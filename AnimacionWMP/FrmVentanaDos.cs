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
    public partial class FrmVentanaDos : Form
    {
        private Circulo circulo;
        private Circulo circuloDos; // Círculo verde claro
        private double tiempoGlobal = 0;
        private double timerIntervaloSegundos = 0.03; // 30 ms
        private int direccionAnimacion = 1; // 1 = adelante, -1 = retroceder
        private const double DURACION_MAXIMA = 30.0; // segundos

        public FrmVentanaDos()
        {
            InitializeComponent();

            this.Load += FrmVentanaDos_Load;
            pictureBox1.Paint += pictureBox1_Paint;
            btnIniciar.Click += btnIniciar_Click;
            btnPausar.Click += btnPausar_Click;
            btnDetener.Click += btnDetener_Click;
            btnAdelantar.Click += btnAdelantar_Click;
            btnRetroceder.Click += btnRetroceder_Click;
        }

        private void FrmVentanaDos_Load(object sender, EventArgs e)
        {
            circulo = new Circulo(
                new PointF(pictureBox1.Width / 2, pictureBox1.Height / 2),
                80, // radio inicial
                32  // cantidad de líneas
            );
            circuloDos = null;
            timer1.Interval = 30;
            timer1.Tick += Timer1_Tick;

            progressBar1.Minimum = 0;
            progressBar1.Maximum = (int)(DURACION_MAXIMA * 100);
            progressBar1.Value = 0;
            tiempoGlobal = 0;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            tiempoGlobal += timerIntervaloSegundos * direccionAnimacion;
            if (tiempoGlobal < 0) tiempoGlobal = 0;
            if (tiempoGlobal >= DURACION_MAXIMA)
            {
                tiempoGlobal = 0;
                progressBar1.Value = 0;
            }

            // Actualiza la animación del círculo principal
            circulo.AnguloActual += 0.01f * direccionAnimacion;
            circulo.Actualizar();

            // Actualiza la barra de progreso
            int progreso = (int)(tiempoGlobal * 100);
            if (progreso > progressBar1.Maximum) progreso = progressBar1.Maximum;
            progressBar1.Value = progreso;

            pictureBox1.Invalidate();
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
            FrmVentanaDos_Load(sender, e); // Reinicia la animación y el tiempo
            progressBar1.Value = 0;
            pictureBox1.Invalidate();
        }

        private void btnAdelantar_Click(object sender, EventArgs e)
        {
            tiempoGlobal += 1.0;
            if (tiempoGlobal > DURACION_MAXIMA) tiempoGlobal = DURACION_MAXIMA;
            progressBar1.Value = (int)(tiempoGlobal * 100);
            pictureBox1.Invalidate();
        }

        private void btnRetroceder_Click(object sender, EventArgs e)
        {
            tiempoGlobal -= 1.0;
            if (tiempoGlobal < 0) tiempoGlobal = 0;
            progressBar1.Value = (int)(tiempoGlobal * 100);
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            circulo.Dibujar(e.Graphics, pictureBox1.ClientSize);

            // Dibuja el círculo verde claro encima después de 15 segundos
            if (tiempoGlobal >= 15.0)
            {
                if (circuloDos == null)
                {
                    circuloDos = new Circulo(
                        new PointF(pictureBox1.Width / 2, pictureBox1.Height / 2),
                        80, // radio
                        32  // cantidad de líneas
                    );
                }
                circuloDos.Actualizar();
                circuloDos.DibujarConColor(e.Graphics, pictureBox1.ClientSize, Color.Red);
            }
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {

        }
    }
}
