using Microsoft.AspNetCore.Http;
using MoviesWebApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Business.DTOs.SerialDTOs
{
    public class SerialIndexDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float IMDB { get; set; }
        public List<Season> Seasons { get; set; }

        public DateTime CreationTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IsDeleted { get; set; }


    }
}
