
namespace P08.CollectionHierarchy.Models
{
    using Interfaces;
    using System.Collections.Generic;
    using System.Linq;

    public class AddRemoveCollection<T> : IAddRemoveCollection<T>
    {
        private readonly IList<T> data;

        public AddRemoveCollection()
        {
            this.data = new List<T>();
        }
        public int Add(T item)
        {
            this.data.Insert(0, item);
            return 0;
        }

        public T Remove()
        {
            T elRemove = this.data.LastOrDefault();
            if (elRemove != null)
            {
                this.data.Remove(elRemove);
            }
            return elRemove;
        }
    }
}
