using System.Diagnostics;

class DFS {
    static void dfs(char[,] map, int x, int y, int xBefore, int yBefore, bool[,] isVisited, ref int count, List<Tuple<int,int>> path, List<Tuple<int,int>> track, List<Tuple<int,int>> solution){
        /*
            The main DFS recursive function
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

        // Getting N
        int size = map.GetLength(0);

        // If map is not out of bounds
        if(x >= 0 && x < size && y >= 0 && y < size){
            // If map is already visited or blocked
            if(isVisited[x,y] || map[x,y] == 'X'){
                return;
            } else {
                // Visit map
                isVisited[x,y] = true;

                // Add map to track
                track.Add(new Tuple<int,int>(x,y));

                // If it contains treasure
                if(map[x,y] == 'T'){
                    count++;
                    solution.Add(new Tuple<int,int>(x,y));
                    path.AddRange(track);
                }

                // DFS on L-U-R-D pattern
                dfs(map, x, y-1, x, y, isVisited, ref count, path, track, solution);
                dfs(map, x-1, y, x, y, isVisited, ref count, path, track, solution);
                dfs(map, x, y+1, x, y, isVisited, ref count, path, track, solution);
                dfs(map, x+1, y, x, y, isVisited, ref count, path, track, solution);

                // If track is blocked and nowhere to continue
                if(xBefore-1 >= 0 && xBefore+1 < size && yBefore-1 >= 0 && yBefore+1 < size && isVisited[xBefore-1,yBefore] && isVisited[xBefore,yBefore+1] && isVisited[xBefore+1,yBefore] && isVisited[xBefore,yBefore-1]){
                    track.Clear();
                } else if (track.Count > 0) {
                    // Remove current map from track and continue add another map to track
                    track.RemoveAt(track.Count - 1);
                }
                return;
            }
        } else {
            return;
        }
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
        const int N = 5;

        // Initialize lists
        List<Tuple<int,int>> path = new List<Tuple<int,int>>();
        List<Tuple<int,int>> track = new List<Tuple<int,int>>();
        List<Tuple<int,int>> treasure = new List<Tuple<int,int>>();
        char[,] map = {{'R', 'R', 'K', 'X', 'T'},
                       {'R', 'X', 'X', 'X', 'R'},
                       {'R', 'R', 'R', 'R', 'R'},
                       {'R', 'X', 'R', 'X', 'R'},
                       {'X', 'T', 'R', 'X', 'R'}};
        char[,] solution = new char[N, N];
        bool[,] isVisited = new bool[N, N];

        // Set all of the solution map with 'X' char
        memset(solution, 'X', N);
        
        // Set all of the isVisited value with false
        for(int i = 0; i < N; i++){
            for(int j = 0; j < N; j++){
                isVisited[i,j] = false;
            }
        }

        // Initialize variable to count the treasures
        int count = 0;

        // Start timer
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        // Searching for the starting point
        Tuple<int,int> startingCoor = getStartingPoint(map, N);

        // DFS Algorithm
        dfs(map, startingCoor.Item1, startingCoor.Item2, startingCoor.Item1, startingCoor.Item2, isVisited, ref count, path, track, treasure);

        // Plotting the solution
        setSolution(solution, path, treasure);

        // Stop timer
        stopwatch.Stop();

        // Print map
        Console.WriteLine("Peta Harta Karun");
        printMap(map);

        Console.WriteLine("\nPeta Jalur ke Harta Karun");
        printMap(solution);

        // Print solution
        Console.WriteLine($"\nTerdapat {count} treasure yang dapat ditemukan.");
        Console.WriteLine($"Execution Time: {stopwatch.ElapsedMilliseconds} ms");
    }
}