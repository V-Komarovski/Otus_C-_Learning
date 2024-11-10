using EventsHomework.Handlers;

namespace EventsHomework
{
    internal class TestingProgram
    {
        internal static void DownloadImages(string url, int count)
        {
            IFileDownloader downloader = new ImageDownloader();
            INotificationFileDownloadEventHandler downloadHandler = new NotificationImageDownloadEventHandler();

            Subscribe(downloader, downloadHandler);

            var images = GetDownloadingFiles("C:\\Users\\Влад-ПК\\Documents\\", url, count);

            var tasks = new List<Task>(images.Length);
            using (var cts = new CancellationTokenSource())
            {
                var cancellationToken = cts.Token;
                foreach (var image in images)
                {
                    tasks.Add(Task.Run(
                        () => downloader.Download(image.Url, image.FileName),
                        cancellationToken));
                }
                ExecuteWaitingCommand(tasks, cts);
            };

            Unsubscribe(downloader, downloadHandler);
        }

        private static void Subscribe(
            IFileDownloader downloader,
            INotificationFileDownloadEventHandler notificationHandler)
        {
            ArgumentNullException.ThrowIfNull(downloader);
            ArgumentNullException.ThrowIfNull(notificationHandler);

            downloader.FileDownloadStarted += notificationHandler.StartDownloadNotificateAction;
            downloader.FileDownloadCompleted += notificationHandler.EndDownloadNotificateAction;
        }

        private static void Unsubscribe(
            IFileDownloader downloader,
            INotificationFileDownloadEventHandler notificationHandler)
        {
            ArgumentNullException.ThrowIfNull(downloader);
            ArgumentNullException.ThrowIfNull(notificationHandler);

            downloader.FileDownloadStarted -= notificationHandler.StartDownloadNotificateAction;
            downloader.FileDownloadCompleted -= notificationHandler.EndDownloadNotificateAction;
        }

        private static DownloadingFile[] GetDownloadingFiles(string basePath, string url, int count)
        {
            var files = new DownloadingFile[count];
            for (int i = 0; i < files.Length; i++)
            {
                files[i] = new DownloadingFile(url, $"{basePath}OtusPicture{i}.jpg");
            }
            return files;
        }

        private static void ExecuteWaitingCommand(List<Task> downloadImageTasks, CancellationTokenSource cts)
        {
            Console.WriteLine("Нажмите лат. клавишу A для выхода или любую другую клавишу для проверки статуса скачивания");
            ConsoleKeyInfo command;

            do
            {
                command = Console.ReadKey();
                for (int i = 0; i < downloadImageTasks.Count; i++)
                {
                    Console.WriteLine($"Загрузка изображения № {i + 1} {(downloadImageTasks[i].IsCompleted ? "завершена" : "продолжается")}");
                }
            } while (command.Key != ConsoleKey.A);
            cts.Cancel();

            return;
        }
    }
}
