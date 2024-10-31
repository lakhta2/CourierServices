using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using CourierServices.Core.DTOs;
using System.Threading.Tasks;

namespace CourierServices.DataAccess.Entities
{
    public class Logs
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Time { get; set; } = DateTime.Now;
        public string Query { get; set; }

        public Logs (string query)
        {  Query = query; }

        public static explicit operator LogsDTO(Logs model)
        {
            return new LogsDTO
            {
                Id = model.Id,
                Time = model.Time,
                Query = model.Query
            };
        }
    }
}
