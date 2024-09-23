using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;

namespace WinUIGallery.ControlPages
{
	public sealed partial class SoundPage : Page
	{
		public SoundPage()
		{
			InitializeComponent();

			if (ElementSoundPlayer.State == ElementSoundPlayerState.On)
				soundToggle.IsOn = true;

			if (ElementSoundPlayer.SpatialAudioMode == ElementSpatialAudioMode.On && soundToggle.IsOn == true)
				spatialAudioBox.IsChecked = true;
		}

		void Button_Click(object sender, RoutedEventArgs e)
		{
			var tagInt = int.Parse((string)(sender as Button).Tag);
			ElementSoundPlayer.Play((ElementSoundKind)tagInt);
		}

		void spatialAudioBox_Checked(object sender, RoutedEventArgs e)
		{
			if (soundToggle.IsOn == true)
			{
				ElementSoundPlayer.SpatialAudioMode = ElementSpatialAudioMode.On;
			}
		}

		void spatialAudioBox_Unchecked(object sender, RoutedEventArgs e)
		{
			if (soundToggle.IsOn == true)
			{
				ElementSoundPlayer.SpatialAudioMode = ElementSpatialAudioMode.Off;
			}
		}

		void soundToggle_Toggled(object sender, RoutedEventArgs e)
		{
			if (soundToggle.IsOn == true)
			{
				spatialAudioBox.IsEnabled = true;
				ElementSoundPlayer.State = ElementSoundPlayerState.On;
			}
			else
			{
				spatialAudioBox.IsEnabled = false;
				spatialAudioBox.IsChecked = false;

				ElementSoundPlayer.State = ElementSoundPlayerState.Off;
				ElementSoundPlayer.SpatialAudioMode = ElementSpatialAudioMode.Off;
			}
		}
	}
}