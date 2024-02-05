using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MoviesWebApp.Pages.Series
{
    [Authorize]
    public class TopIMDBModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
