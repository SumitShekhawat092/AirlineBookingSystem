using AirlineBookingSystem.BuildingBlocks.Contracts.EvenBus.Messages;
using AirlineBookingSystem.Notifications.Application.Interfaces;
using AirlineBookingSystem.Notifications.Core.Entities;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem.Notifications.Application.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public NotificationService(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task SendNotificationAsync(Notification notification)
        {
            //Simulate sending a notification (via email or sms)
            Console.WriteLine($"Notification send to {notification.Recipient}: {notification.Message}");

            var notificationEvent = new NotificationEvent(notification.Recipient, notification.Message, notification.Type);
            await _publishEndpoint.Publish(notificationEvent);
        }
    }
}
