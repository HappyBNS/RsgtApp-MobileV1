using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;

namespace RsgtApp.ViewModels
{
     public class GenerateInvoicepopupViewModel: INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
     //   private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        //Button_dismisspopup Button 
        public Command Button_dismisspopup { get; set; }
        //btnClicked Button 
        public Command btnClicked { get; set; }
        //Property Changed Event Handler
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
        //To Declare IndicatorBGColor Variable
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
        //To Declare indicatorBGOpacity Variable
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
        //imgGenerateInvoice purpose of using image varaiable
        private string imgGenerateInvoice = "";
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
        private string lblDearCustomer = "";
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
        //lblInvoiceMsg purpose of using label varaiable
        private string lblInvoiceMsg = "";
        public string LblInvoiceMsg
        {
            get { return lblInvoiceMsg; }
            set
            {
                lblInvoiceMsg = value;
                OnPropertyChanged();
                RaisePropertyChange("LblInvoiceMsg");
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
        //To handle boolean variable
        private bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
                RaisePropertyChange("IsBusy");
                Button_dismisspopup.ChangeCanExecute();
                btnClicked.ChangeCanExecute();
            }
        }
        //To handle boolean variable
        private bool stackGeneratInvoice = true;
        public bool StackGeneratInvoice
        {
            get { return stackGeneratInvoice; }
            set
            {
                stackGeneratInvoice = value;
                OnPropertyChanged();
                RaisePropertyChange("StackGeneratInvoice");
            }
        }
        /// <summary>
        /// Begin-ViewModel Constructor 
        /// </summary>
        public GenerateInvoicepopupViewModel()
        {
            //Caption Function
            Task.Run(() => assignCms()).Wait();
            Task.Run(() => assignContent()).Wait();
            //Begin-All Command Buttons
            Button_dismisspopup = new Command(async () => await buttondismisspopup(), () => !IsBusy);
            btnClicked = new Command(async () => await BtnClicked(), () => !IsBusy);
            //End-All Command Buttons
        }
        ///End-ViewModel Constructor 
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
                }
                assignContent();
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message);
            }
        }
        /// <summary>
        /// To assign CMS Content respect Captions
        /// </summary>
        public async void assignContent()
        {
            await Task.Delay(1000);

            
            //enumDirection = FlowDirection.LeftToRight;
            //if (strLanguage == "Ar")
            //{
            //    enumDirection = FlowDirection.RightToLeft;
                
            //}
            ImgGenerateInvoice = dbLayer.getCaption("imgGenerateinvoiceConfirm", objCMS);
            LblDearCustomer = dbLayer.getCaption("strDearCustomer", objCMS);
            LblInvoiceMsg = dbLayer.getCaption("strThankYouforinvoicegeneration", objCMS);
            if (gblRegisteration.strGenerateInvoiceflag == "CLEARING AGENT")
            {
                lblInvoiceMsg = dbLayer.getCaption("strNTClearingAgentNotificationmsg", objCMS);
            }
            if (gblRegisteration.strGenerateInvoiceflag == "BROKER")
            {
                lblInvoiceMsg = dbLayer.getCaption("strNTBrokerNotificationmsg", objCMS);
            }

            BtnOk = dbLayer.getCaption("strOk", objCMS); 
        }
        /// <summary>
        /// dismisspopup Button Function
        /// </summary>
        /// <returns></returns>
        private async Task buttondismisspopup()
        {
            IsBusy = true;
            StackGeneratInvoice = false;
            await Task.Delay(1000);
            Application.Current.MainPage?.Navigation.PopToRootAsync();
            StackGeneratInvoice = true;
            IsBusy = false;
            //Application.Current.MainPage?.Navigation.PopAsync();
            //Application.Current.MainPage? = new AppShell();
            //Dismiss(null);
        }
        /// <summary>
        /// BtnClicked Button Function
        /// </summary>
        /// <returns></returns>
        private async Task BtnClicked()
        {
            IsBusy = true;
            StackGeneratInvoice = false;
            await Task.Delay(1000);
            Application.Current.MainPage?.Navigation.PopToRootAsync();
            StackGeneratInvoice = true;
            IsBusy = false;
            //Application.Current.MainPage?.Navigation.PopAsync();
            //Application.Current.MainPage? = new AppShell();
        }
    }
}