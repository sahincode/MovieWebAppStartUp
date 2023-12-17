using System.ComponentModel.DataAnnotations;

namespace MoviesWebApp.Core.Models
{
    public class LogoPageInfo
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        [StringLength(12000)]
        public string? infoAboutApp { get; set; }

    }
}
