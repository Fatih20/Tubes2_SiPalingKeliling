using Avalonia.Controls;
using System.ComponentModel;
using Avalonia.Markup.Xaml;

namespace TreasureFinder;

public enum ApplicationState
{
    FileNotLoaded,
    FileLoading,
    FileLoaded,
    CalculatingResults,
    ShowingResults,
    PlayingRecording,
    PausingRecording
}

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }
}

public class MainWindowViewModel : INotifyPropertyChanged
{

    ApplicationState state = ApplicationState.FileNotLoaded;

    string buttonText = "Click Me!";

    public ApplicationState State
    {
        get => state;
        private set
        {
            state = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(State)));
        }
    }

    public string ButtonText
    {
        get => buttonText;
        set
        {
            buttonText = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ButtonText)));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public void ButtonClicked()
    {
        switch (State)
        {
            case ApplicationState.FileNotLoaded:
                loadingFile();
                break;
            case ApplicationState.FileLoading:
                break;
            case ApplicationState.FileLoaded:
                calculate();
                break;
            case ApplicationState.CalculatingResults:
                break;
            case ApplicationState.ShowingResults:
                playRecording();
                break;
            case ApplicationState.PlayingRecording:
                pauseRecording();
                break;
                // case ApplicationState.PlayingRecording:
                //     loadingFile();
                //     break;
                // case ApplicationState.FileNotLoaded:
                //     loadingFile();
                //     break;
                // case ApplicationState.FileNotLoaded:
                //     loadingFile();
                //     break;


        }
    }

    public void loadingFile()
    {
        State = ApplicationState.FileLoading;
        for (int i = 0; i < 1000000000; i++)
        {

        }
        State = ApplicationState.FileLoaded;
    }

    public void calculate()
    {
        State = ApplicationState.CalculatingResults;
        for (int i = 0; i < 1000000000; i++)
        {

        }
        State = ApplicationState.ShowingResults;
    }

    public void playRecording() { State = ApplicationState.PlayingRecording; }

    public void pauseRecording() { State = ApplicationState.PausingRecording; }

    public void stopPlayingRecording() { State = ApplicationState.ShowingResults; }

}