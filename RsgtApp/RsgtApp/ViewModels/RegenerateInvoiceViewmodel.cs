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
    public class RegenerateInvoiceViewmodel : INotifyPropertyChanged
    {
        //Property Changed Event Handler
        public event PropertyChangedEventHandler PropertyChanged;
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMSG = new List<InfoItem>();
      //  private FlowDirection enumDirection = FlowDirection.LeftToRight;
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
        private bool StackmyprofileNotifiction = true;
        public bool StackMyprofileNotifiction
        {
            get { return StackmyprofileNotifiction; }
            set
            {
                StackmyprofileNotifiction = value;
                OnPropertyChanged();
                RaisePropertyChange("StackMyprofileNotifiction");
            }
        }

        //imgGenerateInvoice purpose of using image varaiable
        public string imgGenerateInvoice = "";
        public string ImgGenerateInvoice
        {
            get { return imgGenerateInvoice; }
            set
            {
                imgGenerateInvoice = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgGenerateInvoice");
            }
        }

        //lblDearCustomer purpose of using label varaiable
        public string lblDearCustomer = "";
        public string LblDearCustomer
        {
            get { return lblDearCustomer; }
            set
            {
                lblDearCustomer = value;
                OnPropertyChanged();
                RaisePropertyChange("LblDearCustomer");
            }
        }

        //lblGenerationInvoiceMg purpose of using label varaiable
        public string lblGenerationInvoiceMg = "";
        public string LblGenerationInvoiceMg
        {
            get { return lblGenerationInvoiceMg; }
            set
            {
                lblGenerationInvoiceMg = value;
                OnPropertyChanged();
                RaisePropertyChange("LblGenerationInvoiceMg");
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

        //Begin-ViewModel Constructor 
        /// <summary>
        /// ViewModel Constructor 
        /// </summary>
        public RegenerateInvoiceViewmodel()
        {

            //Caption Function
            Task.Run(() => assignCms()).Wait();
            //Appcenter Track Event handler
            Analytics.TrackEvent("RegenerateInvoiceViewmodel");
            //Command Buttons
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
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM028");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM028");
                }
                // objCMS = await App.Database.GetCmsAsyncAccessId("RM010");
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


          
            dbLayer.objInfoitems = objCMS;


            ImgGenerateInvoice = dbLayer.getCaption("imgGenerateInvoice", objCMS);
            LblDearCustomer = dbLayer.getCaption("strDearCustomer", objCMS);
            LblGenerationInvoiceMg = dbLayer.getCaption("strInvoiceGenerateRequestMsg", objCMS);
            BtnOk = dbLayer.getCaption("strOk", objCMS);
        }

        //Dismisspopup Button Function
        /// <summary>
        /// To Navigate InvoiceandPayment Screen
        /// </summary>
        /// <returns></returns>
        private async Task buttondismisspopup()
        {
            IsBusy = true;
            StackMyprofileNotifiction = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new InvoiceandPayment("", "", "", "", "", "", "", "", "", "", "", "", "","N"));
            StackMyprofileNotifiction = true;
            IsBusy = false;
            //Dismiss(null);
        }
    }
}
