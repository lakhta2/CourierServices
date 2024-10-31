using System.ComponentModel.DataAnnotations;

namespace CourierServices.Contracts
{
    public record RequestFillTable(
        [Length(0,2)]
        string Date,
        [Length(0,2)]
        string Month,
        [Length(4,4)]
        string Year,
        [Length(0,2)]
        string Hour,
        [Length(2,2)]
        string Minute,
        string District
        );
}
