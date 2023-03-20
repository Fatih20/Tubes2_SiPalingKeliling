using System.Diagnostics;
public class Graph {
    private int M;
    private int N;
    private char[,] map;
    private int treasures;

    public Graph(String pathfile){
        Tuple<char[,],int> config = ReadFile.readFile(pathfile);
        this.map = config.Item1;
        this.treasures = config.Item2;
        this.M = this.map.GetLength(0);
        this.N = this.map.GetLength(1);
    }

    public int getM(){
        return this.M;
    }

    public int getN(){
        return this.N;
    }

    public char[,] getMap(){
        return this.map;
    }

    public Solution Solve(bool isDFS, bool isTSP){
        if(isDFS){
            // Initialize Progress
            List<Tuple<int,int,string>> progressDFS = new List<Tuple<int,int,string>>();

            // Initialize lists
            List<Tuple<int,int>> path = new List<Tuple<int,int>>();
            List<Tuple<int,int>> track = new List<Tuple<int,int>>();
            List<Tuple<int,int>> treasure = new List<Tuple<int,int>>();

            // Initialize lists
            char[,] solution = new char[M, N];
            bool[,] isVisited = new bool[M, N];

            // Set all of the solution map with 'X' char
            Helper.memset(solution, 'X', M, N);
            
            // Set all of the isVisited value with false
            for(int i = 0; i < M; i++){
                for(int j = 0; j < N; j++){
                    isVisited[i,j] = false;
                }
            }

            // Initialize variable to count the treasures
            int count = 0;
            int nodes = 0;
            bool finishTSP = false;

            // Start timer
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            // Searching for the starting point
            Tuple<int,int> startingCoor = Helper.getStartingPoint(map, M, N);
    
            // DFS Algorithm
            DFS DFS = new DFS(startingCoor.Item1, startingCoor.Item2);
            DFS.dfs(map, startingCoor.Item1, startingCoor.Item2, startingCoor.Item1, startingCoor.Item2, isVisited, ref count, path, track, treasure, progressDFS, ref nodes, M, N, this.treasures);

            if(isTSP){
                // Initialize lists
                bool[,] isVisitedTSP = new bool[M, N];

                // Initialize lists
                List<Tuple<int,int>> pathTSP = new List<Tuple<int,int>>();
                List<Tuple<int,int>> trackTSP = new List<Tuple<int,int>>();

                // Set all of the isVisited value with false
                for(int i = 0; i < M; i++){
                    for(int j = 0; j < N; j++){
                        isVisitedTSP[i,j] = false;
                    }
                }

                // TSP Algorithm
                DFS.setTSP(treasure.Last().Item1, treasure.Last().Item2);
                DFS.tspDFS(map, treasure.Last().Item1, treasure.Last().Item2, treasure.Last().Item1, treasure.Last().Item2, isVisitedTSP, pathTSP, trackTSP, ref finishTSP, progressDFS, ref nodes, M, N);

                // Plotting the TSP
                Helper.setSolutionTSP(solution, pathTSP, startingCoor);
            }

            // Plotting the solution
            Helper.setSolution(solution, path, treasure, startingCoor);

            // Process Sequence into array of char
            List<char> sequence = Helper.sequenceMove(progressDFS);

            // Stop timer
            stopwatch.Stop();

            if(isTSP){
                return new Solution(nodes, progressDFS, sequence, progressDFS.Count - 1, stopwatch, solution);
            } else {
                return new Solution(nodes, progressDFS, sequence, progressDFS.Count - 1, stopwatch, solution);
            }
        } else {
            // Initialize Progress
            List<Tuple<int,int,string>> progressBFS = new List<Tuple<int,int,string>>();

            // Initialize lists and queues
            List<Tuple<int,int>> pathBFS = new List<Tuple<int,int>>();
            Queue<List<Tuple<int,int>>> trackBFS = new Queue<List<Tuple<int,int>>>();
            List<Tuple<int,int>> treasureBFS = new List<Tuple<int,int>>();

            // Initialize lists
            char[,] solution = new char[M, N];
            bool[,] isVisited = new bool[M, N];

            // Set all of the solution map with 'X' char
            Helper.memset(solution, 'X', M, N);
            
            // Set all of the isVisited value with false
            for(int i = 0; i < M; i++){
                for(int j = 0; j < N; j++){
                    isVisited[i,j] = false;
                }
            }

            // Initialize variable to count the treasures and visited nodes
            int count = 0;
            int nodes = 0;

            // Start timer
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            // Searching for the starting point
            Tuple<int,int> startingCoor = Helper.getStartingPoint(map, M, N);

            // Create queue and starting track for BFS
            Queue<Tuple<int,int>> bfsTrack = new Queue<Tuple<int,int>>();
            bfsTrack.Enqueue(startingCoor);

            List<Tuple<int,int>> startingTrack = new List<Tuple<int,int>>();
            startingTrack.Add(startingCoor);
            trackBFS.Enqueue(startingTrack);

            // DFS Algorithm
            BFS BFS = new BFS(startingCoor.Item1, startingCoor.Item2);
            BFS.bfs(map, bfsTrack, isVisited, ref count, pathBFS, trackBFS, treasureBFS, progressBFS, ref nodes, M, N, this.treasures);

            if(isTSP){
                // Initialize Progress
                List<Tuple<int,int>> progressBFSTSP = new List<Tuple<int,int>>();

                // Initialize lists
                List<Tuple<int,int>> pathTSPBFS = new List<Tuple<int,int>>();
                Queue<List<Tuple<int,int>>> trackTSPBFS = new Queue<List<Tuple<int,int>>>();
                
                // Initialize lists
                char[,] tspMap = new char[M, N];
                bool[,] isVisitedTSP = new bool[M, N];

                // Set all of the solution map with 'X' char
                Helper.memset(tspMap, 'X', M, N);

                // Set all of the isVisited value with false
                for(int i = 0; i < M; i++){
                    for(int j = 0; j < N; j++){
                        isVisitedTSP[i,j] = false;
                    }
                }

                // Create queue and starting track for TSP
                Tuple<int,int> startingTSPCoor = new Tuple<int,int>(treasureBFS.Last().Item1,treasureBFS.Last().Item2);
                Queue<Tuple<int,int>> tspBFSTrack = new Queue<Tuple<int,int>>();
                tspBFSTrack .Enqueue(startingTSPCoor);

                List<Tuple<int,int>> startingTrackForTSP = new List<Tuple<int,int>>();
                startingTrackForTSP.Add(startingTSPCoor);
                trackTSPBFS.Enqueue(startingTrackForTSP);

                // TSP Algorithm
                BFS.tspBFS(map, tspBFSTrack, isVisitedTSP, pathTSPBFS, trackTSPBFS, progressBFS, ref nodes, M, N);

                // Plotting the TSP
                Helper.setSolutionTSP(solution, pathTSPBFS, startingCoor);

                // Join path treasure and path TSP
                pathTSPBFS.RemoveAt(0);
                pathBFS.AddRange(pathTSPBFS);
            }

            // Plotting the solution
            Helper.setSolution(solution, pathBFS, treasureBFS, startingCoor);

            // Process Sequence into array of char
            List<char> sequence = Helper.sequenceMove(pathBFS);

            // Stop timer
            stopwatch.Stop();
            
            if(isTSP){
                return new Solution(nodes, progressBFS, sequence, sequence.Count, stopwatch, solution);
            } else {
                return new Solution(nodes, progressBFS, sequence, sequence.Count, stopwatch, solution);
            }
        }
    }
}