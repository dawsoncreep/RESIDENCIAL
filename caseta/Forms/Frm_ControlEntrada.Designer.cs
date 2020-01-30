namespace caseta.Forms
{
    partial class Frm_ControlEntrada
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
            this.MS_Menu = new System.Windows.Forms.MenuStrip();
            this.Menu_IngresoTag = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_IngresoVisita = new System.Windows.Forms.ToolStripMenuItem();
            this.MS_Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MS_Menu
            // 
            this.MS_Menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.MS_Menu.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MS_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_IngresoTag,
            this.Menu_IngresoVisita});
            this.MS_Menu.Location = new System.Drawing.Point(0, 0);
            this.MS_Menu.Name = "MS_Menu";
            this.MS_Menu.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.MS_Menu.Size = new System.Drawing.Size(132, 841);
            this.MS_Menu.TabIndex = 1;
            this.MS_Menu.Text = "menuStrip1";
            // 
            // Menu_IngresoTag
            // 
            this.Menu_IngresoTag.Name = "Menu_IngresoTag";
            this.Menu_IngresoTag.Size = new System.Drawing.Size(117, 27);
            this.Menu_IngresoTag.Text = "Ingreso Tag";
            this.Menu_IngresoTag.Click += new System.EventHandler(this.Menu_IngresoTag_Click);
            // 
            // Menu_IngresoVisita
            // 
            this.Menu_IngresoVisita.Name = "Menu_IngresoVisita";
            this.Menu_IngresoVisita.Size = new System.Drawing.Size(117, 27);
            this.Menu_IngresoVisita.Text = "Ingreso Visita";
            this.Menu_IngresoVisita.Click += new System.EventHandler(this.Menu_IngresoVisita_Click);
            // 
            // Frm_ControlEntrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1575, 841);
            this.Controls.Add(this.MS_Menu);
            this.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MS_Menu;
            this.Name = "Frm_ControlEntrada";
            this.Text = "Control de Entrada";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MS_Menu.ResumeLayout(false);
            this.MS_Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MS_Menu;
        private System.Windows.Forms.ToolStripMenuItem Menu_IngresoTag;
        private System.Windows.Forms.ToolStripMenuItem Menu_IngresoVisita;
    }
}