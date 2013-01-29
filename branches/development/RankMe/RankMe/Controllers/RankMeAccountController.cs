using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using RankMe.Entities;
using RankMe.Filters;
using RankMe.Utilities;


namespace RankMe.Controllers
{

	[InitializeSimpleMembership]
	public class RankMeAccountController : BaseController
    {
        //
        // GET: /RankMeAccount/

        public ActionResult Index()
        {
            return View();
        }

		public void Login(string username, string password)
		{
			if (Membership.ValidateUser(username, password))
			{
				FormsAuthentication.SetAuthCookie(username, true);
			}
		}

		[HttpPost]
		public JsonResult Signup(RankMeUser rankMeUser, string password)
		{
			JsonResult result = null;
			
			try
			{
				MembershipUser member = Membership.GetUser(rankMeUser.Email);
				if (member == null)
				{
					Membership.CreateUser(
						rankMeUser.UserName,
						password,
						rankMeUser.Email
					);
				}
			}
			catch (Exception ex)
			{

				this.RankMeResponse.EnclosObject = Helper.ManageException(ex);
				result = Json(this.RankMeResponse); 
			}

			return result;
		}

		[HttpPost]
		public JsonResult RecoverAccount(string email)
		{



			JsonResult result = null;
			string password = null;
			MembershipUser member = null;
			string emailContent = null;
			
			try
			{

				member = Helper.GetUserByEmail(email);
				password = member.ResetPassword();
				emailContent = Helper.OverrideTemplate(
					"RecoveryEmail",
					new List<KeyValuePair<string, string>>(
						new KeyValuePair<string, string>[]{ Helper.GetSimpleKV("password",password)}
					)
				);


				Helper.SendEmail
				(
					"mcpyx.info@gmail.com", 
					new string[] { "codeengine@live.com" },
					"Hello RankMe", 
					emailContent
				);
			}
			catch (Exception ex)
			{

				this.RankMeResponse.EnclosObject = Helper.ManageException(ex);
				result = Json(this.RankMeResponse);
			}



			

			return result;
		}


		public void Signout()
		{
			FormsAuthentication.SignOut();
		}




    }
}
