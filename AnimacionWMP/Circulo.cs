using System;
using System.Drawing;

namespace AnimacionFiguras
{
    public class Circulo : Figura
    {
        private readonly float[] factores;
        private readonly Random rnd = new();

        public Circulo(PointF centro, float radio, int cantidadLineas)
            : base(centro, radio, cantidadLineas)
        {
            factores = new float[cantidadLineas];
            InicializarFactores();
        }

        private void InicializarFactores()
        {
            for (int i = 0; i < factores.Length; i++)
                factores[i] = 1f;
        }

        // Llama a este método en cada frame para animar el "crecimiento"
        public override void Actualizar()
        {
            for (int i = 0; i < factores.Length; i++)
            {
                // Puedes ajustar los valores 0.5f y 1.5f para el rango de crecimiento
                factores[i] = 0.5f + (float)rnd.NextDouble() * 1.5f;
            }
        }

        // Dibuja el círculo con las líneas animadas
        public override void Dibujar(Graphics g, Size area)
        {
            for (int i = 0; i < cantidadLineas; i++)
            {
                float angulo = anguloActual + (float)(2 * Math.PI * i / cantidadLineas);
                float longitud = radio * factores[i];
                PointF puntoFinal = new PointF(
                    centro.X + longitud * (float)Math.Cos(angulo),
                    centro.Y + longitud * (float)Math.Sin(angulo)
                );
                g.DrawLine(Pens.Cyan, centro, puntoFinal);
            }
        }

        public void DibujarConColor(Graphics g, Size area, Color color)
        {
            for (int i = 0; i < cantidadLineas; i++)
            {
                float angulo = anguloActual + (float)(2 * Math.PI * i / cantidadLineas);
                float longitud = radio * factores[i];
                PointF puntoFinal = new PointF(
                    centro.X + longitud * (float)Math.Cos(angulo),
                    centro.Y + longitud * (float)Math.Sin(angulo)
                );
                using (var pen = new Pen(color, 2f))
                {
                    g.DrawLine(pen, centro, puntoFinal);
                }
            }
        }
    }
}

