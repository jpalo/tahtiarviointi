namespace com.jussipalo.tahti
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.txtTapahtumaSarja = new System.Windows.Forms.TextBox();
            this.txtAikaPaikka = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvSkaters = new System.Windows.Forms.DataGridView();
            this.Order = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nimi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.txtMention = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtDressDeduction = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTimeDeduction = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSpiralDeduction = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dgvSkaterPoints = new System.Windows.Forms.DataGridView();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tuomari1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tuomari2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tuomari3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label9 = new System.Windows.Forms.Label();
            this.ddlSkaters = new System.Windows.Forms.ComboBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnOpenResultFile = new System.Windows.Forms.Button();
            this.btnSaveOutputFiles = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAllFoundSkaters = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnOletusarvot = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTemplateBoysBasic = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTemplateGirlsBasic = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTemplateBoysExtended = new System.Windows.Forms.TextBox();
            this.btnOutputFolder = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOutputFolder = new System.Windows.Forms.TextBox();
            this.btnSelectTemplate = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTemplateGirlsExtended = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.ddlTulospohja = new System.Windows.Forms.ComboBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLink = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tiedostoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.avaaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tallennaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.suljeSovellusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSkaters)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSkaterPoints)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tapahtuma ja sarja";
            // 
            // txtTapahtumaSarja
            // 
            this.txtTapahtumaSarja.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTapahtumaSarja.Location = new System.Drawing.Point(11, 44);
            this.txtTapahtumaSarja.Margin = new System.Windows.Forms.Padding(2);
            this.txtTapahtumaSarja.Name = "txtTapahtumaSarja";
            this.txtTapahtumaSarja.Size = new System.Drawing.Size(654, 20);
            this.txtTapahtumaSarja.TabIndex = 3;
            this.txtTapahtumaSarja.TextChanged += new System.EventHandler(this.txtTapahtumaSarja_TextChanged);
            // 
            // txtAikaPaikka
            // 
            this.txtAikaPaikka.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAikaPaikka.Location = new System.Drawing.Point(11, 85);
            this.txtAikaPaikka.Margin = new System.Windows.Forms.Padding(2);
            this.txtAikaPaikka.Name = "txtAikaPaikka";
            this.txtAikaPaikka.Size = new System.Drawing.Size(654, 20);
            this.txtAikaPaikka.TabIndex = 5;
            this.txtAikaPaikka.TextChanged += new System.EventHandler(this.txtAikaPaikka_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Aika ja paikka";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Controls.Add(this.tabPage4);
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Location = new System.Drawing.Point(11, 161);
            this.tabControl.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(656, 523);
            this.tabControl.TabIndex = 8;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgvSkaters);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(648, 497);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Kilpailijat";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvSkaters
            // 
            this.dgvSkaters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSkaters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Order,
            this.Nimi,
            this.Seura});
            this.dgvSkaters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSkaters.Location = new System.Drawing.Point(0, 0);
            this.dgvSkaters.Margin = new System.Windows.Forms.Padding(2);
            this.dgvSkaters.MultiSelect = false;
            this.dgvSkaters.Name = "dgvSkaters";
            this.dgvSkaters.RowTemplate.Height = 28;
            this.dgvSkaters.Size = new System.Drawing.Size(648, 497);
            this.dgvSkaters.TabIndex = 0;
            this.dgvSkaters.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvSkaters_CellValidating);
            this.dgvSkaters.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvSkaters_EditingControlShowing);
            this.dgvSkaters.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvSkaters_RowValidating);
            this.dgvSkaters.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvSkaters_UserDeletingRow);
            // 
            // Order
            // 
            this.Order.Frozen = true;
            this.Order.HeaderText = "Järjestys";
            this.Order.MinimumWidth = 50;
            this.Order.Name = "Order";
            this.Order.Width = 50;
            // 
            // Nimi
            // 
            this.Nimi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Nimi.Frozen = true;
            this.Nimi.HeaderText = "Nimi";
            this.Nimi.MinimumWidth = 160;
            this.Nimi.Name = "Nimi";
            this.Nimi.Width = 160;
            // 
            // Seura
            // 
            this.Seura.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Seura.Frozen = true;
            this.Seura.HeaderText = "Seura";
            this.Seura.MinimumWidth = 160;
            this.Seura.Name = "Seura";
            this.Seura.Width = 160;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.txtMention);
            this.tabPage4.Controls.Add(this.label14);
            this.tabPage4.Controls.Add(this.txtDressDeduction);
            this.tabPage4.Controls.Add(this.label13);
            this.tabPage4.Controls.Add(this.txtTimeDeduction);
            this.tabPage4.Controls.Add(this.label12);
            this.tabPage4.Controls.Add(this.txtSpiralDeduction);
            this.tabPage4.Controls.Add(this.label10);
            this.tabPage4.Controls.Add(this.dgvSkaterPoints);
            this.tabPage4.Controls.Add(this.label9);
            this.tabPage4.Controls.Add(this.ddlSkaters);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(648, 497);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Pisteet";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // txtMention
            // 
            this.txtMention.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMention.Location = new System.Drawing.Point(560, 177);
            this.txtMention.Margin = new System.Windows.Forms.Padding(2);
            this.txtMention.Multiline = true;
            this.txtMention.Name = "txtMention";
            this.txtMention.Size = new System.Drawing.Size(83, 104);
            this.txtMention.TabIndex = 10;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(558, 162);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 13);
            this.label14.TabIndex = 9;
            this.label14.Text = "Erikoismaininta";
            // 
            // txtDressDeduction
            // 
            this.txtDressDeduction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDressDeduction.Location = new System.Drawing.Point(560, 135);
            this.txtDressDeduction.Margin = new System.Windows.Forms.Padding(2);
            this.txtDressDeduction.Name = "txtDressDeduction";
            this.txtDressDeduction.Size = new System.Drawing.Size(75, 20);
            this.txtDressDeduction.TabIndex = 8;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(558, 120);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 13);
            this.label13.TabIndex = 7;
            this.label13.Text = "Pukuvähennys";
            // 
            // txtTimeDeduction
            // 
            this.txtTimeDeduction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimeDeduction.Location = new System.Drawing.Point(560, 94);
            this.txtTimeDeduction.Margin = new System.Windows.Forms.Padding(2);
            this.txtTimeDeduction.Name = "txtTimeDeduction";
            this.txtTimeDeduction.Size = new System.Drawing.Size(76, 20);
            this.txtTimeDeduction.TabIndex = 6;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(558, 79);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "Aikavähennys";
            // 
            // txtSpiralDeduction
            // 
            this.txtSpiralDeduction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSpiralDeduction.Location = new System.Drawing.Point(560, 53);
            this.txtSpiralDeduction.Margin = new System.Windows.Forms.Padding(2);
            this.txtSpiralDeduction.Name = "txtSpiralDeduction";
            this.txtSpiralDeduction.Size = new System.Drawing.Size(76, 20);
            this.txtSpiralDeduction.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(558, 38);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Liukuvähennys";
            // 
            // dgvSkaterPoints
            // 
            this.dgvSkaterPoints.AllowUserToAddRows = false;
            this.dgvSkaterPoints.AllowUserToDeleteRows = false;
            this.dgvSkaterPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSkaterPoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSkaterPoints.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Type,
            this.Tuomari1,
            this.Tuomari2,
            this.Tuomari3});
            this.dgvSkaterPoints.Location = new System.Drawing.Point(2, 38);
            this.dgvSkaterPoints.Margin = new System.Windows.Forms.Padding(2);
            this.dgvSkaterPoints.MultiSelect = false;
            this.dgvSkaterPoints.Name = "dgvSkaterPoints";
            this.dgvSkaterPoints.RowTemplate.Height = 28;
            this.dgvSkaterPoints.Size = new System.Drawing.Size(544, 343);
            this.dgvSkaterPoints.TabIndex = 2;
            this.dgvSkaterPoints.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvSkaterPoints_CellValidating);
            // 
            // Type
            // 
            this.Type.HeaderText = "";
            this.Type.MinimumWidth = 200;
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Type.Width = 200;
            // 
            // Tuomari1
            // 
            this.Tuomari1.HeaderText = "Tuomari 1";
            this.Tuomari1.Name = "Tuomari1";
            this.Tuomari1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Tuomari2
            // 
            this.Tuomari2.HeaderText = "Tuomari 2";
            this.Tuomari2.Name = "Tuomari2";
            this.Tuomari2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Tuomari3
            // 
            this.Tuomari3.HeaderText = "Tuomari 3";
            this.Tuomari3.Name = "Tuomari3";
            this.Tuomari3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 8);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Kilpailija";
            // 
            // ddlSkaters
            // 
            this.ddlSkaters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSkaters.FormattingEnabled = true;
            this.ddlSkaters.Location = new System.Drawing.Point(49, 6);
            this.ddlSkaters.Margin = new System.Windows.Forms.Padding(2);
            this.ddlSkaters.Name = "ddlSkaters";
            this.ddlSkaters.Size = new System.Drawing.Size(217, 21);
            this.ddlSkaters.TabIndex = 0;
            this.ddlSkaters.SelectionChangeCommitted += new System.EventHandler(this.ddlSkaters_SelectionChangeCommitted);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnOpenResultFile);
            this.tabPage1.Controls.Add(this.btnSaveOutputFiles);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtAllFoundSkaters);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(648, 497);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tulokset";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnOpenResultFile
            // 
            this.btnOpenResultFile.Enabled = false;
            this.btnOpenResultFile.Location = new System.Drawing.Point(235, 142);
            this.btnOpenResultFile.Margin = new System.Windows.Forms.Padding(2);
            this.btnOpenResultFile.Name = "btnOpenResultFile";
            this.btnOpenResultFile.Size = new System.Drawing.Size(117, 22);
            this.btnOpenResultFile.TabIndex = 19;
            this.btnOpenResultFile.Text = "Avaa tulostiedosto";
            this.btnOpenResultFile.UseVisualStyleBackColor = true;
            this.btnOpenResultFile.Click += new System.EventHandler(this.btnOpenResultFile_Click);
            // 
            // btnSaveOutputFiles
            // 
            this.btnSaveOutputFiles.Enabled = false;
            this.btnSaveOutputFiles.Location = new System.Drawing.Point(235, 99);
            this.btnSaveOutputFiles.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveOutputFiles.Name = "btnSaveOutputFiles";
            this.btnSaveOutputFiles.Size = new System.Drawing.Size(117, 22);
            this.btnSaveOutputFiles.TabIndex = 19;
            this.btnSaveOutputFiles.Text = "Luo tulostiedosto";
            this.btnSaveOutputFiles.UseVisualStyleBackColor = true;
            this.btnSaveOutputFiles.Click += new System.EventHandler(this.btnSaveOutputFiles_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 2);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Kilpailijat pistejärjestyksessä";
            // 
            // txtAllFoundSkaters
            // 
            this.txtAllFoundSkaters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAllFoundSkaters.Location = new System.Drawing.Point(4, 17);
            this.txtAllFoundSkaters.Margin = new System.Windows.Forms.Padding(2);
            this.txtAllFoundSkaters.Multiline = true;
            this.txtAllFoundSkaters.Name = "txtAllFoundSkaters";
            this.txtAllFoundSkaters.Size = new System.Drawing.Size(159, 179);
            this.txtAllFoundSkaters.TabIndex = 17;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnOletusarvot);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.txtTemplateBoysBasic);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.txtTemplateGirlsBasic);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.txtTemplateBoysExtended);
            this.tabPage2.Controls.Add(this.btnOutputFolder);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.txtOutputFolder);
            this.tabPage2.Controls.Add(this.btnSelectTemplate);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.txtTemplateGirlsExtended);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(648, 497);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Asetukset";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnOletusarvot
            // 
            this.btnOletusarvot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOletusarvot.Location = new System.Drawing.Point(284, 249);
            this.btnOletusarvot.Margin = new System.Windows.Forms.Padding(2);
            this.btnOletusarvot.Name = "btnOletusarvot";
            this.btnOletusarvot.Size = new System.Drawing.Size(128, 22);
            this.btnOletusarvot.TabIndex = 11;
            this.btnOletusarvot.Text = "Palauta oletusarvot";
            this.btnOletusarvot.UseVisualStyleBackColor = true;
            this.btnOletusarvot.Click += new System.EventHandler(this.btnOletusarvot_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(359, 148);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(53, 22);
            this.button3.TabIndex = 8;
            this.button3.Text = "Vaihda";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 134);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "Tulospohja suppea pojat";
            // 
            // txtTemplateBoysBasic
            // 
            this.txtTemplateBoysBasic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTemplateBoysBasic.Location = new System.Drawing.Point(7, 149);
            this.txtTemplateBoysBasic.Margin = new System.Windows.Forms.Padding(2);
            this.txtTemplateBoysBasic.Name = "txtTemplateBoysBasic";
            this.txtTemplateBoysBasic.Size = new System.Drawing.Size(349, 20);
            this.txtTemplateBoysBasic.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(359, 103);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(53, 22);
            this.button2.TabIndex = 6;
            this.button2.Text = "Vaihda";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 90);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Tulospohja suppea tytöt";
            // 
            // txtTemplateGirlsBasic
            // 
            this.txtTemplateGirlsBasic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTemplateGirlsBasic.Location = new System.Drawing.Point(7, 104);
            this.txtTemplateGirlsBasic.Margin = new System.Windows.Forms.Padding(2);
            this.txtTemplateGirlsBasic.Name = "txtTemplateGirlsBasic";
            this.txtTemplateGirlsBasic.Size = new System.Drawing.Size(349, 20);
            this.txtTemplateGirlsBasic.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(359, 60);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 22);
            this.button1.TabIndex = 4;
            this.button1.Text = "Vaihda";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 46);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Tulospohja laaja pojat";
            // 
            // txtTemplateBoysExtended
            // 
            this.txtTemplateBoysExtended.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTemplateBoysExtended.Location = new System.Drawing.Point(7, 61);
            this.txtTemplateBoysExtended.Margin = new System.Windows.Forms.Padding(2);
            this.txtTemplateBoysExtended.Name = "txtTemplateBoysExtended";
            this.txtTemplateBoysExtended.Size = new System.Drawing.Size(349, 20);
            this.txtTemplateBoysExtended.TabIndex = 3;
            // 
            // btnOutputFolder
            // 
            this.btnOutputFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOutputFolder.Location = new System.Drawing.Point(359, 191);
            this.btnOutputFolder.Margin = new System.Windows.Forms.Padding(2);
            this.btnOutputFolder.Name = "btnOutputFolder";
            this.btnOutputFolder.Size = new System.Drawing.Size(53, 22);
            this.btnOutputFolder.TabIndex = 10;
            this.btnOutputFolder.Text = "Vaihda";
            this.btnOutputFolder.UseVisualStyleBackColor = true;
            this.btnOutputFolder.Click += new System.EventHandler(this.btnOutputFolder_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 177);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Tuloskansio";
            // 
            // txtOutputFolder
            // 
            this.txtOutputFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutputFolder.Location = new System.Drawing.Point(7, 192);
            this.txtOutputFolder.Margin = new System.Windows.Forms.Padding(2);
            this.txtOutputFolder.Name = "txtOutputFolder";
            this.txtOutputFolder.Size = new System.Drawing.Size(349, 20);
            this.txtOutputFolder.TabIndex = 9;
            // 
            // btnSelectTemplate
            // 
            this.btnSelectTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectTemplate.Location = new System.Drawing.Point(359, 18);
            this.btnSelectTemplate.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelectTemplate.Name = "btnSelectTemplate";
            this.btnSelectTemplate.Size = new System.Drawing.Size(53, 22);
            this.btnSelectTemplate.TabIndex = 2;
            this.btnSelectTemplate.Text = "Vaihda";
            this.btnSelectTemplate.UseVisualStyleBackColor = true;
            this.btnSelectTemplate.Click += new System.EventHandler(this.btnSelectTemplate_Click_2);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 4);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Tulospohja laaja tytöt";
            // 
            // txtTemplateGirlsExtended
            // 
            this.txtTemplateGirlsExtended.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTemplateGirlsExtended.Location = new System.Drawing.Point(7, 19);
            this.txtTemplateGirlsExtended.Margin = new System.Windows.Forms.Padding(2);
            this.txtTemplateGirlsExtended.Name = "txtTemplateGirlsExtended";
            this.txtTemplateGirlsExtended.Size = new System.Drawing.Size(349, 20);
            this.txtTemplateGirlsExtended.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 111);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Tulospohja";
            // 
            // ddlTulospohja
            // 
            this.ddlTulospohja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlTulospohja.FormattingEnabled = true;
            this.ddlTulospohja.Items.AddRange(new object[] {
            "Tytöt laaja",
            "Tytöt suppea",
            "Pojat laaja",
            "Pojat suppea"});
            this.ddlTulospohja.Location = new System.Drawing.Point(11, 126);
            this.ddlTulospohja.Margin = new System.Windows.Forms.Padding(2);
            this.ddlTulospohja.Name = "ddlTulospohja";
            this.ddlTulospohja.Size = new System.Drawing.Size(82, 21);
            this.ddlTulospohja.TabIndex = 12;
            this.ddlTulospohja.SelectedIndexChanged += new System.EventHandler(this.ddlTulospohja_SelectedIndexChanged);
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 663);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 9, 0);
            this.statusStrip.Size = new System.Drawing.Size(675, 22);
            this.statusStrip.TabIndex = 13;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            this.toolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLink
            // 
            this.toolStripStatusLink.IsLink = true;
            this.toolStripStatusLink.Name = "toolStripStatusLink";
            this.toolStripStatusLink.Size = new System.Drawing.Size(0, 17);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tiedostoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(675, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tiedostoToolStripMenuItem
            // 
            this.tiedostoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.avaaToolStripMenuItem,
            this.tallennaToolStripMenuItem,
            this.suljeSovellusToolStripMenuItem});
            this.tiedostoToolStripMenuItem.Name = "tiedostoToolStripMenuItem";
            this.tiedostoToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.tiedostoToolStripMenuItem.Text = "Tiedosto";
            // 
            // avaaToolStripMenuItem
            // 
            this.avaaToolStripMenuItem.Name = "avaaToolStripMenuItem";
            this.avaaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.avaaToolStripMenuItem.Text = "Avaa...";
            this.avaaToolStripMenuItem.Click += new System.EventHandler(this.avaaToolStripMenuItem_Click);
            // 
            // tallennaToolStripMenuItem
            // 
            this.tallennaToolStripMenuItem.Name = "tallennaToolStripMenuItem";
            this.tallennaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.tallennaToolStripMenuItem.Text = "Tallenna";
            this.tallennaToolStripMenuItem.Click += new System.EventHandler(this.tallennaToolStripMenuItem_Click);
            // 
            // suljeSovellusToolStripMenuItem
            // 
            this.suljeSovellusToolStripMenuItem.Name = "suljeSovellusToolStripMenuItem";
            this.suljeSovellusToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.suljeSovellusToolStripMenuItem.Text = "Sulje sovellus";
            this.suljeSovellusToolStripMenuItem.Click += new System.EventHandler(this.suljeSovellusToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 685);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.ddlTulospohja);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.txtAikaPaikka);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTapahtumaSarja);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Tähtiarvioinnin tulostus";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tabControl.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSkaters)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSkaterPoints)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTapahtumaSarja;
        private System.Windows.Forms.TextBox txtAikaPaikka;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtTemplateGirlsExtended;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSelectTemplate;
        private System.Windows.Forms.TextBox txtOutputFolder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnOutputFolder;
        private System.Windows.Forms.TextBox txtTemplateBoysExtended;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtAllFoundSkaters;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSaveOutputFiles;
        private System.Windows.Forms.Button btnOpenResultFile;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgvSkaters;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTemplateBoysBasic;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTemplateGirlsBasic;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox ddlTulospohja;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLink;
        private System.Windows.Forms.ComboBox ddlSkaters;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvSkaterPoints;
        private System.Windows.Forms.TextBox txtDressDeduction;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtTimeDeduction;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtSpiralDeduction;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMention;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tuomari3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tuomari2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tuomari1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.Button btnOletusarvot;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tiedostoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem avaaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem suljeSovellusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tallennaToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Order;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nimi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Seura;
    }
}

