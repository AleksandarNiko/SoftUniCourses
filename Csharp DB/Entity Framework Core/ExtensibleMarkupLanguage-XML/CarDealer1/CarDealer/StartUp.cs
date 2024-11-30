using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Castle.Core.Resource;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext carDealerContext = new CarDealerContext();

            //09
            //string suppliersText = File.ReadAllText("../../../Datasets/suppliers.xml");
            //Console.WriteLine(ImportSuppliers(carDealerContext,suppliersText));

            //10
            //string partsText = File.ReadAllText("../../../Datasets/parts.xml");
            // Console.WriteLine(ImportParts(carDealerContext,partsText));

            //11
            // string carsText = File.ReadAllText("../../../Datasets/cars.xml");
            //Console.WriteLine(ImportCars(carDealerContext,carsText));

            //12
            //string customersText = File.ReadAllText("../../../Datasets/customers.xml");
            //Console.WriteLine(ImportCustomers(carDealerContext,customersText));

            //13
            //string salesText = File.ReadAllText("../../../Datasets/sales.xml");
            //Console.WriteLine(ImportSales(carDealerContext,salesText));

            //14
            //Console.WriteLine(GetCarsWithDistance(carDealerContext));

            //15
            //Console.WriteLine(GetCarsFromMakeBmw(carDealerContext));

            //16
            //Console.WriteLine(GetLocalSuppliers(carDealerContext));

            //17
            //Console.WriteLine(GetCarsWithTheirListOfParts(carDealerContext));

            //18
            //Console.WriteLine(GetTotalSalesByCustomer(carDealerContext));

            //19
            Console.WriteLine(GetSalesWithAppliedDiscount(carDealerContext));
        }

        public static string ImportSuppliers(CarDealerContext context,string inputXml)
        {
            XmlSerializer xmlSerializer =new XmlSerializer(typeof(ImportSupplierDto[]),
               new XmlRootAttribute("Suppliers"));

            ImportSupplierDto[] supplierDtos;
            
            using (var reader=new StringReader(inputXml))
            {
                supplierDtos = (ImportSupplierDto[])xmlSerializer.Deserialize(reader);
            }

            Supplier[] suppliers = supplierDtos
                .Select(x => new Supplier()
                {
                    Name= x.Name,
                    IsImporter= x.IsImporter,
                }).ToArray();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}";
        }

        public static string ImportParts(CarDealerContext context,string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPartDto[]),
                new XmlRootAttribute("Parts"));

            ImportPartDto[] partDtos;

            using ( var reader=new StringReader(inputXml))
            {
                partDtos = (ImportPartDto[])xmlSerializer.Deserialize(reader);
            }

            var suppliersIds=context.Suppliers
                .Select(s=>s.Id)
                .ToArray();

            var partsWithValidSuppliers=partDtos
                .Where(p=>suppliersIds.Contains(p.SupplierId))
                .ToArray();

            Part[]parts= partsWithValidSuppliers.Select(partDtos => new Part()
            {
                Name= partDtos.Name,
                Price= partDtos.Price,
                Quantity = partDtos.Quantity,
                SupplierId= partDtos.SupplierId,
            }).ToArray() ;

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}";
        }

        public static string ImportCars(CarDealerContext context,string inputXml) 
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarImportDto[]),
                new XmlRootAttribute("Cars"));

            CarImportDto[] carImportDtos;
            using (StringReader reader = new StringReader(inputXml))
            {
                carImportDtos = (CarImportDto[])xmlSerializer.Deserialize(reader);
            };

            List<Car> cars = new List<Car>();

            foreach (var dto in carImportDtos)
            {
                Car car = new Car()
                {
                    Make = dto.Make,
                    Model = dto.Model,
                    TraveledDistance = dto.TraveledDistance
                };

                int[] carPartsId = dto.PartIds
                    .Select(p => p.Id)
                    .Distinct()
                    .ToArray();

                var carParts = new List<PartCar>();

                foreach (var id in carPartsId)
                {
                    carParts.Add(new PartCar()
                    {
                        Car = car,
                        PartId = id
                    });
                }

                car.PartsCars = carParts;
                cars.Add(car);
            }
            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        public static string ImportCustomers(CarDealerContext context,string inputXml)
        {
            XmlSerializer xmlSerializer =new XmlSerializer(typeof(ImportCustomerDto[]),
               new XmlRootAttribute("Customers"));

            ImportCustomerDto[] customerDtos;

            using (var reader = new StringReader(inputXml))
            {
                customerDtos = (ImportCustomerDto[])xmlSerializer.Deserialize(reader);
            }

            Customer[] customers = customerDtos
                .Select(customerD => new Customer()
                {
                    Name = customerD.Name,
                    BirthDate = customerD.BirthDate,
                    IsYoungDriver = customerD.IsYoungDriver
                }).ToArray();

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}";
        }

        public static string ImportSales(CarDealerContext context,string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SaleImportDto[]),
                new XmlRootAttribute("Sales"));

            SaleImportDto[] salesDtos;

            using ( var reader = new StringReader(inputXml))
            {
                salesDtos = (SaleImportDto[])xmlSerializer.Deserialize(reader);
            }

            int[]carIds=context.Cars
                .Select(c=>c.Id).ToArray();

            var validSales=salesDtos
                .Where(vs=>carIds.Contains(vs.CarId))
                .ToArray();

            Sale[] sales= validSales
                .Select(salesD => new Sale()
                {
                    CarId = salesD.CarId,
                    CustomerId = salesD.CustomerId,
                    Discount = salesD.Discount
                }).ToArray();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c=>new ExportCarsWithDistanceDto()
                {
                    Make=c.Make,
                    Model=c.Model,
                    TraveledDistance=c.TraveledDistance
                })
                .Where(c => c.TraveledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToArray();

            return SerializeToXml(cars, "cars");
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c=>c.Make=="BMW")
                .Select(c=>new CarsBmwExportDto()
                {
                    Id=c.Id,
                    Model=c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .OrderBy(c=>c.Model)
                .ThenByDescending(c=>c.TraveledDistance)    
                .ToArray();

            return SerializeToXml(cars,"cars",true);
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new LocalSuppliersExportDto()
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            return SerializeToXml(suppliers, "suppliers", true);
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars=context.Cars
                .OrderByDescending(c=>c.TraveledDistance)
                .ThenBy(c=>c.Model)
                .Take(5)
                .Select(c=>new ExportCarsWithTheirListOfPartsDto()
                {
                    Make=c.Make,
                    Model=c.Model,
                    TraveledDistance =c.TraveledDistance,
                    Parts=c.PartsCars
                    .OrderByDescending(p=>p.Part.Price)
                    .Select(pc=>new PartsForCarsDto()
                    {
                        Name=pc.Part.Name,
                        Price=pc.Part.Price,
                    }).ToArray()
                }).ToArray();

            return SerializeToXml(cars,"cars",true);
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales.Select(s => new
                    {
                        Prices = c.IsYoungDriver
                        ? s.Car.PartsCars.Sum(pc => Math.Round((double)pc.Part.Price * 0.95, 2))
                        : s.Car.PartsCars.Sum(pc => (double)pc.Part.Price)
                    }).ToArray()
                }).ToArray();

            var customersSales=customers
                .OrderByDescending(x=>x.SpentMoney.Sum(s=>s.Prices))
                .Select(a=>new ExportTotalSalesByCustomerDto()
                {
                    FullName = a.FullName,
                    BoughtCars = a.BoughtCars,
                    SpentMoney = a.SpentMoney.Sum(b => (decimal)b.Prices)
                })
                .ToArray();

            return SerializeToXml(customersSales, "customers");
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new SaleWithDiscount()
                {
                    Car = new CarDto()
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TraveledDistance = s.Car.TraveledDistance
                    },
                    Discount = (int)s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartsCars
                        .Sum(pc => pc.Part.Price),
                    PriceWithDiscount = Math.Round(
                        (double)(s.Car.PartsCars.Sum(p => p.Part.Price)
                                 * (1 - (s.Discount / 100))), 4)
                }).ToArray();

            return SerializeToXml(sales, "sales");
        }

        private static string SerializeToXml<T>(T obj, string rootName, bool omitXmlDeclaration = false)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj), "Object to serialize cannot be null.");

            if (string.IsNullOrEmpty(rootName))
                throw new ArgumentNullException(nameof(rootName), "Root name cannot be null or empty.");

            try
            {
                XmlRootAttribute xmlRoot = new(rootName);
                XmlSerializer xmlSerializer = new(typeof(T), xmlRoot);

                XmlSerializerNamespaces namespaces = new();
                namespaces.Add(string.Empty, string.Empty);

                XmlWriterSettings settings = new()
                {
                    OmitXmlDeclaration = omitXmlDeclaration,
                    Indent = true
                };

                StringBuilder sb = new();
                using var stringWriter = new StringWriter(sb);
                using var xmlWriter = XmlWriter.Create(stringWriter, settings);

                xmlSerializer.Serialize(xmlWriter, obj, namespaces);
                return sb.ToString().TrimEnd();
            }
            catch (InvalidOperationException ex)
            {
                Debug.WriteLine($"Serialization error: {ex.Message}");
                throw new InvalidOperationException($"Serializing {typeof(T)} failed.", ex);
            }
        }
    }
}