using Application.Common.Interfaces.Identity;
using Domain.Constants;
using EmployeeProductivity.Server.Models.UserModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<string[]> RegisterUser([FromBody] CreateUserRequest request)
        {
            var result = await _identityService.CreateUserAsync(request.Email, request.Password);
            return result.Errors;
        }

        [HttpPost]
        public async Task<IActionResult> AuthorizeUserAsync([FromBody] LoginUserRequest loginUser)
        {
            var result = await _identityService.AuthorizeAsync(loginUser.Email, loginUser.Password);
            if (result)
            {
                var tokens = await _tokenService.CreateTokenAsync(loginUser.Email);
                return Ok(new { accessToken = tokens.Item1, refreshToken = tokens.Item2 });
            }

            return NotFound();
        }

        [Authorize(Policy = Polices.CanDeleteItself)]
        [HttpDelete]
        public async Task<IActionResult> DeleteUserAsync([FromBody] LoginUserRequest request)
        {
            await _identityService.DeleteUserAsync(request.Email, request.Password);
            return Ok();
        }

        [Authorize(Policy = Polices.CanSee)]
        [HttpGet]
        public async Task SignOutUserAsync() 
            => await _identityService.SignOutAsync();
    }
}

