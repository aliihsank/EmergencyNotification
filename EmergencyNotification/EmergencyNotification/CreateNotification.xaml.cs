using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmergencyNotification
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreateNotification : ContentPage
	{
        private string uname = "";

        ObservableCollection<Question> questions = new ObservableCollection<Question>() { };

        ObservableCollection<Question> polisQuestions = new ObservableCollection<Question>() {
            new Question() { id = 1, question = "Olayın Türü Nedir?", answer1 = "Silahlı Saldırı", answer2 = "Hırsızlık", answer3 = "Terör Eylemi", img1 = "https://cdn4.iconfinder.com/data/icons/military-icon-set/100/military_1-512.png", img2="https://cdn3.iconfinder.com/data/icons/good-or-bad-neighborhood/120/burglar_thief-512.png", img3="https://cdn4.iconfinder.com/data/icons/terrorist-terrorism-suicide-bomber/237/terrorist-terrorism-war-gun-001-512.png" },
            new Question() { id = 2, question = "Olay Nerede Gerçekleşti?", answer1 = "Burada!", answer2 = "3 blok çevremde", answer3 = "5 blok çevremde", img1 = "https://cdn2.iconfinder.com/data/icons/filled-icons/493/Geotag-512.png", img2 = "https://cdn1.iconfinder.com/data/icons/sales-delivery/128/distribution-2-512.png", img3 = "https://cdn1.iconfinder.com/data/icons/sales-delivery/128/distribution-2-512.png" },
            new Question() { id = 3, question = "Olay Ne Zaman Gerçekleşti?", answer1 = "Şu anda!", answer2 = "5dk Önce", answer3 = "15dk Önce", img1 = "https://cdn2.iconfinder.com/data/icons/ui-pt-3-bold/100/143_-_clock-512.png", img2 = "https://cdn4.iconfinder.com/data/icons/time-line/512/history-512.png", img3 = "https://cdn4.iconfinder.com/data/icons/time-line/512/history-512.png" },
            new Question() { id = 4, question = "Saldırganlar Kaç Kişi?", answer1 = "1 Kişi", answer2 = "2 Kişi", answer3 = "3+ Kişi", img1 = "https://cdn1.iconfinder.com/data/icons/human-1/48/04-512.png", img2 = "https://cdn2.iconfinder.com/data/icons/family-solid-icons-1/48/01-512.png", img3 = "https://cdn1.iconfinder.com/data/icons/ui-glynh-05-of-5/100/UI_Glyph_09_-09-512.png" }
        };


        ObservableCollection<Question> acilServisQuestions = new ObservableCollection<Question>() {
            new Question() { id = 1, question = "Olayın Türü Nedir?", answer1 = "Kesici/Delici Aletle Yaralanma", answer2 = "Yanık", answer3 = "İç Hastalıklar", img1 = "https://cdn4.iconfinder.com/data/icons/mini-icon-drugs-medical/91/Drugs_-_Medical_18-512.png", img2 = "https://cdn4.iconfinder.com/data/icons/dangerous/512/burn-512.png", img3 = "https://cdn.iconscout.com/icon/premium/png-256-thumb/sick-88-578108.png" },
            new Question() { id = 2, question = "Olay Ne Zaman Gerçekleşti?", answer1 = "Şu anda!", answer2 = "5dk Önce", answer3 = "15dk Önce", img1 = "https://cdn2.iconfinder.com/data/icons/ui-pt-3-bold/100/143_-_clock-512.png", img2 = "https://cdn4.iconfinder.com/data/icons/time-line/512/history-512.png", img3 = "https://cdn4.iconfinder.com/data/icons/time-line/512/history-512.png" },
            new Question() { id = 3, question = "Kazazede Sayısı Kaç?", answer1 = "1", answer2 = "2", answer3 = "3+", img1 = "https://cdn1.iconfinder.com/data/icons/human-1/48/04-512.png", img2 = "https://cdn2.iconfinder.com/data/icons/family-solid-icons-1/48/01-512.png", img3 = "https://cdn1.iconfinder.com/data/icons/ui-glynh-05-of-5/100/UI_Glyph_09_-09-512.png" }
        };

        ObservableCollection<Question> itfaiyeQuestions = new ObservableCollection<Question>() {
            new Question() { id = 1, question = "Olayın Türü Nedir?", answer1 = "Küçük Çaplı Yangın", answer2 = "Apartman Yangını", answer3 = "Bölgesel Yangın", img1 = "http://t1.rbxcdn.com/5478e92934933709a81823976ac87c77", img2 = "https://cdn3.iconfinder.com/data/icons/disaster-and-weather-conditions/48/62-512.png", img3 = "https://cdn2.iconfinder.com/data/icons/trip-1/85/burning_forest-512.png" },
            new Question() { id = 2, question = "Olay Ne Zaman Gerçekleşti?", answer1 = "Şu anda!", answer2 = "5dk Önce", answer3 = "15dk Önce", img1 = "https://cdn2.iconfinder.com/data/icons/ui-pt-3-bold/100/143_-_clock-512.png", img2 = "https://cdn4.iconfinder.com/data/icons/time-line/512/history-512.png", img3 = "https://cdn4.iconfinder.com/data/icons/time-line/512/history-512.png" }
        };
        
        ObservableCollection<Question> visibleQuestions = new ObservableCollection<Question>();

        private int lastAddedQuestion = 0;
        private bool IsButtonAdded = false;

        private MainPage mainPage;

        private Notification newNotification = new Notification();

        public CreateNotification(MainPage main, long id, string notificationCategory, string uname)
        {
            this.mainPage = main;
            this.uname = uname;

            newNotification.id = id;

            InitializeComponent();

            listView.ItemsSource = visibleQuestions;
            listView.RowHeight = 120;

            lastAddedQuestion++;
            switch (notificationCategory)
            {
                case "Polis":
                    questions = polisQuestions;
                    visibleQuestions.Add(questions[lastAddedQuestion - 1]);
                    newNotification.title = "Polis";
                    break;
                case "AcilServis":
                    questions = acilServisQuestions;
                    visibleQuestions.Add(questions[lastAddedQuestion - 1]);
                    newNotification.title = "Acil Servis";
                    break;
                case "İtfaiye":
                    questions = itfaiyeQuestions;
                    visibleQuestions.Add(questions[lastAddedQuestion - 1]);
                    newNotification.title = "İtfaiye";
                    break;
            }

        }

        private void AnswerChoosen(object sender, EventArgs e)
        {
            StackLayout stackLayout = (StackLayout)sender;
            TapGestureRecognizer tapGestureRecognizer = (TapGestureRecognizer)stackLayout.GestureRecognizers[0];
            string questionId = stackLayout.ClassId;
            string answer = tapGestureRecognizer.CommandParameter.ToString();

            switch (newNotification.title)
            {
                case "Polis":
                    switch (int.Parse(questionId))
                    {
                        case 1:
                            newNotification.detail = answer;
                            break;
                        case 2:
                            newNotification.where = answer;
                            break;
                        case 3:
                            newNotification.when = answer;
                            break;
                        case 4:
                            newNotification.numOfSuspects = answer;
                            break;
                    }
                    break;
                case "Acil Servis":
                    switch (int.Parse(questionId))
                    {
                        case 1:
                            newNotification.detail = answer;
                            break;
                        case 2:
                            newNotification.when = answer;
                            break;
                        case 3:
                            newNotification.numOfInjured = answer;
                            break;
                    }
                    break;
                case "İtfaiye":
                    switch (int.Parse(questionId))
                    {
                        case 1:
                            newNotification.detail = answer;
                            break;
                        case 2:
                            newNotification.when = answer;
                            break;
                    }
                    break;
            }

            if (lastAddedQuestion >= questions.Count)
            {
                if (!IsButtonAdded)
                {
                    Button btnSend = new Button() { Text = "BİLDİRİM GÖNDER", BackgroundColor = Color.FromHex("#255F85"), HorizontalOptions = LayoutOptions.Center };
                    btnSend.Clicked += async delegate {
                        try
                        {
                            var android = DependencyService.Get<IGeoLocation>();
                            string location = await android.GetLocation();
                            newNotification.myCoords = location;
                        }
                        catch (Exception ee)
                        {
                            await DisplayAlert("Hata", ee.ToString(), "Tamam");
                        }

                        mainPage.myNotifications.Add(newNotification);

                        if (Application.Current.Properties.ContainsKey(uname + " Notifications"))
                        {
                            NotificationList oldList = JsonConvert.DeserializeObject<NotificationList>(Application.Current.Properties[uname + " Notifications"].ToString());
                            oldList.notifications.Add(newNotification);
                            Application.Current.Properties[uname + " Notifications"] = JsonConvert.SerializeObject(oldList);
                            await Application.Current.SavePropertiesAsync();
                        }
                        

                        await DisplayAlert("Yeni Bildirim", "Bildiriminiz İletildi !!", "Tamam");
                        Navigation.RemovePage(this);
                    };
                    ParentLayout.Children.Add(btnSend);
                    IsButtonAdded = true;
                }
            }
            else
            {
                if (int.Parse(questionId) == lastAddedQuestion)
                {
                    lastAddedQuestion++;
                    visibleQuestions.Add(questions[lastAddedQuestion - 1]);
                }
            }
        }
    }
}