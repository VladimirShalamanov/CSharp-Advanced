using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public double Height
        {
            get => this.height;
            private set => this.height = value;
        }
        public double Width
        {
            get => this.width;
            set => this.width = value;
        }
        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }

        public override double CalculateArea() => this.Height * this.Width;

        public override double CalculatePerimeter() => 2 * this.Height + 2 * this.Width;

        public override string Draw() => base.Draw() + this.GetType().Name;
    }
}
