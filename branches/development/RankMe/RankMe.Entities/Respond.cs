using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RankMe.Entities.Enums;

namespace RankMe.Entities
{
	public class RankMeResponse
	{

		public int StatusCode { get; set; }

		public string Message { get; set; }

		public Object EnclosObject { get; set; }

	}
}
