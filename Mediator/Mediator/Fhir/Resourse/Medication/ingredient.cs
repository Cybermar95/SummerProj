﻿using Fhir.DataElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fhir.Resourse.Medication
{
    class ingredient
    {
        public CodeableConcept itemCodeableConcept;
        public Reference itemReference;
        public Ratio amount;
    }
}
