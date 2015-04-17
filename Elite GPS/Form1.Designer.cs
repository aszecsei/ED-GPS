namespace Elite_GPS
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
            this.locationsListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.systemBox = new System.Windows.Forms.ComboBox();
            this.stationBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.purchaseBox = new System.Windows.Forms.CheckBox();
            this.sellBox = new System.Windows.Forms.CheckBox();
            this.purchaseCommodityBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.purchaseCommodityAmountBox = new System.Windows.Forms.NumericUpDown();
            this.sellCommodityAmountBox = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.sellCommodityBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.loadDataButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.addLocationButton = new System.Windows.Forms.Button();
            this.deleteLocationButton = new System.Windows.Forms.Button();
            this.moveUpButton = new System.Windows.Forms.Button();
            this.moveDownButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newRouteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startRouteButton = new System.Windows.Forms.Button();
            this.stopRouteButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.loadingDataStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.loadingDataProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseCommodityAmountBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sellCommodityAmountBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // locationsListBox
            // 
            this.locationsListBox.FormattingEnabled = true;
            this.locationsListBox.Location = new System.Drawing.Point(443, 41);
            this.locationsListBox.Name = "locationsListBox";
            this.locationsListBox.Size = new System.Drawing.Size(349, 329);
            this.locationsListBox.TabIndex = 0;
            this.locationsListBox.SelectedIndexChanged += new System.EventHandler(this.locationsListBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "System";
            // 
            // systemBox
            // 
            this.systemBox.Enabled = false;
            this.systemBox.FormattingEnabled = true;
            this.systemBox.Location = new System.Drawing.Point(69, 19);
            this.systemBox.Name = "systemBox";
            this.systemBox.Size = new System.Drawing.Size(226, 21);
            this.systemBox.TabIndex = 3;
            this.systemBox.SelectedIndexChanged += new System.EventHandler(this.systemBox_SelectedIndexChanged);
            // 
            // stationBox
            // 
            this.stationBox.Enabled = false;
            this.stationBox.FormattingEnabled = true;
            this.stationBox.Location = new System.Drawing.Point(69, 56);
            this.stationBox.Name = "stationBox";
            this.stationBox.Size = new System.Drawing.Size(226, 21);
            this.stationBox.TabIndex = 4;
            this.stationBox.SelectedIndexChanged += new System.EventHandler(this.stationBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Station";
            // 
            // purchaseBox
            // 
            this.purchaseBox.AutoSize = true;
            this.purchaseBox.Enabled = false;
            this.purchaseBox.Location = new System.Drawing.Point(69, 19);
            this.purchaseBox.Name = "purchaseBox";
            this.purchaseBox.Size = new System.Drawing.Size(133, 17);
            this.purchaseBox.TabIndex = 6;
            this.purchaseBox.Text = "Purchase Commodities";
            this.purchaseBox.UseVisualStyleBackColor = true;
            this.purchaseBox.CheckedChanged += new System.EventHandler(this.purchaseBox_CheckedChanged);
            // 
            // sellBox
            // 
            this.sellBox.AutoSize = true;
            this.sellBox.Enabled = false;
            this.sellBox.Location = new System.Drawing.Point(69, 117);
            this.sellBox.Name = "sellBox";
            this.sellBox.Size = new System.Drawing.Size(105, 17);
            this.sellBox.TabIndex = 7;
            this.sellBox.Text = "Sell Commodities";
            this.sellBox.UseVisualStyleBackColor = true;
            this.sellBox.CheckedChanged += new System.EventHandler(this.sellBox_CheckedChanged);
            // 
            // purchaseCommodityBox
            // 
            this.purchaseCommodityBox.Enabled = false;
            this.purchaseCommodityBox.FormattingEnabled = true;
            this.purchaseCommodityBox.Location = new System.Drawing.Point(69, 42);
            this.purchaseCommodityBox.Name = "purchaseCommodityBox";
            this.purchaseCommodityBox.Size = new System.Drawing.Size(309, 21);
            this.purchaseCommodityBox.TabIndex = 9;
            this.purchaseCommodityBox.SelectedIndexChanged += new System.EventHandler(this.purchaseCommodityBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Commodity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Amount";
            // 
            // purchaseCommodityAmountBox
            // 
            this.purchaseCommodityAmountBox.Enabled = false;
            this.purchaseCommodityAmountBox.Location = new System.Drawing.Point(69, 80);
            this.purchaseCommodityAmountBox.Name = "purchaseCommodityAmountBox";
            this.purchaseCommodityAmountBox.Size = new System.Drawing.Size(309, 20);
            this.purchaseCommodityAmountBox.TabIndex = 11;
            this.purchaseCommodityAmountBox.ValueChanged += new System.EventHandler(this.purchaseCommodityAmountBox_ValueChanged);
            // 
            // sellCommodityAmountBox
            // 
            this.sellCommodityAmountBox.Enabled = false;
            this.sellCommodityAmountBox.Location = new System.Drawing.Point(69, 183);
            this.sellCommodityAmountBox.Name = "sellCommodityAmountBox";
            this.sellCommodityAmountBox.Size = new System.Drawing.Size(309, 20);
            this.sellCommodityAmountBox.TabIndex = 15;
            this.sellCommodityAmountBox.ValueChanged += new System.EventHandler(this.sellCommodityAmountBox_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Amount";
            // 
            // sellCommodityBox
            // 
            this.sellCommodityBox.Enabled = false;
            this.sellCommodityBox.FormattingEnabled = true;
            this.sellCommodityBox.Location = new System.Drawing.Point(69, 145);
            this.sellCommodityBox.Name = "sellCommodityBox";
            this.sellCommodityBox.Size = new System.Drawing.Size(309, 21);
            this.sellCommodityBox.TabIndex = 13;
            this.sellCommodityBox.SelectedIndexChanged += new System.EventHandler(this.sellCommodityBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Commodity";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.loadDataButton);
            this.groupBox1.Controls.Add(this.systemBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.stationBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 87);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Basic Info";
            // 
            // loadDataButton
            // 
            this.loadDataButton.Location = new System.Drawing.Point(309, 19);
            this.loadDataButton.Name = "loadDataButton";
            this.loadDataButton.Size = new System.Drawing.Size(99, 58);
            this.loadDataButton.TabIndex = 25;
            this.loadDataButton.Text = "Load Data";
            this.loadDataButton.UseVisualStyleBackColor = true;
            this.loadDataButton.Click += new System.EventHandler(this.loadDataButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.purchaseBox);
            this.groupBox2.Controls.Add(this.sellBox);
            this.groupBox2.Controls.Add(this.sellCommodityAmountBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.purchaseCommodityBox);
            this.groupBox2.Controls.Add(this.sellCommodityBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.purchaseCommodityAmountBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 138);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(414, 232);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Trading";
            // 
            // addLocationButton
            // 
            this.addLocationButton.Enabled = false;
            this.addLocationButton.Location = new System.Drawing.Point(12, 387);
            this.addLocationButton.Name = "addLocationButton";
            this.addLocationButton.Size = new System.Drawing.Size(99, 55);
            this.addLocationButton.TabIndex = 18;
            this.addLocationButton.Text = "Add Location";
            this.addLocationButton.UseVisualStyleBackColor = true;
            this.addLocationButton.Click += new System.EventHandler(this.addLocationButton_Click);
            // 
            // deleteLocationButton
            // 
            this.deleteLocationButton.Enabled = false;
            this.deleteLocationButton.Location = new System.Drawing.Point(117, 387);
            this.deleteLocationButton.Name = "deleteLocationButton";
            this.deleteLocationButton.Size = new System.Drawing.Size(99, 55);
            this.deleteLocationButton.TabIndex = 19;
            this.deleteLocationButton.Text = "Delete Location";
            this.deleteLocationButton.UseVisualStyleBackColor = true;
            this.deleteLocationButton.Click += new System.EventHandler(this.deleteLocationButton_Click);
            // 
            // moveUpButton
            // 
            this.moveUpButton.Enabled = false;
            this.moveUpButton.Location = new System.Drawing.Point(222, 387);
            this.moveUpButton.Name = "moveUpButton";
            this.moveUpButton.Size = new System.Drawing.Size(99, 55);
            this.moveUpButton.TabIndex = 20;
            this.moveUpButton.Text = "Move Up";
            this.moveUpButton.UseVisualStyleBackColor = true;
            this.moveUpButton.Click += new System.EventHandler(this.moveUpButton_Click);
            // 
            // moveDownButton
            // 
            this.moveDownButton.Enabled = false;
            this.moveDownButton.Location = new System.Drawing.Point(327, 387);
            this.moveDownButton.Name = "moveDownButton";
            this.moveDownButton.Size = new System.Drawing.Size(99, 55);
            this.moveDownButton.TabIndex = 21;
            this.moveDownButton.Text = "Move Down";
            this.moveDownButton.UseVisualStyleBackColor = true;
            this.moveDownButton.Click += new System.EventHandler(this.moveDownButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(810, 24);
            this.menuStrip1.TabIndex = 22;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newRouteToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newRouteToolStripMenuItem
            // 
            this.newRouteToolStripMenuItem.Name = "newRouteToolStripMenuItem";
            this.newRouteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newRouteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newRouteToolStripMenuItem.Text = "&New Route";
            this.newRouteToolStripMenuItem.Click += new System.EventHandler(this.newRouteToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "&Open Route";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "&Save Route";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Q)));
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.quitToolStripMenuItem.Text = "&Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // startRouteButton
            // 
            this.startRouteButton.Location = new System.Drawing.Point(488, 387);
            this.startRouteButton.Name = "startRouteButton";
            this.startRouteButton.Size = new System.Drawing.Size(99, 55);
            this.startRouteButton.TabIndex = 23;
            this.startRouteButton.Text = "Start Route";
            this.startRouteButton.UseVisualStyleBackColor = true;
            this.startRouteButton.Click += new System.EventHandler(this.startRouteButton_Click);
            // 
            // stopRouteButton
            // 
            this.stopRouteButton.Enabled = false;
            this.stopRouteButton.Location = new System.Drawing.Point(631, 387);
            this.stopRouteButton.Name = "stopRouteButton";
            this.stopRouteButton.Size = new System.Drawing.Size(99, 55);
            this.stopRouteButton.TabIndex = 24;
            this.stopRouteButton.Text = "Stop Route";
            this.stopRouteButton.UseVisualStyleBackColor = true;
            this.stopRouteButton.Click += new System.EventHandler(this.stopRouteButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadingDataStatusLabel,
            this.loadingDataProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 458);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(810, 22);
            this.statusStrip1.TabIndex = 25;
            this.statusStrip1.Text = "Aww yea";
            // 
            // loadingDataStatusLabel
            // 
            this.loadingDataStatusLabel.Name = "loadingDataStatusLabel";
            this.loadingDataStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // loadingDataProgressBar
            // 
            this.loadingDataProgressBar.Enabled = false;
            this.loadingDataProgressBar.Name = "loadingDataProgressBar";
            this.loadingDataProgressBar.Size = new System.Drawing.Size(100, 16);
            this.loadingDataProgressBar.Step = 25;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(810, 480);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.stopRouteButton);
            this.Controls.Add(this.startRouteButton);
            this.Controls.Add(this.moveDownButton);
            this.Controls.Add(this.moveUpButton);
            this.Controls.Add(this.deleteLocationButton);
            this.Controls.Add(this.addLocationButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.locationsListBox);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Elite Dangerous Navigational Assistant";
            ((System.ComponentModel.ISupportInitialize)(this.purchaseCommodityAmountBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sellCommodityAmountBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox locationsListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox systemBox;
        private System.Windows.Forms.ComboBox stationBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox purchaseBox;
        private System.Windows.Forms.CheckBox sellBox;
        private System.Windows.Forms.ComboBox purchaseCommodityBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown purchaseCommodityAmountBox;
        private System.Windows.Forms.NumericUpDown sellCommodityAmountBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox sellCommodityBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button addLocationButton;
        private System.Windows.Forms.Button deleteLocationButton;
        private System.Windows.Forms.Button moveUpButton;
        private System.Windows.Forms.Button moveDownButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newRouteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.Button startRouteButton;
        private System.Windows.Forms.Button stopRouteButton;
        private System.Windows.Forms.Button loadDataButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel loadingDataStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar loadingDataProgressBar;

    }
}

