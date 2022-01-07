namespace CapaPresentacion
{
    partial class C_Tarjeta
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
            this.btnControl = new System.Windows.Forms.Button();
            this.btnSilabo = new System.Windows.Forms.Button();
            this.panelTitulo = new System.Windows.Forms.Panel();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelTitulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnControl
            // 
            this.btnControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(170)))), ((int)(((byte)(211)))));
            this.btnControl.FlatAppearance.BorderSize = 0;
            this.btnControl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnControl.ForeColor = System.Drawing.Color.White;
            this.btnControl.Location = new System.Drawing.Point(170, 115);
            this.btnControl.Name = "btnControl";
            this.btnControl.Size = new System.Drawing.Size(80, 25);
            this.btnControl.TabIndex = 1;
            this.btnControl.Text = "CONTROL";
            this.btnControl.UseVisualStyleBackColor = false;
            this.btnControl.Click += new System.EventHandler(this.btnControl_Click);
            // 
            // btnSilabo
            // 
            this.btnSilabo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSilabo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(234)))), ((int)(((byte)(0)))));
            this.btnSilabo.FlatAppearance.BorderSize = 0;
            this.btnSilabo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSilabo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSilabo.ForeColor = System.Drawing.Color.White;
            this.btnSilabo.Location = new System.Drawing.Point(30, 115);
            this.btnSilabo.Name = "btnSilabo";
            this.btnSilabo.Size = new System.Drawing.Size(80, 25);
            this.btnSilabo.TabIndex = 2;
            this.btnSilabo.Text = "SILABO";
            this.btnSilabo.UseVisualStyleBackColor = false;
            this.btnSilabo.Click += new System.EventHandler(this.btnSilabo_Click);
            // 
            // panelTitulo
            // 
            this.panelTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTitulo.BackColor = System.Drawing.Color.Teal;
            this.panelTitulo.Controls.Add(this.lblCodigo);
            this.panelTitulo.Controls.Add(this.lblTitulo);
            this.panelTitulo.Location = new System.Drawing.Point(0, 0);
            this.panelTitulo.Name = "panelTitulo";
            this.panelTitulo.Size = new System.Drawing.Size(280, 75);
            this.panelTitulo.TabIndex = 3;
            // 
            // lblCodigo
            // 
            this.lblCodigo.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.ForeColor = System.Drawing.Color.White;
            this.lblCodigo.Location = new System.Drawing.Point(5, 55);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(270, 20);
            this.lblCodigo.TabIndex = 2;
            this.lblCodigo.Text = "Codigo";
            this.lblCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblTitulo.Location = new System.Drawing.Point(5, 0);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(5);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(270, 50);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Planeamiento y direccion estrategica de tecnologias de la informacion";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // C_Tarjeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelTitulo);
            this.Controls.Add(this.btnSilabo);
            this.Controls.Add(this.btnControl);
            this.Name = "C_Tarjeta";
            this.Size = new System.Drawing.Size(280, 150);
            this.Load += new System.EventHandler(this.C_Tarjeta_Load);
            this.panelTitulo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnControl;
        private System.Windows.Forms.Button btnSilabo;
        private System.Windows.Forms.Panel panelTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblCodigo;
    }
}
