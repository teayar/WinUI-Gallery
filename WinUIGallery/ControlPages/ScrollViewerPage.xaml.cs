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
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Input;

namespace WinUIGallery.ControlPages
{
    public sealed partial class ScrollViewerPage : Page
    {
        public ScrollViewerPage()
        {
            this.InitializeComponent();
            ScrollViewerControl.ZoomToFactor(4.0f);
        }

        void ZoomModeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ScrollViewerControl != null && ZoomSlider != null)
            {
                if (sender is ComboBox cb)
                {
                    ScrollViewerControl.ZoomMode = (ZoomMode)cb.SelectedIndex;
                    ZoomSlider.IsEnabled = cb.SelectedIndex == 1;

                    if (!ZoomSlider.IsEnabled)
                    {
                        ScrollViewerControl.ZoomToFactor(2.0f);
                    }
                }
            }
        }

        void ZoomSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (ScrollViewerControl != null)
            {
                ScrollViewerControl.ChangeView(null, null, (float)e.NewValue);
            }
        }

        void hsmCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ScrollViewerControl != null)
            {
                if (sender is ComboBox cb)
                {
                    ScrollViewerControl.HorizontalScrollMode = (ScrollMode)cb.SelectedIndex;
                }
            }
        }

        void hsbvCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ScrollViewerControl != null)
            {
                if (sender is ComboBox cb)
                {
                    ScrollViewerControl.HorizontalScrollBarVisibility = (ScrollBarVisibility)cb.SelectedIndex;
                }
            }
        }

        void vsmCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ScrollViewerControl != null)
            {
                if (sender is ComboBox cb)
                {
                    ScrollViewerControl.VerticalScrollMode = (ScrollMode)cb.SelectedIndex;
                }
            }
        }

        void vsbvCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ScrollViewerControl != null)
            {
                if (sender is ComboBox cb)
                {
                    ScrollViewerControl.VerticalScrollBarVisibility = (ScrollBarVisibility)cb.SelectedIndex;
                }
            }
        }

        void ScrollViewerControl_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            ZoomSlider.Value = ScrollViewerControl.ZoomFactor;
        }

        void ScrollViewerControl_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
            if (!e.IsIntermediate)
            {
                ZoomSlider.Value = ScrollViewerControl.ZoomFactor;
            }
        }
    }
}