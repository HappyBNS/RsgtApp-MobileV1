
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RsgtUITest;
using Xamarin.UITest;
using RsgtUITest.Resource;
using System.Threading;

namespace RsgtUITest.Pages
{
    public class Mainpage : BasicSetup
    { //Arrange-variable initalization
        string lstrContainerNo = "";

        public Mainpage(Platform platform) : base(platform)
        {
        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// Tracking shipment feature will be useful to find status of given container number.
        /// If the given container number is valid, then app will show the details about the container. 
        /// If the given container number is not valid or not available in database, then we will show “No record found” information.
        /// The captions will be modifiable through CMS.
        /// Notification:
        /// Will be settings for container status notification to given mobile #, when respective container’s status being changed up to gated out.
        /// </summary>
        /// Obsolete Date:
        /// Category:Method
        public void procBasicTracking()
        {

            //Act-focus on container number control
            Tap("AtxtcontainerNo");
            //Act-reading value from the resource file
            lstrContainerNo = BasicResource.ResourceManager.GetString("ContainerNo");
            //Act-assigning value to the control
            EnterTextID("AtxtcontainerNo", lstrContainerNo);
            //Act-dismiss keyboard
            app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("ContainerNumber");
            //Act-focus on wait for element control
           // app.WaitForElement(c => c.Marked("AlblTrack"), "Could not find myButton", new TimeSpan(0, 0, 0, 90, 0));
            /* Assert */
           // AppResult[] result = app.Query(c => c.Marked("AlblTrack").Text("Track"));
           // Assert.IsTrue(result.Any(), "The error message isn't being displayed.");
            //Act-focus on track button click
            Tap("AlblTrack");

            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("TrackingResult");
            Thread.Sleep(1000);

            //Act-focus on expand collapse button click
              Tap("AimgDownArrowIcon");
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
             app.Screenshot("ContainerDetails_Expand");
             Thread.Sleep(1000);

            //Act-focus on expand collapse button click
            //   Tap("AimgDownArrowIcon");
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            //   app.Screenshot("ContainerDetails_Collapse");
            //   Thread.Sleep(1000);
            //Act-scroll down to gated out button
            // Scrolldown("AGatedOut");

            //Act-focus on notify button click
            //   Tap("AbtnNotify");
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            //   app.Screenshot("Notify_BTNClick");

            //Act-focus on message box control 
            // Tap("message");
            //Act-reading value from the resource file
            // lstrMobile = BasicResource.ResourceManager.GetString("Mobile");
            //Act-assigning value to the control
            // app.EnterText(lstrMobile);
            //Act-dismiss keyboard
            // app.DismissKeyboard();
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            // app.Screenshot("Basictracking-MobileNo");
            //Act-focus on ok button click
            // Tap("button1");-> ok
            //Act-focus on cancel button click
            // Tap("button1");->Cancel


        }

        /// <summary>
        /// Author: VENGATESHWARAN.S
        /// Date: 10-Nov-2022 
        /// a.In-Port (Vessel Name, Shipping Line) - Show All vessels 
        /// b.Arrival(Estimated time of arrival, Vessel Name & Shipping Line, Voyage Number) – Have a facility of showing up to 30 days arrival vessel schedule.
        /// c.Departure(Actual time of departure, Vessel Name & shipping Line, Voyage Number). The cutoff time will be around 6 hours - Show 3 Days
        /// </summary>
        /// Obsolete Date:
        /// Category:Method
        public void procVesselschedule()
        {
            //Act-focus on vessel button click
            Tap("AlblVesselsch");
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
             app.Screenshot("AlblVesselsch");

            Tap("AImgInportIcon");
            Thread.Sleep(3000);
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("Inport");
            Thread.Sleep(1000);

            Tap("AImgArrivalIcon");
            Thread.Sleep(3000);
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("Arrival");
            Thread.Sleep(1000);


            Tap("AImgInportDepart");
            Thread.Sleep(3000);
            // The screenshot can be inspected after the test run to verify
            // the visual correctness of the screen.
            app.Screenshot("Departure");
            Thread.Sleep(1200);
      



        }
    }
}
