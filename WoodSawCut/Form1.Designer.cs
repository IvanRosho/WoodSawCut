namespace WoodSawCut {
    partial class DelPlank {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent() {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CheckPlanks = new System.Windows.Forms.Button();
            this.ColorPanel = new System.Windows.Forms.Panel();
            this.LengthPlank = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.WidthPlank = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.WeigthPlank = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.AddPlank = new System.Windows.Forms.Button();
            this.PlanksBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RemovePlank = new System.Windows.Forms.Button();
            this.BoxingPlanks = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.FieldPanel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.Report = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LengthPlank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthPlank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WeigthPlank)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.CheckPlanks);
            this.groupBox1.Controls.Add(this.ColorPanel);
            this.groupBox1.Controls.Add(this.LengthPlank);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.WidthPlank);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.WeigthPlank);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.AddPlank);
            this.groupBox1.Location = new System.Drawing.Point(758, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 175);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Доска";
            // 
            // CheckPlanks
            // 
            this.CheckPlanks.Location = new System.Drawing.Point(6, 114);
            this.CheckPlanks.Name = "CheckPlanks";
            this.CheckPlanks.Size = new System.Drawing.Size(192, 23);
            this.CheckPlanks.TabIndex = 10;
            this.CheckPlanks.Text = "Проверить упаковку";
            this.CheckPlanks.UseVisualStyleBackColor = true;
            this.CheckPlanks.Click += new System.EventHandler(this.CheckPlanks_Click);
            // 
            // ColorPanel
            // 
            this.ColorPanel.BackColor = System.Drawing.Color.Yellow;
            this.ColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ColorPanel.Location = new System.Drawing.Point(204, 90);
            this.ColorPanel.Name = "ColorPanel";
            this.ColorPanel.Size = new System.Drawing.Size(45, 45);
            this.ColorPanel.TabIndex = 9;
            this.ColorPanel.Click += new System.EventHandler(this.ColorPanel_Click);
            // 
            // LengthPlank
            // 
            this.LengthPlank.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.LengthPlank.Location = new System.Drawing.Point(116, 63);
            this.LengthPlank.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.LengthPlank.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.LengthPlank.Name = "LengthPlank";
            this.LengthPlank.Size = new System.Drawing.Size(133, 21);
            this.LengthPlank.TabIndex = 6;
            this.LengthPlank.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Длина доски, м";
            // 
            // WidthPlank
            // 
            this.WidthPlank.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.WidthPlank.Location = new System.Drawing.Point(116, 39);
            this.WidthPlank.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.WidthPlank.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WidthPlank.Name = "WidthPlank";
            this.WidthPlank.Size = new System.Drawing.Size(133, 21);
            this.WidthPlank.TabIndex = 4;
            this.WidthPlank.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ширина доски, мм";
            // 
            // WeigthPlank
            // 
            this.WeigthPlank.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.WeigthPlank.Location = new System.Drawing.Point(116, 15);
            this.WeigthPlank.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.WeigthPlank.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WeigthPlank.Name = "WeigthPlank";
            this.WeigthPlank.Size = new System.Drawing.Size(133, 21);
            this.WeigthPlank.TabIndex = 2;
            this.WeigthPlank.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Толщина доски, мм";
            // 
            // AddPlank
            // 
            this.AddPlank.Location = new System.Drawing.Point(6, 143);
            this.AddPlank.Name = "AddPlank";
            this.AddPlank.Size = new System.Drawing.Size(243, 23);
            this.AddPlank.TabIndex = 0;
            this.AddPlank.Text = "Добавить доску";
            this.AddPlank.UseVisualStyleBackColor = true;
            this.AddPlank.Click += new System.EventHandler(this.AddPlank_Click);
            // 
            // PlanksBox
            // 
            this.PlanksBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PlanksBox.Location = new System.Drawing.Point(758, 326);
            this.PlanksBox.Name = "PlanksBox";
            this.PlanksBox.Size = new System.Drawing.Size(258, 199);
            this.PlanksBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(755, 310);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Доски: Толщина*Ширина*Длина";
            // 
            // RemovePlank
            // 
            this.RemovePlank.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RemovePlank.Location = new System.Drawing.Point(758, 530);
            this.RemovePlank.Name = "RemovePlank";
            this.RemovePlank.Size = new System.Drawing.Size(127, 23);
            this.RemovePlank.TabIndex = 4;
            this.RemovePlank.Text = "Удалить доску";
            this.RemovePlank.UseVisualStyleBackColor = true;
            this.RemovePlank.Click += new System.EventHandler(this.RemovePlank_Click);
            // 
            // BoxingPlanks
            // 
            this.BoxingPlanks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BoxingPlanks.Location = new System.Drawing.Point(889, 530);
            this.BoxingPlanks.Name = "BoxingPlanks";
            this.BoxingPlanks.Size = new System.Drawing.Size(127, 23);
            this.BoxingPlanks.TabIndex = 5;
            this.BoxingPlanks.Text = "Упаковать доски";
            this.BoxingPlanks.UseVisualStyleBackColor = true;
            this.BoxingPlanks.Click += new System.EventHandler(this.BoxingPlanks_Click);
            // 
            // colorDialog
            // 
            this.colorDialog.AnyColor = true;
            this.colorDialog.Color = System.Drawing.Color.Yellow;
            // 
            // FieldPanel
            // 
            this.FieldPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FieldPanel.AutoScroll = true;
            this.FieldPanel.BackgroundImage = global::WoodSawCut.Properties.Resources.Cross;
            this.FieldPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.FieldPanel.Location = new System.Drawing.Point(0, 0);
            this.FieldPanel.Name = "FieldPanel";
            this.FieldPanel.Size = new System.Drawing.Size(749, 565);
            this.FieldPanel.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(755, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Отчет:";
            // 
            // Report
            // 
            this.Report.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Report.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Report.Location = new System.Drawing.Point(755, 206);
            this.Report.Multiline = true;
            this.Report.Name = "Report";
            this.Report.ReadOnly = true;
            this.Report.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Report.Size = new System.Drawing.Size(261, 101);
            this.Report.TabIndex = 7;
            // 
            // DelPlank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 565);
            this.Controls.Add(this.Report);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BoxingPlanks);
            this.Controls.Add(this.RemovePlank);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PlanksBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.FieldPanel);
            this.Name = "DelPlank";
            this.Text = "Распиловка бревна";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LengthPlank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthPlank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WeigthPlank)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel FieldPanel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown LengthPlank;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown WidthPlank;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown WeigthPlank;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button AddPlank;
        private System.Windows.Forms.ListBox PlanksBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button RemovePlank;
        private System.Windows.Forms.Button BoxingPlanks;
        private System.Windows.Forms.Panel ColorPanel;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Report;
        private System.Windows.Forms.Button CheckPlanks;
    }
}

