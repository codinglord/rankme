using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using RankMe.Exceptions;
using System.Configuration;
using System.Web.Security;

namespace RankMe.Utilities
{
	public static class Helper
	{

		public static Exception ManageException(Exception ex)
		{
			return RankMeManagedException.GetManagedException(ex);
		}

		public static string GetGadgetId(object obj)
		{
			return obj.GetHashCode().ToString();
		}

		public static void SendEmail(string emailFrom,string[] emailTo,string subject,string body)
		{
			if (!ConfigurationManager.AppSettings["RankMe:EnableEmail"].Equals("true"))
			{
				return;
			}



			SmtpClient ss = new SmtpClient("smtp.gmail.com", 587);
			ss.EnableSsl = true;
			ss.Timeout = 10000;
			ss.DeliveryMethod = SmtpDeliveryMethod.Network;
			ss.UseDefaultCredentials = false;
			ss.Credentials = new NetworkCredential("mcpyx.info@gmail.com", "");

			foreach (var i in emailTo)
			{
				MailMessage mm = new MailMessage(emailFrom, i, subject, body);
				mm.BodyEncoding = UTF8Encoding.UTF8;
				mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
				ss.Send(mm);
			}

		}

		public static string OverrideTemplate(string id,List<KeyValuePair<string,string>> cKeyValue)
		{ 
			return TemplateManager.WriteText(id,cKeyValue);
		}

		public static KeyValuePair<string, string> GetSimpleKV(string key,string value)
		{
			return new KeyValuePair<string, string>(key,value);
		}

		public static MembershipUser GetUserByEmail(string email)
		{
			string user = Membership.GetUserNameByEmail(email);
			return Membership.GetUser(user);
		}

	}
}