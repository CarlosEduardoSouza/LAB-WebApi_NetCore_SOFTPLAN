using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Softplayer.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Api1Controller : ControllerBase
    {
        [HttpGet]
        [Route("taxaJuros/")]
        public ActionResult<decimal> Get()
        {
            return (decimal)0.01;
        }
    }
}
