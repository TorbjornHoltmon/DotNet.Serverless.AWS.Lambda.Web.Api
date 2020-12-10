using System.Collections.Generic;
using DotNet.Serverless.AWS.Lambda.Web.Api.Models;

namespace DotNet.Serverless.AWS.Lambda.Web.Api.Bogus.EmployeeBogus
{
    public interface IEmployeeBogus
    {
        List<Employee>  GenerateList();
        Employee Generate();
    }
}