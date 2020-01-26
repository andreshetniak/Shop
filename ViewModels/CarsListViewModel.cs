using Shop.Data.Models;
using System.Collections.Generic;

namespace Shop.ViewModels
{
    public class CarsListViewModel
    {
        public IEnumerable<Car> GetAllCars { get; set; }
        public string currentCategory { get; set; }
    }
}
