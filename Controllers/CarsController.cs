using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

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

        [Route("Cars/List")]
        [Route("Cars/List/{category}")]
        public ViewResult List(string category)
        {
            //string _category = category;
            IEnumerable<Car> cars = null;
            string currentCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                cars = this.allCars.Cars.OrderBy(i => i.Id);
            }
            else
            {
                if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = allCars.Cars.Where(i => i.Category.CategoryName.Equals("Электромобили")).OrderBy(i => i.Id);
                    currentCategory = "Електромобили";
                }
                else if(string.Equals("fuel",category,StringComparison.OrdinalIgnoreCase))
                {
                    cars = allCars.Cars.Where(i => i.Category.CategoryName.Equals("Автомобили с ДВЗ")).OrderBy(i => i.Id);
                    currentCategory = "Автомобили с двигателями внутреннего сгорания";
                }
            }
            var carObj = new CarsListViewModel { GetAllCars = cars, currentCategory = currentCategory };

            ViewBag.Title = "Aouto page";

            return View(carObj);
        }
    }
}
