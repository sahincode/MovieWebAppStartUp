using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Core.DTOs.GenreDTOs
{
    public class GenreUpdateDto
    {
        [StringLength(12000)]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
