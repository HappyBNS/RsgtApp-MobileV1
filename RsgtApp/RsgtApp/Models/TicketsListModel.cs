using System;
using System.Collections.Generic;
using System.Text;

namespace RsgtApp.Models
{
    public class TicketsListModel
    {
        //Begin class TicketdetailDt function

        public class TicketdetailDt
        {
            public int SNO { get; set; }
            public string Mmessageheading { get; set; }
            public string MMessagetime { get; set; }

            public string MMessageinfo { get; set; }

            public string Mbellicon { get; set; }

            public string Avatar { get; set; }

            public string Attachment_file { get; set; }
            public string lblMmessageheading { get; set; }
            public string imgMbellicon { get; set; }
            public string lblAttachment { get; set; }
            public string imgattachicon { get; set; }
        }
       
        //End class TicketdetailDt function

        //Begin class RequesttDt function
        public class RequesttDt
        {
            public int Sno { get; set; }
            public string TicketNo { get; set; }
            public string Casetitle { get; set; }
            public string Category { get; set; }
            public string CaseType { get; set; }
            public string SubType { get; set; }
            public string Origin { get; set; }
            public string CreatedOn { get; set; }
            public string CompletedOn { get; set; }
            public string casegkey { get; set; }
            public string AnywhereAll { get; set; }
            public string Inqueue { get; set; }
            public string Status { get; set; }
            public string StatusCode { get; set; }
            public string StatusColor { get; set; }
            public string lblSno { get; set; }
            public string lblTicketNo { get; set; }
            public string lblStatus { get; set; }
            public string lblCasetitle1 { get; set; }
            public string lblCategory { get; set; }
            public string lblCaseType { get; set; }
            public string lblSubType { get; set; }
            public string lblOrigin { get; set; }
            public string lblCreatedOn { get; set; }
            public string lblCompletedOn { get; set; }
            public string btnMoreDetail { get; set; }
        }
        //End class RequesttDt function



        public class ExtraCareDt
        {
            public int Sno { get; set; }
            public string TicketNo { get; set; }
            public string Casetitle { get; set; }
            public string Category { get; set; }
            public string CaseType { get; set; }
            public string SubType { get; set; }
            public string Origin { get; set; }
            public string CreatedOn { get; set; }
            public string CompletedOn { get; set; }
            public string casegkey { get; set; }
            public string AnywhereAll { get; set; }
            public string Inqueue { get; set; }
            public string Status { get; set; }
            public string StatusCode { get; set; }
            public string StatusColor { get; set; }
            public string lblSno { get; set; }
            public string lblTicketNo { get; set; }
            public string lblStatus { get; set; }
            public string lblCasetitle1 { get; set; }
            public string lblCategory { get; set; }
            public string lblCaseType { get; set; }
            public string lblSubType { get; set; }
            public string lblOrigin { get; set; }
            public string lblCreatedOn { get; set; }
            public string lblCompletedOn { get; set; }
            public string lblQuotation { get; set; }
            public string btnMoreDetail { get; set; }
            public bool IsVisibleQuotation { get; set; }
            public bool BtnactioncaptionGI { get; set; }
            public string CT_TYPEOFCARGO { get; set; }
            public string CT_CATEGORYOFCARGO { get; set; }
            public string CT_OVERLENGTH { get; set; }
            public string CT_OVERWIDTH { get; set; }
            public string CT_OVERHEIGHT { get; set; }
            public string CT_WEIGHT { get; set; }
            public string CT_DANGEROUSCARGO { get; set; }
            public string CT_BASECOST { get; set; }
            public string CT_DGADDLCHARGE { get; set; }
            

        }
        //Begin class clsTICKETSTYPEFILTER function
        public class clsTICKETSTYPEFILTER
        {
            public string ct_casetypecode { get; set; }
            public string ct_casetypedesc1 { get; set; }
            public string ct_casetypedesc2 { get; set; }

        }
        //End class RequesttDt function

        //Begin class ClsTICKETSCATEGORYFILTER function
        public class ClsTICKETSCATEGORYFILTER
        {
            public string ct_categorycode { get; set; }
            public string ct_categorydesc1 { get; set; }
            public string ct_categorydesc2 { get; set; }
        }
        //End class ClsTICKETSCATEGORYFILTER function

        //Begin class clsTICKETSSTATUSFILTER function
        public class clsTICKETSSTATUSFILTER
        {
            public string ct_statuscode { get; set; }
            public string ct_statusdesc1 { get; set; }
            public string ct_statusdesc2 { get; set; }

        }
        //End class clsTICKETSSTATUSFILTER function

        //Begin class TicketFilterDlList function
        public class TicketFilterDlList
        {
            public string CmbStatus { get; set; }
            public string CmbCategory { get; set; }
            public string CmbType { get; set; }
            public bool isChecked { get; set; }
        }
        //End class TicketFilterDlList function

    }
}
