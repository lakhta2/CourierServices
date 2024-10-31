using CourierServices.DataAccess.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierServices.DataAccess.Entities
{
    public class FinalOrders
    {
        [Key]
        public Guid Id { get; set; }
        public WeightValueObject Weight { get; set; }
        public DistrictValueObject District { get; set; }
        public DeliveryTimeValueObject DeliveryTime { get; set; }
        public FinalOrders() { }
        public FinalOrders(Guid id, WeightValueObject weight, DeliveryTimeValueObject deliveryTime, DistrictValueObject district)
        {
            Id = id;
            Weight = weight;
            DeliveryTime = deliveryTime;
            District = district;
        }
    }
}
