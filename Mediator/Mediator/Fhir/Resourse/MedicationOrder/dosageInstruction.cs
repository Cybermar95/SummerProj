using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhir.DataElement;

namespace Fhir.Resourse.MedicationOrder
{
    class dosageInstruction
    {
        public string text;
        public Timing timing;
        public bool asNeededBoolean;
        public CodeableConcept route;
        public CodeableConcept method;
        public Range doseRange;
        public Quantity doseQuantity;
        public Ratio maxDosePerPeriod;
        public Ratio rateRatio;
        public Range rateRange;
        public Quantity rateQuantity;
    }
}
