using testPAN.Domain.Repo;
using testPAN.Domain.Repo.impl;

namespace testPAN
{
    public static class Initialize
    {
        public static void InitializeRepo(this IServiceCollection services)
        {
            services.AddScoped<IUserRepo, UserRepoImpl>();
            services.AddScoped<IOrganizationRepo, OrganizationRepoImpl>();
            services.AddScoped<IUserRequestRepo, UserRequestRepoImpl>();
        }

        public static void InitializeServices(this IServiceCollection services)
        {

        }

    }
}
