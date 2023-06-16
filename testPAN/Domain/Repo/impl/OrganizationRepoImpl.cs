using Microsoft.EntityFrameworkCore;
using testPAN.Core;
using testPAN.Domain.Entity;

namespace testPAN.Domain.Repo.impl
{
    public class OrganizationRepoImpl : IOrganizationRepo
    {
        ApplicationDataBase _context;
        public OrganizationRepoImpl(ApplicationDataBase context) { 
            _context = context;
        }

        public async Task<Organization> GetOrganizationByPan(int pan)
        {
            return await _context.organizations.Where(x => x.pan == pan).FirstOrDefaultAsync();
        }
    }
}
