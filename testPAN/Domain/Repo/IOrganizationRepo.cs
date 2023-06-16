using testPAN.Domain.Entity;

namespace testPAN.Domain.Repo
{
    public interface IOrganizationRepo
    {
        Task<Organization> GetOrganizationByPan(int pan);
    }
}
