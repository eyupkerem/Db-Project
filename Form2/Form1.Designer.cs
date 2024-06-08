namespace Form2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comboBox1 = new ComboBox();
            label1 = new Label();
            start_btn = new Button();
            typeAUser = new NumericUpDown();
            typeBUser = new NumericUpDown();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)typeAUser).BeginInit();
            ((System.ComponentModel.ISupportInitialize)typeBUser).BeginInit();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "ReadCommitted", "ReadUncommitted", "RepeatableRead", "Serializable" });
            comboBox1.Location = new Point(302, 62);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(99, 70);
            label1.Name = "label1";
            label1.Size = new Size(166, 20);
            label1.TabIndex = 1;
            label1.Text = "Select Transaction Level";
            // 
            // start_btn
            // 
            start_btn.Location = new Point(303, 331);
            start_btn.Name = "start_btn";
            start_btn.Size = new Size(94, 29);
            start_btn.TabIndex = 2;
            start_btn.Text = "Start";
            start_btn.UseVisualStyleBackColor = true;
            start_btn.Click += start_btn_Click;
            // 
            // typeAUser
            // 
            typeAUser.Location = new Point(303, 141);
            typeAUser.Name = "typeAUser";
            typeAUser.Size = new Size(150, 27);
            typeAUser.TabIndex = 3;
            typeAUser.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // typeBUser
            // 
            typeBUser.Location = new Point(303, 227);
            typeBUser.Name = "typeBUser";
            typeBUser.Size = new Size(150, 27);
            typeBUser.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(99, 148);
            label2.Name = "label2";
            label2.Size = new Size(87, 20);
            label2.TabIndex = 5;
            label2.Text = "Type A User";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(99, 234);
            label3.Name = "label3";
            label3.Size = new Size(84, 20);
            label3.TabIndex = 6;
            label3.Text = "Type B user";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(typeBUser);
            Controls.Add(typeAUser);
            Controls.Add(start_btn);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)typeAUser).EndInit();
            ((System.ComponentModel.ISupportInitialize)typeBUser).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private Label label1;
        private Button start_btn;
        private NumericUpDown typeAUser;
        private NumericUpDown typeBUser;
        private Label label2;
        private Label label3;
    }
}
