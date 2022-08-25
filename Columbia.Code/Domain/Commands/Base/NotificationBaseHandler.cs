﻿using MediatR;

namespace $safesolutionname$.Domain.Commands.Base
{
    public abstract class NotificationBaseHandler<TNotification> : INotificationHandler<TNotification> where TNotification : INotification
    {
        public async Task Handle(TNotification notification, CancellationToken cancellationToken)
            => await HandleNotification(notification, cancellationToken);

        public abstract Task HandleNotification(TNotification notification, CancellationToken cancellationToken);
    }
}
