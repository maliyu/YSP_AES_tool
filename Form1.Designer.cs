namespace YSP_AES_tool
{
    partial class FormAEStool
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxCiphertext = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPlaintext = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonEncrypt = new System.Windows.Forms.Button();
            this.buttonDecrypt = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxCiphertext);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxKey);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxPlaintext);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(651, 361);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // textBoxCiphertext
            // 
            this.textBoxCiphertext.Location = new System.Drawing.Point(60, 199);
            this.textBoxCiphertext.Multiline = true;
            this.textBoxCiphertext.Name = "textBoxCiphertext";
            this.textBoxCiphertext.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxCiphertext.Size = new System.Drawing.Size(585, 143);
            this.textBoxCiphertext.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ciphertext:";
            // 
            // textBoxKey
            // 
            this.textBoxKey.Location = new System.Drawing.Point(60, 167);
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.Size = new System.Drawing.Size(585, 20);
            this.textBoxKey.TabIndex = 3;
            this.textBoxKey.Text = "000102030405060708090a0b0c0d0e0f";
            this.textBoxKey.TextChanged += new System.EventHandler(this.textBoxKey_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Key:";
            // 
            // textBoxPlaintext
            // 
            this.textBoxPlaintext.Location = new System.Drawing.Point(60, 20);
            this.textBoxPlaintext.Multiline = true;
            this.textBoxPlaintext.Name = "textBoxPlaintext";
            this.textBoxPlaintext.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxPlaintext.Size = new System.Drawing.Size(585, 140);
            this.textBoxPlaintext.TabIndex = 1;
            this.textBoxPlaintext.Text = "00112233445566778899aabbccddeeff";
            this.textBoxPlaintext.TextChanged += new System.EventHandler(this.textBoxPlaintext_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Plaintext:";
            // 
            // buttonEncrypt
            // 
            this.buttonEncrypt.Location = new System.Drawing.Point(72, 425);
            this.buttonEncrypt.Name = "buttonEncrypt";
            this.buttonEncrypt.Size = new System.Drawing.Size(75, 23);
            this.buttonEncrypt.TabIndex = 1;
            this.buttonEncrypt.Text = "Encryption";
            this.buttonEncrypt.UseVisualStyleBackColor = true;
            this.buttonEncrypt.Click += new System.EventHandler(this.buttonEncrypt_Click);
            // 
            // buttonDecrypt
            // 
            this.buttonDecrypt.Location = new System.Drawing.Point(588, 425);
            this.buttonDecrypt.Name = "buttonDecrypt";
            this.buttonDecrypt.Size = new System.Drawing.Size(75, 23);
            this.buttonDecrypt.TabIndex = 2;
            this.buttonDecrypt.Text = "Decryption";
            this.buttonDecrypt.UseVisualStyleBackColor = true;
            this.buttonDecrypt.Click += new System.EventHandler(this.buttonDecrypt_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(12, 13);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(44, 17);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Hex";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Click += new System.EventHandler(this.radioButton1_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(104, 13);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(65, 17);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.Text = "Plaintext";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.Click += new System.EventHandler(this.radioButton2_Click);
            // 
            // FormAEStool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 460);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.buttonDecrypt);
            this.Controls.Add(this.buttonEncrypt);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormAEStool";
            this.Text = "Yosun AES Tool";
            this.Load += new System.EventHandler(this.FormAEStool_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPlaintext;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCiphertext;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonEncrypt;
        private System.Windows.Forms.Button buttonDecrypt;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
    }
}

