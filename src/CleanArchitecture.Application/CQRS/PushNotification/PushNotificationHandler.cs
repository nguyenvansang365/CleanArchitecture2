using CleanArchitecture.Application.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.CQRS.PushNotification.Handlers
{
    public class PushNotificationHandler : INotificationHandler<PushNotification>
    {
        private readonly Microsoft.Extensions.Logging.ILogger _logger;
        public PushNotificationHandler(ILogger<PushNotificationHandler> logger)
        {
            _logger = logger;
        }
        public async Task Handle(PushNotification notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{notification.Message} at : {notification.DateTime}");
        }
    }
}
