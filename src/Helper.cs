using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Diagnostics;

namespace Tubes2Stima
{
    internal class Helper
    {
        public static DataTable DataTableFromTextFile(string location)
        {
            // Function to convert txt file to DataTable
            DataTable result = new DataTable();

            Graph graph = new Graph(location);

            for (int j = 0; j < graph.getN(); j++)
            {
                DataColumn dc = new DataColumn();
                result.Columns.Add(dc);
            }

            for (int i = 0; i < graph.getM(); i++)
            {
                DataRow dr = result.NewRow();
                for(int j = 0; j < graph.getN(); j++)
                {
                    dr[j] = graph.getMap()[i,j];
                }
                result.Rows.Add(dr);
            }
            return result;
        }

        public static void printMap(char[,] map, int M, int N)
        {
            // Function to print the map
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Debug.WriteLine(map[i, j]);
                }
                Debug.WriteLine("");
            }
        }

        public static void memset(char[,] buffer, char value, int M, int N)
        {
            // Function to set a buffer with the given value
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    buffer[i, j] = value;
                }
            }
        }

        public static void setSolution(char[,] buffer, List<Tuple<int, int>> path, List<Tuple<int, int>> solution, Tuple<int, int> start)
        {
            // Function to plot the path to the treasures
            foreach (var coor in path)
            {
                buffer[coor.Item1, coor.Item2] = 'P';
            }
            foreach (var coor in solution)
            {
                buffer[coor.Item1, coor.Item2] = 'T';
            }
            buffer[start.Item1, start.Item2] = 'K';
        }

        public static void setSolutionTSP(char[,] buffer, List<Tuple<int, int>> path, Tuple<int, int> start)
        {
            // Function to plot the path to starting point
            foreach (var coor in path)
            {
                buffer[coor.Item1, coor.Item2] = 'P';
            }
            buffer[start.Item1, start.Item2] = 'K';
        }

        public static Tuple<int, int> getStartingPoint(char[,] map, int M, int N)
        {
            // Function to get the starting point of the map
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (map[i, j] == 'K')
                    {
                        return new Tuple<int, int>(i, j);
                    }
                }
            }
            return new Tuple<int, int>(0, 0);
        }

        public static List<char> sequenceMove(List<Tuple<int, int, string>> progress)
        {
            List<char> sequence = new List<char>();
            for (int i = 0; i < progress.Count - 1; i++)
            {
                Tuple<int, int, string> firstNode = progress.ElementAt(i);
                Tuple<int, int, string> secondNode = progress.ElementAt(i + 1);
                if (firstNode.Item1 == secondNode.Item1 && secondNode.Item2 > firstNode.Item2)
                {
                    sequence.Add('R');
                }
                else if (firstNode.Item1 == secondNode.Item1 && secondNode.Item2 < firstNode.Item2)
                {
                    sequence.Add('L');
                }
                else if (firstNode.Item1 > secondNode.Item1 && secondNode.Item2 == firstNode.Item2)
                {
                    sequence.Add('U');
                }
                else
                {
                    sequence.Add('D');
                }
            }
            return sequence;
        }

        public static List<char> sequenceMove(List<Tuple<int, int>> progress)
        {
            List<char> sequence = new List<char>();
            for (int i = 0; i < progress.Count - 1; i++)
            {
                Tuple<int, int> firstNode = progress.ElementAt(i);
                Tuple<int, int> secondNode = progress.ElementAt(i + 1);
                if (firstNode.Item1 == secondNode.Item1 && secondNode.Item2 > firstNode.Item2)
                {
                    sequence.Add('R');
                }
                else if (firstNode.Item1 == secondNode.Item1 && secondNode.Item2 < firstNode.Item2)
                {
                    sequence.Add('L');
                }
                else if (firstNode.Item1 > secondNode.Item1 && secondNode.Item2 == firstNode.Item2)
                {
                    sequence.Add('U');
                }
                else
                {
                    sequence.Add('D');
                }
            }
            return sequence;
        }
    }
}
