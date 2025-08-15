using AirlineBookingSystem.Notifications.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem.Notifications.Core.Repositories
{
    public interface INotificationRepository
    {
        Task LogNotificationAsync(Notification notification);
    }
}
