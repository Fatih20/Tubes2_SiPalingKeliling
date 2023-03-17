using System.Diagnostics;

class BFS {
    static void bfs(char[,] map, Queue<Tuple<int,int>> current, int xBefore, int yBefore, bool[,] isVisited, ref int count, List<Tuple<int,int>> path, Queue<List<Tuple<int,int>>> track, List<Tuple<int,int>> solution){
        /*
            The main BFS recursive function
            Param :
                map : the given map
                x : the current x coordinate
                y : the current y coordinate
                xBefore : the x coordinate before
                yBefore : the y coordinate before
                isVisited : states which coordinate has been visited or not
                count : counts treasures that were found
                path : collects the path from starting point to all treasures
                track : collects temporary path to a treasure, will be removed if the current track doesn't end on treasure box
                solution : collects coordinates of the treasures
        */

        if(current.Count == 0){
            return;
        }

        // Getting N
        int size = map.GetLength(0);
        Tuple<int,int> coor = current.Dequeue();
        int x = coor.Item1;
        int y = coor.Item2;
        List<Tuple<int,int>> currentTrack = track.Dequeue();

        // If map is not out of bounds
        if(x >= 0 && x < size && y >= 0 && y < size){
            // If map is already visited or blocked
            if(isVisited[x,y] || map[x,y] == 'X'){
                // Do nothing
            } else {
                // Visit map
                isVisited[x,y] = true;

                // If it contains treasure
                if(map[x,y] == 'T'){
                    count++;
                    solution.Add(new Tuple<int,int>(x,y));
                    path.AddRange(currentTrack);
                    currentTrack.ForEach(p => Console.WriteLine(p.Item1 + " " + p.Item2));
                    for(int i = 0; i < size; i++){
                        for(int j = 0; j < size; j++){
                            isVisited[i,j] = false;
                        }
                    }
                    map[x,y] = 'R';
                    track.Clear();
                    current.Clear();
                    currentTrack.Clear();
                    isVisited[x,y] = true;
                }

                // BFS on L-U-R-D pattern
                current.Enqueue(new Tuple<int,int>(x, y-1));
                List<Tuple<int,int>> newTrack = new List<Tuple<int,int>>(currentTrack);
                newTrack.Add(new Tuple<int,int>(x, y-1));
                track.Enqueue(newTrack);

                current.Enqueue(new Tuple<int,int>(x-1, y));
                List<Tuple<int,int>> newTrack2 = new List<Tuple<int,int>>(currentTrack);
                newTrack2.Add(new Tuple<int,int>(x-1, y));
                track.Enqueue(newTrack2);

                current.Enqueue(new Tuple<int,int>(x, y+1));
                List<Tuple<int,int>> newTrack3 = new List<Tuple<int,int>>(currentTrack);
                newTrack3.Add(new Tuple<int,int>(x, y+1));
                track.Enqueue(newTrack3);

                current.Enqueue(new Tuple<int,int>(x+1, y));
                List<Tuple<int,int>> newTrack4 = new List<Tuple<int,int>>(currentTrack);
                newTrack4.Add(new Tuple<int,int>(x+1, y));
                track.Enqueue(newTrack4);
            }
        }
        bfs(map, current, x, y, isVisited, ref count, path, track, solution);
    }

    static void tspBFS(char[,] map, Queue<Tuple<int,int>> current, int xBefore, int yBefore, bool[,] isVisited, List<Tuple<int,int>> path, Queue<List<Tuple<int,int>>> track, ref bool finish){
        /*
            The main BFS recursive function
            Param :
                map : the given map
                x : the current x coordinate
                y : the current y coordinate
                xBefore : the x coordinate before
                yBefore : the y coordinate before
                isVisited : states which coordinate has been visited or not
                count : counts treasures that were found
                path : collects the path from starting point to all treasures
                track : collects temporary path to a treasure, will be removed if the current track doesn't end on treasure box
                solution : collects coordinates of the treasures
        */

        if(current.Count == 0 || finish){
            return;
        }

        // Getting N
        int size = map.GetLength(0);
        Tuple<int,int> coor = current.Dequeue();
        int x = coor.Item1;
        int y = coor.Item2;
        List<Tuple<int,int>> currentTrack = track.Dequeue();

        // If map is not out of bounds
        if(x >= 0 && x < size && y >= 0 && y < size){
            // If map is already visited or blocked
            if(isVisited[x,y] || map[x,y] == 'X'){
                // Do nothing
            } else {
                // Visit map
                isVisited[x,y] = true;

                // If it contains treasure
                if(map[x,y] == 'K'){
                    path.AddRange(currentTrack);
                    return;
                }

                // BFS on L-U-R-D pattern
                current.Enqueue(new Tuple<int,int>(x, y-1));
                List<Tuple<int,int>> newTrack = new List<Tuple<int,int>>(currentTrack);
                newTrack.Add(new Tuple<int,int>(x, y-1));
                track.Enqueue(newTrack);

                current.Enqueue(new Tuple<int,int>(x-1, y));
                List<Tuple<int,int>> newTrack2 = new List<Tuple<int,int>>(currentTrack);
                newTrack2.Add(new Tuple<int,int>(x-1, y));
                track.Enqueue(newTrack2);

                current.Enqueue(new Tuple<int,int>(x, y+1));
                List<Tuple<int,int>> newTrack3 = new List<Tuple<int,int>>(currentTrack);
                newTrack3.Add(new Tuple<int,int>(x, y+1));
                track.Enqueue(newTrack3);

                current.Enqueue(new Tuple<int,int>(x+1, y));
                List<Tuple<int,int>> newTrack4 = new List<Tuple<int,int>>(currentTrack);
                newTrack4.Add(new Tuple<int,int>(x+1, y));
                track.Enqueue(newTrack4);
            }
        }
        tspBFS(map, current, x, y, isVisited, path, track, ref finish);
    }

