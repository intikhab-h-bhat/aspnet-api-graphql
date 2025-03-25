using WebApi.Graphql.Data;
using WebApi.Graphql.Model;
using static System.Reflection.Metadata.BlobBuilder;

namespace WebApi.Graphql.GraphQl
{
    public class Query
    {
        private readonly ApplicationDbContext _context;
        public Query(ApplicationDbContext context)
        {
            _context = context;
        }


        //public static List<Books> books = new()
        //{
        //    new Books { Id = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald" },
        //    new Books { Id = 2, Title = "1984", Author = "George Orwell" },
        //    new Books { Id = 3, Title = "To Kill a Mockingbird", Author = "Harper Lee" }
        //};

        // Get all books
        //public List<Books> Books() => books;
        public List<Books> Books() => _context.Books.ToList();



        // Get book by ID
        //public Books? BookById(int id) => books.FirstOrDefault(b => b.Id == id);

    }
}
