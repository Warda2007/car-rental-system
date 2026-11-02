using CarRentalSystem.Cars.Service;
using CarRentalSystem.RentalHistories.Service;
using CarRentalSystem.Users.Model;
using CarRentalSystem.Users.Repository;

namespace CarRentalSystem.Users.Service
{
    // Business logic of the user panel (rent, return, swap, sort, count, remove all)
    // plus loadAllData()/saveAllData() of the original Program.cs.
    public class UserService
    {
        private User user1;
        private User user2;

        private UserRepository userRepository;
        private CarService carService;
        private RentalHistoryService historyService;

        public UserService(UserRepository userRepository, CarService carService, RentalHistoryService historyService)
        {
            this.userRepository = userRepository;
            this.carService = carService;
            this.historyService = historyService;

            user1 = new User(1);
            user2 = new User(2);
        }

        public User GetUser(int id)
        {
            if (id == 1)
                return user1;
            return user2;

        }



        // public list<int> searchrange(int maxprice, int minprice){
        // return carservive. list<int>searchrange(maxprice, minprice);
        //}


        // public list<string>searchbyname(string name){
        //return car.service list<string>searchbyname;
        //}






        // ---------- FILE HANDLING (all data) ----------
        public void LoadAllData()
        {
            carService.Load();
            userRepository.Load(user1);
            userRepository.Load(user2);
            historyService.Load();
        }

        public void SaveAllData()
        {
            carService.Save();
            userRepository.Save(user1);
            userRepository.Save(user2);
            historyService.Save();
        }

        // ---------- FUNCTIONS ----------
        public int RentCar(User currentUser, int index)
        {
            if (carService.IsValidIndex(index))
            {
                if (carService.IsAvailable(index))
                {
                    // Save the car name before changing its availability.
                    // This ensures the exact car name is added to the user's List.
                    string carName = carService.GetCar(index).name;

                    if (string.IsNullOrEmpty(carName) || carName.Equals("null", System.StringComparison.OrdinalIgnoreCase))
                        return 3;

                    carService.RentCar(index);

                    currentUser.AddCar(carName);
                    historyService.Add("User" + currentUser.id + " rented " + carName);

                    SaveAllData();
                    return 1; // 1 = car rented successfully
                }
                else
                    return 2; // 2 = car is not available
            }
            else
                return 3; // 3 = invalid car index
        }

        // returns true if the car name was found in the car list
        public bool ReturnCar(User currentUser, string name)
        {
            bool found = carService.ReturnCarByName(name);

            currentUser.ReturnCar(name);
            historyService.Add("User" + currentUser.id + " returned " + name);

            SaveAllData();

            return found;
        }

        // returns false when an index is invalid
        public bool SwapCars(User currentUser, int a, int b)
        {
            if (carService.IsValidIndex(a) && carService.IsValidIndex(b))
            {
                carService.SwapCars(a, b);

                historyService.Add("User" + currentUser.id + " swapped cars");
                SaveAllData();

                return true;
            }
            else
                return false;
        }

        public void SortByPrice()
        {
            carService.SortByPrice();

            historyService.Add("Cars sorted");
            SaveAllData();
        }

        public int CountCars(User currentUser)
        {
            return currentUser.cars.Count;
        }

        public void RemoveAllCars(User currentUser)
        {
            // Make every car in this user's rented-car List available again.
            for (int i = 0; i < currentUser.cars.Count; i++)
                carService.ReturnCarByName(currentUser.cars[i]);

            // Now clear the user's personal rented-car List.
            currentUser.RemoveAllCars();

            historyService.Add("User" + currentUser.id + " removed all cars");

            SaveAllData();
        }

        // used by the admin "Reset System"
        public void RemoveAllCarsOfAllUsers()
        {
            user1.RemoveAllCars();
            user2.RemoveAllCars();
        }
    }
}
