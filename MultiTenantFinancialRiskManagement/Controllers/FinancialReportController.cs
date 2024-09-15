using FinancialRiskManagement.Business.Dto;
using FinancialRiskManagement.Business.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MultiTenantFinancialRiskManagement.Controllers
{
    // Controllers/FinancialReportController.cs
    [ApiController]
    [Route("api/[controller]")]
    public class FinancialReportController : ControllerBase
    {
        private readonly IFinancialReportService _financialReportService;

        public FinancialReportController(IFinancialReportService financialReportService)
        {
            _financialReportService = financialReportService;
        }

        // GET: api/FinancialReport
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FinancialReportDto>>> GetAll()
        {
            var financialReports = await _financialReportService.GetAllAsync();
            return Ok(financialReports);
        }

        // GET: api/FinancialReport/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FinancialReportDto>> GetById(int id)
        {
            var financialReport = await _financialReportService.GetByIdAsync(id);
            if (financialReport == null)
            {
                return NotFound();
            }
            return Ok(financialReport);
        }

        // POST: api/FinancialReport
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] FinancialReportDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _financialReportService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        // PUT: api/FinancialReport/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] FinancialReportDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }
            await _financialReportService.UpdateAsync(dto);
            return NoContent();
        }

        // DELETE: api/FinancialReport/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _financialReportService.DeleteAsync(id);
            return NoContent();
        }
    }
}
