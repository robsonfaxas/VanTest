using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanhackTest.Domain;

namespace VanhackTest.Courses.Dtos
{
    [AutoMapTo(typeof(CourseVideo))]
    [AutoMapFrom(typeof(CourseVideo))]
    public class CourseVideoInsertDto
    {
        public int IdCourse { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public short Order { get; set; }
        public string Link { get; set; }
    }
}
