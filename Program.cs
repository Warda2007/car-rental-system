using System;
using CarRentalSystem.Admins.Repository;
using CarRentalSystem.Admins.Service;
using CarRentalSystem.Admins.UI;
using CarRentalSystem.Cars.Repository;
using CarRentalSystem.Cars.Service;
using CarRentalSystem.Cars.UI;
using CarRentalSystem.Common;
using CarRentalSystem.RentalHistories.Repository;
using CarRentalSystem.RentalHistories.Service;
using CarRentalSystem.RentalHistories.UI;
using CarRentalSystem.Users.Model;
using CarRentalSystem.Users.Repository;
using CarRentalSystem.Users.Service;
using CarRentalSystem.Users.UI;

namespace CarRentalSystem
{
    class Program
    {
        // ---------- Repository layer ----------
        static CarRepository carRepository = new CarRepository();
        static UserRepository userRepository = new UserRepository();
        static RentalHistoryRepository historyRepository = new RentalHistoryRepository();
        static AdminRepository adminRepository = new AdminRepository();

        // ---------- Service layer ----------
        static CarService carService = new CarService(carRepository);
        static RentalHistoryService historyService = new RentalHistoryService(historyRepository);
        static UserService userService = new UserService(userRepository, carService, historyService);
        static AdminService adminService = new AdminService(adminRepository, carService, userService, historyService);

        // ---------- UI layer ----------
        static CarUI carUI = new CarUI(carService);
        static RentalHistoryUI historyUI = new RentalHistoryUI(historyService);
        static UserUI userUI = new UserUI(userService, carUI);
        static AdminUI adminUI = new AdminUI(adminService, carUI, userUI, historyUI);

        static User user1 = userService.GetUser(1);
        static User user2 = userService.GetUser(2);

        static void Main(string[] args)
        {
            userService.LoadAllData();

            int choice;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("   ______                                                       ______");
                Console.WriteLine("  /|_||_\\`.__      ===== CAR RENTAL SYSTEM =====              /|_||_\\`.__");
                Console.WriteLine(" (   _    _ _\\                                               (   _    _ _\\");
                Console.WriteLine(" =`-(_)--(_)-'                                                =`-(_)--(_)-'");

                Console.Write("1. User 1\n");
                Console.Write("2. User 2\n");
                Console.Write("3. Exit\n");
                Console.Write("4. Admin\n");
                Console.Write("Enter choice: ");
                choice = ConsoleInput.ReadInt();

                if (choice == 3)
                {
                    userService.SaveAllData();
                    Console.Write("\nProgram ended. Goodbye!\n");
                    Console.ReadKey(true);
                    break;
                }
                else if (choice == 4)
                    adminUI.AdminPanel();
                else if (choice == 1)
                    userUI.UserPanel(user1);
                else if (choice == 2)
                    userUI.UserPanel(user2);
                else
                {
                    Console.Write("Wrong choice");
                    Console.ReadKey(true);
                }
            }
        }
    }
}
