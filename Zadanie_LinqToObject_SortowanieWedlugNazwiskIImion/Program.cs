using Zadanie_LinqToObject_SortowanieWedlugNazwiskIImion;

// rozwiazanie naiwne bez linq
string s = "Krzysztof Molenda,  Jan Kowalski, Anna Abacka , Józef Kabacki, Kazimierz Moksa";
string[] osoby = s.Split(',');
for (int i = 0; i < osoby.Length; i++)
    osoby[i] = osoby[i].Trim();

foreach (var osoba in osoby)
    Console.WriteLine(osoba);



var listaOsob = new List<Osoba>();

osoby = s.Split(',');
for (int i = 0; i < osoby.Length; i++)
{
    osoby[i] = osoby[i].Trim();
    string[] temp = osoby[i].Split(' ');
    Osoba o = new Osoba();
    o.Imie = temp[0];
    o.Nazwisko = temp[1];
    listaOsob.Add(o);
}
Console.WriteLine();
foreach (var osoba in listaOsob)
    Console.WriteLine(osoba);



listaOsob.Sort((o1, o2) => String.Compare(o1.Nazwisko + o1.Imie, o2.Nazwisko + o2.Imie));

string wynik = "";
foreach (var x in listaOsob)
    wynik += x.Imie + " " + x.Nazwisko + ", ";
Console.WriteLine();
Console.WriteLine(wynik);


// rozwiazanie naiwne Tuple
var listaOsobTuple = new List<Tuple<string,string>>();
osoby = s.Split(",");
for (int i = 0; i < osoby.Length; i++)
{
    osoby[i] = osoby[i].Trim();
    string[] temp = osoby[i].Split(" ");
    var o = new Tuple<string, string>(temp[0], temp[1]);
    listaOsobTuple.Add(o);
}
listaOsobTuple.Sort((o1,o2) => String.Compare(o1.Item2+o1.Item1, o2.Item2+o2.Item1));
Console.WriteLine();
wynik = string.Join(", ",listaOsobTuple);
Console.WriteLine(wynik);

// rozwiazanie typy i obiekty anonimowe
var osobaExample = new {imie="Krystian",nazwisko="Petek"};
var listaOsobAnonimowa = new[] {osobaExample}.ToList();
listaOsobAnonimowa.RemoveAt(0);
for (int i = 0; i < osoby.Length; i++)
{
    string[] temp = osoby[i].Split(" ");
    var o = new { imie = temp[0], nazwisko = temp[1] };
    listaOsobAnonimowa.Add(o);
}
listaOsobAnonimowa.Sort((o1,o2)=> string.Compare(o1.nazwisko + o1.imie, o2.nazwisko+o2.imie));
wynik = string.Join(", ",listaOsobAnonimowa);
Console.WriteLine();
foreach(var o in listaOsobAnonimowa)
    Console.WriteLine(o);

// LINQ
Console.WriteLine("\nLINQ");
Console.OutputEncoding = System.Text.Encoding.UTF8;
string sLinq = "Krzysztof Molenda,  Jan Kowalski, Anna Abacka , Józef Kabacki, Kazimierz Moksa";
var query1 = sLinq.Split(",");
var query2 = query1.Select(osoba => osoba.Trim());
Console.Write("\nquery2: ");
query2.ToList().ForEach( q=>
{
    Console.Write(q + ", ");
});
var query3 = query2
    .Select(q => q.Split(" "))
    .Select(q=> (imie: q[0], nazwisko: q[1] ));

Console.Write("\nquery3: ");
query3.ToList().ForEach(q =>
{
    Console.Write($"({q.imie}, {q.nazwisko}),");
});

var query4 = query2
    .Select(q => q.Split(" "))
    .Select(q=> new {imie=q[0],nazwisko=q[1]} );

Console.Write("\nquery4: ");
query4.ToList().ForEach(q =>
{
    Console.Write($"({q.imie}, {q.nazwisko}),");
});

var query5 = query3.OrderBy(o=>o.nazwisko).ThenBy(o=>o.imie);
Console.Write("\nquery5: ");
query5.ToList().ForEach(q =>
{
    Console.Write($"({q.imie}, {q.nazwisko}),");
});

var query6 = query5.Select(o=>o.imie + " " + o.nazwisko);
Console.Write("\nquery6: ");
query6.ToList().ForEach(q =>
{
    Console.Write(q + ", ");
});

Console.Write("\nwynik: ");
wynik = string.Join(", ", query6);
Console.WriteLine(wynik);

// LINQ notacja flow, jedna kwerenda
Console.WriteLine("\nLINQ notacja flow");
string sFlow = "Krzysztof Molenda,  Jan Kowalski, Anna Abacka , Józef Kabacki, Kazimierz Moksa";
var queryFlow = sFlow
    .Split(",")
    .Select( osoba => osoba.Trim() )
    .Select( osoba => osoba.Split(" "))
    .Select( osoba=> (imie: osoba[0], nazwisko: osoba[1] ) )
    .OrderBy( osoba => osoba.nazwisko)
    .ThenBy( osoba => osoba.nazwisko)
    .Select( osoba => osoba.imie + " " + osoba.nazwisko);

string wynikFlow = string.Join(", ",queryFlow);
Console.WriteLine(wynikFlow);

// LINQ notacja query
Console.WriteLine("\nLINQ notacja query");
string sQuery = "Krzysztof Molenda,  Jan Kowalski, Anna Abacka , Józef Kabacki, Kazimierz Moksa";
var queryQuery = sQuery.Split(',')
    .Select(x => x.Trim())
    .Select(x => x.Split(' '));

var queryQuery1 = from osoba in queryQuery
    let imie = osoba[0]
    let nazwisko = osoba[1]
    orderby nazwisko, imie
    select new { imie, nazwisko };

string wynikQuery = string.Join(", ",queryQuery1.Select( osoba => osoba.imie + " "+ osoba.nazwisko));
Console.WriteLine(wynikQuery);

