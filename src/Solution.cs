using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tubes2Stima
{
    internal class Solution
    {
        private int nodes;
        private List<Tuple<int, int, string>> progress;
        private string route;
        private int steps;
        private System.Diagnostics.Stopwatch executionTime;
        private char[,] solutionMap;
        private List<Tuple<int, int>> treasures;

        public Solution(int nodes, List<Tuple<int, int, string>> progress, List<char> route, int steps, System.Diagnostics.Stopwatch executionTime, char[,] map, List<Tuple<int, int>> treasures)
        {
            this.nodes = nodes;
            this.progress = progress;
            string routeFinal = "";
            for (int i = 0; i < route.Count; i++)
            {
                if (i != route.Count - 1)
                {
                    routeFinal += (route.ElementAt(i) + " - ");
                }
                else
                {
                    routeFinal += (route.ElementAt(i));
                }
            }
            this.route = routeFinal;
            this.steps = steps;
            this.executionTime = executionTime;
            this.solutionMap = map;
            this.treasures = treasures;
        }

        public int getNodes()
        {
            return this.nodes;
        }

        public List<Tuple<int, int, string>> getProgress()
        {
            return this.progress;
        }

        public string getRoute()
        {
            return this.route;
        }

        public int getSteps()
        {
            return this.steps;
        }

        public System.Diagnostics.Stopwatch getExecutionTime()
        {
            return this.executionTime;
        }

        public char[,] getSolutionMap()
        {
            return this.solutionMap;
        }

        public List<Tuple<int, int>> getTreasures()
        {
            return this.treasures;
        }
    }
}
