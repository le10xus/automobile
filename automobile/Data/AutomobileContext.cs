using Automobile.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Automobile.Data
{
    public class AutomobileContext : DbContext
    {
        public AutomobileContext(DbContextOptions<AutomobileContext> options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
    }
}
