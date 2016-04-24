using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fhir.DataElement
{
    class Quantity
    {
        public float value;
        public Coding comparator;
        public string unit;
        public string system;
        public Coding code;
    }
}
