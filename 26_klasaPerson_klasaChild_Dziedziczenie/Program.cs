using System;

namespace _26_klasaPerson_klasaChild_Dziedziczenie
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            /* Test: poprawne tworzenie obiektu Person,
   błędne imię lub nazwisko, spacje w środku*/
            try
            {
                Person p = new Person(familyName: "Molen  da", firstName: "Krzysztof", age: 18);
                Console.WriteLine(p);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}