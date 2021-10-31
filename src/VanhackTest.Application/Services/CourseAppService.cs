using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanhackTest.Authorization;
using VanhackTest.Domain;
using VanhackTest.Services.Dtos;

namespace VanhackTest.Services
{
    [AbpAllowAnonymous]
    public class CourseAppService : ICourseAppService
    {
        private readonly IRepository<Course> _personRepository;
        public CourseAppService(IRepository<Course> repository)
        {
            this._personRepository = repository;
        }

        public void Create(CourseDto input)
        {
            var course = new Course()
            {
                CreationTime = input.CreationTime,
                CreatorUserId = input.CreatorUserId,
                Description = input.Description,
                LastModificationTime = input.LastModificationTime,
                LastModifierUserId = input.LastModifierUserId,
                Title = input.Title
            };

            var result = _personRepository.Insert(course);            
        }

        public Task DeleteAsync(EntityDto<int> input)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<CourseDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public Task<CourseDto> GetAsync(EntityDto<int> input)
        {
            throw new NotImplementedException();
        }

        public Task<CourseDto> UpdateAsync(CourseDto input)
        {
            throw new NotImplementedException();
        }
    }
}
