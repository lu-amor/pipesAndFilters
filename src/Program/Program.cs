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
            IPicture p1 = pnull.Send(picture);
            FilterNegative negative = new FilterNegative();
            IFilter ng = negative;
            PipeSerial serial2 = new PipeSerial(ng, pnull);
            IPicture s2 = serial2.Send(p1);
            FilterGreyscale greyscale = new FilterGreyscale();
            IFilter gs = greyscale;
            PipeSerial serial1 = new PipeSerial(gs, serial2);
            IPicture s1 = serial1.Send(s2);

            provider.SavePicture(s1, @"PathToImageToSave.jpg");
        }
    }
}
