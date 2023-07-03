using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RsgtApp.Data;
using Xamarin.CommunityToolkit.Extensions;


namespace RsgtApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CMSGetPage : ContentPage
    {
        public CMSGetPage()
        {
            InitializeComponent();
            defaultActivityIndicator.IsRunning = true;

            this.DisplayToastAsync("Loading data", 3000);

            Task.Delay(2000);

            GetCaption();
            defaultActivityIndicator.IsRunning = false;
        }

        public async void GetCaption()
        {
            List<InfoItem> lstCms = new List<InfoItem>();
            await this.DisplayToastAsync("Before get data", 3000);

            try
            {
                string fstrAccessID = txtAccessID.Text.Trim();
                lstCms = await App.Database.GetCmsAsyncAccessId(fstrAccessID);
                await this.DisplayToastAsync("Total records retreived - " + lstCms.Count.ToString(), 10000);
            }
            catch (Exception Ex)
            {
                await this.DisplayToastAsync("Before get data - Error "+Ex.ToString(), 10000);
            }

            try
            {
                //collectionView.ItemsSource = lstCms;
                lblInfo1.Text = lstCms[31].cms_info1.ToString();
            }
            catch (Exception Ex)
            {
                await this.DisplayToastAsync("Before get data - Error " + Ex.ToString(), 10000);
            }

            await Task.Delay(2000);

            await this.DisplayToastAsync("After get data", 3000);
        }
    }
}