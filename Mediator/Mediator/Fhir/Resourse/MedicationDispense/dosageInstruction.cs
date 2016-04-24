using Fhir.DataElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fhir.Resourse.MedicationDispense
{
    class dosageInstruction
    {
        public string text;
        public Timing timing;
        public bool asNeededBoolean;
        public CodeableConcept asNeededCodeableConcept;
        public CodeableConcept route;
        public CodeableConcept method;

        public Range doseRange;
        public Quantity doseQuantity;

        public Ratio rateRatio;
        public Range rateRange;

        public Ratio maxDosePerPeriod;
    }
}
