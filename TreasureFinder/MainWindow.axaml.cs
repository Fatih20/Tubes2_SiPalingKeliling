using Avalonia.Controls;
using System.ComponentModel;
using Avalonia.Markup.Xaml;
using System.IO;
using System;
using System.Collections.Generic;

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

    Graph? graphRepresentation = null;

    String? exceptionMessage = null;

    Solution? solution = null;

    string filenameToLoad = "";

    Tuple<List<Tuple<int, int, string>>, int>? resultReplay = null;

    public Tuple<List<Tuple<int, int, string>>, int>? ResultReplay
    {
        get => resultReplay;
        private set
        {
            resultReplay = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ResultReplay)));

        }
    }

    public Solution? Solution
    {
        get => solution;
        private set
        {
            solution = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Solution)));

        }
    }

    public String? ExceptionMessage
    {
        get => exceptionMessage;
        private set
        {
            exceptionMessage = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ExceptionMessage)));

        }
    }

    public Graph? GraphRepresentation
    {
        get => graphRepresentation;
        private set
        {
            graphRepresentation = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(GraphRepresentation)));

        }
    }

    public ApplicationState State
    {
        get => state;
        private set
        {
            state = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(State)));
        }
    }

    public string FilenameToLoad
    {
        get => filenameToLoad;
        set
        {
            filenameToLoad = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(filenameToLoad)));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;



    public void ButtonClicked()
    {
        switch (State)
        {
            case ApplicationState.FileNotLoaded:
                loadingFile(filenameToLoad);
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

    public void loadingFile(string file)
    {
        State = ApplicationState.FileLoading;
        try
        {
            GraphRepresentation = new Graph(file);
            State = ApplicationState.FileLoaded;
            return;
        }
        catch (FileNotFoundException)
        {
            exceptionMessage = "File tidak ditemukan!";
        }
        catch (Exception e)
        {
            exceptionMessage = e.GetType() == typeof(System.IO.DirectoryNotFoundException) ? "Directory file tidak ditemukan!" : e.Message;
        }

        State = ApplicationState.FileNotLoaded;
    }

    public void calculate()
    {
        State = ApplicationState.CalculatingResults;
        if (graphRepresentation != null)
        {
            solution = graphRepresentation.Solve(true, true);
            resultReplay = Tuple.Create(solution.getProgress(), -1);
            State = ApplicationState.ShowingResults;
            return;
        }

        State = ApplicationState.FileLoaded;
    }

    public void playRecording() { State = ApplicationState.PlayingRecording; }

    public void pauseRecording() { State = ApplicationState.PausingRecording; }

    public void stopPlayingRecording()
    {
        State = ApplicationState.ShowingResults;
    }

}