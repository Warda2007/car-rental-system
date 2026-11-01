namespace CarRentalSystem.Cars.Model
{
    public class Car
    {
        public string name;
        public int price;
        public int available;

        public Car(string name, int price, int available)
        {
            this.name = name;
            this.price = price;
            this.available = available;
        }

        public bool IsAvailable()
        {
            return available == 1;
        }

        public void Rent()
        {
            available = 0;
        }

        public void Return()
        {
            available = 1;
        }

        public void Remove()
        {
            name = "NULL";
            price = 0;
            available = 0;
        }
    }
}
