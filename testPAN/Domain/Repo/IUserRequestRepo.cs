using testPAN.Domain.Entity;

namespace testPAN.Domain.Repo
{
    public interface IUserRequestRepo
    {
        Task<UserRequest> Save(UserRequest request);
        Task<List<UserRequest>> List(int page = 1, int pageSize = 100);
    }
}
