using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Softplayer.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Api2Controller : ControllerBase
    {
        private readonly HttpClient client;

        public Api2Controller()
        {
            if (client == null)
            {
                client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44356/");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            }
        }

        [HttpGet]
        [Route("calculajuros/")]
        public ActionResult<decimal> Get(decimal valorInicial, int tempo)
        {
            if (valorInicial<=0 || tempo<=0)
                return BadRequest();

            var controller = new Api1Controller();            
            HttpResponseMessage response = client.GetAsync("api1/taxajuros").Result;
                        
            if (response.IsSuccessStatusCode)
            {
                var jurosApi = JsonConvert.DeserializeObject<decimal>(response.Content.ReadAsStringAsync().Result);
                var valorFinal = Math.Pow((double)(valorInicial*(1+ jurosApi)),tempo);
                return (decimal)Math.Round(valorFinal, 2);
            }
            return 0;
        }

        [HttpGet]
        [Route("showmethecode")]
        public ActionResult<string> Get()
        {
            return "https://github.com/CarlosEduardoSouza/LAB-WebApi_NetCore_SOFTPLAN";
        }
    }
}
