using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using AnimacionFiguras;

namespace AnimacionFiguras
{
    public partial class FrmVentana : Form
    {
        private Rectangulo rectangulo;
        private Random rnd = new Random();
        private Color[] coloresNeon = { Color.Cyan, Color.Magenta, Color.Lime, Color.Yellow, Color.Fuchsia };
        private int colorIndex = 0;
        private int direccionAnimacion = 5; // 1 = adelante, -1 = retroceder
        private double tiempoGlobal = 0; // A mayor tiempo, más rectángulos se crean
        private double timerIntervaloSegundos = 0.1; // A mayor valor, más lento avanza la animación
        private const double DURACION_MAXIMA = 800; // segundos

        public FrmVentana()
        {
            InitializeComponent();

            this.Load += FrmVentana_Load;
            pictureBox1.Paint += pictureBox1_Paint_1;
            btnIniciar.Click += btnIniciar_Click;
            btnPausar.Click += btnPausar_Click;
            btnDetener.Click += btnDetener_Click;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            tiempoGlobal += timerIntervaloSegundos * direccionAnimacion; // Avanza o retrocede según la dirección
            if (tiempoGlobal < 0) tiempoGlobal = 0; // Evita tiempos negativos
            if (tiempoGlobal >= DURACION_MAXIMA)
            {
                // Reinicia la animación automáticamente
                tiempoGlobal = 0;
                rectangulo.ResetAnimacion();
                rectangulo.SetTiempoGlobal(0);
            }
            rectangulo.SetTiempoGlobal(tiempoGlobal);

            // Actualiza la barra de progreso (escala a milésimas para mayor precisión visual)
            int progreso = (int)(tiempoGlobal * 100);
            if (progreso > progressBar1.Maximum) progreso = progressBar1.Maximum;
            progressBar1.Value = progreso;

            pictureBox1.Invalidate();
        }

        // Botones
        private void btnIniciar_Click(object sender, EventArgs e) => timer1.Start();
        private void btnPausar_Click(object sender, EventArgs e) => timer1.Stop();
        private void btnDetener_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            tiempoGlobal = 0; // Reinicia el tiempo global del formulario
            rectangulo.ResetAnimacion(); // Limpia la animación y el tiempo en la clase Rectangulo
            rectangulo.SetTiempoGlobal(0); // Asegura que el tiempo global en Rectangulo también sea 0
            progressBar1.Value = 0; // Reinicia la barra de progreso
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint_1(object sender, PaintEventArgs e)
        {
            // Pasa el tamaño del PictureBox para limpiar el trail
            rectangulo.Dibujar(e.Graphics, pictureBox1.ClientSize);
        }

        private void FrmVentana_Load(object sender, EventArgs e)
        {
            rectangulo = new Rectangulo(
                new PointF(pictureBox1.Width / 2, pictureBox1.Height / 2),
                120, // ancho inicial
                60,  // alto inicial
                coloresNeon[0]
            );
            timer1.Interval = 30; // Intervalo de actualización del timer en milisegundos
            timer1.Tick += Timer1_Tick;

            // Inicializa la barra de progreso
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 80000; // 80 segundos * 100
            progressBar1.Value = 0;
        }

        private void btnAdelantar_Click(object sender, EventArgs e)
        {
            tiempoGlobal += 5.0; // Adelanta 1 segundo
            rectangulo.SetTiempoGlobal(tiempoGlobal);
            pictureBox1.Invalidate();
        }

        private void btnRetroceder_Click(object sender, EventArgs e)
        {
            tiempoGlobal -= 5.0; // Retrocede 1 segundo
            if (tiempoGlobal < 0) tiempoGlobal = 0;
            rectangulo.SetTiempoGlobal(tiempoGlobal);
            pictureBox1.Invalidate();
        }
    }
}
