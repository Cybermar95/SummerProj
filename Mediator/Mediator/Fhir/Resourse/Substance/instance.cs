using Fhir.DataElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fhir.Resourse.Substance
{
    class instance
    {
        public Identifier identifier;
        public string expiry; //dateTime needed
        public Quantity quantity;
    }
}
