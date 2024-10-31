using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierServices.Core.DTOs
{
    public class OrdersDTO
    {
        public Guid Id { get; set; }
        public double Weight { get; set; }
        public string DistrictName { get; set; }
        public string DistrictID { get; set; }
        public int Date { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
        public OrdersDTO(Guid id, double weight, string districtName, string districtId, int date,
            int month, int year, int hour, int minute) 
        { 
            Id = id;
            Weight = weight;
            DistrictName = districtName;
            DistrictID = districtId;
            Date = date;
            Month = month;
            Year = year;
            Hour = hour;
            Minute = minute;
        }
    }
}
