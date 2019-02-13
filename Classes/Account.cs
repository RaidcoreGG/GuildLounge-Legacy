using System;
using System.Text.RegularExpressions;

namespace GuildLounge
{
    public class Account
    {
        private string m_sKey;

        public string Name { get; set; }
        public string Key
        {
            get
            {
                return m_sKey;
            }
            set
            {
                if (CheckKey(value))
                    m_sKey = value;
                else
                    throw new Exception("Invalid Key!");
            }
        }

        public override string ToString()
        {
            return Name + " - " + Key;
        }

        private bool CheckKey(string k)
        {
            k = k.ToUpper();
            return Regex.IsMatch(k, @"^[\w]{8}(-[\w]{4}){3}-[\w]{20}(-[\w]{4}){3}-[\w]{12}$");
        }
    }
}