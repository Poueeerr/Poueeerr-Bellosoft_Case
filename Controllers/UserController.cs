using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Studying.DTOs;
using Studying.DTOs.Views;
using Studying.Services;

namespace Studying.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService) { 
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<UserDTO>>> GetAll()
        {
            var users = await _userService.GetAll();
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }

        [HttpGet("userId/{id}")]

        public async Task<ActionResult<UserDTO>> GetById([FromRoute]int id)
        {
            var user = await _userService.FindById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<ActionResult<UserDTO>> Insert([FromBody] UserModelViewDTO dto)
        {
            var response = await _userService.Insert(dto);
            if (response == null)
            {
                return BadRequest("Email já cadastrado");
            }
            return Ok(response);
        }

        [HttpDelete("id/{id}")]
        public async Task<ActionResult<bool>> Delete([FromRoute] int id)
        {
            var response = await _userService.Delete(id);
            if(response == false)
            {
                return BadRequest("Usuário não encontrado");
            }
            return Ok("Usuário deletado com sucesso");
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult> Login([FromBody] LoginView model)
        {
            bool valid = await _userService.LoginAsync(model); 
            if (valid)
            {
                var token = _userService.GenerateJwtToken(model.Email);
                return Ok(new { Token = token });
            }

            return Unauthorized(new { Message = "Usuário ou senha inválidos" });
        }
    }
}
