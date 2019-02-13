using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace GuildLounge
{
    public class ApiHandler
    {
        private const string _apiBase = "https://api.guildwars2.com/v2/";
        private static readonly HttpClient _client = new HttpClient();
        private ModuleData m_oModuleData;

        public async Task<T> GetResponse<T>(string endPoint, params string[] args)
        {
            Console.WriteLine("[API: FETCHING " + endPoint.ToUpper() + "]");
            //Console.WriteLine(String.Join("?", (_apiBase + endPoint), String.Join("&", args)));
            string response = await _client.GetStringAsync(String.Join("?", (_apiBase + endPoint), String.Join("&", args)));
            return new JavaScriptSerializer().Deserialize<T>(response);
        }
        
        public async Task<RaidCMs> FetchRaidCMs(string accessToken)
        {
            RaidCMs resp = new RaidCMs();
            //ID 247 = DUMMY ACHIEVEMENT, GLADIATOR IS BOUND TO EVERY ACCOUNT
            Achievement[] achievements = await GetResponse<Achievement[]>("account/achievements", "access_token=" + accessToken, "ids=247,3019,3334,3287,3342,3292,3392,3993,4037,3979,4416,4429,4355");
            
            foreach (Achievement a in achievements)
            {
                switch (a.Id)
                {
                    case 3019:
                        resp.KeepConstruct = a.Done;
                        break;
                    case 3392:
                        if (a.Bits.Contains(0))
                            resp.Cairn = true;
                        if (a.Bits.Contains(1))
                            resp.MursaatOverseer = true;
                        if (a.Bits.Contains(2))
                            resp.Samarog = true;
                        if (a.Bits.Contains(3))
                            resp.Deimos = true;
                        break;
                    case 3993:
                        resp.SoullessHorror = a.Done;
                        break;
                    case 4037:
                        resp.Statues = a.Done;
                        break;
                    case 3979:
                        resp.Dhuum = a.Done;
                        break;
                    case 4416:
                        resp.ConjuredAmalgamate = a.Done;
                        break;
                    case 4429:
                        resp.LargosTwins = a.Done;
                        break;
                    case 4355:
                        resp.Qadim = a.Done;
                        break;
                }
            }

            return resp;
        }

        public async Task<ModuleData> FetchModuleData(string accessToken)
        {
            Console.WriteLine("[OVERVIEW: INIT]");
            DateTime dt = DateTime.Now;

            m_oModuleData = new ModuleData();
            m_oModuleData.Wallet = new Wallet();
            m_oModuleData.TradingPost = new TradingPost();

            await ProcessWallet(accessToken);
            await ProcessTradingPost(accessToken);
            await ProcessMaterialStorage(accessToken);
            await ProcessCharacters(accessToken);
            await ProcessVault(accessToken);

            //CORRECT LI DUE TO DISCOUNT FOR FIRST SET
            if (m_oModuleData.LegendaryArmor >= 300)
                m_oModuleData.LegendaryArmor -= 150;
            else
            {
                m_oModuleData.LegendaryArmor -= (m_oModuleData.LegendaryArmor / 50 * 25);
                m_oModuleData.RefinedArmor -= (m_oModuleData.RefinedArmor / 25 * 25);
            }

            Console.WriteLine("[OVERVIEW: "+ (DateTime.Now - dt).TotalSeconds + "]");
            GC.Collect();
            return m_oModuleData;
        }

        private async Task ProcessWallet(string accessToken)
        {
            Currency[] currencies = await GetResponse<Currency[]>("account/wallet", "access_token=" + accessToken );

            for (int i = 0; i < currencies.Length; i++)
            {
                switch (currencies[i].Id)
                {
                    case 1:
                        m_oModuleData.Wallet.Coins = currencies[i].Value;
                        break;
                    case 2:
                        m_oModuleData.Wallet.Karma = currencies[i].Value;
                        break;
                    case 3:
                        m_oModuleData.Wallet.Laurels = currencies[i].Value;
                        break;
                    case 4:
                        m_oModuleData.Wallet.Gems = currencies[i].Value;
                        break;
                    case 28:
                        m_oModuleData.Wallet.MagnetiteShards = currencies[i].Value;
                        break;
                    case 39:
                        m_oModuleData.Wallet.GaetingCrystals = currencies[i].Value;
                        break;
                    case 7:
                        m_oModuleData.Wallet.FractalRelics = currencies[i].Value;
                        break;
                    case 24:
                        m_oModuleData.Wallet.PristineFractalRelics = currencies[i].Value;
                        break;
                    case 15:
                        m_oModuleData.Wallet.BadgeOfHonor = currencies[i].Value;
                        break;
                    case 26:
                        m_oModuleData.Wallet.SkirmishTicket = currencies[i].Value;
                        break;
                    case 33:
                        m_oModuleData.Wallet.AscendedShardsOfGlory = currencies[i].Value;
                        break;
                    case 30:
                        m_oModuleData.Wallet.LeagueTicket = currencies[i].Value;
                        break;
                }
            }
        }

        private async Task ProcessTradingPost(string accessToken)
        {
            TradingPost tradingpost = await GetResponse<TradingPost>("commerce/delivery", "access_token=" + accessToken);
            m_oModuleData.TradingPost = tradingpost;
        }

        private async Task ProcessMaterialStorage(string accessToken)
        {
            Material[] materials = await GetResponse<Material[]>("account/materials", "access_token=" + accessToken);

            bool LI = false;
            bool LD = false;

            for (int i = 0; i < materials.Length; i++)
            {
                switch (materials[i].Id)
                {
                    case 77302:
                        m_oModuleData.OnHandLI += materials[i].Count;
                        LI = true;
                        break;
                    case 88485:
                        m_oModuleData.OnHandLD += materials[i].Count;
                        LD = true;
                        break;
                }

                if (LI && LD)
                    break;
            }
        }

        private async Task ProcessCharacters(string accessToken)
        {
            //CRAWLING CHARACTERS FOR ITEMS
            Character[] characters = await GetResponse<Character[]>("characters", "access_token=" + accessToken, "page=0", "page_size=200");

            int liId = 77302;
            int gopId = 78989;
            int eiId = 80516;
            int[] legyArmorIds = { 80111, 80131, 80145, 80161, 80190, 80205, 80248, 80252, 80254, 80277, 80281, 80296, 80356, 80384, 80399, 80435, 80557, 80578 };
            int[] refArmorIds = { 80177, 80648, 80441, 80673, 80460, 80127, 80387, 80607, 80675, 80264, 80634, 80275, 80236, 80583, 80366, 80427, 80658, 80120 };

            int ldId = 88485;

            foreach (Character c in characters)
            {
                foreach (Item eq in c.Equipment)
                {
                    if (eq != null)
                    {
                        if (legyArmorIds.Contains(eq.Id))
                            m_oModuleData.LegendaryArmor += 50;
                        else if (refArmorIds.Contains(eq.Id))
                            m_oModuleData.RefinedArmor += 25;
                    }
                }
                foreach (Bag b in c.Bags)
                {
                    if (b != null)
                    {
                        foreach (Item it in b.Inventory)
                        {
                            if (it != null)
                            {
                                if (it.Id == ldId)
                                    m_oModuleData.OnHandLD += it.Count;
                                else if (it.Id == liId)
                                    m_oModuleData.OnHandLI += it.Count;
                                else if (it.Id == gopId)
                                    m_oModuleData.GiftOfProwess += 25 * it.Count;
                                else if (it.Id == eiId)
                                    m_oModuleData.EnvoyInsignia += 25 * it.Count;
                                else if (legyArmorIds.Contains(it.Id))
                                    m_oModuleData.LegendaryArmor += 50;
                                else if (refArmorIds.Contains(it.Id))
                                    m_oModuleData.RefinedArmor += 25;
                            }
                        }
                    }
                }
            }
        }

        private async Task ProcessVault(string accessToken)
        {
            //CRAWLING BANK FOR ITEMS
            Item[] vault = await GetResponse<Item[]>("account/bank", "access_token=" + accessToken);

            int li_id = 77302;
            int gop_id = 78989;
            int ei_id = 80516;
            int[] legy_armor_ids = { 80111, 80131, 80145, 80161, 80190, 80205, 80248, 80252, 80254, 80277, 80281, 80296, 80356, 80384, 80399, 80435, 80557, 80578 };
            int[] ref_armor_ids = { 80177, 80648, 80441, 80673, 80460, 80127, 80387, 80607, 80675, 80264, 80634, 80275, 80236, 80583, 80366, 80427, 80658, 80120 };

            int ld_id = 88485;

            foreach (Item bi in vault)
            {
                if (bi != null)
                {
                    if (bi.Id == ld_id)
                        m_oModuleData.OnHandLD += bi.Count;
                    else if (bi.Id == li_id)
                        m_oModuleData.OnHandLI += bi.Count;
                    else if (bi.Id == gop_id)
                        m_oModuleData.GiftOfProwess += 25 * bi.Count;
                    else if (bi.Id == ei_id)
                        m_oModuleData.EnvoyInsignia += 25 * bi.Count;
                    else if (legy_armor_ids.Contains(bi.Id))
                        m_oModuleData.LegendaryArmor += 50;
                    else if (ref_armor_ids.Contains(bi.Id))
                        m_oModuleData.RefinedArmor += 25;
                }
            }
        }
    }
}