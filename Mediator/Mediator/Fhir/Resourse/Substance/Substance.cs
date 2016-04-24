using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhir.DataElement;
using Fhir.Resourse.Substance;

namespace Fhir.Resourse.Substance
{
    class Substance
    {
        public string id;
        public string resourceType;
        public Identifier[] identifier;
        public CodeableConcept[] category;
        public CodeableConcept code;
        public string description;
        public instance[] instance;
        public ingredient[] ingredient;
    }
}
