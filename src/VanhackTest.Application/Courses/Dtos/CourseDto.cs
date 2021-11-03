using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanhackTest.Domain;

namespace VanhackTest.Services.Dtos
{
    [AutoMapTo(typeof(Course))]
    [AutoMapFrom(typeof(Course))]
    public class CourseDto : AuditedEntity<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int RoleId { get; set; }
        public List<CourseVideo> Videos { get; set; }
    }
}
