using System;
using System.Collections.Generic;
using Bogus;
using DotNet.Serverless.AWS.Lambda.Web.Api.Bogus.CompanyBogus;
using DotNet.Serverless.AWS.Lambda.Web.Api.Models;

namespace DotNet.Serverless.AWS.Lambda.Web.Api.Bogus.DepartmentBogus
{
    public class DepartmentBogus : IDepartmentBogus
    {
        private readonly Random _randomGen = new Random();
        
        public List<Department> GenerateList()
        {
            var fakeDepartment = new Faker<Department>()
                .RuleFor(department => department.DepartmentName,
                    (faker) => faker.Commerce.Department())
                .RuleFor(department => department.Id, (faker) => faker.Random.Int(0))
                .RuleFor(department => department.OfficeAddress,
                    (faker) => faker.Address.FullAddress())
                .RuleFor(department => department.CompanyId,
                    (faker) => faker.Random.Int(0))
                .RuleFor(department => department.Description,
                    (faker) => faker.Lorem.Sentence())
                .RuleFor(department => department.EmployeeIds,
                    (faker) => faker.Make(_randomGen.Next(5, 9), () => faker.Random.Int()));

            return fakeDepartment.Generate(_randomGen.Next(10, 30));
        }

        public Department Generate()
        {
            var fakeDepartment = new Faker<Department>()
                .RuleFor(department => department.DepartmentName,
                    (faker) => faker.Commerce.Department())
                .RuleFor(department => department.Id, (faker) => faker.Random.Int(0))
                .RuleFor(department => department.OfficeAddress,
                    (faker) => faker.Address.FullAddress())
                .RuleFor(department => department.CompanyId,
                    (faker) => faker.Random.Int(0))
                .RuleFor(department => department.Description,
                    (faker) => faker.Lorem.Sentence())
                .RuleFor(department => department.EmployeeIds,
                    (faker) => faker.Make(_randomGen.Next(10, 30), () => faker.Random.Int()));

            return fakeDepartment.Generate();
        }
    }
}