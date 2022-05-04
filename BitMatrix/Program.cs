using BitMatrixImplementation;

var m = new BitMatrix(4, 3);
Console.WriteLine(m.ToString());

m = new BitMatrix(3, 4, 1);
Console.WriteLine(m);

// konstruktor BitMatrix(int, int, params int[])
// macierz 2x2, komplet danych w tablicy
m = new BitMatrix(2, 2, new int[] { 1, 0, 0, 1 });
Console.WriteLine(m);

m = new BitMatrix(2, 2, 1, 0, 0, 0);
Console.WriteLine(m);

// konstruktor BitMatrix(int, int, params int[])
// macierz 2x2, za dużo danych w tablicy
m = new BitMatrix(2, 2, 1, 0, 0, 1, 1, 1, 0);
Console.WriteLine(m);

// macierz 3x2, za mało danych w tablicy
m = new BitMatrix(3, 2, 1, 0, 0, 1, 1);
Console.WriteLine(m);


// konstruktor BitMatrix(int[,])
int[,] arr = new int[,] { { 1, 0, 1 }, { 0, 1, 1 } };
m = new BitMatrix(arr);
Console.WriteLine(arr.GetLength(0) == m.NumberOfRows);
Console.WriteLine(arr.GetLength(1) == m.NumberOfColumns);
Console.Write(m.ToString());




// konstruktor BitMatrix(int, int, params int[])
// macierz 2x2, tablica null
m = new BitMatrix(2, 2, null);
Console.WriteLine(m);

// macierz 4x3, tablica zerowej długości
m = new BitMatrix(4, 3, new int[0]);
Console.WriteLine(m);




// `Equals` różne wartości komórek
var m1 = new BitMatrix(2, 3, 1, 1, 1, 0, 0, 0);
var m2 = new BitMatrix(2, 3, 0, 0, 0, 1, 1, 1);
Console.WriteLine(m1.Equals(m2));
m1 = new BitMatrix(1, 1, 0);
m2 = new BitMatrix(1, 1, 1);
Console.WriteLine(m1.Equals(m2));


// `Equals` te same wartości
m1 = new BitMatrix(2, 3, 1, 1, 1, 0, 0, 0);
m2 = new BitMatrix(2, 3, 1, 1, 1, 0, 0, 0);
Console.WriteLine(m1.Equals(m2));
m1 = new BitMatrix(1, 1, 0);
m2 = new BitMatrix(1, 1, 0);
Console.WriteLine(m1.Equals(m2));


// operator `==`, `!=`
// zgodne wartości
m1 = new BitMatrix(2, 3, 1, 1, 1, 0, 0, 0);
m2 = new BitMatrix(2, 3, 1, 1, 1, 0, 0, 0);
Console.WriteLine(m1 != m2);
Console.WriteLine(m1 == m2);
Console.WriteLine(m2 != m1);
Console.WriteLine(m2 == m1);

m1 = new BitMatrix(1, 1, 1);
m2 = new BitMatrix(1, 1, 1);
Console.WriteLine(m1 == m2);
Console.WriteLine(m1 != m2);



// Equals dla parametru `null`
m1 = new BitMatrix(1, 1);
Console.WriteLine(m1.Equals(null));




// `Equals(object)` dla innego typu
m1 = new BitMatrix(1, 1);
double[,] temp = new double[1, 1];
Console.WriteLine(m1.Equals(temp));




// operator `==`, `!=`
// dwa `null`
m1 = null;
m2 = null;
Console.WriteLine(m1 == m2);
Console.WriteLine(m1 != m2);
//BitMatrix matrix = new BitMatrix(4);
//Console.WriteLine(matrix);

//var x = matrix[1, 2];

//matrix[1, 2] = true;

//Console.WriteLine(matrix);

//foreach(var index in matrix)
//{

//}
