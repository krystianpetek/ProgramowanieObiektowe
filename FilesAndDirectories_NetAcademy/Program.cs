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


File.WriteAllText(@".\Movies.txt", "Star Wars\nThe Empire Strikes Back\nReturn Of The Jedi\n");

using (var file = new FileStream(@".\Movies.txt", FileMode.Open))
{
    using (var reader = new StreamReader(file))
    {
        while (!reader.EndOfStream)
        {
            string movie = reader.ReadLine();
            Console.WriteLine(movie);
        }
    }
}

using (var file = new FileStream(@".\Actors.txt", FileMode.Create))
{
    using (var writer = new StreamWriter(file))
    {
        foreach (string actor in actors)
        {
            writer.WriteLine(actor);
        }
    }
}


actors = new List<string>()
        {
            "Mark Hamill",
            "Harrison Ford",
            "Carrie Fisher"
        };

using (var file = new FileStream(@".\Actors.txt", FileMode.Create))
{
    using (StreamWriter writer = new StreamWriter(file))
    {
        foreach (string actor in actors)
        {
            writer.WriteLine(actor);
        }
    }
}


Console.WriteLine("\nUtility types - file info");
// utility types
const string DirectoryPath = @".\";
const string FilePath = @".\HelloWorld.txt";

Directory.CreateDirectory(Path.Combine(DirectoryPath, "sub-dir"));
Directory.CreateDirectory(Path.Combine(DirectoryPath, "sub-dir2"));

File.WriteAllText(FilePath, "Hello world!");

FileInfo fileInfo = new FileInfo(FilePath);
Console.WriteLine(fileInfo.Exists);
Console.WriteLine(fileInfo.Name);
Console.WriteLine(fileInfo.LastWriteTime);

string directoryPath = Path.GetDirectoryName(FilePath);
DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
Console.WriteLine(directoryInfo.Exists);
Console.WriteLine(directoryInfo.LastWriteTime);

foreach( string childDirectory in Directory.GetDirectories(directoryPath,"*",SearchOption.AllDirectories))
    Console.WriteLine(childDirectory);

// operacje z plikami

Console.WriteLine("\n");
FileInfo fileinfo2 = new FileInfo(@"C:\Windows\Notepad.exe");
fileinfo2 = new FileInfo(@"C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe");
if(fileinfo2.Exists)
    Console.WriteLine($"The file {fileinfo2.Name} exists on disk, and was last accessed on {fileinfo2.LastAccessTime}");

//fileinfo2.CopyTo($"C:\\Users\\kryst\\Desktop\\powershell.exe");


// directory
string directory = @"C:\Windows";
if (Directory.Exists(directory))
{
    Console.WriteLine("The directory {0} exists", directory);
}
foreach (string childDirectory in Directory.GetDirectories(directory))
    Console.WriteLine(childDirectory);


// PATH
Console.WriteLine("\nPath");
string filePath = $@"c:\windows\notepad.exe";
string fileDirectory = Path.GetDirectoryName(filePath);
string fileName = Path.GetFileName(filePath);
Console.WriteLine($"filePath: {filePath}");
Console.WriteLine($"fileDirectory: {fileDirectory}");
Console.WriteLine($"fileName: {fileName}");

string path = Path.Combine("C:", "Windows", "Notepad.exe");
Console.WriteLine(path);


Directory.CreateDirectory(@".\sub-dir1");
Directory.CreateDirectory(@".\sub-dir2");
Directory.CreateDirectory(@".\sub-dir3");

DirectoryInfo directory2 = new DirectoryInfo(@".\");
var children = directory2.GetDirectories();

foreach (var item in children)
{
    Console.WriteLine(item);
}