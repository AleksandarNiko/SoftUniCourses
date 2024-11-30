using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Castle.Core.Resource;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            using CarDealerContext carDealerContext = new CarDealerContext();

            //09
            // string suppliersText = File.ReadAllText("../../../Datasets/suppliers.json");
            // Console.WriteLine(ImportSuppliers(carDealerContext,suppliersText));

            //10
            //  string partsText = File.ReadAllText("../../../Datasets/parts.json");
            // Console.WriteLine(ImportParts(carDealerContext,partsText));

            //11
            // string carsText = File.ReadAllText("../../../Datasets/cars.json");
            //  Console.WriteLine(ImportCars(carDealerContext,carsText));

            //12
            // string customersText = File.ReadAllText("../../../Datasets/customers.json");
            // Console.WriteLine(ImportCustomers(carDealerContext,customersText));

            //13
            //string salesText = File.ReadAllText("../../../Datasets/sales.json");
            //Console.WriteLine(ImportSales(carDealerContext,salesText));

            //14
            //Console.WriteLine(GetOrderedCustomers(carDealerContext));

            //15
            // Console.WriteLine(GetCarsFromMakeToyota(carDealerContext));

            //16
            //Console.WriteLine(GetLocalSuppliers(carDealerContext));

            //17
            // Console.WriteLine(GetCarsWithTheirListOfParts(carDealerContext));

            //18
            //Console.WriteLine(GetTotalSalesByCustomer(carDealerContext));

            //19
            //Console.WriteLine(GetSalesWithAppliedDiscount(carDealerContext));
        }
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers=JsonConvert.DeserializeObject<List<Supplier>>(inputJson);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";

        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts=JsonConvert.DeserializeObject<List<Part>>(inputJson);

            var validSuppliers=context.Suppliers
                .Select(x=>x.Id)
                .ToList();

            var partsWithValidSuppliers=parts
                .Where(p=>validSuppliers.Contains(p.SupplierId))
                .ToList();

            context.Parts.AddRange(partsWithValidSuppliers);
            context.SaveChanges();

            return $"Successfully imported {partsWithValidSuppliers.Count}.";
        }

        public static string ImportCars(CarDealerContext context,string inputJson)
        {
            var carsDtos=JsonConvert.DeserializeObject<List<ImportCarDto>>(inputJson);

            var cars = new HashSet<Car>();
            var partsCars=new HashSet<PartCar>();

            foreach (var carDto in carsDtos)
            {
                var newCar = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TraveledDistance = carDto.TraveledDistance
                };

                cars.Add(newCar);

                foreach (var partId in carDto.PartsId.Distinct())
                {
                    partsCars.Add(new PartCar()
                    {
                        Car = newCar,
                        PartId = partId
                    });
                }
            }
            context.Cars.AddRange(cars);
            context.PartsCars.AddRange(partsCars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
       {
            var customers=JsonConvert.DeserializeObject<List<Customer>>(inputJson);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales=JsonConvert.DeserializeObject<List<Sale>>(inputJson);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
               .OrderBy(c => c.BirthDate)
               .ThenBy(c => c.IsYoungDriver)
               .Select(c => new
               {
                   c.Name,
                   BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
                   c.IsYoungDriver
               })
               .ToList();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c=>c.Make =="Toyota")
                .Select(c => new
                {
                    c.Id,
                    c.Make,
                    c.Model,
                    c.TraveledDistance
                })
                .OrderBy(c=>c.Model)
                .ThenByDescending (c=>c.TraveledDistance) 
                .ToList();

            return JsonConvert.SerializeObject(cars,Formatting.Indented);
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToList();

            return JsonConvert.SerializeObject(suppliers,Formatting.Indented);
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    car=new
                    {
                        c.Make,
                        c.Model,
                        c.TraveledDistance
                    },
                    parts = c.PartsCars.Select(p => new
                    {
                        p.Part.Name,
                        Price=p.Part.Price.ToString("f2")
                    })
                })
                .ToList();

            return JsonConvert.SerializeObject(cars ,Formatting.Indented);
                
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Count>0)
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count,
                    spentMoney = c.Sales
                    .SelectMany(s => s.Car.PartsCars.Select(pc => pc.Part.Price))
                    .Sum()
                })
                .OrderByDescending(c => c.spentMoney)
                .ThenByDescending(c => c.boughtCars)
                .ToList();

            return SerializeObjectWithJsonSettings (customers);
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Take(10)
                .Select(s => new
                {
                    car = new
                    {
                        s.Car.Make,
                        s.Car.Model,
                        s.Car.TraveledDistance
                    },
                    customerName = s.Customer.Name,
                    discount = s.Discount.ToString("f2"),
                    price = s.Car.PartsCars.Sum(cp => cp.Part.Price).ToString("f2"),
                    priceWithDiscount = (s.Car.PartsCars.Sum(pc => pc.Part.Price) * ((100 - s.Discount) / 100)).ToString("f2")
                })
                .ToList();

            return JsonConvert.SerializeObject(sales,Formatting.Indented);
        }

        private static string SerializeObjectWithJsonSettings(object obj)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented
            };
            return JsonConvert.SerializeObject(obj, settings);
        }
    }
}