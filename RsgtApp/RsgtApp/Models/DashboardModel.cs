using System;
using System.Collections.Generic;
using System.Text;

namespace RsgtApp.Models
{
    public class DashboardModel
    {
        public class clsdashboardCountlist
        {
            //  public int intPageNum { get; set; }
            //  public int intPagesize { get; set; }

            public string emailid { get; set; }
            public string linkcode { get; set; }
            public string idno { get; set; }
            //change to string 
            public string dwelldaysavg { get; set; }
            public string pendingpaymentinvoicescount { get; set; }
            public string volumeupdatecontainerscount { get; set; }
            public string rfdcontainerscount { get; set; }
            public string rfdcontainersexpirycount { get; set; }
            public string containerscount { get; set; }
            public string mbcontainerscount { get; set; }
            public string reviewscount { get; set; }
            public string reviewspendingcount { get; set; }
            public string avstruckamount { get; set; }
            public string avscutomclearenceamount { get; set; }
            public string readytodeliverunitcount { get; set; }
            public string walletbalanace { get; set; }
            public string casesresolved { get; set; }
            public string casesinprogress { get; set; }
            public string invoicescount { get; set; }
            public Decimal invoicesamount { get; set; }
            public string appoinmentscount { get; set; }
            public string mibcontainerscount { get; set; }
            public string r2dgatedoutcount { get; set; }
            public string r2dyardcount { get; set; }
            public string unitsunderdentioncount { get; set; }
            public string unitneardentioncount { get; set; }
            public string bannedtruckscount { get; set; }
            public string eurrsgtcount { get; set; }
            public string euroutsideedcount { get; set; }
            public string voltoday { get; set; }
            public string volthisweek { get; set; }
            public string volthismonth { get; set; }
            public string volcurrentyear { get; set; }
            public string volpreviousyear { get; set; }
            public string ytd20inchpercentage { get; set; }
            public string ytd40inchpercentage { get; set; }
            public string ytdreeferpercentage { get; set; }
            public string ytdinyardcount { get; set; }
            public string ytdgatedoutcount { get; set; }


        }
    }
}
