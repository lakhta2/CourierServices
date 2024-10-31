using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierServices.Core.Models.Abstractions
{
    public interface IValidator
    {
        public (List<string> errors, DateTime queryDateTime) ValidateDateTime(string date, string month, string year, string hour, string minute);
    }
}
