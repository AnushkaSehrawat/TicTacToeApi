using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicTacToeAssignment.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TicTacToeAssignment.Controllers
{
   
    [Route("api/[controller]")]
    public class IdentityController : Controller
    {
        IRepo dataobject;
        GetRepoInstance getObject = new GetRepoInstance();
     
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            dataobject = getObject.getInstance("sql");
            string token = dataobject.GetFromDB(id);
            return token;

        }

        // POST api/values
        [HttpPost]
       
        [Log]
        [Exception]
        public string create([FromBody]User userobj)
        {
            dataobject = getObject.getInstance("sql");
            string response= dataobject.AddToDB(userobj);
            if (response == null)
            {
                throw new UnauthorizedAccessException("User Already Exists");
            }
           
            return response;
           
        }

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
