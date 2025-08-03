namespace Vos.Controls
{
    public class TextView : ContentView
    {
        private GraphicsView _graphicsView;
        
        private TextViewDrawable _drawable;

        public string Text { get; set; } = string.Empty;

        public TextView()
        {
            _drawable = new TextViewDrawable(this);

            _graphicsView = new GraphicsView
            {
                Drawable = _drawable,
                BackgroundColor = Colors.White,
            };

            Content = _graphicsView;
        }
    }
}
