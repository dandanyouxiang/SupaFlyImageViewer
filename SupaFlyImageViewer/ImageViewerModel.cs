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
    public class ImageViewerModel : INotifyPropertyChanged
    {
        int width;
        readonly MainWindowCommand zoomInCommand;
        readonly MainWindowCommand zoomOutCommand;
        readonly MainWindowCommand closeApplicationCommand;

        public ImageViewerModel()
        {
            zoomInCommand = new MainWindowCommand(() => Width += 10);
            zoomOutCommand = new MainWindowCommand(() => Width -= 10);
            closeApplicationCommand = new MainWindowCommand(() => Application.Current.Shutdown());
            Width = 800;
        }

        public string MyPath
        {
            get { return @"D:\Dropbox\Pictures\Eye-Fi\1-26-2015\DSC00779.JPG"; }
        }


        // Todo: get actual width of photo. (Need to set a max width depending on monitor size.)
        public int Width
        {
            get { return width; }
            set
            {
                width = value;
                OnPropertyChanged();
            }
        }

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

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class MainWindowCommand : ICommand
    {
        readonly Action action;

        public MainWindowCommand(Action action)
        {
            this.action = action;
        }

        public bool CanExecute(object parameter)
        {
            return action != null;
        }

        public void Execute(object parameter)
        {
            action();
        }

        public event EventHandler CanExecuteChanged = delegate { };
    }
}
