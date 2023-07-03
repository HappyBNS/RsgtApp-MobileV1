using RsgtApp.BusinessLayer;
using RsgtApp.Helpers;
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
    public class ActionpopupViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();
       
        //To create bussinessLayer Object
        BLConnect objCon = new BLConnect();
        WebApiMethod objWebApi = new WebApiMethod();
        private string strServerSlowMsg = "";
       
       
        public object PopupNavigation { get; private set; }
        //ButtonInvoicePayment Button 
        public Command ButtonInvoicePayment { get; set; }
        //ButtonBookAppointment Button 
        public Command ButtonBookAppointment { get; set; }
        //ButtonGenerateInvoice Button 
        public Command ButtonGenerateInvoice { get; set; }
        //Buttondismisspopup Button 
        public Command Buttondismisspopup { get; set; }
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
        //lblSelectAnAction purpose of using Label varaiable
        private string lblSelectAnAction = "";
        public string LblSelectAnAction
        {
            get { return lblSelectAnAction; }
            set
            {
                lblSelectAnAction = value;
                OnPropertyChanged();
                RaisePropertyChange("LblSelectAnAction");
            }
        }
        //btnPayInvoice purpose of using Label varaiable
        private string btnPayInvoice = "";
        public string BtnPayInvoice
        {
            get { return btnPayInvoice; }
            set
            {
                btnPayInvoice = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnPayInvoice");
            }
        }
        //btnBookAnAppointment purpose of using Label varaiable
        private string btnBookAnAppointment = "";
        public string BtnBookAnAppointment
        {
            get { return btnBookAnAppointment; }
            set
            {
                btnBookAnAppointment = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnBookAnAppointment");
            }
        }
        //btnGenerateInvoice purpose of using Label varaiable
        private string btnGenerateInvoice = "";
        public string BtnGenerateInvoice
        {
            get { return btnGenerateInvoice; }
            set
            {
                btnGenerateInvoice = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnGenerateInvoice");
            }
        }
        //btnCancel purpose of using Label varaiable
        private string btnCancel = "";
        public string BtnCancel
        {
            get { return btnCancel; }
            set
            {
                btnCancel = value;
                OnPropertyChanged();
                RaisePropertyChange("BtnCancel");
            }
        }
        //To handle Boolen variable
        private bool stackActionpopup = true;
        public bool StackActionpopup
        {
            get { return stackActionpopup; }
            set
            {
                stackActionpopup = value;
                OnPropertyChanged();
                RaisePropertyChange("StackActionpopup");
            }
        }
        //To handle Boolen variable
        private bool bookanAppointmentflag = false;
        public bool bookanappointmentflag
        {
            get { return bookanAppointmentflag; }
            set
            {
                bookanAppointmentflag = value;
                OnPropertyChanged();
                RaisePropertyChange("bookanappointmentflag");
            }
        }
        private bool payinvoiceFlag = false;
        public bool PayinvoiceFlag
        {
            get { return payinvoiceFlag; }
            set
            {
                payinvoiceFlag = value;
                OnPropertyChanged();
                RaisePropertyChange("PayinvoiceFlag");
            }
        }

        
        //To Declare Indicator
        private bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
                RaisePropertyChange("IsBusy");
                ButtonInvoicePayment.ChangeCanExecute();
                ButtonBookAppointment.ChangeCanExecute();
                ButtonGenerateInvoice.ChangeCanExecute();
                Buttondismisspopup.ChangeCanExecute();
            }
        }
        /// <summary>
        /// Begin-ViewModel Constructor 
        /// </summary>
        public ActionpopupViewModel()
        {
            //To Call Caption Function  
            Task.Run(() => assignCms()).Wait();
            //Begin-All Command Buttons
            ButtonInvoicePayment = new Command(async () => await buttonInvoicePayment(), () => !IsBusy);
            ButtonBookAppointment = new Command(async () => await buttonBookAppointment(), () => !IsBusy);
            ButtonGenerateInvoice = new Command(async () => await buttonGenerateInvoice(), () => !IsBusy);
            Buttondismisspopup = new Command(async () => await buttondismisspopup(), () => !IsBusy);


            //End-All Command Buttons

            // handling button visibility based conditions
            //
            //
            // var bl_payinvoiceflag = "N";
            // var bl_bookanappointmentflag = "N";
            PayinvoiceFlag = false;
            bookanappointmentflag = false;
            foreach (var item in gblBol.lstInvoice)
            {
                if (item.isChecked == true)
                {
                    if (item.payinvoiceflag == "Y")
                    {
                        PayinvoiceFlag = true;
                      
                    }
                    if (item.bookanappointmentflag == "Y")
                    {

                        bookanappointmentflag = true;
                    }
                }
            }
        }
        //End-ViewModel Constructor 
        /// <summary>
        /// To bind CMS captions
        /// </summary>
        public async void assignCms()
        {
            if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
            {
                objCMS = await App.Database.GetCmsAsyncAccessId("RM029");
                objCMSMsg = await dbLayer.LoadContent("RM026");
            }
            if (App.gblCMSSource.ToUpper().Trim() == "JSON")
            {
                objCMS = await dbLayer.LoadContent("RM029");
                objCMSMsg = await dbLayer.LoadContent("RM026");
            }
            assignContent();
        }
        /// <summary>
        /// To assign CMS Content respect Captions
        /// </summary>
        public async void assignContent()
        {
            await Task.Delay(1000);

            dbLayer.objInfoitems = objCMS;
            LblSelectAnAction = dbLayer.getCaption("strSelectAction", objCMS);
            BtnPayInvoice = dbLayer.getCaption("strPayinvoice", objCMS);
            BtnBookAnAppointment = dbLayer.getCaption("strBookanAppointment", objCMS);
            BtnGenerateInvoice = dbLayer.getCaption("strGenerateInvoice", objCMS);
            BtnCancel = dbLayer.getCaption("strCancel", objCMS);

            strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);
        }
        /// <summary>
        /// Dismisspopup Button Function
        /// </summary>
        /// <returns></returns>
        private async Task buttondismisspopup()
        {
            IsBusy = true;
            StackActionpopup = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new InvoiceandPayment("", "", "", "", "", "Ready to pay", "", "", "", "", "", "", "","N"));
            StackActionpopup = true;
            IsBusy = false;
        }
        /// <summary>
        /// GenerateInvoice Button Function
        /// </summary>
        /// <returns></returns>
        private async Task buttonGenerateInvoice()
        {
            try
            {
                IsBusy = true;
                StackActionpopup = false;
                await Task.Delay(1000);
                string lstrInputJson = "";
                string lstrResult = "";
                string lstrIDNO = "";
                string lstrFlag = "N";
                if (gblBol.lstInvoice.Count > 0)
                {
                    lstrIDNO = gblRegisteration.strIdNo;
                    foreach (var item in gblBol.lstInvoice)
                    {
                        if (item.isChecked == true)
                        {
                            lstrFlag = "Y";
                            lstrInputJson = "{\"PA_API\": \"generate Invoice\",\"PA_STATUS\": \"Requested\",\"PA_PARAMETERS\": \"{'Invoice':{'billOfLading':'" + item.BOL + "','ID':'" + lstrIDNO + "','Language':'EN','Command':'Generate'}}\"}";
                            lstrResult = objWebApi.postWebApi("GenerateInvoice", lstrInputJson);
                            string strJson = "{ \"BL_BOLSTATUSCODE\":\"IN_UP\" }";
                            string lstrBolNo = item.BOL;
                            lstrBolNo = lstrBolNo.Replace("/", "^");
                            lstrResult = objWebApi.putWebApi("UpdateBOLStatus", strJson, lstrBolNo);
                        }
                    }
                }
                if (lstrFlag == "Y")
                {
                    objWebApi.postWebApi("PostSendEmail", gblTrackRequests.GenerateInvoiceeMailData());
                    if (AppSettings.ErrorExceptionWebApi != "")
                    {
                       App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                    }
                    await App.Current.MainPage?.Navigation.PushAsync(new Generateinvoice_popup());
                }
                if (lstrFlag == "N")
                {
                   App.Current.MainPage?.DisplayToastAsync("Please select one invoice", 3000);
                }

            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            StackActionpopup = true;
            IsBusy = false;
        }
        /// <summary>
        /// InvoicePayment Button Function
        /// </summary>
        /// <returns></returns>
        private async Task buttonInvoicePayment()
        {
            try
            {
                IsBusy = true;
                StackActionpopup = false;
                await Task.Delay(1000);
                string lstrPayInvoiceBLNo = "";
                string lstrNotExistDraftNo = "";
                string lstrFlag = "N";
                foreach (var item in gblBol.lstInvoice)
                {
                    if (item.isChecked == true)
                    {

                        lstrFlag = "Y";


                        if (item.ProformaInvoice != "")
                        {
                            //fstrDraftNo = "1504462";
                            int lintResult = objCon.getDraftNoStatus(item.ProformaInvoice);
                            if (lintResult == 0)
                            {
                                List<string> fstrSql = new List<string>();
                                string strJson = "{ \"BL_BOLSTATUSCODE\":\"\",\"BL_IHINVOICENUMBER\":\"\",\"BL_IHPROFORMAINVOICENUMBER\":\"\",\"BL_IHSTATUS\":\"Cancelled\" }";
                                string lstrResult = objWebApi.putWebApi("UpdateBilloflading", strJson, item.ProformaInvoice);
                                //Web Api Timeout
                                if (AppSettings.ErrorExceptionWebApi != "")
                                {
                                   App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                                }
                                lstrNotExistDraftNo += "," + "'" + item.ProformaInvoice + "'";
                            }

                            if (lintResult > 0)
                            {
                                lstrPayInvoiceBLNo += "," + "'" + item.ProformaInvoice + "'";
                            }

                        }
                    }
                }
                if (lstrNotExistDraftNo.Length > 0)
                {
                    lstrNotExistDraftNo = lstrNotExistDraftNo.Substring(1);
                    gblBol.strgblNotExistDraftNo = "Y";
                }
                if (lstrPayInvoiceBLNo.Length > 0)
                {
                    lstrPayInvoiceBLNo = lstrPayInvoiceBLNo.Substring(1);
                    await App.Current.MainPage?.Navigation.PushAsync(new Payment(lstrPayInvoiceBLNo, "", "Y"));
                    return;
                }

                if (lstrFlag == "N")
                {
                   App.Current.MainPage?.DisplayToastAsync("Please select one invoice", 3000);
                }



            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
            StackActionpopup = true;
            IsBusy = false;
        }
        /// <summary>
        /// BookAppointment Button Function
        /// </summary>
        /// <returns></returns>
        private async Task buttonBookAppointment()
        {
            IsBusy = true;
            StackActionpopup = false;
            await Task.Delay(1000);
            await App.Current.MainPage?.Navigation.PushAsync(new AppointmentBooking("", "", "", "", "", "", "","N"));
            StackActionpopup = true;
            IsBusy = false;
        }
    }
}