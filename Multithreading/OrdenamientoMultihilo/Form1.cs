using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using Charting = System.Windows.Forms.DataVisualization.Charting;

namespace OrdenamientoMultihilo
{
    public partial class Form1 : Form
    {
        // Datos
        private List<int> datosOriginal = new List<int>();
        private List<int> datosBurbuja, datosQuick, datosMerge, datosSeleccion;

        // Relojes
        private Stopwatch relojBurbuja = new Stopwatch();
        private Stopwatch relojQuick = new Stopwatch();
        private Stopwatch relojMerge = new Stopwatch();
        private Stopwatch relojSeleccion = new Stopwatch();

        // Control de cancelación
        private volatile bool cancelar = false;

        // Variables para iteraciones
        private List<string> iteracionesBurbuja = new List<string>();
        private List<string> iteracionesQuick = new List<string>();
        private List<string> iteracionesMerge = new List<string>();
        private List<string> iteracionesSeleccion = new List<string>();

        public Form1()
        {
            InitializeComponent();

            // Configurar BackgroundWorkers
            backgroundWorkerQuickSort.WorkerReportsProgress = true;
            backgroundWorkerQuickSort.WorkerSupportsCancellation = true;
            backgroundWorkerQuickSort.DoWork += backgroundWorkerQuickSort_DoWork;
            backgroundWorkerQuickSort.ProgressChanged += backgroundWorkerQuickSort_ProgressChanged;
            backgroundWorkerQuickSort.RunWorkerCompleted += backgroundWorkerQuickSort_RunWorkerCompleted;

            backgroundWorkerMerge.WorkerReportsProgress = true;
            backgroundWorkerMerge.WorkerSupportsCancellation = true;
            backgroundWorkerMerge.DoWork += backgroundWorkerMerge_DoWork;
            backgroundWorkerMerge.ProgressChanged += backgroundWorkerMerge_ProgressChanged;
            backgroundWorkerMerge.RunWorkerCompleted += backgroundWorkerMerge_RunWorkerCompleted;

            backgroundWorkerSeleccion.WorkerReportsProgress = true;
            backgroundWorkerSeleccion.WorkerSupportsCancellation = true;
            backgroundWorkerSeleccion.DoWork += backgroundWorkerSeleccion_DoWork;
            backgroundWorkerSeleccion.ProgressChanged += backgroundWorkerSeleccion_ProgressChanged;
            backgroundWorkerSeleccion.RunWorkerCompleted += backgroundWorkerSeleccion_RunWorkerCompleted;

            // Configurar chart
            ConfigurarChart();

            // Conectar eventos de los botones de ver Word
            ConectarEventosBotonesWord();
        }

        private void ConfigurarChart()
        {
            chartTiempos.Series.Clear();
            var area = chartTiempos.ChartAreas[0];
            area.AxisX.Title = "Algoritmo";
            area.AxisY.Title = "Tiempo (ms)";
            area.AxisX.Interval = 1;
            area.AxisX.IsMarginVisible = true;
            area.AxisX.LabelStyle.Angle = -45;
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.Enabled = true;
            area.AxisY.Minimum = 0;

            var serie = new Charting.Series("Tiempos")
            {
                ChartType = Charting.SeriesChartType.Column,
                IsValueShownAsLabel = true
            };
            serie["PointWidth"] = "0.6";
            chartTiempos.Series.Add(serie);
        }

        private void ConectarEventosBotonesWord()
        {
            // Conectar eventos de los botones para abrir documentos Word
            btnVBurbuja.Click += (s, e) => AbrirDocumentoWord("Burbuja_Iteraciones.docx");
            btnVQuickSort.Click += (s, e) => AbrirDocumentoWord("QuickSort_Iteraciones.docx");
            btnVMergeSort.Click += (s, e) => AbrirDocumentoWord("MergeSort_Iteraciones.docx");
            btnVSelectionSort.Click += (s, e) => AbrirDocumentoWord("SelectionSort_Iteraciones.docx");
        }

