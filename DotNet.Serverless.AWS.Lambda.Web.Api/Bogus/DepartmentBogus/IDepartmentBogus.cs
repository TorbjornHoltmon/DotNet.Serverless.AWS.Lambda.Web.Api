using System.Collections.Generic;
using DotNet.Serverless.AWS.Lambda.Web.Api.Models;

namespace DotNet.Serverless.AWS.Lambda.Web.Api.Bogus.DepartmentBogus
{
    public interface IDepartmentBogus
    {
        List<Department>  GenerateList();
        Department Generate();
    }
}