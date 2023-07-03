using Microsoft.AppCenter.Analytics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using static RsgtApp.Views.FAQ;
using static RsgtApp.Models.FAQDt;
using RsgtApp.Models;
using System.Collections.ObjectModel;

namespace RsgtApp.ViewModels
{
    public class FAQViewModel : INotifyPropertyChanged
    {
        private List<InfoItem> objCMS = new List<InfoItem>();
        private Dictionary<string, string[]> pageContent = new Dictionary<string, string[]>();
     //   private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        public event PropertyChangedEventHandler PropertyChanged;
        // Twowaybinding process on Propertychange Event
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        // Twowaybinding process on Propertychange Event
        public void RaisePropertyChange(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
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
        private bool stackFAQ = true;
        public bool StackFAQ
        {
            get { return stackFAQ; }
            set
            {
                stackFAQ = value;
                OnPropertyChanged();
                RaisePropertyChange("StackDirectDeliveryRequest2");
            }

        }
        private string lbltest = "";
        public string Lbltest
        {
            get { return lbltest; }
            set
            {
                lbltest = value;
                OnPropertyChanged();
                RaisePropertyChange("Lbltest");
            }
        }
        private string faq_Q = "";
        public string Faq_Q
        {
            get { return faq_Q; }
            set
            {
                faq_Q = value;
                OnPropertyChanged();
                RaisePropertyChange("Faq_Q");
            }
        }
        private string Faq_a = "";
        public string Faq_A
        {
            get { return Faq_a; }
            set
            {
                Faq_a = value;
                OnPropertyChanged();
                RaisePropertyChange("Faq_A");
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
        private ObservableCollection<FAQDt> _lstFAQs { get; set; } = new ObservableCollection<FAQDt>();
        public ObservableCollection<FAQDt> lstFAQs
        {
            get { return _lstFAQs; }
            set
            {
                if (_lstFAQs == value)
                    return;
                _lstFAQs = value;
                OnPropertyChanged();
                RaisePropertyChange("lstFAQs");
            }
        }

        /// <summary>
        /// ViewModel- Constructor
        /// </summary>
        public FAQViewModel()
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("FAQViewModel");
            Task.Run(() => assignCms()).Wait();
           
        }
        public int lintLaguageIndex = 0;
        /// <summary>
        /// To bind CMS captions
        /// </summary>
        public async void assignCms()
        {
            try
            {
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM009");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM009");
                }
                assignContent();
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message);
            }
        }
        /// <summary>
        /// Assign Content Method
        /// </summary>
        public  void assignContent()
        {
           
            
            Lbltest = dbLayer.getCaption("strScreenTitle", objCMS);
            fnFAQslist(objCMS);
        }
        /// <summary>
        /// Function for FAQs list
        /// </summary>
        /// <param name="flstFAQ"></param>
        /// <returns></returns>
        private void fnFAQslist(List<InfoItem> flstFAQ)
        {
            var objRawData = flstFAQ;
            lintLaguageIndex = 0;
            if (strLanguage == "Ar")
            {
                lintLaguageIndex = 1;
            }
            foreach (var item in objRawData)
            {
                if (lintLaguageIndex == 0)
                {
                    if ((item.cms_q1 != null) && (item.cms_q1 != ""))
                    {
                        lstFAQs.Add(new FAQDt { Faq_Q = item.cms_q1, Faq_A = item.cms_info1, TotalRowCount = flstFAQ.Count + 1.ToString() });
                    }
                }
                else
                {
                    if ((item.cms_q2 != null) && (item.cms_q2 != ""))
                    {
                        lstFAQs.Add(new FAQDt { Faq_Q = item.cms_q2, Faq_A = item.cms_info2, TotalRowCount = flstFAQ.Count + 1.ToString() });
                    }
                }
            }
        }
        /// <summary>
        /// Expander Tapped Function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Expander_Tapped(object sender, EventArgs e)
        {
            var expander = sender as Expander;
            var lstItemSelected = (FAQDt)((Expander)sender).BindingContext;
            var list = lstFAQs;
            foreach (var item in lstFAQs)
            {
                item.Expander = false;

                if ((lstItemSelected.Faq_A == item.Faq_A) && (expander.IsExpanded == true))
                {
                    item.Expander = true;
                }
            }
        }
    }
}
