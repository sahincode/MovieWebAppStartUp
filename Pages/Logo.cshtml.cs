using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MoviesWebApp.Pages
{
    
    public class LogoModel : PageModel
    {
        private readonly ILogger<LogoModel> _logger;

        public LogoModel(ILogger<LogoModel> logger)
        {
            _logger = logger;
        }

        public void OnGetLogo()
        {

        }
    }
}