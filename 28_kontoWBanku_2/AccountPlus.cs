using System;

namespace _28_kontoWBanku_2
{
    internal class AccountPlus : Account, IAccountWithLimit
    {
        public AccountPlus(string name, decimal initialLimit = 100, decimal initialBalance = 0) : base(name, initialBalance)
        {
            if (initialLimit < 0)
            {
                _limit = 0;
                StdLimit = 0;
            }
            else
            {
                _limit = initialLimit;
                StdLimit = initialLimit;
            }
        }

        private decimal _limit { get; set; }
        private decimal StdLimit { get; set; }

        public decimal OneTimeDebetLimit
        {
            get
            {
                return _limit;
            }
            set
            {
                if (value > 0 && !IsBlocked)
                {
                    _limit = value;
                    StdLimit = value;
                }
            }
        }

        public new void Unblock()
        {
            if (OneTimeDebetLimit >= StdLimit)
            {
                base.Unblock();
            }
        }

        public new bool Deposit(decimal amount)
        {
            if (amount > 0)
            {
                if (OneTimeDebetLimit != StdLimit)
                {
                    if (amount + OneTimeDebetLimit >= StdLimit)
                    {
                        base.Unblock();
                        decimal brakujace = StdLimit - OneTimeDebetLimit;
                        amount -= Math.Round(brakujace, PRECISION);
                        _limit = StdLimit;
                        base.Deposit(Math.Round(amount, PRECISION));
                    }
                }
                else
                {
                    base.Deposit(Math.Round(amount, PRECISION));
                }

                if (OneTimeDebetLimit >= StdLimit)
                    base.Unblock();

                return true;
            }
            return false;
        }

        public new bool Withdrawal(decimal amount)
        {
            if (amount > 0 && IsBlocked == false)
            {
                if (AvaibleFounds > Math.Round(amount, PRECISION))
                {
                    if (Balance < Math.Round(amount, PRECISION))
                    {
                        decimal wartoscWyplaty = Balance;
                        base.Withdrawal(Math.Round(Balance, PRECISION));
                        amount -= Math.Round(wartoscWyplaty, PRECISION);
                        _limit -= Math.Round(amount, PRECISION);
                        base.Block();
                    }
                    else
                    {
                        base.Withdrawal(Math.Round(amount, PRECISION));
                        return true;
                    }
                }
            }
            return false;
        }

        public decimal AvaibleFounds => OneTimeDebetLimit + Balance;

        public override string ToString()
        {
            if (IsBlocked)
            {
                return $"Account name: {Name}, balance: {Balance:F2}, blocked, avaible founds: {AvaibleFounds:F2}, limit: {StdLimit:F2}";
            }
            else
                return $"Account name: {Name}, balance: {Balance:F2}, avaible founds: {AvaibleFounds:F2}, limit: {StdLimit:F2}";
        }
    }
}