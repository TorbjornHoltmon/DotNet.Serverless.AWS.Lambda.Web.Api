using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Bogus;
using DotNet.Serverless.AWS.Lambda.Web.Api.Bogus.DepartmentBogus;
using DotNet.Serverless.AWS.Lambda.Web.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNet.Serverless.AWS.Lambda.Web.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class DepartmentsController : ControllerBase
    {
        private readonly Random _randomGen = new Random();
        private readonly IDepartmentBogus _departmentBogus;

        public DepartmentsController(IDepartmentBogus departmentBogus)
        {
            _departmentBogus = departmentBogus;
        }

        /// <summary>
        ///     Get all departments in a company.
        /// </summary>
        /// <remarks>
        ///     Remark
        ///     TODO: Write details about the request.
        /// </remarks>
        /// <returns>All departments in the company</returns>
        [HttpGet]
        [Route("/api/v1/companies/{companyId}/departments")]
        [ProducesResponseType(typeof(List<Department>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAllDepartmentsFromCompany(
            [FromRoute] int companyId,
            CancellationToken cancellationToken
        )
        {
            var okChance = _randomGen.Next(100);
            if (okChance < 95)
            {
                return Ok(_departmentBogus.GenerateList());
            }

            var errorChance = _randomGen.Next(100);
            if (errorChance < 50)
            {
                return NotFound();
            }

            return BadRequest();
        }

        /// <summary>
        ///     Get a department by id.
        /// </summary>
        /// <remarks>
        ///     Remark
        ///     TODO: Write details about the request.
        /// </remarks>
        /// <returns>The requested department</returns>
        [HttpGet]
        [Route("/api/v1/departments/{departmentId}")]
        [ProducesResponseType(typeof(Company), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetDepartmentById(
            [FromRoute] int departmentId,
            CancellationToken cancellationToken
        )
        {
            var okChance = _randomGen.Next(100);
            if (okChance < 95)
            {
                return Ok(_departmentBogus.Generate());
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