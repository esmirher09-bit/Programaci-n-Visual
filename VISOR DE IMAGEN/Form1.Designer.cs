namespace VISOR_DE_IMAGEN
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnPrimera = new System.Windows.Forms.Button();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.btnUltima = new System.Windows.Forms.Button();
            this.visualizadorImagen = new System.Windows.Forms.PictureBox();
            this.contextMenuImagen = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.girar90ALaIzquierdaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.girar90ALaDerechaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copiarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblRuta = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.escalaGrisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tamañoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.centradaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajustarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.normalbtn = new System.Windows.Forms.ToolStripButton();
            this.escalaGrisbtn = new System.Windows.Forms.ToolStripButton();
            this.centradabtn = new System.Windows.Forms.ToolStripButton();
            this.ajustarbtn = new System.Windows.Forms.ToolStripButton();
            this.zoombtn = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkescalaGris = new System.Windows.Forms.CheckBox();
            this.checknormal = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioZoom = new System.Windows.Forms.RadioButton();
            this.radioAjustar = new System.Windows.Forms.RadioButton();
            this.radioCentrada = new System.Windows.Forms.RadioButton();
            this.lblImagenActual = new System.Windows.Forms.Label();
            this.cmbImagenes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.visualizadorImagen)).BeginInit();
            this.contextMenuImagen.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPrimera
            // 
            this.btnPrimera.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnPrimera.Location = new System.Drawing.Point(48, 395);
            this.btnPrimera.Name = "btnPrimera";
            this.btnPrimera.Size = new System.Drawing.Size(75, 23);
            this.btnPrimera.TabIndex = 0;
            this.btnPrimera.Text = "<<";
            this.btnPrimera.UseVisualStyleBackColor = false;
            this.btnPrimera.Click += new System.EventHandler(this.btnPrimera_Click);
            // 
            // btnAnterior
            // 
            this.btnAnterior.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnAnterior.Location = new System.Drawing.Point(167, 395);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(75, 23);
            this.btnAnterior.TabIndex = 1;
            this.btnAnterior.Text = "<";
            this.btnAnterior.UseVisualStyleBackColor = false;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnSiguiente.Location = new System.Drawing.Point(308, 395);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(75, 23);
            this.btnSiguiente.TabIndex = 2;
            this.btnSiguiente.Text = ">";
            this.btnSiguiente.UseVisualStyleBackColor = false;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // btnUltima
            // 
            this.btnUltima.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnUltima.Location = new System.Drawing.Point(413, 395);
            this.btnUltima.Name = "btnUltima";
            this.btnUltima.Size = new System.Drawing.Size(75, 23);
            this.btnUltima.TabIndex = 3;
            this.btnUltima.Text = ">>";
            this.btnUltima.UseVisualStyleBackColor = false;
            this.btnUltima.Click += new System.EventHandler(this.btnUltima_Click);
            // 
            // visualizadorImagen
            // 
            this.visualizadorImagen.ContextMenuStrip = this.contextMenuImagen;
            this.visualizadorImagen.Location = new System.Drawing.Point(17, 151);
            this.visualizadorImagen.Name = "visualizadorImagen";
            this.visualizadorImagen.Size = new System.Drawing.Size(346, 220);
            this.visualizadorImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.visualizadorImagen.TabIndex = 4;
            this.visualizadorImagen.TabStop = false;
            this.visualizadorImagen.Click += new System.EventHandler(this.visualizadorImagen_Click);
            // 
            // contextMenuImagen
            // 
            this.contextMenuImagen.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.girar90ALaIzquierdaToolStripMenuItem,
            this.girar90ALaDerechaToolStripMenuItem,
            this.copiarToolStripMenuItem});
            this.contextMenuImagen.Name = "contextMenuImagen";
            this.contextMenuImagen.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextMenuImagen.ShowCheckMargin = true;
            this.contextMenuImagen.Size = new System.Drawing.Size(209, 70);
            // 
            // girar90ALaIzquierdaToolStripMenuItem
            // 
            this.girar90ALaIzquierdaToolStripMenuItem.Name = "girar90ALaIzquierdaToolStripMenuItem";
            this.girar90ALaIzquierdaToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.girar90ALaIzquierdaToolStripMenuItem.Text = "Girar 90 a la izquierda";
            this.girar90ALaIzquierdaToolStripMenuItem.Click += new System.EventHandler(this.girar90ALaIzquierdaToolStripMenuItem_Click);
            // 
            // girar90ALaDerechaToolStripMenuItem
            // 
            this.girar90ALaDerechaToolStripMenuItem.Name = "girar90ALaDerechaToolStripMenuItem";
            this.girar90ALaDerechaToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.girar90ALaDerechaToolStripMenuItem.Text = "Girar 90 a la derecha";
            this.girar90ALaDerechaToolStripMenuItem.Click += new System.EventHandler(this.girar90ALaDerechaToolStripMenuItem_Click);
            // 
            // copiarToolStripMenuItem
            // 
            this.copiarToolStripMenuItem.Name = "copiarToolStripMenuItem";
            this.copiarToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.copiarToolStripMenuItem.Text = "Copiar";
            this.copiarToolStripMenuItem.Click += new System.EventHandler(this.copiarToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblRuta});
            this.statusStrip1.Location = new System.Drawing.Point(0, 421);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(568, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblRuta
            // 
            this.lblRuta.Name = "lblRuta";
            this.lblRuta.Size = new System.Drawing.Size(0, 17);
            this.lblRuta.Click += new System.EventHandler(this.lblRuta_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.menuStrip1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.visionToolStripMenuItem,
            this.tamañoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(568, 27);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.guardarToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(69, 23);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(128, 24);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(128, 24);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // visionToolStripMenuItem
            // 
            this.visionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.normalToolStripMenuItem,
            this.escalaGrisToolStripMenuItem});
            this.visionToolStripMenuItem.Name = "visionToolStripMenuItem";
            this.visionToolStripMenuItem.Size = new System.Drawing.Size(58, 23);
            this.visionToolStripMenuItem.Text = "Vision";
            // 
            // normalToolStripMenuItem
            // 
            this.normalToolStripMenuItem.Name = "normalToolStripMenuItem";
            this.normalToolStripMenuItem.Size = new System.Drawing.Size(146, 24);
            this.normalToolStripMenuItem.Text = "Normal";
            this.normalToolStripMenuItem.Click += new System.EventHandler(this.normalToolStripMenuItem_Click);
            // 
            // escalaGrisToolStripMenuItem
            // 
            this.escalaGrisToolStripMenuItem.Name = "escalaGrisToolStripMenuItem";
            this.escalaGrisToolStripMenuItem.Size = new System.Drawing.Size(146, 24);
            this.escalaGrisToolStripMenuItem.Text = "Escala Gris";
            this.escalaGrisToolStripMenuItem.Click += new System.EventHandler(this.escalaGrisToolStripMenuItem_Click);
            // 
            // tamañoToolStripMenuItem
            // 
            this.tamañoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.centradaToolStripMenuItem,
            this.ajustarToolStripMenuItem,
            this.zoonToolStripMenuItem});
            this.tamañoToolStripMenuItem.Name = "tamañoToolStripMenuItem";
            this.tamañoToolStripMenuItem.Size = new System.Drawing.Size(69, 23);
            this.tamañoToolStripMenuItem.Text = "Tamaño";
            // 
            // centradaToolStripMenuItem
            // 
            this.centradaToolStripMenuItem.Name = "centradaToolStripMenuItem";
            this.centradaToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.centradaToolStripMenuItem.Text = "Centrada";
            this.centradaToolStripMenuItem.Click += new System.EventHandler(this.centradaToolStripMenuItem_Click);
            // 
            // ajustarToolStripMenuItem
            // 
            this.ajustarToolStripMenuItem.Name = "ajustarToolStripMenuItem";
            this.ajustarToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.ajustarToolStripMenuItem.Text = "Ajustar";
            this.ajustarToolStripMenuItem.Click += new System.EventHandler(this.ajustarToolStripMenuItem_Click);
            // 
            // zoonToolStripMenuItem
            // 
            this.zoonToolStripMenuItem.Name = "zoonToolStripMenuItem";
            this.zoonToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.zoonToolStripMenuItem.Text = "Zoon";
            this.zoonToolStripMenuItem.Click += new System.EventHandler(this.zoonToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.normalbtn,
            this.escalaGrisbtn,
            this.centradabtn,
            this.ajustarbtn,
            this.zoombtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 27);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(568, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // normalbtn
            // 
            this.normalbtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.normalbtn.Image = ((System.Drawing.Image)(resources.GetObject("normalbtn.Image")));
            this.normalbtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.normalbtn.Name = "normalbtn";
            this.normalbtn.Size = new System.Drawing.Size(23, 22);
            this.normalbtn.Text = "Escala normal";
            this.normalbtn.Click += new System.EventHandler(this.normalbtn_Click);
            // 
            // escalaGrisbtn
            // 
            this.escalaGrisbtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.escalaGrisbtn.Image = ((System.Drawing.Image)(resources.GetObject("escalaGrisbtn.Image")));
            this.escalaGrisbtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.escalaGrisbtn.Name = "escalaGrisbtn";
            this.escalaGrisbtn.Size = new System.Drawing.Size(23, 22);
            this.escalaGrisbtn.Text = "Escala a Grices";
            this.escalaGrisbtn.Click += new System.EventHandler(this.escalaGrisbtn_Click);
            // 
            // centradabtn
            // 
            this.centradabtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.centradabtn.Image = ((System.Drawing.Image)(resources.GetObject("centradabtn.Image")));
            this.centradabtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.centradabtn.Name = "centradabtn";
            this.centradabtn.Size = new System.Drawing.Size(23, 22);
            this.centradabtn.Text = "Centrada";
            this.centradabtn.Click += new System.EventHandler(this.centradabtn_Click);
            // 
            // ajustarbtn
            // 
            this.ajustarbtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ajustarbtn.Image = ((System.Drawing.Image)(resources.GetObject("ajustarbtn.Image")));
            this.ajustarbtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ajustarbtn.Name = "ajustarbtn";
            this.ajustarbtn.Size = new System.Drawing.Size(23, 22);
            this.ajustarbtn.Text = "Ajustar";
            this.ajustarbtn.Click += new System.EventHandler(this.ajustarbtn_Click);
            // 
            // zoombtn
            // 
            this.zoombtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoombtn.Image = ((System.Drawing.Image)(resources.GetObject("zoombtn.Image")));
            this.zoombtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoombtn.Name = "zoombtn";
            this.zoombtn.Size = new System.Drawing.Size(23, 22);
            this.zoombtn.Text = "Zoom";
            this.zoombtn.Click += new System.EventHandler(this.zoombtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkescalaGris);
            this.groupBox1.Controls.Add(this.checknormal);
            this.groupBox1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(568, 60);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vision";
            // 
            // checkescalaGris
            // 
            this.checkescalaGris.AutoSize = true;
            this.checkescalaGris.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkescalaGris.Location = new System.Drawing.Point(167, 19);
            this.checkescalaGris.Name = "checkescalaGris";
            this.checkescalaGris.Size = new System.Drawing.Size(144, 26);
            this.checkescalaGris.TabIndex = 1;
            this.checkescalaGris.Text = "Escalas a Grices";
            this.checkescalaGris.UseVisualStyleBackColor = true;
            this.checkescalaGris.CheckedChanged += new System.EventHandler(this.checkescalaGris_CheckedChanged);
            // 
            // checknormal
            // 
            this.checknormal.AutoSize = true;
            this.checknormal.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checknormal.Location = new System.Drawing.Point(6, 19);
            this.checknormal.Name = "checknormal";
            this.checknormal.Size = new System.Drawing.Size(86, 26);
            this.checknormal.TabIndex = 0;
            this.checknormal.Text = "Normal";
            this.checknormal.UseVisualStyleBackColor = true;
            this.checknormal.CheckedChanged += new System.EventHandler(this.checknormal_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioZoom);
            this.groupBox2.Controls.Add(this.radioAjustar);
            this.groupBox2.Controls.Add(this.radioCentrada);
            this.groupBox2.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(403, 151);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(153, 122);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tamaño";
            // 
            // radioZoom
            // 
            this.radioZoom.AutoSize = true;
            this.radioZoom.Location = new System.Drawing.Point(16, 70);
            this.radioZoom.Name = "radioZoom";
            this.radioZoom.Size = new System.Drawing.Size(67, 25);
            this.radioZoom.TabIndex = 2;
            this.radioZoom.TabStop = true;
            this.radioZoom.Text = "Zoom";
            this.radioZoom.UseVisualStyleBackColor = true;
            this.radioZoom.CheckedChanged += new System.EventHandler(this.radioZoom_CheckedChanged);
            // 
            // radioAjustar
            // 
            this.radioAjustar.AutoSize = true;
            this.radioAjustar.Location = new System.Drawing.Point(16, 46);
            this.radioAjustar.Name = "radioAjustar";
            this.radioAjustar.Size = new System.Drawing.Size(82, 25);
            this.radioAjustar.TabIndex = 1;
            this.radioAjustar.TabStop = true;
            this.radioAjustar.Text = "Ajustar";
            this.radioAjustar.UseVisualStyleBackColor = true;
            this.radioAjustar.CheckedChanged += new System.EventHandler(this.radioAjustar_CheckedChanged);
            // 
            // radioCentrada
            // 
            this.radioCentrada.AutoSize = true;
            this.radioCentrada.Location = new System.Drawing.Point(16, 20);
            this.radioCentrada.Name = "radioCentrada";
            this.radioCentrada.Size = new System.Drawing.Size(93, 25);
            this.radioCentrada.TabIndex = 0;
            this.radioCentrada.TabStop = true;
            this.radioCentrada.Text = "Centrada";
            this.radioCentrada.UseVisualStyleBackColor = true;
            this.radioCentrada.CheckedChanged += new System.EventHandler(this.radioCentrada_CheckedChanged);
            // 
            // lblImagenActual
            // 
            this.lblImagenActual.AutoSize = true;
            this.lblImagenActual.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImagenActual.Location = new System.Drawing.Point(14, 127);
            this.lblImagenActual.Name = "lblImagenActual";
            this.lblImagenActual.Size = new System.Drawing.Size(118, 22);
            this.lblImagenActual.TabIndex = 10;
            this.lblImagenActual.Text = "Imagen actual:";
            // 
            // cmbImagenes
            // 
            this.cmbImagenes.FormattingEnabled = true;
            this.cmbImagenes.Location = new System.Drawing.Point(131, 130);
            this.cmbImagenes.Name = "cmbImagenes";
            this.cmbImagenes.Size = new System.Drawing.Size(121, 21);
            this.cmbImagenes.TabIndex = 11;
            this.cmbImagenes.SelectedIndexChanged += new System.EventHandler(this.cmbImagenes_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(286, 297);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 65);
            this.label1.TabIndex = 12;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(568, 443);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbImagenes);
            this.Controls.Add(this.lblImagenActual);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.visualizadorImagen);
            this.Controls.Add(this.btnUltima);
            this.Controls.Add(this.btnSiguiente);
            this.Controls.Add(this.btnAnterior);
            this.Controls.Add(this.btnPrimera);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Visor de imagenes";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.visualizadorImagen)).EndInit();
            this.contextMenuImagen.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrimera;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Button btnUltima;
        private System.Windows.Forms.PictureBox visualizadorImagen;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem escalaGrisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tamañoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem centradaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajustarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoonToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton normalbtn;
        private System.Windows.Forms.ToolStripButton escalaGrisbtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkescalaGris;
        private System.Windows.Forms.CheckBox checknormal;
        private System.Windows.Forms.RadioButton radioZoom;
        private System.Windows.Forms.RadioButton radioAjustar;
        private System.Windows.Forms.RadioButton radioCentrada;
        private System.Windows.Forms.Label lblImagenActual;
        private System.Windows.Forms.ComboBox cmbImagenes;
        private System.Windows.Forms.ToolStripStatusLabel lblRuta;
        private System.Windows.Forms.ToolStripButton centradabtn;
        private System.Windows.Forms.ToolStripButton ajustarbtn;
        private System.Windows.Forms.ToolStripButton zoombtn;
        private System.Windows.Forms.ContextMenuStrip contextMenuImagen;
        private System.Windows.Forms.ToolStripMenuItem girar90ALaIzquierdaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem girar90ALaDerechaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copiarToolStripMenuItem;
        private System.Windows.Forms.Label label1;
    }
}

