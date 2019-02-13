namespace GuildLounge
{
    #region overviews
    public class ModuleData
    {
        //WALLET
        public Wallet wallet { get; set; }
        //TRADING POST
        public TradingPost tradingpost { get; set; }
        //LI
        public int materialLI { get; set; }
        public int legendary_armor { get; set; }
        public int refined_armor { get; set; }
        public int gift_of_prowess { get; set; }
        public int envoy_insignia { get; set; }
        public int sumLI
        {
            get { return materialLI + legendary_armor + refined_armor + gift_of_prowess; }
        }

        //LD
        public int materialLD { get; set; }
        public int sumLD
        {
            get { return materialLD; }
        }
    }

    public class Wallet
    {
        public int coins { get; set; }
        public int karma { get; set; }
        public int laurels { get; set; }
        public int gems { get; set; }
        public int magnetite { get; set; }
        public int gaeting { get; set; }
        public int fractalrelic { get; set; }
        public int pristinefractalrelic { get; set; }
        public int badgeofhonor { get; set; }
        public int wvwskirmishticket { get; set; }
        public int ascendedshardsofglory { get; set; }
        public int pvpleagueticket { get; set; }
    }

    public class TradingPost
    {
        public int coins { get; set; }
        public Item[] items { get; set; }
    }

    public class RaidCMs
    {
        public bool KeepConstruct { get; set; }
        public bool Cairn { get; set; }
        public bool MursaatOverseer { get; set; }
        public bool Samarog { get; set; }
        public bool Deimos { get; set; }
        public bool SoullessHorror { get; set; }
        public bool Statues { get; set; }
        public bool Dhuum { get; set; }
        public bool ConjuredAmalgamate { get; set; }
        public bool LargosTwins { get; set; }
        public bool Qadim { get; set; }
    }

    public class Dailies
    {
        public Achievement[] pve { get; set; }
        public Achievement[] pvp { get; set; }
        public Achievement[] wvw { get; set; }
        public Achievement[] fractals { get; set; }
    }
    #endregion

    #region character
    public class Character
    {
        public string name { get; set; }
        public Item[] equipment { get; set; }
        public Bag[] bags { get; set; }
    }

    public class Bag
    {
        public int id { get; set; }
        public Item[] inventory { get; set; }
    }

    public class Item
    {
        public int id { get; set; }
        public int count { get; set; }
    }
    #endregion

    #region misc
    public class Currency
    {
        public int id { get; set; }
        public int value { get; set; }
    }
    
    public class Material
    {
        public int id { get; set; }
        public int category { get; set; }
        public int count { get; set; }
    }

    public class Achievement
    {
        public int id { get; set; }
        public string name { get; set; }
        //ONLY FOR CERTAIN ACHIEVEMENTS
        public int[] bits { get; set; }
        //ONLY FOR ACCOUNT ACHIEVEMENTS
        public bool done { get; set; }
    }
    #endregion
}