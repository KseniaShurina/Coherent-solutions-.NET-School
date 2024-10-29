using Task2._1;

// Test Distance() method.
Point p1 = new Point(1, 2, 3, -1);
Point p2 = new Point(4, 5, 6, 8);
Console.WriteLine($"The distance between two points is {p1.Distance(p2)}");

// Test mass is 0 if someone tries to set negative value.
Console.WriteLine($"Mass of {nameof(p1)} is {p1.Mass}");

// Test IsZero() method.
Point p3 = new Point(0, 0, 0, -1);
Console.WriteLine($"Coordinates of {nameof(p3)} are zero? Answer: {p3.IsZero()}");
