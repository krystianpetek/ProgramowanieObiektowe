// See https://aka.ms/new-console-template for more information
using RationalLibrary;

Console.WriteLine(default(BigRational));
Console.WriteLine(new BigRational());
Console.WriteLine(new BigRational(2, -4));

var u = BigRational.Parse("3/-4");
Console.WriteLine(u);