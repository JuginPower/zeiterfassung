using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using ZeitApi.Data.Services;


namespace ZeitApi.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArbeiterController: ControllerBase
    {
        [HttpPost("Login")]
            public IActionResult Index() 
            {
                string username = Request.Form["username"];
                string pwd = Request.Form["pwd"];
                string answer = Authenticator.ToAuthenticate(username, pwd);

                Console.WriteLine("Das ist der User: {0}\nDas ist das Passwort: {1}", username, pwd);
                Console.WriteLine("Das ist die SessionId: {0}", HttpContext.Session.Id);

                if (answer == "Ok")
                {
                    int personid = IdNator.GetId(username, pwd);
                    HttpContext.Session.SetInt32("personid", personid);
                    Console.WriteLine("Die personid in der SessionId: {0}", HttpContext.Session.GetInt32("personid"));
                    return Redirect("https://localhost:5001/dashboard.html");
                }
                else
                {
                    return Ok(answer);
                }
            }
        [HttpPost("State")]
        public IActionResult Details()
        {
            var pessid = HttpContext.Session.GetInt32("personid");
            string answer;

            if (pessid is null)
            {
                Console.WriteLine("Die PersonId ist verloren gegangen.\nDie SessionId lautet jetzt: {0}", HttpContext.Session.Id);
                answer = "fail";
            }
            else
            {
                Console.WriteLine("Die PersonId lautet: {0}\nDie SessionId lautet: {1}", HttpContext.Session.GetInt32("personid"), HttpContext.Session.Id);
                answer = "Succed!";
            }
            return Ok(answer);
        }
    }
}
