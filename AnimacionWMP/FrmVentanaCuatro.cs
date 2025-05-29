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
    
    public partial class FrmVentanaCuatro : Form
    {
        private Ondas ondas;
        private double tiempoGlobal;
        private const double timerIntervaloSegundos = 0.03; // 30 ms
        private int direccionAnimacion = 1;                 // 1 = adelante, -1 = retroceder
        private const double DURACION_MAXIMA = 30.0;         // segundos       

        public FrmVentanaCuatro()
        {
            InitializeComponent();
            // habilita doble búfer para el Form completo (evita parpadeo)
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void btnPausar_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            FrmVentanaCuatro_Load(sender, e);
            pictureBox1.Invalidate();
        }

        private void btnAdelantar_Click(object sender, EventArgs e)
        {
            tiempoGlobal = Math.Min(DURACION_MAXIMA, tiempoGlobal + 1.0);
            progressBar1.Value = (int)(tiempoGlobal * 100);
            pictureBox1.Invalidate();
        }

        private void btnRetroceder_Click(object sender, EventArgs e)
        {
            tiempoGlobal = Math.Max(0.0, tiempoGlobal - 1.0);
            progressBar1.Value = (int)(tiempoGlobal * 100);
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (ondas != null)
                ondas.Dibujar(e.Graphics, pictureBox1.ClientSize);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Avanza o retrocede el tiempo global
            tiempoGlobal += timerIntervaloSegundos * direccionAnimacion;
            if (tiempoGlobal < 0) tiempoGlobal = 0;
            if (tiempoGlobal >= DURACION_MAXIMA)
            {
                tiempoGlobal = 0;
                progressBar1.Value = 0;
            }

            // Actualiza la física de las ondas
            ondas.Actualizar();

            // Actualiza la barra de progreso
            int progreso = (int)(tiempoGlobal * 100);
            progressBar1.Value = Math.Min(progressBar1.Maximum, Math.Max(0, progreso));

            // Fuerza repintado
            pictureBox1.Invalidate();
        }

        private void FrmVentanaCuatro_Load(object sender, EventArgs e)
        {
            // Calcula la longitud base (que será el “radio”) según el PictureBox
            float longitudBase = Math.Min(pictureBox1.Width, pictureBox1.Height) / 2f - 10f;

            // Instancia Ondas en el centro del PictureBox
            ondas = new Ondas(
                new PointF(pictureBox1.Width / 2f, pictureBox1.Height / 2f),
                longitudBase,
                rayCount: 36,   // Número de “rayos” alrededor
                amp: 30f,       // Amplitud de la oscilación
                vel: 0.08f      // Velocidad
            );

            // Configura el timer
            timer1.Interval = (int)(timerIntervaloSegundos * 1000); // milisegundos

            // Configura la ProgressBar (si la tienes)
            progressBar1.Minimum = 0;
            progressBar1.Maximum = (int)(DURACION_MAXIMA * 100);
            progressBar1.Value = 0;

            tiempoGlobal = 0;
        }
    }
}
