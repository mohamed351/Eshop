using AutoMapper;
using EShop.API.DTOS;
using EShop.API.Errors;
using EShop.Core.Entities.Identity;
using EShop.Core.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EShop.API.Controllers
{
    public class AccountController:BaseAPIController
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly ITokenService tokenService;
        private readonly IMapper mapper;

        public AccountController(UserManager<AppUser> userManager , SignInManager<AppUser> signInManager , ITokenService tokenService , IMapper mapper)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenService = tokenService;
            this.mapper = mapper;
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)
        {
            var user = await userManager.FindByEmailAsync(loginDTO.Email);
            if(user == null)
            {
                return Unauthorized(new APIResponse(401,"UnAuthorized"));
            }
            var result = await signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);
            if (!result.Succeeded)
            {
                return Unauthorized(new APIResponse(401, "UnAuthorized"));
            }
            return Ok(new UserDTO()
            {
                Email = user.Email,
                Token = this.tokenService.CreateToken(user),
                DisplayName = user.DisplayName
            }); 
        }
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<UserDTO>> GetCurrentUser()
        {
            var email = HttpContext.User?.Claims.FirstOrDefault(a => a.Type == ClaimTypes.Email)?.Value;
            var user = await userManager.FindByEmailAsync(email);

            return new UserDTO()
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = tokenService.CreateToken(user)
            };
        }
        [HttpGet("emailexists")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<bool>> CheckEmailExist([FromQuery] string email)
        {
            return await userManager.FindByEmailAsync(email) != null;
        }
        [HttpGet("address")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<AddressDTO>> GetAddressAsync()
        {
            var email = HttpContext.User.Claims.FirstOrDefault(a => a.Type == ClaimTypes.Email)?.Value;
            var address = await userManager.FindByEmailAsync(email);
            return this.mapper.Map<AddressDTO>(address);
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDTO)
        {
            var register = new AppUser()
            {
                DisplayName = registerDTO.DisplayName,
                Email = registerDTO.Email,
                UserName = registerDTO.Email
            };
            var result = await userManager.CreateAsync(register);
            if (!result.Succeeded) return BadRequest(new APIResponse(400));

            return new UserDTO()
            {
                DisplayName = register.UserName,
                Email = register.Email,
                Token = this.tokenService.CreateToken(register)
            };
        }
    }
    
}
