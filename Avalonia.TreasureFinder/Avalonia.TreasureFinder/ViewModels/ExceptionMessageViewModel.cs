using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Avalonia.TreasureFinder.ViewModels
{
    public class ExceptionMessageViewModel : ViewModelBase
    {
        
        public ExceptionMessageViewModel()
        {
            ExceptionMessage = "";
        }
        public ExceptionMessageViewModel(string? exceptionMessage)
        {
            ExceptionMessage = exceptionMessage;
        }
        
        public string? ExceptionMessage { get; set; }

    }
}