using Fhir.DataElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhir.Resourse.Encounter;

namespace Fhir.Resourse.Encounter
{
    class Encounter
    {
        public string id;
        public string resourceType;
        public Identifier[] identifier;
        public Coding status;
        public Coding @class;
        public Coding[] type;

        public Reference patient;

        public participant[] participant;
    }
}
