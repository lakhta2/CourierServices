using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierServices.Core.Models.ValueObjects
{
    public class District
    {
        public string Name { get; private set; } = string.Empty;
        public string NormalizedName { get; private set; } = string.Empty;
        public string DistrictId { get; private set; } = string.Empty;

        private District(string name, string normalizedName, string districtId)
        {
            Name = name;
            NormalizedName = normalizedName;
            DistrictId = districtId;
        }

        private static string Normilize(string name)
        {
            return name.ToUpperInvariant().Replace("-", ""); 
        }

        public static (District district, List<string> errors) CreateDistrict(string name, string districtId)
        {
            List<string> errors = new List<string>();

            if(CheckIsValid(name, districtId).errors.Count == 0)
            {
                District NewDistrict = new District(name, Normilize(name), districtId);
                return (NewDistrict, errors);
            }
            else
            {
                errors.AddRange(CheckIsValid(name, districtId).errors);
                District mockDistrict = new District("", "", "");
                return (mockDistrict, errors);
            }
        }
        public static (string[] strings, List<string> errors) CheckIsValid(string name, string districtId)
        {
            List<string> errors = new List<string>();

            if (string.IsNullOrEmpty(name))
                errors.Add("District name can't be empty or null");
            if (string.IsNullOrEmpty(districtId))
                errors.Add("DistrictId can't be empty or null");
            if (name.ToCharArray().Length < 3)
                errors.Add("District name too short");

            return ([name, districtId],  errors);
        }

    }
}
