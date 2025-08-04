using Vos.Controls;

namespace Vos
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var textView = new TextView
            {
                Text = "Line 1\nLine 2\nLine 3"
            };

            ScrollContainer.Content = textView;
        }
    }
}
