using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Master_Zhao.Shell.Util
{
    public class UIElementHelper
    {
        public static string ProImgPath { get; private set; }

        public static void SaveUIElementAsFile(FrameworkElement element, string fileName)
        {
            var render = new RenderTargetBitmap((int)element.ActualWidth, (int)element.ActualHeight, 96, 96, PixelFormats.Default);
            render.Render(element);
            BitmapEncoder encoder = new JpegBitmapEncoder();

            encoder.Frames.Add(BitmapFrame.Create(render));
            using (FileStream fs = File.Create(fileName))
            {
                encoder.Save(fs);
            }
        }

        public static void SaveImageSourceAsFile(BitmapSource imageSource,string fileName)
        {
            BitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageSource));
            using (Stream stream = File.Create(fileName))
            {
                encoder.Save(stream);
            }
        }

        public static BitmapImage GetBitmapImageFromLocalFile(string path)
        {
            if (File.Exists(path) == false)
                return null;

            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            var buffer = System.IO.File.ReadAllBytes(path);
            var ms = new MemoryStream(buffer);
            bi.StreamSource = ms;
            bi.EndInit();
            return bi;
        }
    }
}
