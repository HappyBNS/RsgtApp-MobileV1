using System;
using System.Collections.Generic;
using System.Text;

namespace RsgtApp.Models
{

    public class ExtraCare
    {
        public static int lintExtraCareSno { get; set; }

        public static List<ExtraCareContainer> lstExtra = new List<ExtraCareContainer>();

        public static List<ExtraCareContainer> lstSelectedExtra = new List<ExtraCareContainer>();

        public class ExtraCareContainer
        {
            public int CD_SNO { get; set; }

            public string CD_BillofLading { get; set; }

            public string CD_ContainerNo { get; set; }

            public string CD_ShippingLineName1 { get; set; }

            public string CD_ShippingLineName2 { get; set; }

            public string CD_ETA1 { get; set; }

            public string CD_ETA2 { get; set; }

            public string CD_StowagePlan1 { get; set; }

            public string CD_StowagePlan2 { get; set; }

            public string CD_Date1 { get; set; }
            public string CD_Date2 { get; set; }

            public string lbl_ContainerNo { get; set; }
            public string lbl_BOL { get; set; }
            public string lbl_ShippingLineName { get; set; }
            public string lbl_ShippingLineName2 { get; set; }
            public string lbl_ETA { get; set; }
            public string lbl_ETA2 { get; set; }
            public string lbl_StowagePlan { get; set; }
            public string lbl_StowagePlan2 { get; set; }
            public string lbl_ShippingLine1 { get; set; }
            public string lbl_ShippingLine2 { get; set; }
            public string Btn_Delete { get; set; }
            public string Btn_Edit { get; set; }
            //public string lbl_ShippingLineName { get; set; }
            //public string lbl_ShippingLineName2 { get; set; }
        }
    }

}
