using System;
using System.Collections.Generic;
using System.IO;
using CarRentalSystem.Cars.Model;

namespace CarRentalSystem.Cars.Repository
{
    public class CarRepository
    {
        // Initial car records (previously the static array initializer in Program.cs).
        public List<Car> GetDefaultCars()
        {
            List<Car> cars = new List<Car>();
            cars.Add(new Car("Civic", 50000, 1));
            cars.Add(new Car("Corolla", 45000, 1));
            cars.Add(new Car("Mehran", 20000, 1));
            cars.Add(new Car("City", 48000, 1));
            cars.Add(new Car("Alto", 25000, 1));
            return cars;
        }

        // ---------- FILE HANDLING (cars.txt) ----------
        public void SaveCars(List<Car> cars)
        {
            StreamWriter myfile = new StreamWriter("cars.txt");

            for (int i = 0; i < cars.Count; i++)
                myfile.Write(cars[i].name + " " + cars[i].price + " " + cars[i].available + "\n");

            myfile.Close();
        }

        public void LoadCars(List<Car> cars)
        {
            if (!File.Exists("cars.txt"))
                return;

            StreamReader myfile = new StreamReader("cars.txt");
            string text = myfile.ReadToEnd();
            myfile.Close();

            // same as myfile >> carName[i] >> carPrice[i] >> carAvailable[i]
            List<string> words = new List<string>(text.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries));

            int i = 0;
            int w = 0;

            while (i < cars.Count && w + 2 < words.Count)
            {
                int price;
                int available;

                if (!int.TryParse(words[w + 1], out price) || !int.TryParse(words[w + 2], out available))
                    break;

                cars[i].name = words[w];
                cars[i].price = price;
                cars[i].available = available;

                w = w + 3;
                i++;
            }
        }
    }
}
