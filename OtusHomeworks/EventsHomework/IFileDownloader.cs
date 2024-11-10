namespace EventsHomework
{
    /// <summary>
    /// Интерфейс для скачивания файлов.
    /// </summary>
    public interface IFileDownloader
    {
        /// <summary>
        /// Стартовое событие при скачивании файла.
        /// </summary>
        event Action FileDownloadStarted;

        /// <summary>
        /// Событие успешного завершения скачивания файла.
        /// </summary>
        event Action FileDownloadCompleted;

        /// <summary>
        /// Скачивает файл по ссылке.
        /// </summary>
        /// <param name="url">Ссылка на скачиваемый файл.</param>
        /// <param name="fileName">Имя сохраняемого файла, включая путь.</param>
        Task Download(string url, string fileName);
    }
}
