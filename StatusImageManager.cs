using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Controls;

namespace Simple_games
{
    class StatusImageManager
    {
        List<BitmapImage> imgCollection;
        int current = 0;
        int imgCount = 7;

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

        public void SetCurrentImage(Image img)
        {
            img.Source = imgCollection[current];
        }

        public void SetNextImage(Image img)
        {
            current = current + 1;
            SetCurrentImage(img);
        }

        public int GetCurrentImgNr()
        { return current; }

        public int GetMaxImgNr()
        { return imgCount; }
    }
}
