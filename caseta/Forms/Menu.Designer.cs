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
            this.Btn_Revision = new System.Windows.Forms.Button();
            this.Btn_Record = new System.Windows.Forms.Button();
            this.Btn_Salidas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Btn_Revision
            // 
            this.Btn_Revision.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Revision.Location = new System.Drawing.Point(24, 11);
            this.Btn_Revision.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_Revision.Name = "Btn_Revision";
            this.Btn_Revision.Size = new System.Drawing.Size(214, 106);
            this.Btn_Revision.TabIndex = 1;
            this.Btn_Revision.Text = "Revisión Entradas";
            this.Btn_Revision.UseVisualStyleBackColor = true;
            this.Btn_Revision.Click += new System.EventHandler(this.Btn_Revision_Click);
            // 
            // Btn_Record
            // 
            this.Btn_Record.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Record.Location = new System.Drawing.Point(24, 231);
            this.Btn_Record.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_Record.Name = "Btn_Record";
            this.Btn_Record.Size = new System.Drawing.Size(214, 106);
            this.Btn_Record.TabIndex = 2;
            this.Btn_Record.Text = "Historial Entradas / Salidas";
            this.Btn_Record.UseVisualStyleBackColor = true;
            // 
            // Btn_Salidas
            // 
            this.Btn_Salidas.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Salidas.Location = new System.Drawing.Point(24, 121);
            this.Btn_Salidas.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_Salidas.Name = "Btn_Salidas";
            this.Btn_Salidas.Size = new System.Drawing.Size(214, 106);
            this.Btn_Salidas.TabIndex = 3;
            this.Btn_Salidas.Text = "Revisión Salidas";
            this.Btn_Salidas.UseVisualStyleBackColor = true;
            this.Btn_Salidas.Click += new System.EventHandler(this.Btn_Salidas_Click);
            // 
            // Frm_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 363);
            this.Controls.Add(this.Btn_Salidas);
            this.Controls.Add(this.Btn_Record);
            this.Controls.Add(this.Btn_Revision);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Frm_Menu";
            this.Text = "Menú";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Btn_Revision;
        private System.Windows.Forms.Button Btn_Record;
        private System.Windows.Forms.Button Btn_Salidas;
    }
}