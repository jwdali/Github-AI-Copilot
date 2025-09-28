namespace DebugExplain {
    public readonly struct ImmutableRayPoint
    {
        public double X { get; }
        public double Y { get; }
        public double Z { get; }

        public ImmutableRayPoint(double x, double y, double z)
        {
            X = x;
            Y = y;	
            Z = z;
        }

        public ImmutableRayPoint Offset(double d)
        {
            return new ImmutableRayPoint(X + d, Y + d, Z + d);
        }

        public ImmutableRayPoint SetX(double newX)
        {
            return new ImmutableRayPoint(newX, Y, Z);
        }

        public ImmutableRayPoint SetY(double newY)
        {
            return new ImmutableRayPoint(X, newY, Z);
        }

        public ImmutableRayPoint SetZ(double newZ)
        {
            return new ImmutableRayPoint(X, Y, newZ);
        }
    }
}
