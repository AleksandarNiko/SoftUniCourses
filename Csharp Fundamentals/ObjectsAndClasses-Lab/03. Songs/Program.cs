namespace _03._Songs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfSongs=int.Parse(Console.ReadLine());
            List<Song> playlist = new List<Song>();
            for (int i = 0; i < numOfSongs; i++)
            {
                string[] data = Console.ReadLine().Split("_");
                string typeList = data[0];
                string name = data[1];
                string time = data[2];
                Song song = new Song
                {
                    TypeList = typeList,
                    Name = name,
                    Time = time
                };
                playlist.Add(song);
            }
            string typelist = Console.ReadLine();
            if(typelist =="all")
            {
                foreach (Song song in playlist)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                foreach (Song song in playlist)
                {
                    if( song.TypeList==typelist)
                    {
                        Console.WriteLine( song.Name );
                    }
                }
            }
                }
    }
    public class Song
    {
        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
    }
}
