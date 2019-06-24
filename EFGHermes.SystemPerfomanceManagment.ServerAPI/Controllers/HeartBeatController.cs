using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EFGHermes.SystemPerfomanceManagment.ServerAPI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class HeartBeatController : Controller
    {
        [HttpGet]
        public ActionResult<string> CheckHeartBeat()
        {
            return "I'am alive";

        }
    }
}