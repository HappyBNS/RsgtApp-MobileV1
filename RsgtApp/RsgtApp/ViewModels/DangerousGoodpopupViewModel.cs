using Microsoft.AppCenter.Analytics;
using RsgtApp.BusinessLayer;
using RsgtApp.Helpers;
using RsgtApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using static RsgtApp.Models.Tracking;

namespace RsgtApp.ViewModels
{
    public class DangerousGoodpopupViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
       // private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        //To create bussinessLayer Object
        BLConnect objcon = new BLConnect();    
        //Buttondismisspopup Button 
        public Command Buttondismisspopup { get; set; }
        private List<BasicTrakingDetail> lstTracking = new List<BasicTrakingDetail>();
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
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


        //Twoway Binding Property
        //To handle Boolen variable
        private bool stackDangerousgoodpopup = true;
        public bool StackDangerousgoodpopup
        {
            get { return stackDangerousgoodpopup; }
            set
            {
                stackDangerousgoodpopup = value;
                OnPropertyChanged();
                RaisePropertyChange("stackDangerousgoodpopup");
            }
        }

        //imgDangerred purpose of using Label varaiable
        private string imgDangerred = "";
        public string ImgDangerred
        {
            get { return imgDangerred; }
            set
            {
                ImgDangerred = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgDangerred");
            }
        }
        //lblDangerousGoodDetails purpose of using Label varaiable
        private string lblDangerousGoodDetails = "";
        public string LblDangerousGoodDetails
        {
            get { return lblDangerousGoodDetails; }
            set
            {
                lblDangerousGoodDetails = value;
                OnPropertyChanged();
                RaisePropertyChange("LblDangerousGoodDetails");
            }
        }
        //lblMessage purpose of using Label varaiable
        private string lblMessage = "";
        public string LblMessage
        {
            get { return lblMessage; }
            set
            {
                lblMessage = value;
                OnPropertyChanged();
                RaisePropertyChange("LblMessage");
            }
        }
        //btnOk purpose of using Label varaiable
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
                Buttondismisspopup.ChangeCanExecute();

            }
        }
        /// <summary>
        /// To bind CMS captions
        /// </summary>
        public DangerousGoodpopupViewModel()
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("DangerousGoodpopupViewModel");
            //Begin-Call Caption Function
            Task.Run(() => assignCms()).Wait();
            //End-Caption Function
            //Begin-All Command Buttons
            Buttondismisspopup = new Command(async () => await buttondismisspopup(), () => !IsBusy);
            //End-All Command Buttons
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
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM013");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM013");

                    // objCMSMSG = await dbLayer.LoadContent("RM026");
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
        /// To assign CMS Content respect Captions
        /// </summary>
        public async void assignContent()
        {
            
            //enumDirection = FlowDirection.LeftToRight;
            //if (strLanguage == "Ar")
            //{
            //    enumDirection = FlowDirection.RightToLeft;
                
            //}

          
            dbLayer.objInfoitems = objCMS;
            await Task.Delay(1000);
            ImgDangerred = dbLayer.getCaption("imgDangerred", objCMS);
            LblDangerousGoodDetails = dbLayer.getCaption("strDamagedGoodsDetail", objCMS);
            LblMessage = dbLayer.getCaption("strDangerousApprovalDispatch", objCMS);
            BtnOk = dbLayer.getCaption("strOk", objCMS);
       }

        /// <summary>
        /// Dismisspopup Button Function
        /// </summary>
        /// <returns></returns>
        private async Task buttondismisspopup()
        {
            IsBusy = true;
            StackDangerousgoodpopup = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new Containerlist(gblBol.strgblBolNo, "", "", "", "", "", "", "", "","N"));
            StackDangerousgoodpopup = true;
            IsBusy = false;
            //Dismiss(null);
        }
    }
}
