using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using XnxGaming.Models;
using System.Data.Entity;

namespace XnxGaming.Controllers
{

    [Session]
    public class TeamRequestController : Controller
    {
        private readonly XnxGamingEntities db = new XnxGamingEntities();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult TeamJoinRequest()
        {
            var playerId = (string)Session["Id"];

            var request = db.PlayerRequests.Include(x=>x.Team).Where(x => x.PlayerId == playerId).Select(
                x=> new TeamJoinRequest()
                {
                    TeamId=x.Team.Id,
                    TeamLogo=x.Team.TeamImage,
                    TeamName=x.Team.TeamName
                }).SingleOrDefault();
            return Json(request, JsonRequestBehavior.AllowGet);
        }
    }

    class TeamJoinRequest
    {
        public string TeamName { get; set; }
        public int TeamId { get; set; }
        public string TeamLogo { get; set; }
    }
}