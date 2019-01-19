using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace GuildLounge
{
    public class HttpRequestHandler
    {
        private static readonly HttpClient _client = new HttpClient();

        public HttpRequestHandler()
        {
            
        }

        public async Task<T[]> GetApiResponse<T>(string endpoint)
        {
            string response = await _client.GetStringAsync(endpoint);
            T[] result = new JavaScriptSerializer().Deserialize<List<T>>(response).ToArray();
            return result;
        }

        public async Task<string> FetchWeeklyRaidEncounterProgress(APIEntry apiEntry)
        {
            Console.WriteLine("[API: FETCHING RAIDS]");
            return await _client.GetStringAsync("https://api.guildwars2.com/v2/account/raids?access_token=" + apiEntry.Key);
        }

        public async Task<AccountOverview> GetAccountOverview(APIEntry apiEntry)
        {
            Console.WriteLine("[CREATING ACCOUNT OVERVIEW]");
            DateTime dt = DateTime.Now;
            AccountOverview ov = new AccountOverview();

            //MAGNETITE & GAETING
            Console.WriteLine("[API: FETCHING WALLET]");
            CurrencyObject[] currencies = await GetApiResponse<CurrencyObject>("https://api.guildwars2.com/v2/account/wallet?access_token=" + apiEntry.Key);
            ov.wallet = new AccountWallet();
            
            for (int i = 0; i < currencies.Length; i++)
            {
                switch (currencies[i].id)
                {
                    case 28:
                        ov.wallet.magnetite = currencies[i].value;
                        break;
                    case 39:
                        ov.wallet.gaeting = currencies[i].value;
                        break;
                    case 7:
                        ov.wallet.fractalrelic = currencies[i].value;
                        break;
                    case 24:
                        ov.wallet.pristinefractalrelic = currencies[i].value;
                        break;
                    case 15:
                        ov.wallet.badgeofhonor = currencies[i].value;
                        break;
                    case 26:
                        ov.wallet.wvwskirmishticket = currencies[i].value;
                        break;
                    case 33:
                        ov.wallet.ascendedshardsofglory = currencies[i].value;
                        break;
                    case 30:
                        ov.wallet.pvpleagueticket = currencies[i].value;
                        break;
                }
            }

            //LI & LD
            Console.WriteLine("[API: FETCHING MATERIALS]");
            MaterialObject[] materials = await GetApiResponse<MaterialObject>("https://api.guildwars2.com/v2/account/materials?access_token=" + apiEntry.Key);

            bool LI_found = false;
            bool LD_found = false;
            for (int i = 0; i < materials.Length; i++)
            {
                switch (materials[i].id)
                {
                    case 77302: // LI
                        ov.materialLI = materials[i].count;
                        LI_found = true;
                        break;
                    case 88485: // LD
                        ov.materialLD = materials[i].count;
                        LD_found = true;
                        break;
                }

                if (LI_found && LD_found)
                {
                    break;
                }
            }

            //CRAWLING CHARACTERS FOR ITEMS
            Console.WriteLine("[API: FETCHING CHARACTERS]");
            Character[] characters = await GetApiResponse<Character>("https://api.guildwars2.com/v2/characters?page=0&page_size=200&access_token=" + apiEntry.Key);

            const int li_id = 77302;
            const int ld_id = 88485;
            const int gop_id = 78989;
            const int ei_id = 80516;
            int[] legy_armor_ids = { 80111, 80131, 80145, 80161, 80190, 80205, 80248, 80252, 80254, 80277, 80281, 80296, 80356, 80384, 80399, 80435, 80557, 80578 };
            int[] ref_armor_ids = { 80177, 80648, 80441, 80673, 80460, 80127, 80387, 80607, 80675, 80264, 80634, 80275, 80236, 80583, 80366, 80427, 80658, 80120 };
            foreach (Character c in characters)
            {
                foreach (EqItem eq in c.equipment)
                {
                    if(eq != null)
                    {
                        if (legy_armor_ids.Contains(eq.id))
                        {
                            ov.legendary_armor += 50;
                        }
                        else if (ref_armor_ids.Contains(eq.id))
                        {
                            ov.refined_armor += 25;
                        }
                    }
                }
                foreach (Bag b in c.bags)
                {
                    if(b != null)
                    {
                        foreach (Item it in b.inventory)
                        {
                            if (it != null)
                            {
                                switch (it.id)
                                {
                                    case ld_id:
                                        ov.materialLD += it.count;
                                        break;
                                    case li_id:
                                        ov.materialLI += it.count;
                                        break;
                                    case gop_id:
                                        ov.gift_of_prowess += 25 * it.count;
                                        break;
                                    case ei_id:
                                        ov.envoy_insignia += 25 * it.count;
                                        break;
                                    default:
                                        if (legy_armor_ids.Contains(it.id))
                                        {
                                            ov.legendary_armor += 50;
                                        }
                                        else if (ref_armor_ids.Contains(it.id))
                                        {
                                            ov.refined_armor += 25;
                                        }
                                        break;
                                }
                            }
                        }
                    }
                }
            }

            //CRAWLING BANK FOR ITEMS
            Console.WriteLine("[API: FETCHING BANK]");
            BankItem[] bank = await GetApiResponse<BankItem>("https://api.guildwars2.com/v2/account/bank?access_token=" + apiEntry.Key);

            foreach (BankItem bi in bank)
            {
                if(bi != null)
                {
                    switch (bi.id)
                    {
                        case ld_id:
                            ov.materialLD += bi.count;
                            break;
                        case li_id:
                            ov.materialLI += bi.count;
                            break;
                        case gop_id:
                            ov.gift_of_prowess += 25 * bi.count;
                            break;
                        case ei_id:
                            ov.envoy_insignia += 25 * bi.count;
                            break;
                        default:
                            if (legy_armor_ids.Contains(bi.id))
                            {
                                ov.legendary_armor += 50;
                            }
                            else if (ref_armor_ids.Contains(bi.id))
                            {
                                ov.refined_armor += 25;
                            }
                            break;
                    }
                }
            }

            //CORRECT LI FOR LEGY/REF ARMOR
            if (ov.legendary_armor >= 300)
            {
                ov.legendary_armor -= 150;
            }
            else
            {
                ov.legendary_armor -= (ov.legendary_armor / 50 * 25);
                ov.refined_armor -= (ov.refined_armor / 25 * 25);
            }
            GC.Collect();
            Console.WriteLine("[API: PROCESSED - "+ (DateTime.Now - dt) + "]");
            return ov;
        }
    }
}