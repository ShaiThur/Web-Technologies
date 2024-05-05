using Application.Common.Interfaces.Identity;
using Domain.Constants;
using EmployeeProductivity.Server.Models.UserModels;
using Infrastructure.Data;
using Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeProductivity.Server.Controllers.UserControllers
{
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IIdentityService _identityService;
        private readonly ITokenService _tokenService;
        private readonly Seed _seed;

        public UserController(ISender sender,
            IIdentityService service,
            ITokenService tokenService,
            Seed seed) : base(sender)
        {
            _identityService = service;
            _tokenService = tokenService;
            _seed = seed;
        }

        [HttpGet]
        public async Task TrySeedAsync()
        {
            await _seed.TrySeed();
        }


        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] CreateUserRequest request)
        {
            var result = await _identityService.CreateUserAsync(request.FirstName, request.LastName, request.Email, request.Password);

            if (result.Succeeded)
                return Ok($"user {request.Email} was created");
            else
                return BadRequest(result.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> AuthorizeUserAsync([FromBody] LoginUserRequest request)
        {
            var result = await _identityService.TryAuthorizeAsync(request.Email, request.Password);

            if (result)
            {
                var tokens = await _tokenService.CreateTokensAsync(request.Email);
                var options = new CookieOptions
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.Lax,
                    Secure = false
                };

                var cookieName = "RefreshToken";
                Response.Cookies.Append(cookieName, tokens.Item2, options);

                return Ok(new { accessToken = tokens.Item1 });
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> RefreshUserTokenAsync([FromHeader] string login)
        {
            var newAccessToken = await _tokenService.RefreshUserTokenAsync(login);
            return Ok(new { accessToken = newAccessToken });
        }

        [Authorize(Policy = Polices.RequireAuthentication)]
        [HttpGet]
        public async Task SignOutUserAsync()
            => await _identityService.SignOutAsync();

        [Authorize(Policy = Polices.RequireAuthentication)]
        [HttpDelete]
        public async Task<IActionResult> RevokeRefreshTokenAsync([FromHeader]  string login)
        {
            await _tokenService.RevokeUserRefreshTokenAsync(login);
            await _identityService.SignOutAsync();
            return Ok();
        }

        [Authorize(Policy = Polices.RequireAuthentication)]
        [HttpGet]
        public async Task<IActionResult> GetUserInformationAsync([FromHeader] string userLogin)
        {
            var user = (ApplicationUser)await _identityService.FindUserAsync(userLogin);

            return Ok(new
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            });
        }

        [Authorize(Policy = Polices.RequireAuthentication)]
        [HttpDelete]
        public async Task<IActionResult> DeleteUserAsync([FromBody] LoginUserRequest request)
        {
            var isDeleted = await _identityService.DeleteUserAsync(request.Email, request.Password);
            if (isDeleted)
                return Ok();
            else
                return Forbid();
        }
    }
}

