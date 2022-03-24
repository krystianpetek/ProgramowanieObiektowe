namespace _27_kontoWBanku_1
{
    internal interface IAccount
    {
        string Name { get; } // nazwa klienta, bez spacji przed i po, readonly - modyfikowalna wyłącznie w konstruktorze
        decimal Balance { get; } // bilans, aktualny stan środków, podawany w zaokrągleniu do 2 miejsc po przecinku
        bool IsBlocked { get; } // czy konto jest zablokowane

        void Block(); // zablokuj konto

        void Unblock(); // odblokuj konto

        /// <summary>
        /// wpłata, dla kwoty ujemnej - zignorowana (false),
        /// jeśli konto zablokowane - zignorowana (false),
        /// true jeśli wykonano i nastąpiła zmiana salda
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        bool Deposit(decimal amount);

        /// <summary>
        /// wypłata, dla kwoty ujemnej - zignorowana (false),
        /// jeśli konto zablokowane - zignorowana (false),
        /// jeśli jest niewystarczająca ilość środków - zignorowana (false),
        /// true jeśli wykonano i nastąpiła zmiana salda
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        bool Withdrawal(decimal amount);
    }
}