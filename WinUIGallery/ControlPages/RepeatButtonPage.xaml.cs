// *********************************************************
//
// Copyright (c) Microsoft. All rights reserved.
// THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
// IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
// PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
//
// *********************************************************
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace WinUIGallery.ControlPages
{
	public sealed partial class RepeatButtonPage : Page
	{
		public RepeatButtonPage() => InitializeComponent();

		static int _clicks;
		void RepeatButton_Click(object sender, RoutedEventArgs e)
		{
			_clicks += 1;
			Control1Output.Text = "Number of clicks: " + _clicks;
		}
	}
}