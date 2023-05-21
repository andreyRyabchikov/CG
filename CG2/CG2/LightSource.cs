using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG2
{
    public class LightSource
    {
        
        public static Color CalculateIlluminatedColor(Color baseColor, Vector3D normal, Vector3D lightDirection1, Vector3D lightDirection2,
    double ambientCoefficient, double diffuseCoefficient, double specularCoefficient, double shininess)
        {
            // Расчет компонент фонового, рассеянного и отраженного освещения
            Color ambientColor = MultiplyColor(baseColor, ambientCoefficient);
            Color diffuseColor1 = CalculateDiffuseColor(baseColor, normal, lightDirection1, diffuseCoefficient);
            Color diffuseColor2 = CalculateDiffuseColor(baseColor, normal, lightDirection2, diffuseCoefficient);
            Color specularColor1 = CalculateSpecularColor(lightDirection1, normal, shininess, specularCoefficient);
            Color specularColor2 = CalculateSpecularColor(lightDirection2, normal, shininess, specularCoefficient);

            // Итоговый цвет треугольника после освещения
            Color illuminatedColor = AddColors(ambientColor, diffuseColor1, diffuseColor2, specularColor1, specularColor2);

            return illuminatedColor;
        }

        private static Color MultiplyColor(Color color, double factor)
        {
            int red = (int)(color.R * factor);
            int green = (int)(color.G * factor);
            int blue = (int)(color.B * factor);

            return Color.FromArgb(red, green, blue);
        }

        private static Color CalculateDiffuseColor(Color baseColor, Vector3D normal, Vector3D lightDirection, double diffuseCoefficient)
        {
            double dotProduct = DotProduct(lightDirection, normal);
            double factor = Math.Max(dotProduct, 0) * diffuseCoefficient;

            return MultiplyColor(baseColor, factor);
        }

        private static Color CalculateSpecularColor(Vector3D lightDirection, Vector3D normal, double shininess, double specularCoefficient)
        {
            Vector3D reflectionDirection = Reflect(lightDirection, normal);
            double dotProduct = DotProduct(reflectionDirection, new Vector3D(0, 0, -1));
            double factor = Math.Pow(Math.Max(dotProduct, 0), shininess) * specularCoefficient;

            return MultiplyColor(Color.White, factor);
        }

        private static double DotProduct(Vector3D v1, Vector3D v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
        }

        private static Vector3D Reflect(Vector3D incident, Vector3D normal)
        {
            double dotProduct = DotProduct(incident, normal);
            Vector3D reflection = incident - 2 * dotProduct * normal;
            reflection.Normalize();

            return reflection;
        }

        private static Color AddColors(params Color[] colors)
        {
            int red = 0, green = 0, blue = 0;

            foreach (Color color in colors)
            {
                red += color.R;
                green += color.G;
                blue += color.B;
            }

            red = Math.Min(red, 255);
            green = Math.Min(green, 255);
            blue = Math.Min(blue, 255);

            return Color.FromArgb(red, green, blue);
        }
    }
}
