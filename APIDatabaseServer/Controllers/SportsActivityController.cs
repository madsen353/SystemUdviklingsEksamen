using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using APIDatabaseServer.ObjectTypes;

namespace APIDatabaseServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SportsActivityController : ControllerBase
    {
            private readonly ILogger<SportsActivityController> _logger;

            public SportsActivityController(ILogger<SportsActivityController> logger)
            {
                _logger = logger;
            }
            [HttpGet]
            public IEnumerable<ServerBasedSportsObject> Get()
            {
            DAL dalen = new DAL();
            List<ServerBasedSportsObject> listOfObjects = dalen.GetActivities();
            return listOfObjects;
            }
    }
}
