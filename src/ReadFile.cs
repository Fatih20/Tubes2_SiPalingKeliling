using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tubes2Stima
{
    internal class ReadFile
    {
        public static Tuple<char[,], int> readFile(string pathfile)
        {
            // Function to read map from file

            // Try to read file
            string[] lines = File.ReadAllLines("../../../test/" + pathfile);

            // Remove spaces from each line
            for (int idx = 0; idx < lines.Count(); idx++)
            {
                lines[idx] = lines[idx].Replace(' '.ToString(), String.Empty);
            }

            // Validation file
            // 1. Empty File
            int M = lines.Length;
            if (M == 0)
            {
                throw new Exception("File kosong!");
            }
            int N = lines[0].Length;

            // Initialize variable and array
            char[,] map = new Char[M, N];
            int i = 0;
            int treasures = 0;
            int K = 0;

            // Loop through all lines
            foreach (string line in lines)
            {
                if (line.Length != N)
                {
                    throw new Exception("Ukuran bukan segi empat!");
                }
                for (int j = 0; j < N; j++)
                {
                    // 3. Unknown character
                    if (line[j] != 'K' && line[j] != 'R' && line[j] != 'T' && line[j] != 'X')
                    {
                        throw new Exception("Karakter tidak sesuai isi dari peta!");
                    }
                    else
                    {
                        map[i, j] = line[j];
                        if (line[j] == 'T') treasures++;
                        else if (line[j] == 'K') K++;
                    }
                }
                i++;
            }

            if(K == 0)
            {
                throw new Exception("Tidak ada starting point pada peta!");
            } else if (K > 1)
            {
                throw new Exception("Starting point terdapat lebih dari satu!");
            } else if (treasures == 0)
            {
                throw new Exception("Tidak ada treasure pada peta!");
            }

            // Return map
            return new Tuple<char[,], int>(map, treasures);
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
}
