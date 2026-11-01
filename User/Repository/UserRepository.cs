using System.IO;
using CarRentalSystem.Users.Model;

namespace CarRentalSystem.Users.Repository
{
    public class UserRepository
    {
        // user1cars.txt / user2cars.txt
        public void Save(User user)
        {
            StreamWriter myfile = new StreamWriter("user" + user.id + "cars.txt");

            for (int i = 0; i < user.cars.Count; i++)
            {
                if (!string.IsNullOrEmpty(user.cars[i]) &&
                    !user.cars[i].Equals("null", System.StringComparison.OrdinalIgnoreCase))
                    myfile.Write(user.cars[i] + "\n");
            }

            myfile.Close();
        }

        public void Load(User user)
        {
            if (!File.Exists("user" + user.id + "cars.txt"))
                return;

            StreamReader myfile = new StreamReader("user" + user.id + "cars.txt");

            user.cars.Clear();
            string line;
            while ((line = myfile.ReadLine()) != null && user.cars.Count < 5)
            {
                if (line.Length == 0 || line.Equals("null", System.StringComparison.OrdinalIgnoreCase))
                    continue;

                user.cars.Add(line);
            }

            myfile.Close();
        }
    }
}
