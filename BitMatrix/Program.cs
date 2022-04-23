using BitMatrixImplementation;

BitMatrix matrix = new BitMatrix(4);
Console.WriteLine(matrix);

var x = matrix[1, 2];

matrix[1, 2] = true;

Console.WriteLine(matrix);

foreach(var index in matrix)
{

}