using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhir.DataElement;


namespace Fhir.Resourse.Patient
{
    class Patient
    {
        public Patient()
        {
        }

       /* public Patient(Resourse.Patient Pat)
        {
            resourceType = "Patient";
            extension = new FhirPatientExtension[] { new FhirPatientExtension(Pat.polis, Pat.SocialStatus, Pat.Privileges) };
            name = new HumanName(Pat.family, Pat.name, Pat.suffix);
            switch (Pat.gender)
            {
                case 1:
                    gender = "male";
                    break;

                case 2:
                    gender = "female";
                    break;
            }
            this.birthDate = Pat.birthDate;
        }*/
        public string id;
        public string resourceType;
        public PatientExtension[] extension;
        public HumanName name;
        public string gender;
        public string birthDate;
    }
}
