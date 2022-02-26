namespace Awarean.Sdk.SharedKernel.Services;

public interface INotifier<TNotification, TResult>
{
    Task<TResult> NotifyAsync(TNotification notification);

    event NotitificationHandler<TNotification> NotificationSent;

    delegate Task NotitificationHandler<T>(object? sender, T eventArgs);
}