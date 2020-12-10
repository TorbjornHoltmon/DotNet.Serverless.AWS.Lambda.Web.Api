using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Bogus;
using DotNet.Serverless.AWS.Lambda.Web.Api.Bogus.EmployeeBogus;
using DotNet.Serverless.AWS.Lambda.Web.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNet.Serverless.AWS.Lambda.Web.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class EmployeesController : ControllerBase
    {
        private readonly Random _randomGen = new Random();
        private readonly IEmployeeBogus _employeeBogus;

        public EmployeesController(IEmployeeBogus employeeBogus)
        {
            _employeeBogus = employeeBogus;
        }


        /// <summary>
        ///     Get all employees from a department.
        /// </summary>
        /// <remarks>
        ///     Remark
        ///     TODO: Write details about the request.
        /// </remarks>
        /// <returns>All employees from requested department</returns>
        [HttpGet]
        [Route("/api/v1/department/{departmentId}/employees")]
        [ProducesResponseType(typeof(List<Employee>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAllEmployeesFromDepartment(
            [FromRoute] int departmentId,
            CancellationToken cancellationToken
        )
        {
            var okChance = _randomGen.Next(100);
            if (okChance < 95)
            {
                return Ok(_employeeBogus.GenerateList());
            }

            var errorChance = _randomGen.Next(100);
            if (errorChance < 50)
            {
                return NotFound();
            }

            return BadRequest();
        }

        /// <summary>
        ///     Get a employee by id.
        /// </summary>
        /// <remarks>
        ///     Remark
        ///     TODO: Write details about the request.
        /// </remarks>
        /// <returns>The requested employee</returns>
        [HttpGet]
        [Route("/api/v1/employee/{employeeId}")]
        [ProducesResponseType(typeof(Employee), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetEmployeeById(
            [FromRoute] int employeeId,
            CancellationToken cancellationToken
        )
        {
            var okChance = _randomGen.Next(100);
            if (okChance < 95)
            {
                return Ok(_employeeBogus.Generate());
            }

            var errorChance = _randomGen.Next(100);
            if (errorChance < 50)
            {
                return NotFound();
            }

            return BadRequest();
        }
    }
}