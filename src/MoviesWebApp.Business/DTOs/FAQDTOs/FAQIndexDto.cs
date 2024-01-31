using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Business.DTOs.FAQDTOs
{
    public class FAQIndexDto
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public DateTime DeletedTime { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
