using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RsgtApp.ViewModels;

namespace RsgtApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageRegistration : ContentPage
    {
      
        /// <summary>
        /// Constructor
        /// </summary>
        public PageRegistration()
        {
            InitializeComponent();
            this.BindingContext = new PageRegistrationViewModel(this);
        }
    }
}