using Automobile.Messenger;
using Automobile.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automobile.Providers.Implementation
{
    public class CarProvider: ICarProvider
    {
        public async Task<Pagination<Car>> GetCarsPage(IQueryable<Car> cars, int pageNumber)
        {
           int pageSize = Constants.pageSize;
           return await Pagination<Car>.CreateAsync(cars.AsNoTracking(), pageNumber, pageSize);
        }

        /// <summary>
        /// отправить email
        /// </summary>
        public void SendEmail(Car car, string destination, string source)
        {
            var mail = new EmailMessenger("login", "pass");
            var messageText = CarInfo(car);
            var message = mail.CreateMessage(messageText, destination, source);
            message.SendMessage();
        }

        private string CarInfo(Car car)
        {
            var info = new StringBuilder();
            info.AppendFormat("Model: {0}, Color: {1}, Weight: {2}", car.Model, car.Color, car.Weight);
            return info.ToString();
        }
    }
}
