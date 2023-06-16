using testPAN.Domain.Entity;
using testPAN.Domain.Repo;

namespace testPAN.Services.impl
{
    public class UserRequestServiceImpl : IUserRequestService
    {

        private readonly IUserRequestRepo requestRepo;

        public UserRequestServiceImpl(IUserRequestRepo requestRepo)
        {
            this.requestRepo = requestRepo;
        }

        public async Task<UserRequest> Save(UserRequest request)
        {
            return await requestRepo.Save(request);
        }
    }
}
