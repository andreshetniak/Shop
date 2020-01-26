using Shop.Data.Models;

namespace Shop.Data.Interfaces
{
    public interface IAllOrders
    {
        public void CreateOrder(Order order);
    }
}
