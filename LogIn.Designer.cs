namespace BarCodeLabel
{
    partial class LogIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogIn));
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.txt_PW = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.check_SaveID = new System.Windows.Forms.CheckBox();
            this.check_SavePW = new System.Windows.Forms.CheckBox();
            this.btn_Exit = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // txt_ID
            // 
            this.txt_ID.Location = new System.Drawing.Point(112, 40);
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.Size = new System.Drawing.Size(100, 21);
            this.txt_ID.TabIndex = 0;
            // 
            // txt_PW
            // 
            this.txt_PW.Location = new System.Drawing.Point(112, 91);
            this.txt_PW.Name = "txt_PW";
            this.txt_PW.PasswordChar = '*';
            this.txt_PW.Size = new System.Drawing.Size(100, 21);
            this.txt_PW.TabIndex = 1;
            this.txt_PW.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_PW_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "PW";
            // 
            // check_SaveID
            // 
            this.check_SaveID.AutoSize = true;
            this.check_SaveID.Location = new System.Drawing.Point(103, 143);
            this.check_SaveID.Name = "check_SaveID";
            this.check_SaveID.Size = new System.Drawing.Size(63, 16);
            this.check_SaveID.TabIndex = 3;
            this.check_SaveID.Text = "ID 저장";
            this.check_SaveID.UseVisualStyleBackColor = true;
            // 
            // check_SavePW
            // 
            this.check_SavePW.AutoSize = true;
            this.check_SavePW.Location = new System.Drawing.Point(193, 143);
            this.check_SavePW.Name = "check_SavePW";
            this.check_SavePW.Size = new System.Drawing.Size(70, 16);
            this.check_SavePW.TabIndex = 4;
            this.check_SavePW.Text = "PW 저장";
            this.check_SavePW.UseVisualStyleBackColor = true;
            // 
            // btn_Exit
            // 
            this.btn_Exit.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Exit.Appearance.BackColor2 = System.Drawing.SystemColors.Control;
            this.btn_Exit.Appearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btn_Exit.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Exit.Appearance.Options.UseBackColor = true;
            this.btn_Exit.Appearance.Options.UseBorderColor = true;
            this.btn_Exit.Appearance.Options.UseFont = true;
            this.btn_Exit.AppearanceDisabled.BackColor = System.Drawing.Color.Transparent;
            this.btn_Exit.AppearanceDisabled.BackColor2 = System.Drawing.Color.Transparent;
            this.btn_Exit.AppearanceDisabled.BorderColor = System.Drawing.Color.Transparent;
            this.btn_Exit.AppearanceDisabled.Options.UseBackColor = true;
            this.btn_Exit.AppearanceDisabled.Options.UseBorderColor = true;
            this.btn_Exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Exit.ImageOptions.Image = global::BarCodeLabel.Properties.Resources.close_16x16;
            this.btn_Exit.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btn_Exit.Location = new System.Drawing.Point(295, 180);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(61, 34);
            this.btn_Exit.TabIndex = 5;
            this.btn_Exit.Text = "종료";
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.simpleButton1.ImageOptions.Image = global::BarCodeLabel.Properties.Resources.assignto_32x32;
            this.simpleButton1.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.simpleButton1.Location = new System.Drawing.Point(228, 39);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 74);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "LOGIN";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 226);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.check_SavePW);
            this.Controls.Add(this.txt_ID);
            this.Controls.Add(this.check_SaveID);
            this.Controls.Add(this.txt_PW);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "라벨 출력 시스템 - 로그인";
            this.Load += new System.EventHandler(this.LogIn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_PW;
        private System.Windows.Forms.TextBox txt_ID;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.CheckBox check_SavePW;
        private System.Windows.Forms.CheckBox check_SaveID;
        private DevExpress.XtraEditors.SimpleButton btn_Exit;
    }
}