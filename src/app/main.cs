using System.Diagnostics;
class MainProgram {
    /*
    static void Main(string[] args){
        // Main function to test

        // N = size of map
        const int N = 6;

        // Initialize lists
        List<Tuple<int,int>> path = new List<Tuple<int,int>>();
        List<Tuple<int,int>> track = new List<Tuple<int,int>>();
        List<Tuple<int,int>> treasure = new List<Tuple<int,int>>();
        List<Tuple<int,int>> pathTSP = new List<Tuple<int,int>>();
        List<Tuple<int,int>> trackTSP = new List<Tuple<int,int>>();

        // Try to read file
        string pathfile = "./config/peta.txt";
        char[,] map;
        try {
            map = ReadFile.readFile(pathfile);

            // Initialize lists
            char[,] solution = new char[N, N];
            bool[,] isVisited = new bool[N, N];
            char[,] tspMap = new char[N, N];
            bool[,] isVisitedTSP = new bool[N, N];

            // Set all of the solution map with 'X' char
            Helper.memset(solution, 'X', N);
            Helper.memset(tspMap, 'X', N);
            
            // Set all of the isVisited value with false
            for(int i = 0; i < N; i++){
                for(int j = 0; j < N; j++){
                    isVisited[i,j] = false;
                }
            }
            for(int i = 0; i < N; i++){
                for(int j = 0; j < N; j++){
                    isVisitedTSP[i,j] = false;
                }
            }

            // Initialize variable to count the treasures
            int count = 0;
            bool finishTSP = false;

            // Start timer
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            // Searching for the starting point
            Tuple<int,int> startingCoor = Helper.getStartingPoint(map, N);

            // DFS Algorithm
            DFS.dfs(map, startingCoor.Item1, startingCoor.Item2, startingCoor.Item1, startingCoor.Item2, isVisited, ref count, path, track, treasure);

            // Plotting the solution
            Helper.setSolution(solution, path, treasure);

            // TSP Algorithm
            DFS.tspDFS(map, treasure.Last().Item1, treasure.Last().Item2, treasure.Last().Item1, treasure.Last().Item2, isVisitedTSP, pathTSP, trackTSP, ref finishTSP);

            // Plotting the TSP
            Helper.setSolutionTSP(tspMap, pathTSP, startingCoor, treasure.Last());

            // Stop timer
            stopwatch.Stop();

            // Print map
            Console.WriteLine("Peta Harta Karun");
            Helper.printMap(map);

            Console.WriteLine("\nPeta Jalur ke Harta Karun");
            Helper.printMap(solution);
            
            Console.WriteLine("\nPeta Jalur Kembali ke Starting Point dari Treasure Terakhir");
            Helper.printMap(tspMap);

            // Print solution
            Console.WriteLine($"\nTerdapat {count} treasure yang dapat ditemukan.");
            Console.WriteLine($"Execution Time: {stopwatch.ElapsedMilliseconds} ms");
        } catch (FileNotFoundException){
            Console.WriteLine("File tidak ditemukan!");
        } catch (Exception e2){
            if(e2.GetType() == typeof(System.IO.DirectoryNotFoundException)){
                Console.WriteLine("Directory file tidak ditemukan!");
            } else {
                Console.WriteLine(e2.Message);
            }
        }
    }
    */

    static void Main(string[] args){
        // Main function to test

        // N = size of map
        const int N = 6;

        // Initialize lists
        List<Tuple<int,int>> path = new List<Tuple<int,int>>();
        Queue<List<Tuple<int,int>>> track = new Queue<List<Tuple<int,int>>>();
        List<Tuple<int,int>> treasure = new List<Tuple<int,int>>();
        List<Tuple<int,int>> pathTSP = new List<Tuple<int,int>>();
        Queue<List<Tuple<int,int>>> trackTSP = new Queue<List<Tuple<int,int>>>();

        // Try to read file
        string pathfile = "./config/peta.txt";
        char[,] map;
        try {
            map = ReadFile.readFile(pathfile);

            // Initialize lists
            char[,] solution = new char[N, N];
            bool[,] isVisited = new bool[N, N];
            char[,] tspMap = new char[N, N];
            bool[,] isVisitedTSP = new bool[N, N];

            // Set all of the solution map with 'X' char
            Helper.memset(solution, 'X', N);
            Helper.memset(tspMap, 'X', N);
            
            // Set all of the isVisited value with false
            for(int i = 0; i < N; i++){
                for(int j = 0; j < N; j++){
                    isVisited[i,j] = false;
                }
            }
            for(int i = 0; i < N; i++){
                for(int j = 0; j < N; j++){
                    isVisitedTSP[i,j] = false;
                }
            }

            // Initialize variable to count the treasures
            int count = 0;

            // Start timer
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            // Searching for the starting point
            Tuple<int,int> startingCoor = Helper.getStartingPoint(map, N);

            Queue<Tuple<int,int>> bfsTrack = new Queue<Tuple<int,int>>();
            bfsTrack.Enqueue(startingCoor);
            List<Tuple<int,int>> startingTrack = new List<Tuple<int,int>>();
            startingTrack.Add(startingCoor);
            track.Enqueue(startingTrack);

            // DFS Algorithm
            BFS.bfs(map, bfsTrack, isVisited, ref count, path, track, treasure);

            // Plotting the solution
            Helper.setSolution(solution, path, treasure);

            Tuple<int,int> startingTSPCoor = new Tuple<int,int>(treasure.Last().Item1,treasure.Last().Item2);
            Queue<Tuple<int,int>> tspBFSTrack = new Queue<Tuple<int,int>>();
            tspBFSTrack .Enqueue(startingTSPCoor);
            List<Tuple<int,int>> startingTrackForTSP = new List<Tuple<int,int>>();
            startingTrackForTSP.Add(startingTSPCoor);
            trackTSP.Enqueue(startingTrackForTSP);

            // TSP Algorithm
            BFS.tspBFS(map, tspBFSTrack, isVisitedTSP, pathTSP, trackTSP);

            // Plotting the TSP
            Helper.setSolutionTSP(tspMap, pathTSP, startingCoor, treasure.Last());

            // Stop timer
            stopwatch.Stop();

            // Print map
            Console.WriteLine("Peta Harta Karun");
            Helper.printMap(map);

            Console.WriteLine("\nPeta Jalur ke Harta Karun");
            Helper.printMap(solution);
            
            Console.WriteLine("\nPeta Jalur Kembali ke Starting Point dari Treasure Terakhir");
            Helper.printMap(tspMap);

            // Print solution
            Console.WriteLine($"\nTerdapat {count} treasure yang dapat ditemukan.");
            Console.WriteLine($"Execution Time: {stopwatch.ElapsedMilliseconds} ms");
        } catch (FileNotFoundException){
            Console.WriteLine("File tidak ditemukan!");
        } catch (Exception e2){
            if(e2.GetType() == typeof(System.IO.DirectoryNotFoundException)){
                Console.WriteLine("Directory file tidak ditemukan!");
            } else {
                Console.WriteLine(e2.Message);
            }
        }
    }
}