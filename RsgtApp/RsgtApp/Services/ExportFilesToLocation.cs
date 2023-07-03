using RsgtApp.Droid;
using Java.IO;
using RsgtApp.Interfaces;
using Xamarin.Forms;



[assembly: Dependency(typeof(ExportFilesToLocation))]
namespace RsgtApp.Droid
{
    public class ExportFilesToLocation : IExportFilesToLocation
    {
        public ExportFilesToLocation()
        {
        }

        [System.Obsolete]
        public string GetFolderLocation()
        {
            string root = null;
            
            if (Android.OS.Environment.IsExternalStorageEmulated)
            {
                root = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
            }
            else
                root = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);

            File myDir = new File(root + "/Download");
            if(!myDir.Exists())
                myDir.Mkdir();

            return root + "/Download/";
        }
    }
}