using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
namespace RsgtApp.ViewModels
{
    class DamageContainer_MessageViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();
      //  private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        //ClickedMain Button
        public Command ClickedMain { get; set; }
        //Property Changed Event Handler
        public event PropertyChangedEventHandler PropertyChanged;
        // Twowaybinding process on Propertychange Event
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public void RaisePropertyChange(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
        //To handle Boolean variable
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
        //To handle Boolean variable
        private bool damageMsgEn = true;
        public bool DamageMsgEn
        {
            get { return damageMsgEn; }
            set
            {
                damageMsgEn = value;
                OnPropertyChanged();
                RaisePropertyChange("DamageMsgEn");
            }
        }
        //imgconfirmtick purpose of using image varaiable
        private string imgconfirmtick = "";
        public string imgConfirmtick
        {
            get { return imgconfirmtick; }
            set
            {
                imgconfirmtick = value;
                OnPropertyChanged();
                RaisePropertyChange("imgConfirmtick");
            }
        }
        //lbldearCustomer purpose of using text varaiable
        private string lbldearCustomer = "";
        public string lblDearCustomer
        {
            get { return lbldearCustomer; }
            set
            {
                lbldearCustomer = value;
                OnPropertyChanged();
                RaisePropertyChange("lblDearCustomer");
            }
        }
        //lblfurtherCoordination purpose of using text varaiable
        private string lblfurtherCoordination = "";
        public string lblFurtherCoordination
        {
            get { return lblfurtherCoordination; }
            set
            {
                lblfurtherCoordination = value;
                OnPropertyChanged();
                RaisePropertyChange("lblFurtherCoordination");
            }
        }
        //lblok purpose of using text varaiable
        private string lblok = "";
        public string lblOk
        {
            get { return lblok; }
            set
            {
                lblok = value;
                OnPropertyChanged();
                RaisePropertyChange("lblOk");
            }
        }
        //To handle Boolean variable
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
                RaisePropertyChange("IsBusy");
                ClickedMain.ChangeCanExecute();
            }
        }
        /// <summary>
        /// Begin DamageContainer_MessageViewModel Constructor
        /// </summary>
        public DamageContainer_MessageViewModel()
        {
            try
            {
                Task.Run(() => assignCms()).Wait();
                ClickedMain = new Command(() => clickedMain(), () => !IsBusy);
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message);
            }
        }
        /// <summary>
        /// To bind Assign CMS Caption
        /// </summary>
        public async void assignCms()
        {
            try
            {
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM415");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM411");
                    objCMSMsg = await dbLayer.LoadContent("RM415");
                }
                assignContent();
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message);
            }
        }
        /// <summary>
        /// To get CMS Content Caption
        /// </summary>
        public void assignContent()
        {
            try
            {

                //enumDirection = FlowDirection.LeftToRight;
                //if (strLanguage == "Ar")
                //{
                //    enumDirection = FlowDirection.RightToLeft;

                //}

                dbLayer.objInfoitems = objCMS;
                imgConfirmtick = dbLayer.getCaption("imgConfirmTick", objCMSMsg);
                lblDearCustomer = dbLayer.getCaption("strDearCustomer", objCMSMsg);
                lblFurtherCoordination = dbLayer.getCaption("strContactyouSoonMsg", objCMSMsg);
                lblOk = dbLayer.getCaption("strok", objCMSMsg);
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        /// <summary>
        /// To load clickedMain Button
        /// </summary>
        /// <returns></returns>
        private void clickedMain()
        {
            try
            {
                Application.Current.MainPage?.Navigation.PopToRootAsync();
                 
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
    }
}