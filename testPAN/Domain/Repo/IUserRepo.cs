using testPAN.Domain.Entity;

namespace testPAN.Domain.Repo
{
    public interface IUserRepo
    {
        Task<User> GetUserByEmail(string email);

    }
}
