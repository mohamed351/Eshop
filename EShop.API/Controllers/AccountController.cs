using EShop.API.DTOS;
using EShop.API.Errors;
using EShop.Core.Entities.Identity;
using EShop.Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EShop.API.Controllers
{
    public class AccountController:BaseAPIController
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly ITokenService tokenService;

        public AccountController(UserManager<AppUser> userManager , SignInManager<AppUser> signInManager , ITokenService tokenService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenService = tokenService;
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
