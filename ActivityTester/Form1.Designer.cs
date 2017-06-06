namespace ActivityTester
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.signupList = new System.Windows.Forms.ComboBox();
            this.slotList = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.signName = new System.Windows.Forms.TextBox();
            this.signDescription = new System.Windows.Forms.TextBox();
            this.signLifeTimeStart = new System.Windows.Forms.DateTimePicker();
            this.signLifeTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.End = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.signId = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // signupList
            // 
            this.signupList.FormattingEnabled = true;
            this.signupList.Location = new System.Drawing.Point(12, 12);
            this.signupList.Name = "signupList";
            this.signupList.Size = new System.Drawing.Size(649, 21);
            this.signupList.TabIndex = 0;
            this.signupList.SelectedIndexChanged += new System.EventHandler(this.signupList_SelectedIndexChanged);
            // 
            // slotList
            // 
            this.slotList.FormattingEnabled = true;
            this.slotList.Location = new System.Drawing.Point(12, 62);
            this.slotList.Name = "slotList";
            this.slotList.Size = new System.Drawing.Size(497, 95);
            this.slotList.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(725, 551);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // signName
            // 
            this.signName.Location = new System.Drawing.Point(12, 466);
            this.signName.Name = "signName";
            this.signName.Size = new System.Drawing.Size(100, 20);
            this.signName.TabIndex = 3;
            // 
            // signDescription
            // 
            this.signDescription.Location = new System.Drawing.Point(12, 492);
            this.signDescription.Name = "signDescription";
            this.signDescription.Size = new System.Drawing.Size(100, 20);
            this.signDescription.TabIndex = 3;
            // 
            // signLifeTimeStart
            // 
            this.signLifeTimeStart.Location = new System.Drawing.Point(13, 519);
            this.signLifeTimeStart.Name = "signLifeTimeStart";
            this.signLifeTimeStart.Size = new System.Drawing.Size(200, 20);
            this.signLifeTimeStart.TabIndex = 4;
            // 
            // signLifeTimeEnd
            // 
            this.signLifeTimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.signLifeTimeEnd.Location = new System.Drawing.Point(13, 545);
            this.signLifeTimeEnd.Name = "signLifeTimeEnd";
            this.signLifeTimeEnd.Size = new System.Drawing.Size(200, 20);
            this.signLifeTimeEnd.TabIndex = 4;
            this.signLifeTimeEnd.ValueChanged += new System.EventHandler(this.signLifeTimeEnd_ValueChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.start,
            this.End});
            this.dataGridView1.Location = new System.Drawing.Point(269, 466);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(428, 99);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // start
            // 
            dataGridViewCellStyle1.Format = "f";
            dataGridViewCellStyle1.NullValue = null;
            this.start.DefaultCellStyle = dataGridViewCellStyle1;
            this.start.HeaderText = "Start";
            this.start.Name = "start";
            // 
            // End
            // 
            dataGridViewCellStyle2.Format = "f";
            dataGridViewCellStyle2.NullValue = null;
            this.End.DefaultCellStyle = dataGridViewCellStyle2;
            this.End.HeaderText = "End";
            this.End.Name = "End";
            // 
            // signId
            // 
            this.signId.Location = new System.Drawing.Point(12, 440);
            this.signId.Name = "signId";
            this.signId.Size = new System.Drawing.Size(100, 20);
            this.signId.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 586);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.signLifeTimeEnd);
            this.Controls.Add(this.signLifeTimeStart);
            this.Controls.Add(this.signDescription);
            this.Controls.Add(this.signId);
            this.Controls.Add(this.signName);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.slotList);
            this.Controls.Add(this.signupList);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox signupList;
        private System.Windows.Forms.ListBox slotList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox signName;
        private System.Windows.Forms.TextBox signDescription;
        private System.Windows.Forms.DateTimePicker signLifeTimeStart;
        private System.Windows.Forms.DateTimePicker signLifeTimeEnd;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn start;
        private System.Windows.Forms.DataGridViewTextBoxColumn End;
        private System.Windows.Forms.TextBox signId;
    }
}

