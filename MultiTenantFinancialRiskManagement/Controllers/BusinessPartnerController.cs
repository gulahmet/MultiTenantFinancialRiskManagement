using FinancialRiskManagement.Business.Dto;
using FinancialRiskManagement.Business.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MultiTenantFinancialRiskManagement.Controllers
{
    // Controllers/BusinessPartnerController.cs
    [ApiController]
    [Route("api/[controller]")]
    public class BusinessPartnerController : ControllerBase
    {
        private readonly IBusinessPartnerService _businessPartnerService;

        public BusinessPartnerController(IBusinessPartnerService businessPartnerService)
        {
            _businessPartnerService = businessPartnerService;
        }

        // GET: api/BusinessPartner
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusinessPartnerDto>>> GetAll()
        {
            var businessPartners = await _businessPartnerService.GetAllAsync();
            return Ok(businessPartners);
        }

        // GET: api/BusinessPartner/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BusinessPartnerDto>> GetById(int id)
        {
            var businessPartner = await _businessPartnerService.GetByIdAsync(id);
            if (businessPartner == null)
            {
                return NotFound();
            }
            return Ok(businessPartner);
        }

        // POST: api/BusinessPartner
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateBusinessPartnerDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _businessPartnerService.AddAsync(dto);

            if (result.Success)
            {
                return Ok(new { Message = "Business partner created successfully." });
            }
            else
            {
                return StatusCode(500, new { Message = "Failed to create business partner." });
            }
        }

        // PUT: api/BusinessPartner/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] BusinessPartnerDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest(new { Message = "ID mismatch." });
            }

            var result = await _businessPartnerService.UpdateAsync(dto);

            if (result.Success)
            {
                return NoContent();
            }
            else
            {
                return StatusCode(500, new { Message = "Failed to update business partner." });
            }
        }

        // DELETE: api/BusinessPartner/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _businessPartnerService.DeleteAsync(id);

            if (result.Success)
            {
                return NoContent();
            }
            else
            {
                return StatusCode(500, new { Message = "Failed to delete business partner." });
            }
        }
    }
}
