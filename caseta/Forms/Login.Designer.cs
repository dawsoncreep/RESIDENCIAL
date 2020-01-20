namespace caseta
{
    partial class fLogin
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
            this.gbLogin = new System.Windows.Forms.GroupBox();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.Lbl_Pass = new System.Windows.Forms.Label();
            this.Tbx_Pass = new System.Windows.Forms.TextBox();
            this.Lbl_User = new System.Windows.Forms.Label();
            this.Tbx_User = new System.Windows.Forms.TextBox();
            this.gbLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbLogin
            // 
            this.gbLogin.Controls.Add(this.btnIngresar);
            this.gbLogin.Controls.Add(this.Lbl_Pass);
            this.gbLogin.Controls.Add(this.Tbx_Pass);
            this.gbLogin.Controls.Add(this.Lbl_User);
            this.gbLogin.Controls.Add(this.Tbx_User);
            this.gbLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbLogin.Location = new System.Drawing.Point(9, 10);
            this.gbLogin.Margin = new System.Windows.Forms.Padding(2);
            this.gbLogin.Name = "gbLogin";
            this.gbLogin.Padding = new System.Windows.Forms.Padding(2);
            this.gbLogin.Size = new System.Drawing.Size(296, 247);
            this.gbLogin.TabIndex = 0;
            this.gbLogin.TabStop = false;
            this.gbLogin.Text = "Acceso";
            // 
            // btnIngresar
            // 
            this.btnIngresar.Location = new System.Drawing.Point(177, 175);
            this.btnIngresar.Margin = new System.Windows.Forms.Padding(2);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(115, 52);
            this.btnIngresar.TabIndex = 5;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.BtnIngresar_Click);
            // 
            // Lbl_Pass
            // 
            this.Lbl_Pass.AutoSize = true;
            this.Lbl_Pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Pass.Location = new System.Drawing.Point(4, 98);
            this.Lbl_Pass.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_Pass.Name = "Lbl_Pass";
            this.Lbl_Pass.Size = new System.Drawing.Size(134, 31);
            this.Lbl_Pass.TabIndex = 4;
            this.Lbl_Pass.Text = "Password";
            // 
            // Tbx_Pass
            // 
            this.Tbx_Pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tbx_Pass.Location = new System.Drawing.Point(4, 132);
            this.Tbx_Pass.Margin = new System.Windows.Forms.Padding(2);
            this.Tbx_Pass.Name = "Tbx_Pass";
            this.Tbx_Pass.PasswordChar = '*';
            this.Tbx_Pass.Size = new System.Drawing.Size(288, 28);
            this.Tbx_Pass.TabIndex = 3;
            // 
            // Lbl_User
            // 
            this.Lbl_User.AutoSize = true;
            this.Lbl_User.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_User.Location = new System.Drawing.Point(4, 33);
            this.Lbl_User.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_User.Name = "Lbl_User";
            this.Lbl_User.Size = new System.Drawing.Size(108, 31);
            this.Lbl_User.TabIndex = 2;
            this.Lbl_User.Text = "Usuario";
            // 
            // Tbx_User
            // 
            this.Tbx_User.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tbx_User.Location = new System.Drawing.Point(4, 67);
            this.Tbx_User.Margin = new System.Windows.Forms.Padding(2);
            this.Tbx_User.Name = "Tbx_User";
            this.Tbx_User.Size = new System.Drawing.Size(288, 28);
            this.Tbx_User.TabIndex = 1;
            // 
            // fLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 266);
            this.Controls.Add(this.gbLogin);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "fLogin";
            this.Text = "Login";
            this.gbLogin.ResumeLayout(false);
            this.gbLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbLogin;
        private System.Windows.Forms.Label Lbl_User;
        private System.Windows.Forms.TextBox Tbx_User;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Label Lbl_Pass;
        private System.Windows.Forms.TextBox Tbx_Pass;
    }
}

