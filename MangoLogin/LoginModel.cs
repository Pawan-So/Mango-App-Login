using MangoLogin.Asset;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MangoLogin
{
	public class LoginModel : LoginViewModelBase, IDataErrorInfo
	{
		private string userName;
		public string UserName
		{
			get { return userName; }
			set
			{
				userName = value;
				OnPropertyRaised("UserName");
			}
		}
		private string txtDomainName;
		public string TxtDomainName
		{
			get { return txtDomainName; }
			set
			{
				txtDomainName = value;
				OnPropertyRaised("TxtDomainName");
			}
		}
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
					case "UserName":
						ValidateUserName(ref result);
						break;
				};
				return result;
			}
		}
		public void ValidateUserName(ref string result)
		{
			if (UserName != null && (!Regex.IsMatch(UserName, Constants.emailRegex, RegexOptions.CultureInvariant) || UserName == String.Empty))
				result = "Please Enter a valid Email Id";
		}
	}
}
