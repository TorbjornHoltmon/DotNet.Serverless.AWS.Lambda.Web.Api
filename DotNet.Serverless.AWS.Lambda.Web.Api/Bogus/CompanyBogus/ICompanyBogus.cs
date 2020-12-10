using System.Collections.Generic;
using DotNet.Serverless.AWS.Lambda.Web.Api.Models;

namespace DotNet.Serverless.AWS.Lambda.Web.Api.Bogus.CompanyBogus
{
    public interface ICompanyBogus
    {
        List<Company> GenerateList();
        Company Generate();
    }
}