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
    public class ClothingController : ControllerBase
    {
        // GET: api/Clothing
        [EnableCors("OpenPolicy")]
        [HttpGet]
        public List<Clothing> Get()
        {
            IClothingDataHandler dataHandler = new ClothingDataHandler();
            return dataHandler.Select(); 
        }

        // GET: api/Clothing/5
        [EnableCors("OpenPolicy")]
        [HttpGet("{id}", Name = "GetClothing")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Clothing
        [EnableCors("OpenPolicy")]
        [HttpPost]
        public void Post([FromBody] Clothing value)
        {
            value.dataHandler.Insert(value); 
        }

        // PUT: api/Clothing/5
        [EnableCors("OpenPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Clothing value)
        {
            value.dataHandler.Update(value); 
        }

        // DELETE: api/Clothing/5
        [EnableCors("OpenPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
