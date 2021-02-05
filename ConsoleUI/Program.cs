using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var car in carManager.GetAll())
            {
                var brand = brandManager.GetBrandNameByBrandId(car.CarBrandID);
                var color = colorManager.GetColorNameByColorId(car.CarColorID);
                Console.WriteLine("Car Id : {0}\nCar Brand: {1}\nCar Color:  {2}\nModel Year:  {3}\nDaily Price:  {4}\nDescription:  {5}\n",
                    car.CarID, brand.BrandName, color.ColorName, car.ModelYear, car.DailyPrice, car.Description);
            }

            //carManager.Add(new Car 
            //{
            //    CarBrandID=3,
            //    CarColorID=2,
            //    DailyPrice=180,
            //    ModelYear=2016,
            //    Description="4 Adult / 2 Big Suitcase / Manual Shift / Diesel"
            //});

            //brandManager.Update(new Brand {BrandID= 2,BrandName= "Wolksvagen", BrandModel="T-Roc" });
            //colorManager.Delete(new Color {ColorID=2});
            //colorManager.Add(new Color {ColorName = "White" });



        }
    }
}
