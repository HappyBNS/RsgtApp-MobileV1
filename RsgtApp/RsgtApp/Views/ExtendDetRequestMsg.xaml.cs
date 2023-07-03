using RsgtApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RsgtApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExtendDetRequestMsg : ContentPage
    {
        public ExtendDetRequestMsg()
        {
            InitializeComponent();
            this.BindingContext = new ExtendDetRequestMsgViewModel();
        }
    }
}