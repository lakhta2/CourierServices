using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CourierServices.Core.Models.ValueObjects
{
    public class DeliveryTime
    {
        public DateTime DeliveryTimeValue { get; private set; }
        private DeliveryTime(DateTime deliveryTime)
        {
            DeliveryTimeValue = deliveryTime;
        }
        private static (DateOnly date, List<string> errors) CheckIsValidDate(int date, int month, int year)
        {
            List<string> errors = new List<string>();

            if (year < DateTime.Now.Year)
                errors.Add("Delivery date year can't be less then Current");
            if (DateTime.Now.Year - year > 3)
                errors.Add("Delivery Date year can't be more then three years since today");
            
            
            if (month > 12 && month < 1)
                errors.Add("Month can't be more then 12 and less then 1");

            if (DateTime.DaysInMonth(year, month) < date)
                errors.Add("There is no such date in month");


            DateOnly finalDate = new DateOnly(year, month, date);
            return (finalDate, errors);
        }
        private static (TimeOnly time, List<string> errors) CheckIsValidTime(int hour, int minute)
        {
            List<string> errors = new List<string>();

            if(hour < 0 && hour > 23)
                errors.Add("Hour can't be less then 0 and more then 23");
            if(minute < 0 && minute > 59)
                errors.Add("Minute can't be less then 0 and more then 59");

            TimeOnly finalDate = new TimeOnly(hour, minute);
            return (finalDate, errors);
        }
        public static (DeliveryTime deliveryDate, List<string> errors) CreateDelivery(int date, int month, int year, int hour, int minute)
        {
            List<string> errors = new List<string>();

            var validatedDate = CheckIsValidDate(date, month, year);
            var validatedTime = CheckIsValidTime(hour, minute);

            errors.AddRange(validatedDate.errors);
            errors.AddRange(validatedTime.errors);

            if(errors.Count == 0)
            {
                DateTime finalDate = new DateTime(validatedDate.date, validatedTime.time);
                DeliveryTime deliveryTime = new DeliveryTime(finalDate);
                return (deliveryTime, errors);
            }
            else
            {
                DateTime finalDate = new DateTime();
                DeliveryTime mockTime = new DeliveryTime(finalDate);
                return (mockTime, errors);
            }
        }
    }
}
