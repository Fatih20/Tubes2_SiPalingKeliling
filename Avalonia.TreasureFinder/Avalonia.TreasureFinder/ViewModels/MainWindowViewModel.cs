using System.ComponentModel;
using System.IO;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
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

    public MainWindowViewModel()
    {
        // Bar behaviour
        _inputBarIsHidden = this.WhenAnyValue(x => x.AllBarHidden).Select(condition => condition).ToProperty(this, x => x.InputBarIsHidden);
        _inputBarIsOpen = this.WhenAnyValue(x => x.State, x => x.AllBarHidden, (s, h) => Tuple.Create(s, h)).Select(condition => condition.Item1 == ApplicationState.FileNotLoaded && !condition.Item2).ToProperty(this, x => x.InputBarIsOpen);
        
        _searchBarIsHidden = this.WhenAnyValue(x => x.State, x => x.AllBarHidden, (s, h) => Tuple.Create(s, h)).Select(condition => condition.Item2 || condition.Item1 is ApplicationState.FileNotLoaded or ApplicationState.FileLoading).ToProperty(this, x => x.SearchBarIsHidden);
        _searchBarIsOpen = this.WhenAnyValue(x => x.State, x => x.AllBarHidden, (s, h) => Tuple.Create(s, h)).Select(condition => condition.Item1 == ApplicationState.FileNotLoaded && !condition.Item2).ToProperty(this, x => x.SearchBarIsOpen);

        _replayBarIsOpen = this.WhenAnyValue(x => x.State, x => x.AllBarHidden, (s, h) => Tuple.Create(s, h)).Select(condition => condition.Item1 == ApplicationState.PausingRecording && !condition.Item2).ToProperty(this, x => x.ReplayBarIsOpen);
        _replayBarIsHidden = this.WhenAnyValue(x => x.State, x => x.AllBarHidden, (s, h) => Tuple.Create(s, h)).Select(condition => condition.Item2 || condition.Item1 is ApplicationState.FileNotLoaded or ApplicationState.FileLoading or ApplicationState.FileLoaded or ApplicationState.CalculatingResults).ToProperty(this, x => x.ReplayBarIsHidden);
        _replayBarIsDiscreet = this.WhenAnyValue(x => x.ReplayBarIsHidden, x => x.ReplayBarIsOpen, (o, h) => Tuple.Create(o, h)).Select(condition => !condition.Item1 && !condition.Item2).ToProperty(this, x => x.ReplayBarIsDiscreet);

        _resultBarIsOpen = this.WhenAnyValue(x => x.State, x => x.AllBarHidden, (s, h) => Tuple.Create(s, h)).Select(condition =>  !condition.Item2 &&
            (condition.Item1 is ApplicationState.PausingRecording or ApplicationState.ShowingResults)).ToProperty(this, x => x.ResultBarIsOpen);
        _resultBarIsHidden = this.WhenAnyValue(x => x.State, x => x.AllBarHidden, (s, h) => Tuple.Create(s, h)).Select(condition => condition.Item2 || condition.Item1 is ApplicationState.FileNotLoaded or ApplicationState.FileLoading or ApplicationState.FileLoaded or ApplicationState.CalculatingResults ).ToProperty(this, x => x.ResultBarIsHidden);
        
        _resultBarIsDiscreet = this.WhenAnyValue(x => x.ResultBarIsHidden, x => x.ResultBarIsOpen, (o, h) => Tuple.Create(o, h)).Select(condition => !condition.Item1 && !condition.Item2).ToProperty(this, x => x.ResultBarIsDiscreet);
        
        // Button behaviour
        _isPausingRecording = this.WhenAnyValue(x => x.State)
            .Select(condition => condition == ApplicationState.PausingRecording)
            .ToProperty(this, x => x.IsPausingRecording);


        // Error showing
        _isError = this.WhenAnyValue(x => x.ExceptionMessage).Select(message => message != null)
            .ToProperty(this, x => x.IsError);
    }
    
    private ApplicationState _state = ApplicationState.ShowingResults;

    public ApplicationState State
    {
        get => _state;
        private set => this.RaiseAndSetIfChanged(ref _state, value);
    }
    
    // File-loading concerned attributes
    private string _exceptionMessage = "";
    private string _filenameToLoad = "";

    public string FilenameToLoad
    {
        get => _filenameToLoad;
        set => this.RaiseAndSetIfChanged(ref _filenameToLoad, value);
    }
    
    public string ExceptionMessage
    {
        get => _exceptionMessage;
        private set => this.RaiseAndSetIfChanged(ref _exceptionMessage, value);
    }
    
    // Solution concered attributes
    
    private Graph? _graphRepresentation;
    private Solution? _solution; 
    private Tuple<List<Tuple<int, int, string>>, int>? _resultReplay;
    private bool? _isDFS = true;
    private bool? _isTSP = true;

    public Solution? Solution
    {
        get => _solution;
        private set => this.RaiseAndSetIfChanged(ref _solution, value);
    }
    
    public Graph? GraphRepresentation
    {
        get => _graphRepresentation;
        private set => this.RaiseAndSetIfChanged(ref _graphRepresentation, value);
    }
    
    public Tuple<List<Tuple<int, int, string>>, int>? ResultReplay
    {
        get => _resultReplay;
        private set => this.RaiseAndSetIfChanged(ref _resultReplay, value);
    }
    
    public bool? IsDFS
    {
        get => _isDFS;
        private set => this.RaiseAndSetIfChanged(ref _isDFS, value);
    }
    
    public bool? IsTSP
    {
        get => _isTSP;
        private set => this.RaiseAndSetIfChanged(ref _isTSP, value);
    }

    // Appearance concerned attributes
    
    readonly ObservableAsPropertyHelper<bool> _isError;
    private bool IsError => _isError.Value;

    private bool _allBarHidden;
    public bool AllBarHidden
    {
        get => _allBarHidden;
        set {
        this.RaiseAndSetIfChanged(ref _allBarHidden, value);
        // PropertyChanged(nameof(_allBarHidden));

        }
    }

    // Input Bar State
    readonly ObservableAsPropertyHelper<bool> _inputBarIsOpen;
    readonly ObservableAsPropertyHelper<bool> _inputBarIsHidden;

    public bool InputBarIsOpen => _inputBarIsOpen.Value;
    public bool InputBarIsHidden => _inputBarIsHidden.Value;
    
    readonly ObservableAsPropertyHelper<bool> _searchBarIsOpen;
    readonly ObservableAsPropertyHelper<bool> _searchBarIsHidden;

    public bool SearchBarIsOpen => _searchBarIsOpen.Value;
    public bool SearchBarIsHidden => _searchBarIsHidden.Value;
    
    // Input Bar State
    readonly ObservableAsPropertyHelper<bool> _resultBarIsOpen;
    readonly ObservableAsPropertyHelper<bool> _resultBarIsHidden;
    readonly ObservableAsPropertyHelper<bool> _resultBarIsDiscreet;


    public bool ResultBarIsOpen => _resultBarIsOpen.Value;
    public bool ResultBarIsHidden => _resultBarIsHidden.Value;
    public bool ResultBarIsDiscreet => _resultBarIsDiscreet.Value;
    
    // Replay Bar State
    readonly ObservableAsPropertyHelper<bool> _replayBarIsOpen;
    readonly ObservableAsPropertyHelper<bool> _replayBarIsHidden;
    readonly ObservableAsPropertyHelper<bool> _replayBarIsDiscreet;


    public bool ReplayBarIsOpen => _replayBarIsOpen.Value;
    public bool ReplayBarIsHidden => _replayBarIsHidden.Value;
    public bool ReplayBarIsDiscreet => _replayBarIsDiscreet.Value;
    
    readonly ObservableAsPropertyHelper<bool> _isPausingRecording;

    public bool IsPausingRecording => _isPausingRecording.Value;

    public void ChangeState()
    {
        State = ApplicationState.ShowingResults;
    }

    public event PropertyChangedEventHandler PropertyChanged;



    public void ButtonClicked()
    {
        switch (State)
        {
            case ApplicationState.FileNotLoaded:
                LoadingFile();
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
    
    // Button methods
    
    public void ToggleAllBarHidden()
    {
        AllBarHidden = !AllBarHidden;
    }
    
    public void LoadingFile()
    {
        State = ApplicationState.FileLoading;
        ExceptionMessage = "";
        Console.WriteLine(FilenameToLoad);
        try
        {
            GraphRepresentation = new Graph(FilenameToLoad);
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
        if (GraphRepresentation != null && IsDFS.HasValue && IsTSP.HasValue)
        {
            Solution = GraphRepresentation.Solve(IsDFS.Value, IsTSP.Value);
            ResultReplay = Tuple.Create(Solution.getProgress(), -1);
            State = ApplicationState.ShowingResults;
            return;
        }

        State = ApplicationState.FileLoaded;
    }

    public void PlayRecording() { State = ApplicationState.PlayingRecording; }

    public void PauseRecording() { State = ApplicationState.PausingRecording; }

    public void StopPlayingRecording()
    {
        State = ApplicationState.ShowingResults;
    }
    
    public void ReplayingRecording()
    {
        State = ApplicationState.PlayingRecording;
    }
    
    
}