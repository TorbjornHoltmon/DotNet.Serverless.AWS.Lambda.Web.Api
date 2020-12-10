using System;
using System.Collections.Generic;
using Bogus;
using DotNet.Serverless.AWS.Lambda.Web.Api.Models;

namespace DotNet.Serverless.AWS.Lambda.Web.Api.Bogus.EmployeeBogus
{
    public class EmployeeBogus : IEmployeeBogus
    {
        private readonly Random _randomGen = new Random();
        
        public List<Employee> GenerateList()
        {
            var fakeEmployee = new Faker<Employee>()
                .RuleFor(employee => employee.Name,
                    (faker) => faker.Name.FullName())
                .RuleFor(employee => employee.Id, (faker) => faker.Random.Int(0))
                .RuleFor(employee => employee.Address,
                    (faker) => faker.Address.FullAddress())
                .RuleFor(employee => employee.CompanyId,
                    (faker) => faker.Random.Int(0))
                .RuleFor(employee => employee.Email,
                    (faker) => faker.Internet.Email())
                .RuleFor(employee => employee.DepartmentId,
                    (faker) => faker.Random.Int(0))
                .RuleFor(employee => employee.Salary,
                    (faker) => faker.Random.Int(20, 10000))
                .RuleFor(employee => employee.BirthdayDateTime,
                    (faker) => faker.Date.Past(_randomGen.Next(20, 80), DateTime.Now.AddYears(_randomGen.Next(20, 40))));
            
            return fakeEmployee.Generate(_randomGen.Next(10, 30));
        }

        public Employee Generate()
        {
            var fakeEmployee = new Faker<Employee>()
                .RuleFor(employee => employee.Name,
                    (faker) => faker.Name.FullName())
                .RuleFor(employee => employee.Id, (faker) => faker.Random.Int(0))
                .RuleFor(employee => employee.Address,
                    (faker) => faker.Address.FullAddress())
                .RuleFor(employee => employee.CompanyId,
                    (faker) => faker.Random.Int(0))
                .RuleFor(employee => employee.Email,
                    (faker) => faker.Internet.Email())
                .RuleFor(employee => employee.DepartmentId,
                    (faker) => faker.Random.Int(0))
                .RuleFor(employee => employee.Salary,
                (faker) => faker.Random.Int(20, 10000))
                .RuleFor(employee => employee.BirthdayDateTime,
                (faker) => faker.Date.Past(_randomGen.Next(20, 80), DateTime.Now.AddYears(_randomGen.Next(20, 40))));
            

            return fakeEmployee.Generate();
        }
    }
}