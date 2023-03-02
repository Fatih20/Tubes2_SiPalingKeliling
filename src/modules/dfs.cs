using System;

class Program {
    static void dfs(char[,] map, int x, int y, bool[,] isVisited, ref int count){
        int size = map.GetLength(0);
        if(x >= 0 && x < size && y >= 0 && y < size){
            if(isVisited[x,y] || map[x,y] == '#'){
                return;
            } else {
                isVisited[x,y] = true;
                if(map[x,y] == 'B'){
                    count++;
                }
                dfs(map, x-1, y, isVisited, ref count);
                dfs(map, x+1, y, isVisited, ref count);
                dfs(map, x, y-1, isVisited, ref count);
                dfs(map, x, y+1, isVisited, ref count);
                return;
            }
        } else {
            return;
        }
    }

    static void printMap(char[,] map){
        int size = map.GetLength(0);
        for(int i = 0; i < size; i++){
            for(int j = 0; j < size; j++){
                Console.Write(map[i,j]);
            }
            Console.WriteLine();
        }
    }

    static void Main(string[] args){
        const int N = 4;
        char[,] map = {{'S', '#', '#', 'B'},
                       {'B', 'B', '#', '#'},
                       {'#', 'B', '#', '#'},
                       {'#', '#', '#', 'B'}};
        bool[,] isVisited = new bool[N, N];
        for(int i = 0; i < N; i++){
            for(int j = 0; j < N; j++){
                isVisited[i,j] = false;
            }
        }
        int count = 0;
        dfs(map, 0, 0, isVisited, ref count);
        printMap(map);
        Console.WriteLine($"Terdapat {count} bomb yang dapat dilalui dari S");
    }
}