    static void printMap(char[,] map){
        // Function to print the map
        int size = map.GetLength(0);
        for(int i = 0; i < size; i++){
            for(int j = 0; j < size; j++){
                Console.Write(map[i,j]);
            }
            Console.WriteLine();
        }
    }

    static void memset(char[,] buffer, char value, int size){
        // Function to set a buffer with the given value
        for(int i = 0; i < size; i++){
            for(int j = 0; j < size; j++){
                buffer[i,j] = value;
            }
        }
    }

    static void setSolution(char[,] buffer, List<Tuple<int,int>> path, List<Tuple<int,int>> solution){
        // Function to plot the path to the treasures
        foreach (var coor in path){
            buffer[coor.Item1, coor.Item2] = 'P';
        }
        foreach (var coor in solution){
            buffer[coor.Item1, coor.Item2] = 'T';
        }
    }

    public static void setSolutionTSP(char[,] buffer, List<Tuple<int,int>> path, Tuple<int,int> start, Tuple<int,int> end){
        // Function to plot the path to starting point
        foreach (var coor in path){
            buffer[coor.Item1, coor.Item2] = 'P';
        }
        buffer[start.Item1, start.Item2] = 'K';
        buffer[end.Item1, end.Item2] = 'L';
    }

    static Tuple<int,int> getStartingPoint(char[,] map, int size){
        // Function to get the starting point of the map
        for(int i = 0; i < size; i++){
            for(int j = 0; j < size; j++){
                if(map[i,j] == 'K'){
                    return new Tuple<int, int>(i,j);
                }
            }
        }
        return new Tuple<int, int>(0,0);
    }

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
            memset(solution, 'X', N);
            memset(tspMap, 'X', N);
            
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
            Tuple<int,int> startingCoor = getStartingPoint(map, N);

            Queue<Tuple<int,int>> bfsTrack = new Queue<Tuple<int,int>>();
            bfsTrack.Enqueue(startingCoor);
            List<Tuple<int,int>> startingTrack = new List<Tuple<int,int>>();
            startingTrack.Add(startingCoor);
            track.Enqueue(startingTrack);

            // DFS Algorithm
            bfs(map, bfsTrack, startingCoor.Item1, startingCoor.Item2, isVisited, ref count, path, track, treasure);

            // Plotting the solution
            setSolution(solution, path, treasure);

            Tuple<int,int> startingTSPCoor = new Tuple<int,int>(treasure.Last().Item1,treasure.Last().Item2);
            Queue<Tuple<int,int>> tspBFSTrack = new Queue<Tuple<int,int>>();
            tspBFSTrack .Enqueue(startingTSPCoor);
            List<Tuple<int,int>> startingTrackForTSP = new List<Tuple<int,int>>();
            startingTrackForTSP.Add(startingTSPCoor);
            trackTSP.Enqueue(startingTrackForTSP);

            // TSP Algorithm
            tspBFS(map, tspBFSTrack, treasure.Last().Item1, treasure.Last().Item2, isVisitedTSP, pathTSP, trackTSP, ref finishTSP);

            // Plotting the TSP
            setSolutionTSP(tspMap, pathTSP, startingCoor, treasure.Last());

            // Stop timer
            stopwatch.Stop();

            // Print map
            Console.WriteLine("Peta Harta Karun");
            printMap(map);

            Console.WriteLine("\nPeta Jalur ke Harta Karun");
            printMap(solution);
            
            Console.WriteLine("\nPeta Jalur Kembali ke Starting Point dari Treasure Terakhir");
            printMap(tspMap);

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