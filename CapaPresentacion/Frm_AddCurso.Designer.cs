
namespace CapaPresentacion
{
    partial class Frm_AddCurso
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
            this.Cb_creditos = new System.Windows.Forms.ComboBox();
            this.text_categoria = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_agregarCurso = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(177, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "CURSOS";
            // 
            // text_codigo
            // 
            this.text_codigo.Location = new System.Drawing.Point(43, 164);
            this.text_codigo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.text_codigo.Name = "text_codigo";
            this.text_codigo.Size = new System.Drawing.Size(449, 22);
            this.text_codigo.TabIndex = 1;
            // 
            // text_nombre
            // 
            this.text_nombre.Location = new System.Drawing.Point(43, 233);
            this.text_nombre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.text_nombre.Name = "text_nombre";
            this.text_nombre.Size = new System.Drawing.Size(449, 22);
            this.text_nombre.TabIndex = 2;
            // 
            // Cb_creditos
            // 
            this.Cb_creditos.FormattingEnabled = true;
            this.Cb_creditos.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.Cb_creditos.Location = new System.Drawing.Point(48, 335);
            this.Cb_creditos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Cb_creditos.Name = "Cb_creditos";
            this.Cb_creditos.Size = new System.Drawing.Size(180, 24);
            this.Cb_creditos.TabIndex = 3;
            // 
            // text_categoria
            // 
            this.text_categoria.Location = new System.Drawing.Point(280, 335);
            this.text_categoria.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.text_categoria.Name = "text_categoria";
            this.text_categoria.Size = new System.Drawing.Size(213, 22);
            this.text_categoria.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 127);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Codigo_curso";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 213);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Nombre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 293);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Creditos";
            // 
            // btn_agregarCurso
            // 
            this.btn_agregarCurso.BackColor = System.Drawing.Color.YellowGreen;
            this.btn_agregarCurso.Location = new System.Drawing.Point(185, 453);
            this.btn_agregarCurso.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_agregarCurso.Name = "btn_agregarCurso";
            this.btn_agregarCurso.Size = new System.Drawing.Size(155, 38);
            this.btn_agregarCurso.TabIndex = 8;
            this.btn_agregarCurso.Text = "AGREGAR";
            this.btn_agregarCurso.UseVisualStyleBackColor = false;
            this.btn_agregarCurso.Click += new System.EventHandler(this.btn_agregarCurso_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(277, 303);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Categoria";
            // 
            // Frm_AddCurso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 574);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_agregarCurso);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.text_categoria);
            this.Controls.Add(this.Cb_creditos);
            this.Controls.Add(this.text_nombre);
            this.Controls.Add(this.text_codigo);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Frm_AddCurso";
            this.Text = "Frm_AddCurso";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox text_codigo;
        private System.Windows.Forms.TextBox text_nombre;
        private System.Windows.Forms.ComboBox Cb_creditos;
        private System.Windows.Forms.TextBox text_categoria;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_agregarCurso;
        private System.Windows.Forms.Label label5;
    }
}