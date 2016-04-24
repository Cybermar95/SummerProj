using Fhir.DataElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fhir.Resourse.Organization
{
    class Organization
    {
        public string id;
        public string resourceType;
        public Identifier[] identifier;
        public bool active;
        public CodeableConcept type;
        public string name;
    }
}
