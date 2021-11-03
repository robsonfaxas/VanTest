using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;
using Abp.Application.Services.Dto;
using VanhackTest.Users;
using VanhackTest.Users.Dto;
using VanhackTest.Services;
using VanhackTest.Model.Entities;
using Abp.Authorization;
using Abp.Domain.Repositories;
using VanhackTest.Domain;
using VanhackTest.AppServices.V1;
using NSubstitute;
using NSubstitute.Extensions;
using Abp.ObjectMapping;
using Abp.Domain.Uow;
using VanhackTest.Authorization.Users;
using VanhackTest.Authorization.Roles;
using Abp.Runtime.Session;
using System.Collections.Generic;

namespace VanhackTest.Tests.Courses
{
    public class CoursesAppService_Tests : VanhackTestTestBase
    {
        private readonly ICourseAppService _courseAppService;
        private readonly IRepository<Course> _courseRepository;        
        private readonly IRepository<CourseVideo> _repositoryVideos;
        private readonly IObjectMapper _objectMapper;
        private readonly IUserAppService _userAppService;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;
        private readonly IAbpSession _session;

        public CoursesAppService_Tests()
        {
            _courseRepository = Substitute.For<IRepository<Course>>();
            _repositoryVideos = Substitute.For<IRepository<CourseVideo>>();
            _objectMapper = Substitute.For<IObjectMapper>();
            _userAppService = Substitute.For<IUserAppService>();
            _unitOfWorkManager = Substitute.For<IUnitOfWorkManager>();
            _userManager = Resolve<UserManager>();
            _roleManager = Resolve<RoleManager>();
            _session = Substitute.For<IAbpSession>();
            _courseAppService = new CourseAppService(
                _courseRepository,
                _repositoryVideos,
                _objectMapper,
                _userAppService,
                _unitOfWorkManager,
                _userManager,
                _roleManager,
                _session
            );
        }

        [Fact]
        public async Task CreateCourse_Exception_When_Role_Not_Allowed()
        {
            var course = CourseInsertDtoBuilder.NewInstance()
                                  .WithRoleId(0)
                                  .Build();
            AssertException<AbpAuthorizationException>(() =>
            {
                _courseAppService.Create(course);
            }, $"This logged user does not have access to add, update, delete or get this course with RoleId {course.RoleId}");
        }

        [Fact(Skip ="needs to be fixed. UserManager and RoleManager aren't mockable")]
        public async Task CreateCourse_AddCorrectly()
        {
            var courseDto = CourseInsertDtoBuilder.NewInstance().WithRoleId(2).Build();
            var courseReturn = CourseBuilder.NewInstance().WithRoleId(2).Build();

            _courseRepository.Configure().Get(Arg.Any<int>()).Returns(courseReturn);
            _session.Configure().UserId.Returns(2);
            var course = _courseAppService.Create(courseDto);
            _courseRepository.Received().Get(1);

            course.ShouldNotBeNull();            
        }

        //[Fact]
        //public async Task CreateUser_Test()
        //{
        //    // Act
        //    await _courseAppService.CreateAsync(
        //        new CreateUserDto
        //        {
        //            EmailAddress = "john@volosoft.com",
        //            IsActive = true,
        //            Name = "John",
        //            Surname = "Nash",
        //            Password = "123qwe",
        //            UserName = "john.nash"
        //        });

        //    await UsingDbContextAsync(async context =>
        //    {
        //        var johnNashUser = await context.Users.FirstOrDefaultAsync(u => u.UserName == "john.nash");
        //        johnNashUser.ShouldNotBeNull();
        //    });
        //}
    }
}
