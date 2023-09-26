using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoviesWebApp.Data;
using MoviesWebApp.Models;
using MoviesWebApp.Models.DTO;

namespace MoviesWebApp.Pages.moviefolder
{
    public class CreateModel : PageModel
    {
        private readonly MoviesWebAppContext _context;
        private readonly IMapper _mapper;
        public readonly IWebHostEnvironment _environment;

        public CreateModel(MoviesWebAppContext context,
            IMapper mapper,
            IWebHostEnvironment environment)
        {
            _context = context;
            _mapper = mapper;
            _environment = environment;
        }
        public List<SelectListItem> GenreList { get; set; } = new();

        public IActionResult OnGet()
        {
            var claims = User.Claims;

            foreach (Genre genreEnum in Enum.GetValues(typeof(Genre)))
                GenreList.Add(new SelectListItem() { Text = genreEnum.ToString(), Value = ((int)genreEnum).ToString() });

            return Page();
        }

        [BindProperty]
        public moviemodel Movies { get; set; } 


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {


            if (!ModelState.IsValid)
                {
                    return Page();
                }

                // The rest of your code
                // ...
            

            var movie =  _mapper.Map<Movies>(Movies);
            
            var FolderImage = Path.Combine(_environment.WebRootPath, "uploads", "images");
            var FolderVideo = Path.Combine(_environment.WebRootPath, "uploads", "images");
            if (!Directory.Exists(FolderImage) || !Directory.Exists(FolderImage))
            {
                Directory.CreateDirectory(FolderImage);
                Directory.CreateDirectory(FolderVideo);
            }
            var filename = Guid.NewGuid() + Path.GetExtension(Movies.Image.FileName);
                var filenameVideo = Guid.NewGuid() + Path.GetExtension(Movies.Video.FileName);
            var filefullpath=Path.Combine(FolderImage, filename);
            var filepathVideo = Path.Combine(FolderVideo, filenameVideo);
            using (var FileStream= new FileStream(filefullpath, FileMode.Create))
            {
                await Movies.Image.CopyToAsync(FileStream);
            }
            using (var FileStream = new FileStream(filepathVideo, FileMode.Create))
            {
                await Movies.Image.CopyToAsync(FileStream);
            }
            movie.ImageURL = filename;
            movie.VideoURL = filenameVideo;
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
