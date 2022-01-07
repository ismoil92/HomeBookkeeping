namespace HomeBookkeeping
{
    partial class IncomesOutcomesForm
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
            this.textBoxIncomeOutcome = new System.Windows.Forms.TextBox();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.comboBoxIncomeOutcomeCateg = new System.Windows.Forms.ComboBox();
            this.textBoxComment = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpDateAndTime = new System.Windows.Forms.DateTimePicker();
            this.labelCategory = new System.Windows.Forms.Label();
            this.labelPrice = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonOutcomesCategory = new System.Windows.Forms.RadioButton();
            this.radioButtonIncomesCategory = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxIncomeOutcome
            // 
            this.textBoxIncomeOutcome.Enabled = false;
            this.textBoxIncomeOutcome.Location = new System.Drawing.Point(13, 212);
            this.textBoxIncomeOutcome.Name = "textBoxIncomeOutcome";
            this.textBoxIncomeOutcome.Size = new System.Drawing.Size(94, 20);
            this.textBoxIncomeOutcome.TabIndex = 1;
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(114, 97);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(201, 20);
            this.textBoxPrice.TabIndex = 3;
            this.textBoxPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPrice_KeyPress);
            // 
            // comboBoxIncomeOutcomeCateg
            // 
            this.comboBoxIncomeOutcomeCateg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxIncomeOutcomeCateg.FormattingEnabled = true;
            this.comboBoxIncomeOutcomeCateg.Location = new System.Drawing.Point(115, 62);
            this.comboBoxIncomeOutcomeCateg.Name = "comboBoxIncomeOutcomeCateg";
            this.comboBoxIncomeOutcomeCateg.Size = new System.Drawing.Size(200, 21);
            this.comboBoxIncomeOutcomeCateg.TabIndex = 2;
            // 
            // textBoxComment
            // 
            this.textBoxComment.Location = new System.Drawing.Point(114, 133);
            this.textBoxComment.Name = "textBoxComment";
            this.textBoxComment.Size = new System.Drawing.Size(201, 20);
            this.textBoxComment.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Дата и время";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Категория";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Сумма";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Комментарий";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(13, 170);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(94, 31);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.dtpDateAndTime);
            this.groupBox1.Controls.Add(this.labelCategory);
            this.groupBox1.Controls.Add(this.labelPrice);
            this.groupBox1.Controls.Add(this.buttonSave);
            this.groupBox1.Controls.Add(this.textBoxIncomeOutcome);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBoxPrice);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.comboBoxIncomeOutcomeCateg);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxComment);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(504, 238);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Добавление";
            // 
            // dtpDateAndTime
            // 
            this.dtpDateAndTime.Location = new System.Drawing.Point(115, 27);
            this.dtpDateAndTime.Name = "dtpDateAndTime";
            this.dtpDateAndTime.Size = new System.Drawing.Size(200, 20);
            this.dtpDateAndTime.TabIndex = 18;
            // 
            // labelCategory
            // 
            this.labelCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCategory.AutoSize = true;
            this.labelCategory.ForeColor = System.Drawing.Color.Red;
            this.labelCategory.Location = new System.Drawing.Point(321, 67);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(176, 13);
            this.labelCategory.TabIndex = 17;
            this.labelCategory.Text = "Поля Категория не выбрано";
            this.labelCategory.Visible = false;
            // 
            // labelPrice
            // 
            this.labelPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPrice.AutoSize = true;
            this.labelPrice.ForeColor = System.Drawing.Color.Red;
            this.labelPrice.Location = new System.Drawing.Point(322, 100);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(170, 13);
            this.labelPrice.TabIndex = 14;
            this.labelPrice.Text = "Поля Сумма не равно нулю";
            this.labelPrice.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonOutcomesCategory);
            this.groupBox2.Controls.Add(this.radioButtonIncomesCategory);
            this.groupBox2.Location = new System.Drawing.Point(129, 159);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(104, 78);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Категории";
            // 
            // radioButtonOutcomesCategory
            // 
            this.radioButtonOutcomesCategory.AutoSize = true;
            this.radioButtonOutcomesCategory.Location = new System.Drawing.Point(18, 52);
            this.radioButtonOutcomesCategory.Name = "radioButtonOutcomesCategory";
            this.radioButtonOutcomesCategory.Size = new System.Drawing.Size(67, 17);
            this.radioButtonOutcomesCategory.TabIndex = 1;
            this.radioButtonOutcomesCategory.TabStop = true;
            this.radioButtonOutcomesCategory.Text = "Расход";
            this.radioButtonOutcomesCategory.UseVisualStyleBackColor = true;
            this.radioButtonOutcomesCategory.CheckedChanged += new System.EventHandler(this.radioButtonOutcomesCategory_CheckedChanged);
            // 
            // radioButtonIncomesCategory
            // 
            this.radioButtonIncomesCategory.AutoSize = true;
            this.radioButtonIncomesCategory.Location = new System.Drawing.Point(18, 29);
            this.radioButtonIncomesCategory.Name = "radioButtonIncomesCategory";
            this.radioButtonIncomesCategory.Size = new System.Drawing.Size(62, 17);
            this.radioButtonIncomesCategory.TabIndex = 0;
            this.radioButtonIncomesCategory.TabStop = true;
            this.radioButtonIncomesCategory.Text = "Доход";
            this.radioButtonIncomesCategory.UseVisualStyleBackColor = true;
            this.radioButtonIncomesCategory.CheckedChanged += new System.EventHandler(this.radioButtonIncomesCategory_CheckedChanged);
            // 
            // IncomesOutcomesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 261);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IncomesOutcomesForm";
            this.Text = "Доход и Расход";
            this.Load += new System.EventHandler(this.IncomesOutcomesForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxIncomeOutcome;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.ComboBox comboBoxIncomeOutcomeCateg;
        private System.Windows.Forms.TextBox textBoxComment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButtonOutcomesCategory;
        private System.Windows.Forms.RadioButton radioButtonIncomesCategory;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.DateTimePicker dtpDateAndTime;
    }
}