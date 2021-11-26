using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Automobile.Models
{
    public enum Colors
    {
        White,
        Black,
        Red,
        Blue
    }

    public enum CarType
    {
        Sedan,
        Jeep,
        Bus
    }

    public class Car
    {

        public int Id { get; set; }
        public string Model { get; set; }
        public Colors Color { get; set; }
        public CarType Type { get; set; }
        public float Weight { get; set; }
    }
}
