﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Business.Exceptions.ReferenceExceptions
{
    public  class EntityNotFoundException :Exception
    {
        public string PropertyName { get; set; }
        public EntityNotFoundException(){ }
        public EntityNotFoundException( string message) :base(message){ }
        public EntityNotFoundException( string propertyName,string message) : base(message) 
        {
            PropertyName = propertyName;
        }

    }
}
