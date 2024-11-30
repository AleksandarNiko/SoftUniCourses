namespace Boardgames.DataProcessor
{
    using Boardgames.Data;
    using Boardgames.DataProcessor.ExportDto;
    using Boardgames.Helper;
    using Castle.Components.DictionaryAdapter;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            var creators=context.Creators
                .Where(c=>c.Boardgames.Any())
                .Select(c=>new ExportCreatorDto()
                {
                    CreatorName =$"{c.FirstName} {c.LastName}",
                    BoardgamesCount=c.Boardgames.Count(),
                    Boardgames=c.Boardgames.Select(bg=>new ExportBoardgameDto()
                    {
                        BoardgameName=bg.Name,
                        BoardgameYearPublished=bg.YearPublished
                    })
                    .OrderBy(bg=>bg.BoardgameName)
                    .ToArray()
                })
                .OrderByDescending(c=>c.Boardgames.Count())
                .ThenBy(c=>c.CreatorName)
                .ToArray();

            return XmlSerializationHelper.Serialize(creators, "Creators", true);
        }

        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {
            var sellers = context.Sellers
                .Where(s => s.BoardgamesSellers
                .Any(bs => bs.Boardgame.YearPublished >= year && bs.Boardgame.Rating <= rating))
                .Select(s => new
                {
                    s.Name,
                    s.Website,
                    Boardgames = s.BoardgamesSellers
                    .Where(bgs => bgs.Boardgame.YearPublished >= year &&
                                      bgs.Boardgame.Rating <= rating)
                    .Select(b => new
                    {
                        Name = b.Boardgame.Name,
                        Rating = b.Boardgame.Rating,
                        Mechanics = b.Boardgame.Mechanics,
                        Category = b.Boardgame.CategoryType.ToString()
                    })
                    .OrderByDescending(bg => bg.Rating)
                    .ThenBy(bg => bg.Name)
                    .ToArray()
                })
                .OrderByDescending(s => s.Boardgames.Length)
                .ThenBy(s => s.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(sellers,Formatting.Indented);
        }
    }
}