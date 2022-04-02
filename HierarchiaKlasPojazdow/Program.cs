using HierarchiaKlasPojazdow.Enumy;
using HierarchiaKlasPojazdow.Pojazdy;

Samochod samochod = new Samochod(RodzajSilnika.LPG, 125);
samochod.ZwiekszPredkosc();
samochod.ZmniejszPredkosc();
samochod.ZmniejszPredkosc();
samochod.Stop();

Console.WriteLine(samochod.ToString());