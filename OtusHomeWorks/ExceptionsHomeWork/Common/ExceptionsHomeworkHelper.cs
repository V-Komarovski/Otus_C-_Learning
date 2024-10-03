using System.Collections;
using System.Text;

namespace ExceptionsHomework.Common
{
    /// <summary>
    /// Вспомогательный класс для методов общего назначения при работе с консолью.
    /// </summary>
    internal static class ExceptionsHomeworkHelper
    {
        public const char FirstEquationCoefficientName = 'a';

        /// <summary>
        /// Форматирует сообщение об ошибки расчета квадратного уравнения.
        /// </summary>
        /// <param name="message">Текст ошибки.</param>
        /// <param name="severity">Уровень критичности ошибки.</param>
        /// <param name="data">Данные для расчета уравнения.</param>
        public static void FormatData(string message, Severity severity, IDictionary data)
        {
            var stringBuilder = new StringBuilder();
            for (int i = 0; i < 50; i++)
            {
                stringBuilder.Append("-");
            }
            var stringLine = stringBuilder.ToString();

            var colorSettings = GetConsoleColorsBySeverity(severity);
            Console.BackgroundColor = colorSettings.backGround;
            Console.ForegroundColor = colorSettings.foreGround;

            Console.WriteLine($"\n{stringLine}\n{message}\n{stringLine}");
            Console.WriteLine();

            var lastCoefficientName = FirstEquationCoefficientName + data.Count;
            for (char i = FirstEquationCoefficientName; i < lastCoefficientName; i++)
            {
                Console.WriteLine($"{i} = {data[i]}");
            }

            ResetConsoleColorSettings();
        }

        /// <summary>
        /// Устанавливает цвет текста и фона консоли по критичности ошибки.
        /// </summary>
        /// <param name="severity">Уровень критичности ошибки.</param>
        public static (ConsoleColor backGround, ConsoleColor foreGround) GetConsoleColorsBySeverity(Severity severity) =>
            severity switch
            {
                Severity.Error => new(ConsoleColor.Red, ConsoleColor.White),
                Severity.Warning => new(ConsoleColor.Yellow, ConsoleColor.Black),
                _ => new(ConsoleColor.Black, ConsoleColor.White),
            };

        /// <summary>
        /// Сбрасывает настройки фона консоли.
        /// </summary>
        public static void ResetConsoleColorSettings()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
