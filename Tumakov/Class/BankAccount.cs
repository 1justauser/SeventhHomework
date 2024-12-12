namespace Tumakov
{
    sealed class BankAccount
    {
        #region Fields
        private decimal balance;
        private static decimal defaultBalance = (decimal)Math.Round(Math.Exp(1), 6);
        private BankAccountType bankAccountType;
        private string identificator;
        private Dictionary<string, bool> identificators = new Dictionary<string, bool>();
        #endregion
        #region Constructor Methods
        public BankAccount()
        {
            balance = 0;
            bankAccountType = (BankAccountType)0;
            identificator = "default";
            IDGenerator();
        }
        public BankAccount(decimal userBalance, BankAccountType bankAccountType)
        {
            this.balance = userBalance;
            this.bankAccountType = bankAccountType;
            identificator = "defalt";
            IDGenerator();
        }
        #endregion
        #region Call Methods
        static public void SolveTask()
        {
            Console.WriteLine("Аккаунт куда мы добавим деньги со второго аккаунта");
            BankAccount userAmir = new BankAccount(32310, (BankAccountType)1);
            userAmir.Output();
            BankAccount userNew = new BankAccount();
            Console.WriteLine("Укажем аккаунт откуда снимем деньги");
            userNew.Input();
            userNew.Output();
            Console.WriteLine("Укажите сколько денег снимаются");
            InputWithdrawal(out decimal withdrawal);
            if (userAmir.WithdrawalFromAnotherAccount(userNew, withdrawal) == 0)
            {
                Console.WriteLine("Успешный перевод");
                userAmir.Output();
            }
            else
            {
                Console.WriteLine("Перевод не выполнен");
            }
        }
        public void Output()
        {
            if (bankAccountType == (BankAccountType)2)
            {
                Console.WriteLine("Тип и баланс не определены");
            }
            else
            {
                Console.WriteLine($"У вас {bankAccountType.ToString()} тип аккуанта");
            }
            if (balance == defaultBalance)
            {
                Console.WriteLine("Ваш баланс не определен");
            }
            else
            {
                Console.WriteLine($"Ваш баланс {balance}");
            }
        }
        public void Input()
        {
            IDGenerator();
            Console.WriteLine("Здравствуйте! Создадим банковский аккуант");
            Console.WriteLine("Определим тип счета сберегательный/текущий");
            InputBankAccountType(Console.ReadLine()!);
            if (bankAccountType == (BankAccountType)2)
            {
                Console.WriteLine("Ваш тип счета неопределен, баланс неопределен");
                balance = defaultBalance;
            }
            else
            {
                Console.WriteLine("Укажите баланс");
                InputBalance(Console.ReadLine()!);
            }
        }
        private static void InputWithdrawal(out decimal withdrawal)
        {
            if(!decimal.TryParse(Console.ReadLine(), out withdrawal))
            {
                Console.WriteLine("Ошибка при указании количества денег");
                withdrawal = defaultBalance;
            }
        }
        private void InputBalance(string stringBalance)
        {
            if (!decimal.TryParse(stringBalance, out balance))
            {
                Console.WriteLine("Ошибка вы неправильно указали баланс, он не определен");
                balance = defaultBalance;
            }
        }
        private void InputBankAccountType(string type)
        {
            if (type.ToLower().Replace(" ", string.Empty) == "сберегательный")
            {
                bankAccountType = (BankAccountType)0;
            }
            else if (type.ToLower().Replace(" ", string.Empty) == "текущий")
            {
                bankAccountType = (BankAccountType)1;
            }
            else
            {
                Console.WriteLine("Вы неправильно указали тип аккаунта!");
                bankAccountType = (BankAccountType)2;
            }
        }
        #endregion
        #region Computing Methods
        private byte WithdrawalFromAnotherAccount(BankAccount bankAccount, decimal withdrawal)
        {
            if (withdrawal == defaultBalance)
            {
                return 5;
            }
            if (bankAccount.bankAccountType == (BankAccountType)2)
            {
                return 1;
            }
            else if (bankAccount.balance == defaultBalance)
            {
                return 2;
            }
            else if (withdrawal <= 0)
            {
                return 3;
            }
            else if (withdrawal > bankAccount.balance)
            {
                return 4;
            }
            else
            {
                this.balance += withdrawal;
                bankAccount.balance -= withdrawal;
                return 0;
            }
        }
        private void IDGenerator()
        {
            string Identificator = UniqueIdentificatorGenerator();
            while (identificators.ContainsKey(Identificator))
            {
                Identificator = UniqueIdentificatorGenerator();
            }
            identificators.Add(Identificator, true);
            identificator = Identificator;
        }
        static private string UniqueIdentificatorGenerator()
        {
            return Guid.NewGuid().ToString("N");
        }
        #endregion
    }
}
