using Application.Common.Interfaces.Identity;
using Domain.Constants;
using EmployeeProductivity.Server.Models.UserModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EmployeeProductivity.Server.Controllers
{
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IIdentityService _identityService;
        private readonly ITokenService _tokenService;

        public UserController(ISender sender,
            IIdentityService service,
            ITokenService tokenService) : base(sender)
        {
            _identityService = service;
            _tokenService = tokenService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] CreateUserRequest request)
        {
            var result = await _identityService.CreateUserAsync(request.Email, request.Password);
            
            if (result.Succeeded)
                return Ok("user was created");
            else
                return Forbid(result.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> AuthorizeUserAsync([FromBody] LoginUserRequest request)
        {
            var result = await _identityService.TryAuthorizeAsync(request.Email, request.Password);

            if (result)
            {
                var tokens = await _tokenService.CreateTokensAsync(request.Email);
                //var options = new CookieOptions
                //{
                //    Domain = Request.Host.ToString(),
                //    //HttpOnly = true
                //};

                var cookieName = "RefreshToken";
                Response.Cookies.Append(cookieName, tokens.Item2);

                return Ok(new { accessToken = tokens.Item1 });
            }

            return NotFound();
        }

        [Authorize(Policy = Polices.CanUpdate)]
        [HttpPost]
        public async Task<IActionResult> RefreshUserTokenAsync(string login)
        {
            var newAccessToken = await _tokenService.RefreshUserTokenAsync(login);
            return Ok(new { accessToken = newAccessToken });
        }

        [Authorize(Policy = Polices.CanSee)]
        [HttpGet]
        public async Task SignOutUserAsync() 
            => await _identityService.SignOutAsync();

        [Authorize(Policy = Polices.CanRevokeTokens)]
        [HttpDelete]
        public async Task<IActionResult> RevokeRefreshTokenAsync(string login)
        {
            await _tokenService.RevokeUserRefreshTokenAsync(login);
            await _identityService.SignOutAsync();
            return Ok();
        }

        [Authorize(Policy = Polices.CanDeleteItself)]
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

