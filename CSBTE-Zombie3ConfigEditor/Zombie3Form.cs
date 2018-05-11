using System;
using System.Windows.Forms;
using IniParser;
using IniParser.Model;
using System.Diagnostics;

namespace CSBTE_Zombie3ConfigEditor
{
    public partial class Zombie3Form : Form
    {
        // Config File Path //
        string zb3cfg = "cstrike\\addons\\amxmodx\\configs\\bte_zombie_mod3.ini";

        private static FileIniDataParser parser = new FileIniDataParser();
        private IniData zb3;

        public Zombie3Form()
        {
            InitializeComponent();
            LoadConfigData();
        }

        public void LoadConfigData()
        {
            zb3 = parser.ReadFile(zb3cfg);

            // Zombie //
            MotherHP.Text = zb3["Base Config"]["ZB_LV2_HEALTH"];
            MotherArmor.Text = zb3["Base Config"]["ZB_LV2_ARMOR"];
            LordHP.Text = zb3["Base Config"]["ZB_LV3_HEALTH"];
            LordArmor.Text = zb3["Base Config"]["ZB_LV3_ARMOR"];
            MaxHP.Text = zb3["Base Config"]["MAX_HEALTH_ZOMBIE"];
            MinHP.Text = zb3["Base Config"]["MIN_HEALTH_ZOMBIE"];
            RespawnTime.Text = zb3["Base Config"]["RESPAWN_TIME_WAIT"];
            // Restore Health //
            RegenTime.Text = zb3["Restore Health"]["RESTORE_HEALTH_TIME"];
            MotherRegenHP.Text = zb3["Restore Health"]["RESTORE_HEALTH_LV1"];
            LordRegenHP.Text = zb3["Restore Health"]["RESTORE_HEALTH_LV2"];
            // SupplyBox //
            SupplyMax.Text = zb3["Supply Box"]["SUPPLYBOX_MAX"];
            SupplyMin.Text = zb3["Supply Box"]["SUPPLYBOX_NUM"];
            SupplyFirstSpawnTime.Text = zb3["Supply Box"]["SUPPLYBOX_TIME_FIRST"];
            SupplySpawnTime.Text = zb3["Supply Box"]["SUPPLYBOX_TIME"];
            // Zombie Bomb //
            ZombieBombPower.Text = zb3["Zombie Bomb"]["RADIUS"];
            ZombieBombRadius.Text = zb3["Zombie Bomb"]["POWER"];
        }

        private void TiebaWatermark_Click(object sender, EventArgs e)
        {
            Process.Start("https://tieba.baidu.com/f?kw=csoldjb&ie=utf-8");
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            // Zombie HP & Armor //
            zb3["Base Config"]["ZB_LV2_HEALTH"] = MotherHP.Text;
            zb3["Base Config"]["ZB_LV2_ARMOR"] = MotherArmor.Text;
            zb3["Base Config"]["ZB_LV3_HEALTH"] = LordHP.Text;
            zb3["Base Config"]["ZB_LV3_ARMOR"] = LordArmor.Text;
            zb3["Base Config"]["MAX_HEALTH_ZOMBIE"] = MaxHP.Text;
            zb3["Base Config"]["MIN_HEALTH_ZOMBIE"] = MinHP.Text;
            zb3["Base Config"]["RESPAWN_TIME_WAIT"] = RespawnTime.Text;
            // Restore Health //
            zb3["Restore Health"]["RESTORE_HEALTH_TIME"] = RegenTime.Text;
            zb3["Restore Health"]["RESTORE_HEALTH_LV1"] = MotherRegenHP.Text;
            zb3["Restore Health"]["RESTORE_HEALTH_LV2"] = LordRegenHP.Text;
            // SupplyBox //
            zb3["Supply Box"]["SUPPLYBOX_MAX"] = SupplyMax.Text;
            zb3["Supply Box"]["SUPPLYBOX_NUM"] = SupplyMin.Text;
            zb3["Supply Box"]["SUPPLYBOX_TIME_FIRST"] = SupplyFirstSpawnTime.Text;
            zb3["Supply Box"]["SUPPLYBOX_TIME"] = SupplySpawnTime.Text;
            // Zombie Bomb //
            zb3["Zombie Bomb"]["RADIUS"] = ZombieBombPower.Text;
            zb3["Zombie Bomb"]["POWER"] = ZombieBombRadius.Text;

            parser.WriteFile(zb3cfg, zb3);
        }
    }
}
