using System;
using CarRentalSystem.Cars.Model;
using CarRentalSystem.Cars.Service;

namespace CarRentalSystem.Cars.UI
{
    // Console output related to cars (the former Car.Show... methods and the
    // viewAllCars / viewCarsUser / checkAvailability functions of Program.cs).
    public class CarUI
    {
        private CarService carService;

        public CarUI(CarService carService)
        {
            this.carService = carService;
        }

        // ---------- FUNCTIONS ----------
        public void ViewAllCars()
        {
            for (int i = 0; i < carService.GetCarCount(); i++)
                ShowForAdmin(carService.GetCar(i), i);
        }

        public void ViewCarsUser()
        {
            for (int i = 0; i < carService.GetCarCount(); i++)
                ShowForUser(carService.GetCar(i), i);
        }

        public void CheckAvailability()
        {
            for (int i = 0; i < carService.GetCarCount(); i++)
                ShowAvailability(carService.GetCar(i));
        }

        // prints name and price of every car (used after sorting)
        public void ShowPrices()
        {
            for (int i = 0; i < carService.GetCarCount(); i++)
                ShowPrice(carService.GetCar(i));
        }

        // Admin view: index, name, price, status
        private void ShowForAdmin(Car car, int i)
        {
            Console.Write(i + " " + car.name
                 + " " + car.price);

            if (car.available == 1)
            {
                Console.Write(" Available");
            }
            else
            {
                Console.Write(" Rented");
            }
            Console.WriteLine();
        }

        // User view: index, name, status
        private void ShowForUser(Car car, int i)
        {
            Console.Write(i + " " + car.name);
            if (car.available == 1)
                Console.Write(" Available");
            else
                Console.Write(" Rented");
            Console.WriteLine();
        }

        // Check Availability view: name and availability number
        private void ShowAvailability(Car car)
        {
            Console.Write(car.name + " " + car.available);
            Console.WriteLine();
        }

        // Sort view: name and price
        private void ShowPrice(Car car)
        {
            Console.Write(car.name + " " + car.price);
            Console.WriteLine();
        }
    }
}
