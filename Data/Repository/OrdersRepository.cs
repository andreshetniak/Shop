using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;

namespace Shop.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDBContent appDBContent;
        private readonly ShopCart shopCart;

        public OrdersRepository(AppDBContent appDBContent, ShopCart shopCart)
        {
            this.appDBContent = appDBContent;
            this.shopCart = shopCart;
        }

        public void CreateOrder(Order order)
        {
            order.orderTime = DateTime.Now;
            appDBContent.Order.Add(order);

            var items = shopCart.ListShopItems;

            foreach (var item in items)
            {
                var orderDitail = new OrderDetail()
                {
                    Order = order,
                    Car = item.Car,
                    CarId = item.Id,
                    OrderId = order.Id,
                    Price = item.Car.Price
                };
                appDBContent.OrderDetail.Add(orderDitail);
            }
            appDBContent.SaveChanges();
        }
    }
}
