using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ReactiveUI;

namespace Avalonia.TreasureFinder.ViewModels
{
    public class ExceptionMessageViewModel : ViewModelBase
    {
        
        public ExceptionMessageViewModel()
        {
            _exceptionMessage = "Bruh";
            // ExceptionMessage = "Bruh";
        }

        private string _exceptionMessage;
        
        public string ExceptionMessage
        {
            get => _exceptionMessage;
            set
            {
                Console.WriteLine("Changed exception message in content. Supposed new value :");
                Console.WriteLine(value);
                this.RaiseAndSetIfChanged(ref _exceptionMessage, value);
            }
        }

        public void OnButtonClick()
        {
            Console.WriteLine("Button clicked");
            ExceptionMessage = "What the fuck is up with desktop development";
        }
    }
}