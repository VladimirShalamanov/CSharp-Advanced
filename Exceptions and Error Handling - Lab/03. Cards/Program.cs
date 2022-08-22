namespace _03._Cards
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            var cards = new List<Card>();
            string[] arr = Console.ReadLine().Split(", ");
            for (int i = 0; i < arr.Length; i++)
            {
                try
                {
                    ReadCard(arr[i]);
                    string[] c = arr[i].Split();
                    Card card = new Card(c[0], c[1]);
                    cards.Add(card);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            foreach (Card c in cards)
            {
                Console.Write(c.ToString() + ' ');
            }
        }

        public static void ReadCard(string arr)
        {
            string[] card = arr.Split();
            string face = card[0];
            string suit = card[1];

            if (face != "2" && face != "3" && face != "4" && face != "5" && face != "6" && face != "7" && face != "8" &&
                face != "9" && face != "10" && face != "J" && face != "Q" && face != "K" && face != "A" ||
                suit != "S" && suit != "H" && suit != "D" && suit != "C")
            {
                throw new Exception("Invalid card!");
            }
        }

        public class Card
        {
            public Card(string face, string suit)
            {
                this.Face = face;
                this.Suit = suit;
            }

            public string Face { get; set; }
            public string Suit { get; set; }

            public override string ToString()
            {
                string suit = string.Empty;
                if (this.Suit == "S") suit = "\u2660";
                if (this.Suit == "H") suit = "\u2665";
                if (this.Suit == "D") suit = "\u2666";
                if (this.Suit == "C") suit = "\u2663";
                return $"[{this.Face}{suit}]";
            }

        }
    }
}
