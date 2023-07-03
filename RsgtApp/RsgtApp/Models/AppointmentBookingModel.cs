using System;
using System.Collections.Generic;
using System.Text;

namespace RsgtApp.Models
{
    public class AppointmentBookingModel
    {
        //Begin Appointment Booking Model
        public class BookingDt
        {
            public string AnywhereAll { get; set; }
            public Int32 Sno { get; set; }
            public string BayanNo { get; set; }
            public string Servicehead { get; set; }
            public string Serviceinfo { get; set; }
            public string Icon { get; set; }
            public string Status { get; set; }
            public string StatusColor { get; set; }
            public string statuscode { get; set; }
            public string Billoflading { get; set; }
            public string Inyard { get; set; }
            public string Departed { get; set; }
            public string Shippingline { get; set; }
            public string ShippingIcon { get; set; }
            public string Consignee { get; set; }
            public string Shipper { get; set; }
            public string CustomsAgent { get; set; }
            public string TmsBookingRef { get; set; }
            public string Importer { get; set; }
            public string POL { get; set; }
            public string POD { get; set; }
            public string AppDate { get; set; }
            public string Container { get; set; }
            public string lblBayan { get; set; }
            public string lblBillofLading { get; set; }
            public string lblContainer { get; set; }
            public string lblTmsBookingRef { get; set; }
            public string lblAppDate { get; set; }
            public string lblBookingStatus { get; set; }
        }
        //End Appointment Booking Model
        //Begin Appointment Booking Filter
        public class AppointmentFilterDtlist
        {
            public bool isChecked { get; set; }
            public string CmbStatus { get; set; }
        }
        //End Appointment Booking Filter
    }
}