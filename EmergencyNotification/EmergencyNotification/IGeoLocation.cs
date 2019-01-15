using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyNotification
{
    public interface IGeoLocation
    {
        Task<string> GetLocation();
    }
}
