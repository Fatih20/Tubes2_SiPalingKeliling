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

        public Solution(int nodes, List<Tuple<int, int, string>> progress, List<char> route, int steps, System.Diagnostics.Stopwatch executionTime, char[,] map)
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
    }
}
