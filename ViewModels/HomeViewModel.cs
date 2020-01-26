using Shop.Data.Models;
using System.Collections.Generic;

namespace Shop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Car> FavoriteCars { get; set; }
    }
}
