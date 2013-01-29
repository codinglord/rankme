using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RankMe.Exceptions
{
	public class RankMeManagedException : Exception
	{
		private Exception exception;

		public string ManagedMessage { get; private set; }


		public RankMeManagedException(Exception exception) 
		{

			this.ManagedMessage = exception.Message;

		}



		public static Exception GetManagedException(Exception exception)
		{
			Type type = exception.GetType();
			RankMeManagedException rankMeManagedException = new RankMeManagedException(exception);
			switch (type.FullName)
			{

				case "System.Web.Security.MembershipCreateUserException":
					{
						if (exception.Message == "The password supplied is invalid.  Passwords must conform to the password strength requirements configured for the default provider.")
						{
							rankMeManagedException.ManagedMessage = exception.Message;
						}

						return rankMeManagedException;
					}
				default:
					{
						return exception;
					}
			}

		}

	}
}