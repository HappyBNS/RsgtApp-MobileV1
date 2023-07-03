using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace RsgtApp.Models
{
    public class ContainerInspectionModel
    {
        public class INSPECTIONPHOTOS
        {
            public string BOLNo { get; set; }
            public string ContainerNumber { get; set; }
            public ImageSource ImageData { get; set; }
            public string ImageURL { get; set; }
        }
    }
}
