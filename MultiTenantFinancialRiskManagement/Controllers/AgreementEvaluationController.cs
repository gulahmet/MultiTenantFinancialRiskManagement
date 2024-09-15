using FinancialRiskManagement.Business.Dto;
using FinancialRiskManagement.Business.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MultiTenantFinancialRiskManagement.Controllers
{
    // Controllers/AgreementEvaluationController.cs
    [ApiController]
    [Route("api/[controller]")]
    public class AgreementEvaluationController : ControllerBase
    {
        private readonly IAgreementEvaluationService _agreementEvaluationService;

        public AgreementEvaluationController(IAgreementEvaluationService agreementEvaluationService)
        {
            _agreementEvaluationService = agreementEvaluationService;
        }

        // GET: api/AgreementEvaluation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgreementEvaluationDto>>> GetAll()
        {
            var agreementEvaluations = await _agreementEvaluationService.GetAllAsync();
            return Ok(agreementEvaluations);
        }

        // GET: api/AgreementEvaluation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AgreementEvaluationDto>> GetById(int id)
        {
            var agreementEvaluation = await _agreementEvaluationService.GetByIdAsync(id);
            if (agreementEvaluation == null)
            {
                return NotFound();
            }
            return Ok(agreementEvaluation);
        }

        // POST: api/AgreementEvaluation
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] AgreementEvaluationDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _agreementEvaluationService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        // PUT: api/AgreementEvaluation/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] AgreementEvaluationDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }
            await _agreementEvaluationService.UpdateAsync(dto);
            return NoContent();
        }

        // DELETE: api/AgreementEvaluation/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _agreementEvaluationService.DeleteAsync(id);
            return NoContent();
        }
    }
}
