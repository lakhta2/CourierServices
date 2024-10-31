using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CourierServices.Core.Models.Values
{
    public class Weight
    {
        private const double MAX_WEIGHT = 100.0;
        public double WeightValue { get; private set; }
        public double GetWeight() {  return WeightValue; }
        private Weight(double value)
        {
             WeightValue = value;
        }
        private static List<string> CheckIsValid(double value)
        {
            List<string> errors = new List<string>();


            if (value <= 0.0)
                errors.Add("Weight value can't be less then 0 or equal to 0");
            if (value > MAX_WEIGHT)
                errors.Add("Weight value can't be more then MaxWeight");

            return errors;
        }
        public static (Weight weight, List<string> errors) CreateWeight(double value)
        {
            var errors = CheckIsValid(value);
            if (errors.Count == 0) 
            {
                var weight = new Weight(value);
                return (weight, errors);
            }
            else
            {
                var mockWeight = new Weight(0.0);
                return (mockWeight, errors);
            }
        }
    }
}
