using StackClassHomework.Common;

namespace StackClassHomework
{
    public sealed class Stack
    { 
        private StackItem? _firstItem;
        private StackItem? _lastItem;

        public int Size { get; private set; }
        public string? Top => _lastItem?.Item;

        public Stack(params string[] items)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (!string.IsNullOrEmpty(items[i]))
                {
                    Add(items[i]);
                }
            }
        }

        /// <summary>
        /// Добавляет новый элемент в стек.
        /// </summary>
        /// <param name="item">Элемент.</param>
        public Stack Add(string item)
        {
            if (string.IsNullOrEmpty(item))
            {
                throw new ArgumentException("Передан пустой элемент в стек");
            }

            var newLastItem = new StackItem { Item = item };

            if (_firstItem is null)
            {
                _firstItem = newLastItem;
                _lastItem = newLastItem;
            }
            else
            {
                var currentLastItem = _lastItem;
                currentLastItem!.NextItem = newLastItem;
                _lastItem = newLastItem;
            }

            Size++;

            return this;
        }

        /// <summary>
        /// Удаляет верхний элемент стека.
        /// </summary>
        public string? Pop()
        {
            if (_firstItem is null)
            {
                throw new StackException("Стек пустой");
            }

            var currentLastItem = Top;

            if (_firstItem == _lastItem)
            {
                _firstItem = null;
                _lastItem = null;    
            }
            else
            {
                var newLastItem = _firstItem;
                while (newLastItem!.NextItem != _lastItem)
                {
                    newLastItem = newLastItem.NextItem;
                }

                newLastItem.NextItem = null;
                _lastItem = newLastItem;
            }

            Size--;

            return currentLastItem;
        }

        /// <summary>
        /// Объединяет набор стеков в один.
        /// </summary>
        /// <param name="stacks">Набор стеков.</param>
        /// <returns>Объединенный стек с элементами в обратном порядке.</returns>
        public static Stack Concat(params Stack[] stacks)
        {
            ArgumentNullException.ThrowIfNull(stacks);

            var result = new Stack();
            for (var i = 0; i < stacks.Length; i++)
            {
                result.Merge(stacks[i]);
            }

            return result;
        }

        /// <summary>
        /// Метод для отображения элементов стека.
        /// Только для отладки.
        /// </summary>
        public void PrintStackItems()
        {
            var item = _firstItem;
            while (item is not null)
            {
                Console.WriteLine(item.Item);
                item = item.NextItem;
            }
        }

        private sealed class StackItem
        {
            internal string Item { get; set; } = string.Empty;
            internal StackItem? NextItem { get; set; }
        }
    }
}