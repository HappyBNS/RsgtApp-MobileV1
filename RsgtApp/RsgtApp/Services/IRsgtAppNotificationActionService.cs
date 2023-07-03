using System;
using System.Collections.Generic;
using System.Text;
using RsgtApp.Models;

namespace RsgtApp.Services
{
    /*
       * This type is specific to the "Rsgt application" and uses the "RsgtAppAction enumeration" to identify the action 
       * that is being triggered in a strongly-typed manner.
       * 
       * Interface IRsgtAppNotificationActionService (Services Folder) ------> Implements -------> INotificationActionService (Services Folder)
    */
    public interface IRsgtAppNotificationActionService : INotificationActionService
    {
        event EventHandler<RsgtAppAction> ActionTriggered;
    }
}
