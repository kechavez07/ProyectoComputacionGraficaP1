using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimacionFiguras
{
    public partial class FrmVentanaTres : Form
    {
        private CirculoDos circuloDos;
        private double tiempoGlobal;
        private const double timerIntervaloSegundos = 0.03; // 30 ms
        private int direccionAnimacion = 1;                 // 1 = adelante, -1 = retroceder
        private const double DURACION_MAXIMA = 30.0;         // segundos

        public FrmVentanaTres()
        {
            InitializeComponent();
            // Asociar eventos
            this.Load += FrmVentanaTres_Load;
            pictureBox1.Paint += pictureBox1_Paint;
            timer1.Tick += timer1_Tick;
            btnIniciar.Click += btnIniciar_Click;
            btnPausar.Click += btnPausar_Click;
            btnDetener.Click += btnDetener_Click;
            btnAdelantar.Click += btnAdelantar_Click;
            btnRetroceder.Click += btnRetroceder_Click;
        }

        private void btnIniciar_Click(object sender, EventArgs e) => timer1.Start();

        private void btnPausar_Click(object sender, EventArgs e) => timer1.Stop();

        private void btnDetener_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            FrmVentanaTres_Load(sender, e);   // Reinicia estado y tiempo
            pictureBox1.Invalidate();
        }

        private void btnAdelantar_Click(object sender, EventArgs e)
        {
            tiempoGlobal = Math.Min(DURACION_MAXIMA, tiempoGlobal + 1.0);
            progressBar1.Value = (int)(tiempoGlobal * 100);
            circuloDos.SetTiempo(tiempoGlobal);
            pictureBox1.Invalidate();
        }

        private void btnRetroceder_Click(object sender, EventArgs e)
        {
            tiempoGlobal = Math.Max(0.0, tiempoGlobal - 1.0);
            progressBar1.Value = (int)(tiempoGlobal * 100);
            circuloDos.SetTiempo(tiempoGlobal); 
            pictureBox1.Invalidate();
        }

        private void FrmVentanaTres_Load(object sender, EventArgs e)
        {
            // Calcula el radio máximo según el área del PictureBox (dejando un pequeño margen)
            float radioMax = Math.Min(pictureBox1.Width, pictureBox1.Height) / 2f - 10f;

            circuloDos = new CirculoDos(
                new PointF(pictureBox1.Width / 2f, pictureBox1.Height / 2f),
                radioMax,
                32  // número de líneas/anillos (puedes ajustar)
            );

            timer1.Interval = 30; // milisegundos

            // Inicializar ProgressBar
            progressBar1.Minimum = 0;
            progressBar1.Maximum = (int)(DURACION_MAXIMA * 100);
            progressBar1.Value = 0;

            tiempoGlobal = 0;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (circuloDos != null)
                circuloDos.Dibujar(e.Graphics, pictureBox1.ClientSize);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Avanza o retrocede el tiempo de la animación
            tiempoGlobal += timerIntervaloSegundos * direccionAnimacion;
            if (tiempoGlobal < 0) tiempoGlobal = 0;
            if (tiempoGlobal >= DURACION_MAXIMA)
            {
                tiempoGlobal = 0;
                progressBar1.Value = 0;
            }

            // Actualiza la física de tu onda
            circuloDos.Actualizar();

            // Actualiza la barra de progreso
            int progreso = (int)(tiempoGlobal * 100);
            progressBar1.Value = Math.Min(progressBar1.Maximum, Math.Max(0, progreso));

            // Fuerza repintado
            pictureBox1.Invalidate();
        }
    }
}
