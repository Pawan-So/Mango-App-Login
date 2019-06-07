using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoLogin.Asset
{
    static class Constants
    {
		public const string emailRegex = @"^(?=.{4,100}$)[_a-zA-Z0-9-]+(\.[_a-zA-Z0-9-]+)*@[a-zA-Z0-9-]+(\.[a-zA-Z0-9-]+)*(\.[a-zA-Z]{2,4})$";
		public const string serviceURL = "https://alivance.mangoapps.com/api/login.json";
		public const string successMessage = "You are Logged in Successfully";
		public static string errorMessage = "We were unable to reach the server or it did not properly respond."+Environment.NewLine+Environment.NewLine+
			"kindly verify the following and try again:"+Environment.NewLine+"1.Your Domain URL is correct(e.g. https://demo.mangoapps.com)."+Environment.NewLine+ "2.You are connected to the internet"
			+ Environment.NewLine+"3.The proxy settings are configured correctly in preferences (if you use a proxy to connect to the internet)"+Environment.NewLine+
			"4.Server may be temporily down.Please re-try in a few minutes.";
    }
}
