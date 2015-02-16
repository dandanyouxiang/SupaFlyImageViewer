using System.ComponentModel;
using System.Windows.Input;

namespace SupaFlyImageViewer
{
    public interface IImageViewerModel 
    {
        string MyPath { get; }
        int DisplayedWidth { get; set; }
        ICommand ZoomIn { get; }
        ICommand ZoomOut { get; }
        ICommand CloseApplication { get; }
        event PropertyChangedEventHandler PropertyChanged;
    }
}