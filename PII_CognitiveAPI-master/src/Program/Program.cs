using System;
using System.Drawing;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using CompAndDel;
using TwitterUCU;

namespace CognitiveCoreUCU
{
    class Program
    {
        static void Main(string[] args)
        {
            // PictureProvider provider = new PictureProvider();
            // IPicture NoFilterPicture = provider.GetPicture(@"bill2.jpg");
            
            PipeNull pipeNull = new PipeNull();
            FilterGreyscale greyScale = new FilterGreyscale();
            PipeSerial pipeSerialGrey = new PipeSerial(greyScale, pipeNull);
            FilterNegative filterNegative = new FilterNegative();
            PipeSerial pipeSerialNegative = new PipeSerial(filterNegative, pipeNull);

            // provider.SavePicture(pipeNull.Send(NoFilterPicture), @"Bill2Null.jpg");
            // provider.SavePicture(pipeSerialNegative.Send(NoFilterPicture), @"Bill2NegativeFilter.jpg");
            // provider.SavePicture(pipeSerialGrey.Send(NoFilterPicture), @"Bill2GreyFilter.jpg");

            // var twitter = new TwitterImage();
            // Console.WriteLine(twitter.PublishToTwitter("New Employee 15! ",@"Bill2GreyFilter.jpg"));
            // var twitterDirectMessage = new TwitterMessage();
            // Console.WriteLine(twitterDirectMessage.SendMessage("Hola!", "249011461"));



            CognitiveFace cog = new CognitiveFace(false);
            cog.Recognize(@"bill.jpg");
            FoundFace(cog);
            cog.Recognize(@"bill2.jpg");
            FoundFace(cog);
            cog.Recognize(@"yacht.jpg");
            FoundFace(cog);

        }
        static void FoundFace(CognitiveFace cog)
        {
            if (cog.FaceFound)
            {
                Console.WriteLine("Face Found!");
                if (cog.SmileFound)
                {
                    Console.WriteLine("Found a Smile :)");
                    cog.Recognize
                }
                else
                {
                    Console.WriteLine("No smile found :(");
                }
            }
            else
                Console.WriteLine("No Face Found");
        }
    }
}
