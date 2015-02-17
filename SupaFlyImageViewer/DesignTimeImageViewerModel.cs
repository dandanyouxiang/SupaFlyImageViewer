using System.ComponentModel;
using System.Windows.Input;

namespace SupaFlyImageViewer
{
    public class DesignTimeImageViewerModel : IImageViewerModel
    {
        public DesignTimeImageViewerModel()
        {
            MyPath = @"D:\Dropbox\Pictures\Eye-Fi\1-26-2015\DSC00779.JPG";
            DisplayedWidth = 400;
        }

        public string MyPath { get; private set; }

        public int DisplayedWidth { get; set; }

        public int ZoomWidth { get; set; }

        public ICommand ZoomIn { get; private set; }

        public ICommand ZoomOut { get; private set; }

        public ICommand CloseApplication { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}