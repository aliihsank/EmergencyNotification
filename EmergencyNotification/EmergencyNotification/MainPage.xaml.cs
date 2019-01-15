using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EmergencyNotification
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Notification> myNotifications;
        private string uname = "";

        public MainPage(string uname)
        {
            this.uname = uname;
            myNotifications = new ObservableCollection<Notification>
            {
                //Null list at the beginning 
            };
            InitializeComponent();
            listView.ItemsSource = myNotifications;

            if (Application.Current.Properties.ContainsKey(uname + " Notifications"))
            {
                foreach (Notification notification in JsonConvert.DeserializeObject<NotificationList>(Application.Current.Properties[uname + " Notifications"].ToString()).notifications)
                {
                    myNotifications.Add(notification);
                }
            }
            else
            {
                Application.Current.Properties[uname + " Notifications"] = JsonConvert.SerializeObject(new NotificationList());
                Application.Current.SavePropertiesAsync();
            }

        }

        public void NewNotification(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateNotification(this, DateTimeOffset.Now.ToUnixTimeMilliseconds(), ((StackLayout)sender).ClassId, uname));
        }

        public async void DeleteNotification(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Bildirim İptali", "Bu bildirimi iptal etmek istediğinize emin misiniz?", "Evet", "Hayır");
            if (answer)
            {
                //Make Immediate change in UI
                var delImage = (Image)sender;
                Notification ntfctn = (Notification)((TapGestureRecognizer)delImage.GestureRecognizers[0]).CommandParameter;
                myNotifications.Remove(ntfctn);

                //Make change in records
                NotificationList oldList = JsonConvert.DeserializeObject<NotificationList>(Application.Current.Properties[uname + " Notifications"].ToString());
                for (int i = 0; i < oldList.notifications.Count; i++)
                {
                    if (oldList.notifications[i].id == ntfctn.id)
                    {
                        oldList.notifications.RemoveAt(i);
                    }
                }
                Application.Current.Properties[uname + " Notifications"] = JsonConvert.SerializeObject(oldList);
                await Application.Current.SavePropertiesAsync();
            }

            await DisplayAlert("Bildirim İptali", "Bildirim İptal Edildi !!", "Tamam");
        }
    }
}
