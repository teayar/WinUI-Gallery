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
    public sealed partial class ToggleButtonPage : Page
    {
        public ToggleButtonPage()
        {
            this.InitializeComponent();

            // Set initial output value.
            Control1Output.Text = (bool)Toggle1.IsChecked ? "On" : "Off";
        }

        void ToggleButton_Checked(object sender, RoutedEventArgs e) => Control1Output.Text = "On";

        void ToggleButton_Unchecked(object sender, RoutedEventArgs e) => Control1Output.Text = "Off";
    }
}