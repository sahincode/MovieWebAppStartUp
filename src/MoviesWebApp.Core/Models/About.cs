using System.ComponentModel.DataAnnotations;

namespace MoviesWebApp.Core.Models
{
    public class About :BaseEntity
    {
       
        [StringLength(12000)]
        public string InfoAboutApp { get; set; }

    }
}
