using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Core.Models
{
    public class Setting :BaseEntity
    {
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string FaceUrl { get; set; }
        public string XUrl { get; set; }
        public string WhatUrl { get; set; }
        public string InstaUrl { get; set; }


    }
}
