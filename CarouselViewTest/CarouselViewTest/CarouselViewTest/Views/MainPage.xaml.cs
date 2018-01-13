using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarouselViewTest.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();
            BindingContext = this;
		}

        public ObservableCollection<string> Items { get; } = new ObservableCollection<string>() { "hello", "world", "how", "are", "you" };
	}
}