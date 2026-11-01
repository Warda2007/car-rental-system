namespace CarRentalSystem.Admins.Model
{
    public class Admin
    {
        public string adminUser;
        public string adminPass;

        public Admin(string adminUser, string adminPass)
        {
            this.adminUser = adminUser;
            this.adminPass = adminPass;
        }
    }
}
