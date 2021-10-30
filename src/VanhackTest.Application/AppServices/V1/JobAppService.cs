using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Authorization;
using Microsoft.AspNetCore.Mvc;
using VanhackTest.Interface;
using VanhackTest.Application.FakeDB;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using VanhackTest.Core.Utils;

namespace VanhackTest.AppServices.V1
{
    [ApiVersion("1")]
    [AbpAuthorize()]
    [Route("job")]
    public class JobAppService: ApplicationService, IJobAppService
    {
        [HttpGet]
        [AbpAllowAnonymous]
        public async Task<PagedResults<dynamic>> GetJobs(int skip = 0, int maxResult = 10)
        {
            var jobs = Jobs.FakeJobs
                            .Generate(100)
                            .Skip(skip)
                            .Take(maxResult)
                            .ToList();
           var result = new PagedResults<dynamic>
            (
                jobs,
                100, 
                maxResult,
                skip 
            );

            return result;
        }

        [HttpGet("detail/{slug}")]
        [AbpAllowAnonymous]
        public dynamic GetBySlug(string slug)
        {
            if (string.IsNullOrEmpty(slug))
            {
                throw new AbpAuthorizationException("Slug cannot by empty");
            }

            var job = Jobs.FakeJobs
                            .Generate(1)
                            .FirstOrDefault();

            job.Slug = slug;
            return job;
        }
    }
}