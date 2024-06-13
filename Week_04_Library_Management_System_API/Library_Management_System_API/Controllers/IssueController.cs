using Library_Management_System_API.DTO;
using Library_Management_System_API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;

namespace Library_Management_System_API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class IssueController : Controller
    {
        public IssueController()
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
        public async Task<IssueModel> AddIssuedBook(IssueModel issueModel)
        {
            Issue issue = new Issue();
            issue.BookId = issueModel.BookId;
            issue.MemberId = issueModel.MemberId;
            issue.IssueDate = issueModel.IssueDate;
            issue.ReturnDate = issueModel.ReturnDate;
            issue.IsReturned = issueModel.IsReturned;

            // Assigning Values to The Mandatory Fields 

            issue.Id = Guid.NewGuid().ToString();
            issue.UId = issue.Id;
            issue.DocumentType = "issuebook";
            issue.CreatedBy = "Nisarga";
            issue.CreatedOn = DateTime.Now;
            issue.UpdatedBy = "";
            issue.UpdatedOn = DateTime.Now;
            issue.Version = 1;
            issue.Active = true;
            issue.Archived = false;

            //  Adding The Data To the Database 

            Issue response = await Container.CreateItemAsync(issue);

            //return the Model 

            IssueModel responseModel = new IssueModel();
            responseModel.BookId = response.BookId;
            responseModel.MemberId = response.MemberId;
            responseModel.IssueDate = response.IssueDate;
            responseModel.ReturnDate = response.ReturnDate;
            responseModel.IsReturned = response.IsReturned;


            return responseModel;

        }
        [HttpGet]
        public async Task<IssueModel> GetIssuedBookByUid(string UID)
        {
            var book = Container.GetItemLinqQueryable<Issue>(true).
                Where(q => q.UId == UID && q.Active == true && q.Archived == false).FirstOrDefault();

            IssueModel issueModel = new IssueModel();
            issueModel.UId= book.UId;
            issueModel.BookId = book.Id;
            issueModel.MemberId = book.MemberId;
            issueModel.IssueDate = book.IssueDate;
            issueModel.ReturnDate = book.ReturnDate;
            issueModel.IsReturned = book.IsReturned;

            return issueModel;


        }


        [HttpPut]
        public async Task<IssueModel> UpdateIssued(IssueModel issueModel)
        {
            var existingIssue = Container.GetItemLinqQueryable<Issue>(true).
                Where(q => q.UId == issueModel.UId && q.Active == true && q.Archived == false).FirstOrDefault();

            existingIssue.Archived = true;
            existingIssue.Active = false;

            existingIssue.Id = Guid.NewGuid().ToString();
            existingIssue.UpdatedBy = "Ketan";
            existingIssue.UpdatedOn = DateTime.Now;
            existingIssue.Version = existingIssue.Version + 1;
            existingIssue.Active = true;
            existingIssue.Archived = false;

            existingIssue.BookId = issueModel.BookId;
            existingIssue.MemberId = issueModel.MemberId;
            existingIssue.IssueDate = issueModel.IssueDate;
            existingIssue.ReturnDate = issueModel.ReturnDate;
            existingIssue.IsReturned = issueModel.IsReturned;


            existingIssue = await Container.CreateItemAsync(existingIssue);


            IssueModel response = new IssueModel();
            response.BookId = existingIssue.BookId;
            response.MemberId = existingIssue.MemberId;
            response.IssueDate = existingIssue.IssueDate;
            response.ReturnDate = existingIssue.ReturnDate;
            response.IsReturned = existingIssue.IsReturned;

            return response;

        }
    }
}
