using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AnimacionFiguras
{
    internal class Rectangulo : Figura
    {
        private readonly List<RectanguloAnimado> rectangulos = new();
        private readonly Random rnd = new();

        private static readonly Color[] coloresFijos = new Color[]
        {
            //Color.FromArgb(139, 0, 0),          // Rojo oscuro (Dark Red)
            //Color.FromArgb(255, 36, 0),         // Escarlata (Scarlet)
            Color.FromArgb(0, 191, 255),        // Celeste (Deep Sky Blue)
            Color.FromArgb(0, 0, 128),          // Azul marino (Navy)
            //Color.FromArgb(247, 254, 250),      // Blanqueado (Blanched Almond)
            //Color.FromArgb(169, 162, 137),      // Gris claro (Light Gray)
            Color.FromArgb(76, 103, 165),       // Azul claro (Light Blue)
            //Color.FromArgb(179, 213, 233),     // Azul pálido (Pale Blue)
            Color.FromArgb(0, 191, 255),        // Celeste
            //Color.FromArgb(0, 0, 128),          // Azul marino
            //Color.FromArgb(76, 103, 165),       // Azul claro
            Color.FromArgb(179, 213, 233)       // Azul pálido
        };

        private readonly double intervaloSegundos = 15.0f;
        private double tiempoGlobal = 0;
        private double ultimoRectCreado = 0;
        private float grosorLinea = 0.5f;
        public float GrosorLinea
        {
            get => grosorLinea;
            set => grosorLinea = value > 0 ? value : 1f;
        }

        public Rectangulo(PointF centro, float ancho, float alto, Color colorNeon)
            : base(centro, 0, 4)
        {
        }

        public void CambiarColor(Color nuevoColor) { }

        public float Ancho { get; set; }
        public float Alto { get; set; }

        // Llama a esto en cada avance/retroceso de tiempo
        public void SetTiempoGlobal(double nuevoTiempo)
        {
            tiempoGlobal = Math.Max(0, nuevoTiempo);
        }

        public void ResetAnimacion()
        {
            rectangulos.Clear();
            tiempoGlobal = 0;
            ultimoRectCreado = 0;
        }

        public override void Dibujar(Graphics g, Size area)
        {
            // Crea nuevos rectángulos si corresponde
            while (tiempoGlobal - ultimoRectCreado >= intervaloSegundos)
            {
                ultimoRectCreado += intervaloSegundos;
                var color = coloresFijos[rnd.Next(coloresFijos.Length)];
                rectangulos.Add(new RectanguloAnimado(
                    ultimoRectCreado,
                    centro,
                    20, // ancho inicial
                    10, // alto inicial
                    0,
                    color,
                    grosorLinea
                ));
            }

            // Dibuja y elimina los que ya no se ven
            for (int i = rectangulos.Count - 1; i >= 0; i--)
            {
                var r = rectangulos[i];
                var (ancho, alto, angulo) = r.EstadoActual(tiempoGlobal);

                // Dibuja estela neón
                for (int glow = 8; glow >= 1; glow -= 2)
                {
                    using (var glowPen = new Pen(Color.FromArgb(60, r.Color), r.Grosor + glow))
                    {
                        glowPen.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
                        DrawRect(g, r.Centro, angulo, ancho, alto, glowPen);
                    }
                }
                using (var pen = new Pen(r.Color, r.Grosor) { LineJoin = System.Drawing.Drawing2D.LineJoin.Round })
                {
                    DrawRect(g, r.Centro, angulo, ancho, alto, pen);
                }

                if (FueraDeArea(r.Centro, ancho, alto, angulo, area))
                    rectangulos.RemoveAt(i);
            }
        }

        private bool FueraDeArea(PointF centro, float ancho, float alto, float angulo, Size area)
        {
            PointF[] puntos = new PointF[4];
            double a = angulo;
            float hw = ancho / 2f;
            float hh = alto / 2f;

            PointF[] esquinas = new PointF[]
            {
                new PointF(+hw, -hh),
                new PointF(+hw, +hh),
                new PointF(-hw, +hh),
                new PointF(-hw, -hh)
            };

            for (int i = 0; i < 4; i++)
            {
                float x = esquinas[i].X;
                float y = esquinas[i].Y;
                float xr = centro.X + (float)(x * Math.Cos(a) - y * Math.Sin(a));
                float yr = centro.Y + (float)(x * Math.Sin(a) + y * Math.Cos(a));
                puntos[i] = new PointF(xr, yr);
            }

            bool fueraIzquierda = puntos.All(p => p.X < 0);
            bool fueraDerecha = puntos.All(p => p.X > area.Width);
            bool fueraArriba = puntos.All(p => p.Y < 0);
            bool fueraAbajo = puntos.All(p => p.Y > area.Height);

            return fueraIzquierda || fueraDerecha || fueraArriba || fueraAbajo;
        }

        private void DrawRect(Graphics g, PointF centro, float angulo, float ancho, float alto, Pen pen)
        {
            PointF[] puntos = new PointF[4];
            double a = angulo;
            float hw = ancho / 2f;
            float hh = alto / 2f;

            PointF[] esquinas = new PointF[]
            {
                new PointF(+hw, -hh),
                new PointF(+hw, +hh),
                new PointF(-hw, +hh),
                new PointF(-hw, -hh)
            };

            for (int i = 0; i < 4; i++)
            {
                float x = esquinas[i].X;
                float y = esquinas[i].Y;
                float xr = centro.X + (float)(x * Math.Cos(a) - y * Math.Sin(a));
                float yr = centro.Y + (float)(x * Math.Sin(a) + y * Math.Cos(a));
                puntos[i] = new PointF(xr, yr);
            }

            for (int i = 0; i < 4; i++)
            {
                g.DrawLine(pen, puntos[i], puntos[(i + 1) % 4]);
            }
        }

        // Clase interna para cada rectángulo animado
        private class RectanguloAnimado
        {
            public PointF Centro;
            public float Ancho;
            public float Alto;
            public float Angulo;
            public Color Color;
            public Pen PenNeon;
            public float Grosor;
            private double tiempoCreacion;

            public RectanguloAnimado(double tiempoCreacion, PointF centro, float ancho, float alto, float angulo, Color color, float grosor)
            {
                this.tiempoCreacion = tiempoCreacion;
                Centro = centro;
                Ancho = ancho;
                Alto = alto;
                Angulo = angulo;
                Color = color;
                Grosor = grosor;
                PenNeon = new Pen(color, grosor) { LineJoin = System.Drawing.Drawing2D.LineJoin.Round };
            }

            public (float ancho, float alto, float angulo) EstadoActual(double tiempoGlobal)
            {
                float tiempoTranscurrido = (float)(tiempoGlobal - tiempoCreacion);
                float anchoActual = Ancho + tiempoTranscurrido * 1.5f;
                float altoActual = Alto + tiempoTranscurrido * 1.0f;
                float anguloActual = Angulo + tiempoTranscurrido * 0.1f;
                return (anchoActual, altoActual, anguloActual);
            }
        }
    }
}
