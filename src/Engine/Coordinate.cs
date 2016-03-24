using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace NathanAlden.TextAdventure.Engine
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public struct Coordinate<T> : IJsonSerializable
        where T : struct
    {
        public Coordinate(T x, T y)
        {
            X = x;
            Y = y;
        }

        // ReSharper disable once UnusedMember.Local
        private string DebuggerDisplay => $"{{x={X},y={Y}}}";
        public T X { get; }
        public T Y { get; }

        public bool Equals(Coordinate<T> other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y);
        }

        public override bool Equals(object obj)
        {
            return !ReferenceEquals(null, obj) && obj is Coordinate<T> && Equals((Coordinate<T>)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X.GetHashCode() * 397) ^ Y.GetHashCode();
            }
        }

        public object SerializeToJsonObject()
        {
            return new
                   {
                       x = X,
                       y = Y
                   };
        }

        public override string ToString()
        {
            return DebuggerDisplay;
        }

        public static Coordinate<T> FromJson(JToken jsonObject)
        {
            return new Coordinate<T>(jsonObject.Value<T>("x"), jsonObject.Value<T>("y"));
        }

        public static bool operator ==(Coordinate<T> left, Coordinate<T> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Coordinate<T> left, Coordinate<T> right)
        {
            return !left.Equals(right);
        }
    }
}