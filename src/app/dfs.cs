public class DFS {
    public static void dfs(char[,] map, int x, int y, int xBefore, int yBefore, bool[,] isVisited, ref int count, List<Tuple<int,int>> path, List<Tuple<int,int>> track, List<Tuple<int,int>> solution, List<Tuple<int,int>> progress){
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
                progress.Add(new Tuple<int, int>(x,y));

                // Add map to track
                track.Add(new Tuple<int,int>(x,y));

                // If it contains treasure
                if(map[x,y] == 'T'){
                    count++;
                    solution.Add(new Tuple<int,int>(x,y));
                    path.AddRange(track);
                    track.Clear();
                }

                // DFS on L-U-R-D pattern
                dfs(map, x, y-1, x, y, isVisited, ref count, path, track, solution, progress);
                dfs(map, x-1, y, x, y, isVisited, ref count, path, track, solution, progress);
                dfs(map, x, y+1, x, y, isVisited, ref count, path, track, solution, progress);
                dfs(map, x+1, y, x, y, isVisited, ref count, path, track, solution, progress);

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

    public static void tspDFS(char[,] map, int x, int y, int xBefore, int yBefore, bool[,] isVisited, List<Tuple<int,int>> path, List<Tuple<int,int>> track, ref bool finish, List<Tuple<int,int>> progress){
        /*
            The main TSP DFS recursive function
            Param :
                map : the given map
                x : the current x coordinate
                y : the current y coordinate
                xBefore : the x coordinate before
                yBefore : the y coordinate before
                isVisited : states which coordinate has been visited or not
                path : collects the path from last treasure found to starting point
                track : collects temporary path to starting point, will be removed if the current track doesn't end on starting point
        */

        // Getting N
        int size = map.GetLength(0);

        // If map is not out of bounds
        if(x >= 0 && x < size && y >= 0 && y < size && !finish){
            // If map is already visited or blocked
            if(isVisited[x,y] || map[x,y] == 'X'){
                return;
            } else {
                // Visit map
                isVisited[x,y] = true;
                progress.Add(new Tuple<int, int>(x,y));

                // Add map to track
                track.Add(new Tuple<int,int>(x,y));

                // If it reached starting point
                if(map[x,y] == 'K'){
                    finish = true;
                    path.AddRange(track);
                    track.Clear();
                    return;
                }

                // DFS on L-U-R-D pattern
                tspDFS(map, x, y-1, x, y, isVisited, path, track, ref finish, progress);
                tspDFS(map, x-1, y, x, y, isVisited, path, track, ref finish, progress);
                tspDFS(map, x, y+1, x, y, isVisited, path, track, ref finish, progress);
                tspDFS(map, x+1, y, x, y, isVisited, path, track, ref finish, progress);

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
}