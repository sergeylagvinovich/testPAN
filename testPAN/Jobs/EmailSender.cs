using Quartz;
using System.Net.Mail;
using System.Net;
using testPAN.Domain.Entity;
using testPAN.Domain.Repo;
using testPAN.Services;

namespace testPAN.Jobs
{
    public class EmailSender : IJob
    {

        private readonly IServiceProvider _serviceProvider;
        public EmailSender(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                int page = 1;
                var checkOrganizationService = scope.ServiceProvider.GetRequiredService<IOrganizationChechService>();
                var userRequestRepo = scope.ServiceProvider.GetRequiredService<IUserRequestRepo>();
                List<UserRequest> users = await userRequestRepo.List(page);
                bool haveUsers = users.Count > 0;
                int countSend = 0;
                while (haveUsers)
                {
                    foreach (UserRequest userRequest in users)
                    {
                        bool inLocalDB = await checkOrganizationService.CheckInLocalDb(userRequest.pan);
                        bool inAnotherDB = await checkOrganizationService.CheckInAnotherApi(userRequest.pan);

                        if (inLocalDB == userRequest.inLocalDB && inAnotherDB == userRequest.inAnotherDB)
                            continue;
                        string messageBody = $"Изменился статус организации c unp - {userRequest.pan}\n";
                        messageBody += inLocalDB != userRequest.inLocalDB ? "в локальной базе\n" : "";
                        messageBody += inAnotherDB != userRequest.inAnotherDB ? "в сторонней базе\n" : "";

                        userRequest.inLocalDB = inLocalDB;
                        userRequest.inAnotherDB = inAnotherDB;
                        await userRequestRepo.Save(userRequest);
                        using (MailMessage message = new MailMessage("testsmpttestsmtp@gmail.com", userRequest.user.email))
                        {
                            message.Subject = "Уведомление об изменении статуса организации";
                            message.Body = messageBody;
                            using (SmtpClient client = new SmtpClient
                            {
                                EnableSsl = true,
                                Host = "smtp.gmail.com",
                                Port = 587,
                                Credentials = new NetworkCredential("testsmpttestsmtp@gmail.com", "scspahiiisxbabss")
                            })
                            {
                                await client.SendMailAsync(message);

                            }
                        }
                        countSend++;
                        Thread.Sleep(5000);
                        if (countSend >= 100)
                        {
                            countSend = 0;
                            Thread.Sleep(300000);
                        }
                    }
                    page++;
                    users = await userRequestRepo.List(page);
                    haveUsers = users.Count > 0;
                }
            }

        }
    }
}
