using TempElementsLib;
using (TempFile tempFile = new TempFile())
{
    tempFile.AddText("333");
    tempFile.Dispose();
}

using (TempTextFile tempTextFile = new TempTextFile())
{
    tempTextFile.Write("krystian");
    tempTextFile.WriteLine("");
    tempTextFile.Write("Petek");
    tempTextFile.WriteLine("");
    tempTextFile.WriteLine("Krystian Petek");

    var temp =  tempTextFile.ReadAllText();
    Console.WriteLine(temp);

    Console.WriteLine(tempTextFile.ReadLine());
    Console.WriteLine(tempTextFile.ReadLine());
    Console.WriteLine(tempTextFile.ReadLine());
    Console.WriteLine(tempTextFile.ReadLine());
}

using (TempDir tempDir = new TempDir())
{
    Console.WriteLine(tempDir.DirPath);
}

TempElementsList tempElements = new TempElementsList();
tempElements.AddElement<TempDir>();

