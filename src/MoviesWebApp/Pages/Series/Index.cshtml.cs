using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesWebApp.Business.DTOs.SerialDTOs;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Core.Models;
using MoviesWebApp.ViewModels;

namespace MoviesWebApp.Pages.Series
{
    public class IndexModel : PageModel
    {
        private readonly ISerialService _serialService;
        private readonly IMapper _mapper;

        [BindProperty]
        public PaginatedModelList<SerialUserIndexDto> Serials { get; set; }
        public IndexModel(ISerialService serialService, IMapper mapper)
        {
            this._serialService = serialService;
            this._mapper = mapper;
        }
        public async Task<IActionResult> OnGet(int paged)
        {
            ICollection<Serial> serials = _serialService.GetAll(s => s.IsDeleted == false, "Seasons").Result.ToList();
            ICollection<SerialUserIndexDto> serialUserIndexDtos = new List<SerialUserIndexDto>();
            SerialUserIndexDto serialUserIndexDto = null;
            foreach (var serial in serials)
            {
                serialUserIndexDto = _mapper.Map(serial, serialUserIndexDto);
                if (serialUserIndexDto is not null)
                    serialUserIndexDtos.Add(serialUserIndexDto);
            }
            PaginatedModelList<SerialUserIndexDto> paginatedSerials = PaginatedModelList<SerialUserIndexDto>.Create(serialUserIndexDtos.AsQueryable(), paged, 50);
            Serials = paginatedSerials;
            return Page();
        }
    }
}
