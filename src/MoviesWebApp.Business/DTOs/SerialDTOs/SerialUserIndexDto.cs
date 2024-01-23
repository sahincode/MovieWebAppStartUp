using MoviesWebApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Business.DTOs.SerialDTOs
{
    public class SerialUserIndexDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float IMDB { get; set; }
        public List<Season> Seasons { get; set; }


    }
}
