using System.Threading.Tasks;
using Task4AuthWebApp.Entities;

namespace Task4AuthWebApp.Services.Interfaces
{
    public interface IAuthService
    {
        Task<User> SignInAsync(string email, string password);

        Task<User> SignUpAsync(string email, string userName, string password);

        Task Logout();
    }
}
