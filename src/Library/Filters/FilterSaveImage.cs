using System;
using System.Drawing;
using CompAndDel;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace CompAndDel.Filters
{
    /// <summary>
    /// Un filtro que recibe una imagen y la guarda.
    /// </remarks>
    public class FilterSaveImage : IFilter
    {
        public string path;

        public FilterSaveImage(string path)
        {
            this.path = path;
        }

        /// Procesa la imagen pasada por parametro y guarda la imagen.
        /// </summary>
        /// <param name="image">La imagen que se va a guardar.</param>
        public IPicture Filter (IPicture picture)
        {
            IPicture result = picture.Clone();
            int width = picture.Width;
            int height = picture.Height;
            using(Image<Rgba32> image = new Image<Rgba32>(width, height)) // creates a new image with all the pixels set as transparent
            {
                for (int h = 0; h < picture.Height; h++)
                {
                    for (int w = 0; w < picture.Width; w++)
                    {
                        System.Drawing.Color c = picture.GetColor(w, h);
                        image[w, h] = new Rgba32(c.R, c.G, c.B, c.A);
                    }
                }
                image.Save(this.path);
            }
            return result;
        }
    }
}
