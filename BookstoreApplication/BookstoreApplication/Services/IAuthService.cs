using BookstoreApplication.DTOs;
using System.Security.Claims;

namespace BookstoreApplication.Services
{
    public interface IAuthService
    {
        Task RegisterUserAsync(RegistrationDto registrationDto);
        Task<string> LoginAsync(LoginDto loginDto);
        Task<ProfileDto> GetProfile(ClaimsPrincipal user);
    }
}