namespace testPAN.Services
{
    public interface IOrganizationChechService
    {

        Task<bool> CheckInLocalDb(int pan);
        Task<bool> CheckInAnotherApi(int pan);

    }
}
