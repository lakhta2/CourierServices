using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourierServices.Core.DTOs;
using CourierServices.Core.Models.Abstractions;
using CourierServices.Core.Models.Entities;
using CourierServices.Core.Models.ValueObjects;

namespace CourierServices.Application.Services
{
    public class CoreFunctionalityService : ICoreFunctionalityService
    {
        private readonly ICourierServices _courierServices;
        public CoreFunctionalityService(ICourierServices courierServices)
        {
            if (courierServices != null)
                _courierServices = courierServices;
        }

        public async Task<(Order? order, List<string> errors)> CreateOrder(OrdersDTO ordersDTO)
        {
            var result = await _courierServices.CreateOrder(ordersDTO);
            return result;
        }
        public async Task<List<string>> FillTodayTable(DateTime firstDelivery, string district)
        {
            var queryDistrictPair = District.CreateDistrict(district, "AB40");
            var errors = queryDistrictPair.errors;
            if (errors.Count == 0)
            {
                District queryDistrict = queryDistrictPair.district;
                await _courierServices.FillTodayTable(firstDelivery, queryDistrict);
                return errors;
            }
            else
            {
                return errors;
            }
        }
        public async Task<List<Order>> GetNearbyOrders()
        {
            var result = await _courierServices.GetNearbyOrders();
            return result;
        }
        public async Task<(Order? order, List<string> errors)> GetOrderById(Guid id)
        {
            var result = await _courierServices.GetOrderById(id);
            return result;
        }
        public async Task<List<Order>> GetOrders()
        {
            var result = await _courierServices.GetOrders();

            return result;
        }
        public List<LogsDTO> GetAllLogs()
        {
            var result = _courierServices.GetAllLogs();

            return result;
        }
    }
}
