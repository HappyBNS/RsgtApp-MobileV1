using System;
using System.Collections.Generic;
using System.Text;

namespace RsgtApp.Services
{
    /*
      * This is used as a simple mechanism to centralize the handling of notification actions.
    */
    public interface INotificationActionService
    {
        void TriggerAction(string action);
    }
}
