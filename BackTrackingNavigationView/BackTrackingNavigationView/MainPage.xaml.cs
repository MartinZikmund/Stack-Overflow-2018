using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BackTrackingNavigationView
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private const string PageNamespace = nameof(BackTrackingNavigationView);

        public MainPage()
        {
            this.InitializeComponent();

            AppFrame.Navigated += AppFrame_Navigated;

            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += MainPage_BackRequested;
        }

        private void AppFrame_Navigated(object sender, NavigationEventArgs e)
        {
var pageName = AppFrame.Content.GetType().Name;
AppNavigationView.SelectedItem = AppNavigationView.MenuItems.OfType<NavigationViewItem>().Where(item => item.Tag.ToString() == pageName).First();
        }

        private void MainPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if ( AppFrame.CanGoBack)
            {
                AppFrame.GoBack();
            }
        }

        private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            var invokedMenuItem = sender.MenuItems.OfType<NavigationViewItem>().Where(item => item.Content.ToString() == args.InvokedItem.ToString()).First();
            var pageTypeName = invokedMenuItem.Tag.ToString();
            var pageType = Assembly.GetExecutingAssembly().GetType($"{PageNamespace}.{pageTypeName}");
            AppFrame.Navigate(pageType);
        }
    }
}
