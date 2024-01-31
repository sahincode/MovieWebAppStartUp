using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Business.Exceptions.IdentityExceptions
{
    public  class InavalidLoginAttemptException :Exception
    {
        public string Property { get; set; }
        public InavalidLoginAttemptException(){}
        public InavalidLoginAttemptException( string message) :base(message){}
        public InavalidLoginAttemptException(string property ,string message) : base(message)
        {
            Property=property;
        }

    }
}
