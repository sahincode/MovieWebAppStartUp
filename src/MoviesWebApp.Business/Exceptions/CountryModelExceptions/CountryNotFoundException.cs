using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Business.Exceptions.CountryModelExceptions
{
    public class CountryNotFoundException :Exception
    {
        public string PropertyName;
        public CountryNotFoundException() { }
        public CountryNotFoundException(string message) : base(message) { }
        public CountryNotFoundException(string propertyName, string message) : base(message)
        {
            PropertyName = propertyName;
        }
    }
}
