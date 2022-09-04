namespace test_app
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            HeroRepository<string> asd = new HeroRepository<string>();
            asd.Add("car");
            Console.WriteLine(String.Join(' ', asd));
            Console.WriteLine(asd.FindByName("car"));
        }
    }

    public class HeroRepository<T>
    {
        public List<T> hero => new List<T>();
        public IReadOnlyCollection<T> Models => hero;

        public void Add(T model)
        {
            hero.Add(model);
        }

        public T FindByName(string name)
        {
            var he = hero.FirstOrDefault(h => h.Equals(name));
            if (he != null)
            {
                return he;
            }
            return hero.Min();
        }
    }
}
