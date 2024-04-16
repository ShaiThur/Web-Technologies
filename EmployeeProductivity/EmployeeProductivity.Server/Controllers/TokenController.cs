using Application.Common.Interfaces.Identity;
using Domain.Constants;
using EmployeeProductivity.Server.Models.UserModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeProductivity.Server.Controllers
{
    [ApiController]
    public class TokenController : BaseController
    {
        private readonly ITokenService _tokenService;

        public TokenController(ISender sender, ITokenService tokenService) : base(sender)
        {
            _sender = sender;
            _tokenService = tokenService;
        }

        //[Authorize(Policy = Polices.CanUpdate)]
        [HttpPost]
        public async Task<IActionResult> RefreshUserTokensAsync([FromBody] RefreshUserRequest request)
        {
            var result = await _tokenService.RefreshUserTokenAsync(request.AccessToken, request.RefreshToken);
            return Ok(new { accessToken = result.Item1, refreshToken = result.Item2 });
        }

        //[Authorize(Policy = Polices.CanRevokeTokens)]
        [HttpDelete]
        public async Task<IActionResult> RevokeRefreshTokenAsync([FromBody] RevokeUserRequest request)
        {
            await _tokenService.RevokeUserRefreshTokenAsync(request.Login, request.RefreshToken);
            return Ok();
        }
    }
}
