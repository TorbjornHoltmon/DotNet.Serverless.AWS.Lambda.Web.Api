using System.Collections.Generic;

namespace DotNet.Serverless.AWS.Lambda.Web.Api.Models
{
    public class Department
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string DepartmentName { get; set; }
        public string OfficeAddress { get; set; }
        public string Description { get; set; }
        public List<int> EmployeeIds { get; set; }
    }
}