using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Core.DTOs.AboutDTOs
{
    public class AboutIndexDto
    {
        public int Id { get; set; }
        public string InfoAboutApp { get; set; }
        public DateTime CreationTime { get;set; }
        public DateTime UpdateTime { get; set; }
        public bool IsDeleted { get;set; }

    }
}
