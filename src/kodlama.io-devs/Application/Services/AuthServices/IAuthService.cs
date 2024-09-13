using Core.Security.Entities;
using Core.Security.JWT;

namespace Application.Services.AuthServices
{
    public interface IAuthService
    {
        public Task<AccessToken> CreateAccessToken(User user); // kullanıcıya ait token oluşturulur
        public Task<RefreshToken> CreateRefreshToken(User user, string ipAddress); // kullanıcının yenileme token'ını oluşturur. ipAddres değeri sayesinde token izlenir. Bu güvenlik işlemleri için oldukça önem taşır
        public Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken); //refresh token değerini veritabanına ekler

    }
}
