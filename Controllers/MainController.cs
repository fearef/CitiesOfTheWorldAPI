using CitiesOfTheWorldAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CitiesOfTheWorldAPI.Controllers
{
    [ApiController]
    [Route("api")]
    [Route("")]
    public class MainController : ControllerBase
    {

        private readonly ILogger<MainController> _logger;

        public MainController(ILogger<MainController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> PostCityRequestAsync([FromBody] CityRequest cityRequest)
        {
            try
            {              
                HttpContent content = new StringContent(JsonSerializer.Serialize(cityRequest,CityRequest.JsonSerializerOptions), Encoding.UTF8, "application/json");              
                return Ok(new CityResponse() { Population= 1388308 });
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }
            catch (HttpRequestException)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
            catch (Exception)
            {
                return StatusCode(Response.StatusCode);
            }
        }
    }
}
