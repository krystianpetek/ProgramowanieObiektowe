using System;

namespace _28_kontoWBanku_2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // tworzenie konta, zmiana limitu
            // utworzenie konta plus z domyslnym limitem 100
            var john = new AccountPlus("John");
            Console.WriteLine(john);

            // utworzenie konta plus z ustawionym limitem na 200 i bilansem początkowym 99
            var eve = new AccountPlus("Eve", initialLimit: 200.0m, initialBalance: 99.0m);
            Console.WriteLine(eve);

            // zmiana limitu, konto nie zablokowane
            eve.OneTimeDebetLimit = 120.0m;
            Console.WriteLine(eve);

            // próba zmiany limitu, konto zablokowane
            eve.Block();
            eve.OneTimeDebetLimit = 500.0m;
            Console.WriteLine(eve);

            // próba utworzenia konta z limitem ujemnym
            var stan = new AccountPlus(name: "Stan", initialLimit: -200.0m);
            Console.WriteLine(stan);

            Console.WriteLine("\n\n\n");

            // scenariusz: wpłaty wypłaty, blokada konta
            // utworzenie konta plus z domyslnym limitem 100
            john = new AccountPlus("John", initialBalance: 100.0m);
            Console.WriteLine(john);

            // wypłata - podanie kwoty ujemnej
            john.Withdrawal(-50.0m);
            Console.WriteLine(john);

            // wypłata bez wykorzystania debetu
            john.Withdrawal(50.0m);
            Console.WriteLine(john);

            // wypłata z wykorzystaniem debetu
            john.Withdrawal(100.0m);
            Console.WriteLine(john);

            // konto zablokowane, wypłata niemożliwa
            john.Withdrawal(10.0m);
            Console.WriteLine(john);

            // wpłata odblokowująca konto
            john.Deposit(80.0m);
            Console.WriteLine(john);

            // wpłata podanie kwoty ujemnej
            john.Deposit(-80.0m);
            Console.WriteLine(john);

            Console.WriteLine("\n\n\n");

            // sytuacje specjalne
            // konto z zerowym stanem
            var account = new AccountPlus("John", initialBalance: 0, initialLimit: 0);
            Console.WriteLine(account);
            account.Withdrawal(10);
            Console.WriteLine(account);

            // zerowe saldo, limit 50
            account.OneTimeDebetLimit = 50;
            Console.WriteLine(account);
            account.Withdrawal(0); // zerowa wypłata
            Console.WriteLine(account);
            account.Withdrawal(10); // wypłata w ramach debetu
            Console.WriteLine(account);
            account.Unblock(); // próba odblokowania konta
            Console.WriteLine(account);
            account.Deposit(10); // likwidacja debetu, zerowy bilans
            Console.WriteLine(account);
        }
    }
}