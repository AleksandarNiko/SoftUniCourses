using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Transactions;

namespace _03._The_Pianist
{ 
    class Piece
    {
        public Piece(string pieceName,string composer,string key) 
        { 
            PieceName= pieceName;
            Composer= composer;
            Key= key;
        }
        public  string PieceName { get; set; }
        public  string Composer { get; set; }
        public  string Key { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Piece> parts = new Dictionary<string, Piece>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split("|").ToArray();

                string pieceName = input[0];
                string composer = input[1];
                string key = input[2];
                Piece piece=new Piece(pieceName, composer, key);
                if (!parts.ContainsKey(pieceName))
                {
                    parts.Add(pieceName, piece);
                }

                parts[pieceName].Composer = composer;
                parts[pieceName].Key = key;
            }
            string inp;
            while ((inp=Console.ReadLine())!="Stop")
            {
                string[] data = inp.Split("|").ToArray();
                string command = data[0];

                if (command=="Add")
                {
                    string pieceName = data[1];
                    string composer = data[2];
                    string key = data[3];

                    if (parts.ContainsKey(pieceName))
                    {
                        Console.WriteLine($"{pieceName} is already in the collection!");
                        
                    }
                    else
                    {
                        Piece piece = new Piece(pieceName, composer, key);
                        parts.Add(pieceName, piece);
                        Console.WriteLine($"{pieceName} by {composer} in {key} added to the collection!");
                    }
                }
                else if (command=="Remove")
                {
                    string piece = data[1];

                    if (!parts.ContainsKey(piece))
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                        
                    }
                    else
                    {
                        parts.Remove(piece);
                        Console.WriteLine($"Successfully removed {piece}!");
                    }
                }
                else if (command.Equals("ChangeKey"))
                {
                    string piece = data[1];
                    string newKey = data[2];

                    if (parts.ContainsKey(piece))
                    {
                        parts[piece].Key = newKey;
                        Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                        
                    }
                    else {
                       
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                        
                    }
                }
            }

            foreach (var piece in parts)
            {
                Console.WriteLine($"{piece.Value.PieceName} -> Composer: {piece.Value.Composer}, Key: {piece.Value.Key}");
            }
        }
    }
}
/*
4
Eine kleine Nachtmusik|Mozart|G Major
La Campanella|Liszt|G# Minor
The Marriage of Figaro|Mozart|G Major
Hungarian Dance No.5|Brahms|G Minor
Add|Spring|Vivaldi|E Major
Remove|The Marriage of Figaro
Remove|Turkish March
ChangeKey|Spring|C Major
Add|Nocturne|Chopin|C# Minor
Stop
   */