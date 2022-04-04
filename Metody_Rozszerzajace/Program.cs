using Metody_Rozszerzajace;

string napis = "Ala ma kota, as to Ali pies";
Console.WriteLine(Utility.WordCount(napis));

Console.WriteLine(Utility.WordCount(napis,' ','\t',',','.','!','?','`'));

Console.WriteLine(napis.WordCountExtended());

Console.WriteLine(napis.WordCountExtended( delimiters: new char[] {' ',',','\t',',','.','!','?'} ));
Console.WriteLine(napis.WordCountExtended(' ', ',', '\t', ',', '.', '!', '?'));