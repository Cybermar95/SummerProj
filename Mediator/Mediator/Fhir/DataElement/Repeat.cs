using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fhir.DataElement
{
    class Repeat
    {
        public int count;
        public int frequency;
        public int period;
        public Coding when;
    }
}