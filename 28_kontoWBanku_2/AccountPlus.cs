namespace _28_kontoWBanku_2
{
    internal class AccountPlus : Account, IAccountWithLimit
    {
        public AccountPlus(string name, decimal initialLimit = 100, decimal initialBalance = 0) : base(name, initialBalance)
        {
            if (initialBalance > 0)
            {
                AvaibleFounds = initialBalance + initialLimit;
                if (initialLimit < 0)
                {
                    OneTimeDebetLimit = 0;
                }
                else
                {
                    OneTimeDebetLimit = initialLimit;
                    AvaibleFounds = initialLimit;
                }
            }
            else
            {
                if (initialLimit < 0)
                {
                    OneTimeDebetLimit = 0;
                }
                else
                {
                    OneTimeDebetLimit = initialLimit;
                    AvaibleFounds = initialLimit;
                }
            }
        }

        private decimal _limit { get; set; }

        public decimal OneTimeDebetLimit
        {
            get
            {
                return _limit;
            }
            set
            {
                if (value > 0 && !IsBlocked)
                    _limit = value;
            }
        }

        public decimal AvaibleFounds { get; set; }

        public override string ToString()
        {
            if (IsBlocked)
            {
                return $"Account name: {Name}, balance: {Balance:F2}, blocked, avaible founds: {AvaibleFounds:F2}, limit: {OneTimeDebetLimit:F2}";
            }
            else
                return $"Account name: {Name}, balance: {Balance:F2}, avaible founds: {AvaibleFounds:F2}, limit: {OneTimeDebetLimit:F2}";
        }
    }
}