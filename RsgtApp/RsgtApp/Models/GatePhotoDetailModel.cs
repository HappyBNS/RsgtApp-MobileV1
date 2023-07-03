using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace RsgtApp.Models
{
    public class GatePhotoDetailModel
    {
        // Begin Gate photo detail Model
        public class Gatephotodetaildt
        {
            public string gpr_licenseno { get; set; }
            public string gpr_containernumber { get; set; }
            public string gpr_blnumber { get; set; }
            public string gpr_requesteddate { get; set; }
            public string gpr_status { get; set; }
            public string gp_reqreference { get; set; }
            public string gp_image { get; set; }
            public ImageSource Gate_Image { get; set; }
            public Int64 SNO { get; set; }
        }
        // End Gate photo detail Model
    }

}
