using FinancialRiskManagement.Business.Dto;
using FinancialRiskManagement.Business.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MultiTenantFinancialRiskManagement.Controllers
{
    // Controllers/BusinessTopicController.cs
    [ApiController]
    [Route("api/[controller]")]
    public class BusinessTopicController : ControllerBase
    {
        private readonly IBusinessTopicService _businessTopicService;

        public BusinessTopicController(IBusinessTopicService businessTopicService)
        {
            _businessTopicService = businessTopicService;
        }

        // GET: api/BusinessTopic
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusinessTopicDto>>> GetAll()
        {
            var businessTopics = await _businessTopicService.GetAllAsync();
            return Ok(businessTopics);
        }

        // GET: api/BusinessTopic/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BusinessTopicDto>> GetById(int id)
        {
            var businessTopic = await _businessTopicService.GetByIdAsync(id);
            if (businessTopic == null)
            {
                return NotFound();
            }
            return Ok(businessTopic);
        }

        // POST: api/BusinessTopic
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] BusinessTopicDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _businessTopicService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        // PUT: api/BusinessTopic/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] BusinessTopicDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }
            await _businessTopicService.UpdateAsync(dto);
            return NoContent();
        }

        // DELETE: api/BusinessTopic/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _businessTopicService.DeleteAsync(id);
            return NoContent();
        }
    }
}
