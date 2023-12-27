using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Core.DTOs.GenreDTOs
{
    public class GenreIndexDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationTime { get;set; }
        public DateTime UpdateTime { get; set; }
        public bool IsDeleted { get;set; }

    }
}
