using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanhackTest.Domain;

namespace VanhackTest.Services.Dtos
{
    [AutoMapFrom(typeof(Course))]
    public class CourseDto : AuditedEntityDto<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
