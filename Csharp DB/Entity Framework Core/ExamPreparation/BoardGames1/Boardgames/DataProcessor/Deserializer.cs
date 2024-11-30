namespace Boardgames.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;
    using Boardgames.Data;
    using Boardgames.Data.Models;
    using Boardgames.Data.Models.Enums;
    using Boardgames.DataProcessor.ImportDto;
    using Boardgames.Helper;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
            = "Successfully imported seller - {0} with {1} boardgames.";

        public static string ImportCreators(BoardgamesContext context, string xmlString)
        {
            var creatorsDtos = XmlSerializationHelper.Deserialize<ImportCreator[]>(xmlString,"Creators");

            StringBuilder sb = new StringBuilder();
            List<Creator> creators = new List<Creator>();

            foreach (var creatorDto in creatorsDtos)
            {
                if (!IsValid(creatorDto))
                {
                    sb.AppendLine(ErrorMessage); 
                    continue;
                }

                Creator creator = new Creator()
                {
                    FirstName = creatorDto.FirstName,
                    LastName = creatorDto.LastName,
                };

                foreach (var gameDto in creatorDto.Boardgames)
                {
                    if(!IsValid(gameDto)) 
                    { 
                        sb.AppendLine(ErrorMessage); 
                        continue; 
                    }

                    creator.Boardgames.Add(new Boardgame()
                    {
                        Name= gameDto.Name,
                        Rating = gameDto.Rating,
                        YearPublished = gameDto.YearPublished,
                        CategoryType =(CategoryType)gameDto.CategoryType,
                        Mechanics = gameDto.Mechanics,
                    });
                }

                creators.Add(creator);
                sb.AppendLine(string.Format(SuccessfullyImportedCreator,
                    creator.FirstName,creator.LastName,creator.Boardgames.Count));
            }

            context.Creators.AddRange(creators);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportSellers(BoardgamesContext context, string jsonString)
        {
            var sellersDtos = JsonConvert.DeserializeObject<ImportSellerDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();
            List<Seller> sellers= new List<Seller>();

            var boardgameIds = context.Boardgames
                .Select(x => x.Id)
                .ToArray();

            foreach (var sellerDto in sellersDtos)
            {
                if(!IsValid(sellerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Seller seller = new Seller()
                {
                    Name = sellerDto.Name,
                    Address = sellerDto.Address,
                    Country = sellerDto.Country,
                    Website = sellerDto.Website,
                };

                foreach (var id in sellerDto.BoardgamesId.Distinct())
                {
                    if (!boardgameIds.Contains(id))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    BoardgameSeller boardgameSeller = new BoardgameSeller()
                    {
                        Seller = seller,
                        BoardgameId = id,
                    };

                    seller.BoardgamesSellers.Add(boardgameSeller);
                }
                sellers.Add(seller);
                sb.AppendLine(string.Format(SuccessfullyImportedSeller,seller.Name,seller.BoardgamesSellers.Count));
            }

            context.Sellers.AddRange(sellers);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
