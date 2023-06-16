using testPAN.Domain.Entity;
using testPAN.Domain.Repo;

namespace testPAN.Services.impl
{
    public class UserServiceImpl : IUserService
    {

        private readonly IUserRepo _userRepo;

        public UserServiceImpl(IUserRepo userRepo) { 
            _userRepo = userRepo;
        }
        public async Task<User> GetUserByEmail(string email)
        {
            return await _userRepo.GetUserByEmail(email);
        }
    }
}