        // --------------------------------------------------

        // Generar datos 
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                int cantidad = int.Parse(txtCantidad.Text.Trim());
                if (cantidad <= 0)
                {
                    MessageBox.Show("Ingrese un número mayor que 0.");
                    return;
                }

                Random rnd = new Random();
                datosOriginal = Enumerable.Range(0, cantidad).Select(x => rnd.Next(1, 1000000)).ToList();
                lblCantidad.Text = $"Cantidad generada: {cantidad} elementos";

                // Limpiar iteraciones anteriores
                iteracionesBurbuja.Clear();
                iteracionesQuick.Clear();
                iteracionesMerge.Clear();
                iteracionesSeleccion.Clear();

                MessageBox.Show($"Datos generados correctamente con {cantidad} elementos.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Ingrese un número válido en Cantidad.");
            }
        }

        // --------------------------------------------------

        // Iniciar 
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (datosOriginal == null || datosOriginal.Count == 0)
            {
                MessageBox.Show("Primero debe generar los datos.");
                return;
            }

            cancelar = false;
            ReiniciarProgresos();

            // Limpiar iteraciones anteriores
            iteracionesBurbuja.Clear();
            iteracionesQuick.Clear();
            iteracionesMerge.Clear();
            iteracionesSeleccion.Clear();

            // Copiar listas para cada algoritmo
            datosBurbuja = new List<int>(datosOriginal);
            datosQuick = new List<int>(datosOriginal);
            datosMerge = new List<int>(datosOriginal);
            datosSeleccion = new List<int>(datosOriginal);

            // Limpiar chart antes de empezar
            chartTiempos.Series["Tiempos"].Points.Clear();

            // Hilo para Burbuja
            Thread hiloBurbuja = new Thread(OrdenarBurbuja)
            {
                IsBackground = true
            };
            hiloBurbuja.Start();

            // BackgroundWorkers para los demás algoritmos
            if (!backgroundWorkerQuickSort.IsBusy)
                backgroundWorkerQuickSort.RunWorkerAsync(datosQuick);

            if (!backgroundWorkerMerge.IsBusy)
                backgroundWorkerMerge.RunWorkerAsync(datosMerge);

            if (!backgroundWorkerSeleccion.IsBusy)
                backgroundWorkerSeleccion.RunWorkerAsync(datosSeleccion);
        }

        // --------------------------------------------------

        // Detener 
        private void btnDetener_Click(object sender, EventArgs e)
        {
            cancelar = true;
            if (backgroundWorkerQuickSort.IsBusy)
                backgroundWorkerQuickSort.CancelAsync();
            if (backgroundWorkerMerge.IsBusy)
                backgroundWorkerMerge.CancelAsync();
            if (backgroundWorkerSeleccion.IsBusy)
                backgroundWorkerSeleccion.CancelAsync();

            MessageBox.Show("Solicitud de detención enviada.", "Detener", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // --------------------------------------------------

        // Limpiar 
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cancelar = true;
            if (backgroundWorkerQuickSort.IsBusy) backgroundWorkerQuickSort.CancelAsync();
            if (backgroundWorkerMerge.IsBusy) backgroundWorkerMerge.CancelAsync();
            if (backgroundWorkerSeleccion.IsBusy) backgroundWorkerSeleccion.CancelAsync();

            Thread.Sleep(100);

            ReiniciarProgresos();
            lblBurbuja.Text = "Burbuja:";
            lblQuickSort.Text = "QuickSort:";
            lblMerge.Text = "MergeSort:";
            lblSeleccion.Text = "SelectionSort:";
            lblCantidad.Text = "Cantidad de elementos:";
            txtCantidad.Text = "";

            datosOriginal = new List<int>();
            datosBurbuja = null;
            datosQuick = null;
            datosMerge = null;
            datosSeleccion = null;

            chartTiempos.Series[0].Points.Clear();

            relojBurbuja.Reset();
            relojQuick.Reset();
            relojMerge.Reset();
            relojSeleccion.Reset();

            // Limpiar iteraciones
            iteracionesBurbuja.Clear();
            iteracionesQuick.Clear();
            iteracionesMerge.Clear();
            iteracionesSeleccion.Clear();

            // ELIMINAR DOCUMENTOS WORD DEL ESCRITORIO
            EliminarDocumentosWord();

            cancelar = false;
            MessageBox.Show("Interfaz, procedimientos y documentos Word limpiados.", "Limpiar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // --------------------------------------------------

        // MÉTODO PARA ELIMINAR DOCUMENTOS WORD
        private void EliminarDocumentosWord()
        {
            try
            {
                string rutaEscritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string[] archivosWord = {
                    "Burbuja_Iteraciones.docx",
                    "QuickSort_Iteraciones.docx",
                    "MergeSort_Iteraciones.docx",
                    "SelectionSort_Iteraciones.docx"
                };

                int documentosEliminados = 0;

                foreach (string archivo in archivosWord)
                {
                    string rutaCompleta = Path.Combine(rutaEscritorio, archivo);
                    if (File.Exists(rutaCompleta))
                    {
                        try
                        {
                            File.Delete(rutaCompleta);
                            documentosEliminados++;
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine($"No se pudo eliminar {archivo}: {ex.Message}");
                        }
                    }
                }

                Debug.WriteLine($"Se eliminaron {documentosEliminados} documentos Word");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al eliminar documentos Word: {ex.Message}");
            }
        }

        // --------------------------------------------------

        // BOTÓN GUARDAR WORD
        private void btnGWord_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar que los algoritmos han terminado
                bool algoritmosTerminados = lblBurbuja.Text.Contains("Completado") &&
                                          lblQuickSort.Text.Contains("Completado") &&
                                          lblMerge.Text.Contains("Completado") &&
                                          lblSeleccion.Text.Contains("Completado");

                if (!algoritmosTerminados)
                {
                    MessageBox.Show("Espere a que todos los algoritmos terminen de ejecutarse.",
                                   "Algoritmos en Proceso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Verificar que hay iteraciones para guardar
                if (iteracionesBurbuja.Count == 0 && iteracionesQuick.Count == 0 &&
                    iteracionesMerge.Count == 0 && iteracionesSeleccion.Count == 0)
                {
                    MessageBox.Show("No hay iteraciones para guardar. Ejecute los algoritmos primero.",
                                   "Sin Iteraciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Deshabilitar botón durante la generación, ek bitón GWord se susmpende momentaneamente para perminir guardar los datos sin interrupiciones.
                btnGWord.Enabled = false;
                btnGWord.Text = "Guardando...";

                // Se usa Thread para mejor funcionalidad.
                Thread hiloWord = new Thread(GuardarDocumentosWordOptimizado)
                {
                    IsBackground = true
                };
                hiloWord.Start();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al preparar documentos Word: {ex.Message}",
                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnGWord.Enabled = true;
                btnGWord.Text = "Guardar en Word";
            }
        }

        // --------------------------------------------------

        // MÉTODO PARA GUARDAR DOCUMENTOS
        private void GuardarDocumentosWordOptimizado()
        {
            int documentosCreados = 0;
            bool errorOcurrido = false;
            string errorMensaje = "";

            try
            {
                // Crear documentos individuales - Resultados resumidos para no cargar tanto el documento Word
                if (iteracionesBurbuja.Count > 0)
                {
                    if (CrearDocumentoWordResumen("Burbuja", iteracionesBurbuja, relojBurbuja.ElapsedMilliseconds, datosBurbuja))
                        documentosCreados++;
                }

                if (iteracionesQuick.Count > 0 && !errorOcurrido)
                {
                    if (CrearDocumentoWordResumen("QuickSort", iteracionesQuick, relojQuick.ElapsedMilliseconds, datosQuick))
                        documentosCreados++;
                }

                if (iteracionesMerge.Count > 0 && !errorOcurrido)
                {
                    if (CrearDocumentoWordResumen("MergeSort", iteracionesMerge, relojMerge.ElapsedMilliseconds, datosMerge))
                        documentosCreados++;
                }

                if (iteracionesSeleccion.Count > 0 && !errorOcurrido)
                {
                    if (CrearDocumentoWordResumen("SelectionSort", iteracionesSeleccion, relojSeleccion.ElapsedMilliseconds, datosSeleccion))
                        documentosCreados++;
                }
            }
            catch (Exception ex)
            {
                errorOcurrido = true;
                errorMensaje = ex.Message;
            }

            // Actualizar UI en el hilo principal
            this.Invoke((Action)(() =>
            {
                if (errorOcurrido)
                {
                    MessageBox.Show($"Error al guardar documentos Word: {errorMensaje}",
                                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Se guardaron {documentosCreados} documentos Word en el escritorio.",
                                   "Documentos Guardados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                btnGWord.Enabled = true;
                btnGWord.Text = "Guardar en Word";
            }));
        }

        // --------------------------------------------------

        // MÉTODO PARA CREAR RESUMEN EN WORD Y EVITADO AGREGAR TODAS LAS INTERACIONES
        private bool CrearDocumentoWordResumen(string nombreAlgoritmo, List<string> iteraciones, long tiempo, List<int> datosOrdenados)
        {
            Microsoft.Office.Interop.Word.Application app = null;
            Microsoft.Office.Interop.Word.Document doc = null;

            try
            {
                app = new Microsoft.Office.Interop.Word.Application();
                app.Visible = false;
                app.ScreenUpdating = false;
                doc = app.Documents.Add();

                // Crear contenido RESUMIDO
                string contenidoCompleto = GenerarResumenDocumento(nombreAlgoritmo, iteraciones, tiempo, datosOrdenados);

                // Insertar todo el contenido de una vez
                Microsoft.Office.Interop.Word.Paragraph parrafo = doc.Paragraphs.Add();
                parrafo.Range.Text = contenidoCompleto;

                // Aplicar formato básico
                doc.Range().Font.Size = 12;

                // Guardar documento
                string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +
                                 $"\\{nombreAlgoritmo}_Iteraciones.docx";
                doc.SaveAs2(filePath);

                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en {nombreAlgoritmo}: {ex.Message}");
                return false;
            }
            finally
            {
                // Liberar recursos de forma SEGURA
                try
                {
                    if (doc != null)
                    {
                        doc.Close(SaveChanges: false);
                        Marshal.ReleaseComObject(doc);
                    }
                }
                catch { }

                try
                {
                    if (app != null)
                    {
                        app.Quit();
                        Marshal.ReleaseComObject(app);
                    }
                }
                catch { }

                doc = null;
                app = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        // --------------------------------------------------

        // GENERAR RESUMEN DEL DOCUMENTO
        private string GenerarResumenDocumento(string nombreAlgoritmo, List<string> iteraciones, long tiempo, List<int> datosOrdenados)
        {
            var contenido = new System.Text.StringBuilder();

            // SOLO información esencial
            contenido.AppendLine($"ITERACIONES - ALGORITMO {nombreAlgoritmo.ToUpper()}");
            contenido.AppendLine($"Tiempo de ejecución: {tiempo} ms");
            contenido.AppendLine($"Total de iteraciones: {iteraciones.Count}");
            contenido.AppendLine($"Cantidad de elementos: {datosOriginal?.Count ?? 0}");

            // Buscar la línea de finalización
            var lineaFinal = iteraciones.LastOrDefault(linea => linea.Contains("ALGORITMO") && linea.Contains("COMPLETADO"));
            if (!string.IsNullOrEmpty(lineaFinal))
            {
                contenido.AppendLine(lineaFinal);
            }

            contenido.AppendLine($"Tiempo total: {tiempo} ms");

            if (datosOrdenados != null && datosOrdenados.Count > 0)
            {
                contenido.AppendLine($"Datos ordenados (primeros 10): {string.Join(", ", datosOrdenados.Take(10))}");
            }

            return contenido.ToString();
        }

        // --------------------------------------------------

        // MÉTODO PARA ABRIR DOCUMENTOS WORD
        private void AbrirDocumentoWord(string nombreArchivo)
        {
            try
            {
                string rutaCompleta = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    nombreArchivo);

                if (File.Exists(rutaCompleta))
                {
                    Process.Start(new ProcessStartInfo(rutaCompleta) { UseShellExecute = true });
                }
                else
                {
                    MessageBox.Show($"El documento {nombreArchivo} no se encuentra en el escritorio.\n\n" +
                                  "Primero debe:\n" +
                                  "1. Generar datos\n" +
                                  "2. Ejecutar los algoritmos\n" +
                                  "3. Guardar con 'Guardar en Word'",
                                  "Documento no encontrado",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el documento: {ex.Message}",
                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Reiniciar progresos 
        private void ReiniciarProgresos()
        {
            progressBurbuja.Value = 0;
            progressQuickSort.Value = 0;
            progressMerge.Value = 0;
            progressSeleccion.Value = 0;

            lblBurbuja.Text = "Burbuja: 0%";
            lblQuickSort.Text = "QuickSort: 0%";
            lblMerge.Text = "MergeSort: 0%";
            lblSeleccion.Text = "SelectionSort: 0%";
        }

        // --------------------------------------------------

        // BURBUJA - SOLO CAPTURA INICIO Y FINAL
        private void OrdenarBurbuja()
        {
            try
            {
                relojBurbuja.Restart();

                if (datosBurbuja == null || datosBurbuja.Count == 0)
                {
                    this.Invoke((Action)(() => lblBurbuja.Text = "Burbuja: (sin datos)"));
                    return;
                }

                int n = datosBurbuja.Count;

                // SOLO ITERACIÓN INICIAL
                iteracionesBurbuja.Add($"INICIO ALGORITMO BURBUJA");
                iteracionesBurbuja.Add($"Elementos a ordenar: {n}");
                iteracionesBurbuja.Add($"Datos iniciales (primeros 10): {string.Join(", ", datosBurbuja.Take(10))}");

                // Ordenamiento normal (sin capturar cada iteración)
                for (int i = 0; i < n - 1 && !cancelar; i++)
                {
                    for (int j = 0; j < n - i - 1; j++)
                    {
                        if (datosBurbuja[j] > datosBurbuja[j + 1])
                        {
                            int temp = datosBurbuja[j];
                            datosBurbuja[j] = datosBurbuja[j + 1];
                            datosBurbuja[j + 1] = temp;
                        }
                    }

                    // Reportar progreso solo
                    int progreso = (int)((i + 1) * 100.0 / (n - 1));
                    this.Invoke((Action)(() =>
                    {
                        progressBurbuja.Value = Math.Min(100, progreso);
                        lblBurbuja.Text = $"Burbuja: {progreso}%";
                    }));
                }

                relojBurbuja.Stop();

                // SOLO ITERACIÓN FINAL
                iteracionesBurbuja.Add($" ALGORITMO BURBUJA COMPLETADO");
                iteracionesBurbuja.Add($"Tiempo total: {relojBurbuja.ElapsedMilliseconds} ms");
                iteracionesBurbuja.Add($"Datos ordenados (primeros 10): {string.Join(", ", datosBurbuja.Take(10))}");

                this.Invoke((Action)(() =>
                {
                    progressBurbuja.Value = 100;
                    lblBurbuja.Text = $"Burbuja: Completado en {relojBurbuja.ElapsedMilliseconds} ms ({n} elementos)";
                    AgregarTiempoAlChart("Burbuja", relojBurbuja.ElapsedMilliseconds);
                }));

            }
            catch (Exception ex)
            {
                this.Invoke((Action)(() =>
                {
                    lblBurbuja.Text = "Burbuja: Error";
                    MessageBox.Show($"Error en Burbuja: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
            }
        }

        // ------------------------------------------------------------------

        // QUICKSORT - SOLO CAPTURA INICIO Y FINAL
        private void backgroundWorkerQuickSort_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var worker = sender as BackgroundWorker;
                relojQuick.Restart();

                var lista = e.Argument as List<int>;

                if (lista == null || lista.Count == 0)
                {
                    if (worker != null) worker.ReportProgress(0);
                    return;
                }

                // SOLO ITERACIÓN INICIAL
                iteracionesQuick.Add($" INICIO ALGORITMO QUICKSORT");
                iteracionesQuick.Add($"Elementos a ordenar: {lista.Count}");

                QuickSort_Background(lista, 0, lista.Count - 1, worker);

                relojQuick.Stop();

                // SOLO ITERACIÓN FINAL
                iteracionesQuick.Add($"ALGORITMO QUICKSORT COMPLETADO");
                iteracionesQuick.Add($"Tiempo total: {relojQuick.ElapsedMilliseconds} ms");
                iteracionesQuick.Add($"Datos ordenados (primeros 10): {string.Join(", ", lista.Take(10))}");

                if (worker != null && !worker.CancellationPending && !cancelar)
                    worker.ReportProgress(100);

                this.Invoke((Action)(() =>
                {
                    AgregarTiempoAlChart("QuickSort", relojQuick.ElapsedMilliseconds);
                    lblQuickSort.Text = $"QuickSort: Completado en {relojQuick.ElapsedMilliseconds} ms ({lista.Count} elementos)";
                }));
            }
            catch (Exception ex)
            {
                this.Invoke((Action)(() =>
                {
                    lblQuickSort.Text = "QuickSort: Error";
                    MessageBox.Show($"Error en QuickSort: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
            }
        }

        private void QuickSort_Background(List<int> lista, int izquierda, int derecha, BackgroundWorker worker)
        {
            if (izquierda >= derecha || cancelar) return;
            if (worker != null && worker.CancellationPending) return;

            int pivote = lista[(izquierda + derecha) / 2];
            int i = izquierda, j = derecha;

            while (i <= j)
            {
                while (lista[i] < pivote) i++;
                while (lista[j] > pivote) j--;
                if (i <= j)
                {
                    int tmp = lista[i];
                    lista[i] = lista[j];
                    lista[j] = tmp;
                    i++; j--;
                }
            }

            int progreso = (int)(((double)(i) / lista.Count) * 100);
            if (worker != null && worker.WorkerReportsProgress)
                worker.ReportProgress(Math.Min(100, progreso));

            if (izquierda < j) QuickSort_Background(lista, izquierda, j, worker);
            if (i < derecha) QuickSort_Background(lista, i, derecha, worker);
        }

        private void backgroundWorkerQuickSort_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressQuickSort.Value = Math.Min(100, e.ProgressPercentage);
            lblQuickSort.Text = $"QuickSort: {e.ProgressPercentage}%";
        }

        private void backgroundWorkerQuickSort_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                this.Invoke((Action)(() => lblQuickSort.Text = "QuickSort: Cancelado"));
            }
        }

        // ------------------------------------------------------------------

        // MERGESORT - SOLO CAPTURA INICIO Y FINAL
        private void backgroundWorkerMerge_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var worker = sender as BackgroundWorker;
                relojMerge.Restart();

                var lista = e.Argument as List<int>;

                if (lista == null || lista.Count == 0)
                {
                    if (worker != null) worker.ReportProgress(0);
                    return;
                }

                // SOLO ITERACIÓN INICIAL
                iteracionesMerge.Add($"=== INICIO ALGORITMO MERGESORT ===");
                iteracionesMerge.Add($"Elementos a ordenar: {lista.Count}");
                iteracionesMerge.Add($"Datos iniciales (primeros 10): {string.Join(", ", lista.Take(10))}");

                MergeSort_Background(lista, 0, lista.Count - 1, worker);

                relojMerge.Stop();

                // SOLO ITERACIÓN FINAL
                iteracionesMerge.Add($"=== ALGORITMO MERGESORT COMPLETADO ===");
                iteracionesMerge.Add($"Tiempo total: {relojMerge.ElapsedMilliseconds} ms");
                iteracionesMerge.Add($"Datos ordenados (primeros 10): {string.Join(", ", lista.Take(10))}");

                if (worker != null && !worker.CancellationPending && !cancelar)
                    worker.ReportProgress(100);

                this.Invoke((Action)(() =>
                {
                    AgregarTiempoAlChart("MergeSort", relojMerge.ElapsedMilliseconds);
                    lblMerge.Text = $"MergeSort: Completado en {relojMerge.ElapsedMilliseconds} ms ({lista.Count} elementos)";
                }));
            }
            catch (Exception ex)
            {
                this.Invoke((Action)(() =>
                {
                    lblMerge.Text = "MergeSort: Error";
                    MessageBox.Show($"Error en MergeSort: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
            }
        }

        private void MergeSort_Background(List<int> lista, int izquierda, int derecha, BackgroundWorker worker)
        {
            if (izquierda < derecha && !cancelar && (worker == null || !worker.CancellationPending))
            {
                int medio = (izquierda + derecha) / 2;

                MergeSort_Background(lista, izquierda, medio, worker);
                MergeSort_Background(lista, medio + 1, derecha, worker);

                Merge(lista, izquierda, medio, derecha);

                // Reportar progreso
                int progreso = (int)(((double)(derecha) / lista.Count) * 100);
                if (worker != null && worker.WorkerReportsProgress)
                    worker.ReportProgress(Math.Min(100, progreso));
            }
        }

        private void Merge(List<int> lista, int izquierda, int medio, int derecha)
        {
            int n1 = medio - izquierda + 1;
            int n2 = derecha - medio;

            List<int> izquierdaArray = new List<int>();
            List<int> derechaArray = new List<int>();

            for (int i = 0; i < n1; i++)
                izquierdaArray.Add(lista[izquierda + i]);
            for (int j = 0; j < n2; j++)
                derechaArray.Add(lista[medio + 1 + j]);

            int x = 0, y = 0;
            int k = izquierda;

            while (x < n1 && y < n2)
            {
                if (izquierdaArray[x] <= derechaArray[y])
                {
                    lista[k] = izquierdaArray[x];
                    x++;
                }
                else
                {
                    lista[k] = derechaArray[y];
                    y++;
                }
                k++;
            }

            while (x < n1)
            {
                lista[k] = izquierdaArray[x];
                x++;
                k++;
            }

            while (y < n2)
            {
                lista[k] = derechaArray[y];
                y++;
                k++;
            }
        }

        private void backgroundWorkerMerge_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressMerge.Value = Math.Min(100, e.ProgressPercentage);
            lblMerge.Text = $"MergeSort: {e.ProgressPercentage}%";
        }

        private void backgroundWorkerMerge_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                this.Invoke((Action)(() => lblMerge.Text = "MergeSort: Cancelado"));
            }
        }

        // ------------------------------------------------------------------

        // SELECTION SORT - SOLO CAPTURA INICIO Y FINAL
        private void backgroundWorkerSeleccion_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var worker = sender as BackgroundWorker;
                relojSeleccion.Restart();

                var lista = e.Argument as List<int>;

                if (lista == null || lista.Count == 0)
                {
                    if (worker != null) worker.ReportProgress(0);
                    return;
                }

                int n = lista.Count;

                // SOLO ITERACIÓN INICIAL
                iteracionesSeleccion.Add($"=== INICIO ALGORITMO SELECTION SORT ===");
                iteracionesSeleccion.Add($"Elementos a ordenar: {n}");
                iteracionesSeleccion.Add($"Datos iniciales (primeros 10): {string.Join(", ", lista.Take(10))}");

                // Ordenamiento normal (sin capturar cada iteración)
                for (int i = 0; i < n - 1 && !cancelar && (worker == null || !worker.CancellationPending); i++)
                {
                    int minIndex = i;

                    for (int j = i + 1; j < n; j++)
                    {
                        if (lista[j] < lista[minIndex])
                        {
                            minIndex = j;
                        }
                    }

                    if (minIndex != i)
                    {
                        int temp = lista[i];
                        lista[i] = lista[minIndex];
                        lista[minIndex] = temp;
                    }

                    // Reportar progreso
                    int progreso = (int)((i + 1) * 100.0 / (n - 1));
                    if (worker != null && worker.WorkerReportsProgress)
                        worker.ReportProgress(Math.Min(100, progreso));
                }

                relojSeleccion.Stop();

                // SOLO ITERACIÓN FINAL
                iteracionesSeleccion.Add($"=== ALGORITMO SELECTION SORT COMPLETADO ===");
                iteracionesSeleccion.Add($"Tiempo total: {relojSeleccion.ElapsedMilliseconds} ms");
                iteracionesSeleccion.Add($"Datos ordenados (primeros 10): {string.Join(", ", lista.Take(10))}");

                if (worker != null && !worker.CancellationPending && !cancelar)
                    worker.ReportProgress(100);

                this.Invoke((Action)(() =>
                {
                    AgregarTiempoAlChart("SelectionSort", relojSeleccion.ElapsedMilliseconds);
                    lblSeleccion.Text = $"SelectionSort: Completado en {relojSeleccion.ElapsedMilliseconds} ms ({n} elementos)";
                }));
            }
            catch (Exception ex)
            {
                this.Invoke((Action)(() =>
                {
                    lblSeleccion.Text = "SelectionSort: Error";
                    MessageBox.Show($"Error en SelectionSort: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
            }
        }

        private void backgroundWorkerSeleccion_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressSeleccion.Value = Math.Min(100, e.ProgressPercentage);
            lblSeleccion.Text = $"SelectionSort: {e.ProgressPercentage}%";
        }

        private void backgroundWorkerSeleccion_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                this.Invoke((Action)(() => lblSeleccion.Text = "SelectionSort: Cancelado"));
            }
        }

        // --------------------------------------------------

        // Actualizar Chart
        private void AgregarTiempoAlChart(string algoritmo, long tiempo)
        {
            this.Invoke((Action)(() =>
            {
                var serie = chartTiempos.Series["Tiempos"];

                var puntoExistente = serie.Points.FirstOrDefault(p => p.AxisLabel == algoritmo);
                if (puntoExistente != null)
                {
                    puntoExistente.YValues[0] = tiempo;
                    puntoExistente.Label = tiempo.ToString();
                }
                else
                {
                    int idx = serie.Points.AddXY(algoritmo, tiempo);
                    serie.Points[idx].Label = tiempo.ToString();
                }

                var order = new[] { "Burbuja", "QuickSort", "MergeSort", "SelectionSort" };
                var snapshot = serie.Points.ToDictionary(p => p.AxisLabel, p => p.YValues[0]);
                serie.Points.Clear();
                foreach (var name in order)
                {
                    if (snapshot.ContainsKey(name))
                    {
                        double val = snapshot[name];
                        int id = serie.Points.AddXY(name, val);
                        serie.Points[id].Label = ((long)val).ToString();
                    }
                }
            }));
        }
    }
}