using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanhackTest.Domain;
using VanhackTest.Services.Dtos;

namespace VanhackTest.Model.Entities
{
    public class CourseBuilder
    {
        private readonly Course _course;

        private CourseBuilder()
        {
            var faker = new Faker();
            _course = new Course()
            {
                RoleId = 1,
                Title = faker.Person.FullName,
                Description = faker.Company.CompanyName(),
                Videos = new List<CourseVideo>(), 

            };
        }

        public static CourseBuilder NewInstance() => new CourseBuilder();

        public CourseBuilder WithRoleId(int roleId)
        {
            _course.RoleId = roleId;
            return this;
        }
        public CourseBuilder WithVideos(List<CourseVideo> list)
        {
            _course.Videos = list;
            return this;
        }

        public Course Build() => _course;

        public static implicit operator Course(CourseBuilder builder) => builder.Build();
    }
}
