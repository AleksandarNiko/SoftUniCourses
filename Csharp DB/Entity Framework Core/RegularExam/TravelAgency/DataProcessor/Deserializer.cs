using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using TravelAgency.Data;
using TravelAgency.Data.Models;
using TravelAgency.DataProcessor.ImportDtos;
using TravelAgency.Helpers;

namespace TravelAgency.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format!";
        private const string DuplicationDataMessage = "Error! Data duplicated.";
        private const string SuccessfullyImportedCustomer = "Successfully imported customer - {0}";
        private const string SuccessfullyImportedBooking = "Successfully imported booking. TourPackage: {0}, Date: {1}";

        public static string ImportCustomers(TravelAgencyContext context, string xmlString)
        {
            ImportCustomerDto[] customerDtos= XmlSerializationHelper.Deserialize<ImportCustomerDto[]>(xmlString,"Customers");

            StringBuilder sb= new StringBuilder();
            List<Customer> customers = new List<Customer>();

            foreach(var customerDto in customerDtos ) 
            {
                if (!IsValid(customerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Customer customer = new Customer()
                {
                    FullName = customerDto.FullName,
                    Email = customerDto.Email,
                    PhoneNumber = customerDto.PhoneNumber,
                };

                if (customers.Any(c => c.FullName == customer.FullName 
                || c.PhoneNumber == customer.PhoneNumber
                || c.Email == customer.Email)
                    )
                {
                    sb.AppendLine(DuplicationDataMessage);
                    continue;
                }

               
                customers.Add(customer);
                sb.AppendLine(string.Format(SuccessfullyImportedCustomer, customer.FullName));
            }
            context.Customers.AddRange(customers);
            context.SaveChanges();
            return sb.ToString();

        }

        public static string ImportBookings(TravelAgencyContext context, string jsonString)
        {
            var bookingDtos = JsonConvert.DeserializeObject<ImportBookingDto[]>(jsonString);

            var bookings = new List<Booking>();
            StringBuilder sb = new StringBuilder();

            foreach (var bookingDto in bookingDtos!)
            {
                if (!IsValid(bookingDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Customer custToImp=context.Customers
                    .Where(c=>c.FullName==bookingDto.CustomerName)
                    .FirstOrDefault()!;

                TourPackage tourPackageToImp = context.TourPackages
                    .Where(tp => tp.PackageName == bookingDto.TourPackageName)
                    .FirstOrDefault()!;

                DateTime bookingDate;
                bool isValidDate = DateTime.TryParseExact(bookingDto.BookingDate, "yyyy-MM-dd", 
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out bookingDate);

                if (!isValidDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Booking booking = new Booking()
                {
                    Customer = custToImp,
                    TourPackage = tourPackageToImp,
                    BookingDate = bookingDate,
                };

                bookings.Add(booking);
                sb.AppendLine(string.Format(SuccessfullyImportedBooking, 
                    bookingDto.TourPackageName, bookingDate.ToString("yyyy-MM-dd")));
            }

            context.Bookings.AddRange(bookings);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validateContext, validationResults, true);

            foreach (var validationResult in validationResults)
            {
                string currValidationMessage = validationResult.ErrorMessage!;
            }

            return isValid;
        }
    }
}
