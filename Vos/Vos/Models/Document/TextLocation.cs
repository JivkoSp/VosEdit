using System;
using System.ComponentModel;
using System.Globalization;

namespace Vos.Models.Document
{
    [TypeConverter(typeof(TextLocationConverter))]
    public record TextLocation(int line, int column) : IComparable<TextLocation>
    {
        public int Line { get; init; } = line;

        public int Column { get; init; } = column;

        public bool IsEmpty => Column <= 0 && Line <= 0;

        public override string ToString() => string.Format(CultureInfo.InvariantCulture, "(Line {1}, Col {0})", Column, Line);

        public int CompareTo(TextLocation? other)
        {
            if (Line != other?.Line)
            {
                return Line.CompareTo(other?.Line);
            }
                
            return Column.CompareTo(other.Column);
        }

        public static bool operator <(TextLocation left, TextLocation right) => left.CompareTo(right) < 0;

        public static bool operator >(TextLocation left, TextLocation right) => left.CompareTo(right) > 0;

        public static bool operator <=(TextLocation left, TextLocation right) => left.CompareTo(right) <= 0;

        public static bool operator >=(TextLocation left, TextLocation right) => left.CompareTo(right) >= 0;
    }
}
