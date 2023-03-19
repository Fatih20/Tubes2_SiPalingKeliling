using System.ComponentModel;
using System.IO;
using System;
using System.Collections.Generic;
using Avalonia.TreasureFinder.Models;

namespace Avalonia.TreasureFinder.ViewModels;
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
public class MainWindowViewModel : ViewModelBase
{
    private ApplicationState _state = ApplicationState.FileNotLoaded;

    private Graph? _graphRepresentation;

    private String? _exceptionMessage;

    private Solution? _solution;

    private string _filenameToLoad = "";

    private Tuple<List<Tuple<int, int, string>>, int>? _resultReplay = null;

    public bool ShowError
    {
        get => ExceptionMessage != null;
    }

    public Tuple<List<Tuple<int, int, string>>, int>? ResultReplay
    {
        get => _resultReplay;
        private set
        {
            _resultReplay = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ResultReplay)));

        }
    }

    public Solution? Solution
    {
        get => _solution;
        private set
        {
            _solution = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Solution)));
        }
    }

    public String? ExceptionMessage
    {
        get => _exceptionMessage;
        private set
        {
            _exceptionMessage = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ExceptionMessage)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ShowError)));

        }
    }

    public Graph? GraphRepresentation
    {
        get => _graphRepresentation;
        private set
        {
            _graphRepresentation = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(GraphRepresentation)));

        }
    }

    public ApplicationState State
    {
        get => _state;
        private set
        {
            _state = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(State)));
        }
    }

    public string FilenameToLoad
    {
        get => _filenameToLoad;
        set
        {
            _filenameToLoad = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FilenameToLoad)));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;



    public void ButtonClicked()
    {
        switch (State)
        {
            case ApplicationState.FileNotLoaded:
                LoadingFile(FilenameToLoad);
                break;
            case ApplicationState.FileLoading:
                break;
            case ApplicationState.FileLoaded:
                Calculate();
                break;
            case ApplicationState.CalculatingResults:
                break;
            case ApplicationState.ShowingResults:
                PlayRecording();
                break;
            case ApplicationState.PlayingRecording:
                PauseRecording();
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

    public void LoadingFile(string file)
    {
        State = ApplicationState.FileLoading;
        // Console.WriteLine("Loading file");
        try
        {
            GraphRepresentation = new Graph(file);
            ExceptionMessage = "";
            State = ApplicationState.FileLoaded;
            return;
        }
        catch (FileNotFoundException)
        {
            ExceptionMessage = "File tidak ditemukan!";
        }
        catch (Exception e)
        {
            ExceptionMessage = e.GetType() == typeof(System.IO.DirectoryNotFoundException) ? "Directory file tidak ditemukan!" : e.Message;
        }

        // Console.WriteLine(ExceptionMessage);
        // Console.WriteLine(ShowError);
        // Console.WriteLine("Failed loading file");

        State = ApplicationState.FileNotLoaded;
    }

    public void Calculate()
    {
        State = ApplicationState.CalculatingResults;
        if (GraphRepresentation != null)
        {
            Solution = GraphRepresentation.Solve(true, true);
            ResultReplay = Tuple.Create(Solution.getProgress(), -1);
            State = ApplicationState.ShowingResults;
            return;
        }

        State = ApplicationState.FileLoaded;
    }

    public void PlayRecording() { State = ApplicationState.PlayingRecording; }

    public void PauseRecording() { State = ApplicationState.PausingRecording; }

    public void stopPlayingRecording()
    {
        State = ApplicationState.ShowingResults;
    }}