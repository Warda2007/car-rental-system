using System.IO;
using CarRentalSystem.RentalHistories.Model;

namespace CarRentalSystem.RentalHistories.Repository
{
    public class RentalHistoryRepository
    {
        // history.txt
        public void Save(RentalHistory rentalHistory)
        {
            StreamWriter myfile = new StreamWriter("history.txt");

            for (int i = 0; i < rentalHistory.history.Count; i++)
                myfile.Write(rentalHistory.history[i] + "\n");

            myfile.Close();
        }

        public void Load(RentalHistory rentalHistory)
        {
            if (!File.Exists("history.txt"))
                return;

            StreamReader myfile = new StreamReader("history.txt");

            rentalHistory.history.Clear();
            string line;
            while ((line = myfile.ReadLine()) != null && rentalHistory.history.Count < 50)
            {
                if (line.Length == 0)
                    continue;
                rentalHistory.history.Add(line);
            }

            myfile.Close();
        }
    }
}
