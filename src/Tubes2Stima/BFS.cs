using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tubes2Stima
{
    internal class BFS
    {
        private int startingX;
        private int startingY;

        private int startingXTSP;
        private int startingYTSP;

        public BFS(int x, int y)
        {
            this.startingX = x;
            this.startingY = y;
        }

        public void setTSP(int x, int y)
        {
            this.startingXTSP = x;
            this.startingYTSP = y;
        }

        public void bfs(char[,] map, PrioQueue<Tuple<int, int>> current, bool[,] isVisited, ref int count, List<Tuple<int, int>> path, PrioQueue<List<Tuple<int, int>>> track, List<Tuple<int, int>> solution, List<Tuple<int, int, string>> progress, ref int nodes, int M, int N, int treasures, int[,] countVisit)
        {
            /*
                The main BFS recursive function
                Param :
                    map : the given map
                    current : queue for determine the order in which nodes are visited
                    isVisited : states which coordinate has been visited or not
                    count : counts treasures that were found
                    path : collects the path from starting point to all treasures
                    track : collects temporary path to a treasure, will be removed if the current track doesn't end on treasure box
                    solution : collects coordinates of the treasures
            */

            // If the queue is empty, no more nodes can be visited OR all treasures have been found
            if (current.getNeff() == 0 || count == treasures)
            {
                return;
            }

            // Getting the current coordinate
            Tuple<int, int> coor = current.Dequeue();
            int x = coor.Item1;
            int y = coor.Item2;

            // Getting the current track from starting point
            List<Tuple<int, int>> currentTrack = track.Dequeue();

            // If map is not out of bounds
            if (x >= 0 && x < M && y >= 0 && y < N)
            {
                // If map is already visited or blocked
                if (isVisited[x, y] || map[x, y] == 'X')
                {
                    // Do nothing
                }
                else
                {
                    // Visit map
                    nodes++;
                    isVisited[x, y] = true;
                    countVisit[x, y]++;
                    progress.Add(new Tuple<int, int, string>(x, y, "GREEN"));

                    // If it contains treasure
                    if (map[x, y] == 'T')
                    {
                        // Add the amount of collected treasures
                        count++;

                        // Add current coordinate to solutions
                        solution.Add(new Tuple<int, int>(x, y));

                        // Save path
                        path.AddRange(currentTrack);

                        // Reset settings (Restart the search process from the current treasure)
                        for (int i = 0; i < M; i++)
                        {
                            for (int j = 0; j < N; j++)
                            {
                                isVisited[i, j] = false;
                            }
                        }

                        // Collect Treasure
                        map[x, y] = 'R';

                        // Reset lists and queue
                        track.Clear();
                        current.Clear();
                        currentTrack.Clear();

                        // Visit current node
                        isVisited[x, y] = true;
                    }

                    /*  BFS on L-U-R-D pattern */
                    // Enqueue Left Node
                    int countVisitQueue;

                    if (y - 1 >= 0)
                    {
                        countVisitQueue = countVisit[x, y - 1];
                    }
                    else
                    {
                        countVisitQueue = 0;
                    }
                    current.Enqueue(new ElPrioQueue<Tuple<int, int>>(new Tuple<int, int>(x, y - 1), countVisitQueue));

                    // Create a new track to left node from starting point
                    List<Tuple<int, int>> newTrack = new List<Tuple<int, int>>(currentTrack);
                    newTrack.Add(new Tuple<int, int>(x, y - 1));

                    // Enqueue the new track
                    track.Enqueue(new ElPrioQueue<List<Tuple<int, int>>>(newTrack, countVisitQueue));

                    // Enqueue Upper Node
                    if (x - 1 >= 0)
                    {
                        countVisitQueue = countVisit[x - 1, y];
                    }
                    else
                    {
                        countVisitQueue = 0;
                    }
                    current.Enqueue(new ElPrioQueue<Tuple<int, int>>(new Tuple<int, int>(x - 1, y), countVisitQueue));

                    // Create a new track to upper node from starting point
                    List<Tuple<int, int>> newTrack2 = new List<Tuple<int, int>>(currentTrack);
                    newTrack2.Add(new Tuple<int, int>(x - 1, y));

                    // Enqueue the new track
                    track.Enqueue(new ElPrioQueue<List<Tuple<int, int>>>(newTrack2, countVisitQueue));

                    // Enqueue Right Node
                    if (y + 1 < N)
                    {
                        countVisitQueue = countVisit[x, y + 1];
                    }
                    else
                    {
                        countVisitQueue = 0;
                    }
                    current.Enqueue(new ElPrioQueue<Tuple<int, int>>(new Tuple<int, int>(x, y + 1), countVisitQueue));

                    // Create a new track to right node from starting point
                    List<Tuple<int, int>> newTrack3 = new List<Tuple<int, int>>(currentTrack);
                    newTrack3.Add(new Tuple<int, int>(x, y + 1));

                    // Enqueue the new track
                    track.Enqueue(new ElPrioQueue<List<Tuple<int, int>>>(newTrack3, countVisitQueue));

                    // Enqueue Lower Node
                    if (x + 1 < M)
                    {
                        countVisitQueue = countVisit[x + 1, y];
                    }
                    else
                    {
                        countVisitQueue = 0;
                    }
                    current.Enqueue(new ElPrioQueue<Tuple<int, int>>(new Tuple<int, int>(x + 1, y), countVisitQueue));

                    // Create a new track to lower node from starting point
                    List<Tuple<int, int>> newTrack4 = new List<Tuple<int, int>>(currentTrack);
                    newTrack4.Add(new Tuple<int, int>(x + 1, y));

                    // Enqueue the new track
                    track.Enqueue(new ElPrioQueue<List<Tuple<int, int>>>(newTrack4, countVisitQueue));
                }
            }

            /* BFS to next node in queue */
            bfs(map, current, isVisited, ref count, path, track, solution, progress, ref nodes, M, N, treasures, countVisit);

            // Pop last path from last treasure
            if (x == this.startingX && y == this.startingY)
            {
                Tuple<int, int, string> lastCoor = new Tuple<int, int, string>(solution.Last().Item1, solution.Last().Item2, "GREEN");
                while (!progress.Last().Equals(lastCoor))
                {
                    progress.RemoveAt(progress.Count - 1);
                }
            }
        }

        public void tspBFS(char[,] map, PrioQueue<Tuple<int, int>> current, bool[,] isVisited, List<Tuple<int, int>> path, PrioQueue<List<Tuple<int, int>>> track, List<Tuple<int, int, string>> progress, ref int nodes, int M, int N, int[,] countVisit)
        {
            /*
                The main BFS recursive function
                Param :
                    map : the given map
                    current : queue for determine the order in which nodes are visited
                    isVisited : states which coordinate has been visited or not
                    path : collects the path from starting point to all treasures
                    track : collects temporary path to a treasure, will be removed if the current track doesn't end on treasure box
            */

            // If the queue is empty, no more nodes can be visited
            if (current.getNeff() == 0)
            {
                return;
            }

            // Getting the current coordinate
            Tuple<int, int> coor = current.Dequeue();
            int x = coor.Item1;
            int y = coor.Item2;

            // Getting the current track from starting point
            List<Tuple<int, int>> currentTrack = track.Dequeue();

            // If map is not out of bounds
            if (x >= 0 && x < M && y >= 0 && y < N)
            {
                // If map is already visited or blocked
                if (isVisited[x, y] || map[x, y] == 'X')
                {
                    // Do nothing
                }
                else
                {
                    if (x != this.startingX || y != this.startingY)
                    {
                        // Visit map
                        nodes++;
                        isVisited[x, y] = true;
                        countVisit[x, y]++;
                        progress.Add(new Tuple<int, int, string>(x, y, "GREEN"));

                        // Reached starting point
                        if (map[x, y] == 'K')
                        {
                            path.AddRange(currentTrack);
                            return;
                        }
                    } else
                    {
                        isVisited[x, y] = true;
                    }

                    /* TSP BFS on L-U-R-D pattern */
                    // Enqueue Left Node
                    int countVisitQueue;

                    if (y - 1 >= 0)
                    {
                        countVisitQueue = countVisit[x, y - 1];
                    }
                    else
                    {
                        countVisitQueue = 0;
                    }
                    current.Enqueue(new ElPrioQueue<Tuple<int, int>>(new Tuple<int, int>(x, y - 1), countVisitQueue));

                    // Create a new track to left node from starting point
                    List<Tuple<int, int>> newTrack = new List<Tuple<int, int>>(currentTrack);
                    newTrack.Add(new Tuple<int, int>(x, y - 1));

                    // Enqueue the new track
                    track.Enqueue(new ElPrioQueue<List<Tuple<int, int>>>(newTrack, countVisitQueue));

                    // Enqueue Upper Node
                    if (x - 1 >= 0)
                    {
                        countVisitQueue = countVisit[x - 1, y];
                    }
                    else
                    {
                        countVisitQueue = 0;
                    }
                    current.Enqueue(new ElPrioQueue<Tuple<int, int>>(new Tuple<int, int>(x - 1, y), countVisitQueue));

                    // Create a new track to upper node from starting point
                    List<Tuple<int, int>> newTrack2 = new List<Tuple<int, int>>(currentTrack);
                    newTrack2.Add(new Tuple<int, int>(x - 1, y));

                    // Enqueue the new track
                    track.Enqueue(new ElPrioQueue<List<Tuple<int, int>>>(newTrack2, countVisitQueue));

                    // Enqueue Right Node
                    if (y + 1 < N)
                    {
                        countVisitQueue = countVisit[x, y + 1];
                    }
                    else
                    {
                        countVisitQueue = 0;
                    }
                    current.Enqueue(new ElPrioQueue<Tuple<int, int>>(new Tuple<int, int>(x, y + 1), countVisitQueue));

                    // Create a new track to right node from starting point
                    List<Tuple<int, int>> newTrack3 = new List<Tuple<int, int>>(currentTrack);
                    newTrack3.Add(new Tuple<int, int>(x, y + 1));

                    // Enqueue the new track
                    track.Enqueue(new ElPrioQueue<List<Tuple<int, int>>>(newTrack3, countVisitQueue));

                    // Enqueue Lower Node
                    if (x + 1 < M)
                    {
                        countVisitQueue = countVisit[x + 1, y];
                    }
                    else
                    {
                        countVisitQueue = 0;
                    }
                    current.Enqueue(new ElPrioQueue<Tuple<int, int>>(new Tuple<int, int>(x + 1, y), countVisitQueue));

                    // Create a new track to lower node from starting point
                    List<Tuple<int, int>> newTrack4 = new List<Tuple<int, int>>(currentTrack);
                    newTrack4.Add(new Tuple<int, int>(x + 1, y));

                    // Enqueue the new track
                    track.Enqueue(new ElPrioQueue<List<Tuple<int, int>>>(newTrack4, countVisitQueue));
                }
            }

            /* TSP BFS to next node in queue */
            tspBFS(map, current, isVisited, path, track, progress, ref nodes, M, N, countVisit);

            // Pop last path from last treasure
            if (x == this.startingXTSP && y == this.startingYTSP)
            {
                Tuple<int, int, string> startingCoor = new Tuple<int, int, string>(this.startingX, this.startingY, "GREEN");
                while (!progress.Last().Equals(startingCoor))
                {
                    progress.RemoveAt(progress.Count - 1);
                }
            }
        }
    }
}
