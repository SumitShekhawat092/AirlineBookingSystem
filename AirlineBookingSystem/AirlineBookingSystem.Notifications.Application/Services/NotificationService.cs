using AirlineBookingSystem.Notifications.Application.Interfaces;
using AirlineBookingSystem.Notifications.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem.Notifications.Application.Services
{
    public class NotificationService : INotificationService
    {
        public async Task SendNotificationAsync(Notification notification)
        {
            //Simulate sending a notification (via email or sms)
            Console.WriteLine($"Notification send to {notification.Recipient}: {notification.Message}");
        }
    }
}
