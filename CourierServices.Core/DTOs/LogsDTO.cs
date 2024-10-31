using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierServices.Core.DTOs
{
    public class LogsDTO
    {
        public Guid Id { get; set; }
        public DateTime Time { get; set; } 
        public string Query { get; set; }
        public LogsDTO(Guid id, DateTime time, string query)
        {
            Id = id;
            Time = time;
            Query = query;
        }
        public LogsDTO() { }
    }
}
