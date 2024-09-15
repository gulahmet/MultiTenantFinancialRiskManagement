using FinancialRiskManagement.Business.Dto;
using FinancialRiskManagement.Business.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MultiTenantFinancialRiskManagement.Controllers
{
    // Controllers/UserController.cs
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;


        private readonly ITokenService _tokenService;

        public UserController(IUserService userService,ITokenService tokenService)
        {
            _userService = userService;  
            _tokenService = tokenService;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

    [HttpPost("login")]
public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
{
    // Kullanıcı adı ve şifre doğrulama işlemi
    var user = await _userService.GetUserByUsernameAsync(loginDto);

    if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.PasswordHash, user.PasswordHash))
    {
        return Unauthorized(new { Message = "Invalid username or password." });
    }

    // Token oluşturma
    var token = await _tokenService.GenerateTokenAsync(loginDto.Username);

    return Ok(new { Token = token });
}

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] UserDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _userService.AddUserAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UserDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }
            await _userService.UpdateUserAsync(dto);
            return NoContent();
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
