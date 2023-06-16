using testPAN.Domain.Entity;

namespace testPAN.Services
{
    public interface IUserRequestService
    {
        Task<UserRequest> Save(UserRequest request);


    }
}
