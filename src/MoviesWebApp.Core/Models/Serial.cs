using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Core.Models
{
    public class Serial: BaseEntity
    {
        public string Name {  get; set; }
        public string Description { get; set; }
        public float IMDB { get; set; }
        public List<Season> Seasons { get; set; }
    }
}
