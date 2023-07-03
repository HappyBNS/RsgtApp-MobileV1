using Microsoft.AppCenter.Analytics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;

namespace RsgtApp.ViewModels
{
    public class AboutRSGTViewModel : INotifyPropertyChanged
    {
        
        private List<InfoItem> objCMS = new List<InfoItem>();
      
      
        public event PropertyChangedEventHandler PropertyChanged;
        //20230331
        /// <summary>
        /// Twowaybinding process on Propertychange Event
        /// </summary>
        /// <param name="name">name</param>
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        /// <summary>
        /// Twowaybinding process on RaisePropertyChange Event
        /// </summary>
        /// <param name="propertyname">propertyname</param>
        public void RaisePropertyChange(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
        /// <summary>
        /// Twowaybinding process on Propertychange Event
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="backfield">backfield</param>
        /// <param name="value">value</param>
        /// <param name="propertyName">propertyName</param>
        /// <returns></returns>
        protected bool SetProperty<T>(ref T backfield, T value,
            [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backfield, value))
            {
                return false;
            }
            backfield = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        //Indicator Color
        private string indicatorBGColor = RSGT_Resource.ResourceManager.GetString("IndicatorViewBGColor");
        public string IndicatorBGColor
        {
            get { return indicatorBGColor; }
            set
            {
                indicatorBGColor = value;
                OnPropertyChanged();
                RaisePropertyChange("IndicatorBGColor");
            }
        }
        //Indicator Opacity
        private string indicatorBGOpacity = RSGT_Resource.ResourceManager.GetString("IndicatorViewOpacity");
        public string IndicatorBGOpacity
        {
            get { return indicatorBGOpacity; }
            set
            {
                indicatorBGOpacity = value;
                OnPropertyChanged();
                RaisePropertyChange("IndicatorBGOpacity");
            }
        }
        private bool stackAboutRSGT = true;
        public bool StackAboutRSGT
        {
            get { return stackAboutRSGT; }
            set
            {
                stackAboutRSGT = value;
                OnPropertyChanged();
                RaisePropertyChange("StackAboutRSGT");
            }
        }
        //lblAboutRsgt purpose of using Label varaiable
        private string lblAboutRsgt = "";
        public string LblAboutRsgt
        {
            get { return lblAboutRsgt; }
            set
            {
                lblAboutRsgt = value;
                OnPropertyChanged();
                RaisePropertyChange("LblAboutRsgt");
            }
        }
        //AboutRSGTtext purpose of using Label varaiable
        private string aboutRSGTtext = "";
        public string AboutRSGTtext
        {
            get { return aboutRSGTtext; }
            set
            {
                aboutRSGTtext = value;
                OnPropertyChanged();
                RaisePropertyChange("AboutRSGTtext");
            }
        }
        //AboutRSGTtextArb purpose of using Label varaiable
        private string aboutRSGTtextArb = "";
        public string AboutRSGTtextArb
        {
            get { return aboutRSGTtextArb; }
            set
            {
                aboutRSGTtextArb = value;
                OnPropertyChanged();
                RaisePropertyChange("AboutRSGTtextArb");
            }
        }
        //IsVisibleAboutRSGTEn purpose of using boolean varaiable
        private bool isVisibleAboutRSGTEn = false;
        public bool IsVisibleAboutRSGTEn
        {
            get { return isVisibleAboutRSGTEn; }
            set
            {
                isVisibleAboutRSGTEn = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleAboutRSGTEn");
            }
        }
        //IsVisibleAboutRSGTArb purpose of using boolean varaiable
        private bool isVisibleAboutRSGTArb = false;
        public bool IsVisibleAboutRSGTArb
        {
            get { return isVisibleAboutRSGTArb; }
            set
            {
                isVisibleAboutRSGTArb = value;
                OnPropertyChanged();
                RaisePropertyChange("IsVisibleAboutRSGTArb");
            }
        }
        //To Handel Boolen Value
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;

                OnPropertyChanged();
                RaisePropertyChange("IsBusy");
            }
        }
        /// <summary>
        /// View-Model Constructor
        /// </summary>
        public AboutRSGTViewModel()
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("AboutRSGTViewModel");
            Task.Run(() => assignCms()).Wait();
        }
        public async void assignCms()
        {
            try
            {
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM015");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM015");
                }
                // objCMS = await App.Database.GetCmsAsyncAccessId("RM010");
                assignContent();
            }
            catch (Exception ex)
            {
                string strErrorMsg = ex.Message.ToString();
               App.Current.MainPage?.DisplayToastAsync(ex.Message);
            }
        }
        public void assignContent()
        {

          
            LblAboutRsgt = dbLayer.getCaption("strAboutRSGT", objCMS);
            IsVisibleAboutRSGTEn = true;
            IsVisibleAboutRSGTArb = false;
            if (App.gblLanguage == "Ar")
            {
                IsVisibleAboutRSGTEn = false;
                IsVisibleAboutRSGTArb = true;
            }
            AboutRSGTtext = "Red Sea Gateway Terminal(RSGT) is the newest flagship container terminal at Jeddah Islamic Port, a world-class terminal spearheaded by the Saudi Industrial Services group SISCO, as well as the first privately funded BOT(Build Operate and Transfer) development project in Saudi Arabia with investment of USD 1.7 Billion up to 2050.\n\nRSGT is an international terminal operator representing a partnership between the Red Sea Gateway Terminal of Saudi Arabia and the Malaysian Mining Company (MMC). The combined assets, handling capacity and experience place the terminal operations among the ten largest container terminal operators globally, with a combined annual handling capacity of 20 million TEUs, and equity-weighted throughput of over 10 million TEUS.\n\nLocated at the Port of Jeddah, the Red Sea Gateway Terminal was established in 2009 as Saudi Arabia's first private sector Build-Operate-Transfer project. Currently, with an annual container throughput capacity of 5.2 million TEUs, RSGT is providing world-class integrated logistics solutions, port operations in one of the world's 40 busiest container ports and serves as an engine of growth for both local and regional economies.";
            AboutRSGTtextArb = "محطة بوابة البحر الأحمر (RSGT) هي أحدث محطة حاويات رئيسية في ميناء جدة الإسلامي ، وهي محطة عالمية المستوى تقودها مجموعة الخدمات الصناعية السعودية SISCO ، بالإضافة إلى أول مشروع تطوير BOT (بناء وتشغيل ونقل) ممول من القطاع الخاص في المملكة العربية السعودية العربية باستثمارات 1.7 مليار دولار حتى 2050.\n\nمحطة بوابة البحر الأحمر هي مشغل محطات دولي يمثل شراكة بين محطة بوابة البحر الأحمر في المملكة العربية السعودية وشركة التعدين الماليزية (MMC). تضع الأصول المجمعة وسعة المناولة والخبرة عمليات المحطة بين أكبر عشرة مشغلين لمحطات الحاويات على مستوى العالم ، مع قدرة معالجة سنوية مجمعة تبلغ 20 مليون حاوية مكافئة ، وإنتاجية مرجحة بالأسهم تزيد عن 10 ملايين حاوية مكافئة.\n\nيقع في ميناء جدة ، تم إنشاء محطة بوابة البحر الأحمر في عام 2009 كأول مشروع بناء وتشغيل ونقل للقطاع الخاص في المملكة العربية السعودية. في الوقت الحالي ، مع قدرة إنتاجية سنوية للحاويات تبلغ 5.2 مليون حاوية مكافئة ، توفر RSGT حلول لوجستية متكاملة على مستوى عالمي وعمليات الموانئ في واحد من أكثر 40 ميناء للحاويات ازدحامًا في العالم وتعمل كمحرك للنمو للاقتصادات المحلية والإقليمية.";
        }
    }
}
