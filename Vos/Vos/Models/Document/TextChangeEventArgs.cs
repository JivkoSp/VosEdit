using Vos.Enums.Document;
using Vos.Interfaces.Models.Document;

namespace Vos.Models.Document
{
    public class TextChangeEventArgs : EventArgs
    {
        public int Offset { get; }

        public ITextSource RemovedText { get; }

        public int RemovalLength => RemovedText.TextLength;

        public ITextSource InsertedText { get; }

        public int InsertionLength => InsertedText.TextLength;

        public TextChangeEventArgs(int offset, string removedText, string insertedText)
        {
            if (offset < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(offset), offset, "offset must not be negative");
            }
                
            Offset = offset;

            RemovedText = removedText != null ? new TextSource(removedText) : TextSource.Empty;

            InsertedText = insertedText != null ? new TextSource(insertedText) : TextSource.Empty;
        }

        public TextChangeEventArgs(int offset, ITextSource removedText, ITextSource insertedText)
        {
            if (offset < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(offset), offset, "offset must not be negative");
            }
                
            Offset = offset;

            RemovedText = removedText ?? TextSource.Empty;

            InsertedText = insertedText ?? TextSource.Empty;
        }

        public virtual int GetNewOffset(int offset, AnchorMovementType movementType = AnchorMovementType.Default)
        {
            if (offset >= Offset && offset <= Offset + RemovalLength)
            {
                if (movementType == AnchorMovementType.BeforeInsertion)
                {
                    return Offset;
                }
                    
                return Offset + InsertionLength;
            }

            if (offset > Offset)
            {
                return offset + InsertionLength - RemovalLength;
            }

            return offset;
        }

        public virtual TextChangeEventArgs Invert() => new TextChangeEventArgs(Offset, InsertedText, RemovedText);
    }
}
