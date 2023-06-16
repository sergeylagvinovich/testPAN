using Microsoft.EntityFrameworkCore;
using testPAN.Core;
using testPAN.Domain.Entity;

namespace testPAN.Domain.Repo.impl
{
    public class UserRepoImpl : IUserRepo
    {
        private readonly ApplicationDataBase _context;
        public UserRepoImpl(ApplicationDataBase context) {
            _context = context;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.users.Where(x => x.email == email).FirstOrDefaultAsync();
        }
    }
}
