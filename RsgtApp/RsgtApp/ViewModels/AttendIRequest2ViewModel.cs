using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using RsgtApp.BusinessLayer;
using Xamarin.CommunityToolkit.Extensions;
using System.Runtime.CompilerServices;
using Microsoft.AppCenter.Analytics;
using RsgtApp.Views;
using RsgtApp.Models;

namespace RsgtApp.ViewModels
{
    class AttendIRequest2ViewModel : INotifyPropertyChanged
    {
		//CMS caption list
		private List<InfoItem> objCMS = new List<InfoItem>();
		private List<InfoItem> objCMSMSG = new List<InfoItem>();
		private string strServerSlowMsg = "";
		
		//To create bussinessLayer Object
		BLConnect objBl = new BLConnect();
		public Command Buttonreset { get; set; }
		public Command Buttonsubmitrequest { get; set; }
		public Command Tapmanifestrequesthistory { get; set; }
		public List<EnumCombo> lobjAttendinspection { get; set; } = new List<EnumCombo>();
		public event PropertyChangedEventHandler PropertyChanged;
		// Two way binding process on Propertychange Event
		public void OnPropertyChanged([CallerMemberName] string name = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
		// Two way binding process on RaisePropertyChange Event
		public void RaisePropertyChange(string propertyname)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
			}
		}
		protected bool SetProperty<T>(ref T backfield, T value,
			[CallerMemberName] string propertyName = null)
		{
			if (EqualityComparer<T>.Default.Equals(backfield, value))
			{
				return false;
			}
			backfield = value;
			OnPropertyChanged(propertyName);
			return true;
		}
		//Indicator Color
		private string indicatorBGColor = RSGT_Resource.ResourceManager.GetString("IndicatorViewBGColor");
		public string IndicatorBGColor
		{
			get { return indicatorBGColor; }
			set
			{
				indicatorBGColor = value;
				OnPropertyChanged();
				RaisePropertyChange("IndicatorBGColor");
			}
		}
		//Indicator Opacity
		private string indicatorBGOpacity = RSGT_Resource.ResourceManager.GetString("IndicatorViewOpacity");
		public string IndicatorBGOpacity
		{
			get { return indicatorBGOpacity; }
			set
			{
				indicatorBGOpacity = value;
				OnPropertyChanged();
				RaisePropertyChange("IndicatorBGOpacity");
			}
		}
		private bool stackattendRequest2 = true;
		public bool StackAttendRequest2
		{
			get { return stackattendRequest2; }
			set
			{
				stackattendRequest2 = value;
				OnPropertyChanged();
				RaisePropertyChange("StackAttendRequest2");
			}
		}
		private string TxtapplicantName = "";
		public string TxtApplicantName
		{
			get { return TxtapplicantName; }
			set
			{
				TxtapplicantName = value;
				OnPropertyChanged();
				RaisePropertyChange("TxtApplicantName");
			}
		}
		private string TxtcompanyName = "";
		public string TxtCompanyName
		{
			get { return TxtcompanyName; }
			set
			{
				TxtcompanyName = value;
				OnPropertyChanged();
				RaisePropertyChange("TxtCompanyName");
			}
		}
		private string Txtdesignation = "";
		public string TxtDesignation
		{
			get { return Txtdesignation; }
			set
			{
				Txtdesignation = value;
				OnPropertyChanged();
				RaisePropertyChange("TxtDesignation");
			}
		}
		private string TxtmobileNo = "";
		public string TxtMobileNo
		{
			get { return TxtmobileNo; }
			set
			{
				TxtmobileNo = value;
				OnPropertyChanged();
				RaisePropertyChange("TxtMobileNo");
			}
		}
		private string TxtnationalId = "";
		public string TxtNationalId
		{
			get { return TxtnationalId; }
			set
			{
				TxtnationalId = value;
				OnPropertyChanged();
				RaisePropertyChange("TxtNationalId");
			}
		}
		private string TxtdOV = "";
		public string TxtDOV
		{
			get { return TxtdOV; }
			set
			{
				TxtdOV = value;
				OnPropertyChanged();
				RaisePropertyChange("TxtDOV");
			}
		}
		private string imgvisitorIcon = "";
		public string imgVisitorIcon
		{
			get { return imgvisitorIcon; }
			set
			{
				imgvisitorIcon = value;
				OnPropertyChanged();
				RaisePropertyChange("imgVisitorIcon");
			}
		}
		private string lblattendInspectionRequest = "";
		public string lblAttendInspectionRequest
		{
			get { return lblattendInspectionRequest; }
			set
			{
				lblattendInspectionRequest = value;
				OnPropertyChanged();
				RaisePropertyChange("lblAttendInspectionRequest");
			}
		}
		private string imgrequestIcon = "";
		public string imgRequestIcon
		{
			get { return imgrequestIcon; }
			set
			{
				imgrequestIcon = value;
				OnPropertyChanged();
				RaisePropertyChange("imgRequestIcon");
			}
		}
		private string lblattendRequestForm = "";
		public string lblAttendRequestForm
		{
			get { return lblattendRequestForm; }
			set
			{
				lblattendRequestForm = value;
				OnPropertyChanged();
				RaisePropertyChange("lblAttendRequestForm");
			}
		}
		private string lblcontainerNo = "";
		public string lblContainerNo
		{
			get { return lblcontainerNo; }
			set
			{
				lblcontainerNo = value;
				OnPropertyChanged();
				RaisePropertyChange("lblContainerNo");
			}
		}
		private string lblbOLNo = "";
		public string lblBOLNo
		{
			get { return lblbOLNo; }
			set
			{
				lblbOLNo = value;
				OnPropertyChanged();
				RaisePropertyChange("lblBOLNo");
			}
		}
		private string lblapplicantName = "";
		public string lblApplicantName
		{
			get { return lblapplicantName; }
			set
			{
				lblapplicantName = value;
				OnPropertyChanged();
				RaisePropertyChange("lblApplicantName");
			}
		}
		private string lblcompanyName = "";
		public string lblCompanyName
		{
			get { return lblcompanyName; }
			set
			{
				lblcompanyName = value;
				OnPropertyChanged();
				RaisePropertyChange("lblCompanyName");
			}
		}
		private string lbldesignation = "";
		public string lblDesignation
		{
			get { return lbldesignation; }
			set
			{
				lbldesignation = value;
				OnPropertyChanged();
				RaisePropertyChange("lblDesignation");
			}
		}
		private string lblmobileNo = "";
		public string lblMobileNo
		{
			get { return lblmobileNo; }
			set
			{
				lblmobileNo = value;
				OnPropertyChanged();
				RaisePropertyChange("lblMobileNo");
			}
		}
		private string lblnationalId = "";
		public string lblNationalId
		{
			get { return lblnationalId; }
			set
			{
				lblnationalId = value;
				OnPropertyChanged();
				RaisePropertyChange("lblNationalId");
			}
		}
		private string lbldOV = "";
		public string lblDOV
		{
			get { return lbldOV; }
			set
			{
				lbldOV = value;
				OnPropertyChanged();
				RaisePropertyChange("lblDOV");
			}
		}
		private string Btnreset = "";
		public string BtnReset
		{
			get { return Btnreset; }
			set
			{
				Btnreset = value;
				OnPropertyChanged();
				RaisePropertyChange("BtnReset");
			}
		}
		private string Btnsubmit = "";
		public string BtnSubmit
		{
			get { return Btnsubmit; }
			set
			{
				Btnsubmit = value;
				OnPropertyChanged();
				RaisePropertyChange("BtnSubmit");
			}
		}
		private string imghistoryIcon = "";
		public string imgHistoryIcon
		{
			get { return imghistoryIcon; }
			set
			{
				imghistoryIcon = value;
				OnPropertyChanged();
				RaisePropertyChange("imgHistoryIcon");
			}
		}
		private string lblrequestHistory = "";
		public string lblRequestHistory
		{
			get { return lblrequestHistory; }
			set
			{
				lblrequestHistory = value;
				OnPropertyChanged();
				RaisePropertyChange("lblRequestHistory");
			}
		}
		private string lblvalContainerno = "";
		public string lblValContainerno
		{
			get { return lblvalContainerno; }
			set
			{
				lblvalContainerno = value;
				OnPropertyChanged();
				RaisePropertyChange("lblValContainerno");
			}
		}
		private string lblvalBOLno = "";
		public string lblValBOLno
		{
			get { return lblvalBOLno; }
			set
			{
				lblvalBOLno = value;
				OnPropertyChanged();
				RaisePropertyChange("lblValBOLno");
			}
		}
		private string lblenterthebelowinformation = "";
		public string lblEnterthebelowinformation
		{
			get { return lblenterthebelowinformation; }
			set
			{
				lblenterthebelowinformation = value;
				OnPropertyChanged();
				RaisePropertyChange("lblEnterthebelowinformation");
			}
		}
		private string msgApplicantName = "";
		public string MsgApplicantName
		{
			get { return msgApplicantName; }
			set
			{
				msgApplicantName = value;
				OnPropertyChanged();
				RaisePropertyChange("MsgApplicantName");
			}
		}
		private string msgCompanyName = "";
		public string MsgCompanyName
		{
			get { return msgCompanyName; }
			set
			{
				msgCompanyName = value;
				OnPropertyChanged();
				RaisePropertyChange("MsgCompanyName");
			}
		}
		private string msgDesignation = "";
		public string MsgDesignation
		{
			get { return msgDesignation; }
			set
			{
				msgDesignation = value;
				OnPropertyChanged();
				RaisePropertyChange("MsgDesignation");
			}
		}
		private string msgMobileNo = "";
		public string MsgMobileNo
		{
			get { return msgMobileNo; }
			set
			{
				msgMobileNo = value;
				OnPropertyChanged();
				RaisePropertyChange("MsgMobileNo");
			}
		}
		private bool isvalidatedMobileNo = false;
		public bool IsvalidatedMobileNo
		{
			get { return isvalidatedMobileNo; }
			set
			{
				isvalidatedMobileNo = value;
				OnPropertyChanged();
				RaisePropertyChange("IsvalidatedMobileNo");
			}
		}
		private bool isvalidatedDesignation = false;
		public bool IsvalidatedDesignation
		{
			get { return isvalidatedDesignation; }
			set
			{
				isvalidatedDesignation = value;
				OnPropertyChanged();
				RaisePropertyChange("IsvalidatedDesignation");
			}
		}
		private bool isvalidatedCompanyName = false;
		public bool IsvalidatedCompanyName
		{

			get { return isvalidatedCompanyName; }
			set
			{
				isvalidatedCompanyName = value;
				OnPropertyChanged();
				RaisePropertyChange("IsvalidatedCompanyName");
			}
		}
		private bool isvalidatedApplicantName = false;
		public bool IsvalidatedApplicantName
		{
			get { return isvalidatedApplicantName; }
			set
			{
				isvalidatedApplicantName = value;
				OnPropertyChanged();
				RaisePropertyChange("IsvalidatedApplicantName");
			}
		}
		//Date Picker
		private DateTime? dtDateofvisit = null;
		public DateTime? DtDateofvisit
		{
			get { return dtDateofvisit; }
			set
			{
				dtDateofvisit = value;
				OnPropertyChanged();
				RaisePropertyChange("DtDateofvisit");
			}
		}
		/// <summary>
		/// To handle Boolean
		/// </summary>
		bool isBusy = false;
		public bool IsBusy
		{
			get { return isBusy; }
			set
			{
				isBusy = value;
				OnPropertyChanged();
				RaisePropertyChange("IsBusy");
				Buttonreset.ChangeCanExecute();
				Buttonsubmitrequest.ChangeCanExecute();
				Tapmanifestrequesthistory.ChangeCanExecute();
			}
		}
		/// <summary>
		/// ViewModel - Constructor
		/// </summary>
		/// <param name="fstrValContainerno"></param>
		/// <param name="fstrValBOLno"></param>
		public AttendIRequest2ViewModel(string fstrValContainerno, string fstrValBOLno)
		{
			//Appcenter Track Event handler
			Analytics.TrackEvent("AttendIRequest2ViewModel");
			Task.Run(() => assignCms()).Wait();
			Buttonreset = new Command(async () => await buttonreset(fstrValContainerno, fstrValBOLno), () => !IsBusy);
			Buttonsubmitrequest = new Command(async () => await buttonsubmitrequest(), () => !IsBusy);
			Tapmanifestrequesthistory = new Command(async () => await tapmanifestrequesthistory(), () => !IsBusy);
			lblValContainerno = fstrValContainerno;
			lblValBOLno = fstrValBOLno;
		}
		/// <summary>
		/// To bind CMS captions
		/// </summary>
		public async void assignCms()
		{
			try
			{
				if (App.gblCMSSource.ToUpper().Trim() == "SQLITE")
				{
					objCMS = await App.Database.GetCmsAsyncAccessId("RM459");
					objCMSMSG = await dbLayer.LoadContent("RM026");
				}
				if (App.gblCMSSource.ToUpper().Trim() == "JSON")
				{
					objCMS = await dbLayer.LoadContent("RM459");
					objCMSMSG = await dbLayer.LoadContent("RM026");			
				}	
				assignContent();
			}
			catch (Exception ex)
			{
				await App.Current.MainPage?.DisplayToastAsync(ex.Message);
			}
		}
		/// <summary>
		/// To assign Captions
		/// </summary>
		public async void assignContent()
		{			
			
			
			imgVisitorIcon = dbLayer.getCaption("imgVisitor", objCMS);
			lblAttendInspectionRequest = dbLayer.getCaption("strAttendInspectionRequest", objCMS);
			imgRequestIcon = dbLayer.getCaption("imgRequest", objCMS);
			lblAttendRequestForm = dbLayer.getCaption("strAttendInspectionRequestForm", objCMS);
			lblContainerNo = dbLayer.getCaption("strContainerNumber", objCMS);
			lblBOLNo = dbLayer.getCaption("strBillofLading", objCMS);
			lblEnterthebelowinformation = dbLayer.getCaption("strPleaseEnterBelowInformation", objCMS);
			lblApplicantName = dbLayer.getCaption("strApplicantName", objCMS);
			lblCompanyName = dbLayer.getCaption("strCompanyName", objCMS);
			lblDesignation = dbLayer.getCaption("strDesignation", objCMS);
			lblMobileNo = dbLayer.getCaption("strMobileNo", objCMS);
			lblNationalId = dbLayer.getCaption("strNationalIqamaId", objCMS);
			lblDOV = dbLayer.getCaption("strDateOfVisit", objCMS);
			BtnReset = dbLayer.getCaption("strReset", objCMS);
			BtnSubmit = dbLayer.getCaption("strSubmit", objCMS);
			imgHistoryIcon = dbLayer.getCaption("imgHistory", objCMS);
			lblRequestHistory = dbLayer.getCaption("strRequestHistory", objCMS);
			lobjAttendinspection = dbLayer.getEnum("strAttendInspectionLov", objCMS); 
			MsgApplicantName = dbLayer.getCaption("strMandatory", objCMSMSG);
			MsgCompanyName = dbLayer.getCaption("strMandatory", objCMSMSG);
			MsgDesignation = dbLayer.getCaption("strMandatory", objCMSMSG);
			MsgMobileNo =dbLayer.getCaption("strMandatory", objCMSMSG);
			strServerSlowMsg = dbLayer.getCaption("strServerSlowMsg", objCMSMSG);
			await Task.Delay(1000);
		}
		/// <summary>
		/// To Reset Function
		/// </summary>
		/// <returns></returns>
		private async Task buttonreset(string fstrValContainerno, string fstrValBOLno)
		{
			IsBusy = true;
			StackAttendRequest2 = false;
			await Task.Delay(1000);
			TxtApplicantName = "";
			TxtCompanyName = "";
			TxtDesignation = "";
			TxtMobileNo = "";
			TxtNationalId = "";
			//await App.Current.MainPage?.Navigation.PushAsync(new AttendInspectionRequest2(fstrValContainerno, fstrValBOLno));
			StackAttendRequest2 = true;
			IsBusy = false;
		}
		/// <summary>
		/// To Cick Submit Function
		/// </summary>
		/// <returns></returns>
		private async Task buttonsubmitrequest()
		{
			await HideErrorValidation();
			var ApplicantName = TxtApplicantName.ToString().Trim();
			var CompanyName = TxtCompanyName.ToString().Trim();
			var Designation = TxtDesignation.ToString().Trim();
			var MobileNo = TxtMobileNo.ToString().Trim();
			//var DateofVisit = "";
			bool blResult = true;
			if (blResult == true)
			{
				if ((TxtApplicantName == null) || (TxtApplicantName == ""))
				{
					IsvalidatedApplicantName = true;
				}
				else
				{
					blResult = true;
					IsvalidatedApplicantName = false;
				}
				if ((TxtCompanyName == null) || (TxtCompanyName == ""))
				{
					IsvalidatedCompanyName = true;
				}
				else
				{
					blResult = true;
					IsvalidatedCompanyName = false;
				}
				if ((TxtDesignation == null) || (TxtDesignation == ""))
				{
					IsvalidatedDesignation = true;
				}
				else
				{
					blResult = true;
					IsvalidatedDesignation = false;
				}
				if ((TxtMobileNo == null) || (TxtMobileNo == ""))
				{
					IsvalidatedMobileNo = true;
				}
				else
				{
					blResult = true;
					IsvalidatedMobileNo = false;
				}				
				if ((ApplicantName != "") && (CompanyName != "") && (Designation != "") && (MobileNo != ""))
				{
					await fnRetreiveAttendrequest(ApplicantName, CompanyName, Designation, MobileNo);
				}
			}
		}
		/// <summary>
		/// Click Submit Functon
		/// </summary>
		/// <param name="ApplicantName"></param>
		/// <param name="CompanyName"></param>
		/// <param name="Designation"></param>
		/// <param name="MobileNo"></param>
		/// <returns></returns>
		private async Task fnRetreiveAttendrequest(string ApplicantName, string CompanyName, string Designation, string MobileNo)
		{
			IsBusy = true;
			StackAttendRequest2 = false;
			await Task.Delay(1000);
			await HideErrorValidation();
			string lstrResult = "true";
			bool blResult = true;
			if (blResult == true)
			{
				string strTempdate = lobjAttendinspection[0].Value.ToString();
				string[] lstCaseCode = strTempdate.Split(':');
				string lstrCT_CATEGORYCODE = lstCaseCode[0].ToString();
				string lstrCT_CASETYPECODE = lstCaseCode[1].ToString();
				string lstrCT_REQUESTTYPECODE = lstCaseCode[2].ToString();
				string lstrCT_CASESUBTYPECODE = lstCaseCode[3].ToString();
				string lstrCT_MESSAGE = "";
				string lstrCT_CASEGKEY = "";
				string lstrCT_USERCODE = gblRegisteration.strContactGkeyCRM.ToString().Trim();
				string lstrCT_USERNAME = gblRegisteration.strLoginUserLinkcode.ToString().Trim();
				string lstrct_reference = gblRegisteration.strLoginUser.ToString().Trim() + DateTime.Now.ToString("yyyyMMddHHmmss");
				string lstrCT_TITLE = "Attend Inspection Request -" + lblValContainerno;
				//string lstrCT_MESSAGE = "";
				lstrCT_MESSAGE = "Container No:" + lblValContainerno + ";Bill of Lading No:" + lblValBOLno + ";Applicant Name:" + ApplicantName + ";Company Name:" + CompanyName + ";Designation:" + Designation + ";Mobile No:" + MobileNo + ";National/ Iqama ID:" + TxtNationalId + ";";
				lstrResult = objBl.createRequest(lstrCT_CATEGORYCODE, lstrCT_CASETYPECODE, lstrCT_CASESUBTYPECODE, lstrCT_REQUESTTYPECODE, lstrCT_MESSAGE, lstrCT_CASEGKEY, lstrCT_USERNAME, lstrCT_USERCODE, lstrCT_TITLE, lstrct_reference);
				if (AppSettings.ErrorExceptionWebApi != "")
				{
					await App.Current.MainPage?.DisplayToastAsync(strServerSlowMsg, 5000);
				}
				await App.Current.MainPage?.Navigation.PushAsync(new AttendInspectionMessage());	
			}
			StackAttendRequest2 = true;
			IsBusy = false;
		}
		/// <summary>
		/// To go to Request History
		/// </summary>
		/// <returns></returns>
		private async Task tapmanifestrequesthistory()
		{
			IsBusy = true;
			StackAttendRequest2 = false;
			await Task.Delay(1000);
			await App.Current.MainPage?.Navigation.PushAsync(new RequestHistory("", "", "", "", "", "Attend Inspection"));
			StackAttendRequest2 = true;
			IsBusy = false;
		}
		public async Task HideErrorValidation()
        {
			IsvalidatedApplicantName = false;
			IsvalidatedCompanyName = false;
			IsvalidatedDesignation = false;
			IsvalidatedMobileNo = false;

		}
	}
}
