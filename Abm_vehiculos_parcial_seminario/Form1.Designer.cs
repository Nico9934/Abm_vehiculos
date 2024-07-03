namespace Abm_vehiculos_parcial_seminario
{
	partial class Form_principal
	{
		/// <summary>
		/// Variable del diseñador necesaria.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpiar los recursos que se estén usando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código generado por el Diseñador de Windows Forms

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido de este método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btn_vehicles_down = new System.Windows.Forms.Button();
			this.btn_getDataVehicles = new System.Windows.Forms.Button();
			this.btn_updateVehicle = new System.Windows.Forms.Button();
			this.btn_unsubscribeVehicle = new System.Windows.Forms.Button();
			this.btn_newVehicle = new System.Windows.Forms.Button();
			this.header_panel = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.dgv_data = new System.Windows.Forms.DataGridView();
			this.panel1.SuspendLayout();
			this.header_panel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv_data)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(32)))), ((int)(((byte)(71)))));
			this.panel1.Controls.Add(this.btn_vehicles_down);
			this.panel1.Controls.Add(this.btn_getDataVehicles);
			this.panel1.Controls.Add(this.btn_updateVehicle);
			this.panel1.Controls.Add(this.btn_unsubscribeVehicle);
			this.panel1.Controls.Add(this.btn_newVehicle);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(284, 626);
			this.panel1.TabIndex = 4;
			// 
			// btn_vehicles_down
			// 
			this.btn_vehicles_down.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_vehicles_down.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(32)))), ((int)(((byte)(71)))));
			this.btn_vehicles_down.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(91)))), ((int)(((byte)(97)))));
			this.btn_vehicles_down.FlatAppearance.BorderSize = 0;
			this.btn_vehicles_down.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_vehicles_down.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_vehicles_down.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.btn_vehicles_down.Location = new System.Drawing.Point(2, 429);
			this.btn_vehicles_down.Name = "btn_vehicles_down";
			this.btn_vehicles_down.Size = new System.Drawing.Size(279, 52);
			this.btn_vehicles_down.TabIndex = 6;
			this.btn_vehicles_down.Text = "Vehiculos archivados";
			this.btn_vehicles_down.UseVisualStyleBackColor = false;
			this.btn_vehicles_down.Click += new System.EventHandler(this.btn_vehicles_down_Click);
			this.btn_vehicles_down.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
			this.btn_vehicles_down.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
			// 
			// btn_getDataVehicles
			// 
			this.btn_getDataVehicles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_getDataVehicles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(32)))), ((int)(((byte)(71)))));
			this.btn_getDataVehicles.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(91)))), ((int)(((byte)(97)))));
			this.btn_getDataVehicles.FlatAppearance.BorderSize = 0;
			this.btn_getDataVehicles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_getDataVehicles.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_getDataVehicles.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.btn_getDataVehicles.Location = new System.Drawing.Point(4, 195);
			this.btn_getDataVehicles.Name = "btn_getDataVehicles";
			this.btn_getDataVehicles.Size = new System.Drawing.Size(279, 52);
			this.btn_getDataVehicles.TabIndex = 5;
			this.btn_getDataVehicles.Text = "Ver vehiculos";
			this.btn_getDataVehicles.UseVisualStyleBackColor = false;
			this.btn_getDataVehicles.Click += new System.EventHandler(this.btn_getDataVehicles_Click);
			this.btn_getDataVehicles.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
			this.btn_getDataVehicles.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
			// 
			// btn_updateVehicle
			// 
			this.btn_updateVehicle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_updateVehicle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(32)))), ((int)(((byte)(71)))));
			this.btn_updateVehicle.FlatAppearance.BorderSize = 0;
			this.btn_updateVehicle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_updateVehicle.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
			this.btn_updateVehicle.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.btn_updateVehicle.Location = new System.Drawing.Point(0, 368);
			this.btn_updateVehicle.Name = "btn_updateVehicle";
			this.btn_updateVehicle.Size = new System.Drawing.Size(283, 55);
			this.btn_updateVehicle.TabIndex = 4;
			this.btn_updateVehicle.Text = "Actualizar vehiculo";
			this.btn_updateVehicle.UseVisualStyleBackColor = false;
			this.btn_updateVehicle.Click += new System.EventHandler(this.btn_updateVehicle_Click);
			this.btn_updateVehicle.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
			this.btn_updateVehicle.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
			// 
			// btn_unsubscribeVehicle
			// 
			this.btn_unsubscribeVehicle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_unsubscribeVehicle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(32)))), ((int)(((byte)(71)))));
			this.btn_unsubscribeVehicle.FlatAppearance.BorderSize = 0;
			this.btn_unsubscribeVehicle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_unsubscribeVehicle.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
			this.btn_unsubscribeVehicle.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.btn_unsubscribeVehicle.Location = new System.Drawing.Point(3, 311);
			this.btn_unsubscribeVehicle.Name = "btn_unsubscribeVehicle";
			this.btn_unsubscribeVehicle.Size = new System.Drawing.Size(280, 51);
			this.btn_unsubscribeVehicle.TabIndex = 3;
			this.btn_unsubscribeVehicle.Text = "Dar de baja vehiculo";
			this.btn_unsubscribeVehicle.UseVisualStyleBackColor = false;
			this.btn_unsubscribeVehicle.Click += new System.EventHandler(this.btn_unsubscribeVehicle_Click);
			this.btn_unsubscribeVehicle.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
			this.btn_unsubscribeVehicle.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
			// 
			// btn_newVehicle
			// 
			this.btn_newVehicle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_newVehicle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(32)))), ((int)(((byte)(71)))));
			this.btn_newVehicle.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(91)))), ((int)(((byte)(97)))));
			this.btn_newVehicle.FlatAppearance.BorderSize = 0;
			this.btn_newVehicle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_newVehicle.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_newVehicle.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.btn_newVehicle.Location = new System.Drawing.Point(0, 253);
			this.btn_newVehicle.Name = "btn_newVehicle";
			this.btn_newVehicle.Size = new System.Drawing.Size(283, 52);
			this.btn_newVehicle.TabIndex = 2;
			this.btn_newVehicle.Text = "Agregar vehiculo";
			this.btn_newVehicle.UseVisualStyleBackColor = false;
			this.btn_newVehicle.Click += new System.EventHandler(this.btn_newVehicle_Click);
			this.btn_newVehicle.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
			this.btn_newVehicle.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
			// 
			// header_panel
			// 
			this.header_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(27)))), ((int)(((byte)(63)))));
			this.header_panel.Controls.Add(this.label2);
			this.header_panel.Controls.Add(this.label1);
			this.header_panel.Dock = System.Windows.Forms.DockStyle.Top;
			this.header_panel.Location = new System.Drawing.Point(284, 0);
			this.header_panel.Name = "header_panel";
			this.header_panel.Size = new System.Drawing.Size(1010, 111);
			this.header_panel.TabIndex = 6;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.White;
			this.label2.Location = new System.Drawing.Point(75, 60);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(405, 21);
			this.label2.TabIndex = 5;
			this.label2.Text = "Organiza tus vehiculos de manera rapida y eficiente";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(72, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(287, 42);
			this.label1.TabIndex = 4;
			this.label1.Text = "Vehiculos - ABM";
			// 
			// dgv_data
			// 
			this.dgv_data.AllowUserToAddRows = false;
			this.dgv_data.AllowUserToResizeColumns = false;
			this.dgv_data.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgv_data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgv_data.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dgv_data.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(35)))), ((int)(((byte)(79)))));
			this.dgv_data.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dgv_data.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(79)))));
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
			dataGridViewCellStyle5.ForeColor = System.Drawing.Color.WhiteSmoke;
			dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(109)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgv_data.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
			this.dgv_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(35)))), ((int)(((byte)(79)))));
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 12F);
			dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(4, 8, 1, 8);
			dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(27)))), ((int)(((byte)(63)))));
			dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgv_data.DefaultCellStyle = dataGridViewCellStyle6;
			this.dgv_data.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(35)))), ((int)(((byte)(79)))));
			this.dgv_data.Location = new System.Drawing.Point(308, 132);
			this.dgv_data.Name = "dgv_data";
			this.dgv_data.ReadOnly = true;
			this.dgv_data.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			this.dgv_data.RowHeadersVisible = false;
			this.dgv_data.RowHeadersWidth = 62;
			this.dgv_data.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgv_data.RowTemplate.Height = 28;
			this.dgv_data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgv_data.Size = new System.Drawing.Size(965, 482);
			this.dgv_data.TabIndex = 7;
			this.dgv_data.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_data_CellMouseEnter);
			this.dgv_data.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_data_CellMouseLeave);
			this.dgv_data.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_data_RowPostPaint);
			this.dgv_data.SelectionChanged += new System.EventHandler(this.row_selectionChanged);
			// 
			// Form_principal
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(35)))), ((int)(((byte)(79)))));
			this.ClientSize = new System.Drawing.Size(1294, 626);
			this.Controls.Add(this.dgv_data);
			this.Controls.Add(this.header_panel);
			this.Controls.Add(this.panel1);
			this.Name = "Form_principal";
			this.Text = "Form_principal";
			this.panel1.ResumeLayout(false);
			this.header_panel.ResumeLayout(false);
			this.header_panel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv_data)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btn_updateVehicle;
		private System.Windows.Forms.Button btn_unsubscribeVehicle;
		private System.Windows.Forms.Button btn_newVehicle;
		private System.Windows.Forms.Panel header_panel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridView dgv_data;
		private System.Windows.Forms.Button btn_getDataVehicles;
		private System.Windows.Forms.Button btn_vehicles_down;
	}
}

