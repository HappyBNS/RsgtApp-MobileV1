namespace RsgtApp.Models
{
    public class NotificationMainModel
    {
        public class NotificationmobileDt
        {
            public int SNO { get; set; }
            public string SM_Mmessageheading { get; set; }
            public string SM_MMessagetime { get; set; }
            public string SM_MDATE { get; set; }
            public string SM_MMessageinfo { get; set; }
            public string SM_Mbellicon { get; set; }
            public string lblMmessageheading { get; set; }
            public string imgAvatar { get; set; }
            public string imgMbellicon { get; set; }
        }
        public class NotificationemailDt
        {
            public string messageheading { get; set; }
            public int Sno { get; set; }
            public string Messagetime { get; set; }
            public string Date { get; set; }
            public string Messageinfo { get; set; }
            public string bellicon { get; set; }
            public string imgbellicon { get; set; }
            public string imgAvatar { get; set; }
            public string lblMessageheading { get; set; }
        }
        public class NotificationCountdata
        {
            public string ToEmailId { get; set; }
            public string Emailcount { get; set; }
            public string SMScount { get; set; }
            public string BELLICON { get; set; }
        }
        public class NotificationEmail
        {
            public string ToEmailId { get; set; }
            public string strShipments { get; set; }
            public string strGeneral { get; set; }
            public string Emailcount { get; set; }
            public string sp { get; set; }
            public string Gn { get; set; }
        }
    }
}
