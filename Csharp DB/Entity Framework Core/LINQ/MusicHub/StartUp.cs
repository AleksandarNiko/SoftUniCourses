using Microsoft.EntityFrameworkCore.Internal;
using MusicHub.Data;
using MusicHub.Initializer;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace MusicHub
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            MusicHubDbContext hub=new MusicHubDbContext();

            DbInitializer.ResetDatabase(hub);

            Console.WriteLine(ExportSongsAboveDuration(hub,4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context,int producerId)
        {
            var albums = context.Albums
                .Where(a => a.ProducerId.HasValue
                && a.ProducerId == producerId)
                .ToList()
                .OrderByDescending(a=>a.Price)
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy"),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs.Select(s => new
                    {
                        SongName = s.Name,
                        Price = s.Price.ToString("f2"),
                        WriterName = s.Writer.Name
                    })
                    .OrderByDescending(s => s.SongName)
                    .ThenBy(s => s.WriterName)
                    .ToList(),
                    TotalPrice = a.Price.ToString("f2")
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var a in albums)
            {
                sb.AppendLine($"-AlbumName: {a.AlbumName}")
                   .AppendLine($"-ReleaseDate: {a.ReleaseDate}")
                   .AppendLine($"-ProducerName: {a.ProducerName}")
                   .AppendLine($"-Songs:");

                int songNumber = 1;

                foreach (var s in a.Songs)
                {
                    sb.AppendLine($"---#{songNumber}")
                        .AppendLine($"---SongName: {s.SongName}")
                        .AppendLine($"---Price: {s.Price}")
                        .AppendLine($"---Writer: {s.WriterName}");

                    songNumber += 1;
                }

                sb.AppendLine($"-AlbumPrice: {a.TotalPrice}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    SongName = s.Name,
                    PerformerFullName = s.SongPerformers
                        .Select(p => $"{p.Performer.FirstName} {p.Performer.LastName}")
                        .OrderBy(p => p)
                        .ToList(),
                    WriterName = s.Writer.Name,
                    AlbumProducer = s.Album!.Producer!.Name,
                    Duration = s.Duration.ToString("c")
                })
                .OrderBy(s=>s.SongName)
                .ThenBy(s=>s.WriterName)
                .ToList();

            StringBuilder sb = new StringBuilder();
            int songNumber=1;

            foreach (var s in songs)
            {
                sb.AppendLine($"-Song #{songNumber}")
                    .AppendLine($"---SongName: {s.SongName}")
                    .AppendLine($"---Writer: {s.WriterName}");

                foreach (var p in s.PerformerFullName)
                {
                    sb.AppendLine($"---Performer: {p}");
                }

                sb.AppendLine($"---AlbumProducer: {s.AlbumProducer}")
                    .AppendLine($"---Duration: {s.Duration}");

                songNumber++;
            }

            return sb.ToString().TrimEnd();
        }
    }
}
