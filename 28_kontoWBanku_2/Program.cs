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
        }
    }
}