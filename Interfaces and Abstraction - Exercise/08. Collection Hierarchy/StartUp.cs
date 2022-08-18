namespace P08.CollectionHierarchy
{
    using Models.Interfaces;
    using Models;
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());

            IAddCollection<string> addCollection = new AddCollection<string>();
            IAddRemoveCollection<string> addRemoveCollection = new AddRemoveCollection<string>();
            IMyList<string> myList = new MyList<string>();

            AddToCollections(addCollection, arr);
            AddToCollections(addRemoveCollection, arr);
            AddToCollections(myList, arr);

            RemoveCollections(addRemoveCollection, n);
            RemoveCollections(myList, n);
        }

        private static void AddToCollections(IAddCollection<string> collection, string[] arr)
        {
            foreach (string a in arr)
            {
                Console.Write(collection.Add(a) + " ");
            }
            Console.WriteLine();
        }

        private static void RemoveCollections(IAddRemoveCollection<string> collection, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(collection.Remove() + " ");
            }
            Console.WriteLine();
        }
    }
}
