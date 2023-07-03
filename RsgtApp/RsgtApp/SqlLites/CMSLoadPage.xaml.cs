using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.CommunityToolkit.Extensions;
using System.Threading.Tasks;

namespace RsgtApp.Views
{
    
    public partial class CMSLoadPage : ContentPage
    {
        public CMSLoadPage()
        {
            InitializeComponent();
            BindingContext = new InfoItem();
        }

        async void OnLoadButtonClicked(object sender, EventArgs e)
        {
            var ObjCms = (InfoItem)BindingContext;
            List<InfoItem> lstobjCms = new List<InfoItem>();
            float lintTotalRecords = 0;
            string[] stringarr;
            //stringarr = new string[40] { "RM001", "RM002", "RM003", "RM004", "RM005", "RM007", "RM008", "RM009", "RM010", "RM011", "RM012", "RM013", "RM015", "RM017", "RM019", "RM021", "RM023", "RM024", "RM026", "RM027", "RM028", "RM029", "RM030", "RM077", "RM401", "RM402", "RM403", "RM407", "RM408", "RM409", "RM410", "RM411", "RM412", "RM413", "RM414", "RM415", "RM420", "RM427", "RM428", "RM432" };
            stringarr = new string[23] { "RM001", "RM002", "RM003", "RM004", "RM005", "RM007", "RM008", "RM009", "RM010", "RM011", "RM012", "RM013", "RM015", "RM017", "RM019", "RM021", "RM023", "RM024", "RM026", "RM027", "RM028", "RM029", "RM030" };

            //stringarr = new string[4] { "RM001", "RM002", "RM003", "RM004" };

            lblStatus.Text = "Started";
            await Task.Delay(2000);

            foreach (var lstrAccessid in stringarr)
            {
                lblStatus.Text = lstrAccessid + " - In-progress";
                
                await Task.Delay(2000);

                lstobjCms = App.Database.LoadContentArr(lstrAccessid);
                lintTotalRecords += lstobjCms.Count;

                if (lstobjCms.Count > 0)
                {
                    foreach (var lstrInsertData in lstobjCms)
                    {
                        App.Database.CreateCMSAsync(lstrInsertData);
                    }
                }
            }

            await this.DisplayToastAsync("Total records loaded - " + lintTotalRecords.ToString(), 10000);

            /*
            try
            {
                List<InfoItem> lstCms = new List<InfoItem>();
                string fstrAccessID = "RM004";
                lstCms = await App.Database.GetCmsAsyncAccessId(fstrAccessID);
                await this.DisplayToastAsync("Total records loaded - " + lstCms.Count.ToString(), 10000);
            }
            catch (Exception Ex)
            {
                await this.DisplayToastAsync("After data loaded - Error " + Ex.ToString(), 10000);
            }
            */

            lblStatus.Text = "Completed";
            await Task.Delay(2000);

            await this.DisplayToastAsync("Data loading completed", 3000);
            // Navigate backwards
            await Shell.Current.GoToAsync("..");

        }
    }
}