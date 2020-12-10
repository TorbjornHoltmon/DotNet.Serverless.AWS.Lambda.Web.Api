using System;
using System.Collections.Generic;
using Bogus;
using DotNet.Serverless.AWS.Lambda.Web.Api.Models;

namespace DotNet.Serverless.AWS.Lambda.Web.Api.Bogus.CompanyBogus
{
    public class CompanyBogus : ICompanyBogus
    {
        private readonly Random _randomGen = new Random();

        public List<Company> GenerateList()
        {
            var fakeCompany = new Faker<Company>()
                .RuleFor(company => company.CompanyName,
                    (faker) => faker.Company.CompanyName())
                .RuleFor(company => company.Id, (faker) => faker.Random.Int(0))
                .RuleFor(company => company.CompanyCatchPhrase,
                    (faker) => faker.Company.CatchPhrase())
                .RuleFor(company => company.CompanyLogo,
                    (faker) => faker.Image.PicsumUrl(640, 640))
                .RuleFor(company => company.CompanyDescription,
                    (faker) => faker.Lorem.Sentence())
                .RuleFor(company => company.DepartmentIds,
                    (faker) => faker.Make(_randomGen.Next(10, 30), () => faker.Random.Int()));

            return fakeCompany.Generate(_randomGen.Next(10, 30));
        }

        public Company Generate()
        {
            var fakeCompany = new Faker<Company>()
                .RuleFor(company => company.CompanyName,
                    (faker) => faker.Company.CompanyName())
                .RuleFor(company => company.Id, (faker) => faker.Random.Int())
                .RuleFor(company => company.CompanyCatchPhrase,
                    (faker) => faker.Company.CatchPhrase())
                .RuleFor(company => company.CompanyLogo,
                    (faker) => faker.Image.PicsumUrl(640, 640))
                .RuleFor(company => company.CompanyDescription,
                    (faker) => faker.Lorem.Sentence())
                .RuleFor(company => company.DepartmentIds,
                    (faker) => faker.Make(_randomGen.Next(10, 30), () => faker.Random.Int()));

            return fakeCompany.Generate();
        }
    }
}