namespace EmployeeManagementSystem25.Common
{
    public class Credentials
    {
        public static readonly string DatabaseName = Environment.GetEnvironmentVariable("databaseName");
        public static readonly string ContainerName = Environment.GetEnvironmentVariable("containerName");
        public static readonly string CosmosEndpoint = Environment.GetEnvironmentVariable("cosmosUrl");
        public static readonly string PrimaryKey = Environment.GetEnvironmentVariable("primaryKey");
        public static readonly string EmployeeDataType = "Employee";
        public static readonly string ManagerDatatype = "Manager";
        public static readonly string AdditionalEmployee = "AdditionalEmployee";
        public  static string StudentUrl = Environment.GetEnvironmentVariable("studentUrl");
        public  static string AddStudentEndPoint ="/api/Student/AddStudent";
        public static string GetAllStudentsEndPoint = "/api/Student/GetAllStudent";

    }
}
