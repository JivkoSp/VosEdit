using Vos.Models;
using Vos.Models.Document;

namespace Vos.Controls
{
    public class TextView : ContentView
    {
        private GraphicsView _graphicsView;
        
        private TextViewDrawable _drawable;

        private Entry _textBox;

        private string _previousText = string.Empty;

        public string Text { get; set; } = string.Empty;

        public TextDocument Document { get; } = new TextDocument();

        public TextEditorState EditorState { get; } = new TextEditorState();

        public TextView()
        {
            _drawable = new TextViewDrawable(this);

            _graphicsView = new GraphicsView
            {
                Drawable = _drawable,
                BackgroundColor = Colors.Black
            };

            _textBox = new Entry
            {
                Opacity = 0,
                IsEnabled = true,
                IsVisible = true,
                WidthRequest = 1,
                HeightRequest = 1,
            };

            _textBox.TextChanged += OnHiddenEntryTextChanged;

            var grid = new Grid();

            grid.Children.Add(_graphicsView);

            grid.Children.Add(_textBox);

            Content = grid;

            _textBox.Focus();
        }

        private void OnHiddenEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            var newText = e.NewTextValue ?? string.Empty;

            if (newText.Length > _previousText.Length)
            {
                var addedText = newText.Substring(_previousText.Length);

                InsertTextAtCaret(addedText);
            }
            else if (newText.Length < _previousText.Length)
            {
                DeleteTextBeforeCaret();
            }
            _previousText = newText;

            _textBox.Text = string.Empty;

            _graphicsView.Invalidate();
        }

        private void InsertTextAtCaret(string text)
        {
            var pos = EditorState.CaretPosition;

            Document.InsertText(pos.Line, pos.Column, text);

            EditorState.CaretPosition = new TextPosition { Line = pos.Line, Column = pos.Column + text.Length };
        }

        private void DeleteTextBeforeCaret()
        {
            var pos = EditorState.CaretPosition;

            if (pos.Column > 0)
            {
                Document.DeleteText(pos.Line, pos.Column - 1, 1);

                EditorState.CaretPosition = new TextPosition { Line = pos.Line, Column = pos.Column - 1 };
            }
        }

        public void Invalidate()
        {
            _graphicsView.Invalidate();
        }
    }
}
