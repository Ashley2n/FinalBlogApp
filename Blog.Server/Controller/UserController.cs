using Blog.Application.DTO.Users;
using Blog.Application.Interfaces;
using Blog.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Server.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        // GET: api/user
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers(CancellationToken ct)
        {
            var users = await _userService.GetAllUsers(ct);
            return Ok(users);
        }

        // GET: api/user/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<User>> GetUserById(int id, CancellationToken ct)
        {
            var user = await _userService.GetUserById(id, ct);
            if (user == null)
            {
                _logger.LogWarning("User with ID {UserId} not found.", id);
                return NotFound();
            }

            return Ok(user);
        }

        // POST: api/user
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] CreateUserDto dto, CancellationToken ct)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userService.CreateUserAsync(dto, ct);
            _logger.LogInformation("User {UserId} created successfully.", user.Id);

            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        // PUT: api/user/{id}
        [HttpPut("{id:int}")]
        public async Task<ActionResult<User>> UpdateUser(int id, [FromBody] UpdateUserDto dto, CancellationToken ct)
        {
            if (id != dto.Id)
                return BadRequest("User ID mismatch.");

            var updatedUser = await _userService.UpdateUserAsync(dto, ct);
            if (updatedUser == null)
                return NotFound();

            _logger.LogInformation("User {UserId} updated successfully.", id);
            return Ok(updatedUser);
        }

        // DELETE: api/user/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id, CancellationToken ct)
        {
            //  Use the existing 7-parameter constructor for UserDto
            var dto = new UserDto(
                id,
                string.Empty,        // firstName
                string.Empty,        // lastName
                string.Empty,        // email
                DateTime.UtcNow,     // accountCreationDate
                string.Empty,        // phoneNumber
                string.Empty         // profilePictureImage
            );

            var result = await _userService.DeleteUserAsync(dto, ct);
            if (!result)
            {
                _logger.LogWarning("Failed to delete user {UserId}. Not found.", id);
                return NotFound();
            }

            _logger.LogInformation("User {UserId} deleted successfully.", id);
            return NoContent();
        }
    }
}
