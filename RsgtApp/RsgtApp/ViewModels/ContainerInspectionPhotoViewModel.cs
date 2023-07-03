using Microsoft.AppCenter.Analytics;
using RsgtApp.BusinessLayer;
using RsgtApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using static RsgtApp.Models.ContainerInspectionModel;

namespace RsgtApp.ViewModels
{
    public class ContainerInspectionPhotoViewModel : INotifyPropertyChanged
    {
        //CMS caption list
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSMsg = new List<InfoItem>();
        private Dictionary<string, string[]> pageContent = new Dictionary<string, string[]>();
        
        private string strLanguage = App.gblLanguage;
        //To create bussinessLayer Object
        BLConnect objBl = new BLConnect();
        BLConnect bl = new BLConnect();


        private string strServerSlowMsg = "";
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Twowaybinding process on Propertychange Event
        /// </summary>
        /// <param name="name">Name</param>
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        /// <summary>
        /// Twowaybinding process on Propertychange Event
        /// </summary>
        /// <param name="propertyname">PropertyName</param>
        public void RaisePropertyChange(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
        /// <summary>
        /// To declare SetProperty
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="backfield">Backfield</param>
        /// <param name="value">Value</param>
        /// <param name="propertyName">PropertyName</param>
        /// <returns></returns>
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
        private string lblContainerNo = "";
        public string LblContainerNo
        {
            get { return lblContainerNo; }
            set
            {
                lblContainerNo = value;
                OnPropertyChanged();
                RaisePropertyChange("LblContainerNo");
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
        private string lblValContainer = "";
        public string LblValContainer
        {
            get { return lblValContainer; }
            set
            {
                lblValContainer = value;
                OnPropertyChanged();
                RaisePropertyChange("LblValContainer");
            }
        }
        //LblValRequestDate purpose of using data Variable
        private string lblBol = "";
        public string LblBol
        {
            get { return lblBol; }
            set
            {
                lblBol = value;
                OnPropertyChanged();
                RaisePropertyChange("LblBol");
            }
        }
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
        private ObservableCollection<INSPECTIONPHOTOS> lstInspectionlist = new ObservableCollection<INSPECTIONPHOTOS>();

        public ObservableCollection<INSPECTIONPHOTOS> LstcontainerInspectionlist
        {
            get { return lstInspectionlist; }
            set
            {
                lstInspectionlist = value;
                OnPropertyChanged();
                RaisePropertyChange("LstcontainerInspectionlist");
            }
        }
        /// <summary>
        /// Begin Container gatephoto View Model Constructor Function
        /// </summary>
        /// <param name="strBOL">BillofLading</param>
        /// <param name="fstrContainerNo">ContainerNo</param>
        public ContainerInspectionPhotoViewModel(string strBOLNo, string strContainerNo)
        {

            //Appcenter Track Event handler
            Analytics.TrackEvent("ContainerInspectionPhotoViewModel");
            Task.Run(() => assignCms()).Wait();
            LblValBol = strBOLNo;
            LblValContainer = strContainerNo;
            Task.Run(() => getInspection(strBOLNo, strContainerNo)).Wait();
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
        public async void assignContent()
        {


            await Task.Delay(1000);
            ImgEIRIconblue = dbLayer.getCaption("imgEIRblue", objCMS);
            LblGatePhotoDetail = dbLayer.getCaption("strInspectionPhotos", objCMS);
            LblContainerNo = dbLayer.getCaption("strContainerNo", objCMS);
            LblBol = dbLayer.getCaption("strBillofLadings", objCMS);
            LblRequestDate = dbLayer.getCaption("strRequestDate", objCMS);
            strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMsg);


        }
        /// <summary>
        /// To go to get Inspection
        /// </summary>
        /// <param name="strBOLNo">BOLNo</param>
        /// <param name="strContainerNo">ContainerNo</param>
        /// <returns></returns>
        public async Task getInspection(string strBOLNo, string strContainerNo)
        {
            try
            {
                string fstrFilter = "fstrBOLNo:" + strBOLNo + ";" + "fstrContainerNo:" + strContainerNo + ";";
                var lstcontainerInspectionlist = bl.getInspection("ContainerInspectionImage", strBOLNo, strContainerNo);
                if (AppSettings.ErrorExceptionWebApi != "")
                {
                   App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
                }
                if (lstcontainerInspectionlist.Count == 0)
                {
                    await App.Current.MainPage?.Navigation.PushAsync(new ContainerInspectionMsg());
                }
                else
                {
                    foreach (var item in lstcontainerInspectionlist)
                    {
                        string Image_URL = item.ImageURL;
                        //var matchGroups = Regex.Match(Image_URL, @"^data:((?<type>[\w\/]+))?;base64,(?<data>.+)$").Groups;
                        //var base64Data = matchGroups["data"].Value;
                        byte[] Base64Stream = Convert.FromBase64String(Image_URL);
                        item.ImageData = ImageSource.FromStream(() => new MemoryStream(Base64Stream));
                        LstcontainerInspectionlist.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {

               App.Current.MainPage?.DisplayToastAsync(ex.Message, 3000);
            }

        }

    }
}
