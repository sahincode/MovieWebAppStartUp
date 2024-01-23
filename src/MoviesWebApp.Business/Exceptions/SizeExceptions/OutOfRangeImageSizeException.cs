using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Business.Exceptions.SizeExceptions
{
    public class OutOfRangeImageSizeException : Exception
    {

        public string PropertyName;
        public OutOfRangeImageSizeException() { }
        public OutOfRangeImageSizeException(string message) : base(message) { }
        public OutOfRangeImageSizeException(string propertyName, string message) : base(message)
        {
            PropertyName = propertyName;
        }
    }
}
