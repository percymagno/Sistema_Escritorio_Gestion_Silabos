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
            this.tbID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.lblSemestre = new System.Windows.Forms.Label();
            this.cboxDocente = new System.Windows.Forms.ComboBox();
            this.cboxCurso = new System.Windows.Forms.ComboBox();
            this.lblCurso = new System.Windows.Forms.Label();
            this.lblDocente = new System.Windows.Forms.Label();
            this.cboxTipo = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblGrupo = new System.Windows.Forms.Label();
            this.cboxGrupo = new System.Windows.Forms.ComboBox();
            this.lblHT = new System.Windows.Forms.Label();
            this.lblHP = new System.Windows.Forms.Label();
            this.cboxDia = new System.Windows.Forms.ComboBox();
            this.lblDia = new System.Windows.Forms.Label();
            this.lblAula = new System.Windows.Forms.Label();
            this.tbAula = new System.Windows.Forms.TextBox();
            this.lblHR_inicio = new System.Windows.Forms.Label();
            this.lblHR_fin = new System.Windows.Forms.Label();
            this.numHR_inicio = new System.Windows.Forms.NumericUpDown();
            this.numHR_fin = new System.Windows.Forms.NumericUpDown();
            this.numHT = new System.Windows.Forms.NumericUpDown();
            this.numHP = new System.Windows.Forms.NumericUpDown();
            this.tbSemestre = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numHR_inicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHR_fin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHP)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(111, 6);
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
            this.btnAgregarAsignacion.Location = new System.Drawing.Point(79, 355);
            this.btnAgregarAsignacion.Name = "btnAgregarAsignacion";
            this.btnAgregarAsignacion.Size = new System.Drawing.Size(250, 35);
            this.btnAgregarAsignacion.TabIndex = 1;
            this.btnAgregarAsignacion.Text = "AGREGAR";
            this.btnAgregarAsignacion.UseVisualStyleBackColor = false;
            this.btnAgregarAsignacion.Click += new System.EventHandler(this.btnAgregarAsignacion_Click);
            // 
            // tbID
            // 
            this.tbID.Enabled = false;
            this.tbID.Location = new System.Drawing.Point(40, 79);
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(151, 20);
            this.tbID.TabIndex = 2;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(37, 63);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(18, 13);
            this.lblID.TabIndex = 3;
            this.lblID.Text = "ID";
            // 
            // lblSemestre
            // 
            this.lblSemestre.AutoSize = true;
            this.lblSemestre.Location = new System.Drawing.Point(211, 63);
            this.lblSemestre.Name = "lblSemestre";
            this.lblSemestre.Size = new System.Drawing.Size(51, 13);
            this.lblSemestre.TabIndex = 6;
            this.lblSemestre.Text = "Semestre";
            // 
            // cboxDocente
            // 
            this.cboxDocente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxDocente.FormattingEnabled = true;
            this.cboxDocente.Location = new System.Drawing.Point(40, 125);
            this.cboxDocente.Name = "cboxDocente";
            this.cboxDocente.Size = new System.Drawing.Size(150, 21);
            this.cboxDocente.TabIndex = 7;
            // 
            // cboxCurso
            // 
            this.cboxCurso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxCurso.FormattingEnabled = true;
            this.cboxCurso.Location = new System.Drawing.Point(214, 125);
            this.cboxCurso.Name = "cboxCurso";
            this.cboxCurso.Size = new System.Drawing.Size(150, 21);
            this.cboxCurso.TabIndex = 8;
            // 
            // lblCurso
            // 
            this.lblCurso.AutoSize = true;
            this.lblCurso.Location = new System.Drawing.Point(211, 109);
            this.lblCurso.Name = "lblCurso";
            this.lblCurso.Size = new System.Drawing.Size(70, 13);
            this.lblCurso.TabIndex = 9;
            this.lblCurso.Text = "Codigo Curso";
            // 
            // lblDocente
            // 
            this.lblDocente.AutoSize = true;
            this.lblDocente.Location = new System.Drawing.Point(37, 109);
            this.lblDocente.Name = "lblDocente";
            this.lblDocente.Size = new System.Drawing.Size(84, 13);
            this.lblDocente.TabIndex = 10;
            this.lblDocente.Text = "Codigo Docente";
            // 
            // cboxTipo
            // 
            this.cboxTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxTipo.FormattingEnabled = true;
            this.cboxTipo.Items.AddRange(new object[] {
            "T",
            "P"});
            this.cboxTipo.Location = new System.Drawing.Point(40, 172);
            this.cboxTipo.Name = "cboxTipo";
            this.cboxTipo.Size = new System.Drawing.Size(150, 21);
            this.cboxTipo.TabIndex = 11;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(37, 156);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(28, 13);
            this.lblTipo.TabIndex = 12;
            this.lblTipo.Text = "Tipo";
            // 
            // lblGrupo
            // 
            this.lblGrupo.AutoSize = true;
            this.lblGrupo.Location = new System.Drawing.Point(211, 156);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(36, 13);
            this.lblGrupo.TabIndex = 14;
            this.lblGrupo.Text = "Grupo";
            // 
            // cboxGrupo
            // 
            this.cboxGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxGrupo.FormattingEnabled = true;
            this.cboxGrupo.Items.AddRange(new object[] {
            "A",
            "B",
            "C"});
            this.cboxGrupo.Location = new System.Drawing.Point(214, 172);
            this.cboxGrupo.Name = "cboxGrupo";
            this.cboxGrupo.Size = new System.Drawing.Size(150, 21);
            this.cboxGrupo.TabIndex = 15;
            // 
            // lblHT
            // 
            this.lblHT.AutoSize = true;
            this.lblHT.Location = new System.Drawing.Point(37, 207);
            this.lblHT.Name = "lblHT";
            this.lblHT.Size = new System.Drawing.Size(79, 13);
            this.lblHT.TabIndex = 17;
            this.lblHT.Text = "Horas Teoricas";
            // 
            // lblHP
            // 
            this.lblHP.AutoSize = true;
            this.lblHP.Location = new System.Drawing.Point(211, 207);
            this.lblHP.Name = "lblHP";
            this.lblHP.Size = new System.Drawing.Size(82, 13);
            this.lblHP.TabIndex = 19;
            this.lblHP.Text = "Horas Practicas";
            // 
            // cboxDia
            // 
            this.cboxDia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxDia.FormattingEnabled = true;
            this.cboxDia.Items.AddRange(new object[] {
            "Lunes",
            "Martes",
            "Miercoles",
            "Jueves",
            "Viernes",
            "Sabado"});
            this.cboxDia.Location = new System.Drawing.Point(40, 258);
            this.cboxDia.Name = "cboxDia";
            this.cboxDia.Size = new System.Drawing.Size(150, 21);
            this.cboxDia.TabIndex = 20;
            // 
            // lblDia
            // 
            this.lblDia.AutoSize = true;
            this.lblDia.Location = new System.Drawing.Point(37, 242);
            this.lblDia.Name = "lblDia";
            this.lblDia.Size = new System.Drawing.Size(25, 13);
            this.lblDia.TabIndex = 21;
            this.lblDia.Text = "Día";
            // 
            // lblAula
            // 
            this.lblAula.AutoSize = true;
            this.lblAula.Location = new System.Drawing.Point(211, 242);
            this.lblAula.Name = "lblAula";
            this.lblAula.Size = new System.Drawing.Size(28, 13);
            this.lblAula.TabIndex = 22;
            this.lblAula.Text = "Aula";
            // 
            // tbAula
            // 
            this.tbAula.Location = new System.Drawing.Point(214, 258);
            this.tbAula.Name = "tbAula";
            this.tbAula.Size = new System.Drawing.Size(150, 20);
            this.tbAula.TabIndex = 23;
            // 
            // lblHR_inicio
            // 
            this.lblHR_inicio.AutoSize = true;
            this.lblHR_inicio.Location = new System.Drawing.Point(37, 295);
            this.lblHR_inicio.Name = "lblHR_inicio";
            this.lblHR_inicio.Size = new System.Drawing.Size(72, 13);
            this.lblHR_inicio.TabIndex = 25;
            this.lblHR_inicio.Text = "Hora de inicio";
            // 
            // lblHR_fin
            // 
            this.lblHR_fin.AutoSize = true;
            this.lblHR_fin.Location = new System.Drawing.Point(211, 295);
            this.lblHR_fin.Name = "lblHR_fin";
            this.lblHR_fin.Size = new System.Drawing.Size(59, 13);
            this.lblHR_fin.TabIndex = 26;
            this.lblHR_fin.Text = "Hora de fin";
            // 
            // numHR_inicio
            // 
            this.numHR_inicio.Location = new System.Drawing.Point(121, 293);
            this.numHR_inicio.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numHR_inicio.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numHR_inicio.Name = "numHR_inicio";
            this.numHR_inicio.Size = new System.Drawing.Size(70, 20);
            this.numHR_inicio.TabIndex = 28;
            this.numHR_inicio.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // numHR_fin
            // 
            this.numHR_fin.Location = new System.Drawing.Point(294, 293);
            this.numHR_fin.Maximum = new decimal(new int[] {
            21,
            0,
            0,
            0});
            this.numHR_fin.Minimum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numHR_fin.Name = "numHR_fin";
            this.numHR_fin.Size = new System.Drawing.Size(70, 20);
            this.numHR_fin.TabIndex = 29;
            this.numHR_fin.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // numHT
            // 
            this.numHT.Location = new System.Drawing.Point(121, 205);
            this.numHT.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numHT.Name = "numHT";
            this.numHT.Size = new System.Drawing.Size(70, 20);
            this.numHT.TabIndex = 30;
            this.numHT.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numHP
            // 
            this.numHP.Location = new System.Drawing.Point(294, 205);
            this.numHP.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numHP.Name = "numHP";
            this.numHP.Size = new System.Drawing.Size(70, 20);
            this.numHP.TabIndex = 31;
            this.numHP.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tbSemestre
            // 
            this.tbSemestre.Enabled = false;
            this.tbSemestre.Location = new System.Drawing.Point(214, 79);
            this.tbSemestre.Name = "tbSemestre";
            this.tbSemestre.Size = new System.Drawing.Size(150, 20);
            this.tbSemestre.TabIndex = 32;
            // 
            // Frm_AddAsignacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(404, 413);
            this.Controls.Add(this.tbSemestre);
            this.Controls.Add(this.numHP);
            this.Controls.Add(this.numHT);
            this.Controls.Add(this.numHR_fin);
            this.Controls.Add(this.numHR_inicio);
            this.Controls.Add(this.lblHR_fin);
            this.Controls.Add(this.lblHR_inicio);
            this.Controls.Add(this.tbAula);
            this.Controls.Add(this.lblAula);
            this.Controls.Add(this.lblDia);
            this.Controls.Add(this.cboxDia);
            this.Controls.Add(this.lblHP);
            this.Controls.Add(this.lblHT);
            this.Controls.Add(this.cboxGrupo);
            this.Controls.Add(this.lblGrupo);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.cboxTipo);
            this.Controls.Add(this.lblDocente);
            this.Controls.Add(this.lblCurso);
            this.Controls.Add(this.cboxCurso);
            this.Controls.Add(this.cboxDocente);
            this.Controls.Add(this.lblSemestre);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.tbID);
            this.Controls.Add(this.btnAgregarAsignacion);
            this.Controls.Add(this.lblTitulo);
            this.Name = "Frm_AddAsignacion";
            this.Text = "Frm_AddAsignacion";
            ((System.ComponentModel.ISupportInitialize)(this.numHR_inicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHR_fin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnAgregarAsignacion;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblSemestre;
        private System.Windows.Forms.ComboBox cboxDocente;
        private System.Windows.Forms.ComboBox cboxCurso;
        private System.Windows.Forms.Label lblCurso;
        private System.Windows.Forms.Label lblDocente;
        private System.Windows.Forms.ComboBox cboxTipo;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblGrupo;
        private System.Windows.Forms.ComboBox cboxGrupo;
        private System.Windows.Forms.Label lblHT;
        private System.Windows.Forms.Label lblHP;
        private System.Windows.Forms.ComboBox cboxDia;
        private System.Windows.Forms.Label lblDia;
        private System.Windows.Forms.Label lblAula;
        private System.Windows.Forms.TextBox tbAula;
        private System.Windows.Forms.Label lblHR_inicio;
        private System.Windows.Forms.Label lblHR_fin;
        private System.Windows.Forms.NumericUpDown numHR_inicio;
        private System.Windows.Forms.NumericUpDown numHR_fin;
        private System.Windows.Forms.NumericUpDown numHT;
        private System.Windows.Forms.NumericUpDown numHP;
        private System.Windows.Forms.TextBox tbSemestre;
    }
}