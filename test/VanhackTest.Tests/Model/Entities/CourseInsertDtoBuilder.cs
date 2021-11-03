using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanhackTest.Services.Dtos;

namespace VanhackTest.Model.Entities
{
    public class CourseInsertDtoBuilder
    {
        private readonly CourseInsertDto _courseDto;

        private CourseInsertDtoBuilder()
        {
            var faker = new Faker();
            _courseDto = new CourseInsertDto()
            {
                RoleId = 1,
                Title = faker.Person.FullName,
                Description = faker.Company.CompanyName()                
            };
        }

        public static CourseInsertDtoBuilder NewInstance() => new CourseInsertDtoBuilder();

        public CourseInsertDtoBuilder WithRoleId(int roleId)
        {
            _courseDto.RoleId = roleId;
            return this;
        }

        public CourseInsertDto Build() => _courseDto;

        public static implicit operator CourseInsertDto(CourseInsertDtoBuilder builder) => builder.Build();
    }
}
