using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace AnimacionFiguras
{
    internal class Ondas : Figura
    {
        private readonly int cantidadRayos;         // cuántos rayos dibujar
        private readonly float baseLongitud;       // longitud media de cada rayo
        private readonly float amplitud;           // cuánto varía la longitud (radio)
        private readonly float velocidad;          // velocidad de oscilación de la longitud
        private readonly float[] dynLongitudes;    // longitudes dinámicas (radios)
        private float fase;                        // fase global de la onda

        // --- parámetros para la forma de onda en el dibujo ---
        private const int PuntosPorRayo = 50;    // segmentos por rayo
        private const float CiclosPorRayo = 2f;    // ciclos de sinusoide por rayo
        private const float AmplitudOnda = 15f;   // desplazamiento máximo perpendicular
        // -------------------------------------------------------

        private static readonly Color[] Paleta = new[]
        {
            Color.Red, Color.Orange, Color.Yellow,
            Color.Green, Color.Blue, Color.Indigo,
            Color.Violet
        };

        public Ondas(PointF centro, float baseLength, int rayCount,
                     float amp = 20f, float vel = 0.1f)
            : base(centro, baseLength, rayCount)
        {
            this.baseLongitud = baseLength;
            this.cantidadRayos = rayCount;
            this.amplitud = amp;
            this.velocidad = vel;
            this.dynLongitudes = new float[rayCount];
            this.fase = 0f;

            // inicializamos todos los radios con el valor base
            for (int i = 0; i < cantidadRayos; i++)
                dynLongitudes[i] = baseLongitud;
        }

        public override void Actualizar()
        {
            // varía cada radio con una senoide
            for (int i = 0; i < cantidadRayos; i++)
            {
                float faseLocal = fase + i * (2f * (float)Math.PI / cantidadRayos);
                dynLongitudes[i] = baseLongitud + amplitud * (float)Math.Sin(faseLocal);
            }
            fase += velocidad;  // avanza la fase global
        }

        public override void Dibujar(Graphics g, Size area)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            for (int i = 0; i < cantidadRayos; i++)
            {
                // dirección radial y perpendicular
                float angulo = 2f * (float)Math.PI * i / cantidadRayos;
                var dir = new PointF((float)Math.Cos(angulo), (float)Math.Sin(angulo));
                var perp = new PointF(-dir.Y, dir.X);

                // longitud “radio” para este rayo
                float longitudMax = dynLongitudes[i];

                // construimos la sinusoide a lo largo de la línea
                var puntos = new PointF[PuntosPorRayo];
                for (int j = 0; j < PuntosPorRayo; j++)
                {
                    float t = j / (float)(PuntosPorRayo - 1);
                    float dist = t * longitudMax;
                    float faseOnda = fase + t * CiclosPorRayo * 2f * (float)Math.PI;
                    float offset = AmplitudOnda * (float)Math.Sin(faseOnda);
                    puntos[j] = new PointF(
                        centro.X + dir.X * dist + perp.X * offset,
                        centro.Y + dir.Y * dist + perp.Y * offset
                    );
                }

                using (var lapiz = new Pen(Paleta[i % Paleta.Length], 2f))
                    g.DrawLines(lapiz, puntos);
            }
        }
    }
}
