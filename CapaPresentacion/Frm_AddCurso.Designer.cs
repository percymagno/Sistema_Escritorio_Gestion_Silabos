
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
            this.lblCodDocente = new System.Windows.Forms.Label();
            this.cbDocente = new System.Windows.Forms.ComboBox();
            this.lblHorario = new System.Windows.Forms.Label();
            this.checkLunes = new System.Windows.Forms.CheckBox();
            this.numMartesFin = new System.Windows.Forms.NumericUpDown();
            this.numMartesIni = new System.Windows.Forms.NumericUpDown();
            this.checkMartes = new System.Windows.Forms.CheckBox();
            this.checkMiercoles = new System.Windows.Forms.CheckBox();
            this.checkJueves = new System.Windows.Forms.CheckBox();
            this.checkViernes = new System.Windows.Forms.CheckBox();
            this.checkSabado = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlLunes = new System.Windows.Forms.Panel();
            this.numLunesFin = new System.Windows.Forms.NumericUpDown();
            this.numLunesIni = new System.Windows.Forms.NumericUpDown();
            this.rbLunesPra = new System.Windows.Forms.RadioButton();
            this.rbLunesTeo = new System.Windows.Forms.RadioButton();
            this.pnlMartes = new System.Windows.Forms.Panel();
            this.rbMartesPra = new System.Windows.Forms.RadioButton();
            this.rbMartesTeo = new System.Windows.Forms.RadioButton();
            this.pnlMiercoles = new System.Windows.Forms.Panel();
            this.numMiercolesFin = new System.Windows.Forms.NumericUpDown();
            this.numMiercolesIni = new System.Windows.Forms.NumericUpDown();
            this.rbMiercolesPra = new System.Windows.Forms.RadioButton();
            this.rbMiercolesTeo = new System.Windows.Forms.RadioButton();
            this.pnlViernes = new System.Windows.Forms.Panel();
            this.numViernesFin = new System.Windows.Forms.NumericUpDown();
            this.numViernesIni = new System.Windows.Forms.NumericUpDown();
            this.rbViernesPra = new System.Windows.Forms.RadioButton();
            this.rbViernesTeo = new System.Windows.Forms.RadioButton();
            this.pnlSabado = new System.Windows.Forms.Panel();
            this.numSabadoFin = new System.Windows.Forms.NumericUpDown();
            this.numSabadoIni = new System.Windows.Forms.NumericUpDown();
            this.rbSabadoPra = new System.Windows.Forms.RadioButton();
            this.rbSabadoTeo = new System.Windows.Forms.RadioButton();
            this.pnlJueves = new System.Windows.Forms.Panel();
            this.numJuevesFin = new System.Windows.Forms.NumericUpDown();
            this.numJuevesIni = new System.Windows.Forms.NumericUpDown();
            this.rbJuevesPra = new System.Windows.Forms.RadioButton();
            this.rbJuevesTeo = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numMartesFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMartesIni)).BeginInit();
            this.pnlLunes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLunesFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLunesIni)).BeginInit();
            this.pnlMartes.SuspendLayout();
            this.pnlMiercoles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMiercolesFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMiercolesIni)).BeginInit();
            this.pnlViernes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numViernesFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numViernesIni)).BeginInit();
            this.pnlSabado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSabadoFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSabadoIni)).BeginInit();
            this.pnlJueves.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numJuevesFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numJuevesIni)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(177, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(136, 37);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "CURSO";
            // 
            // text_codigo
            // 
            this.text_codigo.Location = new System.Drawing.Point(34, 69);
            this.text_codigo.Name = "text_codigo";
            this.text_codigo.Size = new System.Drawing.Size(396, 20);
            this.text_codigo.TabIndex = 1;
            this.text_codigo.Enter += new System.EventHandler(this.text_codigo_Enter);
            // 
            // text_nombre
            // 
            this.text_nombre.Location = new System.Drawing.Point(34, 113);
            this.text_nombre.Name = "text_nombre";
            this.text_nombre.Size = new System.Drawing.Size(396, 20);
            this.text_nombre.TabIndex = 2;
            this.text_nombre.Enter += new System.EventHandler(this.text_nombre_Enter);
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
            this.Cb_creditos.Location = new System.Drawing.Point(34, 161);
            this.Cb_creditos.Name = "Cb_creditos";
            this.Cb_creditos.Size = new System.Drawing.Size(136, 21);
            this.Cb_creditos.TabIndex = 3;
            // 
            // text_categoria
            // 
            this.text_categoria.Location = new System.Drawing.Point(269, 161);
            this.text_categoria.Name = "text_categoria";
            this.text_categoria.Size = new System.Drawing.Size(161, 20);
            this.text_categoria.TabIndex = 4;
            // 
            // lblCodCurso
            // 
            this.lblCodCurso.AutoSize = true;
            this.lblCodCurso.Location = new System.Drawing.Point(31, 53);
            this.lblCodCurso.Name = "lblCodCurso";
            this.lblCodCurso.Size = new System.Drawing.Size(73, 13);
            this.lblCodCurso.TabIndex = 5;
            this.lblCodCurso.Text = "Codigo curso*";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(31, 97);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(48, 13);
            this.lblNombre.TabIndex = 6;
            this.lblNombre.Text = "Nombre*";
            // 
            // lblCreditos
            // 
            this.lblCreditos.AutoSize = true;
            this.lblCreditos.Location = new System.Drawing.Point(31, 145);
            this.lblCreditos.Name = "lblCreditos";
            this.lblCreditos.Size = new System.Drawing.Size(45, 13);
            this.lblCreditos.TabIndex = 7;
            this.lblCreditos.Text = "Creditos";
            // 
            // btn_agregarCurso
            // 
            this.btn_agregarCurso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(234)))), ((int)(((byte)(0)))));
            this.btn_agregarCurso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_agregarCurso.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_agregarCurso.Location = new System.Drawing.Point(120, 418);
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
            this.lblCategoria.Location = new System.Drawing.Point(266, 145);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(52, 13);
            this.lblCategoria.TabIndex = 9;
            this.lblCategoria.Text = "Categoria";
            // 
            // lblCodDocente
            // 
            this.lblCodDocente.AutoSize = true;
            this.lblCodDocente.Location = new System.Drawing.Point(31, 215);
            this.lblCodDocente.Name = "lblCodDocente";
            this.lblCodDocente.Size = new System.Drawing.Size(84, 13);
            this.lblCodDocente.TabIndex = 10;
            this.lblCodDocente.Text = "Codigo Docente";
            // 
            // cbDocente
            // 
            this.cbDocente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDocente.FormattingEnabled = true;
            this.cbDocente.Location = new System.Drawing.Point(34, 231);
            this.cbDocente.Name = "cbDocente";
            this.cbDocente.Size = new System.Drawing.Size(136, 21);
            this.cbDocente.TabIndex = 11;
            // 
            // lblHorario
            // 
            this.lblHorario.AutoSize = true;
            this.lblHorario.Location = new System.Drawing.Point(31, 282);
            this.lblHorario.Name = "lblHorario";
            this.lblHorario.Size = new System.Drawing.Size(41, 13);
            this.lblHorario.TabIndex = 12;
            this.lblHorario.Text = "Horario";
            // 
            // checkLunes
            // 
            this.checkLunes.AutoSize = true;
            this.checkLunes.Location = new System.Drawing.Point(34, 318);
            this.checkLunes.Name = "checkLunes";
            this.checkLunes.Size = new System.Drawing.Size(44, 17);
            this.checkLunes.TabIndex = 14;
            this.checkLunes.Text = "Lun";
            this.checkLunes.UseVisualStyleBackColor = true;
            this.checkLunes.CheckedChanged += new System.EventHandler(this.checkLunes_CheckedChanged);
            // 
            // numMartesFin
            // 
            this.numMartesFin.Location = new System.Drawing.Point(46, 0);
            this.numMartesFin.Maximum = new decimal(new int[] {
            21,
            0,
            0,
            0});
            this.numMartesFin.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numMartesFin.Name = "numMartesFin";
            this.numMartesFin.Size = new System.Drawing.Size(40, 20);
            this.numMartesFin.TabIndex = 19;
            this.numMartesFin.Tag = "";
            this.numMartesFin.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numMartesFin.Enter += new System.EventHandler(this.numMartesFin_Enter);
            // 
            // numMartesIni
            // 
            this.numMartesIni.Location = new System.Drawing.Point(0, 0);
            this.numMartesIni.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numMartesIni.Minimum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numMartesIni.Name = "numMartesIni";
            this.numMartesIni.Size = new System.Drawing.Size(40, 20);
            this.numMartesIni.TabIndex = 18;
            this.numMartesIni.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // checkMartes
            // 
            this.checkMartes.AutoSize = true;
            this.checkMartes.Location = new System.Drawing.Point(34, 344);
            this.checkMartes.Name = "checkMartes";
            this.checkMartes.Size = new System.Drawing.Size(44, 17);
            this.checkMartes.TabIndex = 17;
            this.checkMartes.Text = "Mar";
            this.checkMartes.UseVisualStyleBackColor = true;
            this.checkMartes.CheckedChanged += new System.EventHandler(this.checkMartes_CheckedChanged);
            // 
            // checkMiercoles
            // 
            this.checkMiercoles.AutoSize = true;
            this.checkMiercoles.Location = new System.Drawing.Point(34, 370);
            this.checkMiercoles.Name = "checkMiercoles";
            this.checkMiercoles.Size = new System.Drawing.Size(43, 17);
            this.checkMiercoles.TabIndex = 20;
            this.checkMiercoles.Text = "Mie";
            this.checkMiercoles.UseVisualStyleBackColor = true;
            this.checkMiercoles.CheckedChanged += new System.EventHandler(this.checkMiercoles_CheckedChanged);
            // 
            // checkJueves
            // 
            this.checkJueves.AutoSize = true;
            this.checkJueves.Location = new System.Drawing.Point(246, 319);
            this.checkJueves.Name = "checkJueves";
            this.checkJueves.Size = new System.Drawing.Size(43, 17);
            this.checkJueves.TabIndex = 23;
            this.checkJueves.Text = "Jue";
            this.checkJueves.UseVisualStyleBackColor = true;
            this.checkJueves.CheckedChanged += new System.EventHandler(this.checkJueves_CheckedChanged);
            // 
            // checkViernes
            // 
            this.checkViernes.AutoSize = true;
            this.checkViernes.Location = new System.Drawing.Point(246, 345);
            this.checkViernes.Name = "checkViernes";
            this.checkViernes.Size = new System.Drawing.Size(41, 17);
            this.checkViernes.TabIndex = 26;
            this.checkViernes.Text = "Vie";
            this.checkViernes.UseVisualStyleBackColor = true;
            this.checkViernes.CheckedChanged += new System.EventHandler(this.checkViernes_CheckedChanged);
            // 
            // checkSabado
            // 
            this.checkSabado.AutoSize = true;
            this.checkSabado.Location = new System.Drawing.Point(246, 370);
            this.checkSabado.Name = "checkSabado";
            this.checkSabado.Size = new System.Drawing.Size(45, 17);
            this.checkSabado.TabIndex = 29;
            this.checkSabado.Text = "Sab";
            this.checkSabado.UseVisualStyleBackColor = true;
            this.checkSabado.CheckedChanged += new System.EventHandler(this.checkSabado_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(181, 300);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "T    P";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(394, 300);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 45;
            this.label7.Text = "T    P";
            // 
            // pnlLunes
            // 
            this.pnlLunes.Controls.Add(this.numLunesFin);
            this.pnlLunes.Controls.Add(this.numLunesIni);
            this.pnlLunes.Controls.Add(this.rbLunesPra);
            this.pnlLunes.Controls.Add(this.rbLunesTeo);
            this.pnlLunes.Enabled = false;
            this.pnlLunes.Location = new System.Drawing.Point(84, 316);
            this.pnlLunes.Name = "pnlLunes";
            this.pnlLunes.Size = new System.Drawing.Size(133, 20);
            this.pnlLunes.TabIndex = 47;
            // 
            // numLunesFin
            // 
            this.numLunesFin.Location = new System.Drawing.Point(46, 0);
            this.numLunesFin.Maximum = new decimal(new int[] {
            21,
            0,
            0,
            0});
            this.numLunesFin.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numLunesFin.Name = "numLunesFin";
            this.numLunesFin.Size = new System.Drawing.Size(40, 20);
            this.numLunesFin.TabIndex = 36;
            this.numLunesFin.Tag = "";
            this.numLunesFin.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numLunesFin.Enter += new System.EventHandler(this.numLunesFin_Enter);
            // 
            // numLunesIni
            // 
            this.numLunesIni.ForeColor = System.Drawing.SystemColors.WindowText;
            this.numLunesIni.Location = new System.Drawing.Point(0, 0);
            this.numLunesIni.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numLunesIni.Minimum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numLunesIni.Name = "numLunesIni";
            this.numLunesIni.Size = new System.Drawing.Size(40, 20);
            this.numLunesIni.TabIndex = 35;
            this.numLunesIni.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // rbLunesPra
            // 
            this.rbLunesPra.AutoSize = true;
            this.rbLunesPra.Location = new System.Drawing.Point(116, 3);
            this.rbLunesPra.Name = "rbLunesPra";
            this.rbLunesPra.Size = new System.Drawing.Size(14, 13);
            this.rbLunesPra.TabIndex = 34;
            this.rbLunesPra.UseVisualStyleBackColor = true;
            // 
            // rbLunesTeo
            // 
            this.rbLunesTeo.AutoSize = true;
            this.rbLunesTeo.Checked = true;
            this.rbLunesTeo.Location = new System.Drawing.Point(96, 3);
            this.rbLunesTeo.Name = "rbLunesTeo";
            this.rbLunesTeo.Size = new System.Drawing.Size(14, 13);
            this.rbLunesTeo.TabIndex = 33;
            this.rbLunesTeo.TabStop = true;
            this.rbLunesTeo.UseVisualStyleBackColor = true;
            // 
            // pnlMartes
            // 
            this.pnlMartes.Controls.Add(this.rbMartesPra);
            this.pnlMartes.Controls.Add(this.rbMartesTeo);
            this.pnlMartes.Controls.Add(this.numMartesFin);
            this.pnlMartes.Controls.Add(this.numMartesIni);
            this.pnlMartes.Enabled = false;
            this.pnlMartes.Location = new System.Drawing.Point(84, 343);
            this.pnlMartes.Name = "pnlMartes";
            this.pnlMartes.Size = new System.Drawing.Size(133, 20);
            this.pnlMartes.TabIndex = 48;
            // 
            // rbMartesPra
            // 
            this.rbMartesPra.AutoSize = true;
            this.rbMartesPra.Location = new System.Drawing.Point(116, 3);
            this.rbMartesPra.Name = "rbMartesPra";
            this.rbMartesPra.Size = new System.Drawing.Size(14, 13);
            this.rbMartesPra.TabIndex = 34;
            this.rbMartesPra.UseVisualStyleBackColor = true;
            // 
            // rbMartesTeo
            // 
            this.rbMartesTeo.AutoSize = true;
            this.rbMartesTeo.Checked = true;
            this.rbMartesTeo.Location = new System.Drawing.Point(96, 3);
            this.rbMartesTeo.Name = "rbMartesTeo";
            this.rbMartesTeo.Size = new System.Drawing.Size(14, 13);
            this.rbMartesTeo.TabIndex = 33;
            this.rbMartesTeo.TabStop = true;
            this.rbMartesTeo.UseVisualStyleBackColor = true;
            // 
            // pnlMiercoles
            // 
            this.pnlMiercoles.Controls.Add(this.numMiercolesFin);
            this.pnlMiercoles.Controls.Add(this.numMiercolesIni);
            this.pnlMiercoles.Controls.Add(this.rbMiercolesPra);
            this.pnlMiercoles.Controls.Add(this.rbMiercolesTeo);
            this.pnlMiercoles.Enabled = false;
            this.pnlMiercoles.Location = new System.Drawing.Point(84, 368);
            this.pnlMiercoles.Name = "pnlMiercoles";
            this.pnlMiercoles.Size = new System.Drawing.Size(133, 20);
            this.pnlMiercoles.TabIndex = 48;
            // 
            // numMiercolesFin
            // 
            this.numMiercolesFin.Location = new System.Drawing.Point(46, 0);
            this.numMiercolesFin.Maximum = new decimal(new int[] {
            21,
            0,
            0,
            0});
            this.numMiercolesFin.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numMiercolesFin.Name = "numMiercolesFin";
            this.numMiercolesFin.Size = new System.Drawing.Size(40, 20);
            this.numMiercolesFin.TabIndex = 36;
            this.numMiercolesFin.Tag = "";
            this.numMiercolesFin.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numMiercolesFin.Enter += new System.EventHandler(this.numMiercolesFin_Enter);
            // 
            // numMiercolesIni
            // 
            this.numMiercolesIni.Location = new System.Drawing.Point(0, 0);
            this.numMiercolesIni.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numMiercolesIni.Minimum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numMiercolesIni.Name = "numMiercolesIni";
            this.numMiercolesIni.Size = new System.Drawing.Size(40, 20);
            this.numMiercolesIni.TabIndex = 35;
            this.numMiercolesIni.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // rbMiercolesPra
            // 
            this.rbMiercolesPra.AutoSize = true;
            this.rbMiercolesPra.Location = new System.Drawing.Point(116, 3);
            this.rbMiercolesPra.Name = "rbMiercolesPra";
            this.rbMiercolesPra.Size = new System.Drawing.Size(14, 13);
            this.rbMiercolesPra.TabIndex = 34;
            this.rbMiercolesPra.UseVisualStyleBackColor = true;
            // 
            // rbMiercolesTeo
            // 
            this.rbMiercolesTeo.AutoSize = true;
            this.rbMiercolesTeo.Checked = true;
            this.rbMiercolesTeo.Location = new System.Drawing.Point(96, 3);
            this.rbMiercolesTeo.Name = "rbMiercolesTeo";
            this.rbMiercolesTeo.Size = new System.Drawing.Size(14, 13);
            this.rbMiercolesTeo.TabIndex = 33;
            this.rbMiercolesTeo.TabStop = true;
            this.rbMiercolesTeo.UseVisualStyleBackColor = true;
            // 
            // pnlViernes
            // 
            this.pnlViernes.Controls.Add(this.numViernesFin);
            this.pnlViernes.Controls.Add(this.numViernesIni);
            this.pnlViernes.Controls.Add(this.rbViernesPra);
            this.pnlViernes.Controls.Add(this.rbViernesTeo);
            this.pnlViernes.Enabled = false;
            this.pnlViernes.Location = new System.Drawing.Point(296, 342);
            this.pnlViernes.Name = "pnlViernes";
            this.pnlViernes.Size = new System.Drawing.Size(133, 20);
            this.pnlViernes.TabIndex = 49;
            // 
            // numViernesFin
            // 
            this.numViernesFin.Location = new System.Drawing.Point(46, 0);
            this.numViernesFin.Maximum = new decimal(new int[] {
            21,
            0,
            0,
            0});
            this.numViernesFin.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numViernesFin.Name = "numViernesFin";
            this.numViernesFin.Size = new System.Drawing.Size(40, 20);
            this.numViernesFin.TabIndex = 36;
            this.numViernesFin.Tag = "";
            this.numViernesFin.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numViernesFin.Enter += new System.EventHandler(this.numViernesFin_Enter);
            // 
            // numViernesIni
            // 
            this.numViernesIni.Location = new System.Drawing.Point(0, 0);
            this.numViernesIni.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numViernesIni.Minimum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numViernesIni.Name = "numViernesIni";
            this.numViernesIni.Size = new System.Drawing.Size(40, 20);
            this.numViernesIni.TabIndex = 35;
            this.numViernesIni.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // rbViernesPra
            // 
            this.rbViernesPra.AutoSize = true;
            this.rbViernesPra.Location = new System.Drawing.Point(117, 3);
            this.rbViernesPra.Name = "rbViernesPra";
            this.rbViernesPra.Size = new System.Drawing.Size(14, 13);
            this.rbViernesPra.TabIndex = 34;
            this.rbViernesPra.UseVisualStyleBackColor = true;
            // 
            // rbViernesTeo
            // 
            this.rbViernesTeo.AutoSize = true;
            this.rbViernesTeo.Checked = true;
            this.rbViernesTeo.Location = new System.Drawing.Point(97, 3);
            this.rbViernesTeo.Name = "rbViernesTeo";
            this.rbViernesTeo.Size = new System.Drawing.Size(14, 13);
            this.rbViernesTeo.TabIndex = 33;
            this.rbViernesTeo.TabStop = true;
            this.rbViernesTeo.UseVisualStyleBackColor = true;
            // 
            // pnlSabado
            // 
            this.pnlSabado.Controls.Add(this.numSabadoFin);
            this.pnlSabado.Controls.Add(this.numSabadoIni);
            this.pnlSabado.Controls.Add(this.rbSabadoPra);
            this.pnlSabado.Controls.Add(this.rbSabadoTeo);
            this.pnlSabado.Enabled = false;
            this.pnlSabado.Location = new System.Drawing.Point(296, 368);
            this.pnlSabado.Name = "pnlSabado";
            this.pnlSabado.Size = new System.Drawing.Size(133, 20);
            this.pnlSabado.TabIndex = 50;
            // 
            // numSabadoFin
            // 
            this.numSabadoFin.Location = new System.Drawing.Point(46, 0);
            this.numSabadoFin.Maximum = new decimal(new int[] {
            21,
            0,
            0,
            0});
            this.numSabadoFin.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numSabadoFin.Name = "numSabadoFin";
            this.numSabadoFin.Size = new System.Drawing.Size(40, 20);
            this.numSabadoFin.TabIndex = 36;
            this.numSabadoFin.Tag = "";
            this.numSabadoFin.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numSabadoFin.Enter += new System.EventHandler(this.numSabadoFin_Enter);
            // 
            // numSabadoIni
            // 
            this.numSabadoIni.Location = new System.Drawing.Point(0, 0);
            this.numSabadoIni.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numSabadoIni.Minimum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numSabadoIni.Name = "numSabadoIni";
            this.numSabadoIni.Size = new System.Drawing.Size(40, 20);
            this.numSabadoIni.TabIndex = 35;
            this.numSabadoIni.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // rbSabadoPra
            // 
            this.rbSabadoPra.AutoSize = true;
            this.rbSabadoPra.Location = new System.Drawing.Point(115, 3);
            this.rbSabadoPra.Name = "rbSabadoPra";
            this.rbSabadoPra.Size = new System.Drawing.Size(14, 13);
            this.rbSabadoPra.TabIndex = 34;
            this.rbSabadoPra.UseVisualStyleBackColor = true;
            // 
            // rbSabadoTeo
            // 
            this.rbSabadoTeo.AutoSize = true;
            this.rbSabadoTeo.Checked = true;
            this.rbSabadoTeo.Location = new System.Drawing.Point(95, 3);
            this.rbSabadoTeo.Name = "rbSabadoTeo";
            this.rbSabadoTeo.Size = new System.Drawing.Size(14, 13);
            this.rbSabadoTeo.TabIndex = 33;
            this.rbSabadoTeo.TabStop = true;
            this.rbSabadoTeo.UseVisualStyleBackColor = true;
            // 
            // pnlJueves
            // 
            this.pnlJueves.Controls.Add(this.numJuevesFin);
            this.pnlJueves.Controls.Add(this.numJuevesIni);
            this.pnlJueves.Controls.Add(this.rbJuevesPra);
            this.pnlJueves.Controls.Add(this.rbJuevesTeo);
            this.pnlJueves.Enabled = false;
            this.pnlJueves.Location = new System.Drawing.Point(296, 316);
            this.pnlJueves.Name = "pnlJueves";
            this.pnlJueves.Size = new System.Drawing.Size(133, 20);
            this.pnlJueves.TabIndex = 50;
            // 
            // numJuevesFin
            // 
            this.numJuevesFin.Location = new System.Drawing.Point(46, 0);
            this.numJuevesFin.Maximum = new decimal(new int[] {
            21,
            0,
            0,
            0});
            this.numJuevesFin.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numJuevesFin.Name = "numJuevesFin";
            this.numJuevesFin.Size = new System.Drawing.Size(40, 20);
            this.numJuevesFin.TabIndex = 36;
            this.numJuevesFin.Tag = "";
            this.numJuevesFin.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numJuevesFin.Enter += new System.EventHandler(this.numJuevesFin_Enter);
            // 
            // numJuevesIni
            // 
            this.numJuevesIni.Location = new System.Drawing.Point(0, 0);
            this.numJuevesIni.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numJuevesIni.Minimum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numJuevesIni.Name = "numJuevesIni";
            this.numJuevesIni.Size = new System.Drawing.Size(40, 20);
            this.numJuevesIni.TabIndex = 35;
            this.numJuevesIni.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // rbJuevesPra
            // 
            this.rbJuevesPra.AutoSize = true;
            this.rbJuevesPra.Location = new System.Drawing.Point(116, 3);
            this.rbJuevesPra.Name = "rbJuevesPra";
            this.rbJuevesPra.Size = new System.Drawing.Size(14, 13);
            this.rbJuevesPra.TabIndex = 34;
            this.rbJuevesPra.UseVisualStyleBackColor = true;
            // 
            // rbJuevesTeo
            // 
            this.rbJuevesTeo.AutoSize = true;
            this.rbJuevesTeo.Checked = true;
            this.rbJuevesTeo.Location = new System.Drawing.Point(96, 3);
            this.rbJuevesTeo.Name = "rbJuevesTeo";
            this.rbJuevesTeo.Size = new System.Drawing.Size(14, 13);
            this.rbJuevesTeo.TabIndex = 33;
            this.rbJuevesTeo.TabStop = true;
            this.rbJuevesTeo.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(81, 300);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 51;
            this.label8.Text = "Inicio       Fin";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(293, 301);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 52;
            this.label9.Text = "Inicio       Fin";
            // 
            // Frm_AddCurso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(474, 461);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pnlJueves);
            this.Controls.Add(this.pnlSabado);
            this.Controls.Add(this.pnlViernes);
            this.Controls.Add(this.pnlMiercoles);
            this.Controls.Add(this.pnlMartes);
            this.Controls.Add(this.pnlLunes);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.checkSabado);
            this.Controls.Add(this.checkViernes);
            this.Controls.Add(this.checkJueves);
            this.Controls.Add(this.checkMiercoles);
            this.Controls.Add(this.checkMartes);
            this.Controls.Add(this.checkLunes);
            this.Controls.Add(this.lblHorario);
            this.Controls.Add(this.cbDocente);
            this.Controls.Add(this.lblCodDocente);
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
            this.MaximumSize = new System.Drawing.Size(490, 500);
            this.MinimumSize = new System.Drawing.Size(490, 500);
            this.Name = "Frm_AddCurso";
            ((System.ComponentModel.ISupportInitialize)(this.numMartesFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMartesIni)).EndInit();
            this.pnlLunes.ResumeLayout(false);
            this.pnlLunes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLunesFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLunesIni)).EndInit();
            this.pnlMartes.ResumeLayout(false);
            this.pnlMartes.PerformLayout();
            this.pnlMiercoles.ResumeLayout(false);
            this.pnlMiercoles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMiercolesFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMiercolesIni)).EndInit();
            this.pnlViernes.ResumeLayout(false);
            this.pnlViernes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numViernesFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numViernesIni)).EndInit();
            this.pnlSabado.ResumeLayout(false);
            this.pnlSabado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSabadoFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSabadoIni)).EndInit();
            this.pnlJueves.ResumeLayout(false);
            this.pnlJueves.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numJuevesFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numJuevesIni)).EndInit();
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
        private System.Windows.Forms.Label lblCodDocente;
        private System.Windows.Forms.ComboBox cbDocente;
        private System.Windows.Forms.Label lblHorario;
        private System.Windows.Forms.CheckBox checkLunes;
        private System.Windows.Forms.NumericUpDown numMartesFin;
        private System.Windows.Forms.NumericUpDown numMartesIni;
        private System.Windows.Forms.CheckBox checkMartes;
        private System.Windows.Forms.CheckBox checkMiercoles;
        private System.Windows.Forms.CheckBox checkJueves;
        private System.Windows.Forms.CheckBox checkViernes;
        private System.Windows.Forms.CheckBox checkSabado;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pnlLunes;
        private System.Windows.Forms.RadioButton rbLunesPra;
        private System.Windows.Forms.RadioButton rbLunesTeo;
        private System.Windows.Forms.Panel pnlMartes;
        private System.Windows.Forms.RadioButton rbMartesPra;
        private System.Windows.Forms.RadioButton rbMartesTeo;
        private System.Windows.Forms.Panel pnlMiercoles;
        private System.Windows.Forms.RadioButton rbMiercolesPra;
        private System.Windows.Forms.RadioButton rbMiercolesTeo;
        private System.Windows.Forms.Panel pnlViernes;
        private System.Windows.Forms.RadioButton rbViernesPra;
        private System.Windows.Forms.RadioButton rbViernesTeo;
        private System.Windows.Forms.Panel pnlSabado;
        private System.Windows.Forms.RadioButton rbSabadoPra;
        private System.Windows.Forms.RadioButton rbSabadoTeo;
        private System.Windows.Forms.Panel pnlJueves;
        private System.Windows.Forms.RadioButton rbJuevesPra;
        private System.Windows.Forms.RadioButton rbJuevesTeo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numLunesFin;
        private System.Windows.Forms.NumericUpDown numLunesIni;
        private System.Windows.Forms.NumericUpDown numMiercolesFin;
        private System.Windows.Forms.NumericUpDown numMiercolesIni;
        private System.Windows.Forms.NumericUpDown numViernesFin;
        private System.Windows.Forms.NumericUpDown numViernesIni;
        private System.Windows.Forms.NumericUpDown numSabadoFin;
        private System.Windows.Forms.NumericUpDown numSabadoIni;
        private System.Windows.Forms.NumericUpDown numJuevesFin;
        private System.Windows.Forms.NumericUpDown numJuevesIni;
    }
}