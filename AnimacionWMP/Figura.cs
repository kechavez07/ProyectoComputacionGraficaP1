using System;
using System.Drawing;

namespace AnimacionFiguras
{
    public abstract class Figura
    {
        protected PointF centro;
        protected float radio;
        protected int cantidadLineas;
        protected float anguloActual;
        protected Size area;

        public Figura(PointF centro, float radio, int cantidadLineas)
        {
            this.centro = centro;
            this.radio = radio;
            this.cantidadLineas = cantidadLineas;
            this.anguloActual = 0;
        }

        // Propiedad para acceder y modificar el radio
        public float Radio
        {
            get => radio;
            set => radio = value;
        }

        // Propiedad para acceder y modificar el ángulo actual
        public float AnguloActual
        {
            get => anguloActual;
            set => anguloActual = value;
        }

        // Propiedad para acceder y modificar el centro
        public PointF Centro
        {
            get => centro;
            set => centro = value;
        }

        // Método abstracto para dibujar la figura
        public abstract void Dibujar(Graphics g, Size area);

        // Método virtual para actualizar la figura (opcional, para animaciones más complejas)
        public virtual void Actualizar() { }
    }
}
