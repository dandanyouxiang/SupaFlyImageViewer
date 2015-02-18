using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using SupaFlyImageViewer.Annotations;

namespace SupaFlyImageViewer
{
    public class ImageViewerModel : INotifyPropertyChanged, IImageViewerModel
    {
        int displayedWidth;
        readonly MainWindowCommand zoomInCommand;
        readonly MainWindowCommand zoomOutCommand;
        readonly MainWindowCommand closeApplicationCommand;
        readonly MainWindowCommand imageLoadCompletedCommand;

        public ImageViewerModel()
        {
            zoomInCommand = new MainWindowCommand(() => DisplayedWidth += 10);
            zoomOutCommand = new MainWindowCommand(() => DisplayedWidth -= 10);
            imageLoadCompletedCommand = new MainWindowCommand(() => DisplayedWidth = ZoomWidth);
            closeApplicationCommand = new MainWindowCommand(() => Application.Current.Shutdown());

            ZoomWidth = 1200;
        }

        public string MyPath
        {
            get { return @"D:\Dropbox\Pictures\Eye-Fi\1-26-2015\DSC00779.JPG"; }
        }

        // Todo: get actual width of photo. (Need to set a max width depending on monitor size.)
        public int DisplayedWidth
        {
            get { return displayedWidth; }
            set
            {
                displayedWidth = value;
                OnPropertyChanged();
            }
        }

        public int ZoomWidth { get; set; }

        public ICommand ZoomIn
        {
            get { return zoomInCommand; }
        }

        public ICommand ZoomOut
        {
            get { return zoomOutCommand; }
        }

        public ICommand CloseApplication
        {
            get { return closeApplicationCommand; }
        }

        public ICommand ImageLoadCompleted
        {
            get { return imageLoadCompletedCommand; }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
