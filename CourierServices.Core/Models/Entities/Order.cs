using CourierServices.Core.Models.ValueObjects;
using CourierServices.Core.Models.Values;
using CourierServices.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace CourierServices.Core.Models.Entities
{
    public class Order
    {
        public Guid Id { get; }
        public Weight Weight { get; set; }
        public District District { get; set; }
        public DeliveryTime DeliveryTime { get; set; }
        private Order(Guid id, Weight weight, District district, DeliveryTime deliveryTime) 
        {
            Id = id;
            Weight = weight;
            District = district;
            DeliveryTime = deliveryTime;
        }
        public static (Order? order, List<string> errors) Create(OrdersDTO ordersDTO)
        {
            List<string> finalErrors = new List<string>();
            if (ordersDTO == null)
                finalErrors.Append("Request Can't be null");
            var id = Guid.NewGuid();
            var weight = Weight.CreateWeight(ordersDTO.Weight);
            finalErrors.AddRange(weight.errors);
            var district = District.CreateDistrict(ordersDTO.DistrictName, ordersDTO.DistrictID);
            finalErrors.AddRange(district.errors);
            var deliveryTime = DeliveryTime.CreateDelivery(ordersDTO.Date, ordersDTO.Month, ordersDTO.Year, ordersDTO.Hour, ordersDTO.Minute);
            finalErrors.AddRange(deliveryTime.errors);

            if(finalErrors.Count == 0)
            {
                Order result = new Order(id, weight.weight, district.district, deliveryTime.deliveryDate);
                return (result, finalErrors);
            }
            else
            {
                return (null, finalErrors);
            }
        }
        public static (Order? order, List<string> errors) Create(Guid id, OrdersDTO ordersDTO)
        {
            List<string> finalErrors = new List<string>();
            var weight = Weight.CreateWeight(ordersDTO.Weight);
            finalErrors.AddRange(weight.errors);
            var district = District.CreateDistrict(ordersDTO.DistrictName, ordersDTO.DistrictID);
            finalErrors.AddRange(district.errors);
            var deliveryTime = DeliveryTime.CreateDelivery(ordersDTO.Date, ordersDTO.Month, ordersDTO.Year, ordersDTO.Hour, ordersDTO.Minute);
            finalErrors.AddRange(deliveryTime.errors);

            if (finalErrors.Count == 0)
            {
                Order result = new Order(id, weight.weight, district.district, deliveryTime.deliveryDate);
                return (result, finalErrors);
            }
            else
            {
                return (null, finalErrors);
            }
        }
        public static (Order? order, List<string> errors) CreateMockOrder()
        {
            Order result = new Order();

            List<string> errors = new List<string>();

            return (result, errors);
        }
        private Order() { }
    }
}
