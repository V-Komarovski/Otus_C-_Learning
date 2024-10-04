namespace ExceptionsHomework.Common
{
    /// <summary>
    /// Исключение ошибок валидации коэффициентов квадратного уравнения.
    /// </summary>
    public class CoefficientsValidationException : Exception
    {
        public CoefficientsValidationException(string message) : base(message) { }
    }
}
