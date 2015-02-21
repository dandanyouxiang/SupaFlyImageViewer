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
            var options = new Options();
            if (CommandLine.Parser.Default.ParseArguments(Environment.GetCommandLineArgs(), options))
                MyPath = options.ImageFilePath;
            // todo: else, display a broken image icon?

            zoomInCommand = new MainWindowCommand(IncrementWidth);
            zoomOutCommand = new MainWindowCommand(DecrementWidth);
            imageLoadCompletedCommand = new MainWindowCommand(() => DisplayedWidth = ZoomWidth);
            closeApplicationCommand = new MainWindowCommand(() => Application.Current.MainWindow.Close());

            ZoomWidth = 1200;
        }

        public string MyPath { get; private set; }

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

        // todo: Get out of code behind - maybe after using that mvvm framework?
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

        void IncrementWidth()
        {
            // if (size is not already at max)...
            DisplayedWidth += 10;
        }

        void DecrementWidth()
        {
            // if (size is not already at zero)...
            DisplayedWidth -= 10;
        }
    }
}
