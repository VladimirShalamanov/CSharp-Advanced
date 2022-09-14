// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Entities
{
	using NUnit.Framework;
    using System.Collections.Generic;
	using System;

    [TestFixture]
	public class StageTests
    {
		[Test]
        public void CreatePerformer()
        {
            var performer = new Performer("Pesho", "Niko", 20);
            var list = new List<Song>();

            Assert.AreEqual("Pesho Niko", performer.FullName);
            Assert.AreEqual(20, performer.Age);
            Assert.AreEqual(list, performer.SongList);
            Assert.IsNotNull(performer);
        }

        [Test]
		public void CreateSong()
		{
			var dur = new TimeSpan(0, 4, 20);
			var s = new Song("Biala Roza", dur);

			Assert.AreEqual("Biala Roza", s.Name);
			Assert.AreEqual(dur, s.Duration);
		}

		[Test]
		public void CreateSongToString()
		{
			var performer = new Song("Biala Roza", new TimeSpan(0, 4, 20));

			string ovver = performer.ToString();
			string expected = "Biala Roza (04:20)";

			Assert.AreEqual(expected, ovver);
		}

		[Test]
		public void CreateStage()
		{
			var stage = new Stage();
			var p = new List<Performer>();

			Assert.AreEqual(p, stage.Performers);
		}

		[Test]
		public void CollectionStage()
		{
			var stage = new Stage();
			var p = new List<Performer>();

			Assert.AreEqual(p.AsReadOnly(), stage.Performers);
		}

		[Test]
		public void AddPerformer()
		{
			var stage = new Stage();
			var performer = new Performer("Pesho", "Niko", 20);

			stage.AddPerformer(performer);

			Assert.AreEqual(1, stage.Performers.Count);
		}

		[Test]
		public void AddNullPerformer()
		{
			var stage = new Stage();
			Performer performer = null;

			Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(performer));
		}

		[Test]
		public void AddUnder18Performer()
		{
			var stage = new Stage();
			var performer = new Performer("Pesho", "Niko", 17);

			Assert.Throws<ArgumentException>(() => stage.AddPerformer(performer));
		}

		[Test]
		public void AddSong()
		{
			var stage = new Stage();
			var song = new Song("Biala Roza", new TimeSpan(0, 4, 20));
			var songs = new List<Song>();

			stage.AddSong(song);
			songs.Add(song);

			Assert.AreEqual(1, songs.Count);
		}

		[Test]
		public void AddNullSong()
		{
			var stage = new Stage();
			Song s = null;

			Assert.Throws<ArgumentNullException>(() => stage.AddSong(s));
		}

		[Test]
		public void AddUnder1MinSong()
		{
			var stage = new Stage();
			var song = new Song("Biala Roza", new TimeSpan(0, 0, 40));

			Assert.Throws<ArgumentException>(() => stage.AddSong(song));
		}

		[Test]
		public void AddSongToPerformer()
		{
			var stage = new Stage();
			var performer = new Performer("Pesho", "Niko", 19);
			var song = new Song("Biala Roza", new TimeSpan(0, 4, 20));

			stage.AddPerformer(performer);
			stage.AddSong(song);

			string actual = stage.AddSongToPerformer("Biala Roza", "Pesho Niko");

			var expected = "Biala Roza (04:20) will be performed by Pesho Niko";

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void AddSongToPerformerNullSong()
		{
			var stage = new Stage();

			Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer(null, "Bamby"));
		}

		[Test]
		public void AddSongToPerformerNulName()
		{
			var stage = new Stage();

			Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer("Tralala", null));
		}

		[Test]
		public void Play()
		{
			var stage = new Stage();
			var performer = new Performer("Pesho", "Niko", 19);
			var song = new Song("Biala Roza", new TimeSpan(0, 4, 20));
			var song1 = new Song("Tralala", new TimeSpan(0, 3, 30));

			stage.AddPerformer(performer);
			stage.AddSong(song);
			stage.AddSong(song1);
			stage.AddSongToPerformer("Biala Roza", "Pesho Niko");
			stage.AddSongToPerformer("Tralala", "Pesho Niko");

			string actual = stage.Play();

			var expected = "1 performers played 2 songs";

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void PlayNull()
		{
			var stage = new Stage();

			string actual = stage.Play();

			var expected = "0 performers played 0 songs";

			Assert.AreEqual(expected, actual);
		}
	}
}