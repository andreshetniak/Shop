using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Mocks
{
    public class MockCars : IAllCars
    {
        private readonly ICarsCategory categoryCars = new MockCategory();

        public IEnumerable<Car> Cars {
            get
            {
                return new List<Car> {
                    new Car { Name = "Tesla", 
                        ShortDescription = "short Description about Tesla", 
                        LongDescription = "long Description about Tesla", 
                        Img = @"\img\tesla.jpg", 
                        Price = 4500, 
                        IsFavorite = true, 
                        Available = true, 
                        Category = categoryCars.AllCategories.First() },
                    new Car { Name = "BMV",
                        ShortDescription = "short Description about BMV",
                        LongDescription = "long Description about BMV",
                        Img = "/img/bmw.jpg",
                        Price = 4500,
                        IsFavorite = false,
                        Available = true,
                        Category = categoryCars.AllCategories.Last() },
                    new Car { Name = "Audi",
                        ShortDescription = "short Description about Audi",
                        LongDescription = "long Description about Audi",
                        Img = @"\img\audi tt.jpg",
                        Price = 4500,
                        IsFavorite = false,
                        Available = false,
                        Category = categoryCars.AllCategories.Last() },
                    new Car { Name = "Nissan Leaf",
                        ShortDescription = "short Description about ELeaf",
                        LongDescription = "long Description about ELeaf",
                        Img = @"\img\leaf.jpg",
                        Price = 4500,
                        IsFavorite = true,
                        Available = false,
                        Category = categoryCars.AllCategories.First() },
                    new Car { Name = "VAZ 2108",
                        ShortDescription = "short Description about VAZ",
                        LongDescription = "long Description about VAZ",
                        Img = @"\img\vaz_2108.jpg",
                        Price = 4500,
                        IsFavorite = true,
                        Available = true,
                        Category = categoryCars.AllCategories.Last() },
                };
            }
        }
        public IEnumerable<Car> GetFavCars { get ; set; }

        public Car GetObjectCar(int carID)
        {
            throw new NotImplementedException();
        }
    }
}
