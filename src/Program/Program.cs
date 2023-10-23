using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"beer.jpg");

            PipeNull pnull = new PipeNull();
            FilterSaveImage resParcial2 = new FilterSaveImage(@"resParcial2.jpg");
            PipeSerial rp2 = new PipeSerial(resParcial2, pnull);
            FilterNegative negative = new FilterNegative();
            PipeSerial serial2 = new PipeSerial(negative, rp2);
            FilterSaveImage resParcial1 = new FilterSaveImage(@"resParcial1.jpg");
            PipeSerial rp1 = new PipeSerial(resParcial1, serial2);
            FilterGreyscale greyscale = new FilterGreyscale();
            PipeSerial serial1 = new PipeSerial(greyscale, rp1);

            IPicture s1 = serial1.Send(picture);

            provider.SavePicture(s1, @"beerEdited.jpg");
        }
    }
}
