namespace Cadastre.DataProcessor
{
    using Cadastre.Data;
    using Cadastre.DataProcessor.ImportDtos;
    using System.ComponentModel.DataAnnotations;
    using Cadastre.Helpers;
    using System.Text;
    using Cadastre.Data.Models;
    using Cadastre.Data.Enumerations;
    using System.Globalization;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid Data!";
        private const string SuccessfullyImportedDistrict =
            "Successfully imported district - {0} with {1} properties.";
        private const string SuccessfullyImportedCitizen =
            "Succefully imported citizen - {0} {1} with {2} properties.";

        public static string ImportDistricts(CadastreContext dbContext, string xmlDocument)
        {
            var districtsDtos = XmlSerializationHelper.Deserialize<ImportDistrictDto[]>(xmlDocument, "Districts");

            StringBuilder sb = new StringBuilder();
            List<District> districts = new List<District>();

            foreach (var districtDto in  districtsDtos)
            {
                if (!IsValid(districtDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (dbContext.Districts.Any(d => d.Name == districtDto.Name))
                {
                    sb.AppendLine(ErrorMessage);
                }

                District district = new District()
                {
                    Name = districtDto.Name,
                    PostalCode = districtDto.PostalCode,
                    Region = (Region)Enum.Parse(typeof(Region), districtDto.Region)
                };

                foreach (var propertyDto in districtDto.Properties)
                {
                    if(!IsValid(propertyDto)) 
                    { 
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }


                    if (dbContext.Properties.Any(p => p.PropertyIdentifier == propertyDto.PropertyIdentifier) 
                        || district.Properties.Any(dp => dp.PropertyIdentifier == propertyDto.PropertyIdentifier))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (dbContext.Properties.Any(p => p.Address  == propertyDto.Address)
                       || district.Properties.Any(dp => dp.Address == propertyDto.Address))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Property property = new Property()
                    {
                        PropertyIdentifier = propertyDto.PropertyIdentifier,
                        Area = propertyDto.Area,
                        Details = propertyDto.Details,
                        Address = propertyDto.Address,
                        DateOfAcquisition = propertyDto.DateOfAcquisition,
                    };

                    district.Properties.Add(property);
                    sb.AppendLine(string.Format(SuccessfullyImportedDistrict, district.Name, district.Properties.Count));
                }
                dbContext.Districts.AddRange(districts);
                dbContext.SaveChanges();
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportCitizens(CadastreContext dbContext, string jsonDocument)
        {
            var citizensDtos = JsonConvert.DeserializeObject<ImportCitizenDto[]>(jsonDocument);

            StringBuilder sb=new StringBuilder();
            List<Citizen> citizens= new List<Citizen>();

            foreach (var citizenDto in citizensDtos)
            {
                if(!IsValid(citizenDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Citizen citizen = new Citizen()
                {
                    FirstName = citizenDto.FirstName,
                    LastName = citizenDto.LastName,
                    BirthDate = citizenDto.BirthDate,
                    MaritalStatus = (MaritalStatus)Enum.Parse(typeof(MaritalStatus), citizenDto.MaritalStatus),
                };

                foreach (var propId in citizenDto.Properties)
                {
                    PropertyCitizen propertyCitizen = new PropertyCitizen()
                    {
                        Citizen = citizen,
                        PropertyId = propId
                    };
                    citizen.PropertiesCitizens.Add(propertyCitizen);
                }
                citizens.Add(citizen);
                sb.AppendLine(string.Format(SuccessfullyImportedCitizen,
                    citizen.FirstName,citizen.LastName,citizen.PropertiesCitizens.Count));
            }
            dbContext.Citizens.AddRange(citizens);
            dbContext.SaveChanges();
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
