using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Business.Exceptions.EpisodeModelException
{
    public class EpisodeFileFormatException :Exception
    {
        public string Property { get; set; }
        public EpisodeFileFormatException(){}
        public EpisodeFileFormatException( string message):base(message) { }

        public EpisodeFileFormatException(string property, string message) : base(message)
        {
            this.Property = property;
        }
    }
}
