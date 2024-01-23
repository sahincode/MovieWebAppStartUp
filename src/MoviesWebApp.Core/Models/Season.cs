using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Core.Models
{
    public class Season : BaseEntity
    {
        public string Name { get; set; }
        public int SerialId { get; set; }
        public Serial Serial { get; set; }
        public string Country { get; set; }
        public List<Episode> Episodes { get; set; }
        public string ImageUrl { get; set; }

    }
}
