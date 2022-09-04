namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        public class PersonDatabaseTests
        {
            private Person pesho;
            private Person gosho;

            [SetUp]
            public void TestInit()
            {
                pesho = new Person(114560, "Pesho");
                gosho = new Person(447788556699, "Gosho");
            }

            [Test]
            public void ConstructorThrowsExeptionIfPeopleAreNotExactly16()
            {
                var people = new Person[]
                {      new Person (12478,"Pesho"),
                       new Person (32092,"Misho"),
                       new Person (43589,"Gosho"),
                       new Person (49109,"Mimi"),
                       new Person (9820989,"Rosana"),
                       new Person (12345,"Peshito"),
                       new Person (32098,"Mishto"),
                       new Person (43356,"Goshko"),
                       new Person (492098,"Mimito"),
                       new Person (9836749, "Roxana"),
                       new Person (123490,"Pepi"),
                       new Person (32078,"Mishko"),
                       new Person (433590,"Gosheto"),
                       new Person (492678,"Mitko"),
                       new Person (9836745, "Roximira"),
                       new Person (8963790, "Nikolina"),
                       new Person (89637920, "Nikolinava"),
                };

                Assert.That(() => new Database(people), Throws.ArgumentException);
            }

            [Test]
            public void AddOperationShouldThrowExeptionIfCountIsMoreThan16()
            {
                var people = new Person[]
                {
                            new Person(0,"Pesho"),
                            new Person (1,"Misho"),
                            new Person (2,"Gosho"),
                            new Person (3,"Mimi"),
                            new Person (4,"Rosana"),
                            new Person(5,"Peshito"),
                            new Person (6,"Mishto"),
                            new Person (7,"Goshko"),
                            new Person (8,"Mimito"),
                            new Person (9, "Roxana"),
                            new Person(10,"Pepi"),
                            new Person (11,"Mishko"),
                            new Person (12,"Gosheto"),
                            new Person (13,"Mitko"),
                            new Person (14, "Roximira"),
                            new Person (15, "Nikolina"),
                };

                var database = new Database(people);
                var newPerson = new Person(236187, "Martina");
                Assert.That(() => database.Add(newPerson), Throws.InvalidOperationException);
            }

            [Test]
            public void ConstructorShoudInitializeCollection()
            {
                var expected = new Person[] { pesho, gosho };

                var db = new Database(expected);

                var actual = expected;

                Assert.That(actual, Is.EqualTo(expected));
            }

            [Test]
            public void AddRangeOver16ShouldThrowError()
            {
                var expected = new Person[]
                {      new Person (12478,"Pesho"),
                       new Person (32092,"Misho"),
                       new Person (43589,"Gosho"),
                       new Person (49109,"Mimi"),
                       new Person (9820989,"Rosana"),
                       new Person (12345,"Peshito"),
                       new Person (32098,"Mishto"),
                       new Person (43356,"Goshko"),
                       new Person (492098,"Mimito"),
                       new Person (9836749, "Roxana"),
                       new Person (123490,"Pepi"),
                       new Person (32078,"Mishko"),
                       new Person (433590,"Gosheto"),
                       new Person (492678,"Mitko"),
                       new Person (9836745, "Roximira"),
                       new Person (8963790, "Nikolina"),
                       new Person (432516, "Maxi")
                };


                var db = new Database();

                var actual = expected;

                Assert.That(actual, Is.EqualTo(expected));
            }

            [Test]
            public void AddShouldAddValidPerson()
            {
                var persons = new Person[] { pesho, gosho };
                var db = new Database(persons);
                var newPerson = new Person(554466, "Stamat");
                db.Add(newPerson);

                var actual = new Person[] { pesho, gosho, newPerson };
                var expected = new Person[] { pesho, gosho, newPerson };

                Assert.That(actual, Is.EqualTo(expected));
            }

            [Test]
            public void AddSameUsernameShouldThrow()
            {
                var persons = new Person[] { pesho, gosho };
                var db = new Database(persons);
                var newPerson = new Person(554466, "Gosho");

                Assert.That(() => db.Add(newPerson), Throws.InvalidOperationException);
            }

            [Test]
            public void AddSameIdShouldThrow()
            {
                var persons = new Person[] { pesho, gosho };
                var db = new Database(persons);
                var newPerson = new Person(114560, "Stamat");

                Assert.That(() => db.Add(newPerson), Throws.InvalidOperationException);
            }

            [Test]
            public void RemoveShouldRemove()
            {
                var persons = new Person[] { pesho, gosho };
                var db = new Database(persons);
                db.Remove();

                var actual = new Person[] { pesho };
                var expected = new Person[] { pesho };

                int expectedCount = 1;
                int actualCount = db.Count;

                Assert.That(() => db.FindById(447788556699), Throws.InvalidOperationException);
                Assert.That(actualCount, Is.EqualTo(expectedCount));

                Assert.That(actual, Is.EqualTo(expected));
            }

            [Test]
            public void RemoveEmptyCollectionShouldThrow()
            {
                var persons = new Person[] { };
                var db = new Database(persons);

                Assert.That(() => db.Remove(), Throws.InvalidOperationException);
            }

            [Test]
            public void FindByUsernameExistingPersonShouldReturnPerson()
            {
                var persons = new Person[] { pesho, gosho };
                var db = new Database(persons);

                var expected = pesho;
                var actual = db.FindByUsername("Pesho");

                Assert.That(actual, Is.EqualTo(expected));
            }

            [Test]
            public void FindByUsernameNonExistingPersonShouldThrow()
            {
                var persons = new Person[] { pesho, gosho };
                var db = new Database(persons);

                Assert.That(() => db.FindByUsername("Stamat"), Throws.InvalidOperationException);
            }

            [Test]
            public void FindByUsernameNullArgumentShouldThrow()
            {
                var persons = new Person[] { pesho, gosho };
                var db = new Database(persons);

                Assert.That(() => db.FindByUsername(null), Throws.ArgumentNullException);
            }

            [Test]
            public void FindByUsernameIsCaseSensitive()
            {
                var persons = new Person[] { pesho, gosho };
                var db = new Database(persons);

                Assert.That(() => db.FindByUsername("GOSHO"), Throws.InvalidOperationException);
            }

            [Test]
            public void FindByIdExistingPersonShouldReturnPerson()
            {
                var persons = new Person[] { pesho, gosho };
                var db = new Database(persons);

                var expected = pesho;
                var actual = db.FindById(114560);

                Assert.That(actual, Is.EqualTo(expected));
            }

            [Test]
            public void FindByIdNonExistingPersonShouldThrow()
            {
                var persons = new Person[] { pesho, gosho };
                var db = new Database(persons);

                Assert.That(() => db.FindById(558877), Throws.InvalidOperationException);
            }

            [Test]
            public void FindByUsernameNegativeArgumentShouldThrow()
            {
                var persons = new Person[] { pesho, gosho };
                var db = new Database(persons);

                Assert.Throws<System.ArgumentOutOfRangeException>(() => db.FindById(-5));
            }
        }
    }
}