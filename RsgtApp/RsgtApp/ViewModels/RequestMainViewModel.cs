using Microsoft.AppCenter.Analytics;
using RsgtApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;

namespace RsgtApp.ViewModels
{
    public class RequestMainViewModel : INotifyPropertyChanged
    {
        //CMS Caption List
        private List<InfoItem> objCMS = new List<InfoItem>();
        private Dictionary<string, string[]> pageContent = new Dictionary<string, string[]>();
      //  private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        //TicketTapped button
        public Command TicketTapped { get; set; }
        //Inquiryrequest button
        public Command Inquiryrequest { get; set; }
        //Servicerequest button
        public Command Servicerequest { get; set; }
        //Complaintrequest button
        public Command Complaintrequest { get; set; }
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
        //imgRequesticon purpose of using image varaiable
        private string imgRequesticon = "";
        public string ImgRequesticon
        {
            get { return imgRequesticon; }
            set
            {
                imgRequesticon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgRequesticon");
            }
        }
        //lblRequests purpose of using label varaiable
        private string lblRequests = "";
        public string LblRequests
        {
            get { return lblRequests; }
            set
            {
                lblRequests = value;
                OnPropertyChanged();
                RaisePropertyChange("LblRequests");
            }
        }
        //imgTicketIcon purpose of using image varaiable
        private string imgTicketIcon = "";
        public string ImgTicketIcon
        {
            get { return imgTicketIcon; }
            set
            {
                imgTicketIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgTicketIcon");
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
            }
        }
        //lblTickets purpose of using label varaiable
        private string lblTickets = "";
        public string LblTickets
        {
            get { return lblTickets; }
            set
            {
                lblTickets = value;
                OnPropertyChanged();
                RaisePropertyChange("LblTickets");
            }
        }
        //imgBellIcon purpose of using image varaiable
        private string imgBellIcon = "";
        public string ImgBellIcon
        {
            get { return imgBellIcon; }
            set
            {
                imgBellIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgBellIcon");
            }
        }
        //imgRequestInfo purpose of using image varaiable
        private string imgRequestInfo = "";
        public string ImgRequestInfo
        {
            get { return imgRequestInfo; }
            set
            {
                imgRequestInfo = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgRequestInfo");
            }
        }
        //lblRequestForInfo purpose of using label varaiable
        private string lblRequestForInfo = "";
        public string LblRequestForInfo
        {
            get { return lblRequestForInfo; }
            set
            {
                lblRequestForInfo = value;
                OnPropertyChanged();
                RaisePropertyChange("LblRequestForInfo");
            }
        }
        //imgRequestService purpose of using label varaiable
        private string imgRequestService = "";
        public string ImgRequestService
        {
            get { return imgRequestService; }
            set
            {
                imgRequestService = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgRequestService");
            }
        }
        //lblRequestForService purpose of using label varaiable
        private string lblRequestForService = "";
        public string LblRequestForService
        {
            get { return lblRequestForService; }
            set
            {
                lblRequestForService = value;
                OnPropertyChanged();
                RaisePropertyChange("LblRequestForService");
            }
        }
        //imgComplaintIcon purpose of using image varaiable
        private string imgComplaintIcon = "";
        public string ImgComplaintIcon
        {
            get { return imgComplaintIcon; }
            set
            {
                imgComplaintIcon = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgComplaintIcon");
            }
        }
        //lblFileaComplaint purpose of using label varaiable
        private string lblFileaComplaint = "";
        public string LblFileaComplaint
        {
            get { return lblFileaComplaint; }
            set
            {
                lblFileaComplaint = value;
                OnPropertyChanged();
                RaisePropertyChange("LblFileaComplaint");
            }
        }
        //To boolean variable
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
        //To boolean variable   
        bool mainEn = true;
        public bool MainEn
        {
            get { return mainEn; }
            set
            {
                mainEn = value;
                OnPropertyChanged();
                RaisePropertyChange("MainEn");
            }
        }
        /// <summary>
        /// ViewModel Constructor 
        /// </summary>
        public RequestMainViewModel()
        {
            try
            {
                //Appcenter Track Event handler
                Analytics.TrackEvent("RequestMainViewModel");
                //To Call Caption Function 
                Task.Run(() => assignCms()).Wait();
                //Begin call Command Buttons
                TicketTapped = new Command(async () => await Ticket_Tapped(), () => !IsBusy);
                Inquiryrequest = new Command(async () => await Inquiry_request(), () => !IsBusy);
                Servicerequest = new Command(async () => await Service_request(), () => !IsBusy);
                Complaintrequest = new Command(async () => await Complaint_request(), () => !IsBusy);
                //End call Command Buttons
            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message.ToString(), 3000);
            }
        }
        //End TicketMainViewModel function
        /// <summary>
        /// To bind CMS captions
        /// </summary>
        public async void assignCms()
        {
            try
            {
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM440");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM440");
                }
                assignContent();
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message.ToString(), 3000);
            }
        }
        //End assignCms function
        /// <summary>
        /// Function for caption and flowdirection (English - lefttoright / Arabic - righttoleft)
        /// </summary>
        public async void assignContent()
        {
            try
            {
                await Task.Delay(1000);

                //enumDirection = FlowDirection.LeftToRight;
                //if (strLanguage == "Ar")
                //{
                //    enumDirection = FlowDirection.RightToLeft;

                //}

                dbLayer.objInfoitems = objCMS;
                ImgRequesticon = dbLayer.getCaption("imgRequest", objCMS);
                LblRequests = dbLayer.getCaption("strRequest", objCMS);
                ImgTicketIcon = dbLayer.getCaption("imgTicket", objCMS);
                LblTickets = dbLayer.getCaption("strTickets", objCMS);
                ImgBellIcon = dbLayer.getCaption("imgBell", objCMS);
                ImgRequestInfo = dbLayer.getCaption("imgRequestInfo", objCMS);
                ImgRequestService = dbLayer.getCaption("imgRequestService", objCMS);
                ImgComplaintIcon = dbLayer.getCaption("imgComplaint", objCMS);
                LblFileaComplaint = dbLayer.getCaption("strFileComplaint", objCMS);
                LblRequestForInfo = dbLayer.getCaption("strRequestforInfo", objCMS);
                LblRequestForService = dbLayer.getCaption("strRequestforService", objCMS);
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message.ToString(), 3000);
            }
        }
        //End assignContent function
        //To click Ticket_Tapped button 
        /// <summary>
		/// To Navigate Request_TicketsList Screen
		/// </summary>
        public async Task Ticket_Tapped()
        {
            try
            {
                MainEn = false;
                IsBusy = true;
                await Task.Delay(1000);
                Application.Current.MainPage?.Navigation.PushAsync(new Request_TicketsList("", "", "", "", "", "N"));
                MainEn = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message.ToString(), 3000);
            }
        }
        //To click Inquiry_request button
        /// <summary>
		/// To Navigate Inquiry_request Screen
		/// </summary>
        public async Task Inquiry_request()
        {
            try
            {
                MainEn = false;
                IsBusy = true;
                await Task.Delay(1000);
                Application.Current.MainPage?.Navigation.PushAsync(new Inquiry_request());
                MainEn = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message.ToString(), 3000);
            }
        }
        //To click Service_request button
        /// <summary>
        /// To Navigate Service_request Screen
        /// </summary>
        public async Task Service_request()
        {
            try
            {
                MainEn = false;
                IsBusy = true;
                await Task.Delay(1000);
                Application.Current.MainPage?.Navigation.PushAsync(new Service_Request());
                MainEn = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message.ToString(), 3000);
            }
        }
        //To click Complaint_request Button
        /// <summary>
        /// To Navigate Complaint_request Screen
        /// </summary>
        public async Task Complaint_request()
        {
            try
            {
                MainEn = false;
                IsBusy = true;
                await Task.Delay(1000);
                Application.Current.MainPage?.Navigation.PushAsync(new Complaint_request());
                MainEn = true;
                IsBusy = false;
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message.ToString(), 3000);
            }
        }
    }
}
