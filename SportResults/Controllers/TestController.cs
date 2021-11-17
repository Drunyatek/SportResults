using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportResults.Class;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportResults.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        // GET: api/<TestController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<TestController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<TestController>
        [HttpPost]
        public async Task<ActionResult<Responce>> Post(s_request request)
        {
            var a = request;
            Responce responce = new Responce()
            {
                CarDateReg = "06.06.2021",
                CarNum = "ВО777Р",
                CarVin = "65496178154",
                CarDocNum = "23436/2/3",
                CarReg = "какой то рег",
                CarModel = "Ланос",
                DebetorSurname = request.body.Familiya,
                DebetorFirstname = request.body.Imya,
                DebetorLastname = request.body.Otchestvo,
                DebetorFullname = request.body.Naimenovanie,
                More = "And one more thing",
                SpecialMessage = "Special message",
                
                ExecutiveProductionId = long.Parse(request.body.ip_id),
            };

            return CreatedAtAction(nameof(Post), responce);
        }

        //// PUT api/<TestController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<TestController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
