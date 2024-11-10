namespace EventsHomework.Handlers
{
    /// <summary>
    /// Обработчик оповещения подписчика о загрузке файла.
    /// </summary>
    public interface INotificationFileDownloadEventHandler
    {
        /// <summary>
        /// Обработка старта скачивания.
        /// </summary>
        Action StartDownloadNotificateAction { get; init; }

        /// <summary>
        /// Обработка завершения скачивания.
        /// </summary>
        Action EndDownloadNotificateAction { get; init; }
    }
}
