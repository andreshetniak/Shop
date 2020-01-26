using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Data.Models
{
    public class ShopCart
    {
        private readonly AppDBContent appDBContent;

        public ShopCart(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public string ShopCartId { get; set; }
        public List<ShopCartItem> ListShopItems { get; set; }

        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCartId);

            return new ShopCart(context) { ShopCartId = shopCartId };
        }

        public void AddToCart(Car car)
        {
            this.appDBContent.ShopCartItem.Add(new ShopCartItem 
            {
                ShopCartId = this.ShopCartId,
                Car = car,
                Price = car.Price
            });

            appDBContent.SaveChanges();
        }

        public List<ShopCartItem> GetShopItems()
        {
            return appDBContent.ShopCartItem.Where(c => c.ShopCartId == this.ShopCartId).Include(s => s.Car).ToList();
        }
    }
}
