using System.Collections.Generic;

namespace Shop.Data.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public string Decription { get; set; }

        public List<Car> Cars { get; set; }
    }
}
