using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Business.Exceptions.FormatExceptions
{
    public class ImageContentTypeException : Exception
    {
        public string PropertyName { get; set; }
        public ImageContentTypeException() { }
        public ImageContentTypeException(string message) : base(message) { }
        public ImageContentTypeException(string propertyName, string message) : base(message)
        {
            PropertyName = propertyName;
        }

    }
}
