using System;
using CarRentalSystem.Cars.UI;
using CarRentalSystem.Common;
using CarRentalSystem.Users.Model;
using CarRentalSystem.Users.Service;

namespace CarRentalSystem.Users.UI
{
    // The user menu (userPanel) and every user-menu action of the original Program.cs.
    public class UserUI
    {
        private UserService userService;
        private CarUI carUI;

        public UserUI(UserService userService, CarUI carUI)
        {
            this.userService = userService;
            this.carUI = carUI;
        }

        // prints the cars of a user (former User.ShowCars)
        public void ShowCars(User user)
        {
            for (int i = 0; i < user.cars.Count; i++)
            {
                if (!string.IsNullOrEmpty(user.cars[i]) &&
                    !user.cars[i].Equals("null", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Write(user.cars[i]);
                    Console.WriteLine();
                }
            }
        }

        private void RentCar(User currentUser)
        {
            int index;
            Console.Write("Enter car number: ");
            index = ConsoleInput.ReadInt();

            int result = userService.RentCar(currentUser, index);

            if (result == 1)
                Console.Write("Car rented");
            else if (result == 2)
                Console.Write("Not available");
            else
                Console.Write("Invalid index");
        }

        private void ReturnCar(User currentUser)
        {
            string name;
            Console.Write("Enter car name: ");
            name = ConsoleInput.ReadWord();

            bool found = userService.ReturnCar(currentUser, name);

            if (found)
                Console.Write("Car Returned Successfully");
            else
                Console.Write("Car not found");
        }

        private void MyCars(User currentUser)
        {
            ShowCars(currentUser);
        }

        private void SwapCars(User currentUser)
        {
            int a, b;
            Console.Write("Enter first index: ");
            a = ConsoleInput.ReadInt();
            Console.Write("Enter second index: ");
            b = ConsoleInput.ReadInt();

            if (userService.SwapCars(currentUser, a, b))
                Console.Write("Swapped");
            else
                Console.Write("Invalid index");
        }

        private void SortByPrice()
        {
            userService.SortByPrice();

            Console.Write("Sorted:\n");
            carUI.ShowPrices();
        }

        private void CountMyCars(User currentUser)
        {
            Console.Write(userService.CountCars(currentUser));
        }

        private void RemoveAllMyCars(User currentUser)
        {
            userService.RemoveAllCars(currentUser);

            Console.Write("All removed");
        }

        public void UserPanel(User currentUser)
        {
            int userChoice;

            while (true)
            {
                Console.Clear();
                Console.Write("--- MENU ---\n");
                Console.Write("1. View Cars\n");
                Console.Write("2. Rent Car\n");
                Console.Write("3. Return Car\n");
                Console.Write("4. My Cars\n");
                Console.Write("5. Swap Cars\n");
                Console.Write("6. Check Availability\n");
                Console.Write("7. Sort by Price\n");
                Console.Write("8. Count My Cars\n");
                Console.Write("9. Remove All Cars\n");
                Console.Write("10. Logout\n");
                Console.Write("Enter: ");
                userChoice = ConsoleInput.ReadInt();

                if (userChoice == 10)
                {
                    Console.Write("\nThanks for using Car Rental System\nVisit again!\n");
                    Console.ReadKey(true);
                    break;
                }
                else if (userChoice == 1)
                    carUI.ViewCarsUser();
                else if (userChoice == 2)
                    RentCar(currentUser);
                else if (userChoice == 3)
                    ReturnCar(currentUser);
                else if (userChoice == 4)
                    MyCars(currentUser);
                else if (userChoice == 5)
                    SwapCars(currentUser);
                else if (userChoice == 6)
                    carUI.CheckAvailability();
                else if (userChoice == 7)
                    SortByPrice();
                else if (userChoice == 8)
                    CountMyCars(currentUser);
                else if (userChoice == 9)
                    RemoveAllMyCars(currentUser);
                else
                    Console.Write("Invalid");

                Console.Write("\n\nPress any key to continue...");
                Console.ReadKey(true);
            }
        }
    }
}
