using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace FactoryProfitCalculator
{
    public class Program
    {
        //Definitions
        public List<string> techLevels = new();
        public List<string> refitTypes = new();
        public List<string> unitTypes = new();
        public List<double> techMultipliers = new();
        public List<double> refitTypeMultipliers = new();

        public string techLevel = "";
        public string refitTechLevel = "";
        public string refitType = "";
        public string sellTechLvl = "";
        public string factoryTechLevel = "";
        public string unitType = "";

        public bool refit = false;
        public bool handmake = false;
        public bool omni = false;

        public int bFactoryCount = 0;
        public int cFactoryCount = 0;
        public int bFactoryMax = 0;
        public int cFactoryMax = 0;

        public int retroVee_BFactoryMax = 0;
        public int retroVee_CFactoryMax = 0;
        public int introVee_BFactoryMax = 0;
        public int introVee_CFactoryMax = 0;
        public int stdVee_BFactoryMax = 0;
        public int stdVee_CFactoryMax = 0;
        public int advVee_BFactoryMax = 0;
        public int advVee_CFactoryMax = 0;
        public int expVee_BFactoryMax = 0;
        public int expVee_CFactoryMax = 0;

        public int retroMechASF_BFactoryMax = 0;
        public int retroMechASF_CFactoryMax = 0;
        public int introMechASF_BFactoryMax = 0;
        public int introMechASF_CFactoryMax = 0;
        public int stdMechASF_BFactoryMax = 0;
        public int stdMechASF_CFactoryMax = 0;
        public int advMechASF_BFactoryMax = 0;
        public int advMechASF_CFactoryMax = 0;
        public int expMechASF_BFactoryMax = 0;
        public int expMechASF_CFactoryMax = 0;

        public int retroSmallCraftDrop_BFactoryMax = 0;
        public int retroSmallCraftDrop_CFactoryMax = 0;
        public int introSmallCraftDrop_BFactoryMax = 0;
        public int introSmallCraftDrop_CFactoryMax = 0;
        public int stdSmallCraftDrop_BFactoryMax = 0;
        public int stdSmallCraftDrop_CFactoryMax = 0;
        public int advSmallCraftDrop_BFactoryMax = 0;
        public int advSmallCraftDrop_CFactoryMax = 0;
        public int expSmallCraftDrop_BFactoryMax = 0;
        public int expSmallCraftDrop_CFactoryMax = 0;

        public int retroBattleArm_BFactoryMax = 0;
        public int retroBattleArm_CFactoryMax = 0;
        public int introBattleArm_BFactoryMax = 0;
        public int introBattleArm_CFactoryMax = 0;
        public int stdBattleArm_BFactoryMax = 0;
        public int stdBattleArm_CFactoryMax = 0;
        public int advBattleArm_BFactoryMax = 0;
        public int advBattleArm_CFactoryMax = 0;
        public int expBattleArm_BFactoryMax = 0;
        public int expBattleArm_CFactoryMax = 0;

        public double tonnage = 0;

        public double requiredTonnage = 0;
        public double baseUnitPrice = 0;

        public double unitCostCount = 0;

        public double techMulti = 0;
        public double refitTechMulti = 0;
        public double sellTechMulti = 0;
        public double mechMulti = 0;
        public double asfMulti = 0;
        public double veeMulti = 0;
        public double smallMulti = 0;

        public double lightBA_cost = 0;
        public double mediumBA_cost = 0;
        public double heavyBA_cost = 0;
        public double assaultBA_cost = 0;

        public double bFactoryOutput = 0;
        public double cFactoryOutput = 0;
        public double retroFactoryOutput = 0;
        public double introFactoryOutput = 0;
        public double stdFactoryOutput = 0;
        public double advFactoryOutput = 0;
        public double expFactoryOutput = 0;

        public double baseChassisCost = 0;
        public double handMakeCost = 0;
        public double modifiedChassisCost = 0;
        public double refitCost = 0;
        public double totalCost = 0;

        public double handMakeCostMulti = 0;
        public double costMulti = 0;
        public double refitTypeMulti = 0;

        public double productionRate = 0;

        public double monthlyExpenses = 0;
        public double monthlySell = 0;
        public double monthlyProfit = 0;

        public double mechProdMulti = 0;
        public double asfProdMulti = 0;
        public double veeProdMulti = 0;
        public double smallProdMulti = 0;
        public double dropshipProdMulti = 0;
        public double battleArmorMulti = 0;
        public double belowFactoryTechMulti = 0;
        public double atFactoryTechMulti = 0;
        public double aboveFactoryTechMulti = 0;
        public double primitiveMulti = 0;

        public double omniFactoryBonusCFactory = 0;

        public double retroRequiredTonnage = 0;
        public double introRequiredTonnage = 0;
        public double stdRequiredTonnage = 0;
        public double advRequiredTonnage = 0;
        public double expRequiredTonnage = 0;

        private const string str_techLevel = "TechLevel: ";
        private const string str_techMulti = "TechMulti: ";

        private const string str_refitType = "RefitType: ";
        private const string str_refitMulti = "RefitMultipliers: ";

        private const string str_unitType = "UnitType: ";
        private const string str_lightBACost = "Light_BA_Cost: ";
        private const string str_mediumBACost = "Medium_BA_Cost: ";
        private const string str_heavyBACost = "Heavy_BA_Cost: ";
        private const string str_assaultBACost = "Assault_BA_Cost: ";

        private const string str_mechMulti = "Mech_Multi: ";
        private const string str_asfMulti = "ASF_Multi: ";
        private const string str_veeMulti = "Vee_Multi: ";
        private const string str_smallMulti = "Small_Craft_Multi: ";

        private const string str_bFactCap = "B_Factory_Output: ";
        private const string str_cFactCap = "C_Factory_Output: ";

        private const string str_retroFactCap = "RetroFactory_Output: ";
        private const string str_introFactCap = "IntroFactory_Output: ";
        private const string str_stdFactCap = "StdFactory_Output: ";
        private const string str_advFactCap = "AdvFactory_Output: ";
        private const string str_expFactCap = "ExpFactory_Output: ";

        private const string str_mechProdMulti = "Mech_Prod_Multi: ";
        private const string str_asfProdMulti = "ASF_Prod_Multi: ";
        private const string str_veeProdMulti = "Vee_Prod_Multi: ";
        private const string str_smallProdMulti = "Small_Prod_Multi: ";
        private const string str_dropProdMulti = "Drop_Prod_Multi: ";
        private const string str_baMulti = "BA_Multi: ";

        private const string str_belowFactMulti = "BelowFactory_Multi: ";
        private const string str_atFactMulti = "AtFactory_Multi: ";
        private const string str_aboveFactMulti = "AboveFactory_Multi: ";
        private const string str_omniBonus = "OmniFactory_Bonus: ";
        private const string str_handMakeMulti = "Hand_Make_Multiplier: ";
        private const string str_primitiveMulti = "Primitive_Production_Bonus: ";

        private const string str_retroVBFactMax = "Retro_Vee_BFactory_MinCost_Req: ";
        private const string str_retroVCFactMax = "Retro_Vee_CFactory_MinCost_Req: ";
        private const string str_introVBFactMax = "Intro_Vee_BFactory_MinCost_Req: ";
        private const string str_introVCFactMax = "Intro_Vee_CFactory_MinCost_Req: ";
        private const string str_stdVBFactMax = "Std_Vee_BFactory_MinCost_Req: ";
        private const string str_stdVCFactMax = "Std_Vee_CFactory_MinCost_Req: ";
        private const string str_advVBFactMax = "Adv_Vee_BFactory_MinCost_Req: ";
        private const string str_advVCFactMax = "Adv_Vee_CFactory_MinCost_Req: ";
        private const string str_expVBFactMax = "Exp_Vee_BFactory_MinCost_Req: ";
        private const string str_expVCFactMax = "Exp_Vee_CFactory_MinCost_Req: ";

        private const string str_retroMechBFactMax = "Retro_MechASFB_BFactory_MinCost_Req: ";
        private const string str_retroMechCFactMax = "Retro_MechASFB_CFactory_MinCost_Req: ";
        private const string str_introMechBFactMax = "Intro_MechASFB_BFactory_MinCost_Req: ";
        private const string str_introMechCFactMax = "Intro_MechASFB_CFactory_MinCost_Req: ";
        private const string str_stdMechBFactMax = "Std_MechASFB_BFactory_MinCost_Req: ";
        private const string str_stdMechCFactMax = "Std_MechASFB_CFactory_MinCost_Req: ";
        private const string str_advMechBFactMax = "Adv_MechASFB_BFactory_MinCost_Req: ";
        private const string str_advMechCFactMax = "Adv_MechASFB_CFactory_MinCost_Req: ";
        private const string str_expMechBFactMax = "Exp_MechASFB_BFactory_MinCost_Req: ";
        private const string str_expMechCFactMax = "Exp_MechASFB_CFactory_MinCost_Req: ";

        private const string str_retroSCDropBFactMax = "Retro_SCDrop_BFactory_MinCost_Req: ";
        private const string str_retroSCDropCFactMax = "Retro_SCDrop_CFactory_MinCost_Req: ";
        private const string str_introSCDropBFactMax = "Intro_SCDrop_BFactory_MinCost_Req: ";
        private const string str_introSCDropCFactMax = "Intro_SCDrop_CFactory_MinCost_Req: ";
        private const string str_stdSCDropBFactMax = "Std_SCDrop_BFactory_MinCost_Req: ";
        private const string str_stdSCDropCFactMax = "Std_SCDrop_CFactory_MinCost_Req: ";
        private const string str_advSCDropBFactMax = "Adv_SCDrop_BFactory_MinCost_Req: ";
        private const string str_advSCDropCFactMax = "Adv_SCDrop_CFactory_MinCost_Req: ";
        private const string str_expSCDropBFactMax = "Exp_SCDrop_BFactory_MinCost_Req: ";
        private const string str_expSCDropCFactMax = "Exp_SCDrop_CFactory_MinCost_Req: ";

        private const string str_retroBABFactMax = "Retro_BA_BFactory_MinCost_Req: ";
        private const string str_retroBACFactMax = "Retro_BA_CFactory_MinCost_Req: ";
        private const string str_introBABFactMax = "Intro_BA_BFactory_MinCost_Req: ";
        private const string str_introBACFactMax = "Intro_BA_CFactory_MinCost_Req: ";
        private const string str_stdBABFactMax = "Std_BA_BFactory_MinCost_Req: ";
        private const string str_stdBACFactMax = "Std_BA_CFactory_MinCost_Req: ";
        private const string str_advBABFactMax = "Adv_BA_BFactory_MinCost_Req: ";
        private const string str_advBACFactMax = "Adv_BA_CFactory_MinCost_Req: ";
        private const string str_expBABFactMax = "Exp_BA_BFactory_MinCost_Req: ";
        private const string str_expBACFactMax = "Exp_BA_CFactory_MinCost_Req: ";

        private const string str_asfUnitType = "ASF";
        private const string str_dropshipUnitType = "Dropship";
        private const string str_smallUnitType = "Small Craft";
        private const string str_mechUnitType = "Mech";
        private const string str_baUnitType = "Battle Armor";
        private const string str_veeUnitType = "Vee";
        private const string str_minorRefitType = "Minor";
        private const string str_refitRefitType = "Refit";
        private const string str_rebuildRefitType = "Rebuild";
        private const string str_primTechLvl = "Civilian";
        private const string str_retroTechLvl = "Retro";
        private const string str_introTechLvl = "Intro";
        private const string str_stdTechLvl = "Standard";
        private const string str_advTechLvl = "Advanced";
        private const string str_expTechLvl = "Experimental";

        private const string str_saveFileFolder = "factories";
        private const string str_configName = "factory_calculator_config.txt";

        public static ProfitCalculatorForm mainForm;

        private const string str_versionNum = "1.1";

        [STAThread]
        public static void Main()
        {
            Program myClass = new();
            FindCreateFolders(myClass);
            ApplicationConfiguration.Initialize();
            Application.Run(mainForm = new ProfitCalculatorForm(myClass));
        }

        private static void FindCreateFolders(Program myClass)
        {
            try
            {
                IEnumerable<string> folderList = Directory.GetDirectories(AppDomain.CurrentDomain.BaseDirectory).Where(s => s.Contains(Program.str_saveFileFolder));

                if (!folderList.Any())
                {
                    Directory.CreateDirectory(Program.str_saveFileFolder);
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking/creating save folder.  " + ex.ToString(), "Folder Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                IEnumerable<string> fileList = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory).Where(s => s.Contains(Program.str_configName));

                if (!fileList.Any())
                {
                    SetDefaultValues(myClass);
                    WriteConfigFile(myClass);
                }
                else
                {
                    ReadConfigFile(myClass);
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking/creating config file.  " + ex.ToString(), "Config Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void SetDefaultValues(Program myClass)
        {
            // Tech level stuff
            myClass.techLevels.Add(Program.str_primTechLvl);
            myClass.techLevels.Add(Program.str_retroTechLvl);
            myClass.techLevels.Add(Program.str_introTechLvl);
            myClass.techLevels.Add(Program.str_stdTechLvl);
            myClass.techLevels.Add(Program.str_advTechLvl);
            myClass.techLevels.Add(Program.str_expTechLvl);

            myClass.techMultipliers.Add(5);
            myClass.techMultipliers.Add(5);
            myClass.techMultipliers.Add(10);
            myClass.techMultipliers.Add(20);
            myClass.techMultipliers.Add(25);
            myClass.techMultipliers.Add(30);

            // Refit stuff
            myClass.refitTypes.Add(Program.str_minorRefitType);
            myClass.refitTypes.Add(Program.str_refitRefitType);
            myClass.refitTypes.Add(Program.str_rebuildRefitType);

            myClass.refitTypeMultipliers.Add(0.1);
            myClass.refitTypeMultipliers.Add(0.25);
            myClass.refitTypeMultipliers.Add(0.5);

            // Unit types
            myClass.unitTypes.Add(Program.str_asfUnitType);
            myClass.unitTypes.Add(Program.str_baUnitType);
            myClass.unitTypes.Add(Program.str_mechUnitType);
            myClass.unitTypes.Add(Program.str_dropshipUnitType);
            myClass.unitTypes.Add(Program.str_smallUnitType);
            myClass.unitTypes.Add(Program.str_veeUnitType);

            // BA Weight Costs
            myClass.lightBA_cost = 25;
            myClass.mediumBA_cost = 50;
            myClass.heavyBA_cost = 75;
            myClass.assaultBA_cost = 100;

            // Unit Type Multi
            myClass.mechMulti = 1;
            myClass.asfMulti = 1;
            myClass.veeMulti = 0.5;
            myClass.smallMulti = 1;

            // Factory outputs
            myClass.bFactoryOutput = 10;
            myClass.cFactoryOutput = 20;
            myClass.retroFactoryOutput = 100;
            myClass.introFactoryOutput = 100;
            myClass.stdFactoryOutput = 100;
            myClass.advFactoryOutput = 100;
            myClass.expFactoryOutput = 100;

            // Production Multipliers
            myClass.mechProdMulti = 1;
            myClass.asfProdMulti = 1;
            myClass.veeProdMulti = 2;
            myClass.smallProdMulti = 2;
            myClass.dropshipProdMulti = 2;
            myClass.battleArmorMulti = 0.4;
            myClass.belowFactoryTechMulti = 1.5;
            myClass.atFactoryTechMulti = 1;
            myClass.aboveFactoryTechMulti = 0.5;
            myClass.primitiveMulti = 1.5;
            myClass.handMakeCostMulti = 0.25;

            // Basic and Component Factory requirements
            myClass.omniFactoryBonusCFactory = 5;

            // Retrotech
            myClass.retroBattleArm_BFactoryMax = 2;
            myClass.retroBattleArm_CFactoryMax = 1;
            myClass.retroVee_BFactoryMax = 1;
            myClass.retroVee_CFactoryMax = 1;
            myClass.retroMechASF_BFactoryMax = 2;
            myClass.retroMechASF_CFactoryMax = 1;
            myClass.retroSmallCraftDrop_BFactoryMax = 3;
            myClass.retroSmallCraftDrop_CFactoryMax = 1;

            // Introtech
            myClass.introBattleArm_BFactoryMax = 2;
            myClass.introBattleArm_CFactoryMax = 1;
            myClass.introVee_BFactoryMax = 2;
            myClass.introVee_CFactoryMax = 1;
            myClass.introMechASF_BFactoryMax = 3;
            myClass.introMechASF_CFactoryMax = 2;
            myClass.introSmallCraftDrop_BFactoryMax = 4;
            myClass.introSmallCraftDrop_CFactoryMax = 3;

            // Standard
            myClass.stdBattleArm_BFactoryMax = 2;
            myClass.stdBattleArm_CFactoryMax = 1;
            myClass.stdVee_BFactoryMax = 2;
            myClass.stdVee_CFactoryMax = 3;
            myClass.stdMechASF_BFactoryMax = 4;
            myClass.stdMechASF_CFactoryMax = 5;
            myClass.stdSmallCraftDrop_BFactoryMax = 6;
            myClass.stdSmallCraftDrop_CFactoryMax = 7;

            // Advanced
            myClass.advBattleArm_BFactoryMax = 2;
            myClass.advBattleArm_CFactoryMax = 2;
            myClass.advVee_BFactoryMax = 4;
            myClass.advVee_CFactoryMax = 5;
            myClass.advMechASF_BFactoryMax = 6;
            myClass.advMechASF_CFactoryMax = 8;
            myClass.advSmallCraftDrop_BFactoryMax = 8;
            myClass.advSmallCraftDrop_CFactoryMax = 11;

            // Experimental
            myClass.expBattleArm_BFactoryMax = 3;
            myClass.expBattleArm_CFactoryMax = 5;
            myClass.expVee_BFactoryMax = 6;
            myClass.expVee_CFactoryMax = 8;
            myClass.expMechASF_BFactoryMax = 8;
            myClass.expMechASF_CFactoryMax = 11;
            myClass.expSmallCraftDrop_BFactoryMax = 10;
            myClass.expSmallCraftDrop_CFactoryMax = 15;
        }

        private static void WriteConfigFile(Program myClass)
        {
            try
            {
                using (StreamWriter wt = new(str_configName))
                {
                    myClass.techLevels.ForEach(delegate (string s) { wt.WriteLine(str_techLevel + s); });
                    myClass.techMultipliers.ForEach(delegate (double s) { wt.WriteLine(str_techMulti + s.ToString()); });
                    myClass.refitTypes.ForEach(delegate (string s) { wt.WriteLine(str_refitType + s); });
                    myClass.refitTypeMultipliers.ForEach(delegate (double s) { wt.WriteLine(str_refitMulti + s.ToString()); });
                    myClass.unitTypes.ForEach(delegate (string s) { wt.WriteLine(str_unitType + s); });

                    wt.WriteLine(str_lightBACost + myClass.lightBA_cost);
                    wt.WriteLine(str_mediumBACost + myClass.mediumBA_cost);
                    wt.WriteLine(str_heavyBACost + myClass.heavyBA_cost);
                    wt.WriteLine(str_assaultBACost + myClass.assaultBA_cost);

                    wt.WriteLine(str_mechMulti + myClass.mechMulti);
                    wt.WriteLine(str_asfMulti + myClass.asfMulti);
                    wt.WriteLine(str_veeMulti + myClass.veeMulti);
                    wt.WriteLine(str_smallMulti + myClass.smallMulti);

                    wt.WriteLine(str_bFactCap + myClass.bFactoryOutput);
                    wt.WriteLine(str_cFactCap + myClass.cFactoryOutput);
                    wt.WriteLine(str_retroFactCap + myClass.retroFactoryOutput);
                    wt.WriteLine(str_introFactCap + myClass.introFactoryOutput);
                    wt.WriteLine(str_stdFactCap + myClass.stdFactoryOutput);
                    wt.WriteLine(str_advFactCap + myClass.advFactoryOutput);
                    wt.WriteLine(str_expFactCap + myClass.expFactoryOutput);

                    wt.WriteLine(str_mechProdMulti + myClass.mechProdMulti);
                    wt.WriteLine(str_asfProdMulti + myClass.asfProdMulti);
                    wt.WriteLine(str_veeProdMulti + myClass.veeProdMulti);
                    wt.WriteLine(str_smallProdMulti + myClass.smallProdMulti);
                    wt.WriteLine(str_dropProdMulti + myClass.dropshipProdMulti);
                    wt.WriteLine(str_baMulti + myClass.battleArmorMulti);
                    wt.WriteLine(str_belowFactMulti + myClass.belowFactoryTechMulti);
                    wt.WriteLine(str_atFactMulti + myClass.atFactoryTechMulti);
                    wt.WriteLine(str_aboveFactMulti + myClass.aboveFactoryTechMulti);
                    wt.WriteLine(str_handMakeMulti + myClass.handMakeCostMulti);
                    wt.WriteLine(str_omniBonus + myClass.omniFactoryBonusCFactory);
                    wt.WriteLine(str_primitiveMulti + myClass.primitiveMulti);

                    wt.WriteLine(str_retroVBFactMax + myClass.retroVee_BFactoryMax);
                    wt.WriteLine(str_retroVCFactMax + myClass.retroVee_CFactoryMax);
                    wt.WriteLine(str_introVBFactMax + myClass.introVee_BFactoryMax);
                    wt.WriteLine(str_introVCFactMax + myClass.introVee_CFactoryMax);
                    wt.WriteLine(str_stdVBFactMax + myClass.stdVee_BFactoryMax);
                    wt.WriteLine(str_stdVCFactMax + myClass.stdVee_CFactoryMax);
                    wt.WriteLine(str_advVBFactMax + myClass.advVee_BFactoryMax);
                    wt.WriteLine(str_advVCFactMax + myClass.advVee_CFactoryMax);
                    wt.WriteLine(str_expVBFactMax + myClass.expVee_BFactoryMax);
                    wt.WriteLine(str_expVCFactMax + myClass.expVee_CFactoryMax);

                    wt.WriteLine(str_retroMechBFactMax + myClass.retroMechASF_BFactoryMax);
                    wt.WriteLine(str_retroMechCFactMax + myClass.retroMechASF_CFactoryMax);
                    wt.WriteLine(str_introMechBFactMax + myClass.introMechASF_BFactoryMax);
                    wt.WriteLine(str_introMechCFactMax + myClass.introMechASF_CFactoryMax);
                    wt.WriteLine(str_stdMechBFactMax + myClass.stdMechASF_BFactoryMax);
                    wt.WriteLine(str_stdMechCFactMax + myClass.stdMechASF_CFactoryMax);
                    wt.WriteLine(str_advMechBFactMax + myClass.advMechASF_BFactoryMax);
                    wt.WriteLine(str_advMechCFactMax + myClass.advMechASF_CFactoryMax);
                    wt.WriteLine(str_expMechBFactMax + myClass.expMechASF_BFactoryMax);
                    wt.WriteLine(str_expMechCFactMax + myClass.expMechASF_CFactoryMax);

                    wt.WriteLine(str_retroSCDropBFactMax + myClass.retroSmallCraftDrop_BFactoryMax);
                    wt.WriteLine(str_retroSCDropCFactMax + myClass.retroSmallCraftDrop_CFactoryMax);
                    wt.WriteLine(str_introSCDropBFactMax + myClass.introSmallCraftDrop_BFactoryMax);
                    wt.WriteLine(str_introSCDropCFactMax + myClass.introSmallCraftDrop_CFactoryMax);
                    wt.WriteLine(str_stdSCDropBFactMax + myClass.stdSmallCraftDrop_BFactoryMax);
                    wt.WriteLine(str_stdSCDropCFactMax + myClass.stdSmallCraftDrop_CFactoryMax);
                    wt.WriteLine(str_advSCDropBFactMax + myClass.advSmallCraftDrop_BFactoryMax);
                    wt.WriteLine(str_advSCDropCFactMax + myClass.advSmallCraftDrop_CFactoryMax);
                    wt.WriteLine(str_expSCDropBFactMax + myClass.expSmallCraftDrop_BFactoryMax);
                    wt.WriteLine(str_expSCDropCFactMax + myClass.expSmallCraftDrop_CFactoryMax);

                    wt.WriteLine(str_retroBABFactMax + myClass.retroBattleArm_BFactoryMax);
                    wt.WriteLine(str_retroBACFactMax + myClass.retroBattleArm_CFactoryMax);
                    wt.WriteLine(str_introBABFactMax + myClass.introBattleArm_BFactoryMax);
                    wt.WriteLine(str_introBACFactMax + myClass.introBattleArm_CFactoryMax);
                    wt.WriteLine(str_stdBABFactMax + myClass.stdBattleArm_BFactoryMax);
                    wt.WriteLine(str_stdBACFactMax + myClass.stdBattleArm_CFactoryMax);
                    wt.WriteLine(str_advBABFactMax + myClass.advBattleArm_BFactoryMax);
                    wt.WriteLine(str_advBACFactMax + myClass.advBattleArm_CFactoryMax);
                    wt.WriteLine(str_expBABFactMax + myClass.expBattleArm_BFactoryMax);
                    wt.WriteLine(str_expBACFactMax + myClass.expBattleArm_CFactoryMax);

                    wt.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error writing to config file.  " + ex.ToString(), "Config Write Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void ReadConfigFile(Program myClass)
        {
            try
            {
                using (StreamReader rt = new(str_configName))
                {
                    myClass.techLevels.Add(rt.ReadLine()!.Remove(0, str_techLevel.Length));
                    myClass.techLevels.Add(rt.ReadLine()!.Remove(0, str_techLevel.Length));
                    myClass.techLevels.Add(rt.ReadLine()!.Remove(0, str_techLevel.Length));
                    myClass.techLevels.Add(rt.ReadLine()!.Remove(0, str_techLevel.Length));
                    myClass.techLevels.Add(rt.ReadLine()!.Remove(0, str_techLevel.Length));
                    myClass.techLevels.Add(rt.ReadLine()!.Remove(0, str_techLevel.Length));

                    myClass.techMultipliers.Add(double.Parse(rt.ReadLine()!.Remove(0, str_techMulti.Length)));
                    myClass.techMultipliers.Add(double.Parse(rt.ReadLine()!.Remove(0, str_techMulti.Length)));
                    myClass.techMultipliers.Add(double.Parse(rt.ReadLine()!.Remove(0, str_techMulti.Length)));
                    myClass.techMultipliers.Add(double.Parse(rt.ReadLine()!.Remove(0, str_techMulti.Length)));
                    myClass.techMultipliers.Add(double.Parse(rt.ReadLine()!.Remove(0, str_techMulti.Length)));
                    myClass.techMultipliers.Add(double.Parse(rt.ReadLine()!.Remove(0, str_techMulti.Length)));

                    myClass.refitTypes.Add(rt.ReadLine()!.Remove(0, str_refitType.Length));
                    myClass.refitTypes.Add(rt.ReadLine()!.Remove(0, str_refitType.Length));
                    myClass.refitTypes.Add(rt.ReadLine()!.Remove(0, str_refitType.Length));

                    myClass.refitTypeMultipliers.Add(double.Parse(rt.ReadLine()!.Remove(0, str_refitMulti.Length)));
                    myClass.refitTypeMultipliers.Add(double.Parse(rt.ReadLine()!.Remove(0, str_refitMulti.Length)));
                    myClass.refitTypeMultipliers.Add(double.Parse(rt.ReadLine()!.Remove(0, str_refitMulti.Length)));

                    myClass.unitTypes.Add(rt.ReadLine()!.Remove(0, str_unitType.Length));
                    myClass.unitTypes.Add(rt.ReadLine()!.Remove(0, str_unitType.Length));
                    myClass.unitTypes.Add(rt.ReadLine()!.Remove(0, str_unitType.Length));
                    myClass.unitTypes.Add(rt.ReadLine()!.Remove(0, str_unitType.Length));
                    myClass.unitTypes.Add(rt.ReadLine()!.Remove(0, str_unitType.Length));
                    myClass.unitTypes.Add(rt.ReadLine()!.Remove(0, str_unitType.Length));

                    myClass.lightBA_cost = double.Parse(rt.ReadLine()!.Remove(0, str_lightBACost.Length));
                    myClass.mediumBA_cost = double.Parse(rt.ReadLine()!.Remove(0, str_mediumBACost.Length));
                    myClass.heavyBA_cost = double.Parse(rt.ReadLine()!.Remove(0, str_heavyBACost.Length));
                    myClass.assaultBA_cost = double.Parse(rt.ReadLine()!.Remove(0, str_assaultBACost.Length));

                    myClass.mechMulti = double.Parse(rt.ReadLine()!.Remove(0, str_mechMulti.Length));
                    myClass.asfMulti = double.Parse(rt.ReadLine()!.Remove(0, str_asfMulti.Length));
                    myClass.veeMulti = double.Parse(rt.ReadLine()!.Remove(0, str_veeMulti.Length));
                    myClass.smallMulti = double.Parse(rt.ReadLine()!.Remove(0, str_smallMulti.Length));

                    myClass.bFactoryOutput = double.Parse(rt.ReadLine()!.Remove(0, str_bFactCap.Length));
                    myClass.cFactoryOutput = double.Parse(rt.ReadLine()!.Remove(0, str_cFactCap.Length));
                    myClass.retroFactoryOutput = double.Parse(rt.ReadLine()!.Remove(0, str_retroFactCap.Length));
                    myClass.introFactoryOutput = double.Parse(rt.ReadLine()!.Remove(0, str_introFactCap.Length));
                    myClass.stdFactoryOutput = double.Parse(rt.ReadLine()!.Remove(0, str_stdFactCap.Length));
                    myClass.advFactoryOutput = double.Parse(rt.ReadLine()!.Remove(0, str_advFactCap.Length));
                    myClass.expFactoryOutput = double.Parse(rt.ReadLine()!.Remove(0, str_expFactCap.Length));

                    myClass.mechProdMulti = double.Parse(rt.ReadLine()!.Remove(0, str_mechProdMulti.Length));
                    myClass.asfProdMulti = double.Parse(rt.ReadLine()!.Remove(0, str_asfProdMulti.Length));
                    myClass.veeProdMulti = double.Parse(rt.ReadLine()!.Remove(0, str_veeProdMulti.Length));
                    myClass.smallProdMulti = double.Parse(rt.ReadLine()!.Remove(0, str_smallProdMulti.Length));
                    myClass.dropshipProdMulti = double.Parse(rt.ReadLine()!.Remove(0, str_dropProdMulti.Length));
                    myClass.battleArmorMulti = double.Parse(rt.ReadLine()!.Remove(0, str_baMulti.Length));
                    myClass.belowFactoryTechMulti = double.Parse(rt.ReadLine()!.Remove(0, str_belowFactMulti.Length));
                    myClass.atFactoryTechMulti = double.Parse(rt.ReadLine()!.Remove(0, str_atFactMulti.Length));
                    myClass.aboveFactoryTechMulti = double.Parse(rt.ReadLine()!.Remove(0, str_aboveFactMulti.Length));
                    myClass.handMakeCostMulti = double.Parse(rt.ReadLine()!.Remove(0, str_handMakeMulti.Length));
                    myClass.omniFactoryBonusCFactory = Int32.Parse(rt.ReadLine()!.Remove(0, str_omniBonus.Length));
                    myClass.primitiveMulti = double.Parse(rt.ReadLine()!.Remove(0, str_primitiveMulti.Length));

                    myClass.retroVee_BFactoryMax = Int32.Parse(rt.ReadLine()!.Remove(0, str_retroVBFactMax.Length));
                    myClass.retroVee_CFactoryMax = Int32.Parse(rt.ReadLine()!.Remove(0, str_retroVCFactMax.Length));
                    myClass.introVee_BFactoryMax = Int32.Parse(rt.ReadLine()!.Remove(0, str_introVBFactMax.Length));
                    myClass.introVee_CFactoryMax = Int32.Parse(rt.ReadLine()!.Remove(0, str_introVCFactMax.Length));
                    myClass.stdVee_BFactoryMax = Int32.Parse(rt.ReadLine()!.Remove(0, str_stdVBFactMax.Length));
                    myClass.stdVee_CFactoryMax = Int32.Parse(rt.ReadLine()!.Remove(0, str_stdVCFactMax.Length));
                    myClass.advVee_BFactoryMax = Int32.Parse(rt.ReadLine()!.Remove(0, str_advVBFactMax.Length));
                    myClass.advVee_CFactoryMax = Int32.Parse(rt.ReadLine()!.Remove(0, str_advVCFactMax.Length));
                    myClass.expVee_BFactoryMax = Int32.Parse(rt.ReadLine()!.Remove(0, str_expVBFactMax.Length));
                    myClass.expVee_CFactoryMax = Int32.Parse(rt.ReadLine()!.Remove(0, str_expVCFactMax.Length));

                    myClass.retroMechASF_BFactoryMax = Int32.Parse(rt.ReadLine()!.Remove(0, str_retroMechBFactMax.Length));
                    myClass.retroMechASF_CFactoryMax = Int32.Parse(rt.ReadLine()!.Remove(0, str_retroMechCFactMax.Length));
                    myClass.introMechASF_BFactoryMax = Int32.Parse(rt.ReadLine()!.Remove(0, str_introMechBFactMax.Length));
                    myClass.introMechASF_CFactoryMax = Int32.Parse(rt.ReadLine()!.Remove(0, str_introMechCFactMax.Length));
                    myClass.stdMechASF_BFactoryMax = Int32.Parse(rt.ReadLine()!.Remove(0, str_stdMechBFactMax.Length));
                    myClass.stdMechASF_CFactoryMax = Int32.Parse(rt.ReadLine()!.Remove(0, str_stdMechCFactMax.Length));
                    myClass.advMechASF_BFactoryMax = Int32.Parse(rt.ReadLine()!.Remove(0, str_advMechBFactMax.Length));
                    myClass.advMechASF_CFactoryMax = Int32.Parse(rt.ReadLine()!.Remove(0, str_advMechCFactMax.Length));
                    myClass.expMechASF_BFactoryMax = Int32.Parse(rt.ReadLine()!.Remove(0, str_expMechBFactMax.Length));
                    myClass.expMechASF_CFactoryMax = Int32.Parse(rt.ReadLine()!.Remove(0, str_expMechCFactMax.Length));

                    myClass.retroSmallCraftDrop_BFactoryMax = Int32.Parse(rt.ReadLine()!.Remove(0, str_retroSCDropBFactMax.Length));
                    myClass.retroSmallCraftDrop_CFactoryMax = Int32.Parse(rt.ReadLine()!.Remove(0, str_retroSCDropCFactMax.Length));
                    myClass.introSmallCraftDrop_BFactoryMax = Int32.Parse(rt.ReadLine()!.Remove(0, str_introSCDropBFactMax.Length));
                    myClass.introSmallCraftDrop_CFactoryMax = Int32.Parse(rt.ReadLine()!.Remove(0, str_introSCDropCFactMax.Length));
                    myClass.stdSmallCraftDrop_BFactoryMax = Int32.Parse(rt.ReadLine()!.Remove(0, str_stdSCDropBFactMax.Length));
                    myClass.stdSmallCraftDrop_CFactoryMax = Int32.Parse(rt.ReadLine()!.Remove(0, str_stdSCDropCFactMax.Length));
                    myClass.advSmallCraftDrop_BFactoryMax = Int32.Parse(rt.ReadLine()!.Remove(0, str_advSCDropBFactMax.Length));
                    myClass.advSmallCraftDrop_CFactoryMax = Int32.Parse(rt.ReadLine()!.Remove(0, str_advSCDropCFactMax.Length));
                    myClass.expSmallCraftDrop_BFactoryMax = Int32.Parse(rt.ReadLine()!.Remove(0, str_expSCDropBFactMax.Length));
                    myClass.expSmallCraftDrop_CFactoryMax = Int32.Parse(rt.ReadLine()!.Remove(0, str_expSCDropCFactMax.Length));

                    myClass.retroBattleArm_BFactoryMax = Int32.Parse(rt.ReadLine()!.Remove(0, str_retroBABFactMax.Length));
                    myClass.retroBattleArm_CFactoryMax = Int32.Parse(rt.ReadLine()!.Remove(0, str_retroBACFactMax.Length));
                    myClass.introBattleArm_BFactoryMax = Int32.Parse(rt.ReadLine()!.Remove(0, str_introBABFactMax.Length));
                    myClass.introBattleArm_CFactoryMax = Int32.Parse(rt.ReadLine()!.Remove(0, str_introBACFactMax.Length));
                    myClass.stdBattleArm_BFactoryMax = Int32.Parse(rt.ReadLine()!.Remove(0, str_stdBABFactMax.Length));
                    myClass.stdBattleArm_CFactoryMax = Int32.Parse(rt.ReadLine()!.Remove(0, str_stdBACFactMax.Length));
                    myClass.advBattleArm_BFactoryMax = Int32.Parse(rt.ReadLine()!.Remove(0, str_advBABFactMax.Length));
                    myClass.advBattleArm_CFactoryMax = Int32.Parse(rt.ReadLine()!.Remove(0, str_advBACFactMax.Length));
                    myClass.expBattleArm_BFactoryMax = Int32.Parse(rt.ReadLine()!.Remove(0, str_expBABFactMax.Length));
                    myClass.expBattleArm_CFactoryMax = Int32.Parse(rt.ReadLine()!.Remove(0, str_expBACFactMax.Length));

                    rt.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading from config file.  " + ex.ToString(), "Config Read Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SaveFactoryFile()
        {
            try
            {
                if(mainForm.Variant != "")
                { 
                    string fileName = mainForm.Variant;
                    string fullFileName = str_saveFileFolder + "\\" + fileName + ".txt";
                    DialogResult saveFile = DialogResult.Yes;

                    if (File.Exists(fullFileName))
                    {
                        saveFile = MessageBox.Show("File exists, Overwrite?", "File Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    }

                    if (saveFile == DialogResult.Yes)
                    {
                        using (StreamWriter wt = new(fullFileName))
                        {
                            wt.WriteLine(mainForm.Variant);
                            wt.WriteLine(mainForm.Tonnage);
                            wt.WriteLine(mainForm.UnitType);
                            wt.WriteLine(mainForm.FactoryType);
                            wt.WriteLine(mainForm.Cost);
                            wt.WriteLine(mainForm.TechLevel);
                            wt.WriteLine(mainForm.HandMake);
                            wt.WriteLine(mainForm.BFactory);
                            wt.WriteLine(mainForm.CFactory);
                            wt.WriteLine(mainForm.Refit);
                            wt.WriteLine(mainForm.RefitTechLevel);
                            wt.WriteLine(mainForm.RefitType);
                            wt.WriteLine(mainForm.Omni);
                            wt.WriteLine(mainForm.SellTechLevel);

                            wt.Close();
                        }
                    }
                    else
                    {
                        saveFile = DialogResult.No;
                        MessageBox.Show("File not saved.", "File Not Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Missing File Name.", "File Not Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Saving Factory.  " + ex.ToString(), "Form Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadFactoryFile()
        {
            try
            {
                OpenFileDialog openFileDialog = new();
                openFileDialog.InitialDirectory = str_saveFileFolder;
                openFileDialog.Title = "Browse Saved Factories";
                openFileDialog.DefaultExt = "txt";
                openFileDialog.Filter = "txt files (*.txt)|*.txt";
                openFileDialog.CheckFileExists = true;
                openFileDialog.CheckPathExists = true;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.ShowReadOnly = true;

                mainForm.update = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader rt = new StreamReader(openFileDialog.FileName))
                    {
                        mainForm.Variant = rt.ReadLine();
                        mainForm.Tonnage = decimal.Parse(rt.ReadLine());
                        mainForm.UnitType = Int32.Parse(rt.ReadLine());
                        mainForm.FactoryType = int.Parse(rt.ReadLine());
                        mainForm.Cost = decimal.Parse(rt.ReadLine());
                        mainForm.TechLevel = int.Parse(rt.ReadLine());
                        mainForm.HandMake = bool.Parse(rt.ReadLine());
                        mainForm.BFactory = int.Parse(rt.ReadLine());
                        mainForm.CFactory = int.Parse(rt.ReadLine());
                        mainForm.Refit = bool.Parse(rt.ReadLine());
                        mainForm.RefitTechLevel = int.Parse(rt.ReadLine());
                        mainForm.RefitType = int.Parse(rt.ReadLine());
                        mainForm.Omni = bool.Parse(rt.ReadLine());
                        mainForm.SellTechLevel = int.Parse(rt.ReadLine());

                        rt.Close();
                    }
                }

                mainForm.update = true;
                UpdateValues();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Loading Factory.  " + ex.ToString(), "Form Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void AboutDialog()
        {
            try
            {
                MessageBox.Show("This tool was coded by Morkath.  It was designed by Sprero to calcuate the factory production rates for a Battletech Campaign game.  Version: " + str_versionNum, "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Showing About.  " + ex.ToString(), "Form Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateValues()
        {
            CalculateValues();
        }
        private void CalculateValues()
        {
            UpdateTonnage();
            UpdateTechLevel();
            UpdateUnitCost();
            UpdateChassisCosts();
            UpdateFactoryType();
            UpdateFeederFactories();
            UpdateRequiredTOnnage();
            UpdateCostMultipler();
            UpdateModifiedChassisCost();
            UpdateRefitTechLevel();
            UpdateRefitType();
            UpdateRefitCost();
            UpdateTotalCost();
            UpdateProductionRate();
            UpdateSellTechMulti();
            UpdateMonthlyCost();
            UpdateMonthlyGross();
            UpdateMonthlyNet();
        }
        private void UpdateTonnage()
        {
            try
            {
                if (mainForm.Tonnage >= 0)
                {
                    tonnage = Convert.ToDouble(mainForm.Tonnage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating Tonnage.  " + ex.ToString(), "Form Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateTechLevel()
        {
            try
            {
                techLevel = techLevels[mainForm.TechLevel];

                if (mainForm.TechLevel >= 0)
                {
                    techMulti = techMultipliers[mainForm.TechLevel];
                    mainForm.TechMulti = Math.Round(techMulti, 3).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating Tech Level.  " + ex.ToString(), "Form Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateUnitCost()
        {
            try
            {
                if (Convert.ToInt32(mainForm.Cost) >= 0)
                {
                    unitCostCount = Convert.ToInt32(mainForm.Cost);
                 }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating Unit Cost/Count.  " + ex.ToString(), "Form Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateChassisCosts()
        {
            try
            {
                unitType = unitTypes[mainForm.UnitType];

                if (mainForm.UnitType >= 0)
                {
                    if(unitType == str_mechUnitType) // Mech
                    {
                        baseChassisCost = tonnage * techMulti * mechMulti;
                    }
                    else if (unitType == str_asfUnitType) // Aerospace Fighter
                    {
                        baseChassisCost = tonnage * techMulti * asfMulti;
                    }
                    else if (unitType == str_veeUnitType) // Vee
                    {
                        baseChassisCost = tonnage * techMulti * veeMulti;
                    }
                    else if (unitType == str_smallUnitType) // Small Craft
                    {
                        baseChassisCost = tonnage * techMulti * smallMulti;
                    }
                    else if (unitType == str_dropshipUnitType) // Dropship
                    {
                        baseChassisCost = unitCostCount;
                    }
                    else if (unitType == str_baUnitType) // Battle Armor 
                    {
                        double suitCost = 0;

                        if (tonnage < 1)
                        {
                            suitCost = lightBA_cost;
                        }
                        else if (tonnage == 1)
                        {
                            suitCost = mediumBA_cost;
                        }
                        else if (tonnage == 1.5)
                        {
                            suitCost = heavyBA_cost;
                        }
                        else if (tonnage == 2)
                        {
                            suitCost = assaultBA_cost;
                        }

                        baseChassisCost = suitCost;
                    }

                    handmake = mainForm.HandMake;

                    // Hand make modifier
                    if (handmake)
                    {
                        handMakeCost = baseChassisCost * handMakeCostMulti;
                        mainForm.HandMakeCost = handMakeCost.ToString();
                    }
                    else
                    {
                        handMakeCost = 0;
                        mainForm.HandMakeCost = "0";
                    }

                    mainForm.ChassisCost = Math.Round(baseChassisCost, 3).ToString();
                    mainForm.ModChassisCost = Math.Round(modifiedChassisCost, 3).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating Chassis Cost.  " + ex.ToString(), "Form Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateFactoryType()
        {
            try
            {
                factoryTechLevel = techLevels[mainForm.FactoryType];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating Factory Type.  " + ex.ToString(), "Form Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateFeederFactories()
        {
            try
            {
                // Required Tonnage = b output * b max + c output * c max
                bFactoryCount = Convert.ToInt32(mainForm.BFactory);
                cFactoryCount = Convert.ToInt32(mainForm.CFactory);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating feeder factories.  " + ex.ToString(), "Form Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void UpdateRequiredTOnnage()
        {
            bFactoryMax = 0;
            cFactoryMax = 0;

            try
            {
                if (techLevel == techLevels[0] || techLevel == techLevels[1])
                {
                    if (unitType == str_mechUnitType || unitType == str_asfUnitType)
                    {
                        bFactoryMax = retroMechASF_BFactoryMax;
                        cFactoryMax = retroMechASF_CFactoryMax;
                    }
                    else if (unitType == str_veeUnitType)
                    {
                        bFactoryMax = retroVee_BFactoryMax;
                        cFactoryMax = retroVee_CFactoryMax;
                    }
                    else if (unitType == str_dropshipUnitType || unitType == str_smallUnitType)
                    {
                        bFactoryMax = retroSmallCraftDrop_BFactoryMax;
                        cFactoryMax = retroSmallCraftDrop_CFactoryMax;
                    }
                    else if (unitType == str_baUnitType)
                    {
                        bFactoryMax = retroBattleArm_BFactoryMax;
                        cFactoryMax = retroBattleArm_CFactoryMax;
                    }
                }
                else if (techLevel == techLevels[2])
                {
                    if (unitType == str_mechUnitType || unitType == str_asfUnitType)
                    {
                        bFactoryMax = introMechASF_BFactoryMax;
                        cFactoryMax = introMechASF_CFactoryMax;
                    }
                    else if (unitType == str_veeUnitType)
                    {
                        bFactoryMax = introVee_BFactoryMax;
                        cFactoryMax = introVee_CFactoryMax;
                    }
                    else if (unitType == str_dropshipUnitType || unitType == str_smallUnitType)
                    {
                        bFactoryMax = introSmallCraftDrop_BFactoryMax;
                        cFactoryMax = introSmallCraftDrop_CFactoryMax;
                    }
                    else if (unitType == str_baUnitType)
                    {
                        bFactoryMax = introBattleArm_BFactoryMax;
                        cFactoryMax = introBattleArm_CFactoryMax;
                    }
                }
                else if (techLevel == techLevels[3])
                {
                    if (unitType == str_mechUnitType || unitType == str_asfUnitType)
                    {
                        bFactoryMax = stdMechASF_BFactoryMax;
                        cFactoryMax = stdMechASF_CFactoryMax;
                    }
                    else if (unitType == str_veeUnitType)
                    {
                        bFactoryMax = stdVee_BFactoryMax;
                        cFactoryMax = stdVee_CFactoryMax;
                    }
                    else if (unitType == str_dropshipUnitType || unitType == str_smallUnitType)
                    {
                        bFactoryMax = stdSmallCraftDrop_BFactoryMax;
                        cFactoryMax = stdSmallCraftDrop_CFactoryMax;
                    }
                    else if (unitType == str_baUnitType)
                    {
                        bFactoryMax = stdBattleArm_BFactoryMax;
                        cFactoryMax = stdBattleArm_CFactoryMax;
                    }
                }
                else if (techLevel == techLevels[4])
                {
                    if (unitType == str_mechUnitType || unitType == str_asfUnitType)
                    {
                        bFactoryMax = advMechASF_BFactoryMax;
                        cFactoryMax = advMechASF_CFactoryMax;
                    }
                    else if (unitType == str_veeUnitType)
                    {
                        bFactoryMax = advVee_BFactoryMax;
                        cFactoryMax = advVee_CFactoryMax;
                    }
                    else if (unitType == str_dropshipUnitType || unitType == str_smallUnitType)
                    {
                        bFactoryMax = advSmallCraftDrop_BFactoryMax;
                        cFactoryMax = advSmallCraftDrop_CFactoryMax;
                    }
                    else if (unitType == str_baUnitType)
                    {
                        bFactoryMax = advBattleArm_BFactoryMax;
                        cFactoryMax = advBattleArm_CFactoryMax;
                    }
                }
                else if (techLevel == techLevels[5])
                {
                    if (unitType == str_mechUnitType || unitType == str_asfUnitType)
                    {
                        bFactoryMax = expMechASF_BFactoryMax;
                        cFactoryMax = expMechASF_CFactoryMax;
                    }
                    else if (unitType == str_veeUnitType)
                    {
                        bFactoryMax = expVee_BFactoryMax;
                        cFactoryMax = expVee_CFactoryMax;
                    }
                    else if (unitType == str_dropshipUnitType || unitType == str_smallUnitType)
                    {
                        bFactoryMax = expSmallCraftDrop_BFactoryMax;
                        cFactoryMax = expSmallCraftDrop_CFactoryMax;
                    }
                    else if (unitType == str_baUnitType)
                    {
                        bFactoryMax = expBattleArm_BFactoryMax;
                        cFactoryMax = expBattleArm_CFactoryMax;
                    }
                }

                requiredTonnage = (bFactoryMax * bFactoryOutput) + (cFactoryMax * cFactoryOutput);
                mainForm.RequiredTonnage = requiredTonnage.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating required tonnage.  " + ex.ToString(), "Form Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateCostMultipler()
        {
            try
            {
                int b;
                int c;

                if ((Convert.ToInt32(mainForm.BFactory) - bFactoryMax) <= 0)
                {
                    b = Convert.ToInt32(mainForm.BFactory);
                }
                else
                {
                    b = bFactoryMax;
                }
                if ((Convert.ToInt32(mainForm.CFactory) - cFactoryMax) <= 0)
                {
                    c = Convert.ToInt32(mainForm.CFactory);
                }
                else
                {
                    c = cFactoryMax;
                }

                costMulti = 100 - (50 * ((b * bFactoryOutput) + (c * cFactoryOutput)) / requiredTonnage);

                mainForm.CostMultiplier = Math.Round(costMulti, 3).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating Cost Multiplier.  " + ex.ToString(), "Form Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateModifiedChassisCost()
        {
            try
            {
                modifiedChassisCost = (baseChassisCost * (costMulti / 100));

                if (handmake)
                {
                    modifiedChassisCost += handMakeCost;
                }
                
                mainForm.ModChassisCost = Math.Round(modifiedChassisCost, 3).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating Modified Chassis Cost.  " + ex.ToString(), "Form Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateRefitTechLevel()
        {
            try
            {
                refit = mainForm.Refit;
                if (refit)
                { 
                    if (mainForm.RefitTechLevel >= 0)
                    {
                        refitTechMulti = techMultipliers[mainForm.RefitTechLevel];
                        mainForm.RefitTechMulti = Math.Round(refitTechMulti, 3).ToString();
                    }
                }
                else
                {
                    refitTechMulti = 0;
                    mainForm.RefitTechMulti = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating Refit Tech Level.  " + ex.ToString(), "Form Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateRefitType()
        {
            try
            {
                if (refit)
                { 
                    if (mainForm.RefitType >= 0)
                    {
                        refitTypeMulti = refitTypeMultipliers[mainForm.RefitType];
                        mainForm.RefitMulti = refitTypeMulti.ToString();
                    }
                }
                else
                {
                    refitTypeMulti = 0;
                    mainForm.RefitMulti = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating Refit Type.  " + ex.ToString(), "Form Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateRefitCost()
        {
            try
            {
                // Refit Cost = Tonnage * Refit Tech Multi * Refit Type Multi
                refitCost = tonnage * refitTechMulti * refitTypeMulti;
                mainForm.RefitCost = Math.Round(refitCost, 3).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating Refit Cost.  " + ex.ToString(), "Form Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateTotalCost()
        {
            try
            {
                totalCost = modifiedChassisCost + refitCost;
                mainForm.TotalCost = Math.Round(totalCost, 3).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating Total Cost.  " + ex.ToString(), "Form Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateProductionRate()
        {
            try
            {
                omni = mainForm.Omni;

                int smallCraftMaxB = 0;
                int smallCraftMaxC = 0;
                double factoryOutput = 0;
                double cOutput = 0;
                double bOutput = 0;

                // Set out max factory production bonus based on factory tech level.
                switch(factoryTechLevel)
                { 
                    case str_primTechLvl:
                        smallCraftMaxB = retroSmallCraftDrop_BFactoryMax;
                        smallCraftMaxC = retroSmallCraftDrop_CFactoryMax;
                        factoryOutput = retroFactoryOutput;
                        break;
                    case str_retroTechLvl:
                        smallCraftMaxB = retroSmallCraftDrop_BFactoryMax;
                        smallCraftMaxC = retroSmallCraftDrop_CFactoryMax;
                        factoryOutput = retroFactoryOutput;
                        break;
                    case str_introTechLvl:
                        smallCraftMaxB = introSmallCraftDrop_BFactoryMax;
                        smallCraftMaxC = introSmallCraftDrop_CFactoryMax;
                        factoryOutput = introFactoryOutput;
                        break;
                    case str_stdTechLvl:
                        smallCraftMaxB = stdSmallCraftDrop_BFactoryMax;
                        smallCraftMaxC = stdSmallCraftDrop_CFactoryMax;
                        factoryOutput = stdFactoryOutput;
                        break;
                    case str_advTechLvl:
                        smallCraftMaxB = advSmallCraftDrop_BFactoryMax;
                        smallCraftMaxC = advSmallCraftDrop_CFactoryMax;
                        factoryOutput = advFactoryOutput;
                        break;
                    case str_expTechLvl:
                        smallCraftMaxB = expSmallCraftDrop_BFactoryMax;
                        smallCraftMaxC = expSmallCraftDrop_CFactoryMax;
                        factoryOutput = expFactoryOutput;
                        break;
                }

                // Add our bonus to component factory limit if an omni.
                if(omni)
                {
                    smallCraftMaxC += 5;
                }

                // Add 50% bonus for every b/c factory above required for minimum cost, but below the smallcraft max.
                var bFactBonus = 0;
                var cFactBonus = 0;

                if (bFactoryCount > bFactoryMax)
                {
                    if (bFactoryCount > smallCraftMaxB)
                    {
                        bFactBonus = smallCraftMaxB - bFactoryMax;
                    }
                    else
                    {
                        bFactBonus = bFactoryCount - bFactoryMax;
                    }
                }

                if (cFactoryCount > cFactoryMax)
                {
                    if (cFactoryCount > smallCraftMaxC)
                    {
                        cFactBonus = smallCraftMaxC - cFactoryMax;
                    }
                    else
                    {
                        cFactBonus = cFactoryCount - cFactoryMax;
                    }
                }

                // Sets max extra feeder production.
                if (bFactoryCount > smallCraftMaxB)
                {
                    bOutput = (smallCraftMaxB * bFactoryOutput) + (bFactBonus * bFactoryOutput * 0.5);
                }
                else 
                {
                    bOutput = (bFactoryCount * bFactoryOutput) + (bFactBonus * bFactoryOutput * 0.5);
                }
                if (cFactoryCount > smallCraftMaxC)
                {
                    cOutput = (smallCraftMaxC * cFactoryOutput) + (cFactBonus * cFactoryOutput * 0.5);
                }
                else
                {
                    cOutput = (cFactoryCount * cFactoryOutput) + (cFactBonus * cFactoryOutput * 0.5);
                }

                if (techLevel == str_primTechLvl)
                {
                    if (mainForm.FactoryType == 1)
                    {
                        // Feeder production + 50% for producing civilian/primitive tech on a retrotech line.
                        bOutput *= 1.5;
                        cOutput *= 1.5;
                    }
                }

                // Get our base production.
                if(handmake)
                { 
                    productionRate = (10 + bOutput + cOutput) / tonnage;
                }
                else
                {
                    productionRate = (factoryOutput + bOutput + cOutput) / tonnage;
                }

                // Factory Tech Level Multipliers
                if (mainForm.FactoryType == 1 && mainForm.TechLevel == 0)
                {
                    productionRate *= atFactoryTechMulti;
                }
                else if (mainForm.FactoryType > mainForm.TechLevel)
                {
                    productionRate *= belowFactoryTechMulti;
                }
                else if (mainForm.FactoryType < mainForm.TechLevel)
                {
                    productionRate *= aboveFactoryTechMulti;
                }
                else if (mainForm.FactoryType == mainForm.TechLevel)
                {
                    productionRate *= atFactoryTechMulti;
                }

                // Unit Type Multipliers.
                switch(unitType)
                {
                    case str_asfUnitType:
                        {
                            productionRate *= asfProdMulti;
                            break;
                        }
                    case str_mechUnitType:
                        {
                            productionRate *= mechProdMulti;
                            break;
                        }
                    case str_veeUnitType:
                        {
                            productionRate *= veeProdMulti;
                            break;
                        }
                    case str_smallUnitType:
                        {
                            productionRate *= smallProdMulti;
                            break;
                        }
                    case str_dropshipUnitType:
                        {
                            productionRate *= dropshipProdMulti;
                            break;
                        }
                    case str_baUnitType:
                        {
                            productionRate *= battleArmorMulti;
                            break;
                        }
                }

                mainForm.ProductionRate = Math.Round(productionRate, 3).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating Production Rate.  " + ex.ToString(), "Form Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateMonthlyCost()
        {
            try
            {
                monthlyExpenses = totalCost * productionRate;
                mainForm.MonthlyCost = Math.Round(monthlyExpenses, 3).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating Monthly Cost.  " + ex.ToString(), "Form Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateSellTechMulti()
        {
            try
            {
                if (mainForm.SellTechLevel >= 0)
                {
                    sellTechMulti = techMultipliers[mainForm.SellTechLevel];
                    mainForm.SellTechMulti = Math.Round(sellTechMulti, 3).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating Sell Tech Level.  " + ex.ToString(), "Form Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateMonthlyGross()
        {
            try
            {
                if (unitType == str_mechUnitType) // Mech
                {
                    monthlySell = productionRate * tonnage * sellTechMulti * mechMulti;
                }
                else if (unitType == str_asfUnitType) // Aerospace Fighter
                {
                    monthlySell = productionRate * tonnage * sellTechMulti * asfMulti;
                }
                else if (unitType == str_veeUnitType) // Vee
                {
                    monthlySell = productionRate * tonnage * sellTechMulti * veeMulti;
                }
                else if (unitType == str_smallUnitType) // Small Craft
                {
                    monthlySell = productionRate * tonnage * sellTechMulti * smallMulti;
                }
                else if (unitType == str_dropshipUnitType) // Dropship
                {
                    monthlySell = productionRate * unitCostCount;
                }
                else if (unitType == str_baUnitType) // Battle Armor 
                {
                    double tempSellMulti = 0;
                    double tempBA_Cost = 0;

                    if (tonnage < 1)
                    {
                        tempBA_Cost = lightBA_cost;
                    }
                    else if (tonnage == 1)
                    {
                        tempBA_Cost = mediumBA_cost;
                    }
                    else if (tonnage == 1.5)
                    {
                        tempBA_Cost = heavyBA_cost;
                    }
                    else if (tonnage == 2)
                    {
                        tempBA_Cost = assaultBA_cost;
                    }

                    if (mainForm.SellTechLevel == 0) // Prim Tech
                    {
                        tempSellMulti = techMultipliers[3] / techMultipliers[0];
                        monthlySell = productionRate * (tempBA_Cost / tempSellMulti);
                    }
                    else if (mainForm.SellTechLevel == 1) // Retro Tech
                    {
                        tempSellMulti = techMultipliers[3] / techMultipliers[1];
                        monthlySell = productionRate * (tempBA_Cost / tempSellMulti);
                    }
                    else if (mainForm.SellTechLevel == 2) // Intro Tech
                    {
                        tempSellMulti = techMultipliers[3] / techMultipliers[2];
                        monthlySell = productionRate * (tempBA_Cost / tempSellMulti);
                    }
                    else if (mainForm.SellTechLevel == 3) // Std Tech
                    {
                        monthlySell = productionRate * tempBA_Cost; // Std is our base level, so we don't need to multiply for it.
                    }
                    else if (mainForm.SellTechLevel == 4) // Adv Tech
                    {
                        tempSellMulti = sellTechMulti / 100;
                        monthlySell = productionRate * (tempBA_Cost + (tempBA_Cost * tempSellMulti));
                    }
                    else if (mainForm.SellTechLevel == 5) // Exp/Clan Tech
                    {
                        tempSellMulti = sellTechMulti / 100;
                        monthlySell = productionRate * (tempBA_Cost + (tempBA_Cost * tempSellMulti));
                    }                    
                }
                    mainForm.MonthlySell = Math.Round(monthlySell, 3).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating Monthly Gross.  " + ex.ToString(), "Form Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateMonthlyNet()
        {
            try
            {
                monthlyProfit = monthlySell - monthlyExpenses;
                mainForm.MonthlyProfit = Math.Round(monthlyProfit, 3).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating Monthly Net.  " + ex.ToString(), "Form Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}