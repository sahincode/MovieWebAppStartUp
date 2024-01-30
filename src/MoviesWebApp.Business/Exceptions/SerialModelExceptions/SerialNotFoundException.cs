using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Business.Exceptions.SerialModelExceptions
{
    public class SerialNotFoundException :Exception
    {
        public string PropertyName;
        public SerialNotFoundException(){}
        public SerialNotFoundException(string message):base(message) { }
        public SerialNotFoundException(string propertyName ,string message):base(message) 
        {
            PropertyName = propertyName;
        }

    }
}
