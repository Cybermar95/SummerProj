using Fhir.DataElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fhir.Resourse.Practitioner
{
    class practitionerRole
    {
        public Reference organization;
        public CodeableConcept role;
        public CodeableConcept speciality;
        public Identifier[] identifier;
    }
}
