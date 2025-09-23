using Microsoft.AspNetCore.Http;
using OnlineStore.Domain.SeedWork;
using static System.Net.WebRequestMethods;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace OnlineStore.Application.Services.UserContext
{
    public class UserContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContextService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int GetCurrentUserId()
        {
            var user = _httpContextAccessor.HttpContext?.User;
            if (user?.Identity?.IsAuthenticated != true)
                throw new UnauthorizedAccessException("User is not authenticated.");

            var idClaim =
                user.FindFirst("Id") ??
                user.FindFirst(ClaimTypes.NameIdentifier) ??
                user.FindFirst(JwtRegisteredClaimNames.Sub);

            if (idClaim == null)
                throw new InvalidOperationException("User Id claim is missing.");

            if (!int.TryParse(idClaim.Value, out var userId))
                throw new InvalidOperationException("Invalid user Id claim.");

            return userId;

        }
    }
}
