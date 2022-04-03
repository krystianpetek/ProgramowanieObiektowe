using HierarchiaKlasPojazdow.Enumy;
using HierarchiaKlasPojazdow.Pojazdy;
using HierarchiaKlasPojazdow.RodzajPojazdu;

Amfibia amfibia = new Amfibia(100, 6, 3200);
DeskaElektryczna deskaElektryczna = new DeskaElektryczna(8);
Helikopter helikopter = new Helikopter(2100);
Hulajnoga hulajnoga = new Hulajnoga();
Kajak kajak = new Kajak(110);
LodzPodwodna lodzPodwodna = new LodzPodwodna(6970, 26500);
Lotnia lotnia = new Lotnia();
Motocykl motocykl = new Motocykl(RodzajSilnika.Benzyna, 150);
Motorowka motorowka = new Motorowka(50, 1500);
Poduszkowiec poduszkowiec = new Poduszkowiec(RodzajSilnika.Benzyna, 120, 1670);
Rower rower = new Rower();
Samochod samochod = new Samochod(RodzajSilnika.Hybrydowy, 240);
Samolot samolot = new Samolot(5000);
Statek statek = new Statek(43151, 78400);
Szybowiec szybowiec = new Szybowiec();
Symulacja();
List<Pojazd> listaPojazdow = new List<Pojazd>() { amfibia, deskaElektryczna, helikopter, hulajnoga, kajak, lodzPodwodna, lotnia, motocykl, motorowka, poduszkowiec, rower, samochod, samolot, statek, szybowiec };

while (true)
{
    Console.Clear();
    Console.WriteLine("Wybierz jedną z opcji od 1 do 4");
    Console.WriteLine("1. Lista pojazdow w kolejnosci oryginalnej");
    Console.WriteLine("2. Lista pojazdów lądowych");
    Console.WriteLine("3. Lista posortowana rosnąco ze względu na aktualną szybkość poruszania się");
    Console.WriteLine("4. Lista pojazdów poruszających się aktualnie w środowisku lądowym, od aktualnie najszybciej poruszającego się do najwolniejszego");
    var key = Console.ReadKey().Key;
    Console.WriteLine();

    switch (key)
    {
        case ConsoleKey.NumPad1:
        case ConsoleKey.D1:
            OryginalnaListaWKolejnosciDodawania();
            break;
        case ConsoleKey.NumPad2:
        case ConsoleKey.D2:
            ListaPojazdowLadowych();
            break;
        case ConsoleKey.NumPad3:
        case ConsoleKey.D3:
            ListaRosnacoNaPodstawiePredkosci();
            break;
        case ConsoleKey.NumPad4:
        case ConsoleKey.D4:
            ListaLadowaPredkoscPosortowanaMalejaco();
            break;
        default:
            Console.WriteLine("\nZły wybór, koniec programu");
            return;
    }
    Console.ReadKey();
}

