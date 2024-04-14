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

        [Authorize(Policy = Polices.CanUpdate)]
        [HttpPost]
        public async Task<IActionResult> RefreshUserTokensAsync([FromBody] RefreshUserRequest request)
        {
            var result = await _tokenService.RefreshUserTokenAsync(request.AccessToken, request.RefreshToken);
            return Ok(new { accessToken = result.Item1, refreshToken = result.Item2 });
        }

        [Authorize(Policy = Polices.CanDelete)]
        [HttpDelete]
        public async Task<IActionResult> RevokeRefreshTokenAsync([FromBody] RevokeUserRequest request)
        {
            await _tokenService.RevokeUserRefreshTokenAsync(request.Login, request.RefreshToken);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUserAsync([FromBody] LoginUserRequest request)
        {
            await _identityService.DeleteUserAsync(request.Email, request.Password);
            return Ok();
        }
    }
}

