using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category { CategoryName = "Электромобили", Decription = "Автомобили испльзующие эликтричество для передвижения"},
                    new Category { CategoryName = "Автомобили с ДВЗ", Decription = "Автомобили с двигателями внутреннего сгорания"}
                };
            }
        }
    }
}
