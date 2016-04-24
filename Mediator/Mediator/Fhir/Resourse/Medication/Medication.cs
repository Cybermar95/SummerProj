using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhir.DataElement;

namespace Fhir.Resourse.Medication
{
    class Medication
    {
        public string id;
        public string resourceType;
        public CodeableConcept code;
        public product product;
        public package package;
    }
}
