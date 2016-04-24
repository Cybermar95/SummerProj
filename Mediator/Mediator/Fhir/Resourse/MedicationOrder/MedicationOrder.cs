using Fhir.DataElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fhir.Resourse.MedicationOrder
{
    class MedicationOrder
    {
        public string id;
        public string resourceType = "MedicationOrder";
        public Identifier[] identifier;
        public Reference medicationReference;
        public Reference patient;
        public Reference encounter;
        public string dateWritten;
        public string dateEnded;
        public dosageInstruction[] dosageInstruction;
    }
}
