using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;
        public double Radius
        {
            get => this.radius;
            private set => this.radius = value;
        }

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public override double CalculateArea() => Math.PI * this.Radius * this.Radius;

        public override double CalculatePerimeter() => 2 * Math.PI * this.Radius;

        public override string Draw() => base.Draw() + this.GetType().Name;
    }
}
