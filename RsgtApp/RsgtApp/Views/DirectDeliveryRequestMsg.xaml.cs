using RsgtApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RsgtApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DirectDeliveryRequestMsg : ContentPage
    {
        public DirectDeliveryRequestMsg()
        {
            InitializeComponent();
            this.BindingContext = new DirectDeliveryRequestMsgViewModel();
        }
    }
}