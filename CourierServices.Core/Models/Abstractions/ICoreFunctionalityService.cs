using CourierServices.Core.DTOs;
using CourierServices.Core.Models.Entities;
using CourierServices.Core.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierServices.Core.Models.Abstractions
{
    public interface ICoreFunctionalityService
    {
        public Task<(Order? order, List<string> errors)> CreateOrder(OrdersDTO ordersDTO);
        public Task<List<string>> FillTodayTable(DateTime firstDelivery, string district);
        public Task<List<Order>> GetNearbyOrders();
        public Task<(Order? order, List<string> errors)> GetOrderById(Guid id);
        public Task<List<Order>> GetOrders();
        public List<LogsDTO> GetAllLogs();
    }
}
