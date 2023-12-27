﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Business.Exceptions.ReferenceExceptions
{
    public  class EntityNotFoundException :Exception
    {
        public EntityNotFoundException(){ }
        public EntityNotFoundException( string message) :base(message){ }
    }
}
