using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.ViewModels;
using System.Linq;

namespace Shop.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IAllCars carRepository;
        private readonly ShopCart shopCart;

        public ShopCartController(IAllCars carRepository, ShopCart shopCart)
        {
            this.carRepository = carRepository;
            this.shopCart = shopCart;
        }

        public ViewResult Index()
        {
            var items = this.shopCart.GetShopItems();
            this.shopCart.ListShopItems = items;
            var obj = new ShopCartViewModel { ShopCart = this.shopCart };
            return View(obj);
        }

        public RedirectToActionResult AddToCart(int id)
        {
            var item = this.carRepository.Cars.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                this.shopCart.AddToCart(item);
            }

            return RedirectToAction("Index");
        }
    }
}
