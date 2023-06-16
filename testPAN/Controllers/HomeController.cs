using Microsoft.AspNetCore.Mvc;
using testPAN.Domain.Entity;
using testPAN.RequestApi;
using testPAN.ResponseApi;
using testPAN.Services;

namespace testPAN.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        private IOrganizationChechService organizationChechService;
        private IUserRequestService userRequestService;
        private IUserService userService;

        public HomeController(IOrganizationChechService organizationChechService, IUserRequestService userRequestService)
        {
            this.organizationChechService = organizationChechService;
            this.userRequestService = userRequestService;
        }

        public async Task<UserRequestResponseApi> CheckOrganization(UserRequestApi userRequestApi)
        {
            User user = await userService.GetUserByEmail(userRequestApi.email);
            UserRequest ur = null;

            if(user == null)
            {
                user = new User()
                {
                    email = userRequestApi.email,
                };
                ur = new UserRequest()
                {
                    user = user,
                    pan = userRequestApi.pan,
                };
            }

            ur.inLocalDB = await organizationChechService.CheckInLocalDb(userRequestApi.pan);
            ur.inAnotherDB = await organizationChechService.CheckInAnotherApi(userRequestApi.pan);
            ur = await userRequestService.Save(ur);

            return new UserRequestResponseApi()
            {
                pan = ur.pan,
                inAnotherDB = ur.inAnotherDB,
                inLocalDB = ur.inLocalDB,
            };
        }
    }
}
