class MainProgram {
    static void Main(string[] args){
        // Try to read file
        string pathfile = "./config/peta.txt";
        try {
            Graph TreasureMap = new Graph(pathfile);

            // Print map
            Console.WriteLine("\nPeta Harta Karun");
            Helper.printMap(TreasureMap.getMap(), TreasureMap.getM(), TreasureMap.getN());

            // Solve
            Solution solution = TreasureMap.Solve(false, false);

            // Print solution
            Console.WriteLine("\nDENGAN BFS");

            // Output Peta
            Console.WriteLine("Peta Jalur Kemenangan");
            Helper.printMap(solution.getSolutionMap(), solution.getSolutionMap().GetLength(0), solution.getSolutionMap().GetLength(1));

            // Output Route
            List<char> route = solution.getRoute();
            Console.Write("\nRoute: ");
            for(int i = 0; i < route.Count; i++){
                if(i != route.Count - 1){
                    Console.Write(route.ElementAt(i) + " - ");
                } else {
                    Console.WriteLine(route.ElementAt(i));
                }
            }

            // Output Steps
            Console.WriteLine("Steps : " + solution.getSteps());

            // Output Nodes
            Console.WriteLine("Nodes : " + solution.getNodes());
            
            // Output Execution Time
            Console.WriteLine($"Execution Time: {solution.getExecutionTime().ElapsedMilliseconds} ms");
            
            // Output Progress
            Console.WriteLine("Urutan pengecekan : ");
            solution.getProgress().ForEach(coor => Console.WriteLine("(" + coor.Item1 + ", " + coor.Item2 + ")"));

        } catch (FileNotFoundException){
            Console.WriteLine("File tidak ditemukan!");
        } catch (Exception e2){
            if(e2.GetType() == typeof(System.IO.DirectoryNotFoundException)){
                Console.WriteLine("Directory file tidak ditemukan!");
            } else {
                Console.WriteLine(e2.Message);
            }
        }
    }
}