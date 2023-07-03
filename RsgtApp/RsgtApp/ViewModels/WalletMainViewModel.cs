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
    public class WalletMainViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMSG = new List<InfoItem>();
       // private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        public Command AddMoneyTapped { get; set; }
        public Command TransactionhistoryTapped { get; set; }
        public Command BtnReset { get; set; }
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

        private bool stackWalletMain = true;
        //lblSar purpose of using Label
        private string lblSar = "";
        public string LblSar
        {
            get { return lblSar; }
            set
            {
                lblSar = value;
                OnPropertyChanged();
                RaisePropertyChange("LblSar");
            }
        }

        private string getWalletBallance = "0.00";
        public string GetWalletBallance
        {
            get { return getWalletBallance; }
            set
            {
                getWalletBallance = value;
                OnPropertyChanged();
                RaisePropertyChange("GetWalletBallance");
            }
        }

        private string getHoldBallance = "0.00";
        public string GetHoldBallance
        {
            get { return getHoldBallance; }
            set
            {
                getHoldBallance = value;
                OnPropertyChanged();
                RaisePropertyChange("GetHoldBallance");
            }
        }

        public bool StackWalletMain
        {
            get { return stackWalletMain; }
            set
            {
                stackWalletMain = value;
                OnPropertyChanged();
                RaisePropertyChange("StackWalletMain");
            }
        }
        private string imgWalletMenuIcon = "";
        public string ImgWalletMenuIcon
        {
            get { return imgWalletMenuIcon; }
            set
            {
                imgWalletMenuIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgWalletMenuIcon");
            }
        }
        private string lblWallet = "";
        public string LblWallet
        {
            get { return lblWallet; }
            set
            {
                lblWallet = value;
                OnPropertyChanged();
                RaisePropertyChange("LblWallet");
            }
        }
        private string imgWallet = "";
        public string ImgWallet
        {
            get { return imgWallet; }
            set
            {
                imgWallet = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgWallet");
            }
        }
        private string lblMyWallet = "";
        public string LblMyWallet
        {
            get { return lblMyWallet; }
            set
            {
                lblMyWallet = value;
                OnPropertyChanged();
                RaisePropertyChange("LblMyWallet");
            }
        }
        private string imgCards = "";
        public string ImgCards
        {
            get { return imgCards; }
            set
            {
                imgCards = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgCards");
            }
        }
        private string lblCards = "";
        public string LblCards
        {
            get { return lblCards; }
            set
            {
                lblCards = value;
                OnPropertyChanged();
                RaisePropertyChange("LblCards");
            }
        }
        private string imgBank = "";
        public string ImgBank
        {
            get { return imgBank; }
            set
            {
                imgBank = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgBank");
            }
        }
        private string lblBankInf = "";
        public string LblBankInf
        {
            get { return lblBankInf; }
            set
            {
                lblBankInf = value;
                OnPropertyChanged();
                RaisePropertyChange("LblBankInf");
            }
        }
        private string imgAddMoney = "";
        public string ImgAddMoney
        {
            get { return imgAddMoney; }
            set
            {
                imgAddMoney = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgAddMoney");
            }
        }
        private string lblAddMoney = "";
        public string LblAddMoney
        {
            get { return lblAddMoney; }
            set
            {
                lblAddMoney = value;
                OnPropertyChanged();
                RaisePropertyChange("LblAddMoney");
            }
        }
        private string imgRefund = "";
        public string ImgRefund
        {
            get { return imgRefund; }
            set
            {
                imgRefund = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgRefund");
            }
        }
        private string lblRefundMoney = "";
        public string LblRefundMoney
        {
            get { return lblRefundMoney; }
            set
            {
                lblRefundMoney = value;
                OnPropertyChanged();
                RaisePropertyChange("LblRefundMoney");
            }
        }
        private string imgTransHistory = "";
        public string ImgTransHistory
        {
            get { return imgTransHistory; }
            set
            {
                imgTransHistory = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgTransHistory");
            }
        }
        private string lblTransHistory = "";
        public string LblTransHistory
        {
            get { return lblTransHistory; }
            set
            {
                lblTransHistory = value;
                OnPropertyChanged();
                RaisePropertyChange("LblTransHistory");
            }
        }
        private string imgReset = "";
        public string ImgReset
        {
            get { return imgReset; }
            set
            {
                imgReset = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgReset");
            }
        }
        private string lblOnhold = "";
        public string lblOnHold
        {
            get { return lblOnhold; }
            set
            {
                lblOnhold = value;
                OnPropertyChanged();
                RaisePropertyChange("lblOnHold");
            }
        }
        private string strServerSlowMsg = "";
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
                AddMoneyTapped.ChangeCanExecute();
                TransactionhistoryTapped.ChangeCanExecute();
                BtnReset.ChangeCanExecute();
            }
        }

        /// <summary>
        /// ViewModel Constructor 
        /// </summary>
        public WalletMainViewModel()
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("WalletMainViewModel");
            Task.Run(() => assignCms()).Wait();
            AddMoneyTapped = new Command(async () => await addMoneyTapped(), () => !IsBusy);
            TransactionhistoryTapped = new Command(async () => await transactionhistoryTapped(), () => !IsBusy);
            BtnReset = new Command(async () => await btnReset(), () => !IsBusy);
            Task.Run(() => getBallance()).Wait();
        }

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
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM427");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM427");

                    objCMSMSG = await dbLayer.LoadContent("RM026");
                }
                //objCMS = await App.Database.GetCmsAsyncAccessId("RM004");
                assignContent();


            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message);
            }
        }
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

            ImgWalletMenuIcon = dbLayer.getCaption("imgWalletMenu", objCMS);
            LblWallet = dbLayer.getCaption("strWallet", objCMS);
            ImgWallet = dbLayer.getCaption("imgWallet", objCMS);
            LblMyWallet = dbLayer.getCaption("strMyWallet", objCMS);
            ImgCards = dbLayer.getCaption("imgCards", objCMS);
            LblCards = dbLayer.getCaption("strCards", objCMS);
            ImgBank = dbLayer.getCaption("imgBank", objCMS);
            LblBankInf = dbLayer.getCaption("strBankInformation", objCMS);
            ImgAddMoney = dbLayer.getCaption("imgAddmoney", objCMS);
            LblAddMoney = dbLayer.getCaption("strAddMoney", objCMS);
            ImgRefund = dbLayer.getCaption("imgRefund", objCMS);
            LblRefundMoney = dbLayer.getCaption("strRefundMoney", objCMS);
            ImgTransHistory = dbLayer.getCaption("imgTransactionhistory", objCMS);
            LblTransHistory = dbLayer.getCaption("strTransactionHistory", objCMS);
            ImgReset = dbLayer.getCaption("imgReset", objCMS);
            lblOnHold = dbLayer.getCaption("strHold", objCMS);
            lblSar = dbLayer.getCaption("strSAR", objCMS);
            strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMSG);

        }
        /// <summary>
        /// To Navigate AddMoneytoWallet Screen
        /// </summary>
        private async Task addMoneyTapped()
        {
            IsBusy = true;
            StackWalletMain = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new AddMoneytoWallet());
            StackWalletMain = true;
            IsBusy = false;
        }
        /// <summary>
        /// Api Calling Function 
        /// </summary>
        /// <returns></returns>
        private async Task getBallance()
        {
            IsBusy = true;
            StackWalletMain = false;
            await Task.Delay(1000);
            string fstrCustomerId = gblRegisteration.strLoginUserLinkcode;
            string fstrCustomerType = gblRegisteration.strLoginCustomerType;
            string lstrWalletBalance = objBl.getbalance(fstrCustomerId, fstrCustomerType);
            string lstrHoldBalance = objBl.getHOLDbalance(fstrCustomerId);
            //Web Api Timeout
            if (AppSettings.ErrorExceptionWebApi != "")
            {
               App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
            }
            GetWalletBallance = lblSar+" "+ Decimal.Parse(lstrWalletBalance).ToString("#,##0.00");
            GetHoldBallance = lblSar + " " + Decimal.Parse(lstrHoldBalance).ToString("#,##0.00"); 
            StackWalletMain = true;
            IsBusy = false;
        }
        /// <summary>
        /// To call the getBallance Function
        /// </summary>
        private async Task btnReset()
        {
            IsBusy = true;
            StackWalletMain = false;
            await Task.Delay(1000);
            await getBallance();
            
            StackWalletMain = true;
            IsBusy = false;

        }
        /// <summary>
        /// To Navigate TransactionHistory Screen
        /// </summary>
        private async Task transactionhistoryTapped()
        {
            IsBusy = true;
            StackWalletMain = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new TransactionHistory("", "", "", "", "","",""));
            StackWalletMain = true;
            IsBusy = false;
        }
        //private void Cards_Tapped(object sender, EventArgs e)
        //{
        //    Navigation.PushAsync(new Cards_submenu());
        //}

        //private void Bank_Tapped(object sender, EventArgs e)
        //{
        //    Navigation.PushAsync(new BankInfo());
        //}

        //private void RefundMoney_Tapped(object sender, EventArgs e)
        //{
        //    Navigation.PushAsync(new RefundMoneytoWallet());
        //}
    }
}
