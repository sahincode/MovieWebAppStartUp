using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Business.Exceptions.SeasonModelExceptions
{
    public class SeasonNotFoundException :Exception
    {
        public string PropertyName;
        public SeasonNotFoundException() { }
        public SeasonNotFoundException(string message) : base(message) { }
        public SeasonNotFoundException(string propertyName, string message) : base(message)
        {
            PropertyName = propertyName;
        }
    }
}
