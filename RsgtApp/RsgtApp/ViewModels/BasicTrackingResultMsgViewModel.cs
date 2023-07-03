﻿using Microsoft.AppCenter.Analytics;
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
    public class BasicTrackingResultMsgViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
       
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        //ButtonClicked Button 
        public Command ButtonClicked { get; set; }
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
        private bool stackBasicTrackingResultMsg = true;
        public bool StackBasicTrackingResultMsg
        {
            get { return stackBasicTrackingResultMsg; }
            set
            {
                stackBasicTrackingResultMsg = value;
                OnPropertyChanged();
                RaisePropertyChange("StackBasicTrackingResultMsg");
            }
        }
        //imgRegisterIcon purpose of using image varaiable
        private string imgRegisterIcon = "";
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
        //lbldearCustomer purpose of using Label varaiable
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
        //lblmessage purpose of using Label varaiable
        private string lblmessage = "";
        public string lblMessage
        {
            get { return lblmessage; }
            set
            {
                lblmessage = value;
                OnPropertyChanged();
                RaisePropertyChange("lblMessage");
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
        //To Declare Indicator
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
                RaisePropertyChange("IsBusy");
                ButtonClicked.ChangeCanExecute();
            }
        }
        /// <summary>
        /// Begin-ViewModel Constructor 
        /// </summary>
        public BasicTrackingResultMsgViewModel()
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("BasicTrackingResultMsgViewModel");
            //To Call Caption Function   
            Task.Run(() => assignCms()).Wait();
            //Begin-All Command Buttons
            ButtonClicked = new Command(async () => await buttonClicked(), () => !IsBusy);
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
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM010");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM010");
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
                      
            ImgRegisterIcon = dbLayer.getCaption("imgRegistericon", objCMS);
            lblDearCustomer = dbLayer.getCaption("strCustomer", objCMS);
            lblMessage = dbLayer.getCaption("strBTrackingMessage", objCMS);
            BtnOk = dbLayer.getCaption("strOk", objCMS);
        }
        /// <summary>
        /// Clicked Button Function
        /// </summary>
        /// <returns></returns>
        private async Task buttonClicked()
        {
            IsBusy = true;
            StackBasicTrackingResultMsg = false;
            await Task.Delay(1000);
            Application.Current.MainPage?.Navigation.PopToRootAsync();
            StackBasicTrackingResultMsg = true;
            IsBusy = false;
        }
    }
}
