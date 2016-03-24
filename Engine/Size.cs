using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace NathanAlden.TextAdventure.Engine
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public struct Size<T> : IJsonSerializable
        where T : struct
    {
        public Size(T width, T height)
        {
            Width = width;
            Height = height;
        }

        // ReSharper disable once UnusedMember.Local
        private string DebuggerDisplay => $"{{w={Width},h={Height}}}";
        public T Width { get; }
        public T Height { get; }

        public bool Equals(Size<T> other)
        {
            return Width.Equals(other.Width) && Height.Equals(other.Height);
        }

        public override bool Equals(object obj)
        {
            return !ReferenceEquals(null, obj) && obj is Size<T> && Equals((Size<T>)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Width.GetHashCode() * 397) ^ Height.GetHashCode();
            }
        }

        public object SerializeToJsonObject()
        {
            return new
                   {
                       width = Width,
                       height = Height
                   };
        }

        public override string ToString()
        {
            return DebuggerDisplay;
        }

        public static Size<T> FromJson(JToken jsonObject)
        {
            return new Size<T>(jsonObject.Value<T>("width"), jsonObject.Value<T>("height"));
        }

        public static bool operator ==(Size<T> left, Size<T> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Size<T> left, Size<T> right)
        {
            return !left.Equals(right);
        }
    }
}