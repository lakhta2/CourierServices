using CourierServices.Contracts;
using CourierServices.Core.DTOs;
using CourierServices.Core.Models.Abstractions;
using CourierServices.Core.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text;

namespace CourierServices.Controllers
{
    public class CoreFunctionalityController : ControllerBase
    {
        private readonly ICoreFunctionalityService _coreFunctionalityService;
        private readonly IValidator _validator;
        public CoreFunctionalityController(ICoreFunctionalityService coreFunctionalityService, IValidator validator)
        {
            _coreFunctionalityService = coreFunctionalityService;
            _validator = validator;
        }
        [HttpPost("orders")]
        public async Task<ActionResult<(Order? order, List<string> errors)>> CreateOrder([FromBody] CreateOrderRequest request)
        {
            var result = await _coreFunctionalityService.CreateOrder(new OrdersDTO(request.Id, request.Weight, request.DistrictName, request.DistrictID, request.Date,
                request.Month, request.Year, request.Hour, request.Minute));

            if (result.errors.Count == 0)
            {
                return Ok(result.order);
            }
            else
            {
                return BadRequest(result.errors);
            }
        }
        [HttpPost("orders/coming")]
        public async Task<List<string>> FillTodayTable([FromBody] RequestFillTable req)
        {
            var result = _validator.ValidateDateTime(req.Date, req.Month, req.Year, req.Hour, req.Minute);
            if(result.errors.Count > 0)
                return result.errors;
            return await _coreFunctionalityService.FillTodayTable(result.queryDateTime, req.District);
        }
        [HttpGet("orders/coming")]
        public async Task<List<Order>> GetNearbyOrders()
        {
            var result = await _coreFunctionalityService
                .GetNearbyOrders();

            return result;
        }
        [HttpGet("orders/{id:guid}")]
        public async Task<ActionResult<(Order? order, List<string> errors)>> GetOrderById(Guid id)
        {
            var result = await _coreFunctionalityService
                .GetOrderById(id);

            if (result.errors.Count == 0)
            {
                return Ok(result.order);
            }
            else
            {
                return BadRequest(result.errors);
            }
        }
        [HttpGet("orders")]
        public async Task<List<Order>> GetOrders()
        {
            var result = await _coreFunctionalityService.GetOrders();
            
            return result;
        }
        
        [HttpGet("logs")]
        public List<LogsDTO> GetAllLogs()
        {
            var result = _coreFunctionalityService
                .GetAllLogs();

            return result;
        }
        
    }
}
