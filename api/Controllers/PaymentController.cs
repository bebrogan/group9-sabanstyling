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
    public class PaymentController : ControllerBase
    {
        // GET: api/Payment
        [EnableCors("OpenPolicy")]
        [HttpGet]
        public List<Payment> Get()
        {
            IPaymentDataHandler dataHandler = new PaymentDataHandler();
            return dataHandler.Select(); 
        }

        // GET: api/Payment/5
        [EnableCors("OpenPolicy")]
        [HttpGet("{id}", Name = "GetPayment")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Payment
        [EnableCors("OpenPolicy")]
        [HttpPost]
        public void Post([FromBody] Payment value)
        {
            value.dataHandler.Insert(value); 
        }

        // PUT: api/Payment/5
        [EnableCors("OpenPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Payment value)
        {
            value.dataHandler.Update(value); 
        }

        // DELETE: api/Payment/5
        [EnableCors("OpenPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
