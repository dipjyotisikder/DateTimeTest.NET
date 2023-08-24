namespace Ordering
{
    internal class ConvertedCode
    {
        public static void Main(string[] args)
        {
            var fruits = new List<Fruit>
            {
                new Fruit("Mango", "small", 2),
                new Fruit("Jak", "big", 2),
                new Fruit("Apple", "small", 1),
                new Fruit("Mango", "big", 2),
                new Fruit("Jak", "small", 5),
                new Fruit("Orange", "small", 1),
                new Fruit("Mango", "small", 2)
            };

            var comparator = Comparer<Fruit>.Create((f1, f2) =>
            {
                int sizeComparison = f1.Size.CompareTo(f2.Size);
                if (sizeComparison != 0)
                    return sizeComparison;
                return f1.Expire.CompareTo(f2.Expire);
            });

            var groupedFruits = fruits.GroupBy(f => f.Name)
                                      .ToDictionary(g => g.Key, g => g.OrderBy(f => f, comparator).ToList());

            var sortedGroupedFruits = new SortedDictionary<string, List<Fruit>>(groupedFruits);

            // Print the grouped and sorted fruits
            foreach (var entry in sortedGroupedFruits)
            {
                Console.WriteLine("Name: " + entry.Key);
                foreach (var fruit in entry.Value)
                {
                    Console.WriteLine(fruit);
                }
                Console.WriteLine();
            }
        }
    }

    public class Fruit
    {
        public string Name { get; set; }
        public string Size { get; set; }
        public int Expire { get; set; }

        public Fruit(string name, string size, int expire)
        {
            Name = name;
            Size = size;
            Expire = expire;
        }

        public override string ToString()
        {
            return $"Fruit{{name='{Name}', size='{Size}', expire={Expire}}}";
        }
    }
}