using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using XnxGaming.Models;
using System.Data.Entity;


namespace XnxGaming.Controllers
{

    [Session]
    public class GamesController : Controller
    {
        // GET: Games

        XnxGamingEntities db = new XnxGamingEntities();
        public ActionResult Index()
        {
            db.Configuration.ProxyCreationEnabled = false;
           
            var players = db.Users.Include(x => x.TeamPlayers).Where(x => x.TeamPlayers.Count == 0).ToList();
            ViewBag.Players = players;

            string id = (string)Session["Id"];
            var playerHavTeam = db.Users.Include(x => x.TeamPlayers).Where(x => x.TeamPlayers.Any(p => p.PlayerId == id)).SingleOrDefault().TeamPlayers.Select(x=>x.TeamId).SingleOrDefault();
            Session["TeamId"] = playerHavTeam;
            var Team = db.Teams.Where(x => x.Id == playerHavTeam).ToList();
            return View(Team);
        }
        [HttpPost]
        public async Task<JsonResult> Index(string q)
        {
            var url = new Uri("http://localhost:4000/");
            var http = new HttpClient();
            http.BaseAddress = url;
            http.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            string token = Session["token"]!=null ? (string)Session["token"] : "";
            http.DefaultRequestHeaders.Authorization =
                                 new AuthenticationHeaderValue("Bearer", token);
            var response = (await http.GetAsync("api/Player/FilterList?searchvalue="+q));



            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Json((await response.Content.ReadAsStringAsync()),JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);


        }
        public ActionResult TeamJoinRequest()
        {
            var playerId =  (string)Session["Id"];
            var team = db.PlayerRequests.Include(x => x.Team).Where(x => x.PlayerId == playerId)
                .Select(x => x.Team).SingleOrDefault();

            return Json(team, JsonRequestBehavior.AllowGet);

        }
        public async Task<ActionResult> SendTeamRequest(string username)
        {
            var url = new Uri("http://localhost:4000/");
            var http = new HttpClient();
            http.BaseAddress = url;
            http.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            string token = Session["token"] != null ? (string)Session["token"] : "";
            http.DefaultRequestHeaders.Authorization =
                                 new AuthenticationHeaderValue("Bearer", token);
            var response = (await http.PostAsJsonAsync("api/PlayerRequest/", new PlayerRequest() {

                PlayerId=username,
                TeamId= Convert.ToInt32(Session["TeamId"])
            }));
            if (response.StatusCode==System.Net.HttpStatusCode.OK)
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
            return Json("", JsonRequestBehavior.AllowGet);

        }

    }
    public class PlayerRequest
    {
        public int TeamId { get; set; }
        public string PlayerId { get; set; }
    }
}