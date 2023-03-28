using OnlineTest.Services.DTO;

namespace OnlineTest.Services.Interfaces
{
    public interface IMailService
    {
        bool SendMail(MailDTO mail);
    }
}