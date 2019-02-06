using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GuildLounge
{
    public partial class TabPage_Raids : UserControl
    {
        private static readonly ApiHandler _api = new ApiHandler();
        private ApiEntry m_oActiveKey;
        public ApiEntry ActiveAPIEntry
        {
            get { return m_oActiveKey; }
            set
            {
                //SET VALUES
                m_oActiveKey = value;

                //UPDATA DATA
                UpdateWeeklyRaidProgress();
            }
        }

        public TabPage_Raids()
        {
            InitializeComponent();
        }
        
        private async void UpdateWeeklyRaidProgress()
        {
            try
            {
                //GET RAID ENCOUNTER PROGRESS
                string[] APIResponse = await _api.GetResponse<string[]>("account/raids", "access_token=" + ActiveAPIEntry.Key);

                //UPDATE ACCORDING TO DATA
                UpdatePictureBoxes(APIResponse);
                UpdateLabels(APIResponse);
                UpdateCMFlags();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }

            //REDRAW
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
            //COUNT LEGENDARY INSIGHTS PROGRESS
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
            labelTotalWeeklyLI.Text = LI + " / 15 LI earned this week.";

            //COUNT LEGENDARY DIVINATIONS PROGRESS
            byte LD = 0;
            string[] PoF = {"soulless_horror", "river_of_souls", "statues_of_grenth", "voice_in_the_void",
                            "conjured_amalgamate", "twin_largos", "qadim"};
            
            for (int i = 0; i < PoF.Length; i++)
            {
                if (APIResponse.Contains(PoF[i]))
                    LD++;
            }
            labelTotalWeeklyLD.Text = LD + " / 7 LD earned this week.";
            
            //RECOLORING LABELS FOR COMPLETED WINGS
            foreach (var gb in Controls.OfType<Control_GroupBox>())
            {
                int gbc = gb.Controls.Count - 1;
                int pbcTrue = 0;
                foreach (var pb in gb.Controls.OfType<Control_PictureBoxEncounter>())
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

        private async void UpdateCMFlags()
        {
            //try
            //{
                RaidCMs APIResponse = await _api.FetchRaidCMs(ActiveAPIEntry.Key);

                //W3
                pictureBoxKeepConstruct.DoneCM = APIResponse.KeepConstruct;

                //W4
                pictureBoxCairn.DoneCM = APIResponse.Cairn;
                pictureBoxMursaatOverseer.DoneCM = APIResponse.MursaatOverseer;
                pictureBoxSamarog.DoneCM = APIResponse.Samarog;
                pictureBoxDeimos.DoneCM = APIResponse.Deimos;

                //W5
                pictureBoxSoullessHorror.DoneCM = APIResponse.SoullessHorror;
                pictureBoxStatuesofGrenth.DoneCM = APIResponse.Statues;
                pictureBoxDhuum.DoneCM = APIResponse.Dhuum;

                //W6
                pictureBoxConjuredAmalgamate.DoneCM = APIResponse.ConjuredAmalgamate;
                pictureBoxLargosTwins.DoneCM = APIResponse.LargosTwins;
                pictureBoxQadim.DoneCM = APIResponse.Qadim;
            /*}
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);

                //W3
                pictureBoxKeepConstruct.DoneCM = false;

                //W4
                pictureBoxCairn.DoneCM = false;
                pictureBoxMursaatOverseer.DoneCM = false;
                pictureBoxSamarog.DoneCM = false;
                pictureBoxDeimos.DoneCM = false;

                //W5
                pictureBoxSoullessHorror.DoneCM = false;
                pictureBoxStatuesofGrenth.DoneCM = false;
                pictureBoxDhuum.DoneCM = false;

                //W6
                pictureBoxConjuredAmalgamate.DoneCM = false;
                pictureBoxLargosTwins.DoneCM = false;
                pictureBoxQadim.DoneCM = false;
            }*/

            //REDRAW
            Refresh();
        }
    }
}