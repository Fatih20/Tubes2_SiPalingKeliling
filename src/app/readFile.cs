public class ReadFile {
    public static char[,] readFile(string pathfile){
        // Function to read map from file

        // Try to read file
        string[] lines = System.IO.File.ReadAllLines(pathfile);

        // Validation file
        // 1. Empty File
        int size = lines.Length;
        if(size== 0){
            throw new Exception("File kosong!");
        }

        // Initialize variable and array
        char[,] map = new Char[size, size];
        int i = 0;

        // Loop through all lines
        foreach(string line in lines){
            // 2. Shape
            if(line.Length != size){
                throw new Exception("Ukuran tidak berbentuk persegi!");
            } else {
                for(int j = 0; j < line.Length; j++){
                    // 3. Unknown character
                    if(line[j] != 'K' && line[j] != 'R' && line[j] != 'T' && line[j] != 'X'){
                        throw new Exception("Karakter tidak sesuai isi dari peta!");
                    } else {
                        map[i,j] = line[j];
                    }
                }
                i++;
            }
        }

        // Return map
        return map;
    }

    // Example using try and catch to handle errors
    /*
        static void Main(string[] args){
            string pathfile = "./config/peta.txt";
            try {
                char[,] map = readFile(pathfile);
                DFS.printMap(map);
            } catch (FileNotFoundException){
                Console.WriteLine("File tidak ditemukan!");
            } catch (Exception e2){
                Console.WriteLine(e2.Message);
            }
        }
    */
}