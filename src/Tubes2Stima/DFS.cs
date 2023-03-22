using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tubes2Stima
{
    internal class DFS
    {
        private int startingX;
        private int startingY;

        private int startingXTSP;
        private int startingYTSP;

        public DFS(int x, int y)
        {
            this.startingX = x;
            this.startingY = y;
        }

        public void setTSP(int x, int y)
        {
            this.startingXTSP = x;
            this.startingYTSP = y;
        }

        public void dfs(char[,] map, int x, int y, int xBefore, int yBefore, bool[,] isVisited, ref int count, List<Tuple<int, int>> path, List<Tuple<int, int>> track, List<Tuple<int, int>> solution, List<Tuple<int, int, string>> progress, ref int nodes, int M, int N, int treasures)
        {
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
                    nodes : count how many nodes visited
                    M, N : size of the map
                    treasures : the amount of available treasures
            */

            // If map is not out of bounds and not all treasures have been collected
            if (x >= 0 && x < M && y >= 0 && y < N && count != treasures)
            {
                // If map is already visited or blocked
                if (isVisited[x, y] || map[x, y] == 'X')
                {
                    return;
                }
                else
                {
                    // Visit map
                    nodes++;
                    isVisited[x, y] = true;
                    progress.Add(new Tuple<int, int, string>(x, y, "GREEN"));

                    // Add map to track
                    track.Add(new Tuple<int, int>(x, y));

                    // If it contains treasure
                    if (map[x, y] == 'T')
                    {
                        count++;
                        solution.Add(new Tuple<int, int>(x, y));
                        path.AddRange(track);
                        track.Clear();
                        if (count == treasures) return;
                    }

                    // DFS on L-U-R-D pattern
                    dfs(map, x, y - 1, x, y, isVisited, ref count, path, track, solution, progress, ref nodes, M, N, treasures);
                    if (count == treasures) return;
                    if (progress.Last().Item1 != x || progress.Last().Item2 != y)
                    {
                        progress.Add(new Tuple<int, int, string>(x, y, "RED"));
                        nodes++;
                    }

                    dfs(map, x - 1, y, x, y, isVisited, ref count, path, track, solution, progress, ref nodes, M, N, treasures);
                    if (count == treasures) return;
                    if (progress.Last().Item1 != x || progress.Last().Item2 != y)
                    {
                        progress.Add(new Tuple<int, int, string>(x, y, "RED"));
                        nodes++;
                    }

                    dfs(map, x, y + 1, x, y, isVisited, ref count, path, track, solution, progress, ref nodes, M, N, treasures);
                    if (count == treasures) return;
                    if (progress.Last().Item1 != x || progress.Last().Item2 != y)
                    {
                        progress.Add(new Tuple<int, int, string>(x, y, "RED"));
                        nodes++;
                    }

                    dfs(map, x + 1, y, x, y, isVisited, ref count, path, track, solution, progress, ref nodes, M, N, treasures);
                    if (count == treasures) return;
                    if (progress.Last().Item1 != x || progress.Last().Item2 != y)
                    {
                        progress.Add(new Tuple<int, int, string>(x, y, "RED"));
                        nodes++;
                    }

                    // If track is blocked and nowhere to continue
                    if (xBefore - 1 >= 0 && xBefore + 1 < M && yBefore - 1 >= 0 && yBefore + 1 < N && isVisited[xBefore - 1, yBefore] && isVisited[xBefore, yBefore + 1] && isVisited[xBefore + 1, yBefore] && isVisited[xBefore, yBefore - 1])
                    {
                        track.Clear();
                    }
                    else if (track.Count > 0)
                    {
                        // Remove current map from track and continue add another map to track
                        track.RemoveAt(track.Count - 1);
                    }

                    // Pop last backtrack to starting point
                    if (x == this.startingX && y == this.startingY)
                    {
                        Tuple<int, int, string> startingCoor = new Tuple<int, int, string>(solution.Last().Item1, solution.Last().Item2, "GREEN");
                        while (!progress.Last().Equals(startingCoor))
                        {
                            progress.RemoveAt(progress.Count - 1);
                            nodes--;
                        }
                    }
                    return;
                }
            }
            else
            {
                return;
            }
        }

        public void tspDFS(char[,] map, int x, int y, int xBefore, int yBefore, bool[,] isVisited, List<Tuple<int, int>> path, List<Tuple<int, int>> track, ref bool finish, List<Tuple<int, int, string>> progress, ref int nodes, int M, int N)
        {
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

            // If map is not out of bounds
            if (x >= 0 && x < M && y >= 0 && y < N && !finish)
            {
                // If map is already visited or blocked
                if (isVisited[x, y] || map[x, y] == 'X')
                {
                    return;
                }
                else
                {
                    if (x != xBefore || y != yBefore)
                    {
                        // Visit map
                        nodes++;
                        isVisited[x, y] = true;
                        progress.Add(new Tuple<int, int, string>(x, y, "GREEN"));

                        // Add map to track
                        track.Add(new Tuple<int, int>(x, y));

                        // If it reached starting point
                        if (map[x, y] == 'K')
                        {
                            finish = true;
                            path.AddRange(track);
                            track.Clear();
                            return;
                        }
                    }

                    // DFS on L-U-R-D pattern
                    tspDFS(map, x, y - 1, x, y, isVisited, path, track, ref finish, progress, ref nodes, M, N);
                    if (finish) return;
                    if (progress.Last().Item1 != x || progress.Last().Item2 != y)
                    {
                        progress.Add(new Tuple<int, int, string>(x, y, "RED"));
                        nodes++;
                    }

                    tspDFS(map, x - 1, y, x, y, isVisited, path, track, ref finish, progress, ref nodes, M, N);
                    if (finish) return;
                    if (progress.Last().Item1 != x || progress.Last().Item2 != y)
                    {
                        progress.Add(new Tuple<int, int, string>(x, y, "RED"));
                        nodes++;
                    }

                    tspDFS(map, x, y + 1, x, y, isVisited, path, track, ref finish, progress, ref nodes, M, N);
                    if (finish) return;
                    if (progress.Last().Item1 != x || progress.Last().Item2 != y)
                    {
                        progress.Add(new Tuple<int, int, string>(x, y, "RED"));
                        nodes++;
                    }

                    tspDFS(map, x + 1, y, x, y, isVisited, path, track, ref finish, progress, ref nodes, M, N);
                    if (finish) return;
                    if (progress.Last().Item1 != x || progress.Last().Item2 != y)
                    {
                        progress.Add(new Tuple<int, int, string>(x, y, "RED"));
                        nodes++;
                    }

                    // If track is blocked and nowhere to continue
                    if (xBefore - 1 >= 0 && xBefore + 1 < M && yBefore - 1 >= 0 && yBefore + 1 < N && isVisited[xBefore - 1, yBefore] && isVisited[xBefore, yBefore + 1] && isVisited[xBefore + 1, yBefore] && isVisited[xBefore, yBefore - 1])
                    {
                        track.Clear();
                    }
                    else if (track.Count > 0)
                    {
                        // Remove current map from track and continue add another map to track
                        track.RemoveAt(track.Count - 1);
                    }

                    return;
                }
            }
            else
            {
                return;
            }
        }
    }
}
