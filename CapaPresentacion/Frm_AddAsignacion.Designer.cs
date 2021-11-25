namespace CapaPresentacion
{
    partial class Frm_AddAsignacion
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnAgregarAsignacion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(99, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(185, 37);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Asignacion";
            // 
            // btnAgregarAsignacion
            // 
            this.btnAgregarAsignacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(234)))), ((int)(((byte)(0)))));
            this.btnAgregarAsignacion.FlatAppearance.BorderSize = 0;
            this.btnAgregarAsignacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarAsignacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarAsignacion.Location = new System.Drawing.Point(70, 305);
            this.btnAgregarAsignacion.Name = "btnAgregarAsignacion";
            this.btnAgregarAsignacion.Size = new System.Drawing.Size(250, 35);
            this.btnAgregarAsignacion.TabIndex = 1;
            this.btnAgregarAsignacion.Text = "AGREGAR";
            this.btnAgregarAsignacion.UseVisualStyleBackColor = false;
            // 
            // Frm_AddAsignacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(410, 450);
            this.Controls.Add(this.btnAgregarAsignacion);
            this.Controls.Add(this.lblTitulo);
            this.Name = "Frm_AddAsignacion";
            this.Text = "Frm_AddAsignacion";
            this.Load += new System.EventHandler(this.Frm_AddAsignacion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnAgregarAsignacion;
    }
}