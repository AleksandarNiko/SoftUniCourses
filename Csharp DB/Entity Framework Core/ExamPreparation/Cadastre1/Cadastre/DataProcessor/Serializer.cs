using Cadastre.Data;
using Cadastre.DataProcessor;
using Cadastre.Helpers;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Cadastre.DataProcessor
{
    public class Serializer
    {
        public static string ExportPropertiesWithOwners(CadastreContext dbContext)
        {
            var properties = dbContext.Properties
                .Where(p => p.DateOfAcquisition >= new DateTime(2000, 1, 1))
                .OrderByDescending(p => p.DateOfAcquisition)
                .ThenBy(p => p.PropertyIdentifier)
                .Select(p => new
                {
                    PropertyIdentifier = p.PropertyIdentifier,
                    Area = p.Area,
                    Address = p.Address,
                    DateOfAcquisition = p.DateOfAcquisition.ToString("dd/MM/yyyy"),
                    Owners = p.PropertiesCitizens
                    .Select(pc => pc.Citizen)
                    .OrderBy(c => c.LastName)
                    .Select(c => new
                    {
                        LastName = c.LastName,
                        MaritalStatus = c.MaritalStatus.ToString(),
                    })
                    .ToArray()
                })
                .ToArray();

            return JsonConvert.SerializeObject(properties, Formatting.Indented);
        }

        public static string ExportFilteredPropertiesWithDistrict(CadastreContext dbContext)
        {
            var properties = dbContext.Properties
                .Where(p => p.Area >= 100)
                .OrderByDescending(p => p.Area)
                .OrderBy(p => p.DateOfAcquisition)
                .Select(p => new
                {
                    p.District.PostalCode,
                    p.PropertyIdentifier,
                    p.Area,
                    DateOfAcquisition = p.DateOfAcquisition.ToString("dd/MM/yyyy"),
                })              
                .ToArray();

            return XmlSerializationHelper.Serialize(properties, "Properies", true);
        }
    }
}
