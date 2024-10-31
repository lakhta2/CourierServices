using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CourierServices.Core.Models.Entities;
using System.Threading.Tasks;
using CourierServices.Core.DTOs;
using CourierServices.Core.Models.ValueObjects;

namespace CourierServices.Core.Models.Abstractions
{
    public interface ICourierServices
    {
        public Task<List<Order>> GetOrders();
        public Task<(Order? order, List<string> errors)> GetOrderById(Guid id);
        public Task<(Order? order, List<string> errors)> CreateOrder(OrdersDTO ordersDTO);
        public Task FillTodayTable(DateTime firstDelivery, District district);
        public Task<List<Order>> GetNearbyOrders();
        public List<LogsDTO> GetAllLogs();
    }
}
