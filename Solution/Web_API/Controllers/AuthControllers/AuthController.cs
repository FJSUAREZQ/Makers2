using _1.DAL.DataContext;
using _2.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Web_API.DTOs;
using Web_API.Helpers;

namespace Web_API.Controllers.AuthControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {


        private readonly IServices _services;
        private readonly IConfiguration _configuration;

        public AuthController(IServices services, IConfiguration configuration)
        {
            this._services = services;
            _configuration = configuration;
        }


        //-- /api/account/register
        //[HttpPost("register")]
        //public async Task<IActionResult> Register([FromBody] RegisterModel_DTO model)
        //{
        //    try
        //    {
        //        var user = new User { UserName = model.UserName, PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password) };
        //        await _services.CreateUser(user);

        //        return Ok(new { Message = "User registered successfully." });
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }
        //}


        //-- /api/account/login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel_DTO model)
        {
            try
            {
                var user = await _services.GetUserLogin(model.UserName.Trim().ToString());


                if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.Email))
                {
                    return Unauthorized(new { Message = "Invalid username or password." });
                }

                var token = GenerateToken.GenerateJwtToken(user, _configuration);


                return Ok(new
                {
                    Token = token,
                    User = new { user.Id, user.Nombre },
                    // Datos = datos
                });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        [HttpGet]
        [Route("GetUsersAu")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetAuthorize()
        {
            try
            {
                List<Usuario> list_p = await _services.GetUsersAll();

                if (list_p.Count <= 0)
                {
                    return NotFound("There are not users");
                }

                return Ok(list_p);
            }
            catch (Exception ex)
            {
                return NotFound("There was a problem: " + ex.Message.ToString());
            }
        }



        //api/account/GetUsers
        [HttpGet]
        [Route("GetUsers")]
        public async Task<ActionResult<IEnumerable<Usuario>>> Get()
        {
            try
            {
                List<Usuario> list_p = await _services.GetUsersAll();

                if (list_p.Count <= 0)
                {
                    return NotFound("There are not users");
                }

                return Ok(list_p);
            }
            catch (Exception ex)
            {
                return NotFound("There was a problem: " + ex.Message.ToString());
            }
        }



    }
}
