using System.Drawing;

namespace GuildLounge
{
    //GUILDLOUNGE
    public class ModuleData
    {
        public Wallet Wallet { get; set; }
        public TradingPost TradingPost { get; set; }

        //LI
        public int OnHandLI { get; set; }
        public int LegendaryArmor { get; set; }
        public int RefinedArmor { get; set; }
        public int GiftOfProwess { get; set; }
        public int EnvoyInsignia { get; set; }
        public int TotalLegendaryInsights
        {
            get { return OnHandLI + LegendaryArmor + RefinedArmor + GiftOfProwess; }
        }

        //LD
        public int OnHandLD { get; set; }
        public int GiftOfCompassion { get; set; }
        public int Coalescence { get; set; }
        public int TotalLegendaryDivinations
        {
            get { return OnHandLD + GiftOfCompassion + Coalescence; }
        }
    }

    public class Wallet
    {
        public int Coins { get; set; }
        public int Karma { get; set; }
        public int Laurels { get; set; }
        public int Gems { get; set; }
        public int MagnetiteShards { get; set; }
        public int GaetingCrystals { get; set; }
        public int FractalRelics { get; set; }
        public int PristineFractalRelics { get; set; }
        public int BadgeOfHonor { get; set; }
        public int SkirmishTicket { get; set; }
        public int AscendedShardsOfGlory { get; set; }
        public int LeagueTicket { get; set; }
    }

    public class TradingPost
    {
        public int Coins { get; set; }
        public Item[] Items { get; set; }
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

        public bool Adina { get; set; }
        public bool Sabir { get; set; }
        public bool QadimThePeerless { get; set; }
    }

    //GUILDLOUNGE API
    class NewsObject
    {
        public string Link { get; set; }
        public string HeaderImageLink { get; set; }
        public Image HeaderImage { get; set; }
    }

    class BuildInfo
    {
        public int BuildID { get; set; }
        public int RevisionID { get; set; }
        public int UpdaterBuildID { get; set; }
        public int UpdaterRevisionID { get; set; }
        public string Note { get; set; }
    }

    //GW2 API
    public class Dailies
    {
        public Achievement[] PvE { get; set; }
        public Achievement[] PvP { get; set; }
        public Achievement[] WvW { get; set; }
        public Achievement[] Fractals { get; set; }
    }
    
    public class Character
    {
        public string Name { get; set; }
        public Item[] Equipment { get; set; }
        public Bag[] Bags { get; set; }
    }

    public class Bag
    {
        public int Id { get; set; }
        public Item[] Inventory { get; set; }
    }

    public class Item
    {
        public int Id { get; set; }
        public int Count { get; set; }
    }

    public class Currency
    {
        public int Id { get; set; }
        public int Value { get; set; }
    }
    
    public class Material
    {
        public int Id { get; set; }
        public int Count { get; set; }
    }

    public class Achievement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //ONLY FOR CERTAIN ACHIEVEMENTS
        public int[] Bits { get; set; }
        //ONLY FOR ACCOUNT ACHIEVEMENTS
        public bool Done { get; set; }
    }

    public class TokenInfo
    {
        public string[] Permissions { get; set; }
        public override string ToString()
        {
            return string.Join(",", Permissions);
        }
    }
}