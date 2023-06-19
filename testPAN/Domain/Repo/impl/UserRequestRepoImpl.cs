using Microsoft.EntityFrameworkCore;
using testPAN.Core;
using testPAN.Domain.Entity;

namespace testPAN.Domain.Repo.impl
{
    public class UserRequestRepoImpl : IUserRequestRepo
    {
        public ApplicationDataBase _context;

        public UserRequestRepoImpl(ApplicationDataBase context)
        {
            _context = context;
        }
        public async Task<List<UserRequest>> List(int page = 1, int pageSize = 100)
        {
            return await _context.userRequests.Skip((page - 1) * pageSize).Take(pageSize).Include(x=>x.user).ToListAsync();
        }

        public async Task<UserRequest> Save(UserRequest request)
        {
            if (request.id == null)
            {
                _context.Add(request);
            }
            else
            {
                _context.Update(request);
            }
            _context.SaveChangesAsync();
            return request;
        }
    }
}
