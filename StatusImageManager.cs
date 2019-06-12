using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Simple_games
{
    sealed class StatusImageManager
    {
        private static StatusImageManager instance;
        private readonly List<BitmapImage> imgCollection;
        private int currentImgNr = -1;

        private StatusImageManager()
        {
            imgCollection = new List<BitmapImage>
                {
                    new BitmapImage(new Uri("assets\\gallows0.png", UriKind.Relative)),
                    new BitmapImage(new Uri("assets\\gallows1.png", UriKind.Relative)),
                    new BitmapImage(new Uri("assets\\gallows2.png", UriKind.Relative)),
                    new BitmapImage(new Uri("assets\\gallows3.png", UriKind.Relative)),
                    new BitmapImage(new Uri("assets\\gallows4.png", UriKind.Relative)),
                    new BitmapImage(new Uri("assets\\gallows5.png", UriKind.Relative)),
                    new BitmapImage(new Uri("assets\\gallows6.png", UriKind.Relative))
                };
        }

        public static StatusImageManager Instance()
        {
            if (instance == null)
            {
                instance = new StatusImageManager();
            }
            return instance;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="img">Image which source is to set.</param>
        public void SetNextImage(Image img)
        {
            currentImgNr += 1;
            img.Source = imgCollection[currentImgNr];
        }

        public void Reset()
        {
            currentImgNr = -1;
        }

        public int CurrentImgNr
        { get { return currentImgNr; } }

        public int ImgCount
        { get { return imgCollection.Count; } }

        /// <summary>
        /// Check if index of current image is an index of the last image.
        /// </summary>
        /// <returns></returns>
        public bool IsLastImage()
        {
            return currentImgNr == imgCollection.Count - 1;
        }
    }
}
