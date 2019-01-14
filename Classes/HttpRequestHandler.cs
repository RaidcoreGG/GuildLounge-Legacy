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
            string curr = await _client.GetStringAsync("https://api.guildwars2.com/v2/account/wallet?access_token=" + apiEntry.Key);
            CurrencyObject[] currencies = new JavaScriptSerializer().Deserialize<List<CurrencyObject>>(curr).ToArray();
            ov.wallet = new AccountWallet();

            //raids
            bool mag = false;
            bool gae = false;

            //fractals
            bool fr = false;
            bool pfr = false;

            //wvw
            bool boh = false;
            bool sct = false;

            //pvp
            bool asog = false;
            bool lt = false;
            for (int i = 0; i < currencies.Length; i++)
            {
                switch (currencies[i].id)
                {
                    case 28:
                        ov.wallet.magnetite = currencies[i].value;
                        mag = true;
                        break;
                    case 39:
                        ov.wallet.gaeting = currencies[i].value;
                        gae = true;
                        break;
                    case 7:
                        ov.wallet.fractalrelic = currencies[i].value;
                        fr = true;
                        break;
                    case 24:
                        ov.wallet.pristinefractalrelic = currencies[i].value;
                        pfr = true;
                        break;
                    case 15:
                        ov.wallet.badgeofhonor = currencies[i].value;
                        boh = true;
                        break;
                    case 26:
                        ov.wallet.wvwskirmishticket = currencies[i].value;
                        sct = true;
                        break;
                    case 33:
                        ov.wallet.ascendedshardsofglory = currencies[i].value;
                        asog = true;
                        break;
                    case 30:
                        ov.wallet.pvpleagueticket = currencies[i].value;
                        lt = true;
                        break;
                }

                if (mag && gae
                    && fr && pfr
                    && boh && sct
                    && asog && lt)
                    break;
            }

            //LI & LD
            Console.WriteLine("[API: FETCHING MATERIALS]");
            string mats = await _client.GetStringAsync("https://api.guildwars2.com/v2/account/materials?access_token=" + apiEntry.Key);
            MaterialObject[] materials = new JavaScriptSerializer().Deserialize<List<MaterialObject>>(mats).ToArray();
            bool LI = false;
            bool LD = false;
            for (int i = 0; i < materials.Length; i++)
            {
                if (materials[i].id == 77302)
                {
                    ov.materialLI = materials[i].count;
                    LI = true;
                }

                if (materials[i].id == 88485)
                {
                    ov.materialLD = materials[i].count;
                    LD = true;
                }
                if (LI && LD)
                    break;
            }

            //CRAWLING CHARACTERS FOR ITEMS
            Console.WriteLine("[API: FETCHING CHARACTERS]");
            string chars = await _client.GetStringAsync("https://api.guildwars2.com/v2/characters?page=0&page_size=200&access_token=" + apiEntry.Key);
            Character[] characters = new JavaScriptSerializer().Deserialize<List<Character>>(chars).ToArray();
            int li_id = 77302;
            int gop_id = 78989;
            int ei_id = 80516;
            int[] legy_armor_ids = { 80111, 80131, 80145, 80161, 80190, 80205, 80248, 80252, 80254, 80277, 80281, 80296, 80356, 80384, 80399, 80435, 80557, 80578 };
            int[] ref_armor_ids = { 80177, 80648, 80441, 80673, 80460, 80127, 80387, 80607, 80675, 80264, 80634, 80275, 80236, 80583, 80366, 80427, 80658, 80120 };
            int ld_id = 88485;
            foreach (Character c in characters)
            {
                foreach (EqItem eq in c.equipment)
                {
                    if(eq != null)
                    {
                        if (legy_armor_ids.Contains(eq.id))
                            ov.legendary_armor += 50;
                        else if (ref_armor_ids.Contains(eq.id))
                            ov.refined_armor += 25;
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
                                if (it.id == ld_id)
                                    ov.materialLD += it.count;
                                else if (it.id == li_id)
                                    ov.materialLI += it.count;
                                else if (it.id ==  gop_id)
                                    ov.gift_of_prowess += 25 * it.count;
                                else if (it.id == ei_id)
                                    ov.envoy_insignia += 25 * it.count;
                                else if (legy_armor_ids.Contains(it.id))
                                    ov.legendary_armor += 50;
                                else if (ref_armor_ids.Contains(it.id))
                                    ov.refined_armor += 25;
                            }
                        }
                    }
                }
            }

            //CRAWLING BANK FOR ITEMS
            Console.WriteLine("[API: FETCHING BANK]");
            string vault = await _client.GetStringAsync("https://api.guildwars2.com/v2/account/bank?access_token=" + apiEntry.Key);
            BankItem[] bank = new JavaScriptSerializer().Deserialize<List<BankItem>>(vault).ToArray();

            foreach (BankItem bi in bank)
            {
                if(bi != null)
                {
                    if (bi.id == ld_id)
                        ov.materialLD += bi.count;
                    else if (bi.id == li_id)
                        ov.materialLI += bi.count;
                    else if (bi.id == gop_id)
                        ov.gift_of_prowess += 25 * bi.count;
                    else if (bi.id == ei_id)
                        ov.envoy_insignia += 25 * bi.count;
                    else if (legy_armor_ids.Contains(bi.id))
                        ov.legendary_armor += 50;
                    else if (ref_armor_ids.Contains(bi.id))
                        ov.refined_armor += 25;
                }
            }

            //CORRECT LI FOR LEGY/REF ARMOR
            if (ov.legendary_armor >= 300)
                ov.legendary_armor -= 150;
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