using testPAN.Domain.Repo;

namespace testPAN.Services.impl
{
    public class OrganizationServiceImpl : IOrganizationService, IOrganizationChechService
    {
        private readonly IOrganizationRepo organizationRepo;

        public OrganizationServiceImpl(IOrganizationRepo organizationRepo)
        {
            this.organizationRepo = organizationRepo;
        }

        public async Task<bool> CheckInAnotherApi(int pan)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync($"https://www.portal.nalog.gov.by/grp/getData?unp={pan}&charset=UTF-8&type=json");

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> CheckInLocalDb(int pan)
        {
            var organization = await organizationRepo.GetOrganizationByPan(pan);

            return organization != null;
        }
    }
}
