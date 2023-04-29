namespace Sparky
{
    public class BankAccount
    {
        private readonly ILogBook logBook;

        public int Balance { get; set; }

        public BankAccount(ILogBook logBook)
        {
            Balance = 0;
            this.logBook = logBook;
        }

        public bool Deposit(int amount)
        {
            logBook.Message("Deposit invoked");
            logBook.Message("Test");
            logBook.LogSeverity = 101;
            var temp = logBook.LogSeverity;
            Balance += amount;
            return true;
        }

        public bool Withrdraw(int amount)
        {
            if (amount <= Balance)
            {
                logBook.LogToDb("Withdrawal amount: " + amount.ToString());
                Balance -= amount;
                return logBook.LogBalanceAgerWithdrawl(Balance);
            }
            return logBook.LogBalanceAgerWithdrawl(Balance - amount);
        }

        public int GetBalance()
        {
            return Balance;
        }
    }
}
