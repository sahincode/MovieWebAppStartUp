using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoviesWebApp.Data;

namespace MoviesWebApp.Models.LogoinfoModel
{
    public class CreateModel : PageModel
    {
        private readonly MoviesWebApp.Data.MoviesWebAppContext _context;

        public CreateModel(MoviesWebApp.Data.MoviesWebAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public LogoPageInfo LogoPageInfo { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.LogoPageInfo == null || LogoPageInfo == null)
            {
                return Page();
            }

            _context.LogoPageInfo.Add(LogoPageInfo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
