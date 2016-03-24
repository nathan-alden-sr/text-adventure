namespace NathanAlden.TextAdventure.Engine
{
    public static class SizeExtensions
    {
        public static Coordinate<int> Divide(this Size<int> value, int divisor)
        {
            return new Coordinate<int>(value.Width / divisor, value.Height / divisor);
        }

        public static Coordinate<int> Divide(this Size<int> value, double divisor)
        {
            return new Coordinate<int>((int)(value.Width / divisor), (int)(value.Height / divisor));
        }
    }
}