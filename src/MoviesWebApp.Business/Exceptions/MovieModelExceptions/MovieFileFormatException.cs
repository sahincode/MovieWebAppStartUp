using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Business.Exceptions.MovieModelExceptions
{

    public class MovieFileFormatException : Exception
    {
        public string Property { get; set; }
        public MovieFileFormatException()
        {

        }
        public MovieFileFormatException(string property, string message) : base(message)
        {
            Property = property;
        }

    }
}
