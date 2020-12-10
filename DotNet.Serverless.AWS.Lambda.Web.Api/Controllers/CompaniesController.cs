using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Bogus;
using Bogus.DataSets;
using Bogus.Extensions;
using DotNet.Serverless.AWS.Lambda.Web.Api.Bogus.CompanyBogus;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DotNet.Serverless.AWS.Lambda.Web.Api.Models;
using Company = DotNet.Serverless.AWS.Lambda.Web.Api.Models.Company;

namespace DotNet.Serverless.AWS.Lambda.Web.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class CompaniesController : ControllerBase
    {
        private readonly Random _randomGen = new Random();
        private readonly ICompanyBogus _companyBogus;

        public CompaniesController(ICompanyBogus companyBogus)
        {
            _companyBogus = companyBogus;
        }

        /// <summary>
        ///     Get all companies.
        /// </summary>
        /// <remarks>
        ///     Remark
        ///     TODO: Write details about the request.
        /// </remarks>
        /// <returns>All companies</returns>
        [HttpGet]
        [Route("/api/v1/companies")]
        [ProducesResponseType(typeof(List<Company>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAllCompanies(
            CancellationToken cancellationToken
        )
        {
            var okChance = _randomGen.Next(100);
            if (okChance < 95)
            {
                return Ok(_companyBogus.GenerateList());
            }

            var errorChance = _randomGen.Next(100);
            if (errorChance < 50)
            {
                return NotFound();
            }

            return BadRequest();
        }

        /// <summary>
        ///     Get a company by id.
        /// </summary>
        /// <remarks>
        ///     Remark
        ///     TODO: Write details about the request.
        /// </remarks>
        /// <returns>The requested company</returns>
        [HttpGet]
        [Route("/api/v1/companies/{companyId}")]
        [ProducesResponseType(typeof(Company), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCompanyById(
            [FromRoute] int companyId,
            CancellationToken cancellationToken
        )
        {
            var okChance = _randomGen.Next(100);
            if (okChance < 95)
            {
                return Ok(_companyBogus.Generate());
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