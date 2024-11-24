using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Imaging;

namespace WpfApp4
{
    public partial class GalleryWindow : Window
    {
        private List<string> imagePaths;
        private int currentImageIndex;

        public GalleryWindow()
        {
            InitializeComponent();

            imagePaths = new List<string>
            {
                "Images/1.jpg",
                "Images/2.jpg",
                "Images/3.jpg",
                "Images/4.jpg"
            };

            currentImageIndex = 0;
            ShowImage();
        }
        private void ShowImage()
        {
            BitmapImage bitmap = new BitmapImage(new Uri(imagePaths[currentImageIndex], UriKind.Relative));
            ImageDisplay.Source = bitmap;
        }
        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            currentImageIndex = (currentImageIndex == 0) ? imagePaths.Count - 1 : currentImageIndex - 1;
            ShowImage();
        }
        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            currentImageIndex = (currentImageIndex == imagePaths.Count - 1) ? 0 : currentImageIndex + 1;
            ShowImage();
        }
    }
}