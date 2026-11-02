using System.Collections.Generic;
using CarRentalSystem.Cars.Model;
using CarRentalSystem.Cars.Repository;

namespace CarRentalSystem.Cars.Service
{
    // Business logic that works on the 5-car list (the former static
    // "cars" array of Program.cs). Operations that also touch users/history
    // and save all data are coordinated by UserService / AdminService.
    public class CarService
    {
        private List<Car> cars;
        private CarRepository carRepository;

        public CarService(CarRepository carRepository)
        {
            this.carRepository = carRepository;
            cars = carRepository.GetDefaultCars();
        }

        public Car GetCar(int index)
        {
            return cars[index];
        }

        // number of cars in the list (needed by CarUI loops)
        public int GetCarCount()
        {
            return cars.Count;
        }

        // original check: index >= 0 && index < 5
        public bool IsValidIndex(int index)
        {
            return index >= 0 && index < cars.Count;
        }

        public void Load()
        {
            carRepository.LoadCars(cars);
        }

        public void Save()
        {
            carRepository.SaveCars(cars);
        }

        public void AddCar(int index, string name, int price)
        {
            cars[index].name = name;
            cars[index].price = price;

            cars[index].available = 1;
        }

        public void RemoveCar(int index)
        {
            cars[index].Remove();
        }

        public bool IsAvailable(int index)
        {
            return cars[index].IsAvailable();
        }

        public void RentCar(int index)
        {
            cars[index].Rent();
        }

        // returns true if a car with this name was found (and returned)
        public bool ReturnCarByName(string name)
        {
            bool found = false;

            for (int i = 0; i < cars.Count; i++)
            {
                if (cars[i].name == name)
                {
                    cars[i].Return();
                    found = true;
                }
            }

            return found;
        }

        public void SwapCars(int a, int b)
        {
            // swapping the two Car objects swaps name, price and available together
            Car temp = cars[a];
            cars[a] = cars[b];
            cars[b] = temp;
        }
         //public List<int> SearchRange (int maxprice, int minprice){
        // list<int> searchrange= newlist<int> ;
        // for (int i=0;  i<cars.count; i++){
        // if(car[i].price>=min && cars[i].price<=max){
        // list<int>searchrange.add(i) ;}
        // return searchrange;
        // }
        //}

        // public list<string>searchbyname(string name){
        // list<string> searchbyname=new list<string> ;
        // for(int i=0; i<cars.count; i++){
        // if(cars[i].name.ToLower == carname.ToLower){
        // list<string> searchbyname.add.cars.name ;
        //}
        //}
        //}



        // public list<int> searchavailableity
        // logic implementation by comparing the available cars from the list and then loading the cars available in the list

        public void SortByPrice()
        {
            for (int i = 0; i < cars.Count; i++)
            {
                for (int j = 0; j < cars.Count - 1; j++)
                {
                    if (cars[j].price > cars[j + 1].price)
                    {
                        Car temp = cars[j];
                        cars[j] = cars[j + 1];
                        cars[j + 1] = temp;
                    }
                }
            }
        }

        public void ResetCarsToDefault()
        {
            // Restore the original car names, prices, order and availability.
            // This also removes any cars that were added to the inventory list.
            List<Car> defaultCars = carRepository.GetDefaultCars();

            cars.Clear();

            for (int i = 0; i < defaultCars.Count; i++)
                cars.Add(defaultCars[i]);
        }
    }
}
