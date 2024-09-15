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
using Microsoft.UI.Xaml.Shapes;

namespace WinUIGallery.ControlPages
{
    public sealed partial class ThemeTransitionPage : Page
    {
        int _itemCount = 10;
        public ThemeTransitionPage()
        {
            InitializeComponent();

            for (int i = 0; i < _itemCount; i++)
                AddRemoveListView.Items.Add(new ListViewItem() { Content = "Item " + i });

            AddItemsToContentListView();
        }

        void ShowPopupButton_Click(object sender, RoutedEventArgs e)
        {
            ExamplePopup.IsOpen = true;
            ClosePopupButton.Focus(FocusState.Programmatic);
        }

        void ClosePopupButton_Click(object sender, RoutedEventArgs e)
        {
            ExamplePopup.IsOpen = false;
            ShowPopupButton.Focus(FocusState.Programmatic);
        }

        void ContentRefreshButton_Click(object sender, RoutedEventArgs e)
        {
            AddItemsToContentListView(true);
        }

        void AddItemsToContentListView(bool ShowDifferentContent = false)
        {
            var items = new List<string>();

            for (int i = 0; i < 5; i++)
                items.Add(ShowDifferentContent ? "Updated content " + i : "Item " + i);

            ContentList.ItemsSource = items;
        }

        void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddRemoveListView.Items.Add(new ListViewItem() { Content = "New Item " + _itemCount.ToString() });
            _itemCount++;
        }

        void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (AddRemoveListView.Items.Count > 0)
                AddRemoveListView.Items.RemoveAt(0);
        }

        void RepositionButton_Click(object sender, RoutedEventArgs e)
        {
            MiddleElement.Visibility = MiddleElement.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }

        void EntranceAddButton_Click(object sender, RoutedEventArgs e)
        {
            var value = Convert.ToInt32((sender as Button).Tag);

            for (int i = 0; i < value; i++)
            {
                Thickness thickness = new Thickness(5.0);

                EntranceStackPanel.Children
                    .Add(new Rectangle() { Width = 50, Height = 50, Margin = thickness, Fill = new SolidColorBrush(Microsoft.UI.Colors.LightBlue) });
            }
        }

        void EntranceClearButton_Click(object sender, RoutedEventArgs e)
        {
            EntranceStackPanel.Children.Clear();
        }

        void AddDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            AddButton_Click(sender, e);
            DeleteButton_Click(sender, e);
        }
    }
}