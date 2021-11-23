
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.text_codigo = new System.Windows.Forms.TextBox();
            this.text_nombre = new System.Windows.Forms.TextBox();
            this.Cb_creditos = new System.Windows.Forms.ComboBox();
            this.text_categoria = new System.Windows.Forms.TextBox();
            this.lblCodCurso = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblCreditos = new System.Windows.Forms.Label();
            this.btn_agregarCurso = new System.Windows.Forms.Button();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(154, 1);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(136, 37);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "CURSO";
            // 
            // text_codigo
            // 
            this.text_codigo.Location = new System.Drawing.Point(34, 57);
            this.text_codigo.Name = "text_codigo";
            this.text_codigo.Size = new System.Drawing.Size(362, 20);
            this.text_codigo.TabIndex = 1;
            // 
            // text_nombre
            // 
            this.text_nombre.Location = new System.Drawing.Point(34, 101);
            this.text_nombre.Name = "text_nombre";
            this.text_nombre.Size = new System.Drawing.Size(362, 20);
            this.text_nombre.TabIndex = 2;
            // 
            // Cb_creditos
            // 
            this.Cb_creditos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cb_creditos.FormattingEnabled = true;
            this.Cb_creditos.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5"});
            this.Cb_creditos.Location = new System.Drawing.Point(34, 149);
            this.Cb_creditos.Name = "Cb_creditos";
            this.Cb_creditos.Size = new System.Drawing.Size(136, 21);
            this.Cb_creditos.TabIndex = 3;
            // 
            // text_categoria
            // 
            this.text_categoria.Location = new System.Drawing.Point(235, 149);
            this.text_categoria.Name = "text_categoria";
            this.text_categoria.Size = new System.Drawing.Size(161, 20);
            this.text_categoria.TabIndex = 4;
            // 
            // lblCodCurso
            // 
            this.lblCodCurso.AutoSize = true;
            this.lblCodCurso.Location = new System.Drawing.Point(31, 41);
            this.lblCodCurso.Name = "lblCodCurso";
            this.lblCodCurso.Size = new System.Drawing.Size(73, 13);
            this.lblCodCurso.TabIndex = 5;
            this.lblCodCurso.Text = "Codigo curso*";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(31, 85);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(48, 13);
            this.lblNombre.TabIndex = 6;
            this.lblNombre.Text = "Nombre*";
            // 
            // lblCreditos
            // 
            this.lblCreditos.AutoSize = true;
            this.lblCreditos.Location = new System.Drawing.Point(31, 133);
            this.lblCreditos.Name = "lblCreditos";
            this.lblCreditos.Size = new System.Drawing.Size(45, 13);
            this.lblCreditos.TabIndex = 7;
            this.lblCreditos.Text = "Creditos";
            // 
            // btn_agregarCurso
            // 
            this.btn_agregarCurso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(234)))), ((int)(((byte)(0)))));
            this.btn_agregarCurso.FlatAppearance.BorderSize = 0;
            this.btn_agregarCurso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_agregarCurso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_agregarCurso.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_agregarCurso.Location = new System.Drawing.Point(97, 205);
            this.btn_agregarCurso.Name = "btn_agregarCurso";
            this.btn_agregarCurso.Size = new System.Drawing.Size(250, 35);
            this.btn_agregarCurso.TabIndex = 8;
            this.btn_agregarCurso.Text = "AGREGAR";
            this.btn_agregarCurso.UseVisualStyleBackColor = false;
            this.btn_agregarCurso.Click += new System.EventHandler(this.btn_agregarCurso_Click);
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(232, 133);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(52, 13);
            this.lblCategoria.TabIndex = 9;
            this.lblCategoria.Text = "Categoria";
            // 
            // Frm_AddCurso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(429, 263);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.btn_agregarCurso);
            this.Controls.Add(this.lblCreditos);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblCodCurso);
            this.Controls.Add(this.text_categoria);
            this.Controls.Add(this.Cb_creditos);
            this.Controls.Add(this.text_nombre);
            this.Controls.Add(this.text_codigo);
            this.MaximizeBox = false;
            this.Name = "Frm_AddCurso";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox text_codigo;
        private System.Windows.Forms.TextBox text_nombre;
        private System.Windows.Forms.ComboBox Cb_creditos;
        private System.Windows.Forms.TextBox text_categoria;
        private System.Windows.Forms.Label lblCodCurso;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblCreditos;
        private System.Windows.Forms.Button btn_agregarCurso;
        private System.Windows.Forms.Label lblCategoria;
    }
}