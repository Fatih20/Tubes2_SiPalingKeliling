using System.ComponentModel;
using System.IO;
using System;
using System.Collections.Generic;
using Avalonia.TreasureFinder.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ReactiveUI;

namespace Avalonia.TreasureFinder.ViewModels;
public enum ApplicationState : int
{
    FileNotLoaded = 0,
    FileLoading = 1,
    FileLoaded = 2,
    CalculatingResults = 3,
    ShowingResults = 4,
    PlayingRecording = 5,
    PausingRecording = 6,
}
public class MainWindowViewModel : ViewModelBase
{
    // private ApplicationState _state = ApplicationState.FileNotLoaded;
    private ApplicationState _state = ApplicationState.ShowingResults;

    private Graph? _graphRepresentation;

    private String? _exceptionMessage;

    private Solution? _solution;

    private string _filenameToLoad = "";
    
    private Tuple<List<Tuple<int, int, string>>, int>? _resultReplay;

    public Tuple<List<Tuple<int, int, string>>, int>? ResultReplay
    {
        get => _resultReplay;
        private set => this.RaiseAndSetIfChanged(ref _resultReplay, value);
    }

    public Solution? Solution
    {
        get => _solution;
        private set => this.RaiseAndSetIfChanged(ref _solution, value);
    }

    public String? ExceptionMessage
    {
        get => _exceptionMessage;
        private set => this.RaiseAndSetIfChanged(ref _exceptionMessage, value);
    }

    public Graph? GraphRepresentation
    {
        get => _graphRepresentation;
        private set => this.RaiseAndSetIfChanged(ref _graphRepresentation, value);
    }

    public ApplicationState State
    {
        get => _state;
        private set => this.RaiseAndSetIfChanged(ref _state, value);
    }

    public string FilenameToLoad
    {
        get => _filenameToLoad;
        set => this.RaiseAndSetIfChanged(ref _filenameToLoad, value);
    }
    // Appearance concerned attributes
    
    private bool _allBarHidden = true;
    public bool AllBarHidden
    {
        get => _allBarHidden;
        set => this.RaiseAndSetIfChanged(ref _allBarHidden, value);
    }

    public void ToggleAllBarHidden()
    {
        AllBarHidden = true;
    }
    
    public bool ShowError
    {
        get => ExceptionMessage != null;
    }
    
    // Input Bar State
    public bool InputBarIsOpen
    {
        get => State == ApplicationState.FileNotLoaded && !AllBarHidden;
    }
    
    public bool InputBarIsHidden
    {
        get => AllBarHidden;
    }
    
    // Result Bar State
    public bool ResultBarIsHidden
    {
        get => AllBarHidden || State == ApplicationState.FileNotLoaded || State == ApplicationState.FileLoading || State == ApplicationState.FileLoaded || State == ApplicationState.CalculatingResults;
    }
    
    public bool ResultBarIsDiscreet
    {
        get => !ResultBarIsHidden && !ResultBarIsOpen;
    }
    
    public bool ResultBarIsOpen
    {
        get => State == ApplicationState.PausingRecording || State == ApplicationState.ShowingResults && !AllBarHidden;
    }
    
    // Replay Bar State
    public bool ReplayBarIsHidden
    {
        get => AllBarHidden || State == ApplicationState.FileNotLoaded || State == ApplicationState.FileLoading || State == ApplicationState.FileLoaded || State == ApplicationState.CalculatingResults;
    }
    
    
    public bool ReplayBarIsDiscreet
    {
        get => !ReplayBarIsHidden && !ReplayBarIsOpen;
    }
    
    public bool ReplayBarIsOpen
    {
        get => State == ApplicationState.PausingRecording && !AllBarHidden;
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