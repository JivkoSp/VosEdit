using Vos.Interfaces.Models.Document;

namespace Vos.Extensions
{
    public static class SegmentExtensions
    {
        public static bool Contains(this ISegment segment, int offset, int length)
            => segment.Offset <= offset && offset + length <= segment.EndOffset;

        public static bool Contains(this ISegment thisSegment, ISegment segment)
            => segment != null && thisSegment.Offset <= segment.Offset && segment.EndOffset <= thisSegment.EndOffset;
    }
}
