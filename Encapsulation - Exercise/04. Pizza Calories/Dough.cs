using System;
using System.Collections.Generic;
using System.Text;

namespace P04PizzaCalories
{
    public class Dough
    {
        private const double White = 1.5;
        private const double Wholegrain = 1.0;
        private const double Crispy = 0.9;
        private const double Chewy = 1.1;
        private const double Homemade = 1.0;

        private string flourType;
        private string bakingTechnique;
        private double grams;

        public Dough(string flourType, string bakingTechnique, double grams)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Grams = grams;
        }

        public string FlourType
        {
            get { return this.flourType; }
            private set
            {
                string type = value.ToLower();
                if (!string.IsNullOrEmpty(type) && type == "white" || type == "wholegrain")
                {
                    this.flourType = type;
                    return;
                }
                throw new ArgumentException("Invalid type of dough.");
            }
        }

        public string BakingTechnique
        {
            get { return this.bakingTechnique; }
            private set
            {
                string baking = value.ToLower();
                if (!string.IsNullOrEmpty(baking) && baking == "crispy" || baking == "chewy" || baking == "homemade")
                {
                    this.bakingTechnique = baking;
                    return;
                }
                throw new ArgumentException("Invalid type of dough.");
            }
        }

        public double Grams
        {
            get { return this.grams; }
            private set
            {
                if (value >= 1 && value <= 200)
                {
                    this.grams = value;
                    return;
                }
                throw new Exception("Dough weight should be in the range [1..200].");
            }
        }

        public double BakingD()
        {
            double flour = 0;
            if (this.FlourType == "white") flour = White;
            else if (this.FlourType == "wholegrain") flour = Wholegrain;
            double baking = 0;
            if (this.BakingTechnique == "crispy") baking = Crispy;
            else if (this.BakingTechnique == "chewy") baking = Chewy;
            else if (this.BakingTechnique == "homemade") baking = Homemade;

            return (2 * this.Grams) * flour * baking;
        }
    }
}
