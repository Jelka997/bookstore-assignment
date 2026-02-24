using AutoMapper;
using BookstoreApplication.DTOs;
using BookstoreApplication.Exceptions;
using BookstoreApplication.Models;
using Microsoft.AspNetCore.Identity;

namespace BookstoreApplication.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper mapper;

        public AuthService(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            this.mapper = mapper;
        }

        public async Task RegisterUserAsync(RegistrationDto registrationDto)
        {
            var user = mapper.Map<ApplicationUser>(registrationDto);
            var result = await _userManager.CreateAsync(user, registrationDto.Password);
            if (!result.Succeeded)
            {
                string message = string.Join("; ", result.Errors.Select(e => e.Description));
                throw new BadRequestException(message);
            }
        }

        public async Task LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.Username);
            if (user == null)
            {
                throw new BadRequestException("Invalid username or password.");
            }
            var passwordMatch = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!passwordMatch)
            {
                throw new BadRequestException("Invalid username or password.");
            }

        }
    }
}
