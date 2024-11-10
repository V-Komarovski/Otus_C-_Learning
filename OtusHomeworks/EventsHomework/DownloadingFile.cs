namespace EventsHomework
{
    /// <summary>
    /// Информация о скачиваемом файле.
    /// </summary>
    /// <param name="Url">Ссылка для загрузки файла.</param>
    /// <param name="FileName">Имя сохраняемого файла.</param>
    public record DownloadingFile(string Url, string FileName);
}
