using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using api.Models;
using api.Interfaces;
using api.Data;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // GET: api/Employee
        [EnableCors("OpenPolicy")]
        [HttpGet]
        public List<Employee> Get()
        {
            IEmployeeDataHandler dataHandler = new EmployeeDataHandler();
            return dataHandler.Select(); 
        }

        // GET: api/Employee/5
        [EnableCors("OpenPolicy")]
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Employee
        [EnableCors("OpenPolicy")]
        [HttpPost]
        public void Post([FromBody] Employee value)
        {
            value.dataHandler.Insert(value);
        }

        // PUT: api/Employee/5
        [EnableCors("OpenPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee value)
        {
            value.dataHandler.Update(value); 
        }

        // DELETE: api/Employee/5
        [EnableCors("OpenPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
