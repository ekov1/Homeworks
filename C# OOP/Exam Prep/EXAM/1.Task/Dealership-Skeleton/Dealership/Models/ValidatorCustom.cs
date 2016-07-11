namespace Dealership.Models
{
    using Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ValidatorCustom
    {
        public static void StringValidation(string value, int min, int max, string obj)
        {
            Validator.ValidateIntRange(value.Length, min,
                   max,
                   String.Format(Constants.StringMustBeBetweenMinAndMax, obj, min
                   , max));
        }

        public static void NumberValdation(int value, int min, int max, string obj)
        {
            Validator.ValidateDecimalRange(value, min,
                    max, String.Format(Constants.NumberMustBeBetweenMinAndMax,
                    obj, min
                    , max));
        }

        public static void DecimalNumberValidation(decimal value, decimal min, decimal max, string obj)
        {
            Validator.ValidateDecimalRange(value, min,
                    max, String.Format(Constants.NumberMustBeBetweenMinAndMax,
                    obj, min
                    , max));
        }
    }
}
