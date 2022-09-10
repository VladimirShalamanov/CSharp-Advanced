using System;
using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{
    [Test]
    public void CreateHero()
    {
        string name = "Pesho";
        int level = 3;
        var hero = new Hero(name, level);

        Assert.AreEqual(name, hero.Name);
        Assert.AreEqual(level, hero.Level);
    }

    [Test]
    public void CreateRepo()
    {
        var rep = new HeroRepository();
        var list = new List<Hero>();

        Assert.AreEqual(0, list.Count);
    }

    [Test]
    public void AddNewHero()
    {
        var rep = new HeroRepository();
        var h1 = new Hero("Pesho", 4);

        string actualMessege = rep.Create(h1);
        string expectedMessege = "Successfully added hero Pesho with level 4";

        Assert.AreEqual(expectedMessege, actualMessege);
    }

    [Test]
    public void NullCreate()
    {
        var rep = new HeroRepository();
        var h1 = new Hero("Pencho", 5);
        h1 = null;
        Assert.Throws<ArgumentNullException>(() => rep.Create(h1));
    }

    [Test]
    public void DublicateHeroAdd()
    {
        var rep = new HeroRepository();
        var h1 = new Hero("Pesho", 4);
        rep.Create(h1);

        Assert.Throws<InvalidOperationException>(() => rep.Create(h1));
    }

    [Test]
    public void RemoveHero()
    {
        var rep = new HeroRepository();
        var h1 = new Hero("Pesho", 4);
        var h2 = new Hero("Dimo", 5);

        rep.Create(h1);
        rep.Create(h2);

        bool isRemoved = rep.Remove("Dimo");

        Assert.IsTrue(isRemoved);
    }

    [Test]
    [TestCase(null)]
    [TestCase("   ")]
    public void ErrorRemoveHero(string name)
    {
        var rep = new HeroRepository();
        var h1 = new Hero("Pesho", 4);
        var h2 = new Hero("Dimo", 5);

        rep.Create(h1);
        rep.Create(h2);

        Assert.Throws<ArgumentNullException>(() => rep.Remove(name));
    }

    [Test]
    public void GetHeroWithHighestLevel()
    {
        var rep = new HeroRepository();
        var h1 = new Hero("Pesho1", 3);
        var h2 = new Hero("Pesho2", 13);
        var h3 = new Hero("Pesho3", 8);

        rep.Create(h1);
        rep.Create(h2);
        rep.Create(h3);

        Hero top = rep.GetHeroWithHighestLevel();

        Assert.AreEqual(h2, top);
    }

    [Test]
    public void GetOneHeroWithHighestLevel()
    {
        var rep = new HeroRepository();
        var h1 = new Hero("Pesho1", 3);

        rep.Create(h1);

        Hero top = rep.GetHeroWithHighestLevel();

        Assert.AreEqual(h1, top);
    }

    [Test]
    public void NameGetHero()
    {
        var rep = new HeroRepository();
        var h1 = new Hero("Pesho1", 3);
        var h2 = new Hero("Pesho2", 7);

        rep.Create(h1);
        rep.Create(h2);

        Hero name = rep.GetHero("Pesho2");

        Assert.AreEqual(h2, name);
    }

    [Test]
    public void NullNameGetHero()
    {
        var rep = new HeroRepository();

        Hero name = rep.GetHero("Pesho2");

        Assert.AreEqual(null, name);
    }

    [Test]
    public void CollectionHero()
    {
        var rep = new HeroRepository();
        var h1 = new Hero("Pesho1", 3);
        var h2 = new Hero("Pesho2", 7);

        var list = new List<Hero>();
        rep.Create(h1);
        rep.Create(h2);
        list.Add(h1);
        list.Add(h2);

        IReadOnlyCollection<Hero> ReadHeroes = rep.Heroes;
        IReadOnlyCollection<Hero> listHeroes = list.AsReadOnly();

        Assert.AreEqual(2, ReadHeroes.Count);
        Assert.AreEqual(listHeroes, ReadHeroes);
    }

    [Test]
    public void NullCollectionHero()
    {
        var rep = new HeroRepository();

        var list = new List<Hero>();

        IReadOnlyCollection<Hero> ReadHeroes = rep.Heroes;
        IReadOnlyCollection<Hero> listHeroes = list.AsReadOnly();

        Assert.AreEqual(0, ReadHeroes.Count);
        Assert.AreEqual(listHeroes, ReadHeroes);
    }
}