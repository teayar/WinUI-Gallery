﻿using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using WinUIGallery.ControlPages;
using Microsoft.UI.Xaml.Media.Animation;

namespace WinUIGallery.ConnectedAnimationPages
{
    public sealed partial class DetailedInfoPage : Page
    {
        public CustomDataObject DetailedObject { get; set; }
        public DetailedInfoPage()
        {
            InitializeComponent();
            GoBackButton.Loaded += GoBackButton_Loaded;
        }

        void GoBackButton_Loaded(object sender, RoutedEventArgs e)
        {
            // When we land in page, put focus on the back button
            GoBackButton.Focus(FocusState.Programmatic);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // Store the item to be used in binding to UI
            DetailedObject = e.Parameter as CustomDataObject;

            ConnectedAnimation imageAnimation = ConnectedAnimationService.GetForCurrentView().GetAnimation("ForwardConnectedAnimation");

            if (imageAnimation != null)
            {
                // Connected animation + coordinated animation
                imageAnimation.TryStart(detailedImage, new UIElement[] { coordinatedPanel });
            }
        }

        // Create connected animation back to collection page.
        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);

            ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("BackConnectedAnimation", detailedImage);
        }

        void BackButton_Click(object sender, RoutedEventArgs e) => Frame.GoBack();
    }
}