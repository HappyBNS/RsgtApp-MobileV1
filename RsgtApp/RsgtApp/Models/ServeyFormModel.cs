using System.Text;

namespace RsgtApp.Models
{
   public class ServeyFormModel
    {
        public static class gblSuryvaform
        {
            public static string strRegMailid { get; set; }
            public static string strQuestion { get; set; }
            public static string strRating { get; set; }
            public static string strComments { get; set; }
            public static string strDate { get; set; }
            public static string strSortoder { get; set; }
            public static string strBlgkey { get; set; }
            public static string BuildJsonProperty(string fstrPropName, string fstrValue)
            {
                StringBuilder strJsonProp = new StringBuilder();
                strJsonProp.AppendFormat("\"{0}\":\"{1}\",", fstrPropName, fstrValue);
                return strJsonProp.ToString();
            }
            public static string SurveyForm()
            {
                StringBuilder strRequest = new StringBuilder("{");
                strRequest.AppendFormat(BuildJsonProperty("SA_EMAILID", strRegMailid));
                strRequest.AppendFormat(BuildJsonProperty("SA_QUESTION", strQuestion));
                strRequest.AppendFormat(BuildJsonProperty("SA_RATING", strRating));
                strRequest.AppendFormat(BuildJsonProperty("SA_COMMENTS", strComments));
                strRequest.AppendFormat(BuildJsonProperty("SA_DATE", strDate));
                strRequest.AppendFormat(BuildJsonProperty("SA_SORTORDER", strSortoder));
                strRequest.AppendFormat("\"{0}\":\"{1}\"}}", "SA_BLGKEY", strBlgkey);
                return strRequest.ToString();
            }
            public static string GenerateInvoiceeMailData()
            {
                string strCode = MailSettings.GenerateInvoice;
                StringBuilder strTruckService = new StringBuilder("{");
                strTruckService.AppendFormat(BuildJsonProperty("SMT_CODE", strCode));
                strTruckService.AppendFormat(BuildJsonProperty("RU_EMAILID", gblRegisteration.strLoginUser));
                strTruckService.AppendFormat("\"{0}\":\"{1}\"}}", "RU_FIRSTNAME1", gblRegisteration.strLoginFirstName);
                return strTruckService.ToString();
            }
        }
    }
}