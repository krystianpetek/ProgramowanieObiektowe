using System;

namespace _28_kontoWBanku_2
{
    internal class Account : IAccount
    {
        private readonly string _name;
        protected const int PRECISION = 4;

        public string Name
        {
            get { return _name; }
        }

        private decimal _amount;

        public decimal Balance
        {
            get { return Math.Round(_amount, PRECISION); }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException();
                _amount = Math.Round(value, PRECISION);
            }
        }

        public bool IsBlocked { get; set; }

        public void Block()
        {
            IsBlocked = true;
        }

        public virtual bool Deposit(decimal amount)
        {
            if (amount > 0 && IsBlocked == false)
            {
                Balance += Math.Round(amount, PRECISION);
                return true;
            }
            return false;
        }

        public void Unblock()
        {
            IsBlocked = false;
        }

        public virtual bool Withdrawal(decimal amount)
        {
            if (amount > 0 && IsBlocked == false)
            {
                if (Balance >= Math.Round(amount, PRECISION))
                {
                    Balance -= Math.Round(amount, PRECISION);
                    return true;
                }
            }
            return false;
        }

        public Account(string nazwaKonta, decimal saldo = 0)
        {
            if (nazwaKonta == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            nazwaKonta = nazwaKonta.Trim();
            if (nazwaKonta.Length < 3)
                throw new ArgumentException("Name is to short");
            else
                _name = nazwaKonta;

            Balance = Math.Round(saldo, PRECISION);
            IsBlocked = false;
        }

        public override string ToString()
        {
            if (IsBlocked)
                return $"Account name: {Name}, balance: {Balance:F2}, blocked";
            else
                return $"Account name: {Name}, balance: {Balance:F2}";
        }
    }
}