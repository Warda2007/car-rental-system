using CarRentalSystem.Admins.Model;
using CarRentalSystem.Admins.Repository;
using CarRentalSystem.Cars.Service;
using CarRentalSystem.RentalHistories.Service;
using CarRentalSystem.Users.Model;
using CarRentalSystem.Users.Service;

namespace CarRentalSystem.Admins.Service
{
    // Business logic of the admin panel: login, add/remove car, reset system.
    // Coordinates CarService, UserService and RentalHistoryService.
    public class AdminService
    {
        private Admin admin;

        private AdminRepository adminRepository;
        private CarService carService;
        private UserService userService;
        private RentalHistoryService historyService;

        public AdminService(AdminRepository adminRepository, CarService carService, UserService userService, RentalHistoryService historyService)
        {
            this.adminRepository = adminRepository;
            this.carService = carService;
            this.userService = userService;
            this.historyService = historyService;

            admin = adminRepository.GetAdmin();
        }

        public bool CheckLogin(string u, string p)
        {
            return u == admin.adminUser && p == admin.adminPass;
        }

        public bool IsValidCarIndex(int index)
        {
            return carService.IsValidIndex(index);
        }

        // called only after IsValidCarIndex(index) was true
        public void AddCar(int index, string name, int price)
        {
            carService.AddCar(index, name, price);
            historyService.Add("Admin added " + carService.GetCar(index).name);
            userService.SaveAllData();
        }

        // returns false when the index is invalid
        public bool RemoveCar(int index)
        {
            if (carService.IsValidIndex(index))
            {
                historyService.Add("Admin removed " + carService.GetCar(index).name);

                carService.RemoveCar(index);

                userService.SaveAllData();

                return true;
            }
            else
                return false;
        }

        public User GetUser(int id)
        {
            return userService.GetUser(id);
        }

        public void ResetSystem()
        {
            carService.ResetCarsToDefault();

            userService.RemoveAllCarsOfAllUsers();
            historyService.Clear();

            userService.SaveAllData();
        }
    }
}
