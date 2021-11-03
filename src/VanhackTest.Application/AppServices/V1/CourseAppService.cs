using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.ObjectMapping;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VanhackTest.Authorization;
using VanhackTest.Authorization.Roles;
using VanhackTest.Authorization.Users;
using VanhackTest.Courses.Dtos;
using VanhackTest.Domain;
using VanhackTest.Helpers;
using VanhackTest.Services;
using VanhackTest.Services.Dtos;
using VanhackTest.Users;

namespace VanhackTest.AppServices.V1
{
    [ApiVersion("1")]
    [AbpAuthorize]
    [Route("course")]
    public class CourseAppService : CourseAppServiceBase, ICourseAppService
    {
        private readonly IRepository<Course> _courseRepository;
        private readonly IObjectMapper _mapper;
        private readonly IUserAppService _userAppService;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IRepository<CourseVideo> _videoRepository;        
        public CourseAppService(IRepository<Course> repository,
                                IRepository<CourseVideo> repositoryVideos,
                                IObjectMapper objectMapper, 
                                IUserAppService userAppService, 
                                IUnitOfWorkManager unitOfWorkManager,
                                UserManager userManager,
                                RoleManager roleManager,
                                IAbpSession session) : base (userManager,roleManager,session)
        {
            this._courseRepository = repository;
            this._mapper = objectMapper;
            this._userAppService = userAppService;
            this._unitOfWorkManager = unitOfWorkManager;
            this._videoRepository = repositoryVideos;
        }
        
        [HttpPost]
        public CourseDto Create(CourseInsertDto input)
        {
            User user = base.GetLoggedUserWithRoles();
            base.ValidateUserAccess(user, input.RoleId);
            var course = _mapper.Map<Course>(input);
            var courseId = _courseRepository.InsertAndGetId(course);
            course = _courseRepository.Get(courseId);
            return _mapper.Map<CourseDto>(course);
        }

        [HttpPost("video")]
        public CourseVideoDto CreateVideo(CourseVideoInsertDto input)
        {
            var course = _courseRepository.Get(input.IdCourse);
            User user = base.GetLoggedUserWithRoles();
            base.ValidateUserAccess(user, course.RoleId);
            var courseVideo = _mapper.Map<CourseVideo>(input);
            var courseVideoId = _videoRepository.InsertAndGetId(courseVideo);
            courseVideo = _videoRepository.Get(courseVideoId);
            return _mapper.Map<CourseVideoDto>(courseVideo);
        }

        [HttpPut]
        public CourseDto Update(CourseUpdateDto input)
        {
            var course = _courseRepository.Get(input.Id);
            User user = base.GetLoggedUserWithRoles();
            base.ValidateUserAccess(user, course.RoleId);
            base.ValidateUserAccess(user, input.RoleId);

            course.Title = input.Title;
            course.Description = input.Description;
            course.RoleId = input.RoleId;

            var result = _courseRepository.Update(course);
            course = _courseRepository.Get(input.Id);
            course.Videos = GetVideosByCourseId(input.Id);
            return _mapper.Map<CourseDto>(course);
        }

        [HttpPut("video")]
        public CourseVideoDto UpdateVideo(CourseVideoUpdateDto input)
        {
            var course = _courseRepository.Get(input.IdCourse);
            User user = base.GetLoggedUserWithRoles();
            base.ValidateUserAccess(user, course.RoleId);
            var courseVideo = _videoRepository.Get(input.Id);
            courseVideo.Title = input.Title;
            courseVideo.Description = input.Description;
            courseVideo.IdCourse = input.IdCourse;
            courseVideo.Link = input.Link;
            courseVideo.Order = input.Order;            
            _ = _videoRepository.Update(courseVideo);
            courseVideo = _videoRepository.Get(input.Id);
            return _mapper.Map<CourseVideoDto>(courseVideo);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var course = _courseRepository.Get(id);
            User user = base.GetLoggedUserWithRoles();
            base.ValidateUserAccess(user, course.RoleId);
            _courseRepository.Delete(id);
        }

        [HttpDelete("video/{id}")]
        public void DeleteVideo(int id)
        {
            var courseVideo = _videoRepository.Get(id);
            var course = _courseRepository.Get(courseVideo.IdCourse);
            User user = base.GetLoggedUserWithRoles();
            base.ValidateUserAccess(user, course.RoleId);
            _videoRepository.Delete(id);
        }

        [HttpGet("{id}")]
        public CourseDto Get(int id)
        {
            var course = _courseRepository.Get(id);
            course.Videos = GetVideosByCourseId(id);
            User user = base.GetLoggedUserWithRoles();
            base.ValidateUserAccess(user, course.RoleId);
            var result = _mapper.Map<CourseDto>(course);
            return result;
        }

        [HttpGet("video/{id}")]
        public CourseVideoDto GetVideo(int id)
        {
            var courseVideo = _videoRepository.Get(id);
            var course = _courseRepository.Get(courseVideo.Id);            
            User user = base.GetLoggedUserWithRoles();
            base.ValidateUserAccess(user, course.RoleId);
            var result = _mapper.Map<CourseVideoDto>(courseVideo);            
            return result;
        }

        [HttpGet]
        public IEnumerable<CourseDto> GetAll()
        {
            User user = base.GetLoggedUserWithRoles();
            base.ValidateUserAccess(user);
            var courses = _courseRepository.GetAllList(p => user.Roles.Select(s => s.RoleId).Contains(p.RoleId));
            foreach(var course in courses)
                course.Videos = GetVideosByCourseId(course.Id);
            return _mapper.Map<List<CourseDto>>(courses);
        }


        private List<CourseVideo> GetVideosByCourseId(int id)
        {
            List<CourseVideo> videos = _videoRepository.GetAllList(p => p.IdCourse == id);
            if (videos != null && videos.Count > 0)
                videos = videos.OrderBy(o => o.Order).ToList();
            return videos;
        }
    }
}
