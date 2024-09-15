using FinancialRiskManagement.Business.Dto;
using FinancialRiskManagement.Business.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MultiTenantFinancialRiskManagement.Controllers
{
    // Controllers/RiskAnalysisController.cs
    [ApiController]
    [Route("api/[controller]")]
    public class RiskAnalysisController : ControllerBase
    {
        private readonly IRiskAnalysisService _riskAnalysisService;

        public RiskAnalysisController(IRiskAnalysisService riskAnalysisService)
        {
            _riskAnalysisService = riskAnalysisService;
        }

        // GET: api/RiskAnalysis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RiskAnalysisDto>>> GetAll()
        {
            var riskAnalyses = await _riskAnalysisService.GetAllAsync();
            return Ok(riskAnalyses);
        }

        // GET: api/RiskAnalysis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RiskAnalysisDto>> GetById(int id)
        {
            var riskAnalysis = await _riskAnalysisService.GetByIdAsync(id);
            if (riskAnalysis == null)
            {
                return NotFound();
            }
            return Ok(riskAnalysis);
        }

        // POST: api/RiskAnalysis
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] RiskAnalysisDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _riskAnalysisService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        // PUT: api/RiskAnalysis/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] RiskAnalysisDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }
            await _riskAnalysisService.UpdateAsync(dto);
            return NoContent();
        }

        // DELETE: api/RiskAnalysis/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _riskAnalysisService.DeleteAsync(id);
            return NoContent();
        }
    }
}
