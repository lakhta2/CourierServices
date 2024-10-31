using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using CourierServices.Core.Models.Abstractions;

namespace CourierServices.Infrasrtucture
{
    public class Validator : IValidator
    {
        private StringBuilder _sb = new StringBuilder();
        public (List<string> errors, DateTime queryDateTime) ValidateDateTime(string date, string month, string year, string hour, string minute)
        {
            DateOnly date_var = DateOnly.MinValue;
            TimeOnly time_var = TimeOnly.MinValue;
            List<string> errors = new List<string>();
            _sb.Clear();

            if (ValidateStringsForNullOrEmpty(date, month, year))
            {
                if (date.Length < 2 || date.Length > 2)
                    errors.Add("Date can't have more or less then 2 symbols");
                if (month.Length < 2 || month.Length > 2)
                    errors.Add("Month can't have more or less then 2 symbols");
                if (year.Length < 4 || year.Length > 4)
                    errors.Add("Year can't have more or less then 4 symbols");
                if (!date.All(c => c >= '0' && c <= '9'))
                {
                    errors.Add("Date can only have digits characters");
                    return (errors, new DateTime(date_var, time_var));
                }
                if (!month.All(c => c >= '0' && c <= '9'))
                {
                    errors.Add("Month can only have digits characters");
                    return (errors, new DateTime(date_var, time_var));
                }
                if (!year.All(c => c >= '0' && c <= '9'))
                {
                    errors.Add("Year can only have digits characters");
                    return (errors, new DateTime(date_var, time_var));
                }
                if (int.Parse(month, CultureInfo.InvariantCulture) > 12 || int.Parse(month, CultureInfo.InvariantCulture) < 1)
                { 
                    errors.Add("Month can't be more than 12 and less than 1");
                    return (errors, new DateTime(date_var, time_var));
                }
                if (int.Parse(date, CultureInfo.InvariantCulture) > DateTime
                    .DaysInMonth(int.Parse(year, CultureInfo.InvariantCulture), int.Parse(month, CultureInfo.InvariantCulture)))
                    errors.Add("There is no such day in month");

                if (errors.Count == 0)
                {
                    _sb.Append(date);
                    _sb.Append("-");
                    _sb.Append(month);
                    _sb.Append("-");
                    _sb.Append(year);

                    DateOnly.TryParseExact(_sb.ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture,
                           DateTimeStyles.None, out date_var);
                }
            }
            else
            {
                errors.Add("Date, month, year is null or empty");
                date_var = DateOnly.MinValue;
            }

            _sb.Clear();

            if(ValidateStringsForNullOrEmpty(hour, minute))
            {
                if (hour.Length < 2 || hour.Length > 2)
                    errors.Add("Hour can't have more or less then 2 symbols");
                if (minute.Length < 2 || minute.Length > 2)
                    errors.Add("Minute can't have more or less then 2 symbols");
                if (!hour.All(c => c >= '0' && c <= '9'))
                {
                    errors.Add("Hour can only have digits characters");
                    return (errors, new DateTime(date_var, time_var));
                }
                if (!minute.All(c => c >= '0' && c <= '9'))
                {
                    errors.Add("Minutes can only have digits characters");
                    return (errors, new DateTime(date_var, time_var));
                }
                if (int.Parse(hour, CultureInfo.InvariantCulture) > 23 || int.Parse(hour, CultureInfo.InvariantCulture) < 0)
                    errors.Add("Hour can't be more than 23 and less than 0");
                if (int.Parse(minute, CultureInfo.InvariantCulture) > 59 || int.Parse(minute, CultureInfo.InvariantCulture) < 0)
                    errors.Add("Minute can't be more than 59 and less than 0");

                if (errors.Count == 0)
                {
                    _sb.Append(hour);
                    _sb.Append("-");
                    _sb.Append(minute);

                    TimeOnly.TryParseExact(_sb.ToString(), "HH-mm", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out time_var);
                }
            }
            else
            {
                errors.Add("Hour or minute is null or empty");
                time_var = TimeOnly.MinValue;
            }

            if(errors.Count == 0)
            {
                return (errors, new DateTime(date_var, time_var));
            }
            else
            {
                return (errors, new DateTime(date_var, time_var));
            }
        }
        private static bool ValidateStringsForNullOrEmpty(params string[] strings)
        {
            foreach (string elem in strings)
            {
                if(string.IsNullOrEmpty(elem))
                    return false;
            }
            return true;
        }
    }
}
