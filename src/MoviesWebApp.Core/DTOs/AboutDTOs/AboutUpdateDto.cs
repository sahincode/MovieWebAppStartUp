using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Core.DTOs.AboutDTOs
{
    public class AboutUpdateDto
    {
        [StringLength(12000)]
        public string InfoAboutApp { get; set; }
        public bool IsDeleted { get; set; }
    }
}
