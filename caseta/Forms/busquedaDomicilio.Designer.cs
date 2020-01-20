namespace caseta
{
    partial class busquedaDomicilio
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
            this.Btn_Buscar = new System.Windows.Forms.Button();
            this.Gbx_Busqueda = new System.Windows.Forms.GroupBox();
            this.Tbx_Telefono = new System.Windows.Forms.TextBox();
            this.Lbl_Telefono = new System.Windows.Forms.Label();
            this.Tbx_Numero = new System.Windows.Forms.TextBox();
            this.Lbl_Numero = new System.Windows.Forms.Label();
            this.Tbx_Interior = new System.Windows.Forms.TextBox();
            this.Lbl_Interior = new System.Windows.Forms.Label();
            this.Tbx_Calle = new System.Windows.Forms.TextBox();
            this.Lbl_Calle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Gbx_Resultados = new System.Windows.Forms.GroupBox();
            this.Dgv_Domicilio = new System.Windows.Forms.DataGridView();
            this.Calle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Interior = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Observaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AceptaVisitas = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Seleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Gbx_Busqueda.SuspendLayout();
            this.Gbx_Resultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Domicilio)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_Buscar
            // 
            this.Btn_Buscar.Location = new System.Drawing.Point(535, 58);
            this.Btn_Buscar.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_Buscar.Name = "Btn_Buscar";
            this.Btn_Buscar.Size = new System.Drawing.Size(56, 19);
            this.Btn_Buscar.TabIndex = 0;
            this.Btn_Buscar.Text = "Buscar";
            this.Btn_Buscar.UseVisualStyleBackColor = true;
            this.Btn_Buscar.Click += new System.EventHandler(this.Btn_Buscar_Click);
            // 
            // Gbx_Busqueda
            // 
            this.Gbx_Busqueda.Controls.Add(this.Tbx_Telefono);
            this.Gbx_Busqueda.Controls.Add(this.Lbl_Telefono);
            this.Gbx_Busqueda.Controls.Add(this.Tbx_Numero);
            this.Gbx_Busqueda.Controls.Add(this.Lbl_Numero);
            this.Gbx_Busqueda.Controls.Add(this.Tbx_Interior);
            this.Gbx_Busqueda.Controls.Add(this.Lbl_Interior);
            this.Gbx_Busqueda.Controls.Add(this.Tbx_Calle);
            this.Gbx_Busqueda.Controls.Add(this.Lbl_Calle);
            this.Gbx_Busqueda.Controls.Add(this.label1);
            this.Gbx_Busqueda.Controls.Add(this.Btn_Buscar);
            this.Gbx_Busqueda.Dock = System.Windows.Forms.DockStyle.Top;
            this.Gbx_Busqueda.Location = new System.Drawing.Point(0, 0);
            this.Gbx_Busqueda.Margin = new System.Windows.Forms.Padding(2);
            this.Gbx_Busqueda.Name = "Gbx_Busqueda";
            this.Gbx_Busqueda.Padding = new System.Windows.Forms.Padding(2);
            this.Gbx_Busqueda.Size = new System.Drawing.Size(600, 81);
            this.Gbx_Busqueda.TabIndex = 1;
            this.Gbx_Busqueda.TabStop = false;
            this.Gbx_Busqueda.Text = "Busqueda";
            // 
            // Tbx_Telefono
            // 
            this.Tbx_Telefono.Location = new System.Drawing.Point(309, 42);
            this.Tbx_Telefono.Margin = new System.Windows.Forms.Padding(2);
            this.Tbx_Telefono.Name = "Tbx_Telefono";
            this.Tbx_Telefono.Size = new System.Drawing.Size(203, 20);
            this.Tbx_Telefono.TabIndex = 8;
            // 
            // Lbl_Telefono
            // 
            this.Lbl_Telefono.AutoSize = true;
            this.Lbl_Telefono.Location = new System.Drawing.Point(255, 45);
            this.Lbl_Telefono.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_Telefono.Name = "Lbl_Telefono";
            this.Lbl_Telefono.Size = new System.Drawing.Size(49, 13);
            this.Lbl_Telefono.TabIndex = 7;
            this.Lbl_Telefono.Text = "Teléfono";
            // 
            // Tbx_Numero
            // 
            this.Tbx_Numero.Location = new System.Drawing.Point(309, 17);
            this.Tbx_Numero.Margin = new System.Windows.Forms.Padding(2);
            this.Tbx_Numero.Name = "Tbx_Numero";
            this.Tbx_Numero.Size = new System.Drawing.Size(203, 20);
            this.Tbx_Numero.TabIndex = 6;
            // 
            // Lbl_Numero
            // 
            this.Lbl_Numero.AutoSize = true;
            this.Lbl_Numero.Location = new System.Drawing.Point(255, 20);
            this.Lbl_Numero.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_Numero.Name = "Lbl_Numero";
            this.Lbl_Numero.Size = new System.Drawing.Size(44, 13);
            this.Lbl_Numero.TabIndex = 5;
            this.Lbl_Numero.Text = "Numero";
            // 
            // Tbx_Interior
            // 
            this.Tbx_Interior.Location = new System.Drawing.Point(43, 42);
            this.Tbx_Interior.Margin = new System.Windows.Forms.Padding(2);
            this.Tbx_Interior.Name = "Tbx_Interior";
            this.Tbx_Interior.Size = new System.Drawing.Size(203, 20);
            this.Tbx_Interior.TabIndex = 4;
            // 
            // Lbl_Interior
            // 
            this.Lbl_Interior.AutoSize = true;
            this.Lbl_Interior.Location = new System.Drawing.Point(9, 45);
            this.Lbl_Interior.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_Interior.Name = "Lbl_Interior";
            this.Lbl_Interior.Size = new System.Drawing.Size(39, 13);
            this.Lbl_Interior.TabIndex = 3;
            this.Lbl_Interior.Text = "Interior";
            // 
            // Tbx_Calle
            // 
            this.Tbx_Calle.Location = new System.Drawing.Point(43, 17);
            this.Tbx_Calle.Margin = new System.Windows.Forms.Padding(2);
            this.Tbx_Calle.Name = "Tbx_Calle";
            this.Tbx_Calle.Size = new System.Drawing.Size(203, 20);
            this.Tbx_Calle.TabIndex = 2;
            // 
            // Lbl_Calle
            // 
            this.Lbl_Calle.AutoSize = true;
            this.Lbl_Calle.Location = new System.Drawing.Point(9, 20);
            this.Lbl_Calle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_Calle.Name = "Lbl_Calle";
            this.Lbl_Calle.Size = new System.Drawing.Size(30, 13);
            this.Lbl_Calle.TabIndex = 1;
            this.Lbl_Calle.Text = "Calle";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Calle";
            // 
            // Gbx_Resultados
            // 
            this.Gbx_Resultados.Controls.Add(this.Dgv_Domicilio);
            this.Gbx_Resultados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Gbx_Resultados.Location = new System.Drawing.Point(0, 81);
            this.Gbx_Resultados.Margin = new System.Windows.Forms.Padding(2);
            this.Gbx_Resultados.Name = "Gbx_Resultados";
            this.Gbx_Resultados.Padding = new System.Windows.Forms.Padding(2);
            this.Gbx_Resultados.Size = new System.Drawing.Size(600, 285);
            this.Gbx_Resultados.TabIndex = 2;
            this.Gbx_Resultados.TabStop = false;
            this.Gbx_Resultados.Text = "Resultados";
            // 
            // Dgv_Domicilio
            // 
            this.Dgv_Domicilio.AllowUserToAddRows = false;
            this.Dgv_Domicilio.AllowUserToDeleteRows = false;
            this.Dgv_Domicilio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_Domicilio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Calle,
            this.Numero,
            this.Interior,
            this.telefono,
            this.Observaciones,
            this.AceptaVisitas,
            this.Seleccionar});
            this.Dgv_Domicilio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dgv_Domicilio.Location = new System.Drawing.Point(2, 15);
            this.Dgv_Domicilio.Margin = new System.Windows.Forms.Padding(2);
            this.Dgv_Domicilio.Name = "Dgv_Domicilio";
            this.Dgv_Domicilio.ReadOnly = true;
            this.Dgv_Domicilio.RowTemplate.Height = 24;
            this.Dgv_Domicilio.Size = new System.Drawing.Size(596, 268);
            this.Dgv_Domicilio.TabIndex = 0;
            // 
            // Calle
            // 
            this.Calle.DataPropertyName = "Street";
            this.Calle.HeaderText = "Calle";
            this.Calle.Name = "Calle";
            this.Calle.ReadOnly = true;
            // 
            // Numero
            // 
            this.Numero.DataPropertyName = "OutNumber";
            this.Numero.HeaderText = "Numero";
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            // 
            // Interior
            // 
            this.Interior.DataPropertyName = "InNumber";
            this.Interior.HeaderText = "Interior";
            this.Interior.Name = "Interior";
            this.Interior.ReadOnly = true;
            // 
            // telefono
            // 
            this.telefono.HeaderText = "telefono";
            this.telefono.Name = "telefono";
            this.telefono.ReadOnly = true;
            // 
            // Observaciones
            // 
            this.Observaciones.HeaderText = "Observaciones";
            this.Observaciones.Name = "Observaciones";
            this.Observaciones.ReadOnly = true;
            // 
            // AceptaVisitas
            // 
            this.AceptaVisitas.HeaderText = "Acepta Visitas";
            this.AceptaVisitas.Name = "AceptaVisitas";
            this.AceptaVisitas.ReadOnly = true;
            this.AceptaVisitas.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "Seleccionar";
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.ReadOnly = true;
            // 
            // busquedaDomicilio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.Gbx_Resultados);
            this.Controls.Add(this.Gbx_Busqueda);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "busquedaDomicilio";
            this.Text = "busquedaDomicilio";
            this.Gbx_Busqueda.ResumeLayout(false);
            this.Gbx_Busqueda.PerformLayout();
            this.Gbx_Resultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Domicilio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_Buscar;
        private System.Windows.Forms.GroupBox Gbx_Busqueda;
        private System.Windows.Forms.GroupBox Gbx_Resultados;
        private System.Windows.Forms.DataGridView Dgv_Domicilio;
        private System.Windows.Forms.TextBox Tbx_Telefono;
        private System.Windows.Forms.Label Lbl_Telefono;
        private System.Windows.Forms.TextBox Tbx_Numero;
        private System.Windows.Forms.Label Lbl_Numero;
        private System.Windows.Forms.TextBox Tbx_Interior;
        private System.Windows.Forms.Label Lbl_Interior;
        private System.Windows.Forms.TextBox Tbx_Calle;
        private System.Windows.Forms.Label Lbl_Calle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Calle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Interior;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn Observaciones;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AceptaVisitas;
        private System.Windows.Forms.DataGridViewButtonColumn Seleccionar;
    }
}