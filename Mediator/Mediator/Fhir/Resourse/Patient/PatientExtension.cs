using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhir.DataElement;


namespace Fhir.Resourse.Patient
{
    class PatientExtension
    {
        public PatientExtension()
        {
        }

        public PatientExtension(string Polis, int SocStatusCode, int PrivilCode)
        {
           /* Extension polis = new Extension("Polis", Polis);
            Extension SocialStatus = new Extension("SocialStatus", new Coding("NON", SocStatusCode.ToString()));
            Extension Privileges = new Extension("Privileges", new Coding("NON", PrivilCode.ToString()));
            extension = new Extension[] { polis, SocialStatus, Privileges };*/
        }
        public string url = "NON";
        public Extension[] extension;
    }
}
