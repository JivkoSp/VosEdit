using Vos.Enums.Document;
using Vos.Models.Document;

namespace Vos.Interfaces.Models.Document
{
    public interface IDocument : ITextSource, IServiceProvider
    {
        new string Text { get; set; } // hides ITextSource.Text to add the setter

        event EventHandler<TextChangeEventArgs> TextChanging;

        event EventHandler<TextChangeEventArgs> TextChanged;

        event EventHandler ChangeCompleted;

        int LineCount { get; }

        IDocumentLine GetLineByNumber(int lineNumber);

        IDocumentLine GetLineByOffset(int offset);

        int GetOffset(int line, int column);

        int GetOffset(TextLocation location);

        TextLocation GetLocation(int offset);

        void Insert(int offset, string text);

        void Insert(int offset, ITextSource text);

        void Insert(int offset, string text, AnchorMovementType defaultAnchorMovementType);

        void Insert(int offset, ITextSource text, AnchorMovementType defaultAnchorMovementType);

        void Remove(int offset, int length);

        void Replace(int offset, int length, string newText);

        void Replace(int offset, int length, ITextSource newText);

        void StartUndoableAction();

        void EndUndoableAction();

        IDisposable OpenUndoGroup();

        ITextAnchor CreateAnchor(int offset);

        string FileName { get; }

        event EventHandler FileNameChanged;
    }
}
