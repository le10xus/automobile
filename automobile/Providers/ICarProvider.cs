using Automobile.Models;
using Automobile.Providers.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Automobile.Providers
{
    public interface ICarProvider
    {
        public Task<Pagination<Car>> GetCarsPage(IQueryable<Car> cars, int pageNumber);
        public void SendEmail(Car car, string destination, string source);
    }
}