void Symulacja()
{
    Console.WriteLine(amfibia.GetType().Name);
    amfibia.Start();
    amfibia.ZmienSrodowisko();
    amfibia.ZwiekszPredkosc(3);
    amfibia.Stop();
    amfibia.ZmienSrodowisko();
    amfibia.ZwiekszPredkosc();
    amfibia.ZmienSrodowisko();
    amfibia.Start();
    amfibia.Stop();

    Console.WriteLine("\n" + deskaElektryczna.GetType().Name);
    deskaElektryczna.ZwiekszPredkosc();
    deskaElektryczna.Start();
    deskaElektryczna.ZwiekszPredkosc();
    deskaElektryczna.ZwiekszPredkosc();

    Console.WriteLine("\n" + helikopter.GetType().Name);
    helikopter.Start();
    helikopter.ZwiekszPredkosc();
    Console.WriteLine(helikopter);
    helikopter.ZmniejszPredkosc();
    helikopter.ZmienSrodowisko();
    helikopter.ZwiekszPredkosc(4);
    helikopter.Stop();

    Console.WriteLine("\n" + kajak.GetType().Name);
    kajak.Stop();
    kajak.Start();
    kajak.ZwiekszPredkosc(2);
    Console.WriteLine(kajak);

    Console.WriteLine("\n" + lodzPodwodna.GetType().Name);
    lodzPodwodna.Start();
    lodzPodwodna.ZwiekszPredkosc();
    lodzPodwodna.ZwiekszPredkosc(5);
    lodzPodwodna.Stop();
    lodzPodwodna.ZwiekszPredkosc(3);
    lodzPodwodna.Stop();
    lodzPodwodna.ZmienSrodowisko();
    lodzPodwodna.ZwiekszPredkosc(2);
    lodzPodwodna.ZmienSrodowisko();

    Console.WriteLine("\n" + samochod.GetType().Name);
    samochod.Start();
    samochod.ZwiekszPredkosc(6);
    samochod.ZwiekszPredkosc();
    samochod.ZwiekszPredkosc();
    samochod.ZwiekszPredkosc();
    Console.WriteLine(samochod);
    samochod.ZwiekszPredkosc();
    samochod.ZwiekszPredkosc();
    samochod.ZwiekszPredkosc();
    samochod.ZwiekszPredkosc();
    samochod.ZmienSrodowisko();
    samochod.ZmniejszPredkosc();
    samochod.ZmniejszPredkosc();
    samochod.Start();
    Console.WriteLine(samochod);

    Console.WriteLine("\n" + samolot.GetType().Name);
    samolot.ZwiekszPredkosc();
    samolot.ZwiekszPredkosc(5);
    samolot.Stop();
    samolot.ZmienSrodowisko();
    samolot.ZmniejszPredkosc();
    samolot.ZmniejszPredkosc(5);
    samolot.ZmniejszPredkosc();
    samolot.Stop();
    samolot.ZwiekszPredkosc(3);
    samolot.ZwiekszPredkosc(5);
    Console.WriteLine(samolot);
}

void OryginalnaListaWKolejnosciDodawania()
{
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine("Lista pojazdow w kolejnosci oryginalnej");
    Console.ResetColor();
    foreach (Pojazd pojazd in listaPojazdow)
    {
        Console.WriteLine(pojazd.ToString());
    }
}

void ListaPojazdowLadowych()
{
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine("Lista pojazdów lądowych");
    Console.ResetColor();
    foreach (Pojazd pojazd in listaPojazdow)
    {
        if (pojazd is ILadowy ladowy && pojazd is not IWodny && pojazd is not IPowietrzny)
        {
            Console.WriteLine(ladowy);
        }
    }
}

void ListaRosnacoNaPodstawiePredkosci()
{
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine("Lista posortowana rosnąco ze względu na aktualną szybkość poruszania się");
    Console.ResetColor();
    //Comparison<Pojazd> porownywacz = new Comparison<Pojazd>((x,y) => x.Predkosc.CompareTo(y.Predkosc));
    Comparison<Pojazd> porownywacz = new Comparison<Pojazd>(Pojazd.PorownajDwaPojazdy);
    List<Pojazd> nowaListaPojazdow = new List<Pojazd>(listaPojazdow);
    nowaListaPojazdow.Sort(porownywacz);
    nowaListaPojazdow.Reverse();
    foreach (Pojazd pojazd in nowaListaPojazdow)
    {
        Console.Write(pojazd);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{"",-30}{pojazd.Predkosc} {pojazd.JednostkaPredkosci}");
        Console.ResetColor();
    }
}

void ListaLadowaPredkoscPosortowanaMalejaco()
{
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine("Lista pojazdów poruszających się aktualnie w środowisku lądowym, od aktualnie najszybciej poruszającego się do najwolniejszego.");
    Console.ResetColor();

    List<Pojazd> nowaListaPojazdow = new List<Pojazd>(listaPojazdow);
    nowaListaPojazdow.Sort((x, y) => x.Predkosc.CompareTo(y.Predkosc));
    foreach (Pojazd pojazd in nowaListaPojazdow)
    {
        if (pojazd.AktualneSrodowisko == Srodowisko.Ladowe)
        {
            Console.Write(pojazd);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{"",-30}{pojazd.Predkosc} {pojazd.JednostkaPredkosci} Srodowisko: {pojazd.AktualneSrodowisko}");
            Console.ResetColor();
        }
    }
}
