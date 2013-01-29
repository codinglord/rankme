using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace RankMe.Extensions
{
	public class ExtendedMembership
	{

		public static Membership GetUserByEmail(this Membership member,string email)
		{
			string user = Membership.GetUserNameByEmail(email);
			return Membership.GetUser(user);
		}

	}
}