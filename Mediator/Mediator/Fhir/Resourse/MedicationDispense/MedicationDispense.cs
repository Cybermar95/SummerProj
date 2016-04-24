using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhir.DataElement;
using Fhir.Resourse.MedicationDispense;

namespace Fhir.Resourse.MedicationDispense
{
    class MedicationDispense
    {
        public string id;
        public string resourceType;
        public Identifier[] identifier;
        public Coding status;
        public CodeableConcept medicationCodeableConcept;
        public Reference medicationReference;
        public Reference patient;
        public Reference dispenser;
        public Reference[] authorizingPrescription;
        public Quantity quantity;
        public Quantity daysSupply;
        public string whenPrepared; //dateTime needed
        public string whenHandedOver; //dateTime needed
        public Reference[] receiver;
        public dosageInstruction[] dosageInstructions;

    }
}
