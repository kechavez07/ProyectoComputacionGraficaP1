using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace AnimacionFiguras
{
    internal class CirculoDos : Figura
    {
        private const float Espacio = 15f;                 // separación entre anillos
        private const float Amplitud = 10f;                // cuánto varía el radio
        private const float Velocidad = 0.05f;             // rapidez de la animación
        private const float DesfasePorAnillo = (float)(Math.PI / 6); // fase extra por cada anillo

        private readonly float[] baseRadios;    // radios constantes
        private readonly float[] dynRadios;     // radios animados
        private float fase;                     // fase global de la onda
        private float tiempo;                  // tiempo global de la animación

        private static readonly Color[] Paleta = new[]
        {
            Color.Red, Color.Orange, Color.Yellow,
            Color.Green, Color.Blue, Color.Indigo,
            Color.Violet
        };

        public CirculoDos(PointF centro, float radioMax, int cantidadLineas)
            : base(centro, radioMax, cantidadLineas)
        {
            // calculo cuántos anillos caben
            int count = (int)Math.Ceiling(radioMax / Espacio);
            baseRadios = new float[count];
            dynRadios = new float[count];

            // inicializo los radios base y dinámicos
            for (int i = 0; i < count; i++)
            {
                float r = radioMax - i * Espacio;
                baseRadios[i] = r;
                dynRadios[i] = r;
            }
        }

        public override void Actualizar()
        {
            // Ajusta cada radio con una onda seno
            for (int i = 0; i < baseRadios.Length; i++)
            {
                float faseLocal = fase + i * DesfasePorAnillo;
                dynRadios[i] = baseRadios[i]
                              + Amplitud * (float)Math.Sin(faseLocal);
            }

            // Avanza la fase global para la siguiente iteración
            fase += Velocidad;
        }

        public void SetTiempo(double tiempoGlobal)
        {
            float tiempoG = (float)tiempoGlobal;
            tiempo = tiempoG >= 0 ? tiempoG : 0;
            Actualizar();
        }

        public override void Dibujar(Graphics g, Size area)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            for (int i = 0; i < dynRadios.Length; i++)
            {
                float r = dynRadios[i];
                var rect = new RectangleF(
                    centro.X - r,
                    centro.Y - r,
                    r * 2,
                    r * 2
                );

                using (var pen = new Pen(Paleta[i % Paleta.Length], 2f))
                    g.DrawEllipse(pen, rect);
            }
        }
    }
}
