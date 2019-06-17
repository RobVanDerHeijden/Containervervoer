namespace ContainervervoerCasus
{
    partial class ContainervervoerCasus
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Lbl_Containers = new System.Windows.Forms.Label();
            this.Grbx_ContainerStats = new System.Windows.Forms.GroupBox();
            this.Lbl_TotalContainers = new System.Windows.Forms.Label();
            this.Lbl_TotalContainerWeight = new System.Windows.Forms.Label();
            this.Lbl_TotalCooled = new System.Windows.Forms.Label();
            this.Lbl_TotalRegular = new System.Windows.Forms.Label();
            this.Lbl_TotalValuable = new System.Windows.Forms.Label();
            this.Grbx_AddContainer = new System.Windows.Forms.GroupBox();
            this.Nud_RandomContainers = new System.Windows.Forms.NumericUpDown();
            this.Nud_ContainerWeight = new System.Windows.Forms.NumericUpDown();
            this.Btn_AddRandomContainers = new System.Windows.Forms.Button();
            this.Lbl_ContainerWeight = new System.Windows.Forms.Label();
            this.Lbl_ContainerType = new System.Windows.Forms.Label();
            this.Cbbx_ContainerType = new System.Windows.Forms.ComboBox();
            this.Btn_AddContainer = new System.Windows.Forms.Button();
            this.Btn_ResetContainers = new System.Windows.Forms.Button();
            this.Lbx_Containers = new System.Windows.Forms.ListBox();
            this.Lbl_CargoShip = new System.Windows.Forms.Label();
            this.Grbx_AddCargoShip = new System.Windows.Forms.GroupBox();
            this.Nud_CargoShipLength = new System.Windows.Forms.NumericUpDown();
            this.Nud_CargoShipWidth = new System.Windows.Forms.NumericUpDown();
            this.Lbl_CargoShipLength = new System.Windows.Forms.Label();
            this.Lbl_CargoShipWidth = new System.Windows.Forms.Label();
            this.Btn_AddCargoShip = new System.Windows.Forms.Button();
            this.Btn_ResetCargoShip = new System.Windows.Forms.Button();
            this.Lbx_CargoShips = new System.Windows.Forms.ListBox();
            this.Lbx_StackContainers = new System.Windows.Forms.ListBox();
            this.DGV_Stacks = new System.Windows.Forms.DataGridView();
            this.Btn_AddContainerToStack = new System.Windows.Forms.Button();
            this.Btn_SortContainers = new System.Windows.Forms.Button();
            this.Btn_Algorithm = new System.Windows.Forms.Button();
            this.Grbx_StackStats = new System.Windows.Forms.GroupBox();
            this.Lbl_StackWeight = new System.Windows.Forms.Label();
            this.Lbl_StackBalansPosition = new System.Windows.Forms.Label();
            this.Grbx_CargoShipStats = new System.Windows.Forms.GroupBox();
            this.Lbl_LeftSideWeight = new System.Windows.Forms.Label();
            this.Lbl_MiddleSideWeight = new System.Windows.Forms.Label();
            this.Lbl_RightSideWeight = new System.Windows.Forms.Label();
            this.Lbl_CargoShipCurrentWeight = new System.Windows.Forms.Label();
            this.Lbl_CargoShipMaxWeight = new System.Windows.Forms.Label();
            this.Grbx_ContainerStats.SuspendLayout();
            this.Grbx_AddContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_RandomContainers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_ContainerWeight)).BeginInit();
            this.Grbx_AddCargoShip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_CargoShipLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_CargoShipWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Stacks)).BeginInit();
            this.Grbx_StackStats.SuspendLayout();
            this.Grbx_CargoShipStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // Lbl_Containers
            // 
            this.Lbl_Containers.AutoSize = true;
            this.Lbl_Containers.Location = new System.Drawing.Point(416, 9);
            this.Lbl_Containers.Name = "Lbl_Containers";
            this.Lbl_Containers.Size = new System.Drawing.Size(76, 17);
            this.Lbl_Containers.TabIndex = 27;
            this.Lbl_Containers.Text = "Containers";
            // 
            // Grbx_ContainerStats
            // 
            this.Grbx_ContainerStats.Controls.Add(this.Lbl_TotalContainers);
            this.Grbx_ContainerStats.Controls.Add(this.Lbl_TotalContainerWeight);
            this.Grbx_ContainerStats.Controls.Add(this.Lbl_TotalCooled);
            this.Grbx_ContainerStats.Controls.Add(this.Lbl_TotalRegular);
            this.Grbx_ContainerStats.Controls.Add(this.Lbl_TotalValuable);
            this.Grbx_ContainerStats.Location = new System.Drawing.Point(419, 399);
            this.Grbx_ContainerStats.Name = "Grbx_ContainerStats";
            this.Grbx_ContainerStats.Size = new System.Drawing.Size(355, 118);
            this.Grbx_ContainerStats.TabIndex = 26;
            this.Grbx_ContainerStats.TabStop = false;
            this.Grbx_ContainerStats.Text = "Container Stats";
            // 
            // Lbl_TotalContainers
            // 
            this.Lbl_TotalContainers.AutoSize = true;
            this.Lbl_TotalContainers.Location = new System.Drawing.Point(4, 86);
            this.Lbl_TotalContainers.Name = "Lbl_TotalContainers";
            this.Lbl_TotalContainers.Size = new System.Drawing.Size(126, 17);
            this.Lbl_TotalContainers.TabIndex = 15;
            this.Lbl_TotalContainers.Text = "Total containers: 0";
            // 
            // Lbl_TotalContainerWeight
            // 
            this.Lbl_TotalContainerWeight.AutoSize = true;
            this.Lbl_TotalContainerWeight.Location = new System.Drawing.Point(4, 69);
            this.Lbl_TotalContainerWeight.Name = "Lbl_TotalContainerWeight";
            this.Lbl_TotalContainerWeight.Size = new System.Drawing.Size(188, 17);
            this.Lbl_TotalContainerWeight.TabIndex = 14;
            this.Lbl_TotalContainerWeight.Text = "Total weight all containers: 0";
            // 
            // Lbl_TotalCooled
            // 
            this.Lbl_TotalCooled.AutoSize = true;
            this.Lbl_TotalCooled.Location = new System.Drawing.Point(3, 52);
            this.Lbl_TotalCooled.Name = "Lbl_TotalCooled";
            this.Lbl_TotalCooled.Size = new System.Drawing.Size(104, 17);
            this.Lbl_TotalCooled.TabIndex = 13;
            this.Lbl_TotalCooled.Text = "Total Cooled: 0";
            // 
            // Lbl_TotalRegular
            // 
            this.Lbl_TotalRegular.AutoSize = true;
            this.Lbl_TotalRegular.Location = new System.Drawing.Point(3, 18);
            this.Lbl_TotalRegular.Name = "Lbl_TotalRegular";
            this.Lbl_TotalRegular.Size = new System.Drawing.Size(110, 17);
            this.Lbl_TotalRegular.TabIndex = 10;
            this.Lbl_TotalRegular.Text = "Total Regular: 0";
            // 
            // Lbl_TotalValuable
            // 
            this.Lbl_TotalValuable.AutoSize = true;
            this.Lbl_TotalValuable.Location = new System.Drawing.Point(3, 35);
            this.Lbl_TotalValuable.Name = "Lbl_TotalValuable";
            this.Lbl_TotalValuable.Size = new System.Drawing.Size(115, 17);
            this.Lbl_TotalValuable.TabIndex = 12;
            this.Lbl_TotalValuable.Text = "Total Valuable: 0";
            // 
            // Grbx_AddContainer
            // 
            this.Grbx_AddContainer.Controls.Add(this.Nud_RandomContainers);
            this.Grbx_AddContainer.Controls.Add(this.Nud_ContainerWeight);
            this.Grbx_AddContainer.Controls.Add(this.Btn_AddRandomContainers);
            this.Grbx_AddContainer.Controls.Add(this.Lbl_ContainerWeight);
            this.Grbx_AddContainer.Controls.Add(this.Lbl_ContainerType);
            this.Grbx_AddContainer.Controls.Add(this.Cbbx_ContainerType);
            this.Grbx_AddContainer.Controls.Add(this.Btn_AddContainer);
            this.Grbx_AddContainer.Location = new System.Drawing.Point(419, 199);
            this.Grbx_AddContainer.Name = "Grbx_AddContainer";
            this.Grbx_AddContainer.Size = new System.Drawing.Size(220, 194);
            this.Grbx_AddContainer.TabIndex = 25;
            this.Grbx_AddContainer.TabStop = false;
            this.Grbx_AddContainer.Text = "Add Container";
            // 
            // Nud_RandomContainers
            // 
            this.Nud_RandomContainers.Location = new System.Drawing.Point(6, 159);
            this.Nud_RandomContainers.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Nud_RandomContainers.Name = "Nud_RandomContainers";
            this.Nud_RandomContainers.Size = new System.Drawing.Size(57, 22);
            this.Nud_RandomContainers.TabIndex = 11;
            this.Nud_RandomContainers.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // Nud_ContainerWeight
            // 
            this.Nud_ContainerWeight.Location = new System.Drawing.Point(10, 85);
            this.Nud_ContainerWeight.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.Nud_ContainerWeight.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.Nud_ContainerWeight.Name = "Nud_ContainerWeight";
            this.Nud_ContainerWeight.Size = new System.Drawing.Size(200, 22);
            this.Nud_ContainerWeight.TabIndex = 10;
            this.Nud_ContainerWeight.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // Btn_AddRandomContainers
            // 
            this.Btn_AddRandomContainers.Location = new System.Drawing.Point(69, 153);
            this.Btn_AddRandomContainers.Name = "Btn_AddRandomContainers";
            this.Btn_AddRandomContainers.Size = new System.Drawing.Size(141, 33);
            this.Btn_AddRandomContainers.TabIndex = 11;
            this.Btn_AddRandomContainers.Text = "Random Containers";
            this.Btn_AddRandomContainers.UseVisualStyleBackColor = true;
            this.Btn_AddRandomContainers.Click += new System.EventHandler(this.Btn_AddRandomContainers_Click);
            // 
            // Lbl_ContainerWeight
            // 
            this.Lbl_ContainerWeight.AutoSize = true;
            this.Lbl_ContainerWeight.Location = new System.Drawing.Point(7, 65);
            this.Lbl_ContainerWeight.Name = "Lbl_ContainerWeight";
            this.Lbl_ContainerWeight.Size = new System.Drawing.Size(171, 17);
            this.Lbl_ContainerWeight.TabIndex = 9;
            this.Lbl_ContainerWeight.Text = "Container Weight (In Ton)";
            // 
            // Lbl_ContainerType
            // 
            this.Lbl_ContainerType.AutoSize = true;
            this.Lbl_ContainerType.Location = new System.Drawing.Point(7, 18);
            this.Lbl_ContainerType.Name = "Lbl_ContainerType";
            this.Lbl_ContainerType.Size = new System.Drawing.Size(105, 17);
            this.Lbl_ContainerType.TabIndex = 6;
            this.Lbl_ContainerType.Text = "Container Type";
            // 
            // Cbbx_ContainerType
            // 
            this.Cbbx_ContainerType.FormattingEnabled = true;
            this.Cbbx_ContainerType.Location = new System.Drawing.Point(10, 36);
            this.Cbbx_ContainerType.Name = "Cbbx_ContainerType";
            this.Cbbx_ContainerType.Size = new System.Drawing.Size(200, 24);
            this.Cbbx_ContainerType.TabIndex = 7;
            // 
            // Btn_AddContainer
            // 
            this.Btn_AddContainer.Location = new System.Drawing.Point(6, 113);
            this.Btn_AddContainer.Name = "Btn_AddContainer";
            this.Btn_AddContainer.Size = new System.Drawing.Size(204, 33);
            this.Btn_AddContainer.TabIndex = 8;
            this.Btn_AddContainer.Text = "Add Container";
            this.Btn_AddContainer.UseVisualStyleBackColor = true;
            this.Btn_AddContainer.Click += new System.EventHandler(this.Btn_AddContainer_Click);
            // 
            // Btn_ResetContainers
            // 
            this.Btn_ResetContainers.BackColor = System.Drawing.SystemColors.Control;
            this.Btn_ResetContainers.Location = new System.Drawing.Point(419, 151);
            this.Btn_ResetContainers.Name = "Btn_ResetContainers";
            this.Btn_ResetContainers.Size = new System.Drawing.Size(220, 30);
            this.Btn_ResetContainers.TabIndex = 32;
            this.Btn_ResetContainers.Text = "Reset Containers";
            this.Btn_ResetContainers.UseVisualStyleBackColor = false;
            this.Btn_ResetContainers.Click += new System.EventHandler(this.Btn_ResetContainers_Click);
            // 
            // Lbx_Containers
            // 
            this.Lbx_Containers.FormattingEnabled = true;
            this.Lbx_Containers.ItemHeight = 16;
            this.Lbx_Containers.Location = new System.Drawing.Point(419, 29);
            this.Lbx_Containers.Name = "Lbx_Containers";
            this.Lbx_Containers.Size = new System.Drawing.Size(220, 116);
            this.Lbx_Containers.TabIndex = 23;
            // 
            // Lbl_CargoShip
            // 
            this.Lbl_CargoShip.AutoSize = true;
            this.Lbl_CargoShip.Location = new System.Drawing.Point(12, 9);
            this.Lbl_CargoShip.Name = "Lbl_CargoShip";
            this.Lbl_CargoShip.Size = new System.Drawing.Size(74, 17);
            this.Lbl_CargoShip.TabIndex = 36;
            this.Lbl_CargoShip.Text = "CargoShip";
            // 
            // Grbx_AddCargoShip
            // 
            this.Grbx_AddCargoShip.Controls.Add(this.Nud_CargoShipLength);
            this.Grbx_AddCargoShip.Controls.Add(this.Nud_CargoShipWidth);
            this.Grbx_AddCargoShip.Controls.Add(this.Lbl_CargoShipLength);
            this.Grbx_AddCargoShip.Controls.Add(this.Lbl_CargoShipWidth);
            this.Grbx_AddCargoShip.Controls.Add(this.Btn_AddCargoShip);
            this.Grbx_AddCargoShip.Location = new System.Drawing.Point(15, 199);
            this.Grbx_AddCargoShip.Name = "Grbx_AddCargoShip";
            this.Grbx_AddCargoShip.Size = new System.Drawing.Size(395, 194);
            this.Grbx_AddCargoShip.TabIndex = 34;
            this.Grbx_AddCargoShip.TabStop = false;
            this.Grbx_AddCargoShip.Text = "Add CargoShip";
            // 
            // Nud_CargoShipLength
            // 
            this.Nud_CargoShipLength.Location = new System.Drawing.Point(192, 61);
            this.Nud_CargoShipLength.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.Nud_CargoShipLength.Name = "Nud_CargoShipLength";
            this.Nud_CargoShipLength.Size = new System.Drawing.Size(186, 22);
            this.Nud_CargoShipLength.TabIndex = 12;
            this.Nud_CargoShipLength.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // Nud_CargoShipWidth
            // 
            this.Nud_CargoShipWidth.Location = new System.Drawing.Point(192, 27);
            this.Nud_CargoShipWidth.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.Nud_CargoShipWidth.Name = "Nud_CargoShipWidth";
            this.Nud_CargoShipWidth.Size = new System.Drawing.Size(186, 22);
            this.Nud_CargoShipWidth.TabIndex = 11;
            this.Nud_CargoShipWidth.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // Lbl_CargoShipLength
            // 
            this.Lbl_CargoShipLength.AutoSize = true;
            this.Lbl_CargoShipLength.Location = new System.Drawing.Point(6, 61);
            this.Lbl_CargoShipLength.Name = "Lbl_CargoShipLength";
            this.Lbl_CargoShipLength.Size = new System.Drawing.Size(100, 17);
            this.Lbl_CargoShipLength.TabIndex = 10;
            this.Lbl_CargoShipLength.Text = "Length (Rows)";
            // 
            // Lbl_CargoShipWidth
            // 
            this.Lbl_CargoShipWidth.AutoSize = true;
            this.Lbl_CargoShipWidth.Location = new System.Drawing.Point(6, 27);
            this.Lbl_CargoShipWidth.Name = "Lbl_CargoShipWidth";
            this.Lbl_CargoShipWidth.Size = new System.Drawing.Size(112, 17);
            this.Lbl_CargoShipWidth.TabIndex = 6;
            this.Lbl_CargoShipWidth.Text = "Width (Columns)";
            // 
            // Btn_AddCargoShip
            // 
            this.Btn_AddCargoShip.Location = new System.Drawing.Point(192, 91);
            this.Btn_AddCargoShip.Name = "Btn_AddCargoShip";
            this.Btn_AddCargoShip.Size = new System.Drawing.Size(186, 50);
            this.Btn_AddCargoShip.TabIndex = 8;
            this.Btn_AddCargoShip.Text = "Add CargoShip";
            this.Btn_AddCargoShip.UseVisualStyleBackColor = true;
            this.Btn_AddCargoShip.Click += new System.EventHandler(this.Btn_AddCargoShip_Click);
            // 
            // Btn_ResetCargoShip
            // 
            this.Btn_ResetCargoShip.BackColor = System.Drawing.SystemColors.Control;
            this.Btn_ResetCargoShip.Location = new System.Drawing.Point(15, 151);
            this.Btn_ResetCargoShip.Name = "Btn_ResetCargoShip";
            this.Btn_ResetCargoShip.Size = new System.Drawing.Size(395, 30);
            this.Btn_ResetCargoShip.TabIndex = 37;
            this.Btn_ResetCargoShip.Text = "Reset CargoShip";
            this.Btn_ResetCargoShip.UseVisualStyleBackColor = false;
            this.Btn_ResetCargoShip.Click += new System.EventHandler(this.Btn_ResetCargoShip_Click);
            // 
            // Lbx_CargoShips
            // 
            this.Lbx_CargoShips.FormattingEnabled = true;
            this.Lbx_CargoShips.ItemHeight = 16;
            this.Lbx_CargoShips.Location = new System.Drawing.Point(15, 29);
            this.Lbx_CargoShips.Name = "Lbx_CargoShips";
            this.Lbx_CargoShips.Size = new System.Drawing.Size(395, 116);
            this.Lbx_CargoShips.TabIndex = 33;
            this.Lbx_CargoShips.SelectedIndexChanged += new System.EventHandler(this.Lbx_CargoShips_SelectedIndexChanged);
            // 
            // Lbx_StackContainers
            // 
            this.Lbx_StackContainers.FormattingEnabled = true;
            this.Lbx_StackContainers.ItemHeight = 16;
            this.Lbx_StackContainers.Location = new System.Drawing.Point(1100, 399);
            this.Lbx_StackContainers.Name = "Lbx_StackContainers";
            this.Lbx_StackContainers.Size = new System.Drawing.Size(302, 116);
            this.Lbx_StackContainers.TabIndex = 38;
            // 
            // DGV_Stacks
            // 
            this.DGV_Stacks.AllowUserToAddRows = false;
            this.DGV_Stacks.AllowUserToDeleteRows = false;
            this.DGV_Stacks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Stacks.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DGV_Stacks.Location = new System.Drawing.Point(780, 27);
            this.DGV_Stacks.Name = "DGV_Stacks";
            this.DGV_Stacks.ReadOnly = true;
            this.DGV_Stacks.RowHeadersVisible = false;
            this.DGV_Stacks.RowTemplate.Height = 24;
            this.DGV_Stacks.ShowCellToolTips = false;
            this.DGV_Stacks.ShowEditingIcon = false;
            this.DGV_Stacks.Size = new System.Drawing.Size(622, 366);
            this.DGV_Stacks.TabIndex = 39;
            this.DGV_Stacks.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Stacks_CellContentClick);
            // 
            // Btn_AddContainerToStack
            // 
            this.Btn_AddContainerToStack.Location = new System.Drawing.Point(645, 29);
            this.Btn_AddContainerToStack.Name = "Btn_AddContainerToStack";
            this.Btn_AddContainerToStack.Size = new System.Drawing.Size(129, 116);
            this.Btn_AddContainerToStack.TabIndex = 13;
            this.Btn_AddContainerToStack.Text = "Add Selected Container To Stack";
            this.Btn_AddContainerToStack.UseVisualStyleBackColor = true;
            this.Btn_AddContainerToStack.Click += new System.EventHandler(this.Btn_AddContainerToStack_Click);
            // 
            // Btn_SortContainers
            // 
            this.Btn_SortContainers.Location = new System.Drawing.Point(645, 151);
            this.Btn_SortContainers.Name = "Btn_SortContainers";
            this.Btn_SortContainers.Size = new System.Drawing.Size(129, 116);
            this.Btn_SortContainers.TabIndex = 40;
            this.Btn_SortContainers.Text = "SortContainers";
            this.Btn_SortContainers.UseVisualStyleBackColor = true;
            this.Btn_SortContainers.Click += new System.EventHandler(this.Btn_SortContainers_Click);
            // 
            // Btn_Algorithm
            // 
            this.Btn_Algorithm.Location = new System.Drawing.Point(645, 273);
            this.Btn_Algorithm.Name = "Btn_Algorithm";
            this.Btn_Algorithm.Size = new System.Drawing.Size(129, 116);
            this.Btn_Algorithm.TabIndex = 41;
            this.Btn_Algorithm.Text = "Algorithm";
            this.Btn_Algorithm.UseVisualStyleBackColor = true;
            this.Btn_Algorithm.Click += new System.EventHandler(this.Btn_Algorithm_Click);
            // 
            // Grbx_StackStats
            // 
            this.Grbx_StackStats.Controls.Add(this.Lbl_StackWeight);
            this.Grbx_StackStats.Controls.Add(this.Lbl_StackBalansPosition);
            this.Grbx_StackStats.Location = new System.Drawing.Point(780, 399);
            this.Grbx_StackStats.Name = "Grbx_StackStats";
            this.Grbx_StackStats.Size = new System.Drawing.Size(314, 118);
            this.Grbx_StackStats.TabIndex = 27;
            this.Grbx_StackStats.TabStop = false;
            this.Grbx_StackStats.Text = "Stack Stats";
            // 
            // Lbl_StackWeight
            // 
            this.Lbl_StackWeight.AutoSize = true;
            this.Lbl_StackWeight.Location = new System.Drawing.Point(3, 18);
            this.Lbl_StackWeight.Name = "Lbl_StackWeight";
            this.Lbl_StackWeight.Size = new System.Drawing.Size(107, 17);
            this.Lbl_StackWeight.TabIndex = 10;
            this.Lbl_StackWeight.Text = "Stack Weight: 0";
            // 
            // Lbl_StackBalansPosition
            // 
            this.Lbl_StackBalansPosition.AutoSize = true;
            this.Lbl_StackBalansPosition.Location = new System.Drawing.Point(3, 35);
            this.Lbl_StackBalansPosition.Name = "Lbl_StackBalansPosition";
            this.Lbl_StackBalansPosition.Size = new System.Drawing.Size(52, 17);
            this.Lbl_StackBalansPosition.TabIndex = 12;
            this.Lbl_StackBalansPosition.Text = "Side: 0";
            // 
            // Grbx_CargoShipStats
            // 
            this.Grbx_CargoShipStats.Controls.Add(this.Lbl_CargoShipMaxWeight);
            this.Grbx_CargoShipStats.Controls.Add(this.Lbl_CargoShipCurrentWeight);
            this.Grbx_CargoShipStats.Controls.Add(this.Lbl_RightSideWeight);
            this.Grbx_CargoShipStats.Controls.Add(this.Lbl_LeftSideWeight);
            this.Grbx_CargoShipStats.Controls.Add(this.Lbl_MiddleSideWeight);
            this.Grbx_CargoShipStats.Location = new System.Drawing.Point(15, 399);
            this.Grbx_CargoShipStats.Name = "Grbx_CargoShipStats";
            this.Grbx_CargoShipStats.Size = new System.Drawing.Size(402, 118);
            this.Grbx_CargoShipStats.TabIndex = 28;
            this.Grbx_CargoShipStats.TabStop = false;
            this.Grbx_CargoShipStats.Text = "CargoShip Stats";
            // 
            // Lbl_LeftSideWeight
            // 
            this.Lbl_LeftSideWeight.AutoSize = true;
            this.Lbl_LeftSideWeight.Location = new System.Drawing.Point(3, 18);
            this.Lbl_LeftSideWeight.Name = "Lbl_LeftSideWeight";
            this.Lbl_LeftSideWeight.Size = new System.Drawing.Size(96, 17);
            this.Lbl_LeftSideWeight.TabIndex = 10;
            this.Lbl_LeftSideWeight.Text = "Left Weight: 0";
            // 
            // Lbl_MiddleSideWeight
            // 
            this.Lbl_MiddleSideWeight.AutoSize = true;
            this.Lbl_MiddleSideWeight.Location = new System.Drawing.Point(124, 18);
            this.Lbl_MiddleSideWeight.Name = "Lbl_MiddleSideWeight";
            this.Lbl_MiddleSideWeight.Size = new System.Drawing.Size(113, 17);
            this.Lbl_MiddleSideWeight.TabIndex = 12;
            this.Lbl_MiddleSideWeight.Text = "Middle Weight: 0";
            // 
            // Lbl_RightSideWeight
            // 
            this.Lbl_RightSideWeight.AutoSize = true;
            this.Lbl_RightSideWeight.Location = new System.Drawing.Point(255, 18);
            this.Lbl_RightSideWeight.Name = "Lbl_RightSideWeight";
            this.Lbl_RightSideWeight.Size = new System.Drawing.Size(105, 17);
            this.Lbl_RightSideWeight.TabIndex = 13;
            this.Lbl_RightSideWeight.Text = "Right Weight: 0";
            // 
            // Lbl_CargoShipCurrentWeight
            // 
            this.Lbl_CargoShipCurrentWeight.AutoSize = true;
            this.Lbl_CargoShipCurrentWeight.Location = new System.Drawing.Point(38, 52);
            this.Lbl_CargoShipCurrentWeight.Name = "Lbl_CargoShipCurrentWeight";
            this.Lbl_CargoShipCurrentWeight.Size = new System.Drawing.Size(119, 17);
            this.Lbl_CargoShipCurrentWeight.TabIndex = 14;
            this.Lbl_CargoShipCurrentWeight.Text = "Current Weight: 0";
            // 
            // Lbl_CargoShipMaxWeight
            // 
            this.Lbl_CargoShipMaxWeight.AutoSize = true;
            this.Lbl_CargoShipMaxWeight.Location = new System.Drawing.Point(189, 52);
            this.Lbl_CargoShipMaxWeight.Name = "Lbl_CargoShipMaxWeight";
            this.Lbl_CargoShipMaxWeight.Size = new System.Drawing.Size(97, 17);
            this.Lbl_CargoShipMaxWeight.TabIndex = 15;
            this.Lbl_CargoShipMaxWeight.Text = "Max Weight: 0";
            // 
            // ContainervervoerCasus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1414, 602);
            this.Controls.Add(this.Grbx_CargoShipStats);
            this.Controls.Add(this.Grbx_StackStats);
            this.Controls.Add(this.Lbx_StackContainers);
            this.Controls.Add(this.Btn_Algorithm);
            this.Controls.Add(this.Btn_SortContainers);
            this.Controls.Add(this.Btn_AddContainerToStack);
            this.Controls.Add(this.DGV_Stacks);
            this.Controls.Add(this.Lbl_CargoShip);
            this.Controls.Add(this.Grbx_AddCargoShip);
            this.Controls.Add(this.Btn_ResetCargoShip);
            this.Controls.Add(this.Lbx_CargoShips);
            this.Controls.Add(this.Lbl_Containers);
            this.Controls.Add(this.Grbx_ContainerStats);
            this.Controls.Add(this.Grbx_AddContainer);
            this.Controls.Add(this.Btn_ResetContainers);
            this.Controls.Add(this.Lbx_Containers);
            this.Name = "ContainervervoerCasus";
            this.Text = "Containervervoer";
            this.Load += new System.EventHandler(this.ContainervervoerCasus_Load);
            this.Grbx_ContainerStats.ResumeLayout(false);
            this.Grbx_ContainerStats.PerformLayout();
            this.Grbx_AddContainer.ResumeLayout(false);
            this.Grbx_AddContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_RandomContainers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_ContainerWeight)).EndInit();
            this.Grbx_AddCargoShip.ResumeLayout(false);
            this.Grbx_AddCargoShip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_CargoShipLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_CargoShipWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Stacks)).EndInit();
            this.Grbx_StackStats.ResumeLayout(false);
            this.Grbx_StackStats.PerformLayout();
            this.Grbx_CargoShipStats.ResumeLayout(false);
            this.Grbx_CargoShipStats.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Lbl_Containers;
        private System.Windows.Forms.GroupBox Grbx_ContainerStats;
        private System.Windows.Forms.Label Lbl_TotalRegular;
        private System.Windows.Forms.Label Lbl_TotalValuable;
        private System.Windows.Forms.GroupBox Grbx_AddContainer;
        private System.Windows.Forms.ComboBox Cbbx_ContainerType;
        private System.Windows.Forms.Button Btn_AddContainer;
        private System.Windows.Forms.Button Btn_ResetContainers;
        private System.Windows.Forms.ListBox Lbx_Containers;
        private System.Windows.Forms.Label Lbl_TotalCooled;
        private System.Windows.Forms.NumericUpDown Nud_ContainerWeight;
        private System.Windows.Forms.Label Lbl_ContainerWeight;
        private System.Windows.Forms.Label Lbl_TotalContainerWeight;
        private System.Windows.Forms.Label Lbl_ContainerType;
        private System.Windows.Forms.Label Lbl_CargoShip;
        private System.Windows.Forms.GroupBox Grbx_AddCargoShip;
        private System.Windows.Forms.Label Lbl_CargoShipWidth;
        private System.Windows.Forms.Button Btn_AddCargoShip;
        private System.Windows.Forms.Button Btn_ResetCargoShip;
        private System.Windows.Forms.ListBox Lbx_CargoShips;
        private System.Windows.Forms.Label Lbl_CargoShipLength;
        private System.Windows.Forms.NumericUpDown Nud_CargoShipLength;
        private System.Windows.Forms.NumericUpDown Nud_CargoShipWidth;
        private System.Windows.Forms.ListBox Lbx_StackContainers;
        private System.Windows.Forms.DataGridView DGV_Stacks;
        private System.Windows.Forms.Button Btn_AddContainerToStack;
        private System.Windows.Forms.Button Btn_AddRandomContainers;
        private System.Windows.Forms.NumericUpDown Nud_RandomContainers;
        private System.Windows.Forms.Label Lbl_TotalContainers;
        private System.Windows.Forms.Button Btn_SortContainers;
        private System.Windows.Forms.Button Btn_Algorithm;
        private System.Windows.Forms.GroupBox Grbx_StackStats;
        private System.Windows.Forms.Label Lbl_StackWeight;
        private System.Windows.Forms.Label Lbl_StackBalansPosition;
        private System.Windows.Forms.GroupBox Grbx_CargoShipStats;
        private System.Windows.Forms.Label Lbl_LeftSideWeight;
        private System.Windows.Forms.Label Lbl_MiddleSideWeight;
        private System.Windows.Forms.Label Lbl_RightSideWeight;
        private System.Windows.Forms.Label Lbl_CargoShipMaxWeight;
        private System.Windows.Forms.Label Lbl_CargoShipCurrentWeight;
    }
}

