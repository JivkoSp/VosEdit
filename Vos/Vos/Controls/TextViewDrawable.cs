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
            throw new NotImplementedException();
        }
    }
}
