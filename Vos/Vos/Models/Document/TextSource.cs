using Vos.Interfaces.Models.Document;

namespace Vos.Models.Document
{
    public class TextSource : ITextSource
    {
        public static readonly TextSource Empty = new TextSource(string.Empty);

        public ITextSourceVersion Version { get; }

        public int TextLength => Text.Length;

        public string Text { get; }

        public TextSource(string text)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }

        public TextSource(string text, ITextSourceVersion version) : this(text)  
        {
            Version = version;
        }

        public ITextSource CreateSnapshot() => this;

        public ITextSource CreateSnapshot(int offset, int length) => new TextSource(Text.Substring(offset, length));
        
        public TextReader CreateReader() => new StringReader(Text);

        public TextReader CreateReader(int offset, int length) => new StringReader(Text.Substring(offset, length));

        public void WriteTextTo(TextWriter writer)
        {
            writer.Write(Text);
        }

        public void WriteTextTo(TextWriter writer, int offset, int length)
        {
            writer.Write(Text.Substring(offset, length));
        }

        public char GetCharAt(int offset) => Text[offset];

        public string GetText(int offset, int length) => Text.Substring(offset, length);

        public string GetText(ISegment segment)
        {
            if (segment == null)
            {
                throw new ArgumentNullException(nameof(segment));
            }
                
            return Text.Substring(segment.Offset, segment.Length);
        }

        public int IndexOf(char c, int startIndex, int count) => Text.IndexOf(c, startIndex, count);

        public int IndexOfAny(char[] anyOf, int startIndex, int count) => Text.IndexOfAny(anyOf, startIndex, count);

        public int IndexOf(string searchText, int startIndex, int count, StringComparison comparisonType)
                => Text.IndexOf(searchText, startIndex, count, comparisonType);

        public int LastIndexOf(char c, int startIndex, int count) => Text.LastIndexOf(c, startIndex + count - 1, count);

        public int LastIndexOf(string searchText, int startIndex, int count, StringComparison comparisonType)
            => Text.LastIndexOf(searchText, startIndex + count - 1, count, comparisonType);
    }
}
