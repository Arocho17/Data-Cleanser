namespace CRSTDataCleaner
{
    partial class ViewForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxReplace = new System.Windows.Forms.TextBox();
            this.txtBoxWith = new System.Windows.Forms.TextBox();
            this.dgvEditRules = new System.Windows.Forms.DataGridView();
            this.rdoState = new System.Windows.Forms.RadioButton();
            this.rdoCounty = new System.Windows.Forms.RadioButton();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.cmbCounty = new System.Windows.Forms.ComboBox();
            this.btnViewAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEditRules)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(281, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Replace:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(512, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "With:";
            // 
            // txtBoxReplace
            // 
            this.txtBoxReplace.Location = new System.Drawing.Point(359, 22);
            this.txtBoxReplace.Name = "txtBoxReplace";
            this.txtBoxReplace.Size = new System.Drawing.Size(125, 26);
            this.txtBoxReplace.TabIndex = 2;
            // 
            // txtBoxWith
            // 
            this.txtBoxWith.Location = new System.Drawing.Point(563, 22);
            this.txtBoxWith.Name = "txtBoxWith";
            this.txtBoxWith.Size = new System.Drawing.Size(125, 26);
            this.txtBoxWith.TabIndex = 3;
            // 
            // dgvEditRules
            // 
            this.dgvEditRules.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEditRules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEditRules.Location = new System.Drawing.Point(18, 100);
            this.dgvEditRules.Name = "dgvEditRules";
            this.dgvEditRules.RowTemplate.Height = 28;
            this.dgvEditRules.Size = new System.Drawing.Size(1193, 869);
            this.dgvEditRules.TabIndex = 4;
            this.dgvEditRules.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEditRules_CellContentClick);
            // 
            // rdoState
            // 
            this.rdoState.AutoSize = true;
            this.rdoState.Location = new System.Drawing.Point(385, 63);
            this.rdoState.Name = "rdoState";
            this.rdoState.Size = new System.Drawing.Size(73, 24);
            this.rdoState.TabIndex = 6;
            this.rdoState.Text = "State";
            this.rdoState.UseVisualStyleBackColor = true;
            this.rdoState.CheckedChanged += new System.EventHandler(this.rdoState_CheckedChanged);
            // 
            // rdoCounty
            // 
            this.rdoCounty.AutoSize = true;
            this.rdoCounty.Location = new System.Drawing.Point(464, 63);
            this.rdoCounty.Name = "rdoCounty";
            this.rdoCounty.Size = new System.Drawing.Size(84, 24);
            this.rdoCounty.TabIndex = 7;
            this.rdoCounty.Text = "County";
            this.rdoCounty.UseVisualStyleBackColor = true;
            this.rdoCounty.CheckedChanged += new System.EventHandler(this.radioBtnCounty_CheckedChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(709, 17);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(116, 37);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add Rule";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(893, 57);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(116, 37);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cmbCounty
            // 
            this.cmbCounty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCounty.FormattingEnabled = true;
            this.cmbCounty.Items.AddRange(new object[] {
            "Albany",
            "Allegany",
            "Broome",
            "Cattaraugus",
            "Chemung",
            "Chenango",
            "Clinton",
            "Columbia",
            "Cortland",
            "Delaware",
            "Dutchess",
            "Erie",
            "Essex",
            "Franklin",
            "Fulton",
            "Genesee",
            "Greene",
            "Hamilton",
            "Herkimer",
            "Jefferson",
            "Lewis",
            "Livingston",
            "Madison",
            "Monroe",
            "Montgomery",
            "Nassau",
            "Niagara",
            "New York City",
            "Oneida",
            "Onondaga",
            "Ontario",
            "Orange",
            "Orleans",
            "Oswego",
            "Otsego",
            "Putnam",
            "Rensselaer",
            "Rockland",
            "Saint Lawrence",
            "Saratoga",
            "Schenectady",
            "Schoharie",
            "Schuyler",
            "Seneca",
            "Steuben",
            "Suffolk",
            "Sullivan",
            "Tioga",
            "Tompkins",
            "Ulster",
            "Warren",
            "Washington",
            "Wayne",
            "Westchester",
            "Wyoming",
            "Yates"});
            this.cmbCounty.Location = new System.Drawing.Point(554, 62);
            this.cmbCounty.Name = "cmbCounty";
            this.cmbCounty.Size = new System.Drawing.Size(156, 28);
            this.cmbCounty.TabIndex = 10;
            this.cmbCounty.Visible = false;
            this.cmbCounty.SelectedIndexChanged += new System.EventHandler(this.cmbCounty_SelectedIndexChanged);
            // 
            // btnViewAll
            // 
            this.btnViewAll.Location = new System.Drawing.Point(102, 57);
            this.btnViewAll.Name = "btnViewAll";
            this.btnViewAll.Size = new System.Drawing.Size(116, 37);
            this.btnViewAll.TabIndex = 11;
            this.btnViewAll.Text = "View All";
            this.btnViewAll.UseVisualStyleBackColor = true;
            this.btnViewAll.Click += new System.EventHandler(this.btnViewAll_Click);
            // 
            // ViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 981);
            this.Controls.Add(this.btnViewAll);
            this.Controls.Add(this.cmbCounty);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.rdoCounty);
            this.Controls.Add(this.rdoState);
            this.Controls.Add(this.dgvEditRules);
            this.Controls.Add(this.txtBoxWith);
            this.Controls.Add(this.txtBoxReplace);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ViewForm";
            this.Text = "Data Cleanser";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEditRules)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxReplace;
        private System.Windows.Forms.TextBox txtBoxWith;
        private System.Windows.Forms.RadioButton rdoState;
        private System.Windows.Forms.RadioButton rdoCounty;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cmbCounty;
        public System.Windows.Forms.DataGridView dgvEditRules;
        private System.Windows.Forms.Button btnViewAll;
    }
}