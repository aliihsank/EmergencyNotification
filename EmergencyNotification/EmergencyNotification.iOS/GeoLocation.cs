using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using UIKit;

namespace EmergencyNotification.iOS
{
    class GeoLocation : IGeoLocation
    {
        public Task<string> GetLocation()
        {
            throw new NotImplementedException();
        }
    }
}