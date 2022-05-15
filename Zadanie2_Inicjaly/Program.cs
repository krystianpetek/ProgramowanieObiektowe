string napis = "Krzysztof Molenda, Jan Kowalski,  Anna    Abacka, Józef Kabacki, Kazimierz Moksa,  Alfred Alacki";

Console.WriteLine("Standard");
string[] splitted = napis.Trim().Split(",",StringSplitOptions.RemoveEmptyEntries);
List<Tuple<string, string>> lista = new List<Tuple<string, string>>();
for (int i = 0; i < splitted.Length; i++)
{
    var g = splitted[i].Trim().Split(" ",StringSplitOptions.RemoveEmptyEntries);
    lista.Add(new Tuple<string,string>(g[0][0].ToString(),g[1][0].ToString()));
};
lista.Sort((x, y) => string.Compare(x.Item1 + x.Item2, y.Item1 + y.Item2));

Dictionary<string,int> dic = new Dictionary<string,int>();
for (int i = 0; i < lista.Count; i++)
{
    var key = lista[i].Item1 + lista[i].Item2;
    if (dic.ContainsKey(key))
        dic[key]++;
    else
        dic.Add(key,1);
}

foreach (var VARIABLE in dic)
{
    if(VARIABLE.Value > 1)
        Console.WriteLine(VARIABLE.Key);
}

// LINQ flow
var queryFlow = napis.Split(",", StringSplitOptions.RemoveEmptyEntries)
    .Select(osoba => osoba.Split(" ", StringSplitOptions.RemoveEmptyEntries))
    .Select(osoba => new { imie = osoba[0], nazwisko = osoba[1] })
    .OrderBy(osoba => osoba.imie)
    .ThenBy(osoba => osoba.nazwisko)
    .Select(osoba => osoba.imie[0] + "" + osoba.nazwisko[0])
    .GroupBy(osoba => osoba)
    .Where(osoba => osoba.Count() > 1)
    .ToList();

Console.WriteLine("LINQ: flow");
queryFlow.ForEach(osoba => Console.WriteLine(osoba.Key));
    
// linq query
var queryQuery = from osoba in splitted
    let osoba2 = osoba.Split(" ", StringSplitOptions.RemoveEmptyEntries)
    let imie = osoba2[0][0]
    let nazwisko = osoba2[1][0]
    let inicjaly = imie + "" + nazwisko
    orderby inicjaly
    group osoba.Count() by inicjaly
    into newGroup
                 where newGroup.Count() > 1
    select newGroup.Key;

Console.WriteLine("LINQ: queryNotation");
foreach (var item in queryQuery)
    Console.WriteLine(item);

public static class Classa
{
    public static string SayHello(this string s)
    {
        return $"Hello,{s}";
    }
    public static void Main()
    {
        string krystian = "Krystian";
        krystian.SayHello();
    }
}