﻿// *********************************************************
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
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Input;

namespace WinUIGallery.ControlPages
{
	public sealed partial class FlyoutPage : Page
	{
		public FlyoutPage() => InitializeComponent();

		void DeleteConfirmation_Click(object sender, RoutedEventArgs e)
		{
			if (Control1.Flyout is Flyout f) f.Hide();
		}
	}
}