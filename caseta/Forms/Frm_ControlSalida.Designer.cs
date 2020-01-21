namespace caseta.Forms
{
    partial class Frm_ControlSalida
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
            this.MS_Salidas = new System.Windows.Forms.MenuStrip();
            this.MItem_SalidaVisita = new System.Windows.Forms.ToolStripMenuItem();
            this.MS_Salidas.SuspendLayout();
            this.SuspendLayout();
            // 
            // MS_Salidas
            // 
            this.MS_Salidas.Dock = System.Windows.Forms.DockStyle.Left;
            this.MS_Salidas.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MS_Salidas.GripMargin = new System.Windows.Forms.Padding(2);
            this.MS_Salidas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MItem_SalidaVisita});
            this.MS_Salidas.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.MS_Salidas.Location = new System.Drawing.Point(0, 0);
            this.MS_Salidas.Name = "MS_Salidas";
            this.MS_Salidas.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.MS_Salidas.Size = new System.Drawing.Size(129, 754);
            this.MS_Salidas.TabIndex = 6;
            this.MS_Salidas.Text = "menuStrip1";
            // 
            // MItem_SalidaVisita
            // 
            this.MItem_SalidaVisita.Name = "MItem_SalidaVisita";
            this.MItem_SalidaVisita.Size = new System.Drawing.Size(75, 19);
            this.MItem_SalidaVisita.Text = "Salidas Visita";
            this.MItem_SalidaVisita.Click += new System.EventHandler(this.MItem_SalidaVisita_Click);
            // 
            // Frm_ControlSalida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1575, 754);
            this.Controls.Add(this.MS_Salidas);
            this.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MS_Salidas;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Frm_ControlSalida";
            this.Text = "MS_Menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MS_Salidas.ResumeLayout(false);
            this.MS_Salidas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip MS_Salidas;
        private System.Windows.Forms.ToolStripMenuItem MItem_SalidaVisita;
    }
}