using Task51;

SparseMatrix m2 = new SparseMatrix(10, 10);
m2[0, 0] = 1;
m2[0, 9] = 2;
m2[9, 0] = 3;
m2[9, 9] = 4;

Console.WriteLine(m2);
Console.WriteLine();

// GetNonZeroElements
Console.WriteLine("Method GetNonZeroElements: ");
foreach (var item in m2.GetNonZeroElements())
{
    Console.Write($"{item} "); // (0, 0, 1) (9, 0, 3) (0, 9, 2) (9, 9, 4)
}
Console.WriteLine();
Console.WriteLine();

// GetCount
Console.WriteLine("Method GetCount");
Console.WriteLine($"How many times element 1 appears in the matrix - {m2.GetCount(1)}"); // 1
Console.WriteLine($"How many times element 0 appears in the matrix - {m2.GetCount(0)}"); // 96
