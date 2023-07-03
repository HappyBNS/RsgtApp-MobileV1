using Microsoft.AppCenter.Analytics;
using RsgtApp.BusinessLayer;
using RsgtApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;

namespace RsgtApp.ViewModels
{
    public class PayMessageViewModel : INotifyPropertyChanged
    {
        //Property Changed Event Handler
        public event PropertyChangedEventHandler PropertyChanged;

        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();
       // private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private Dictionary<string, string[]> pageContent = new Dictionary<string, string[]>();
        private string strLanguage = App.gblLanguage;
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        //Buttondismisspopup Button 
        public Command Buttondismisspopup { get; set; }

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

        //To handle boolean variable
        private bool StackpayMessage = true;
        public bool StackPayMessage
        {
            get { return StackpayMessage; }
            set
            {
                StackpayMessage = value;
                OnPropertyChanged();
                RaisePropertyChange("StackPayMessage");
            }
        }

        //imgGenerateInvoices purpose of using image varaiable
        public string imgGenerateInvoices = "";
        public string ImgGenerateInvoices
        {
            get { return imgGenerateInvoices; }
            set
            {
                imgGenerateInvoices = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgGenerateInvoices");
            }
        }

        //imgRegisterIcon purpose of using image varaiable
        public string imgRegisterIcon = "";
        public string ImgRegisterIcon
        {
            get { return imgRegisterIcon; }
            set
            {
                imgRegisterIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgRegisterIcon");
            }
        }

        //lblDearCustomers purpose of using label varaiable
        public string lblDearCustomers = "";
        public string LblDearCustomers
        {
            get { return lblDearCustomers; }
            set
            {
                lblDearCustomers = value;
                OnPropertyChanged();
                RaisePropertyChange("LblDearCustomers");
            }
        }

        //lblInvoicesMsg purpose of using label varaiable
        public string lblInvoicesMsg = "";
        public string LblInvoicesMsg
        {
            get { return lblInvoicesMsg; }
            set
            {
                lblInvoicesMsg = value;
                OnPropertyChanged();
                RaisePropertyChange("LblInvoicesMsg");
            }

        }

        //btnOk purpose of using label varaiable
        private string btnOk = "";
        public string BtnOk
        {
            get { return btnOk; }
            set
            {
                btnOk = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnOk");
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
                Buttondismisspopup.ChangeCanExecute();
                
            }
        }
        /// <summary>
        /// ViewModel Constructor 
        /// </summary>
        //Begin-ViewModel Constructor 
        public PayMessageViewModel()
        {
            //Caption Function
            Task.Run(() => assignCms()).Wait();
            //Appcenter Track Event handler
            Analytics.TrackEvent("PayMessageViewModel");
            //Command Function
            Buttondismisspopup = new Command(async () => await buttondismisspopup(), () => !IsBusy);
        }
        //End-ViewModel Constructor 

        //To bind CMS captions
        /// <summary>
        /// To bind CMS captions
        /// </summary>
        public async void assignCms()
        {
            try
            {
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM012");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM012");
                    objCMSMsg = await dbLayer.LoadContent("RM026");
                }
                assignContent();

            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message);
            }
        }

        //To assign CMS Content respect Captions
        /// <summary>
        /// Function for caption and flowdirection (English - lefttoright / Arabic - righttoleft)
		/// </summary>
        public async void assignContent()
        {
            await Task.Delay(1000);
            
            //enumDirection = FlowDirection.LeftToRight;
            //if (strLanguage == "Ar")
            //{
            //    enumDirection = FlowDirection.RightToLeft;
                
            //}


            // dbLayer.lintLanguage = lintIndex;
            //dbLayer.objInfoitems = objCMS;

            ImgGenerateInvoices = dbLayer.getCaption("imgGenerateinvoiceConfirm", objCMS);
            LblDearCustomers = dbLayer.getCaption("strDearCustomer", objCMS);
            BtnOk = dbLayer.getCaption("strOk", objCMS);
            LblInvoicesMsg = dbLayer.getCaption("strNTDraftNumberNotificationmsg", objCMSMsg);

            if (gblBol.strgblNotExistDraftNo == "Y")
            {
                lblInvoicesMsg = dbLayer.getCaption("strNTInvoiceNumberNotificationmsg", objCMSMsg);
            }
        }

        //Dismisspopup Button Function
        /// <summary>
		/// To Navigate BOL Popup
		/// </summary>
        private async Task buttondismisspopup()
        {
            IsBusy = true;
            StackPayMessage = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new BOL("", "", "", "", "", ""));
            StackPayMessage = true;
            IsBusy = false;
        }
    }
}
