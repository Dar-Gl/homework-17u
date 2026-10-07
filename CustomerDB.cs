namespace CustomerMaintenance
{
    public static class CustomerDB
    {
        private const string dir = @"C:\C#\Files";
        private const string path = dir + @"\Customers.dat";

        public static void SaveCustomers(List<Customer> customers)
        {
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            using BinaryWriter binaryOut = new(
                new FileStream(path, FileMode.Create, FileAccess.Write));

            foreach (Customer customer in customers)
            {
                binaryOut.Write(customer.FirstName);
                binaryOut.Write(customer.LastName);
                binaryOut.Write(customer.Email);
            }
        }

        public static List<Customer> GetCustomers()
        {
            List<Customer> customers = new();

            if (File.Exists(path))
            {
                using BinaryReader binaryIn = new(
                    new FileStream(path, FileMode.Open, FileAccess.Read));

                while (binaryIn.PeekChar() != -1)
                {
                    string firstName = binaryIn.ReadString();
                    string lastName = binaryIn.ReadString();
                    string email = binaryIn.ReadString();

                    customers.Add(new Customer(firstName, lastName, email));
                }
            }

            return customers;
        }
    }
}
