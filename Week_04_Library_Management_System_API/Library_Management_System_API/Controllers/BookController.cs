using Library_Management_System_API.DTO;
using Library_Management_System_API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using System.Net;



namespace Student_Management.Controllers
{
    [Route("api/[controller]/[action]")]
    public class BookController : Controller
    {
        public BookController()
        {
            Container = GetContainer();
        }


        public string URI = "https://localhost:8081";
        public string PrimaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        public string DatabaseName = "Lib_Mangm_Sys";
        public string ContainerName = "Book";

        private Container Container;

        private Container GetContainer()
        {
            CosmosClient cosmosClient = new CosmosClient(URI, PrimaryKey);
            Database database = cosmosClient.GetDatabase(DatabaseName);
            Container container = database.GetContainer(ContainerName);
            return container;
        }



        [HttpPost]
        public async Task<BookModel> AddBook(BookModel bookModel)
        {
            EntityBase book = new EntityBase();
            book.Title = bookModel.Title;
            book.Author = bookModel.Author;
            book.PublishedDate = bookModel.PublishedDate;
            book.ISBN = bookModel.ISBN;
            book.IsIssued = bookModel.IsIssued;

            // Assigning Values to The Mandatory Fields 

            book.Id = Guid.NewGuid().ToString();
            book.UId = book.Id;
            book.DocumentType = "book";
            book.CreatedBy = "Nisarga";
            book.CreatedOn = DateTime.Now;
            book.UpdatedBy = "";
            book.UpdatedOn = DateTime.Now;
            book.Version = 1;
            book.Active = true;
            book.Archived = false;

            //  Adding The Data To the Database 

            EntityBase response = await Container.CreateItemAsync(book);

            //return the Model 

            BookModel responseModel = new BookModel();
            responseModel.Title = response.Title;
            responseModel.Author = response.Author;
            responseModel.PublishedDate = response.PublishedDate;
            responseModel.ISBN = response.ISBN;
            responseModel.IsIssued = response.IsIssued;


            return responseModel;

        }


        // Method To Get all Books
        [HttpGet]
        public async Task<List<BookModel>> GetAllBooks()
        {
            var books = Container.GetItemLinqQueryable<EntityBase>(true).
                Where(q => q.Active ==true && q.Archived == false && q.DocumentType == "book").ToList();

            List<BookModel> bookModels = new List<BookModel>();

            foreach (var book in books)
            {
                BookModel bookModel = new BookModel();
                bookModel.UID = book.UId;
                bookModel.Title = book.Title;
                bookModel.Author = book.Author;
                bookModel.PublishedDate= book.PublishedDate;
                bookModel.ISBN= book.ISBN;
                bookModel.IsIssued= book.IsIssued;

                bookModels.Add(bookModel);
               
            }
            return bookModels;
        }

        // Method to get the record by UID
        [HttpGet]
        public async Task<BookModel> GetBookByUid(string UID)
        {
            var book = Container.GetItemLinqQueryable<EntityBase>(true).
                Where(q => q.UId == UID && q.Active == true && q.Archived == false).FirstOrDefault();

            BookModel bookModel = new BookModel();
            bookModel.Title = book.Title;
            bookModel.Author = book.Author;
            bookModel.PublishedDate = book.PublishedDate;
            bookModel.ISBN = book.ISBN;
            bookModel.IsIssued  = book.IsIssued;

            return bookModel;

        }

         // Method to update the Existing Book Details 

        [HttpPut]
        public async Task<BookModel> UpdateBook(BookModel book)
        {
            var existingBook = Container.GetItemLinqQueryable<EntityBase>(true).
                Where(q => q.UId == book.UID &&q.Active == true && q.Archived == false).FirstOrDefault();

            existingBook.Archived = true;
            existingBook.Active = false;

            existingBook.Id = Guid.NewGuid().ToString();
            existingBook.UpdatedBy = "Ketan";
            existingBook.UpdatedOn = DateTime.Now;
            existingBook.Version = existingBook.Version ++;
            existingBook.Active = true;
            existingBook.Archived = false;


            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.PublishedDate = book.PublishedDate;
            existingBook.ISBN = book.ISBN;
            existingBook.IsIssued = book.IsIssued;

            existingBook = await Container.CreateItemAsync(existingBook);


            BookModel response = new BookModel();
            response.Title = existingBook.Title;
            response.Author = existingBook.Author;  
            response.PublishedDate = existingBook.PublishedDate;
            response.ISBN = existingBook.ISBN;
            response.IsIssued = existingBook.IsIssued;

            return response;

        }


        [HttpDelete]
        public async Task<IActionResult> DeleteBook(string UID)
        {
            var book = Container.GetItemLinqQueryable<EntityBase>(true).Where(q => q.UId == q.Id && q.DocumentType == "book" && q.Archived == false && q.Active == true).AsEnumerable().FirstOrDefault();
            book.Active = false;
            await Container.ReplaceItemAsync(book, book.Id);

            return Ok("Book Deleted SucessFully!!!");
        }



    }

   
}
