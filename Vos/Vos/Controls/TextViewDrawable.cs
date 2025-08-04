namespace Vos.Controls
{
    public class TextViewDrawable : IDrawable
    {
        private readonly TextView _textView;

        public TextViewDrawable(TextView textView)
        {
            _textView = textView;
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.FillColor = Colors.White;

            canvas.FillRectangle(dirtyRect);

            if (string.IsNullOrEmpty(_textView.Text))
            {
                return;
            }

            // Draw text line by line

            var lines = _textView.Text.Split('\n');

            float y = 15;

            float lineHeight = 20;

            float leftMarginLineNumbers = 5;

            float leftMarginText = 40;

            canvas.FontSize = 14;

            canvas.FontColor = Colors.Black;

            for (int i = 0; i < lines.Length; i++)
            {
                // Draw line number
                canvas.FontColor = Colors.Gray;
                canvas.DrawString((i + 1).ToString(), leftMarginLineNumbers, y, HorizontalAlignment.Left);

                // Draw text
                canvas.FontColor = Colors.Black;
                canvas.DrawString(lines[i], leftMarginText, y, HorizontalAlignment.Left);
                y += lineHeight;
            }

            // TODO: Draw selection, caret, syntax highlighting, etc.
        }
    }
}
