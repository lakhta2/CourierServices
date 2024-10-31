using CourierServices.Core.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierServices.DataAccess.ValueObjects
{
    public class DistrictValueObject
    {
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string DistrictId { get; set; } 
    }
}
