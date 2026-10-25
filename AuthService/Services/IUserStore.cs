using AuthService.Models;

namespace AuthService.Services;

public interface IUserStore
{
    /// <summary>Trả về tài khoản nếu login/password đúng, ngược lại trả về null.</summary>
    UserAccount? Validate(string login, string password);
}
