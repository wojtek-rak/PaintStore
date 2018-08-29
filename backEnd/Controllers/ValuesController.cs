using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
//using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using backEnd.Models;
using System.Net;

/// <summary>
///  FOR TESTING!!!!!!!!!!!!!!!!!!!!!!!!!!
/// </summary>
namespace backEnd.Controllers
{
    [Route("api/[controller]")]
    //[EnableCors(origins: "http://mywebclient.azurewebsites.net", headers: "*", methods: "*")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        // POST api/values
        //[HttpPost]
        //public Comments Post([FromBody] Comments comments)//[FromBody]string value)
        //{
        //    return comments;

        //}
        //[HttpPost("{id}")]
        //public string Post2([FromBody] Comments comments, string id)//[FromBody]string value)
        //{
        //    return id;

        //}


        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
