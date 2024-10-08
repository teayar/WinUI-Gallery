using Microsoft.UI.Xaml.Controls;

namespace WinUIGallery.ControlPages
{
	public sealed partial class ColorPickerPage : Page
	{
		public ColorPickerPage() => InitializeComponent();

		void ColorSpectrumShapeRadioButtons_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			switch (ColorSpectrumShapeRadioButtons.SelectedItem)
			{
				case "Box":
					colorPicker.ColorSpectrumShape = Microsoft.UI.Xaml.Controls.ColorSpectrumShape.Box;
					break;
				default:
					colorPicker.ColorSpectrumShape = Microsoft.UI.Xaml.Controls.ColorSpectrumShape.Ring;
					break;
			}
		}
	}
}
