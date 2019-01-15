using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Essentials;

[assembly: Xamarin.Forms.Dependency(typeof(EmergencyNotification.Droid.GeoLocation))]
namespace EmergencyNotification.Droid
{
    public class GeoLocation : IGeoLocation
    {
        public async Task<string> GetLocation()
        {
            var request = new GeolocationRequest(GeolocationAccuracy.Medium);
            var location = await Geolocation.GetLocationAsync(request);

            if (location != null)
            {
                return (location.Latitude + "," + location.Longitude);
            }
            else
            {
                return "Boş Koordinat";
            }
        }
        

    }
}