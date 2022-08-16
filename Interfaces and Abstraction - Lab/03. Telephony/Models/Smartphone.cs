using System;
using System.Collections.Generic;
using System.Text;
using Telephony.Models.Interfaces;

namespace Telephony.Models
{
    public class Smartphone : ICallable, IBrowseable
    {
        public string Call(string number)
        {
            return $"Calling... {number}";
        }
        public string BrowseURL(string site)
        {
            return $"Browsing: {site}!";
        }
    }
}
