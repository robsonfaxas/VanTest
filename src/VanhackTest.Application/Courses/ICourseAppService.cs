using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanhackTest.Courses.Dtos;
using VanhackTest.Services.Dtos;

namespace VanhackTest.Services
{
    public interface ICourseAppService : IApplicationService
    {
        CourseDto Create(CourseInsertDto input);
        CourseVideoDto CreateVideo(CourseVideoInsertDto input);
        CourseDto Update(CourseUpdateDto input);
        CourseVideoDto UpdateVideo(CourseVideoUpdateDto input);
        void Delete(int id);
        void DeleteVideo(int id);
        CourseDto Get(int id);
        CourseVideoDto GetVideo(int id);
        IEnumerable<CourseDto> GetAll();
    }
}
