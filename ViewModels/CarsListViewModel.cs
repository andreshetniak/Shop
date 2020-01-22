using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.ViewModels
{
    public class CarsListViewModel
    {
        public IEnumerable<Car> GetAllCars { get; set; }
        public string currentCategory { get; set; }
    }
}
