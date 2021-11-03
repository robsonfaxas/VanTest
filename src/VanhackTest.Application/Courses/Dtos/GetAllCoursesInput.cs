using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanhackTest.Services.Dtos
{
    public class GetAllCoursesInput : PagedAndSortedResultRequestDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
