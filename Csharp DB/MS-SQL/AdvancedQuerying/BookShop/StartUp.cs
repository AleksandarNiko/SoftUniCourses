using BookShop.Data;
using BookShop.Models.Enums;
using System.Globalization;
using System.Linq;
using System.Text;

namespace BookShop
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            BookShopContext bookShopContext = new BookShopContext();
            Console.WriteLine(RemoveBooks(bookShopContext));
            // IncreasePrices(bookShopContext);
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            try
            {
                AgeRestriction ageRestriction = Enum.Parse<AgeRestriction>(command, true);

                var books = context.Books
                    .Where(b => b.AgeRestriction == ageRestriction)
                    .OrderBy(b => b.Title)
                    .Select(b => b.Title)
                    .ToList();

                return string.Join(Environment.NewLine, books);
            }
            catch (Exception ex)
            {
                return null;
            }


        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            try
            {
                var goldenBooks = context.Books
                    .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                    .OrderBy(b => b.BookId)
                    .Select(b => b.Title)
                    .ToList();

                return string.Join(Environment.NewLine, goldenBooks);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            try
            {
                var books = context.Books
                    .Where(b => b.Price > 40)
                    .OrderByDescending(b => b.Price)
                    .Select(b => new
                    {
                        b.Title,
                        b.Price
                    })
                    .ToList();

                StringBuilder sb = new StringBuilder();

                foreach (var book in books)
                {
                    sb.AppendLine($"{book.Title} - ${book.Price:f2}");
                }

                return sb.ToString().TrimEnd();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input.Split(" ")
                .Select(c => c.ToLower())
                .ToArray();

            var books = context.Books
                .Where(b => b.BookCategories.Any(bc => categories.Contains(bc.Category.Name.ToLower())))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime dateTime = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(b => b.ReleaseDate < dateTime)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var b in books)
            {
                sb.AppendLine($"{b.Title} - {b.EditionType} - ${b.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authorNames = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var author in authorNames)
            {
                sb.AppendLine($"{author.FirstName} {author.LastName}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(a => $"{a.Title} ({a.Author.FirstName} {a.Author.LastName})")
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var copiesCount = context.Authors
                .Select(a => new
                {
                    AuthorName = $"{a.FirstName} {a.LastName}",
                    BooksCopies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.BooksCopies)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var c in copiesCount)
            {
                sb.AppendLine($"{c.AuthorName} - {c.BooksCopies}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var books= context.Categories
                .Select(c => new
                {
                    c.Name,
                    Profit=c.CategoryBooks.Sum(b=>b.Book.Copies*b.Book.Price)
                })
                .OrderByDescending(c=>c.Profit)
                .ThenBy(c=>c.Name)
                .ToList();

            StringBuilder sb=new StringBuilder ();

            foreach (var b in books)
            {
                sb.AppendLine($"{b.Name} ${b.Profit:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var recentBooks = context.Categories
                              .OrderBy(c => c.Name)
                              .Select(c => new
                              {
                                  CategoryName = c.Name,
                                  Recent = c.CategoryBooks
                                    .OrderByDescending(x => x.Book.ReleaseDate)
                                    .Take(3)
                                    .Select(x => new
                                    {
                                        BookName = x.Book.Title,
                                        ReleaseYear = x.Book.ReleaseDate.Value.Year
                                    })
                                    .ToList()
                              })
                            .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var c in recentBooks)
            {
                sb.AppendLine($"--{c.CategoryName}");

                foreach (var b in c.Recent)
                {
                    sb.AppendLine($"{b.BookName} ({b.ReleaseYear})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            context.Books
                .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var b in context.Books)
            {
                b.Price += 5;
            }

            context.SaveChanges();              
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Copies < 4200)
                .ToList();

            context.RemoveRange(books);

            context.SaveChanges();

            return books.Count;
        }
    }
}
