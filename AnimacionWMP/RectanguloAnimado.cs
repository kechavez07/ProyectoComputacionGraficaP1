using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AnimacionFiguras
{
    internal class RectanguloAnimado
    {
        public double TiempoCreacion; // En segundos
        public PointF Centro;
        public float AnchoInicial;
        public float AltoInicial;
        public float AnguloInicial;
        public Color Color;
        public float Grosor;

        public RectanguloAnimado(double tiempoCreacion, PointF centro, float ancho, float alto, float angulo, Color color, float grosor)
        {
            TiempoCreacion = tiempoCreacion;
            Centro = centro;
            AnchoInicial = ancho;
            AltoInicial = alto;
            AnguloInicial = angulo;
            Color = color;
            Grosor = grosor;
        }

        // Calcula el estado actual del rectángulo según el tiempo global
        public (float ancho, float alto, float angulo) EstadoActual(double tiempoGlobal)
        {
            double vida = tiempoGlobal - TiempoCreacion;
            if (vida < 0) vida = 0;
            float ancho = AnchoInicial + (float)(1.5f * vida);
            float alto = AltoInicial + (float)(1.0f * vida);
            float angulo = AnguloInicial + (float)(0.1f * vida);
            return (ancho, alto, angulo);
        }
    }
}
