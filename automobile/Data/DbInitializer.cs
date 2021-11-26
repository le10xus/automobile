using Automobile.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Automobile.Data
{
    public class DbInitializer
    {
        public static void Initialize(AutomobileContext context)
        {
            context.Database.EnsureCreated();

            if (context.Cars.Any())
            {
                return;
            }

            var cars = new Car[]
            {
                new Car{ Id = 1, Color= Colors.Black, Model = "S300", Type = CarType.Sedan, Weight = 2000 },
                new Car{ Id = 2, Color= Colors.White, Model = "B250", Type = CarType.Bus, Weight = 5000 },
                new Car{ Id = 3, Color= Colors.Black, Model = "S300", Type = CarType.Sedan, Weight = 2000 },
                new Car{ Id = 4, Color= Colors.White, Model = "B450", Type = CarType.Bus, Weight = 8000 },
                new Car{ Id = 5, Color= Colors.Black, Model = "J300", Type = CarType.Jeep, Weight = 2500 },
                new Car{ Id = 6, Color= Colors.Blue, Model = "J350", Type = CarType.Jeep, Weight = 3000 },
                new Car{ Id = 7, Color= Colors.Red, Model = "S200", Type = CarType.Sedan, Weight = 1200 }
            };
            foreach (var car in cars)
            {
                context.Cars.Add(car);
            }
            context.SaveChanges();
        }
    }
}
