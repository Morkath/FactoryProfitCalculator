namespace FactoryProfitCalculator
{
    public partial class ProfitCalculatorForm : Form
    {
        public Program myProgram;

        public string Variant
        {
            get { return tb_variantName.Text; } 
            set { tb_variantName.Text = value; }
        }
        public decimal Tonnage
        { 
            get { return num_tonnage.Value; }
            set { num_tonnage.Value = value; } 
        }
        public decimal BFactory
        {
            get { return num_basicFactory.Value; }
            set { num_basicFactory.Value = value; }
        }
        public decimal CFactory
        {
            get { return num_componentFactory.Value; }
            set { num_componentFactory.Value = value; }
        }
        public int UnitType
        {
            get { return comb_unitType.SelectedIndex; }
            set { comb_unitType.SelectedIndex = value; }
        }
        public int TechLevel
        {
            get { return comb_techLevel.SelectedIndex; }
            set { comb_techLevel.SelectedIndex = value; }
        }
        public int FactoryType
        {
            get { return comb_factoryType.SelectedIndex; }
            set { comb_factoryType.SelectedIndex= value; }
        }
        public int RefitTechLevel
        {
            get { return comb_refitTechLevel.SelectedIndex; }
            set { comb_refitTechLevel.SelectedIndex = value; }
        }
        public int RefitType
        {
            get { return comb_refitType.SelectedIndex; }
            set { comb_refitType.SelectedIndex = value; }
        }
        public int SellTechLevel
        {
            get { return comb_sellTechLevel.SelectedIndex; }
            set { comb_sellTechLevel.SelectedIndex = value; }
        }
        public bool HandMake
        {
            get { return cb_handBuild.Checked; }
            set { cb_handBuild.Checked = value; }
        }
        public bool Refit
        {
            get { return cb_refit.Checked; }
            set { cb_refit.Checked = value; }
        }
        public bool Omni
        {
            get { return cb_omni.Checked; }
            set { cb_omni.Checked = value; }
        }
        public decimal Cost
        {
            get { return num_cost.Value; }
            set { num_cost.Value = value; }
        }
        public string HandMakeCost
        {
            get { return tb_handMakeCost.Text; }
            set { tb_handMakeCost.Text = value; }
        }
        public string ChassisCost
        {
            get { return tb_chassisCost.Text; }
            set { tb_chassisCost.Text = value; }
        }
        public string ModChassisCost
        {
            get { return tb_modChassisCost.Text; }
            set { tb_modChassisCost.Text = value; }
        }
        public string RefitCost
        {
            get { return tb_refitCost.Text; }
            set { tb_refitCost.Text = value; }
        }
        public string TotalCost
        {
            get { return tb_totalCost.Text; }
            set { tb_totalCost.Text = value; }
        }
        public string MonthlyCost
        {
            get { return tb_monthlyCost.Text; }
            set { tb_monthlyCost.Text = value; }
        }
        public string MonthlySell
        {
            get { return tb_monthlySell.Text; }
            set { tb_monthlySell.Text = value; }
        }
        public string MonthlyProfit
        {
            get { return tb_monthlyProfit.Text; }
            set { tb_monthlyProfit.Text = value; }
        }
        public string TechMulti
        {
            get { return tb_techMultiplier.Text; }
            set { tb_techMultiplier.Text = value; }
        }
        public string SellTechMulti
        {
            get { return tb_sellTechMulti.Text; }
            set { tb_sellTechMulti.Text = value; }
        }
        public string RefitTechMulti
        {
            get { return tb_refitTechMulti.Text; }
            set { tb_refitTechMulti.Text = value; }
        }
        public string RefitMulti
        {
            get { return tb_refitMulti .Text; }
            set { tb_refitMulti.Text = value; }
        }
        public string ProductionRate
        {
            get { return tb_productionRate.Text; }
            set { tb_productionRate.Text = value; }
        }
        public string RequiredTonnage
        {
            get { return tb_requiredTonnage.Text; }
            set { tb_requiredTonnage.Text = value; }
        }
        public string CostMultiplier
        {
            get { return tb_costMulti.Text; }
            set { tb_costMulti.Text = value; }
        }

        public bool update = true;

        public ProfitCalculatorForm(Program myClass)
        {
            myProgram = myClass;
            InitializeComponent();
        }

        public void UpdateFieldValues(Program myClass)
        {
            myProgram = myClass;
        }

        private void SetFieldValues()
        {
            UpdateTechField(myProgram.techLevels);
            UpdateTypeField(myProgram.unitTypes);
            UpdateFactoryField(myProgram.techLevels);
            UpdateRefitTechField(myProgram.techLevels);
            UpdateRefitTypeField(myProgram.refitTypes);
            UpdateSellTechLevelField(myProgram.techLevels);
        }

        public void SetInitialValues()
        {
            update = false;

            comb_techLevel.SelectedIndex = 0;
            comb_unitType.SelectedIndex = 0;
            comb_factoryType.SelectedIndex = 0;
            comb_refitTechLevel.SelectedIndex = 0;
            comb_refitType.SelectedIndex = 0;
            comb_sellTechLevel.SelectedIndex = 0;

            update = true;
        }
        private void factoryProfitCalc_Load(object sender, EventArgs e)
        {
            SetFieldValues();
            SetInitialValues();
            myProgram.UpdateValues();
        }

        private void factoryProfitCalc_Shown(object sender, EventArgs e)
        {

        }

        // Event Handlers
        private void cb_refit_Click(object sender, EventArgs e)
        {
            switch (cb_refit.CheckState)
            {
                case CheckState.Checked:
                    comb_refitTechLevel.Enabled = true;
                    comb_refitType.Enabled = true;
                    break;
                case CheckState.Unchecked:
                    comb_refitTechLevel.Enabled = false;
                    comb_refitType.Enabled = false;
                    break;
                case CheckState.Indeterminate:
                    break;
            }

            if (update)
            {
                myProgram.UpdateValues();
            }
        }

        private void num_tonnage_ValueChanged(object sender, EventArgs e)
        {
            if (update) { myProgram.UpdateValues(); };
        }
        private void num_componentFactory_ValueChanged(object sender, EventArgs e)
        {
            if (update) { myProgram.UpdateValues(); };
        }
        private void comb_unitType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (update) { myProgram.UpdateValues(); };
        }
        private void num_cost_ValueChanged(object sender, EventArgs e)
        {
            if (update) { myProgram.UpdateValues(); };
        }
        private void comb_factoryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (update) { myProgram.UpdateValues(); };
        }
        private void comb_refitTechLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (update) { myProgram.UpdateValues(); };
        }
        private void comb_refitType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (update) { myProgram.UpdateValues(); };
        }
        private void num_basicFactory_ValueChanged(object sender, EventArgs e)
        {
            if (update) { myProgram.UpdateValues(); };
        }
        private void comb_sellTechLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (update) { myProgram.UpdateValues(); };
        }
        private void comb_techLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (update) { myProgram.UpdateValues(); };
        }
        private void cb_handBuild_TextChanged(object sender, EventArgs e)
        {
            if (update) { myProgram.UpdateValues(); };
        }
        private void cb_handBuild_Click(object sender, EventArgs e)
        {
            if (update) { myProgram.UpdateValues(); };
        }
        private void cb_omni_CheckedChanged(object sender, EventArgs e)
        {
            if (update) { myProgram.UpdateValues(); };
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myProgram.SaveFactoryFile();
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myProgram.LoadFactoryFile();
        }
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myProgram.AboutDialog();
        }

        // Form Updates
        private void UpdateTechField(List<string> incomingList)
        {
            incomingList.ForEach(delegate(string s) { comb_techLevel.Items.Add(s); });
        }
        private void UpdateTypeField(List<string> incomingList)
        {
            incomingList.ForEach(delegate (string s) { comb_unitType.Items.Add(s); });
        }
        private void UpdateFactoryField(List<string> incomingList)
        {
            incomingList.ForEach(delegate (string s) { comb_factoryType.Items.Add(s); });
        }
        private void UpdateRefitTechField(List<string> incomingList)
        {
            incomingList.ForEach(delegate (string s) { comb_refitTechLevel.Items.Add(s); });
        }
        private void UpdateRefitTypeField(List<string> incomingList)
        {
            incomingList.ForEach(delegate (string s) { comb_refitType.Items.Add(s); });
        }
        private void UpdateSellTechLevelField(List<string> incomingList)
        {
            incomingList.ForEach(delegate (string s) { comb_sellTechLevel.Items.Add(s); });
        }

        // Not Used
        private void pan_main_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}