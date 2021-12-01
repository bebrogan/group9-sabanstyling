using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendationController : ControllerBase
    {
        // GET: api/Recommendation
        [EnableCors("OpenPolicy")]
        [HttpGet]
        public List<Recommendation> Get()
        {
            IRecommendationDataHandler dataHandler = new RecommendationDataHandler();
            return dataHandler.Select(); 
        }

        // GET: api/Recommendation/5
        [EnableCors("OpenPolicy")]
        [HttpGet("{id}", Name = "GetRec")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Recommendation
        [EnableCors("OpenPolicy")]
        [HttpPost]
        public void Post([FromBody] Recommendation value)
        {
            value.dataHandler.Insert(value); 
        }

        // PUT: api/Recommendation/5
        [EnableCors("OpenPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Recommendation value)
        {
            value.dataHandler.Update(value); 
        }

        // DELETE: api/Recommendation/5
        [EnableCors("OpenPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
