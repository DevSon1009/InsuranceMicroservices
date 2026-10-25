using System.Security.Cryptography;
using System.Text;
using AuthService.Models;

namespace AuthService.Services;

/// <summary>
/// Kho người dùng trong bộ nhớ, đủ cho bài thực hành.
/// Thực tế sẽ thay bằng CSDL và lưu mật khẩu đã băm.
/// </summary>
public class InMemoryUserStore : IUserStore
{
    private static readonly UserAccount[] Users =
    {
        new()
        {
            Login = "jimmy.sales", Password = "secret", DisplayName = "Jimmy Sales",
            UserType = "SALESMAN", Roles = new[] { "Salesman" },
            Avatar = "https://i.pravatar.cc/150?u=jimmy.sales"
        },
        new()
        {
            Login = "mary.sales", Password = "secret", DisplayName = "Mary Sales",
            UserType = "SALESMAN", Roles = new[] { "Salesman" },
            Avatar = "https://i.pravatar.cc/150?u=mary.sales"
        },
        new()
        {
            Login = "admin", Password = "secret", DisplayName = "Administrator",
            UserType = "SALESMAN", Roles = new[] { "Salesman", "Admin" },
            Avatar = "https://i.pravatar.cc/150?u=admin"
        }
    };

    public UserAccount? Validate(string login, string password)
    {
        var user = Users.FirstOrDefault(u => string.Equals(u.Login, login, StringComparison.OrdinalIgnoreCase));
        if (user is null)
        {
            return null;
        }

        var expected = Encoding.UTF8.GetBytes(user.Password);
        var actual = Encoding.UTF8.GetBytes(password ?? string.Empty);
        return CryptographicOperations.FixedTimeEquals(expected, actual) ? user : null;
    }
}
