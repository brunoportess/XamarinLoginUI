using System.ComponentModel;
using Xamarin.Forms;
using XamarinLoginUI.Views;

namespace XamarinLoginUI
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void login1_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new Login1());
        }

        private async void login2_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new Login2());
        }

        private async void login3_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new Login3());

        }
    }
}
