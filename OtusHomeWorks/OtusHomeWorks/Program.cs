namespace OtusHomeWorks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = new Stack("a", "b", "c");
            // size = 3, Top = 'c'
            Console.WriteLine($"size = {s.Size}, Top = '{s.Top}'");
            var deleted = s.Pop();
            // Извлек верхний элемент 'c' Size = 2
            Console.WriteLine($"Извлек верхний элемент '{deleted}' Size = {s.Size}");
            s.Add("d");
            // size = 3, Top = 'd'
            Console.WriteLine($"size = {s.Size}, Top = '{s.Top}'");
            s.Pop();
            Console.WriteLine($"size = {s.Size}, Top = '{s.Top}'");
            s.Pop();
            Console.WriteLine($"size = {s.Size}, Top = '{s.Top}'");
            s.Pop();
            // size = 0, Top = null
            Console.WriteLine($"size = {s.Size}, Top = {(s.Top == null ? "null" : s.Top)}");
            //s.Pop();

            Console.WriteLine("--------------");
            var s1 = new Stack("a", "b", "c");
            s1.Merge(new Stack("1", "2", "3"));
            s1.PrintStackItems();

            Console.WriteLine("--------------");
            var s2 = Stack.Concat(new Stack("a", "b", "c"), new Stack("1", "2", "3"), new Stack("А", "Б", "В"));
            s2.PrintStackItems();
        }
    }
}
