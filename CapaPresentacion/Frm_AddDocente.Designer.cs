
namespace CapaPresentacion
{
    partial class Frm_AddDocente
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
            this.label1 = new System.Windows.Forms.Label();
            this.text_codigo = new System.Windows.Forms.TextBox();
            this.text_nombre = new System.Windows.Forms.TextBox();
            this.text_correo = new System.Windows.Forms.TextBox();
            this.btn_agregarDocente = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.text_materno = new System.Windows.Forms.TextBox();
            this.text_paterno = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.text_telefono = new System.Windows.Forms.TextBox();
            this.comboBox_regimen = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(124, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "DOCENTE";
            // 
            // text_codigo
            // 
            this.text_codigo.Location = new System.Drawing.Point(55, 59);
            this.text_codigo.Name = "text_codigo";
            this.text_codigo.Size = new System.Drawing.Size(279, 20);
            this.text_codigo.TabIndex = 1;
            // 
            // text_nombre
            // 
            this.text_nombre.Location = new System.Drawing.Point(55, 185);
            this.text_nombre.Name = "text_nombre";
            this.text_nombre.Size = new System.Drawing.Size(279, 20);
            this.text_nombre.TabIndex = 2;
            // 
            // text_correo
            // 
            this.text_correo.Location = new System.Drawing.Point(55, 271);
            this.text_correo.Name = "text_correo";
            this.text_correo.Size = new System.Drawing.Size(279, 20);
            this.text_correo.TabIndex = 4;
            // 
            // btn_agregarDocente
            // 
            this.btn_agregarDocente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(234)))), ((int)(((byte)(0)))));
            this.btn_agregarDocente.FlatAppearance.BorderSize = 0;
            this.btn_agregarDocente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_agregarDocente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_agregarDocente.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_agregarDocente.Location = new System.Drawing.Point(68, 354);
            this.btn_agregarDocente.Name = "btn_agregarDocente";
            this.btn_agregarDocente.Size = new System.Drawing.Size(250, 35);
            this.btn_agregarDocente.TabIndex = 5;
            this.btn_agregarDocente.Text = "AGREGAR";
            this.btn_agregarDocente.UseVisualStyleBackColor = false;
            this.btn_agregarDocente.Click += new System.EventHandler(this.btn_agregarDocente_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Codigo_Docente";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Nombres";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 255);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Correo";
            // 
            // text_materno
            // 
            this.text_materno.Location = new System.Drawing.Point(55, 146);
            this.text_materno.Name = "text_materno";
            this.text_materno.Size = new System.Drawing.Size(279, 20);
            this.text_materno.TabIndex = 10;
            // 
            // text_paterno
            // 
            this.text_paterno.Location = new System.Drawing.Point(55, 103);
            this.text_paterno.Name = "text_paterno";
            this.text_paterno.Size = new System.Drawing.Size(279, 20);
            this.text_paterno.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(52, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Paterno";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(52, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Materno";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(52, 210);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Regimen";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(52, 299);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Telefono";
            // 
            // text_telefono
            // 
            this.text_telefono.Location = new System.Drawing.Point(55, 315);
            this.text_telefono.Name = "text_telefono";
            this.text_telefono.Size = new System.Drawing.Size(279, 20);
            this.text_telefono.TabIndex = 16;
            // 
            // comboBox_regimen
            // 
            this.comboBox_regimen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_regimen.FormattingEnabled = true;
            this.comboBox_regimen.Location = new System.Drawing.Point(55, 231);
            this.comboBox_regimen.Name = "comboBox_regimen";
            this.comboBox_regimen.Size = new System.Drawing.Size(279, 21);
            this.comboBox_regimen.TabIndex = 18;
            // 
            // Frm_AddDocente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(407, 414);
            this.Controls.Add(this.comboBox_regimen);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.text_telefono);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.text_paterno);
            this.Controls.Add(this.text_materno);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_agregarDocente);
            this.Controls.Add(this.text_correo);
            this.Controls.Add(this.text_nombre);
            this.Controls.Add(this.text_codigo);
            this.Controls.Add(this.label1);
            this.Name = "Frm_AddDocente";
            this.Text = "Frm_AddDocente";
            this.Load += new System.EventHandler(this.Frm_AddDocente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox text_codigo;
        private System.Windows.Forms.TextBox text_nombre;
        private System.Windows.Forms.TextBox text_correo;
        private System.Windows.Forms.Button btn_agregarDocente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox text_materno;
        private System.Windows.Forms.TextBox text_paterno;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox text_telefono;
        private System.Windows.Forms.ComboBox comboBox_regimen;
    }
}