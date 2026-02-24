using BookstoreApplication.DTOs;

namespace BookstoreApplication.Services
{
    public interface IAuthService
    {
        Task RegisterUserAsync(RegistrationDto registrationDto);
        Task LoginAsync(LoginDto loginDto);
    }
}