using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Business.DTOs.PrivacyDTOs
{


    public class PrivacyIndexDto
    {
        public int Id { get; set; }
        public string Info { get; set; }
        public DateTime CreationTime { get;set; }
        public DateTime UpdateTime { get; set; }
        public bool IsDeleted { get;set; }

    }
}
