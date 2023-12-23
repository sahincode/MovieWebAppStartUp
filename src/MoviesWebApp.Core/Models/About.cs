using System.ComponentModel.DataAnnotations;

namespace MoviesWebApp.Core.Models
{
    public class About :BaseEntity
    {
        public string? Title { get; set; }
        [StringLength(12000)]
        public string? infoAboutApp { get; set; }

    }
}
