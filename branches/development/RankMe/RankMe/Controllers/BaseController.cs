using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RankMe.Entities;

namespace RankMe.Controllers
{
    public class BaseController : Controller
    {

		protected RankMeResponse RankMeResponse { get; set; }

		public BaseController()
		{
			this.RankMeResponse = new RankMeResponse();
		}


        public ActionResult Index()
        {
            return View();
        }

    }
}
