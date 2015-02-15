using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SupaFlyImageViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            var args = Environment.GetCommandLineArgs();
            var uri = new Uri(@"D:\Dropbox\Pictures\Eye-Fi\1-26-2015\DSC00779.JPG");
            MainImage.Source = new BitmapImage(uri);
        }

        void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        void ImageLoadedZoomIn_Completed(object sender, EventArgs e)
        {
            //var dataContext = (ImageViewerModel)DataContext;
            //MainImage.Width = dataContext.DisplayedWidth;
            //ImageLoadStoryboard.Remove(MainImage);
        }
    }
}
