namespace CourierServices.Contracts
{
    public record CreateOrderRequest(
     Guid Id,
     double Weight,
     string DistrictName,
     string DistrictID,
     int Date,
     int Month,
     int Year,
     int Hour,
     int Minute);
}
