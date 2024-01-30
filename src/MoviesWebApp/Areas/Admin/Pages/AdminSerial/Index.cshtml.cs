using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesWebApp.Business.DTOs.SerialDTOs;
using MoviesWebApp.Business.Exceptions.ReferenceExceptions;
using MoviesWebApp.Business.Exceptions.SerialModelExceptions;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Core.Models;

namespace MoviesWebApp.Areas.Admin.Pages.AdminSerial
{
    public class IndexModel : PageModel
    {
        private readonly ISerialService _serialService;
        private readonly IMapper _mapper;

        public IndexModel( ISerialService serialService, IMapper mapper)
        {
            this._serialService = serialService;
            this._mapper = mapper;
        }

        public IList<SerialIndexDto> SerialIndexDtos { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            IEnumerable<Serial> serials = await  _serialService.GetAll(null, null);
            List<SerialIndexDto> serialIndexDtos = new List<SerialIndexDto>();
            foreach(var serial in serials)
            {
                SerialIndexDto serialIndexDto = _mapper.Map<SerialIndexDto>(serial);
                serialIndexDtos.Add(serialIndexDto);
            }
            SerialIndexDtos = serialIndexDtos;
            return Page();
        }
        public async Task<IActionResult> OnPostDelete([FromBody]int id)
        {
            
            try
            {
                await  _serialService.Delete(id);
            }catch(NullIdException ex){
                return NotFound(ex.Message);
            }
            catch (SerialNotFoundException ex)
            {
                return NotFound(ex.Message);
            }


            return RedirectToPage("./Index");
        }
        public async Task<IActionResult> OnPostToggleDelete( int id)
        {

            try
            {
                await _serialService.ToggleDelete(id);
            }
            catch (NullIdException ex)
            {
                return NotFound(ex.Message);
            }
            catch (SerialNotFoundException ex)
            {
                return NotFound(ex.Message);
            }


            return RedirectToAction("OnGet");
        }
    }
}
