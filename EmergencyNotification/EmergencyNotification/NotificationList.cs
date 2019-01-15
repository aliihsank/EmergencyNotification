using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace EmergencyNotification
{
    class NotificationList
    {
        public ObservableCollection<Notification> notifications = new ObservableCollection<Notification>();
    }
}
