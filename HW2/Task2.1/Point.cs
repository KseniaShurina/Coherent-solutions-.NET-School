namespace Task2._1
{
    internal class Point
    {
        public int X
        {
            get => _coordinates[0];
            set => _coordinates[0] = value;
        }
        public int Y
        {
            get => _coordinates[1];
            set => _coordinates[1] = value;
        }
        public int Z
        {
            get => _coordinates[2];
            set => _coordinates[2] = value;
        }

        private double _mass;

        public double Mass
        {
            get => _mass;
            set => _mass = value < 0 ? 0 : value;
        }

        private readonly int[] _coordinates = new int[3];

        public Point(int x, int y, int z, double mass)
        {
            X = x;
            Y = y;
            Z = z;
            Mass = mass;
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
        public double Distance(Point? point)
        {
            if (point == null)
            {
                throw new ArgumentNullException(nameof(point));
            }
            return Math.Sqrt(Math.Pow((X - point.X), 2) + Math.Pow((Y - point.Y), 2) + Math.Pow((Z - point.Z), 2));
        }
    }
}
