using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Core.Models
{
    public  class NewsSlide:BaseEntity
    {
        public string Title { get; set; }
        public string SubDescription { get; set; }
        public string Description { get; set; }

    }
}
