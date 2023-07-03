using RsgtApp.Themes;
using System;
using Nancy.Json;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RsgtApp.BusinessLayer;
using System.Collections;
using Xamarin.Essentials;

namespace RsgtApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThemeMain : ContentPage
    {
        BLConnect objBl = new BLConnect();
        private List<InfoItem> objCMS = new List<InfoItem>();
        private Dictionary<string, string[]> pageContent = new Dictionary<string, string[]>();

       // private FlowDirection enumDirection = FlowDirection.LeftToRight;
        private string strLanguage = App.gblLanguage;
        string lstrthemeselection;
        private bool checkedRadio { get; set; }
        protected async override void OnAppearing()
        {
            var current = Connectivity.NetworkAccess;
            var profiles = Connectivity.ConnectionProfiles;
            if (current == NetworkAccess.Internet)
            {

                if (App.isinternetSlowEnablement == true)
                {
                    bool isConnectionFast = DependencyService.Get<INetwork>().IsConnectedFast();
                    if (isConnectionFast)
                    { }
                    else
                        await this.DisplayToastAsync("Network Connection is slow", 3000); // DependencyService.Get<IToast>().ShowToast("Network Connection is slow");
                } 



            }
            else
            {
                //lblNetworkStatus.Text = "Network is Not Available";
                await DisplayAlert("Network Problem", "Network is Not Available,Please check Internet Connection!", "OK");
                //Navigation.PushAsync(new InternetConnectivity());
            }

        }


        public ThemeMain()
        {
            InitializeComponent();

            // objCMS = await dbLayer.LoadContent("RM006");
            // assignContent();
            assignCms();

           

        }

        public async void assignCms()
        {
            try
            {
                if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
                {
                    objCMS = await App.Database.GetCmsAsyncAccessId("RM006");
                }
                if (App.gblCMSSource.ToUpper().Trim() == "JSON")
                {
                    objCMS = await dbLayer.LoadContent("RM006");
                }
                //objCMS = await App.Database.GetCmsAsyncAccessId("RM006");
                assignContent();

            }
            catch (Exception ex)
            {
                await this.DisplayToastAsync(ex.Message);
            }
        }

        public async void assignContent()
        {
            
            //enumDirection = FlowDirection.LeftToRight;
            //if (strLanguage == "Ar")
            //{
            //    enumDirection = FlowDirection.RightToLeft;
                
            //}
            imgtheme.Source = dbLayer.getCaption("imgTheme", objCMS);
            lblChooseTheme.Text = dbLayer.getCaption("strChooseYourTheme", objCMS);
            btnLightTheme.Content = dbLayer.getCaption("strLightTheme", objCMS);
            imgLightThemeIcon.Source = dbLayer.getCaption("imgLightTheme", objCMS);
            btnDarkTheme.Content = dbLayer.getCaption("strDarkTheme", objCMS);
            imgDarktheme.Source = dbLayer.getCaption("imgDarkTheme", objCMS);
            btnSaudiTheme.Content = dbLayer.getCaption("strSaudiTheme", objCMS);
            imgGreentheme.Source = dbLayer.getCaption("imgGreenTheme", objCMS);
            btnApply.Text = dbLayer.getCaption("strApply", objCMS);
            btnExit.Text = dbLayer.getCaption("strExit", objCMS);

            string result = await SecureStorage.GetAsync("ApplyTheme");

            if (result == null)
            {
                App.gblSelectedTheme = "1";
                await SecureStorage.SetAsync("ApplyTheme", "1");
            }
            else
            {
                App.gblSelectedTheme = result.ToString();
            }


            if (App.gblSelectedTheme == "1") btnLightTheme.IsChecked = true;
            if (App.gblSelectedTheme == "2") btnDarkTheme.IsChecked = true;
            if (App.gblSelectedTheme == "3") btnSaudiTheme.IsChecked = true;
            setThemes();
        }

        private void applyThemes(object sender, EventArgs e)
        {
            SecureStorage.SetAsync("ApplyTheme", App.gblSelectedTheme); //Key,Vaue

            setThemes();
        }

        private void setThemes()
        {
            ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            if (mergedDictionaries != null)
            {
                switch (App.gblSelectedTheme)
                {
                    case "2":
                        mergedDictionaries.Add(new DarkTheme());
                        break;
                    case "3":
                        mergedDictionaries.Add(new GreenTheme());
                        break;
                    case "1":
                    default:
                        mergedDictionaries.Add(new LightTheme());
                        break;
                }
            }
        }

        private void OnDarkThemeCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            RadioButton button = sender as RadioButton;
            lstrthemeselection = button.Value.ToString();
            App.gblSelectedTheme = "2";
        }

        private void OnSaudiThemeCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            RadioButton button = sender as RadioButton;
            lstrthemeselection = button.Value.ToString();
            App.gblSelectedTheme = "3";
        }

        private void OnLightThemeCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            RadioButton button = sender as RadioButton;
            lstrthemeselection = button.Value.ToString();
            App.gblSelectedTheme = "1";
        }

        private void ExitToMain(object sender, EventArgs e)
        {
            Application.Current.MainPage?.Navigation.PopAsync();
            Application.Current.MainPage = new AppShell();
           // Application.Current.MainPage?.Navigation.PopToRootAsync();
        }
    }
}