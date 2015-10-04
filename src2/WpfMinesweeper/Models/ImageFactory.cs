namespace WpfMinesweeper.Models
{
    using System;
    using System.Drawing;
    using System.Windows;
    using System.Windows.Interop;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    
    public static class ImageFactory
    {
        /// <summary>
        ///     Creates an image, ready to be used in the WPF view.
        /// </summary>
        /// <param name="imgResource">The resource of the image.</param>
        /// <returns></returns>
        public static ImageBrush CreateImage(Bitmap imgResource)
        {
            var bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(
                imgResource.GetHbitmap(),
                IntPtr.Zero,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());

            return new ImageBrush(bitmapSource);
        }
    }
}
