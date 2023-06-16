using testPAN.Domain.Entity;

namespace testPAN.Services
{
    public interface IUserService
    {

        Task<User> GetUserByEmail(string email);

    }
}
