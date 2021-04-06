using System.Threading.Tasks;

namespace Inventura.ApplicationCore.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}