namespace CapaPresentacion
{
    partial class C_Alumno
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvAlumnos = new System.Windows.Forms.DataGridView();
            this.btnSubir = new System.Windows.Forms.Button();
            this.rTBSubirAlumnos = new System.Windows.Forms.RichTextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAlumnos
            // 
            this.dgvAlumnos.AllowUserToAddRows = false;
            this.dgvAlumnos.AllowUserToDeleteRows = false;
            this.dgvAlumnos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAlumnos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvAlumnos.BackgroundColor = System.Drawing.Color.White;
            this.dgvAlumnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlumnos.Location = new System.Drawing.Point(10, 80);
            this.dgvAlumnos.Name = "dgvAlumnos";
            this.dgvAlumnos.Size = new System.Drawing.Size(780, 370);
            this.dgvAlumnos.TabIndex = 0;
            // 
            // btnSubir
            // 
            this.btnSubir.Location = new System.Drawing.Point(86, 29);
            this.btnSubir.Name = "btnSubir";
            this.btnSubir.Size = new System.Drawing.Size(75, 23);
            this.btnSubir.TabIndex = 1;
            this.btnSubir.Text = "Subir Lista Alumnos";
            this.btnSubir.UseVisualStyleBackColor = true;
            this.btnSubir.Click += new System.EventHandler(this.btnSubir_Click);
            // 
            // rTBSubirAlumnos
            // 
            this.rTBSubirAlumnos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rTBSubirAlumnos.Location = new System.Drawing.Point(10, 80);
            this.rTBSubirAlumnos.Name = "rTBSubirAlumnos";
            this.rTBSubirAlumnos.Size = new System.Drawing.Size(780, 370);
            this.rTBSubirAlumnos.TabIndex = 2;
            this.rTBSubirAlumnos.Text = "";
            this.rTBSubirAlumnos.Visible = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Location = new System.Drawing.Point(686, 29);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Visible = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnAtras
            // 
            this.btnAtras.BackColor = System.Drawing.Color.White;
            this.btnAtras.FlatAppearance.BorderSize = 0;
            this.btnAtras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtras.Location = new System.Drawing.Point(0, 0);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(80, 80);
            this.btnAtras.TabIndex = 4;
            this.btnAtras.Text = "Atras";
            this.btnAtras.UseVisualStyleBackColor = false;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // C_Alumno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.rTBSubirAlumnos);
            this.Controls.Add(this.btnSubir);
            this.Controls.Add(this.dgvAlumnos);
            this.Name = "C_Alumno";
            this.Size = new System.Drawing.Size(800, 450);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAlumnos;
        private System.Windows.Forms.Button btnSubir;
        private System.Windows.Forms.RichTextBox rTBSubirAlumnos;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnAtras;
    }
}
