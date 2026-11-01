using System;
using CarRentalSystem.Admins.Service;
using CarRentalSystem.Cars.UI;
using CarRentalSystem.Common;
using CarRentalSystem.RentalHistories.UI;
using CarRentalSystem.Users.UI;

namespace CarRentalSystem.Admins.UI
{
    // The admin login/menu (adminPanel) and every admin-menu action of the original Program.cs.
    public class AdminUI
    {
        private AdminService adminService;
        private CarUI carUI;
        private UserUI userUI;
        private RentalHistoryUI historyUI;

        public AdminUI(AdminService adminService, CarUI carUI, UserUI userUI, RentalHistoryUI historyUI)
        {
            this.adminService = adminService;
            this.carUI = carUI;
            this.userUI = userUI;
            this.historyUI = historyUI;
        }

        private void AddCar()
        {
            int index;
            Console.Write("Enter index (0-4): ");
            index = ConsoleInput.ReadInt();

            if (adminService.IsValidCarIndex(index))
            {
                Console.Write("Enter car name: ");
                string name = ConsoleInput.ReadWord();
                Console.Write("Enter price: ");
                int price = ConsoleInput.ReadInt();

                adminService.AddCar(index, name, price);

                Console.Write("Car added!");
            }
            else
                Console.Write("Invalid index!");
        }

        private void RemoveCar()
        {
            int index;
            Console.Write("Enter index to remove: ");
            index = ConsoleInput.ReadInt();

            if (adminService.RemoveCar(index))
            {
                Console.Write("Car removed!");
            }
            else
                Console.Write("Invalid index!");
        }

        private void ViewUserCars()
        {
            Console.Write("\nUser1 Cars:\n");
            userUI.ShowCars(adminService.GetUser(1));

            Console.Write("\nUser2 Cars:\n");
            userUI.ShowCars(adminService.GetUser(2));
        }

        private void ResetSystem()
        {
            adminService.ResetSystem();

            Console.Write("System Reset Done!");
        }

        public void AdminPanel()
        {
            string u, p;
            Console.Write("Enter username: ");
            u = ConsoleInput.ReadWord();
            Console.Write("Enter password: ");
            p = ConsoleInput.ReadWord();

            if (adminService.CheckLogin(u, p))
            {
                int adminChoice;

                while (true)
                {
                    Console.Clear();
                    Console.Write("\n===== ADMIN PANEL =====\n");
                    Console.Write("1. View All Cars\n");
                    Console.Write("2. Add Car\n");
                    Console.Write("3. Remove Car\n");
                    Console.Write("4. View User Cars\n");
                    Console.Write("5. View History\n");
                    Console.Write("6. Reset System\n");
                    Console.Write("7. Logout\n");
                    Console.Write("Enter: ");
                    adminChoice = ConsoleInput.ReadInt();

                    if (adminChoice == 1)
                        carUI.ViewAllCars();
                    else if (adminChoice == 2)
                        AddCar();
                    else if (adminChoice == 3)
                        RemoveCar();
                    else if (adminChoice == 4)
                        ViewUserCars();
                    else if (adminChoice == 5)
                        historyUI.Show();
                    else if (adminChoice == 6)
                        ResetSystem();
                    else if (adminChoice == 7)
                        break;
                    else
                        Console.Write("Invalid");

                    Console.Write("\nPress any key...");
                    Console.ReadKey(true);
                }
            }
            else
            {
                Console.Write("Wrong Admin Credentials!");
                Console.ReadKey(true);
            }
        }
    }
}
