// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImageFactory.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-6"
// </copyright>
// <summary>
//   The image factory
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace WpfMinesweeper.Models
{
    using System;
    using System.Drawing;
    using System.Windows;
    using System.Windows.Interop;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    
    /// <summary>
    /// The image factory.
    /// </summary>
    public static class ImageFactory
    {
        /// <summary>
        ///     Creates an image, ready to be used in the WPF view.
        /// </summary>
        /// <param name="imgResource">The resource of the image.</param>
        /// <returns>
        /// The image, ready to be used in the WPF view.
        /// </returns>
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
