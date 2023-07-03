using Microsoft.AppCenter.Analytics;
using RsgtApp.BusinessLayer;
using RsgtApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using static RsgtApp.Models.GatePhotoDetailModel;

namespace RsgtApp.ViewModels
{
    public class ContainerPhotoDetailsViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();
        private Dictionary<string, string[]> pageContent = new Dictionary<string, string[]>();
        
        private string strLanguage = App.gblLanguage;
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        private string strServerSlowMsg = "";
        private List<Gatephotodetaildt> lstGatephotodetail { get; set; } = new List<Gatephotodetaildt>();
        public List<Gatephotodetaildt> lstEIRImage { get; set; } = new List<Gatephotodetaildt>();
        //To list of data call in the ObservableCollection
        private ObservableCollection<Gatephotodetaildt> _lstGatePhotoDetails = new ObservableCollection<Gatephotodetaildt>();
        public ObservableCollection<Gatephotodetaildt> lstGatePhotoDetails
        {
            get { return _lstGatePhotoDetails; }
            set
            {
                if (_lstGatePhotoDetails == value)
                    return;

                _lstGatePhotoDetails = value;
                OnPropertyChanged();
                RaisePropertyChange("lstGatePhotoDetails");
            }
        }
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
        //To handle Indicator
        private bool stackGatePhotoDetail = true;
        public bool StackGatePhotoDetail
        {
            get { return stackGatePhotoDetail; }
            set
            {
                stackGatePhotoDetail = value;
                OnPropertyChanged();
                RaisePropertyChange("StackGatePhotoDetail");
            }
        }
        //ImgEIRIconblue purpose of using Image Variable
        private string imgEIRIconblue = "";
        public string ImgEIRIconblue
        {
            get { return imgEIRIconblue; }
            set
            {
                imgEIRIconblue = value;
                OnPropertyChanged();
                RaisePropertyChange("ImgEIRIconblue");
            }
        }
        //LblGatePhotoDetail purpose of using Label Variable
        private string lblGatePhotoDetail = "";
        public string LblGatePhotoDetail
        {
            get { return lblGatePhotoDetail; }
            set
            {
                lblGatePhotoDetail = value;
                OnPropertyChanged();
                RaisePropertyChange("LblGatePhotoDetail");
            }
        }
        //LblBOL purpose of using Label Variable
        private string lblBOL = "";
        public string LblBOL
        {
            get { return lblBOL; }
            set
            {
                lblBOL = value;
                OnPropertyChanged();
                RaisePropertyChange("LblBOL");
            }
        }
        //LblRequestDate purpose of using Label Variable
        private string lblRequestDate = "";
        public string LblRequestDate
        {
            get { return lblRequestDate; }
            set
            {
                lblRequestDate = value;
                OnPropertyChanged();
                RaisePropertyChange("LblRequestDate");
            }
        }
        //LblValBol purpose of using data Variable
        private string lblValBol = "";
        public string LblValBol
        {
            get { return lblValBol; }
            set
            {
                lblValBol = value;
                OnPropertyChanged();
                RaisePropertyChange("LblValBol");
            }
        }
        //LblValRequestDate purpose of using data Variable
        private string lblValRequestDate = "";
        public string LblValRequestDate
        {
            get { return lblValRequestDate; }
            set
            {
                lblValRequestDate = value;
                OnPropertyChanged();
                RaisePropertyChange("LblValRequestDate");
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
            }
        }
        // lfintPageSize variable
        private int lfintPageSize = Convert.ToInt32(RSGT_Resource.ResourceManager.GetString("ColletionViewPageSize").ToString().Trim());
        public int LfintPageSize
        {
            get { return lfintPageSize; }
            set
            {
                lfintPageSize = value;
                OnPropertyChanged();
                RaisePropertyChange("LfintPageSize");
            }
        }
        // lfintPageNo variable
        private int lfintPageNo = 1;
        public int LfintPageNo
        {
            get { return lfintPageNo; }
            set
            {
                lfintPageNo = value;
                OnPropertyChanged();
                RaisePropertyChange("LfintPageNo");
            }
        }
        /// <summary>
        /// Begin Container gatephoto View Model Constructor Function
        /// </summary>
        /// <param name="strBOL"></param>
        /// <param name="fstrContainerNo"></param>
        public ContainerPhotoDetailsViewModel(string strBOL, string fstrContainerNo)
        {
            //Appcenter Track Event handler
            Analytics.TrackEvent("GatePhotoDetailViewModel");
            Task.Run(() => assignCms()).Wait();
            LblValBol = fstrContainerNo;
            Task.Run(() => getphoto(strBOL, fstrContainerNo)).Wait();
        }
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
        /// <summary>
        /// Function for caption and flowdirection (English - lefttoright / Arabic - righttoleft)
        /// </summary>
        public void assignContent()
        {

            ImgEIRIconblue = dbLayer.getCaption("imgEIRblue", objCMS);
            LblGatePhotoDetail = dbLayer.getCaption("strGatePhotoDetail", objCMS);
            LblBOL = dbLayer.getCaption("strContainerNo", objCMS);
            LblRequestDate = dbLayer.getCaption("strRequestDate", objCMS);
            strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);
        }
        /// <summary>
        /// Begin to gate out image photo to get the API (or)no data in show the message
        /// </summary>
        /// <param name="strBOL"></param>
        /// <param name="fstrContainerNo"></param>
        /// <returns></returns>
        private async Task getphoto(string strBOL, string fstrContainerNo)
        {
            try
            {
                string fstrFilter = "fstrBOLNo:" + strBOL + ";" + "fstrContainerNo:" + fstrContainerNo + ";";
                lstGatephotodetail = objBl.getContainerGatedoutImage(fstrFilter, lfintPageNo, lfintPageSize);
                await Task.Delay(1000);
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                   App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }
                foreach (var item in lstGatephotodetail)
                {
                    string Image_URL = item.gp_image;
                    var matchGroups = Regex.Match(Image_URL, @"^data:((?<type>[\w\/]+))?;base64,(?<data>.+)$").Groups;
                    var base64Data = matchGroups["data"].Value;
                    byte[] Base64Stream = Convert.FromBase64String(base64Data);
                    item.Gate_Image = ImageSource.FromStream(() => new MemoryStream(Base64Stream));
                    lstGatePhotoDetails.Add(item);
                }
                LblValRequestDate = lstGatePhotoDetails[0].gpr_requesteddate.ToString().Trim();
            }
            catch (Exception ex)
            {
               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }
        }
        //End to gate out image photo to get the API (or)no data in show the message
    }
}
