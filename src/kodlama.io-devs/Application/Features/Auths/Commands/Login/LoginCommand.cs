using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Services.AuthServices;
using Application.Services.Repositories;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;

namespace Application.Features.Auths.Commands.Login
{
    public class LoginCommand : IRequest<LoggedInDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string IpAddress { get; set; }

        public class LoginCommandHandler : IRequestHandler<LoginCommand, LoggedInDto>
        {
            private readonly IAuthService _authService;
            private readonly IUserRepository _userRepository;
            private readonly AuthBusinessRules _authBusinessRules;

            public LoginCommandHandler(IAuthService authService, IUserRepository userRepository, AuthBusinessRules authBusinessRules)
            {
                _authService = authService;
                _userRepository = userRepository;
                _authBusinessRules = authBusinessRules;
            }

            public async Task<LoggedInDto> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                // Kullanıcının var olup olmadığını kontrol et
                User? user = await _userRepository.GetAsync(u=>u.Email == request.Email);
                if (user == null || !HashingHelper.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
                {
                    throw new UnauthorizedAccessException("Geçersiz e-posta veya şifre.");
                }

                // Erişim tokeni ve yenileme tokeni oluştur
                AccessToken accessToken = await _authService.CreateAccessToken(user);
                RefreshToken refreshToken = await _authService.CreateRefreshToken(user, request.IpAddress);
                RefreshToken addedRefreshToken = await _authService.AddRefreshToken(refreshToken);

                // Giriş başarılı ise DTO döndür
                LoggedInDto loggedInDto = new()
                {
                    AccessToken = accessToken,
                    RefreshToken = addedRefreshToken
                };

                return loggedInDto;
            }
        }
    }
}
