using System;
using System.Text.RegularExpressions;

namespace GuildLounge
{
    public class Extension
    {
        private string _Link { get; set; }

        public string Name { get; set; }
        public string Link
        {
            get
            {
                return _Link;
            }
            set
            {
                if (ValidateLink(value))
                    _Link = value;
                else
                    throw new Exception("Invalid Link!");
            }
        }
        public bool IsMain { get; set; }

        private bool ValidateLink(string link)
        {
            return Regex.IsMatch(link, @"(http(s)?:\/\/)?(www.)?[\w-_\/]*.dll");
        }
        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Name) && !string.IsNullOrWhiteSpace(Name))
                return Name;
            else
                return _Link;
        }
    }
}