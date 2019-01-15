using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace EmergencyNotification.UWP
{
    class GeoLocation : IGeoLocation
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
