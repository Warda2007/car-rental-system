using System.Collections.Generic;

namespace CarRentalSystem.Users.Model
{
    public class User
    {
        public int id;
        public List<string> cars;

        public User(int id)
        {
            this.id = id;
            cars = new List<string>();
        }

        public void AddCar(string carName)
        {
            cars.Add(carName);
        }

        public void ReturnCar(string name)
        {
            for (int i = 0; i < cars.Count; i++)
            {
                if (cars[i] == name)
                {
                    cars.RemoveAt(i);
                    break;
                }
            }
        }

        public void RemoveAllCars()
        {
            cars.Clear();
        }
    }
}
