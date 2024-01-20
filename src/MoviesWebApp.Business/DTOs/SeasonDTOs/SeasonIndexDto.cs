using MoviesWebApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Business.DTOs.SeasonDTOs
{
    public class SeasonIndexDto
    {
        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public DateTime DeletedTime { get; set; }
        public bool IsDeleted { get; set; }
        public int SeasonNumber { get; set; }
        public string Country { get; set; }
        public Serial Serial { get; set; }
    }
}
