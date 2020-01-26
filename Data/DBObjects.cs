using Shop.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Data
{
    public class DBObjects
    {
        private static Dictionary<string, Category> category;

        public static void Initial(AppDBContent content)
        {
            if (!content.Category.Any())
            {
                content.Category.AddRange(Categories.Select(content => content.Value));
            }

            if (!content.Car.Any())
            {
                content.AddRange(
                    new Car
                    {
                        Name = "Tesla",
                        ShortDescription = "short Description about Tesla",
                        LongDescription = "long Description about Tesla",
                        Img = @"\img\tesla.jpg",
                        Price = 4500,
                        IsFavorite = true,
                        Available = true,
                        Category = Categories["Электромобили"]
                    },
                    new Car
                    {
                        Name = "BMV",
                        ShortDescription = "short Description about BMV",
                        LongDescription = "long Description about BMV",
                        Img = "/img/bmw.jpg",
                        Price = 4500,
                        IsFavorite = false,
                        Available = true,
                        Category = Categories["Автомобили с ДВЗ"]
                    },
                    new Car
                    {
                        Name = "Audi",
                        ShortDescription = "short Description about Audi",
                        LongDescription = "long Description about Audi",
                        Img = @"\img\audi tt.jpg",
                        Price = 4500,
                        IsFavorite = false,
                        Available = false,
                        Category = Categories["Автомобили с ДВЗ"]
                    },
                    new Car
                    {
                        Name = "Nissan Leaf",
                        ShortDescription = "short Description about ELeaf",
                        LongDescription = "long Description about ELeaf",
                        Img = @"\img\leaf.jpg",
                        Price = 4500,
                        IsFavorite = true,
                        Available = false,
                        Category = Categories["Электромобили"]
                    },
                    new Car
                    {
                        Name = "VAZ 2108",
                        ShortDescription = "short Description about VAZ",
                        LongDescription = "long Description about VAZ",
                        Img = @"\img\vaz_2108.jpg",
                        Price = 4500,
                        IsFavorite = true,
                        Available = true,
                        Category = Categories["Автомобили с ДВЗ"]
                    });
            }
            content.SaveChanges();
        }

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                        new Category { CategoryName = "Электромобили", Decription = "Автомобили испльзующие эликтричество для передвижения"},
                        new Category { CategoryName = "Автомобили с ДВЗ", Decription = "Автомобили с двигателями внутреннего сгорания"}
                    };

                    category = new Dictionary<string, Category>();

                    foreach (Category item in list)
                    {
                        category.Add(item.CategoryName, item);
                    }
                }

                return category;
            }
        }
    }
}
