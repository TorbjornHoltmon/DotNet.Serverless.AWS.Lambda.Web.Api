using System;

namespace DotNet.Serverless.AWS.Lambda.Web.Api.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime BirthdayDateTime { get; set; }
        public int DepartmentId { get; set; }
        public int CompanyId { get; set; }
        public int Salary { get; set; }
        public string CreditCard { get; set; }
    }
}