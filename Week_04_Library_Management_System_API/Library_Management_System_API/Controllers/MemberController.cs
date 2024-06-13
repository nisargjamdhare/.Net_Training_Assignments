using Library_Management_System_API.DTO;
using Library_Management_System_API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;

namespace Library_Management_System_API.Controllers
{
     [Route("api/[controller]/[action]")]
        public class MemberController : Controller
        {
            public MemberController()
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


        // Method To add The member 
            [HttpPost]
            public async Task<MemberModel> AddMember(MemberModel memberModel)
            {
                Member member = new Member();
                member.Name = memberModel.Name;
                member.DateOfBirth = memberModel.DateOfBirth;
                member.Email = memberModel.Email;


            // Assigning Values to The Mandatory Fields 

            member.Id = Guid.NewGuid().ToString();
            member.UId = member.Id;
            member.DocumentType = "Member";
            member.CreatedBy = "Nisarga";
            member.CreatedOn = DateTime.Now;
            member.UpdatedBy = "";
            member.UpdatedOn = DateTime.Now;
            member.Version = 1;
            member.Active = true;
            member.Archived = false;

                //  Adding The Data To the Database 

                Member response = await Container.CreateItemAsync(member);

                //return the Model 

                MemberModel responseModel = new MemberModel();
                responseModel.Name = response.Name;
                responseModel.DateOfBirth = response.DateOfBirth;
                responseModel.Email = response.Email;
               

                return responseModel;

            }

        [HttpGet]
        public async Task<MemberModel> GetMemberByUid(string UID)
        {
            var member = Container.GetItemLinqQueryable<Member>(true).
                Where(q => q.UId == UID && q.Active == true && q.Archived == false).FirstOrDefault();

            MemberModel memberModel = new MemberModel();
            memberModel.Name = member.Name;
            memberModel.DateOfBirth = member.DateOfBirth;
            memberModel.Email = member.Email;
           

            return memberModel;

        }

        [HttpGet]
        public async Task<List<MemberModel>> GetAllMembers()
        {
            var members = Container.GetItemLinqQueryable<Member>(true).
                Where(q => q.Active == true && q.Archived == false && q.DocumentType == "Member").ToList();

            List<MemberModel> member_Model = new List<MemberModel>();

            foreach (var member in members)
            {
                MemberModel memberModel = new MemberModel();

                memberModel.UID = member.UId;
                memberModel.Name = member.Name;
                memberModel.DateOfBirth = member.DateOfBirth;
                memberModel.Email = member.Email;



                member_Model.Add(memberModel);

            }
            return member_Model;
        }




        [HttpPut]
        public async Task<MemberModel> UpdateMember(MemberModel member)
        {
            var existingMember = Container.GetItemLinqQueryable<Member>(true).
                Where(q => q.UId == member.UID && q.Active == true && q.Archived == false).FirstOrDefault();

            existingMember.Archived = true;
            existingMember.Active = false;

            existingMember.Id = Guid.NewGuid().ToString();
            existingMember.UpdatedBy = "Ketan";
            existingMember.UpdatedOn = DateTime.Now;
            existingMember.Version = existingMember.Version++;
            existingMember.Active = true;
            existingMember.Archived = false;


            existingMember.Name = member.Name;
            existingMember.DateOfBirth = member.DateOfBirth;
            existingMember.Email = member.Email;
           

            existingMember = await Container.CreateItemAsync(existingMember);


            MemberModel response = new MemberModel();
            response.Name = existingMember.Name;
            response.DateOfBirth = existingMember.DateOfBirth;
            response.Email = existingMember.Email;

            return response;

        }
    }
}
