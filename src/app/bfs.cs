public class BFS {
    public static void bfs(char[,] map, Queue<Tuple<int,int>> current, bool[,] isVisited, ref int count, List<Tuple<int,int>> path, Queue<List<Tuple<int,int>>> track, List<Tuple<int,int>> solution){
        /*
            The main BFS recursive function
            Param :
                map : the given map
                x : the current x coordinate
                y : the current y coordinate
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
        bfs(map, current, isVisited, ref count, path, track, solution);
    }

    public static void tspBFS(char[,] map, Queue<Tuple<int,int>> current, bool[,] isVisited, List<Tuple<int,int>> path, Queue<List<Tuple<int,int>>> track){
        /*
            The main BFS recursive function
            Param :
                map : the given map
                x : the current x coordinate
                y : the current y coordinate
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
        tspBFS(map, current, isVisited, path, track);
    }
}