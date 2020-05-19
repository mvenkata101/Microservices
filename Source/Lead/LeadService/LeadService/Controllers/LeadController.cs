using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using LeadService.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeadService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadController : ControllerBase
    {
        private readonly ILeadRepository _leadRepository = null;

        public LeadController(ILeadRepository leadRepository)
        {
            _leadRepository = leadRepository;
        }

        // GET: api/Lead
        [HttpGet]
        public IActionResult Get()
        {
            var leads = _leadRepository.GetLeads();
            return new OkObjectResult(leads);
        }

        // GET: api/Lead/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var lead = _leadRepository.GetLeadByID(id);
            return new OkObjectResult(lead);
        }

        // POST: api/Lead
        [HttpPost]
        public IActionResult Post([FromBody] Lead lead)
        {
            using (var scope = new TransactionScope())
            {
                _leadRepository.InsertLead(lead);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = lead.Id }, lead);
            }
        }

        // PUT: api/Lead/5
        [HttpPut]
        public IActionResult Put([FromBody] Lead lead)
        {
            if (lead != null)
            {
                using (var scope = new TransactionScope())
                {
                    _leadRepository.UpdateLead(lead);
                    scope.Complete();
                    return new OkResult();
                }
            }

            return new NoContentResult();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _leadRepository.DeleteLead(id);
            return new OkResult();
        }
    }
}
