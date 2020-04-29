using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinLoginUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login1 : ContentPage
    {
        public Login1()
        {
            InitializeComponent();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}