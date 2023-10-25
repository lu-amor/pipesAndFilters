using System;
using System.Drawing;
using CompAndDel;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using Ucu.Poo.Cognitive;

namespace CompAndDel.Filters
{
    /// <summary>
    /// Un filtro que recibe una imagen y la guarda.
    /// </remarks>
    public class FilterConditional : IFilter
    {
        public bool face;
        public CognitiveFace cog;
        public FilterConditional(bool face, string path)
        {
            CognitiveFace cog = new CognitiveFace(true, Color.GreenYellow);
            cog.Recognize(path);
        }

        /// Procesa la imagen pasada por parametro y guarda la imagen.
        /// </summary>
        /// <param name="image">La imagen que se va a guardar.</param>
        public IPicture Filter (IPicture picture)
        {
            if (cog.FaceFound)
            {
                face = true;
            }
            else
            {
                face = false;
            }
            return picture;
        }
    }
}

