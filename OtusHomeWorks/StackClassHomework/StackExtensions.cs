namespace StackClassHomework
{
    /// <summary>
    /// Расширения для класса Stack
    /// </summary>
    public static class StackExtensions
    {
        /// <summary>
        /// Выполняет слияние двух стеков.
        /// </summary>
        /// <param name="head">Целевой стек.</param>
        /// <param name="source">Присоединяемый стек.</param>
        /// <returns>Объединенный стек.</returns>
        public static Stack Merge(this Stack head, Stack source)
        {
            ArgumentNullException.ThrowIfNull(head);
            ArgumentNullException.ThrowIfNull(source);

            var stackSize = source.Size;

            var sourceElementsArray = new string[stackSize];
            for (int i = 0; i < stackSize; i++)
            {
                sourceElementsArray[i] = source.Pop();       
            }
 
            for (int i = 0; i < sourceElementsArray.Length; i++)
            {
                head.Add(sourceElementsArray[i]);
            }

            return head;
        }
    }
}