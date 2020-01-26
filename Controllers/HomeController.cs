using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private IAllCars carRepository;

        public HomeController(IAllCars carRepository)
        {
            this.carRepository = carRepository;
        }

        public ViewResult Index()
        {
            var homeCars = new HomeViewModel { FavoriteCars = this.carRepository.GetFavCars };
            return View(homeCars);
        }
    }
}