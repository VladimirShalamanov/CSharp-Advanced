using System;
using System.Collections.Generic;
using System.Text;
using Telephony.IO.Interfaces;
using Telephony.Models;

namespace Telephony.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly StationaryPhone stationaryPhone;
        private readonly Smartphone smartphone;

        private Engine()
        {
            this.stationaryPhone = new StationaryPhone();
            this.smartphone = new Smartphone();
        }
        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Start()
        {
            string[] phoneN = this.reader
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] urls = this.reader
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (string pN in phoneN)
            {
                if (!this.ValidateNum(pN))
                {
                    this.writer.WriteLine("Invalid number!");
                }
                else if (pN.Length == 7)
                {
                    this.writer.WriteLine(stationaryPhone.Call(pN));
                }
                else if (pN.Length == 10)
                {
                    this.writer.WriteLine(smartphone.Call(pN));
                }
            }

            foreach (string url in urls)
            {
                if (!this.ValidateURL(url))
                {
                    this.writer.WriteLine("Invalid URL!");
                }
                else
                {
                    this.writer.WriteLine(this.smartphone.BrowseURL(url));
                }
            }
        }

        private bool ValidateNum(string num)
        {
            foreach (char d in num)
            {
                if (!char.IsDigit(d))
                {
                    return false;
                }
            }
            return true;
        }

        private bool ValidateURL(string url)
        {
            foreach (char c in url)
            {
                if (char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
