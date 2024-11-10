namespace EventsHomework
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            var url = "https://img3.akspic.ru/crops/7/3/3/9/7/179337/179337-8k_priroda-priroda-planshet-voda-gidroresursy-7680x4320.jpg";
            TestingProgram.DownloadImages(url, 10);
        }
    }
}
