using Microsoft.UI.Xaml.Controls;

namespace WinUIGallery.ControlPages
{
    public sealed partial class RatingControlPage : Page
    {
        public RatingControlPage() => InitializeComponent();

        void RatingControl1_ValueChanged(Microsoft.UI.Xaml.Controls.RatingControl sender, object args)
        {
            RatingControl1.Caption = "Your rating";
        }
    }
}
