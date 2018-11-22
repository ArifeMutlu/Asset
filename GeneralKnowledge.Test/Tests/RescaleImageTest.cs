

using System;
using System.Drawing;
using System.IO;
using System.Net;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// Image rescaling
    /// </summary>
    public class RescaleImageTest : ITest
    {
        public void Run()
        {
            // TODO
            // Grab an image from a public URL and write a function that rescales the image to a desired format
            // The use of 3rd party plugins is permitted
            // For example: 100x80 (thumbnail) and 1200x1600 (preview)
            downloadImage();
        }

        private void downloadImage()
        {
            Image imgThumb;
            Image imgPreview;
            using (WebClient wc = new WebClient())
            {
                byte[] data = wc.DownloadData("https://i1.wp.com/www.kerimusta.com/wp-content/uploads/2017/01/at-resimleri_184984.jpg");
                MemoryStream ms = new MemoryStream(data);
                System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
                imgThumb = img.GetThumbnailImage(100, 80, null, IntPtr.Zero);
                imgPreview = img.GetThumbnailImage(1200, 1600, null, IntPtr.Zero);
                //imgThumb.Save("C:\\resimThumbnail.png");
                //imgPreview.Save("C:\\resimPreview.png");
                Console.WriteLine("Image Created");
            }
        }
    }
}
