using RsgtApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace RsgtApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OogBreakBulkMsg : ContentPage
    {
        public OogBreakBulkMsg()
        {
            InitializeComponent();
            this.BindingContext = new OogBreakBulkMsgViewModel();
        }
    }
}