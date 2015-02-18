using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
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
        bool isReadyToClose;

        public MainWindow()
        {
            InitializeComponent();
            //var args = Environment.GetCommandLineArgs();
        }

        void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void ImageLoadStoryboardAnimation_Completed(object sender, EventArgs e)
        {
            var context = (ImageViewerModel)DataContext;
            context.DisplayedWidth = context.ZoomWidth;
        }

        void ImageUnloadStoryboardAnimation_Completed(object sender, EventArgs e)
        {
            isReadyToClose = true;
            Close();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (isReadyToClose)
                return;

            e.Cancel = true;
            var imageUnloadStoryboard = (Storyboard)MainImage.FindResource("ImageUnloadStoryboard");
            imageUnloadStoryboard.Begin(MainImage);
        }
    }
}
