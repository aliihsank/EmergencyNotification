using System;
using System.Collections.Generic;
using System.Text;

namespace EmergencyNotification
{
    public class Notification
    {
        public long id { get; set; }

        public string title { get; set; }
        public string detail { get; set; }

        public string myCoords { get; set; }

        public string when { get; set; }

        //Polis Spesifik Bilgiler
        public string where { get; set; }
        public string numOfSuspects { get; set; }

        //Acil Servis Spesifik Bilgiler
        public string numOfInjured { get; set; }

        //İtfaiye Spesific Bilgiler


    }
}
