using Microsoft.UI;
using Microsoft.UI.Text;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Shapes;
using System.Threading.Tasks;

namespace WinUIGallery.ControlPages
{
	public sealed partial class SplitButtonPage : Page
	{
		Windows.UI.Color currentColor = Colors.Green;

		public SplitButtonPage()
		{
			InitializeComponent();

			myRichEditBox.Document.Selection.CharacterFormat.ForegroundColor = currentColor;

			myRichEditBox.Document.Selection
			    .SetText(Microsoft.UI.Text.TextSetOptions.None,
				"Lorem ipsum dolor sit amet, consectetur adipiscing elit, " +
				"sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Tempor commodo ullamcorper a lacus.");
		}

		void GridView_ItemClick(object sender, ItemClickEventArgs e)
		{
			var rect = (Rectangle)e.ClickedItem;
			var color = ((SolidColorBrush)rect.Fill).Color;
			myRichEditBox.Document.Selection.CharacterFormat.ForegroundColor = color;
			CurrentColor.Background = new SolidColorBrush(color);

			myRichEditBox.Focus(Microsoft.UI.Xaml.FocusState.Keyboard);
			currentColor = color;

			// Delay required to circumvent GridView bug: https://github.com/microsoft/microsoft-ui-xaml/issues/6350
			Task.Delay(10)
			    .ContinueWith(_ => myColorButton.Flyout.Hide(), TaskScheduler.FromCurrentSynchronizationContext());
		}

		void RevealColorButton_Click(object sender, RoutedEventArgs e)
		{
			myColorButtonReveal.Flyout.Hide();
		}

		void myColorButton_Click(Microsoft.UI.Xaml.Controls.SplitButton sender, Microsoft.UI.Xaml.Controls.SplitButtonClickEventArgs args)
		{
			var border = (Border)sender.Content;
			var color = ((Microsoft.UI.Xaml.Media.SolidColorBrush)border.Background).Color;

			myRichEditBox.Document.Selection.CharacterFormat.ForegroundColor = color;
			currentColor = color;
		}

		void MyRichEditBox_TextChanged(object sender, RoutedEventArgs e)
		{
			if (myRichEditBox.Document.Selection.CharacterFormat.ForegroundColor != currentColor)
			{
				myRichEditBox.Document.Selection.CharacterFormat.ForegroundColor = currentColor;
			}
		}
	}
}