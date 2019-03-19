using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GuildLounge.TabPages
{
    public partial class Raids : UserControl
    {
        private static readonly ApiHandler _api = new ApiHandler();

        public Raids()
        {
            InitializeComponent();
        }
        
        public async void UpdateWeeklyRaidProgress(string key)
        {
            try
            {
                //Get encounter progress from the API
                string[] APIResponse = await _api.GetResponse<string[]>("account/raids", "access_token=" + key);

                //Updates from API response
                UpdatePictureBoxes(APIResponse);
                UpdateLabels(APIResponse);
                UpdateCMFlags(key);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }

            Refresh();
        }
        
        private void UpdatePictureBoxes(string[] APIResponse)
        {
            //TERRIBLE CLOWNFIESTA INCOMING

            //W1
            pictureBoxValeGuardian.EncounterFinished = APIResponse.Contains("vale_guardian");
            pictureBoxSpiritWoods.EncounterFinished = APIResponse.Contains("spirit_woods");
            pictureBoxGorseval.EncounterFinished = APIResponse.Contains("gorseval");
            pictureBoxSabetha.EncounterFinished = APIResponse.Contains("sabetha");

            //W2
            pictureBoxSlothasor.EncounterFinished = APIResponse.Contains("slothasor");
            pictureBoxTrio.EncounterFinished = APIResponse.Contains("bandit_trio");
            pictureBoxMatthias.EncounterFinished = APIResponse.Contains("matthias");

            //W3
            pictureBoxEscort.EncounterFinished = APIResponse.Contains("escort");
            pictureBoxKeepConstruct.EncounterFinished = APIResponse.Contains("keep_construct");
            pictureBoxTwistedCastle.EncounterFinished = APIResponse.Contains("twisted_castle");
            pictureBoxXera.EncounterFinished = APIResponse.Contains("xera");

            //W4
            pictureBoxCairn.EncounterFinished = APIResponse.Contains("cairn");
            pictureBoxMursaatOverseer.EncounterFinished = APIResponse.Contains("mursaat_overseer");
            pictureBoxSamarog.EncounterFinished = APIResponse.Contains("samarog");
            pictureBoxDeimos.EncounterFinished = APIResponse.Contains("deimos");

            //W5
            pictureBoxSoullessHorror.EncounterFinished = APIResponse.Contains("soulless_horror");
            pictureBoxRiverofSouls.EncounterFinished = APIResponse.Contains("river_of_souls");
            pictureBoxStatuesofGrenth.EncounterFinished = APIResponse.Contains("statues_of_grenth");
            pictureBoxDhuum.EncounterFinished = APIResponse.Contains("voice_in_the_void");

            //W6
            pictureBoxConjuredAmalgamate.EncounterFinished = APIResponse.Contains("conjured_amalgamate");
            pictureBoxLargosTwins.EncounterFinished = APIResponse.Contains("twin_largos");
            pictureBoxQadim.EncounterFinished = APIResponse.Contains("qadim");
        }
        
        private void UpdateLabels(string[] APIResponse)
        {
            //Count LI and set label text
            byte LI = 0;
            string[] HoT = {"vale_guardian", "spirit_woods", "gorseval", "sabetha",
                            "slothasor", "bandit_trio", "matthias",
                            "escort", "keep_construct", "twisted_castle", "xera",
                            "cairn", "mursaat_overseer", "samarog", "deimos"};
            
            for (int i = 0; i < HoT.Length; i++)
            {
                if (APIResponse.Contains(HoT[i]))
                    LI++;
            }
            labelTotalWeeklyLI.Text = LI + " / " + HoT.Length + " LI earned this week.";

            //Count LD and set label text
            byte LD = 0;
            string[] PoF = {"soulless_horror", "river_of_souls", "statues_of_grenth", "voice_in_the_void",
                            "conjured_amalgamate", "twin_largos", "qadim"};
            
            for (int i = 0; i < PoF.Length; i++)
            {
                if (APIResponse.Contains(PoF[i]))
                    LD++;
            }
            labelTotalWeeklyLD.Text = LD + " / " + PoF.Length + " LD earned this week.";
            
            //Recolor labels if wing is completed
            foreach (var gb in Controls.OfType<GroupBox>())
            {
                int gbc = gb.Controls.Count - 1;
                int pbcTrue = 0;
                foreach (var pb in gb.Controls.OfType<Controls.PictureBoxEncounter>())
                {
                    if (pb.EncounterFinished)
                        pbcTrue++;
                }
                foreach (var l in gb.Controls.OfType<Label>())
                {
                    if (pbcTrue == gbc)
                        l.ForeColor = Color.Green;
                    else
                        l.ForeColor = Color.White;
                }
            }
        }

        private async void UpdateCMFlags(string key)
        {
            try
            {
                //Fetch CM progress from predefined achievements
                RaidCMs APIResponse = await _api.FetchRaidCMs(key);

                //Set encounter CM progress according to API response
                //W3
                pictureBoxKeepConstruct.CMdone = APIResponse.KeepConstruct;

                //W4
                pictureBoxCairn.CMdone = APIResponse.Cairn;
                pictureBoxMursaatOverseer.CMdone = APIResponse.MursaatOverseer;
                pictureBoxSamarog.CMdone = APIResponse.Samarog;
                pictureBoxDeimos.CMdone = APIResponse.Deimos;

                //W5
                pictureBoxSoullessHorror.CMdone = APIResponse.SoullessHorror;
                pictureBoxStatuesofGrenth.CMdone = APIResponse.Statues;
                pictureBoxDhuum.CMdone = APIResponse.Dhuum;

                //W6
                pictureBoxConjuredAmalgamate.CMdone = APIResponse.ConjuredAmalgamate;
                pictureBoxLargosTwins.CMdone = APIResponse.LargosTwins;
                pictureBoxQadim.CMdone = APIResponse.Qadim;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);

                //Set each encounter CM to false if API fails
                //W3
                pictureBoxKeepConstruct.CMdone = false;

                //W4
                pictureBoxCairn.CMdone = false;
                pictureBoxMursaatOverseer.CMdone = false;
                pictureBoxSamarog.CMdone = false;
                pictureBoxDeimos.CMdone = false;

                //W5
                pictureBoxSoullessHorror.CMdone = false;
                pictureBoxStatuesofGrenth.CMdone = false;
                pictureBoxDhuum.CMdone = false;

                //W6
                pictureBoxConjuredAmalgamate.CMdone = false;
                pictureBoxLargosTwins.CMdone = false;
                pictureBoxQadim.CMdone = false;
            }
        }
    }
}