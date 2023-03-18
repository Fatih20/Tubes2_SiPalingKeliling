public class Solution {
    private int nodes;
    private List<Tuple<int,int,string>> progress;
    private List<char> route;
    private int steps;
    private System.Diagnostics.Stopwatch executionTime;
    private char[,] solutionMap;

    public Solution(int nodes, List<Tuple<int,int,string>> progress, List<char> route, int steps, System.Diagnostics.Stopwatch executionTime, char[,] map){
        this.nodes = nodes;
        this.progress = progress;
        this.route = route;
        this.steps = steps;
        this.executionTime = executionTime;
        this.solutionMap = map;
    }

    public int getNodes(){
        return this.nodes;
    }

    public List<Tuple<int,int,string>> getProgress(){
        return this.progress;
    }

    public List<char> getRoute(){
        return this.route;
    }

    public int getSteps(){
        return this.steps;
    }

    public System.Diagnostics.Stopwatch getExecutionTime(){
        return this.executionTime;
    }

    public char[,] getSolutionMap(){
        return this.solutionMap;
    }
}