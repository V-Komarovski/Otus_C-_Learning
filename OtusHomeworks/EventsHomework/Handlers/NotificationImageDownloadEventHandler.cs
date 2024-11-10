namespace EventsHomework.Handlers
{
    /// <summary>
    /// Обработчик оповещения подписчика о скачивании изображения.
    /// </summary>
    internal class NotificationImageDownloadEventHandler : INotificationFileDownloadEventHandler
    {
        public Action StartDownloadNotificateAction { get; init; }
        public Action EndDownloadNotificateAction { get; init; }

        public NotificationImageDownloadEventHandler()
        {
            StartDownloadNotificateAction = () => Console.WriteLine("Скачивание изображения началось");
            EndDownloadNotificateAction = () => Console.WriteLine("Скачивание изображения завершено");
        }
    }
}
