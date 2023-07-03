using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RsgtApp.Services
{
    /*
     * This will handle the interaction between the client and backend service.
    */
    public interface INotificationRegistrationService
    {
        Task DeregisterDeviceAsync();
        Task RegisterDeviceAsync(params string[] tags);
        Task RefreshRegistrationAsync();
    }
}
