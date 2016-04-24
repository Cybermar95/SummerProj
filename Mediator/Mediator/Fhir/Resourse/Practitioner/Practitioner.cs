using Fhir.DataElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhir.Resourse.Practitioner;

namespace Fhir.Resourse.Practitioner
{
    class Practitioner
    {
        public string id;
        public string resourceType;
        public Identifier[] identifier;
        public bool active;
        public HumanName name;
        public Coding gender;
        public string birthDate; //dateTime needed
        public practitionerRole[] practitionerRole;
    }
}
