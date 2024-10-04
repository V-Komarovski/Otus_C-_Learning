namespace ExceptionsHomework.Common
{
    /// <summary>
    /// Ошибка отрицательного дискриминанта квадратного уравнения.
    /// </summary>
    public class NegativeDiscriminantException : Exception
    {
        public NegativeDiscriminantException(string message) : base(message) {}
    }
}
