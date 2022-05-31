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
            IPicture NoFilterPicture = provider.GetPicture(@"luke.jpg");
            
            PipeNull pipeNull = new PipeNull();
            
            FilterGreyscale greyScale = new FilterGreyscale();
            PipeSerial pipeSerialGrey = new PipeSerial(greyScale, pipeNull);

            FilterNegative filterNegative = new FilterNegative();
            PipeSerial pipeSerialNegative = new PipeSerial(filterNegative, pipeNull);

            provider.SavePicture(pipeNull.Send(NoFilterPicture), @"LukeNull.jpg");
            provider.SavePicture(pipeSerialNegative.Send(NoFilterPicture), @"LukeNegativeFilter.jpg");
            provider.SavePicture(pipeSerialGrey.Send(NoFilterPicture), @"LukeGreyFilter.jpg");
            
        }
    }
}
