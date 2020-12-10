using System.Collections.Generic;

namespace DotNet.Serverless.AWS.Lambda.Web.Api.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyCatchPhrase { get; set; }
        public string CompanyLogo { get; set; }
        public string CompanyDescription { get; set; }
        public List<int> DepartmentIds { get; set; }
    }
}