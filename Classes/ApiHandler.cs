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
        private const string API_BASE = "https://api.guildwars2.com/v2/";
        private static readonly HttpClient _client = new HttpClient();
        private AccountOverview AccOverview;
        
        public async Task<T> GetResponse<T>(string endPoint, string accessToken, params string[] parameters)
        {
            Console.WriteLine("[API: FETCHING " + endPoint.ToUpper() + "]");
            string response =  await _client.GetStringAsync(String.Format("{0}{1}?access_token={2}&{3}", API_BASE,
                                                                                                         endPoint,
                                                                                                         accessToken,
                                                                                                         String.Join("&", parameters)));
            return new JavaScriptSerializer().Deserialize<T>(response);
        }
        
        public async Task<AccountOverview> FetchAccountOverview(string accessToken)
        {
            Console.WriteLine("[OVERVIEW: INIT]");
            DateTime dt = DateTime.Now;

            AccOverview = new AccountOverview();
            AccOverview.wallet = new AccountWallet();

            await ProcessWallet(accessToken);
            await ProcessMaterialStorage(accessToken);
            await ProcessCharacters(accessToken);
            await ProcessVault(accessToken);

            //CORRECT LI DUE TO DISCOUNT FOR FIRST SET
            if (AccOverview.legendary_armor >= 300)
                AccOverview.legendary_armor -= 150;
            else
            {
                AccOverview.legendary_armor -= (AccOverview.legendary_armor / 50 * 25);
                AccOverview.refined_armor -= (AccOverview.refined_armor / 25 * 25);
            }

            GC.Collect();
            Console.WriteLine("[OVERVIEW: "+ (DateTime.Now - dt).TotalSeconds + "]");
            return AccOverview;
        }

        private async Task ProcessWallet(string accessToken)
        {
            CurrencyObject[] currencies = await GetResponse<CurrencyObject[]>("account/wallet", accessToken);

            for (int i = 0; i < currencies.Length; i++)
            {
                switch (currencies[i].id)
                {
                    case 28:
                        AccOverview.wallet.magnetite = currencies[i].value;
                        break;
                    case 39:
                        AccOverview.wallet.gaeting = currencies[i].value;
                        break;
                    case 7:
                        AccOverview.wallet.fractalrelic = currencies[i].value;
                        break;
                    case 24:
                        AccOverview.wallet.pristinefractalrelic = currencies[i].value;
                        break;
                    case 15:
                        AccOverview.wallet.badgeofhonor = currencies[i].value;
                        break;
                    case 26:
                        AccOverview.wallet.wvwskirmishticket = currencies[i].value;
                        break;
                    case 33:
                        AccOverview.wallet.ascendedshardsofglory = currencies[i].value;
                        break;
                    case 30:
                        AccOverview.wallet.pvpleagueticket = currencies[i].value;
                        break;
                }
            }
        }

        private async Task ProcessMaterialStorage(string accessToken)
        {
            MaterialObject[] materials = await GetResponse<MaterialObject[]>("account/materials", accessToken);

            bool LI = false;
            bool LD = false;

            for (int i = 0; i < materials.Length; i++)
            {
                switch (materials[i].id)
                {
                    case 77302:
                        AccOverview.materialLI += materials[i].count;
                        LI = true;
                        break;
                    case 88485:
                        AccOverview.materialLD += materials[i].count;
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
            Character[] characters = await GetResponse<Character[]>("characters", accessToken, "page=0", "page_size=200");

            int liId = 77302;
            int gopId = 78989;
            int eiId = 80516;
            int[] legyArmorIds = { 80111, 80131, 80145, 80161, 80190, 80205, 80248, 80252, 80254, 80277, 80281, 80296, 80356, 80384, 80399, 80435, 80557, 80578 };
            int[] refArmorIds = { 80177, 80648, 80441, 80673, 80460, 80127, 80387, 80607, 80675, 80264, 80634, 80275, 80236, 80583, 80366, 80427, 80658, 80120 };

            int ldId = 88485;

            foreach (Character c in characters)
            {
                foreach (EqItem eq in c.equipment)
                {
                    if (eq != null)
                    {
                        if (legyArmorIds.Contains(eq.id))
                            AccOverview.legendary_armor += 50;
                        else if (refArmorIds.Contains(eq.id))
                            AccOverview.refined_armor += 25;
                    }
                }
                foreach (Bag b in c.bags)
                {
                    if (b != null)
                    {
                        foreach (Item it in b.inventory)
                        {
                            if (it != null)
                            {
                                if (it.id == ldId)
                                    AccOverview.materialLD += it.count;
                                else if (it.id == liId)
                                    AccOverview.materialLI += it.count;
                                else if (it.id == gopId)
                                    AccOverview.gift_of_prowess += 25 * it.count;
                                else if (it.id == eiId)
                                    AccOverview.envoy_insignia += 25 * it.count;
                                else if (legyArmorIds.Contains(it.id))
                                    AccOverview.legendary_armor += 50;
                                else if (refArmorIds.Contains(it.id))
                                    AccOverview.refined_armor += 25;
                            }
                        }
                    }
                }
            }
        }

        private async Task ProcessVault(string accessToken)
        {
            //CRAWLING BANK FOR ITEMS
            BankItem[] vault = await GetResponse<BankItem[]>("account/bank", accessToken);

            int li_id = 77302;
            int gop_id = 78989;
            int ei_id = 80516;
            int[] legy_armor_ids = { 80111, 80131, 80145, 80161, 80190, 80205, 80248, 80252, 80254, 80277, 80281, 80296, 80356, 80384, 80399, 80435, 80557, 80578 };
            int[] ref_armor_ids = { 80177, 80648, 80441, 80673, 80460, 80127, 80387, 80607, 80675, 80264, 80634, 80275, 80236, 80583, 80366, 80427, 80658, 80120 };

            int ld_id = 88485;

            foreach (BankItem bi in vault)
            {
                if (bi != null)
                {
                    if (bi.id == ld_id)
                        AccOverview.materialLD += bi.count;
                    else if (bi.id == li_id)
                        AccOverview.materialLI += bi.count;
                    else if (bi.id == gop_id)
                        AccOverview.gift_of_prowess += 25 * bi.count;
                    else if (bi.id == ei_id)
                        AccOverview.envoy_insignia += 25 * bi.count;
                    else if (legy_armor_ids.Contains(bi.id))
                        AccOverview.legendary_armor += 50;
                    else if (ref_armor_ids.Contains(bi.id))
                        AccOverview.refined_armor += 25;
                }
            }
        }
    }
}