// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using System;
using WinUIGallery.Data;
using WinUIGallery.Helper;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Uri = System.Uri;

namespace WinUIGallery.DesktopWap.Controls
{
    public sealed partial class PageHeader : UserControl
    {
        public Visibility ThemeButtonVisibility
        {
            get { return (Visibility)GetValue(ThemeButtonVisibilityProperty); }
            set { SetValue(ThemeButtonVisibilityProperty, value); }
        }
        public static readonly DependencyProperty ThemeButtonVisibilityProperty =
            DependencyProperty.Register("ThemeButtonVisibility", typeof(Visibility), typeof(PageHeader), new PropertyMetadata(Visibility.Visible));

        public string PageName { get; set; }
        public Action CopyLinkAction { get; set; }
        public Action ToggleThemeAction { get; set; }

        public ControlInfoDataItem Item { get; set; }
        public PageHeader()
        {
            InitializeComponent();
            CopyLinkAction = OnCopyLink;
        }

        public void SetSamplePageSourceLinks(string BaseUri, string PageName)
        {
            // Pagetype is not null!
            // So lets generate the github links and set them!
            var pageName = PageName + ".xaml";
            PageCodeGitHubLink.NavigateUri = new Uri(BaseUri + pageName + ".cs");
            PageMarkupGitHubLink.NavigateUri = new Uri(BaseUri + pageName);
        }

        public void SetControlSourceLink(string BaseUri, string SourceLink)
        {
            if (!string.IsNullOrEmpty(SourceLink))
            {
                ControlSourcePanel.Visibility = Visibility.Visible;
                ControlSourceLink.NavigateUri = new Uri(BaseUri + SourceLink);
            }
            else
            {
                ControlSourcePanel.Visibility = Visibility.Collapsed;
            }
        }

        void OnCopyLinkButtonClick(object sender, RoutedEventArgs e)
        {
            CopyLinkAction?.Invoke();

            if (ProtocolActivationClipboardHelper.ShowCopyLinkTeachingTip)
            {
                CopyLinkButtonTeachingTip.IsOpen = true;
            }
        }

        public void OnThemeButtonClick(object sender, RoutedEventArgs e)
        {
            ToggleThemeAction?.Invoke();
            UIHelper.AnnounceActionForAccessibility(ThemeButton, "Theme changed.", "ThemeChangedSuccessNotificationId");
        }

        void OnCopyDontShowAgainButtonClick(TeachingTip sender, object args)
        {
            ProtocolActivationClipboardHelper.ShowCopyLinkTeachingTip = false;
            CopyLinkButtonTeachingTip.IsOpen = false;
        }

        void OnCopyLink() => ProtocolActivationClipboardHelper.Copy(Item);
        public async void OnFeedBackButtonClick(object sender, RoutedEventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri("https://github.com/microsoft/WinUI-Gallery/issues/new/choose"));
        }
    }
}