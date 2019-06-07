using MangoLogin.Asset;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace MangoLogin
{
	public class LoginViewModel : LoginViewModelBase, IDataErrorInfo,IDisposable
	{
		#region Constructor
		/// <summary>
		/// Constructor use to create new login command instances and to give reference of command methods to delegate.
		/// </summary>
		public LoginViewModel()
		{
			MinimizeBtnClick = new LoginCommand(new Action<object>(MinimizeBtn_Click));
			CloseBtnClick = new LoginCommand(new Action<object>(CloseBtn_Click));
			SubmitBtnClicked = new LoginCommand(new Action<object>(SubmitBtn_Click));
			_LoginModel = new LoginModel();
		}
	#endregion

		#region UI Method
		/// <summary>
		/// This funtion is used to minimize the login window when user clicks on "-" minimize button
		/// </summary>
		/// <param name="obj">Takes MainWindow as an object</param>
		private void MinimizeBtn_Click(object obj)
		{
			if (obj != null)
				(obj as MainWindow).WindowState = WindowState.Minimized;
		}
		/// <summary>
		/// This funtion is used to close the login window when user click on "x" close button on window.
		/// </summary>
		/// <param name="obj">Takes MainWindow as an object</param>
		private void CloseBtn_Click(object obj)
		{
			if (obj != null)
				(obj as MainWindow).Close();
		}
		/// <summary>
		/// Submit button click event.This function call Dispatcher on current thread to do Login Authentication asynchronously.
		/// </summary>
		/// <param name="obj"></param>
		private void SubmitBtn_Click(object obj)
		{
			IsSignInBtnEnabled = false;
			Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => LoginAuthentication()));
		}
	#endregion

		#region Properties
		public ICommand MinimizeBtnClick { get; set; }
		public ICommand CloseBtnClick { get; set; }
		public ICommand SubmitBtnClicked { get; set; }
		private LoginModel _loginModel;
		public LoginModel _LoginModel
		{
			get { return _loginModel; }
			set
			{
				_loginModel = value;
				OnPropertyRaised("_LoginModel");
			}
		}
		private SecureString securePassword;
		public SecureString SecurePassword
		{
			get { return securePassword; }
			set
			{
				securePassword = value;
				OnPropertyRaised("SecurePassword");
			}
		}
		private bool isSignInBtnEnabled;
		public bool IsSignInBtnEnabled
		{
			get { return isSignInBtnEnabled; }
			set
			{
				isSignInBtnEnabled = value;
				OnPropertyRaised("IsSignInBtnEnabled");
			}
		}
	#endregion

		#region IDataErrorInfo
		public string Error
		{
			get { throw new NotImplementedException(); }
		}

		public string this[string columnName]
		{
			get
			{
				string result = String.Empty;
				switch (columnName)
				{
					case "SecurePassword":
						ValidatePassword(ref result);
						break;
				};
				return result;
			}
		}
		#endregion

		#region User Methods
		private void ValidatePassword(ref string result)
		{
			if (SecurePassword != null && (SecurePassword.Length < 5 || SecurePassword.Length > 25))
				result = "Password length must be between 5 to 25";
		}
		/// <summary>
		/// This function is used to create a post rest api request to login and show success and error message accordingly.
		/// </summary>
		public void LoginAuthentication()
		{
			try
			{
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Constants.serviceURL);
				request.Method = "POST";
				request.ContentType = "application/json";
				string response = null;
				LoginRequest requestObj = new LoginRequest { username = _LoginModel.UserName, password = ConvertToBase64String(SecurePassword) };
				JObject json = JObject.Parse(JsonConvert.SerializeObject(requestObj));
				JObject obj = new JObject(new JProperty("ms_request", new JObject(new JProperty("user", json))));
				using (var streamWriter = new StreamWriter(request.GetRequestStream()))
				{
					streamWriter.Write(obj.ToString());
					streamWriter.Flush();
					streamWriter.Close();
				}
				var httpResponse = (HttpWebResponse)request.GetResponse();
				using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
				{
					response = streamReader.ReadToEnd();
				}
				if (response != null)
					MessageBox.Show(Constants.successMessage, "Successfull Login", MessageBoxButton.OK, MessageBoxImage.Information);
				else
					MessageBox.Show(Constants.errorMessage, "Unable To Connect", MessageBoxButton.OK, MessageBoxImage.Error);
				IsSignInBtnEnabled = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(Constants.errorMessage, "Unable To Connect", MessageBoxButton.OK, MessageBoxImage.Error);
				IsSignInBtnEnabled = true;
			}
		}
		/// <summary>
		/// This funtion takes Secure string and convert it to plain string and then convert the byte string to base 64 encoded string.
		/// </summary>
		/// <param name="securePassword"></param>
		/// <returns></returns>
		private string ConvertToBase64String(SecureString securePassword)
		{
			if (securePassword == null)
				return string.Empty;
			IntPtr unmanagedString = IntPtr.Zero;
			try
			{
				unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
				var byteString = System.Text.Encoding.UTF8.GetBytes(Marshal.PtrToStringUni(unmanagedString));
				return System.Convert.ToBase64String(byteString);
			}
			finally
			{
				Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
			}
		}
		#endregion

		#region IDisposable Support
		private bool disposedValue = false; // To detect redundant calls

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					if (MinimizeBtnClick != null)
						MinimizeBtnClick = null;
					if (CloseBtnClick != null)
						CloseBtnClick = null;
					if (SubmitBtnClicked != null)
						SubmitBtnClicked = null;
				}
				disposedValue = true;
			}
		}

		~LoginViewModel() {
		   Dispose(false);
		 }

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		#endregion
	}
}
