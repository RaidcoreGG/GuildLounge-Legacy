﻿using System;
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

        //Relevant ids: LI, Gift of Prowess, Envoy Insignia, Legy & Refined armor
        const int liId = 77302;
        const int gopId = 78989;
        const int eiId = 80516;
        int[] legyArmorIds = { 80111, 80131, 80145, 80161, 80190, 80205, 80248, 80252, 80254, 80277, 80281, 80296, 80356, 80384, 80399, 80435, 80557, 80578 };
        int[] refArmorIds = { 80177, 80648, 80441, 80673, 80460, 80127, 80387, 80607, 80675, 80264, 80634, 80275, 80236, 80583, 80366, 80427, 80658, 80120 };

        //Relevant ids: LD, Gift of Compassion, Coalescence
        const int ldId = 88485;
        const int gocId = 91225;
        const int coalescenceId = 91234;


        public async Task<T> GetResponse<T>(string endPoint, params string[] args)
        {
            Console.WriteLine("[API: FETCHING " + endPoint.ToUpper() + "]");
            string response = await _client.GetStringAsync(String.Join("?", (_apiBase + endPoint), String.Join("&", args)));
            return new JavaScriptSerializer().Deserialize<T>(response);
        }
        
        //Used to call the guildlounge API
        public async Task<T> GetResponseWithEntryPoint<T>(string entryPoint, string endPoint, params string[] args)
        {
            Console.WriteLine("[API: FETCHING " + entryPoint + endPoint.ToUpper() + "]");
            string response = await _client.GetStringAsync(String.Join("?", (entryPoint + endPoint), String.Join("&", args)));
            return new JavaScriptSerializer().Deserialize<T>(response);
        }

        public async Task<RaidCMs> FetchRaidCMs(string accessToken)
        {
            RaidCMs resp = new RaidCMs();
            //ID 247 = DUMMY ACHIEVEMENT, GLADIATOR IS BOUND TO EVERY ACCOUNT
            Achievement[] achievements = await GetResponse<Achievement[]>("account/achievements", "access_token=" + accessToken, "ids=247,3019,3334,3287,3342,3292,3392,3993,4037,3979,4416,4429,4355,4803,4779,4800");
            
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
                    case 4803:
                        resp.Adina = a.Done;
                        break;
                    case 4779:
                        resp.Sabir = a.Done;
                        break;
                    case 4800:
                        resp.QadimThePeerless = a.Done;
                        break;
                }
            }

            return resp;
        }

        public async Task<ModuleData> FetchModuleData(string accessToken)
        {
            Console.WriteLine("[DATA: INIT]");
            DateTime dt = DateTime.Now;

            m_oModuleData = new ModuleData();
            m_oModuleData.Wallet = new Wallet();
            m_oModuleData.TradingPost = new TradingPost();

            var task1 = ProcessWallet(accessToken);
            var task2 = ProcessTradingPost(accessToken);
            var task3 = ProcessMaterialStorage(accessToken);
            var task4 = ProcessCharacters(accessToken);
            var task5 = ProcessVault(accessToken);
            await Task.WhenAll(task1, task2, task3, task4, task5);

            //Correct LI due to the discount for the first legendary armor set
            if (m_oModuleData.LegendaryArmor >= 300)
                m_oModuleData.LegendaryArmor -= 150;
            else
            {
                m_oModuleData.LegendaryArmor -= (m_oModuleData.LegendaryArmor / 50 * 25);
                m_oModuleData.RefinedArmor -= (m_oModuleData.RefinedArmor / 25 * 25);
            }

            Console.WriteLine("[DATA: "+ (DateTime.Now - dt).TotalSeconds + "]");
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
            Character[] characters = await GetResponse<Character[]>("characters", "access_token=" + accessToken, "page=0");
            
            //Crawling through characters checking for the ids
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
                                switch (it.Id)
                                {
                                    case liId:
                                        m_oModuleData.OnHandLI += it.Count;
                                        break;
                                    case gopId:
                                        m_oModuleData.GiftOfProwess += 25 * it.Count;
                                        break;
                                    case eiId:
                                        m_oModuleData.EnvoyInsignia += 25 * it.Count;
                                        break;
                                    case ldId:
                                        m_oModuleData.OnHandLD += it.Count;
                                        break;
                                    case gocId:
                                        m_oModuleData.GiftOfCompassion += 150;
                                        break;
                                    case coalescenceId:
                                        m_oModuleData.Coalescence += 150;
                                        break;
                                    default:
                                        if (legyArmorIds.Contains(it.Id))
                                            m_oModuleData.LegendaryArmor += 50;
                                        else if (refArmorIds.Contains(it.Id))
                                            m_oModuleData.RefinedArmor += 25;
                                        break;
                                }
                            }
                        }
                    }
                }
            }
        }

        private async Task ProcessVault(string accessToken)
        {
            //Crawling through bank checking for the ids
            Item[] vault = await GetResponse<Item[]>("account/bank", "access_token=" + accessToken);

            foreach (Item it in vault)
            {
                if (it != null)
                {
                    switch (it.Id)
                    {
                        case liId:
                            m_oModuleData.OnHandLI += it.Count;
                            break;
                        case gopId:
                            m_oModuleData.GiftOfProwess += 25 * it.Count;
                            break;
                        case eiId:
                            m_oModuleData.EnvoyInsignia += 25 * it.Count;
                            break;
                        case ldId:
                            m_oModuleData.OnHandLD += it.Count;
                            break;
                        case gocId:
                            m_oModuleData.GiftOfCompassion += 150;
                            break;
                        case coalescenceId:
                            m_oModuleData.Coalescence += 150;
                            break;
                        default:
                            if (legyArmorIds.Contains(it.Id))
                                m_oModuleData.LegendaryArmor += 50;
                            else if (refArmorIds.Contains(it.Id))
                                m_oModuleData.RefinedArmor += 25;
                            break;
                    }
                }
            }
        }
    }
}