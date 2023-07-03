using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace RsgtApp.Models
{
    public class ExtendedDetentionModel
    {
        public static int lintExtendDetionSno { get; set; }

        public static List<ExtendedDetention> lstExtendedDetention = new List<ExtendedDetention>();
        public static List<ExtendedDetention> lstSelectedExtendedDetention = new List<ExtendedDetention>();

        public event PropertyChangedEventHandler PropertyChanged;

        public static string strContainerNo { get; set; }
        public static string strBolNo { get; set; }
        public static string strDetentionDate { get; set; }
        public static string strNewDepot { get; set; }
        public class ExtendedDetention : INotifyPropertyChanged
        {
            public string cd_containernumber { get; set; }
            public string cd_blnumber { get; set; }
            public string cd_consigneegkey { get; set; }
            public string cd_agentkey { get; set; }
            public string cd_shippergkey { get; set; }
            public string cd_transporter { get; set; }
            public string cd_custombrokeragent { get; set; }
            public string bl_linegkey { get; set; }

            public string cd_DetentionDate { get; set; }
            public string cd_NewDeport { get; set; }
            public int CD_SNO { get; set; }
            public string btn_delete { get; set; }
            public string lbl_Containerno { get; set; }
            public string lbl_Bolno { get; set; }
            public string lbl_Detentiondate { get; set; }

            public bool cd_CheckBox { get; set; }

            public string lbl_Newdeport { get; set; }



            public bool isChecked { get; set; }
            private bool ischecked;

            public bool IsChecked // Child
            {
                get
                {
                    return ischecked;
                }
                set
                {
                    if (value != null)
                    {
                        ischecked = value;
                        OnPropertyChanged("IsChecked");
                    }
                }
            }


            public event PropertyChangedEventHandler PropertyChanged;
            // Twowaybinding process on Propertychange Event
            public void OnPropertyChanged([CallerMemberName] string name = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
    }


    //End Dwell Days Filter

}
