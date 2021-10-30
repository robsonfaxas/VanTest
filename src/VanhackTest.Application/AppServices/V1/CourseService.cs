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
using VanhackTest.Courses;

namespace VanhackTest.AppServices.V1
{
    [ApiVersion("1")]
    [AbpAuthorize()]
    [Route("course")]
    public class CourseService: ApplicationService, ICourseService
    {

        //[HttpGet("Get/{id}")]
        //public async Task<Course> GetCourse(int id)
        //{


            
        //}
    }
}