using Microsoft.AppCenter.Analytics;
using RsgtApp.BusinessLayer;
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
    public class ContainerPDFMsgViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMSG = new List<InfoItem>();
        
        private string strLanguage = App.gblLanguage;
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        //ClickedOk Button 
        public Command ClickedOk { get; set; }
        //Property Changed Event Handler
        public event PropertyChangedEventHandler PropertyChanged;
        // Twowaybinding process on Propertychange Event
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        // Twowaybinding process on RaisePropertyChange Event
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

        //To handle Boolen variable
        private bool stackContainerPDFMsg = true;
        public bool StackContainerPDFMsg
        {
            get { return stackContainerPDFMsg; }
            set
            {
                stackContainerPDFMsg = value;
                OnPropertyChanged();
                RaisePropertyChange("StackContainerPDFMsg");
            }
        }

        //imgSearch purpose of using image varaiable
        private string imgConfirmtick = "";
        public string ImgConfirmtick
        {
            get { return imgConfirmtick; }
            set
            {
                imgConfirmtick = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgConfirmtick");
            }
        }

        //lbldearCustomer purpose of using lable varaiable
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

        //lblfurtherCoordination purpose of using lable varaiable
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

        //btnOk purpose of using lable varaiable
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

        //To handle Boolen variable
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;

                OnPropertyChanged();
                RaisePropertyChange("IsBusy");
                ClickedOk.ChangeCanExecute();


            }
        }
        /// <summary>
        /// Begin-ViewModel Constructor
        /// </summary>
        public ContainerPDFMsgViewModel()
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("ContainerPDFMsgViewModel");
            //Caption Function
            Task.Run(() => assignCms()).Wait();
            //Command Buttons
            ClickedOk = new Command(async () => await clickedOk(), () => !IsBusy);
        }
        //End-ViewModel Constructor 

        /// <summary>
        /// To bind CMS captions
        /// </summary>
        public async void assignCms()
        {
            try
            {
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM026");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM026");
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
        public  void assignContent()
        {
            try
            {

                dbLayer.objInfoitems = objCMS;
                ImgConfirmtick = dbLayer.getCaption("imgConfirmTick", objCMS);
                lblDearCustomer = dbLayer.getCaption("strDearcustomer", objCMS);
                lblFurtherCoordination = dbLayer.getCaption("strContainerpdfmessage", objCMS);
                BtnOk = dbLayer.getCaption("strOk", objCMS);

            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message);
            }
        }

        /// <summary>
        /// clickedOk Button Function
        /// </summary>
        /// <returns></returns>
        private async Task clickedOk()
        {
            try
            {
                IsBusy = true;
                StackContainerPDFMsg = false;
                await Task.Delay(1000);
                await Shell.Current.GoToAsync("..");
                StackContainerPDFMsg = true;
                IsBusy = false;

                //Application.Current.MainPage?.Navigation.PopToRootAsync();
                // Navigation.PushAsync(new Containerdetail(gblContainer.strgblContainerNo,gblContainer.strgblBolNo,gblContainer.strgblBaynanNo));

            }
            catch (Exception ex)
            {

               App.Current.MainPage?.DisplayToastAsync(ex.Message);
            }
        }
    }
}
