using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Business.Exceptions
{
    public  class NullIdException : Exception
    {
        public NullIdException(){ }
        public NullIdException(string message):base(message){}

    }
}
