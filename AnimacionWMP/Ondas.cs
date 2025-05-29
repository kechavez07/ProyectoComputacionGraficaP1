using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace AnimacionFiguras
{
    internal class Ondas : Figura
    {
        private static readonly Color[] Paleta = new[]
        {
            Color.Red, Color.Orange, Color.Yellow,
            Color.Green, Color.Blue, Color.Indigo,
            Color.Violet
        };

        // Amplitud y velocidad en caso de querer animar (opcional)
        private readonly float amplitude;
        private readonly float velocity;

        // Fase de rotación (animación)
        private float phase;

        private readonly float baseLength;
        private readonly int rayCount;

        public Ondas(PointF centro, float baseLength, int rayCount,
                     float amp = 0f, float vel = 0f)
            : base(centro, baseLength, rayCount)
        {
            this.centro     = centro;
            this.baseLength = baseLength;
            this.rayCount   = rayCount;

            this.amplitude = amp;
            this.velocity = vel;
            this.phase = 0f;
        }


        // Llamado por tu temporizador o por SetTiempo para avanzar la fase
        

        // Si prefieres controlar el tiempo manualmente:
        public void SetTiempo(double tiempoGlobal)
        {
            // Por ejemplo: fase = tiempoGlobal * velocity;
            phase = (float)(tiempoGlobal * velocity) % (2 * (float)Math.PI);
        }

        public override void Dibujar(Graphics g, Size area)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            float angleInc = 2f * (float)Math.PI / rayCount;
            int puntosPorRayo = 50;    // cuántos segmentos por rayo
            float ciclosPorRayo = 2f;  // ciclos de onda a lo largo del rayo

            for (int i = 0; i < rayCount; i++)
            {
                float theta = i * angleInc + phase;
                float cosTh = (float)Math.Cos(theta);
                float sinTh = (float)Math.Sin(theta);

                // Generar los puntos ondulados
                var puntos = new PointF[puntosPorRayo + 1];
                for (int j = 0; j <= puntosPorRayo; j++)
                {
                    float t = j / (float)puntosPorRayo;  // de 0.0 a 1.0 a lo largo del rayo

                    // Punto base sobre el rayo
                    var basePt = new PointF(
                        centro.X + baseLength * t * cosTh,
                        centro.Y + baseLength * t * sinTh
                    );

                    // Desplazamiento perpendicular: onda senoidal
                    float wave = amplitude * (float)Math.Sin(2 * Math.PI * ciclosPorRayo * t + phase * 6f);
                    var offset = new PointF(-sinTh * wave, cosTh * wave);

                    puntos[j] = new PointF(basePt.X + offset.X, basePt.Y + offset.Y);
                }

                // Dibujar la línea ondulada
                Color col = Paleta[i % Paleta.Length];
                using (var pen = new Pen(col, 2f))
                    g.DrawLines(pen, puntos);
            }
        }

    }
}
