// Test Distance() method.
Point p1 = new Point(1, 2, 3, -1);
Point p2 = new Point(4, 5, 6, 8);
Console.WriteLine($"The distance between two points is {p1.Distance(p2)}");

// Test mass is 0 if someone tries to set negative value.
Console.WriteLine($"Mass of {nameof(p1)} is {p1.Mass}");

// Test IsZero() method.
Point p3 = new Point(0, 0, 0, -1);
Console.WriteLine($"Coordinates of {nameof(p3)} are zero? Answer: {p3.IsZero()}");

public class Point
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }
    public double Mass { get; set; }

    private readonly int[] _coordinates = new int[3];

    public Point(int x, int y, int z, double mass)
    {
        X = x;
        Y = y;
        Z = z;
        Mass = mass < 0 ? 0 : mass;

        // Set array of coordinates.
        _coordinates[0] = x;
        _coordinates[1] = y;
        _coordinates[2] = z;
    }

    // Returns true if all coordinates of the point are 0.
    public bool IsZero()
    {
        if (X == 0 && Y == 0 && Z == 0)
        {
            return true;
        }
        return false;
    }

    // Return the distance between the current point and the parameter point.
    public double Distance(Point point)
    {
        double result = Math.Sqrt(Math.Pow((X - point.X), 2) + Math.Pow((Y - point.Y), 2) + Math.Pow((Z - point.Z), 2));
        return result;
    }
}