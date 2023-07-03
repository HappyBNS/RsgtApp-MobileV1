using System;
using System.Collections.Generic;
using System.Text;
using RsgtApp.Models;
using System.Linq;

namespace RsgtApp.Services
{

    /*
     * Class RsgtAppNotificationActionService(Services Folder) -----> Implements ---->  IRsgtAppNotificationActionService (Services Folder)
     * TriggerAction implemented
     * 
     * enum RsgtAppAction (Models Folder) used in EventHandler, 
    */

    public class RsgtAppNotificationActionService : IRsgtAppNotificationActionService
    {
        readonly Dictionary<string, RsgtAppAction> _actionMappings = new Dictionary<string, RsgtAppAction>
        {
            { "action_a", RsgtAppAction.ActionA },
            { "action_b", RsgtAppAction.ActionB }
        };

        public event EventHandler<RsgtAppAction> ActionTriggered = delegate { };

        public void TriggerAction(string action)
        {
            if (!_actionMappings.TryGetValue(action, out var RsgtAppAction))
                return;

            List<Exception> exceptions = new List<Exception>();

            foreach (var handler in ActionTriggered?.GetInvocationList())
            {
                try
                {
                    handler.DynamicInvoke(this, RsgtAppAction);
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                }
            }

            if (exceptions.Any())
                throw new AggregateException(exceptions);
        }

    }
}
