using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Interfaces
{
    public interface IAllCars
    {
        public IEnumerable<Car> Cars { get; }
        public IEnumerable<Car> GetFavCars { get; set; }
        public Car GetObjectCar(int carID);
    }
}
