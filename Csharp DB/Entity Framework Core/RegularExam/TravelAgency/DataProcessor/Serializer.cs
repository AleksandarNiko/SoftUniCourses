using Newtonsoft.Json;
using System.Text.Json;
using System.Xml.Linq;
using TravelAgency.Data;
using TravelAgency.DataProcessor.ExportDtos;
using TravelAgency.Helpers;

namespace TravelAgency.DataProcessor
{
    public class Serializer
    {
        public static string ExportGuidesWithSpanishLanguageWithAllTheirTourPackages(TravelAgencyContext context)
        {
            var guides = context.Guides
                .Where(g => g.Language == Data.Models.Enums.Language.Spanish)
                .OrderByDescending(g => g.TourPackagesGuides.Count())
                .ThenBy(g => g.FullName)
                .Select(g => new ExportGuideDto()
                {
                    FullName = g.FullName,
                    TourPackages = g.TourPackagesGuides.Select(tp => new ExportTourPackage()
                    {
                        Name = tp.TourPackage.PackageName,
                        Description = tp.TourPackage.Description,
                        Price = tp.TourPackage.Price,
                    })
                    .OrderByDescending(t => t.Price)
                    .ThenBy(x => x.Name)
                    .ToArray()
                })
                .ToArray();


            return XmlSerializationHelper.Serialize(guides,"Guides");
        }

        public static string ExportCustomersThatHaveBookedHorseRidingTourPackage(TravelAgencyContext context)
        {
            var filteredCustomers = context.Customers
           .Where(c => c.Bookings.Any(b => b.TourPackage.PackageName == "Horse Riding Tour"))
           .ToArray()
           .Select(c => new
           {
               c.FullName,
               c.PhoneNumber,
               Bookings = c.Bookings
                   .Where(b => b.TourPackage.PackageName == "Horse Riding Tour")
                   .Select(b => new
                   {
                       TourPackageName = b.TourPackage.PackageName,
                       Date = b.BookingDate.ToString("yyyy-MM-dd")
                   })
                   .OrderBy(b => b.Date)
           })
           .OrderByDescending(x => x.Bookings.Count())
           .ThenBy(x => x.FullName)
           .ToArray();


            return JsonConvert.SerializeObject(filteredCustomers,Formatting.Indented);
        }
    }
}
