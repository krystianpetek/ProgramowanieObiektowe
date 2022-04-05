using ImplementacjaInterfejsow;

// zadanie 1
Pracownik pracownik = new Pracownik("Petek", new DateTime(2019, 08, 01),2800);
Console.WriteLine(pracownik.CzasZatrudnienia);
Console.WriteLine(pracownik.ToString());
Pracownik pracownik2 = new Pracownik("Petek", new DateTime(2019, 08, 01), 2800);
Console.WriteLine($"{"Equals:",-10}{pracownik.Equals(pracownik2)}");
Console.WriteLine($"{"==:",-10}{pracownik == pracownik2}");
Console.WriteLine($"{"!=:",-10}{pracownik != pracownik2}");
Console.WriteLine($"{"HashCode p1: ",-15}{pracownik.GetHashCode()}");
Console.WriteLine($"{"HashCode p2: ",-15}{pracownik2.GetHashCode()}");
Console.WriteLine($"{"Equals Hash: ",-15}{pracownik.GetHashCode() == pracownik2.GetHashCode()}");
Console.WriteLine(Pracownik.Equals(pracownik, pracownik2));

// zadanie 2
Pracownik pracownik01 = new Pracownik("Warchał", new DateTime(2020, 01, 05), 3000);
Pracownik pracownik02 = new Pracownik("Warchał", new DateTime(2018, 10, 02), 3100);
Pracownik pracownik03 = new Pracownik("Petek", new DateTime(2020, 01, 05), 3200);
Pracownik pracownik04 = new Pracownik("Merek", new DateTime(2012, 12, 12), 2300);
Pracownik pracownik05 = new Pracownik("Porębski", new DateTime(2014, 02, 04), 3200);
List<Pracownik> listaPracownikow = new List<Pracownik>()
{
    pracownik01,
    pracownik02,
    pracownik03,
    pracownik04,
    pracownik05
};
foreach(Pracownik employee in listaPracownikow)
    Console.WriteLine(employee);

listaPracownikow.Sort();
Console.WriteLine();
foreach (Pracownik employee in listaPracownikow)
    Console.WriteLine(employee);

WgCzasuZatrudnieniaPotemWgWynagrodzeniaComparer porownywacz = new();
listaPracownikow.Sort(porownywacz);
foreach (Pracownik employee in listaPracownikow)
    Console.WriteLine(employee);

