namespace P08.CollectionHierarchy.Models
{
    using Interfaces;
    using System.Collections.Generic;
    using System.Linq;
    public class MyList<T> : IMyList<T>
    {
        private readonly List<T> data;

        public MyList()
        {
            this.data = new List<T>();
        }
        public int Used
            => this.data.Count;

        public int Add(T item)
        {
            this.data.Insert(0, item);
            return 0;
        }

        public T Remove()
        {
            T elRemove = this.data.FirstOrDefault();
            if (elRemove != null)
            {
                this.data.Remove(elRemove);
            }
            return elRemove;
        }
    }
}
