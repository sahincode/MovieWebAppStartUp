using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Business.Exceptions.IdentityExceptions
{
    public class InvalidRegisterAttemptException:Exception
    {
        public string Property { get; set; }
        public InvalidRegisterAttemptException() { }
        public InvalidRegisterAttemptException(string message) : base(message) { }
        public InvalidRegisterAttemptException(string property, string message) : base(message)
        {
            Property = property;
        }
    }
}
