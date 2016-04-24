using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fhir.DataElement
{
    class Timing
    {
        public string[] @event; //dateTime needed
        public Repeat repeat;
        public Coding code;
    }

}