using MoviesWebApp.Core.Models;
namespace MoviesWebApp.Business.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailToUserForConfirmation(UserEmailOptions uSerEmailOptions);
    }
}