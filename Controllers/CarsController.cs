using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.ViewModels;
using Shop.Data.Mocks;

namespace Shop.Controllers
{
    public class CarsController : Controller
    {
        private readonly IAllCars allCars;
        private readonly ICarsCategory allCarsCategory;

        public CarsController(IAllCars allCars, ICarsCategory allCarsCategory)
        {
            this.allCars = allCars;
            this.allCarsCategory = allCarsCategory;
        }

        public ViewResult List()
        {

            ViewBag.Title = "Aouto page";
            CarsListViewModel obj = new CarsListViewModel();

            obj.GetAllCars = allCars.Cars;
            obj.currentCategory = "auto";

            return View(obj);
        }
    }
}
