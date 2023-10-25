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
            CognitiveFace cog = new CognitiveFace(true, Color.GreenYellow);
            public bool face;
            PipeNull pNull = new PipeNull();
            FilterNegative fNegative = new FilterNegative();
            PipeSerial pSerial2 = new PipeSerial(negative, pnull);
            FilterTwitter ftwitter = new FilterTwitter(@"hasFace.jpg", "ej3");
            PipeSerial pTwitter = new PipeSerial(ft, pnull);
            FilterConditional fConditional = new FilterConditional(face, "picture1.jpg");
            PipeConditionalFork pConditional = new PipeConditionalFork(pTwitter, pSerial2);
            FilterSaveImage fSave1 = new FilterSaveImage("picture1. jpg");
            PipeSerial pSave1 = new PipeSerial(fSave1, pConditional);
            FilterGreyscale fGreyscale = new FilterGreyscale();
            PipeSerial pSerial1 = new PipeSerial(fGreyscale, pConditional);

            IPicture s1 = serial1.Send(picture);

            provider.SavePicture(s1, @"beerEdited.jpg");
        }
    }
}