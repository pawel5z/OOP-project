using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Simple_games
{
    class StatusImageManager
    {
        private readonly List<BitmapImage> imgCollection;
        int currentImgNr = -1;

        public StatusImageManager()
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

        //public void SetCurrentImage(Image img)
        //{
        //    img.Source = imgCollection[currentImgNr];
        //}

        public void SetNextImage(Image img)
        {
            currentImgNr = currentImgNr + 1;
            img.Source = imgCollection[currentImgNr];
        }

        public int CurrentImgNr
        { get { return currentImgNr; } }

        public int ImgCount
        { get { return imgCollection.Count; } }
    }
}
