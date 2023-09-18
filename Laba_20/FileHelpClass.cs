using Microsoft.Win32;
using System.IO;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FileHelpClass
{
    public static class OpenSaver
    {
        private static string exts = "JPEG files (*.jpeg)|*.jpeg|JPG files (*.jpg)|*.jpg|PNG files (*.png)|*.png";

        public static void OpenFile(InkCanvas canv)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = exts;

            if (openFileDialog1.ShowDialog() == true)
            {
                ImageBrush brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new System.Uri(openFileDialog1.FileName, System.UriKind.Absolute));
                canv.Background = brush;
            }
        }

        public static void WriteFile(InkCanvas canv)
        {


            RenderTargetBitmap rtb = new RenderTargetBitmap((int)canv.ActualWidth, (int)canv.ActualHeight, 96d, 96d, PixelFormats.Pbgra32);
            rtb.Render(canv);

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = exts;

            if (saveFileDialog1.ShowDialog() == true)
            {
                FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create);
                
                switch (saveFileDialog1.FilterIndex)
                {
                    case 0:
                    case 1:
                        {
                            JpegBitmapEncoder jpegEncoder = new JpegBitmapEncoder();
                            jpegEncoder.Frames.Add(BitmapFrame.Create(rtb));
                            jpegEncoder.Save(fs);

                        }; break;

                    case 2:
                        {
                            PngBitmapEncoder jpegEncoder = new PngBitmapEncoder();
                            jpegEncoder.Frames.Add(BitmapFrame.Create(rtb));
                            jpegEncoder.Save(fs);

                        }; break;
                }
                fs.Close();
            }

        }
    }
}
