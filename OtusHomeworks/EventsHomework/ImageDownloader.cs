using System.Net;

namespace EventsHomework
{
    /// <summary>
    /// Класс - загрузчик изображений.
    /// </summary>
    internal class ImageDownloader : IFileDownloader
    {
        public event Action? FileDownloadStarted;

        public event Action? FileDownloadCompleted;

        public async Task Download(string url, string fileName)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentException("Ссылка на изображение не должна быть пустой");
            }

            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("Отсутствует имя файла");
            }

            using var webClient = new WebClient();
            FileDownloadStarted?.Invoke(); 
            await webClient.DownloadFileTaskAsync(url, fileName);
            FileDownloadCompleted?.Invoke();
        }
    }
}
