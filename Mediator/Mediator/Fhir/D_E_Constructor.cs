using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fhir.DataElement
{
    class D_E_Constructor
    {
        public void GetCodeableConcept(string SystemUri, string code, string text)
        {
            CodeableConcept codeableConcept = new CodeableConcept();
            codeableConcept.coding = new Coding[] { GetCoding(SystemUri, code) };
            codeableConcept.text = text;
        }

        public Coding GetCoding(string SystemUri, string code)
        {
            Coding coding = new Coding();
            coding.SystemUri = SystemUri;
            coding.code = code;
            return coding;
        }

        public Extension GetExtension(string url, string valueString)
        {
            Extension extension = new Extension();
            extension.url = url;
            extension.valueString = valueString;
            return extension;
        }

        public Extension GetExtension(string url, Coding valueCoding)
        {
            Extension extension = new Extension();
            extension.url = url;
            extension.valueCoding = valueCoding;
            return extension;
        }

        public HumanName GetHumanName(string family, string given, string suffix)
        {
            HumanName humanName = new HumanName();
            humanName.family = new string[] { family };
            humanName.given = new string[] { given };
            humanName.suffix = new string[] { suffix };
            return humanName;
        }

        public Identifier GetIdentifier(string system, string value)
        {
            Identifier identifier = new Identifier();
            identifier.use = GetCoding("http://hl7.org/fhir/ValueSet/identifier-use", "Official");
            identifier.system = system;
            identifier.value = value;
            return identifier;
        }

        public Period GetPeriod(string start, string end)
        {
            Period period = new Period();
            period.start = start;
            period.end = end;
            return period;
        }

        public Quantity GetQuantity(float value, string unit, string system, Coding code)
        {
            Quantity quantity = new Quantity();
            quantity.value = value;
            quantity.unit = unit;
            quantity.system = system;
            quantity.code = code;
            return quantity;
        }

        public Quantity GetQuantity(float value, Coding comparator, string unit, string system, Coding code)
        {
            Quantity quantity = new Quantity();
            quantity.value = value;
            quantity.comparator = comparator;
            quantity.unit = unit;
            quantity.system = system;
            quantity.code = code;
            return quantity;
        }

        public Range GetRange(Quantity low, Quantity high)
        {
            Range range = new Range();
            range.low = low;
            range.high = high;
            return range;
        }

        public Ratio GetRatio(Quantity numerator, Quantity denominator)
        {
            Ratio ratio = new Ratio();
            ratio.numerator = numerator;
            ratio.denominator = denominator;
            return ratio;
        }

        public Reference GetReference(string reference, string display)
        {
            Reference _reference = new Reference();
            _reference.reference = reference;
            _reference.display = display;
            return _reference;
        }

        public Repeat GetRepeat(int count, int frequency, int period, string when_value)
        {
            Repeat repeat = new Repeat();
            repeat.count = count;
            repeat.frequency = frequency;
            repeat.period = period;
            repeat.when = GetCoding("http://hl7.org/fhir/ValueSet/event-timing", when_value);
            return repeat;
        }

        public Timing GetTiming(string[] @event , Repeat repeat, string code_value)
        {
            Timing timing = new Timing();
            timing.@event = @event;
            timing.repeat = repeat;
            timing.code = GetCoding("http://hl7.org/fhir/ValueSet/timing-abbreviation",code_value);
            return timing;
        }

        public string GetDateTime(int Year, int Month, int Day)
        {
            char D = '-';
            return string.Concat(Year.ToString(), D, Month.ToString(), D, Day.ToString());
        }
    }
}
