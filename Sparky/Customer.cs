namespace Sparky
{
    public class Customer
    {

        public int Discount { get; set; } = 15;

        public int OrderTotal { get; set; }

        public string? GreetMessage { get; set; }
        public bool IsPlatinum { get; set; }

        public Customer()
        {
            IsPlatinum = false;
        }

        public string GreetAndCombineName(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName))
                throw new ArgumentException("Empty First Name");

            GreetMessage = $"Hello, {firstName} {lastName}";
            Discount = 20;
            return GreetMessage;
        }

        public CustomerType GetCustomerDetails()
        {
            if (OrderTotal < 100)
            {
                return new BasicCustomer();
            }
            return new PlatiniumCustomer();
        }

    }

    public class CustomerType { }
    public class BasicCustomer : CustomerType { }
    public class PlatiniumCustomer : CustomerType { }
}
