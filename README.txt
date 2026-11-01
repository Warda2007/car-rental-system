Car Rental System - .NET Framework 4.8

How to run:
1. Extract this ZIP.
2. Open CarRentalSystem.sln in Visual Studio Community.
3. If Visual Studio asks to install the .NET Framework 4.8 targeting pack, allow it or install the .NET desktop development workload.
4. In Solution Explorer, right-click CarRentalSystem and choose Set as Startup Project.
5. Press Ctrl+F5 to run without debugging.

The original C# code is placed in Program.cs and has not been intentionally redesigned.
The program uses text files (cars.txt, user1cars.txt, user2cars.txt, history.txt). They are created/read relative to the program's working directory. Keep backups of any existing data files.
Admin login: username admin, password 123.

Four-layer version: every class (Car, User, RentalHistory, Admin) has its own folder with four layers: UI, Service, Repository and Model (e.g. Car/UI/CarUI.cs, Car/Service/CarService.cs, Car/Repository/CarRepository.cs, Car/Model/Car.cs). Program.cs is the entry point (wiring + main menu) and Common/ConsoleInput.cs holds the shared input helpers. Behaviour, menus, output and data files are unchanged.
