﻿using Quartz.Impl;
using Quartz.Spi;
using testPAN.Domain.Repo;
using testPAN.Domain.Repo.impl;
using testPAN.Services;
using testPAN.Services.impl;

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
            services.AddScoped<IOrganizationChechService, OrganizationServiceImpl>();
            services.AddScoped<IOrganizationService, OrganizationServiceImpl>();

            //services.AddSingleton<IJobFactory, QuartzJobFactory>(provider =>
            //{
            //    var serviceProvider = provider.GetRequiredService<IServiceProvider>();
            //    return new QuartzJobFactory(serviceProvider);
            //});

            //services.AddSingleton(provider =>
            //{
            //    var schedulerFactory = new StdSchedulerFactory();
            //    var scheduler = schedulerFactory.GetScheduler().GetAwaiter().GetResult();
            //    scheduler.JobFactory = provider.GetRequiredService<IJobFactory>();
            //    scheduler.Start().GetAwaiter().GetResult();
            //    return scheduler;
            //});
            //services.AddTransient<EmailSender>();
        }

    }
}
