using System;
using System.IO;

// Files
string pathToFile = $".\\hello.txt";
string message = "Hello World!";
File.WriteAllText(pathToFile, message);

string content = File.ReadAllText(pathToFile);
Console.WriteLine(content);

File.Delete(pathToFile);

// Directories
foreach (string file in Directory.GetFiles(".\\"))
{
    Console.WriteLine(file);
}

Directory.CreateDirectory(@".\folder");
Directory.CreateDirectory(@".\path\to\folder");
Directory.Delete(@".\path\to\", true);

string[] files = Directory.GetFiles(@".\folder","*.jpg",SearchOption.TopDirectoryOnly);
Console.WriteLine();
for (int i = 0; i < files.Length; i++)
    Console.WriteLine(files[i]);

Directory.CreateDirectory(@".\Droids");
File.WriteAllText(@".\Droids\R2D2.txt", "beep bop");
Directory.Delete(@".\Droids", true);

// Enumerate files in a directory
Directory.CreateDirectory(@".\Droids\Astromech");
Directory.CreateDirectory(@".\Droids\Protocol");
File.WriteAllText(@".\Droids\Astromech\R2D2.txt", "beep bop");
File.WriteAllText(@".\Droids\Protocol\C3P0.txt", "sir!");

files = Directory.GetFiles(@".\Droids", "*.txt", SearchOption.AllDirectories);
foreach (string file in files)
{
    Console.WriteLine(file);
}

// using streams
Console.WriteLine("\nUsing streams");
using (var writer = new StreamWriter(new FileStream(@".\StarWars.txt", FileMode.Create)))
{
    writer.Write("Beep bop!");
    //writer.Close();
}

using (var reader = new StreamReader( new FileStream(@".\StarWars.txt", FileMode.Open)))
{
    Console.WriteLine(reader.ReadToEnd());

    //reader.Close();
}


using( var writer = new StreamWriter(new FileStream(@".\newFile.txt.",FileMode.Create)))
{
    writer.WriteLine("Krystian");
    writer.WriteLine("Petek");
    writer.WriteLine("Lat: 23");
}

using(var reader = new StreamReader(new FileStream(@".\newFile.txt",FileMode.Open)))
{
    while(!reader.EndOfStream)
    {
        string line = reader.ReadLine();
        Console.WriteLine(line);
    };
}

File.WriteAllText(@".\Movies.txt", "Star Wars\nThe Empire Strikes Back\nReturn Of The Jedi\n");
FileStream fileStream10 = new FileStream(@".\Movies.txt", FileMode.Open);
StreamReader streamReader10 = new StreamReader(fileStream10);

Console.WriteLine();
while(!streamReader10.EndOfStream)
{
    string movie = streamReader10.ReadLine();
    Console.WriteLine(movie);
}
streamReader10.Close();

// actors
Console.WriteLine("\nActors");
List<string> actors = new List<string>()
        {
            "Mark Hamill",
            "Harrison Ford",
            "Carrie Fisher"
        };
using(var fileStream = new FileStream($".\\Actors.txt",FileMode.Create))
{
    StreamWriter writer = new StreamWriter(fileStream);

    foreach(var actor in actors)
    writer.WriteLine(actor);

    writer.Close();
}


// https://dotnetcademy.net/Learn/2050/Pages/13