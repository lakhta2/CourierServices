using CourierServices.Core.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourierServices.DataAccess.Entities;
using CourierServices.Core.Models.Entities;
using CourierServices.Core.DTOs;
using Microsoft.EntityFrameworkCore;
using CourierServices.Core.Models.Values;
using CourierServices.DataAccess.ValueObjects;
using CourierServices.Core.Models.ValueObjects;

namespace CourierServices.DataAccess.Repositories
{
    public class CourierServicesRepository : ICourierServices
    {
        private CourierServicesDbContext _context;
        public CourierServicesRepository(CourierServicesDbContext context)
        {
            _context = context;
        }

        public async Task<(Order? order, List<string> errors)> CreateOrder(OrdersDTO ordersDTO)
        {
            var orderToSave = Order.Create(ordersDTO);

            if (orderToSave.errors.Count == 0)
            {
                var orderEntityToSave = new OrderEntities();
                orderEntityToSave.Id = orderToSave.order.Id;

                WeightValueObject weightValueObject = new WeightValueObject();
                weightValueObject.WeightValue = orderToSave.order.Weight.WeightValue;
                orderEntityToSave.Weight = weightValueObject;

                DistrictValueObject districtValueObject = new DistrictValueObject();
                districtValueObject.DistrictId = orderToSave.order.District.DistrictId;
                districtValueObject.Name = orderToSave.order.District.Name;
                districtValueObject.NormalizedName = orderToSave.order.District.NormalizedName;
                orderEntityToSave.District = districtValueObject;

                DeliveryTimeValueObject delivTimeValueObject = new DeliveryTimeValueObject();
                delivTimeValueObject.DeliveryTimeValue = orderToSave.order.DeliveryTime.DeliveryTimeValue;
                orderEntityToSave.DeliveryTime = delivTimeValueObject;

                await _context.Orders.AddAsync(orderEntityToSave);

                _context.Logs.Add(new Logs($"CreateOrder: id:{ordersDTO.Id.ToString()}, weight:{ordersDTO.Weight}, hour:{ordersDTO.Hour}, minute:{ordersDTO.Minute}"));

            }
            else
            {
                foreach (var error in orderToSave.errors)
                {
                    _context.Logs.Add(new Logs($"CreateOrderFailed: id:{ordersDTO.Id.ToString()}, weight:{ordersDTO.Weight}, hour:{ordersDTO.Hour}, minute:{ordersDTO.Minute} with " +
                        $"Reason {error}"));
                }
            }

            await _context.SaveChangesAsync();

            return orderToSave;
        }

        public async Task FillTodayTable(DateTime firstDelivery, District district)
        {
            _context.FinalOrders.ExecuteDelete();

            var result = _context.Orders
                .AsNoTracking()
                .Where(o => o.DeliveryTime.DeliveryTimeValue.Date == firstDelivery.Date)
                .Where(o => o.District.NormalizedName == district.NormalizedName)
                .Where(o => o.DeliveryTime.DeliveryTimeValue >= firstDelivery && o.DeliveryTime.DeliveryTimeValue <= firstDelivery.AddMinutes(30))
                .ToList();

            var finalResult = result
                .Select(o => new FinalOrders(o.Id, o.Weight, o.DeliveryTime, o.District)).ToList();

            _context.Logs.Add(new Logs($"FillTodayTable, firstDeliver:{firstDelivery.ToString()}, district:{district}"));

            _context.FinalOrders.AddRange(finalResult);
            _context.SaveChanges();
            return;
        }

        public async Task<List<Order>> GetNearbyOrders()
        {
            var result = await _context.FinalOrders
                .AsNoTracking()
                .ToListAsync();

            var finalResult = result
                .Select(o => new OrdersDTO(o.Id, o.Weight.WeightValue, o.District.Name, o.District.DistrictId, o.DeliveryTime.DeliveryTimeValue.Day, o.DeliveryTime.DeliveryTimeValue.Month,
                o.DeliveryTime.DeliveryTimeValue.Year, o.DeliveryTime.DeliveryTimeValue.Hour, o.DeliveryTime.DeliveryTimeValue.Minute));

            var veryFinalResult = finalResult
                .Select(o => Order.Create(o).order)
                .ToList();

            _context.Logs.Add(new Logs($"Get Nearby Orders"));
            _context.SaveChanges();

            return veryFinalResult;
        }

        public async Task<(Order? order, List<string> errors)> GetOrderById(Guid id)
        {
            var result_order = await _context.Orders
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.Id == id);


            if (result_order != null)
            {

                var DTO = new OrdersDTO(result_order.Id, result_order.Weight.WeightValue, result_order.District.Name,
                    result_order.District.DistrictId, result_order.DeliveryTime.DeliveryTimeValue.Day,
                    result_order.DeliveryTime.DeliveryTimeValue.Month, result_order.DeliveryTime.DeliveryTimeValue.Year,
                    result_order.DeliveryTime.DeliveryTimeValue.Hour, result_order.DeliveryTime.DeliveryTimeValue.Minute);

                var final_result = Order.Create(id, DTO);

                _context.Logs.Add(new Logs($"Get Orders By Id + {id}"));
                await _context.SaveChangesAsync();

                return final_result;
            }
            else
            {
                var mock_order = Order.CreateMockOrder();
                mock_order.errors.Add("There is no order with that id");
                _context.Logs.Add(new Logs($"Get Orders By Id + {id}"));
                return mock_order;
            }
        }

        public async Task<List<Order>> GetOrders()
        {
            var resultToMap = await _context.Orders
                .AsNoTracking()
                .ToArrayAsync();

            var finalResult = resultToMap
                .Select(o => new OrdersDTO(o.Id, o.Weight.WeightValue, o.District.Name, o.District.DistrictId, o.DeliveryTime.DeliveryTimeValue.Day, o.DeliveryTime.DeliveryTimeValue.Month,
                o.DeliveryTime.DeliveryTimeValue.Year, o.DeliveryTime.DeliveryTimeValue.Hour, o.DeliveryTime.DeliveryTimeValue.Minute));

            var veryFinalResult = finalResult
                .Select(o => Order.Create(o.Id, o).order)
                .ToList();

            _context.Logs.Add(new Logs("Get Orders"));
            _context.SaveChangesAsync();

            return veryFinalResult;
        }
        public List<LogsDTO> GetAllLogs()
        {
            var result = _context.Logs
                .AsNoTracking()
                .ToListAsync();

            var finalResult = result.Result
                .Select(o => (LogsDTO)o)
                .ToList();

            return finalResult;
        }
    }
}
