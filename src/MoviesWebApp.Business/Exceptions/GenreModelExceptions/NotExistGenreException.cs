using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Business.Exceptions.GenreModelExceptions
{
    public class NotExistGenreException : Exception
    {
        public string Property { get; set; }
        public NotExistGenreException() { }
        public NotExistGenreException(string message) : base(message) { }

        public NotExistGenreException(string property, string message) : base(message)
        {
            this.Property = property;
        }
    }
}
