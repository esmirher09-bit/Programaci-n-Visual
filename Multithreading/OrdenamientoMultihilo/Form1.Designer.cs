namespace OrdenamientoMultihilo
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.progressBurbuja = new System.Windows.Forms.ProgressBar();
            this.progressQuickSort = new System.Windows.Forms.ProgressBar();
            this.lblBurbuja = new System.Windows.Forms.Label();
            this.lblQuickSort = new System.Windows.Forms.Label();
            this.backgroundWorkerQuickSort = new System.ComponentModel.BackgroundWorker();
            this.btnDetener = new System.Windows.Forms.Button();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.backgroundWorkerMerge = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSeleccion = new System.ComponentModel.BackgroundWorker();
            this.lblMerge = new System.Windows.Forms.Label();
            this.lblSeleccion = new System.Windows.Forms.Label();
            this.progressMerge = new System.Windows.Forms.ProgressBar();
            this.progressSeleccion = new System.Windows.Forms.ProgressBar();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.chartTiempos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnVBurbuja = new System.Windows.Forms.Button();
            this.btnGWord = new System.Windows.Forms.Button();
            this.btnVQuickSort = new System.Windows.Forms.Button();
            this.btnVMergeSort = new System.Windows.Forms.Button();
            this.btnVSelectionSort = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartTiempos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerar
            // 
            this.btnGenerar.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnGenerar.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.Location = new System.Drawing.Point(27, 32);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(162, 33);
            this.btnGenerar.TabIndex = 0;
            this.btnGenerar.Text = "Generar Datos";
            this.btnGenerar.UseVisualStyleBackColor = false;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // btnIniciar
            // 
            this.btnIniciar.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnIniciar.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciar.Location = new System.Drawing.Point(27, 71);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(162, 33);
            this.btnIniciar.TabIndex = 1;
            this.btnIniciar.Text = "Iniciar Ordenamiento";
            this.btnIniciar.UseVisualStyleBackColor = false;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // progressBurbuja
            // 
            this.progressBurbuja.Location = new System.Drawing.Point(27, 218);
            this.progressBurbuja.Name = "progressBurbuja";
            this.progressBurbuja.Size = new System.Drawing.Size(122, 23);
            this.progressBurbuja.TabIndex = 2;
            // 
            // progressQuickSort
            // 
            this.progressQuickSort.Location = new System.Drawing.Point(27, 277);
            this.progressQuickSort.Name = "progressQuickSort";
            this.progressQuickSort.Size = new System.Drawing.Size(122, 23);
            this.progressQuickSort.TabIndex = 3;
            // 
            // lblBurbuja
            // 
            this.lblBurbuja.AutoSize = true;
            this.lblBurbuja.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblBurbuja.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBurbuja.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblBurbuja.Location = new System.Drawing.Point(24, 197);
            this.lblBurbuja.Name = "lblBurbuja";
            this.lblBurbuja.Size = new System.Drawing.Size(57, 18);
            this.lblBurbuja.TabIndex = 4;
            this.lblBurbuja.Text = "Burbuja:";
            // 
            // lblQuickSort
            // 
            this.lblQuickSort.AutoSize = true;
            this.lblQuickSort.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblQuickSort.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuickSort.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblQuickSort.Location = new System.Drawing.Point(24, 256);
            this.lblQuickSort.Name = "lblQuickSort";
            this.lblQuickSort.Size = new System.Drawing.Size(73, 18);
            this.lblQuickSort.TabIndex = 5;
            this.lblQuickSort.Text = " QuickSort:";
            // 
            // backgroundWorkerQuickSort
            // 
            this.backgroundWorkerQuickSort.WorkerReportsProgress = true;
            this.backgroundWorkerQuickSort.WorkerSupportsCancellation = true;
            this.backgroundWorkerQuickSort.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerQuickSort_DoWork);
            // 
            // btnDetener
            // 
            this.btnDetener.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnDetener.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetener.Location = new System.Drawing.Point(27, 110);
            this.btnDetener.Name = "btnDetener";
            this.btnDetener.Size = new System.Drawing.Size(127, 33);
            this.btnDetener.TabIndex = 6;
            this.btnDetener.Text = "Detener ";
            this.btnDetener.UseVisualStyleBackColor = false;
            this.btnDetener.Click += new System.EventHandler(this.btnDetener_Click);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(259, 9);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(100, 20);
            this.txtCantidad.TabIndex = 8;
            // 
            // backgroundWorkerMerge
            // 
            this.backgroundWorkerMerge.WorkerReportsProgress = true;
            this.backgroundWorkerMerge.WorkerSupportsCancellation = true;
            // 
            // backgroundWorkerSeleccion
            // 
            this.backgroundWorkerSeleccion.WorkerReportsProgress = true;
            this.backgroundWorkerSeleccion.WorkerSupportsCancellation = true;
            // 
            // lblMerge
            // 
            this.lblMerge.AutoSize = true;
            this.lblMerge.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblMerge.Location = new System.Drawing.Point(24, 312);
            this.lblMerge.Name = "lblMerge";
            this.lblMerge.Size = new System.Drawing.Size(59, 13);
            this.lblMerge.TabIndex = 9;
            this.lblMerge.Text = "MergeSort:";
            // 
            // lblSeleccion
            // 
            this.lblSeleccion.AutoSize = true;
            this.lblSeleccion.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblSeleccion.Location = new System.Drawing.Point(24, 363);
            this.lblSeleccion.Name = "lblSeleccion";
            this.lblSeleccion.Size = new System.Drawing.Size(73, 13);
            this.lblSeleccion.TabIndex = 10;
            this.lblSeleccion.Text = "SelectionSort:";
            // 
            // progressMerge
            // 
            this.progressMerge.Location = new System.Drawing.Point(27, 328);
            this.progressMerge.Name = "progressMerge";
            this.progressMerge.Size = new System.Drawing.Size(122, 23);
            this.progressMerge.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressMerge.TabIndex = 13;
            // 
            // progressSeleccion
            // 
            this.progressSeleccion.Location = new System.Drawing.Point(27, 379);
            this.progressSeleccion.Name = "progressSeleccion";
            this.progressSeleccion.Size = new System.Drawing.Size(122, 23);
            this.progressSeleccion.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressSeleccion.TabIndex = 14;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblCantidad.Location = new System.Drawing.Point(24, 416);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(118, 13);
            this.lblCantidad.TabIndex = 15;
            this.lblCantidad.Text = "Cantidad de elementos:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(95, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "Ingrese un número:";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnLimpiar.Font = new System.Drawing.Font("Palatino Linotype", 12F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(27, 149);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(127, 33);
            this.btnLimpiar.TabIndex = 17;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // chartTiempos
            // 
            this.chartTiempos.BackColor = System.Drawing.Color.Lavender;
            chartArea1.Name = "ChartArea1";
            this.chartTiempos.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartTiempos.Legends.Add(legend1);
            this.chartTiempos.Location = new System.Drawing.Point(374, 9);
            this.chartTiempos.Name = "chartTiempos";
            this.chartTiempos.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Tiempos";
            this.chartTiempos.Series.Add(series1);
            this.chartTiempos.Size = new System.Drawing.Size(414, 232);
            this.chartTiempos.TabIndex = 18;
            this.chartTiempos.Text = "chart1";
            this.chartTiempos.UseWaitCursor = true;
            // 
            // btnVBurbuja
            // 
            this.btnVBurbuja.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnVBurbuja.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVBurbuja.Location = new System.Drawing.Point(661, 253);
            this.btnVBurbuja.Name = "btnVBurbuja";
            this.btnVBurbuja.Size = new System.Drawing.Size(127, 33);
            this.btnVBurbuja.TabIndex = 20;
            this.btnVBurbuja.Text = "Ver Burbuja";
            this.btnVBurbuja.UseVisualStyleBackColor = false;
            // 
            // btnGWord
            // 
            this.btnGWord.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnGWord.Font = new System.Drawing.Font("Palatino Linotype", 12F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGWord.Location = new System.Drawing.Point(374, 253);
            this.btnGWord.Name = "btnGWord";
            this.btnGWord.Size = new System.Drawing.Size(162, 33);
            this.btnGWord.TabIndex = 19;
            this.btnGWord.Text = "Guardar en Word";
            this.btnGWord.UseVisualStyleBackColor = false;
            this.btnGWord.Click += new System.EventHandler(this.btnGWord_Click);
            // 
            // btnVQuickSort
            // 
            this.btnVQuickSort.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnVQuickSort.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVQuickSort.Location = new System.Drawing.Point(661, 292);
            this.btnVQuickSort.Name = "btnVQuickSort";
            this.btnVQuickSort.Size = new System.Drawing.Size(127, 33);
            this.btnVQuickSort.TabIndex = 21;
            this.btnVQuickSort.Text = "Ver QuickSort";
            this.btnVQuickSort.UseVisualStyleBackColor = false;
            // 
            // btnVMergeSort
            // 
            this.btnVMergeSort.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnVMergeSort.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVMergeSort.Location = new System.Drawing.Point(661, 331);
            this.btnVMergeSort.Name = "btnVMergeSort";
            this.btnVMergeSort.Size = new System.Drawing.Size(127, 33);
            this.btnVMergeSort.TabIndex = 22;
            this.btnVMergeSort.Text = "Ver MergeSort";
            this.btnVMergeSort.UseVisualStyleBackColor = false;
            // 
            // btnVSelectionSort
            // 
            this.btnVSelectionSort.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnVSelectionSort.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVSelectionSort.Location = new System.Drawing.Point(661, 370);
            this.btnVSelectionSort.Name = "btnVSelectionSort";
            this.btnVSelectionSort.Size = new System.Drawing.Size(127, 33);
            this.btnVSelectionSort.TabIndex = 23;
            this.btnVSelectionSort.Text = "Ver SelectionSort";
            this.btnVSelectionSort.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(808, 432);
            this.Controls.Add(this.btnVSelectionSort);
            this.Controls.Add(this.btnVMergeSort);
            this.Controls.Add(this.btnVQuickSort);
            this.Controls.Add(this.btnVBurbuja);
            this.Controls.Add(this.btnGWord);
            this.Controls.Add(this.chartTiempos);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.lblSeleccion);
            this.Controls.Add(this.lblMerge);
            this.Controls.Add(this.lblQuickSort);
            this.Controls.Add(this.lblBurbuja);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressSeleccion);
            this.Controls.Add(this.progressMerge);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.btnDetener);
            this.Controls.Add(this.progressQuickSort);
            this.Controls.Add(this.progressBurbuja);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.btnGenerar);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chartTiempos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.ProgressBar progressBurbuja;
        private System.Windows.Forms.ProgressBar progressQuickSort;
        private System.Windows.Forms.Label lblBurbuja;
        private System.Windows.Forms.Label lblQuickSort;
        private System.ComponentModel.BackgroundWorker backgroundWorkerQuickSort;
        private System.Windows.Forms.Button btnDetener;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.ComponentModel.BackgroundWorker backgroundWorkerMerge;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSeleccion;
        private System.Windows.Forms.Label lblMerge;
        private System.Windows.Forms.Label lblSeleccion;
        private System.Windows.Forms.ProgressBar progressMerge;
        private System.Windows.Forms.ProgressBar progressSeleccion;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTiempos;
        private System.Windows.Forms.Button btnVBurbuja;
        private System.Windows.Forms.Button btnGWord;
        private System.Windows.Forms.Button btnVQuickSort;
        private System.Windows.Forms.Button btnVMergeSort;
        private System.Windows.Forms.Button btnVSelectionSort;
    }
}