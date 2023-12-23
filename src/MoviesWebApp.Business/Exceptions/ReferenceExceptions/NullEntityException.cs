using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Business.Exceptions.ReferenceExceptions
{
    public  class NullEntityException : Exception
    {
        public string Property { get; set; }
        public NullEntityException()
        {

        }
        public NullEntityException(string property, string message) : base(message)
        {
            this.Property = property;
        }
    }
}
