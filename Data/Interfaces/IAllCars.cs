using Shop.Data.Models;
using System.Collections.Generic;

namespace Shop.Data.Interfaces
{
    public interface IAllCars
    {
        public IEnumerable<Car> Cars { get; }
        public IEnumerable<Car> GetFavCars { get; }
        public Car GetObjectCar(int carID);
    }
}
