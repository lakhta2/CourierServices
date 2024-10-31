using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using CourierServices.Core.Models.ValueObjects;
using CourierServices.Core.Models.Values;
using System.ComponentModel.DataAnnotations;
using CourierServices.DataAccess.ValueObjects;

namespace CourierServices.DataAccess.Entities
{
    [Table("Orders")]
    public class OrderEntities
    {
        [Key]
        public Guid Id { get; set; }
        public WeightValueObject Weight { get; set; }
        public DistrictValueObject District { get; set; }
        public DeliveryTimeValueObject DeliveryTime { get; set; }

        public OrderEntities() { }
        public OrderEntities(Guid id, WeightValueObject weight, DeliveryTimeValueObject deliveryTime, DistrictValueObject district)
        {
            Id = id;
            Weight = weight;
            DeliveryTime = deliveryTime;
            District = district;
        }
    }
}
