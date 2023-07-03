using RsgtApp.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RsgtApp.ViewModels
{
    public class TermsConditionViewModel : INotifyPropertyChanged
    {
        //  private Dictionary<string, string[]> pageContent = new Dictionary<string, string[]>();
        private List<InfoItem> objCMS = new List<InfoItem>();
        private List<InfoItem> objCMSTitle = new List<InfoItem>();
        private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        /// <summary>

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
        private string tctermsAr = "";
        public string tcTermsAr
        {
            get { return tctermsAr; }
            set
            {
                tctermsAr = value;
                OnPropertyChanged();
                RaisePropertyChange("tcTermsAr");
            }
        }
        private bool isvisibleEnglish = false;
        public bool IsvisibleEnglish
        {
            get { return isvisibleEnglish; }
            set
            {
                isvisibleEnglish = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvisibleEnglish");
            }
        }
        private bool isvisibleArabic = false;
        public bool IsvisibleArabic
        {
            get { return isvisibleArabic; }
            set
            {
                isvisibleArabic = value;
                OnPropertyChanged();
                RaisePropertyChange("IsvisibleArabic");
            }
        }
        private string lbltChead = "";

        public string lblTChead
        {
            get { return lbltChead; }
            set
            {
                lbltChead = value;
                OnPropertyChanged();
                RaisePropertyChange("lblTChead");
            }
        }
       
        private ObservableCollection<termscond> _lstTerms { get; set; } = new ObservableCollection<termscond>();
        public ObservableCollection<termscond> lstTerms
        {
            get { return _lstTerms; }
            set
            {
                if (_lstTerms == value)
                    return;
                _lstTerms = value;
                OnPropertyChanged();
                RaisePropertyChange("lstTerms");
            }
        }


        public TermsConditionViewModel()
        {
            Task.Run(() => assignCms()).Wait();
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
                    objCMSTitle = await App.Database.GetCmsAsyncAccessId("RM015");
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM021");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMSTitle = await dbLayer.LoadContent("RM015");
                    objCMS = await dbLayer.LoadContent("RM021");
                }
                assignContent();

            }
            catch (Exception ex)
            {
                App.Current.MainPage?.DisplayToastAsync(ex.Message.ToString(), 3000);

            }
        }
        /// <summary>
        /// Function for caption and flowdirection (English - lefttoright / Arabic - righttoleft)
        /// </summary>
        public void assignContent()
        {
            //IsvisibleEnglish = true;
            //IsvisibleArabic = false;
            //if (App.gblLanguage == "Ar")
            //{
            //    IsvisibleEnglish = false;
            //    IsvisibleArabic = true;
            //}
             Terms(dbLayer.getLOVTC("strTermsconditionsTitle", objCMS), App.gblLanguage);
          //  tcTermsAr = Terms(dbLayer.getLOVTC("strTermsconditionsTitle", objCMS), App.gblLanguage);
            lblTChead = dbLayer.getCaption("strTermsConditions", objCMSTitle);
        }


        public void Terms(Dictionary<string, string> fobjterms, string fstrLanguage)
        {
            
            // var lobjTermsCondition = "lobjpicTermsCondition";
            int lintTermIndex = 1;
            var lstrResultline = "";
            lstTerms.Clear();

            foreach (var term in fobjterms)
            {
                 lstrResultline = "";
                var lstrMainline = term.Key;
                lstrMainline = lstrMainline.Replace("<p>", "~");
                lstrMainline = lstrMainline.Replace("\\n\\n", "~");
                lstrMainline = lstrMainline.Replace("</p>", "");
                lstrMainline = lstrMainline.Replace("~~", "~");
                // split terms into no of bullets if exist
                string[] bullets = lstrMainline.Split('~');

                int lintsublength = bullets.Length;
                string lstrTemp1 = "";
                lstrTemp1 = bullets[0];
                lstrTemp1 = lstrTemp1.Replace(lintTermIndex.ToString().Trim() + ".", "");
                lstrTemp1 = lstrTemp1.Replace(lintTermIndex.ToString().Trim(), "");
                lstrTemp1 = lstrTemp1.Replace("<NL>", System.Environment.NewLine);


                if (fstrLanguage == "En")
                {
                    lstrResultline = lstrResultline + lintTermIndex.ToString() + " " + lstrTemp1;
                }
                if (fstrLanguage == "Ar")
                {
                    lstrResultline = lstrResultline + " " + "\u202A"+" " + lstrTemp1 + " " + "\u202C"+" " + lintTermIndex.ToString();
                }


                lstrResultline = lstrResultline + System.Environment.NewLine;

                if (lintsublength > 0)
                {
                    int lintBulletIndex = 0;

                    foreach (string bullet in bullets)
                    {
                        
                        if (lintBulletIndex == 0)
                        {
                            lintBulletIndex = lintBulletIndex + 1;
                            continue;


                        }
                        if (bullet == null) continue;
                        if (bullet.ToString().Trim() == "") continue;
                        string lstrTemp2 = bullet;
                        lstrTemp2 = lstrTemp2.Replace("<NL>", System.Environment.NewLine);

                        if (Device.RuntimePlatform == Device.iOS)
                        {
                            if (fstrLanguage == "En")
                            {
                                lstrResultline = lstrResultline + " " + lintTermIndex.ToString() + "." + lintBulletIndex.ToString() + " " + lstrTemp2.Replace(lintTermIndex.ToString() + "." + lintBulletIndex.ToString(), "");
                            }
                            if (fstrLanguage == "Ar")
                            {
                                string lstrTemp3 = "";
                                lstrTemp3 = lintTermIndex.ToString() + "." + lintBulletIndex.ToString();
                                lstrResultline = lstrResultline + " " + "\u202A"  + lstrTemp2 + " " + "\u202C" + lstrTemp3;
                            }
                        }
                        else if (Device.RuntimePlatform == Device.Android)
                        {

                            lstrResultline = lstrResultline + " " + lintTermIndex.ToString() + "." + lintBulletIndex.ToString() + " " + lstrTemp2.Replace(lintTermIndex.ToString() + "." + lintBulletIndex.ToString(), "");
                        }
                        lstrResultline += System.Environment.NewLine;


                        lintBulletIndex = lintBulletIndex + 1;

                    }
                }
                termscond lobjTerm = new termscond();
                lobjTerm.tctext = lstrResultline;
            
                lstTerms.Add(lobjTerm);
                lintTermIndex += 1;

                lstrResultline += System.Environment.NewLine;


            }


        }

    }

    public class termscond
    {
        public string tctext { get; set; }
      //  public string tctextArb { get; set; }
    }
}


