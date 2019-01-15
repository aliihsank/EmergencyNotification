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
	public partial class Register : ContentPage
	{
		public Register ()
		{
			InitializeComponent ();
		}

        private async void Button_ClickedAsync(object sender, EventArgs e)
        {
            if (Application.Current.Properties.ContainsKey(uname.Text))
            {
                await DisplayAlert("Login Process", "This user already exists !!", "OK");
            }
            else
            {
                
                Application.Current.Properties[uname.Text] = JsonConvert.SerializeObject(
                    new User() {
                    tcNum = this.tcNum.Text,
                    name = this.name.Text,
                    surname = this.surname.Text,
                    birthDate = this.birthDate.Date,
                    birthPlace = this.birthPlace.Text,
                    uname = this.uname.Text,
                    password = this.password.Text }
                    );
                await Application.Current.SavePropertiesAsync();

                await DisplayAlert("Login Process", "You are registered successfuly !!", "OK");
                await Navigation.PushAsync(new MainPage(uname.Text));
                Navigation.RemovePage(this);
            }
        }
    }
}