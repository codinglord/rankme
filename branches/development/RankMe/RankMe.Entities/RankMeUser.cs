using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RankMe.Entities.Enums;

namespace RankMe.Entities
{
	[Serializable]
	public class RankMeUser
	{

		public string UserName { get; set; }

		public string Email { get; set; }

		public string AvatarUrl { get; set; }

		public RankMeUserStatus Status { get; set; }

		public DateTime? CreatedDate { get; set; }

		public DateTime? LatestUpdated { get; set; }

	}
}
