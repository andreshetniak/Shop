using Shop.Data.Models;
using System.Collections.Generic;

namespace Shop.Data.Interfaces
{
    public interface ICarsCategory
    {
        public IEnumerable<Category> AllCategories { get; }
    }
}
