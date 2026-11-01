using CarRentalSystem.Admins.Model;

namespace CarRentalSystem.Admins.Repository
{
    // The original program has NO file storage for the admin account: the
    // credentials were hard-coded in Program.cs (new Admin("admin", "123")).
    // To keep behaviour identical (and not invent a new data file), this
    // repository is the single place that supplies that same built-in record.
    public class AdminRepository
    {
        public Admin GetAdmin()
        {
            return new Admin("admin", "123");
        }
    }
}
