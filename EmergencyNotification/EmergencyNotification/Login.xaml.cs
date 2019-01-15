using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmergencyNotification
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
		public Login ()
		{
			InitializeComponent ();
		}

        private async void Button_ClickedAsync(object sender, EventArgs e)
        {
            if (Application.Current.Properties.ContainsKey(uname.Text))
            {
                if (JsonConvert.DeserializeObject<User>(Application.Current.Properties[uname.Text].ToString()).password == password.Text)
                {
                    await Navigation.PushAsync(new MainPage(uname.Text));
                    Navigation.RemovePage(this);
                }
                else
                {
                    await DisplayAlert("Login Process", "Username and Password Dismatch!", "OK");
                }
            }
            else
            {
                await DisplayAlert("Login Process", "User does not exist !!", "OK");
            }
        }

        private void Register_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Register());
        }
    }
}