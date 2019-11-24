namespace caseta
{
    partial class Frm_Menu
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
            this.Btn_VCheckIn = new System.Windows.Forms.Button();
            this.Btn_Revision = new System.Windows.Forms.Button();
            this.Btn_Record = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Btn_VCheckIn
            // 
            this.Btn_VCheckIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_VCheckIn.Location = new System.Drawing.Point(24, 26);
            this.Btn_VCheckIn.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_VCheckIn.Name = "Btn_VCheckIn";
            this.Btn_VCheckIn.Size = new System.Drawing.Size(214, 106);
            this.Btn_VCheckIn.TabIndex = 0;
            this.Btn_VCheckIn.Text = "Ingreso Visitantes";
            this.Btn_VCheckIn.UseVisualStyleBackColor = true;
            this.Btn_VCheckIn.Click += new System.EventHandler(this.Btn_VCheckIn_Click);
            // 
            // Btn_Revision
            // 
            this.Btn_Revision.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Revision.Location = new System.Drawing.Point(24, 136);
            this.Btn_Revision.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_Revision.Name = "Btn_Revision";
            this.Btn_Revision.Size = new System.Drawing.Size(214, 106);
            this.Btn_Revision.TabIndex = 1;
            this.Btn_Revision.Text = "Revisión Entradas / Salidas";
            this.Btn_Revision.UseVisualStyleBackColor = true;
            // 
            // Btn_Record
            // 
            this.Btn_Record.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Record.Location = new System.Drawing.Point(24, 247);
            this.Btn_Record.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_Record.Name = "Btn_Record";
            this.Btn_Record.Size = new System.Drawing.Size(214, 106);
            this.Btn_Record.TabIndex = 2;
            this.Btn_Record.Text = "Historial Entradas / Salidas";
            this.Btn_Record.UseVisualStyleBackColor = true;
            // 
            // Frm_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 375);
            this.Controls.Add(this.Btn_Record);
            this.Controls.Add(this.Btn_Revision);
            this.Controls.Add(this.Btn_VCheckIn);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Frm_Menu";
            this.Text = "Menú";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_VCheckIn;
        private System.Windows.Forms.Button Btn_Revision;
        private System.Windows.Forms.Button Btn_Record;
    }
}