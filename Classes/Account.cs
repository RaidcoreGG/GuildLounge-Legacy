using System;
using System.Text.RegularExpressions;

namespace GuildLounge
{
    public class Account
    {
        private static readonly ApiHandler _api = new ApiHandler();
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
                {
                    m_sKey = value;
                    FetchPermissions(value);
                }
                else
                    throw new Exception("Invalid Key Format!");
            }
        }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Permissions { get; set; }

        public override string ToString()
        {
            return Name + " - Key ends with " + Key.Substring(60);
        }
        private bool CheckKey(string k)
        {
            k = k.ToUpper();
            return Regex.IsMatch(k, @"^[\w]{8}(-[\w]{4}){3}-[\w]{20}(-[\w]{4}){3}-[\w]{12}$");
        }
        private async void FetchPermissions(string accessToken)
        {
            TokenInfo APIResponse = await _api.GetResponse<TokenInfo>("tokeninfo", "access_token=" + accessToken);
            Permissions = APIResponse.ToString();
        }
    }
}