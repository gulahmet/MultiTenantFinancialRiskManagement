using FinancialRiskManagement.Business.Dto;
using FinancialRiskManagement.Business.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MultiTenantFinancialRiskManagement.Controllers
{
    // Controllers/ContractController.cs
    [ApiController]
    [Route("api/[controller]")]
    public class ContractController : ControllerBase
    {
        private readonly IContractService _contractService;

        public ContractController(IContractService contractService)
        {
            _contractService = contractService;
        }

        // GET: api/Contract
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContractDto>>> GetAll()
        {
            var contracts = await _contractService.GetAllAsync();
            return Ok(contracts);
        }

        // GET: api/Contract/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContractDto>> GetById(int id)
        {
            var contract = await _contractService.GetByIdAsync(id);
            if (contract == null)
            {
                return NotFound();
            }
            return Ok(contract);
        }

        // POST: api/Contract
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ContractDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _contractService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        // PUT: api/Contract/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] ContractDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }
            await _contractService.UpdateAsync(dto);
            return NoContent();
        }

        // DELETE: api/Contract/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _contractService.DeleteAsync(id);
            return NoContent();
        }
    }
}
