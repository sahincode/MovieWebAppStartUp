using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Business.Exceptions.AboutModelExceptions
{
    public class AboutNotFoundException : Exception
    {
        public AboutNotFoundException() { }
        public AboutNotFoundException(string message) : base(message) { }

    }
}
