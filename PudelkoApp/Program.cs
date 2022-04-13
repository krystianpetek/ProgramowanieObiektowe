using PudelkoLib;
//using P = PudelkoLib.Pudelko;
Console.OutputEncoding = System.Text.Encoding.UTF8;
Pudelko x = new Pudelko(2.5, 9.321, 0.1);

Pudelko p1 = new Pudelko(1, 2.1, 3.05);
Pudelko p11 = new Pudelko(1, 2.1, 3.05);
Pudelko p2 = new Pudelko(1, 3.05, 2.1);
Pudelko p3 = new Pudelko(2.1, 1, 3.05);
Pudelko p4 = new Pudelko(2100, 1000, 3050, Pudelko.UnitOfMeasure.milimeter);

Console.WriteLine(p1.Equals(p1));
Console.WriteLine(p1.Equals(p2));
Console.WriteLine(p1.Equals(p3));
Console.WriteLine(p1.Equals(p4));
Console.WriteLine(p2.Equals(p1));
Console.WriteLine(p2.Equals(p2));
Console.WriteLine(p2.Equals(p3));
Console.WriteLine(p2.Equals(p4));
Console.WriteLine(p3.Equals(p1));
Console.WriteLine(p3.Equals(p2));
Console.WriteLine(p3.Equals(p3));
Console.WriteLine(p3.Equals(p4));
Console.WriteLine(p4.Equals(p1));
Console.WriteLine(p4.Equals(p2));
Console.WriteLine(p4.Equals(p3));
Console.WriteLine(p4.Equals(p4));
Console.WriteLine(p1 != p3);

Console.WriteLine(p1.GetHashCode());
Console.WriteLine(p11.GetHashCode());
Console.WriteLine(p2.GetHashCode());
Console.WriteLine(p3.GetHashCode());
Console.WriteLine(p4.GetHashCode());

Pudelko zapalki = new Pudelko(20,15,10, Pudelko.UnitOfMeasure.centimeter);
Pudelko box304050 = new Pudelko(8.6, 5.5, 2.5, Pudelko.UnitOfMeasure.centimeter);

Console.WriteLine(zapalki.Volume);
Console.WriteLine(box304050.Volume);
Console.WriteLine((zapalki + box304050).Volume);
Console.WriteLine((zapalki + box304050));

ValueTuple<int, int, int> vt3 = new(2003, 5501, 221);
Pudelko v12 = vt3;
Console.WriteLine(v12);

Console.WriteLine(v12[2]);

Console.WriteLine();
foreach(double xe in v12)
{
    Console.WriteLine(xe);
}

var puds = Pudelko.Parse("2500 mm × 912 mm × 100 mm");

bool s = new Pudelko(2.5, 9.321, 0.1) == Pudelko.Parse("2.500 m × 9.321 m × 0.100 m");
Console.WriteLine(s);

var plytaGipsowa = new Pudelko(2.6, 1.2, 0.0125);
var pudelkoZChlebem = new Pudelko(0.2, 0.15, 0.1);

Console.WriteLine((plytaGipsowa + pudelkoZChlebem).Volume);

var ppp1 = new Pudelko(3.2,2.2, 0.43);
var ppp2 = new Pudelko(0.012, 1.5, 0.130);
var ppp3 = ppp1 + ppp2;
Console.WriteLine(ppp3.Volume);