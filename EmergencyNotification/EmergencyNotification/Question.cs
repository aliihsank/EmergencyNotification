using System;
using System.Collections.Generic;
using System.Text;

namespace EmergencyNotification
{
    public class Question
    {
        public int id { get; set; }
        public string question { get; set; }
        public string answer1 { get; set; }
        public string answer2 { get; set; }
        public string answer3 { get; set; }

        public string img1 { get; set; }
        public string img2 { get; set; }
        public string img3 { get; set; }
    }
}
