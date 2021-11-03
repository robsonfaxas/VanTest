using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Runtime.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanhackTest.Authorization.Roles;
using VanhackTest.Authorization.Users;
using VanhackTest.Domain;

namespace VanhackTest.Helpers
{
    public class CourseAppServiceBase
    {

        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;
        private readonly IAbpSession _session;

        public CourseAppServiceBase(UserManager userManager,
                                     RoleManager roleManager,
                                     IAbpSession session)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._session = session;
        }

        public void ValidateUserAccess(User user, int courseRoleId = 0)
        {
            if (user == null)
                throw new AbpAuthorizationException("User not logged");
            if (user.Roles == null || user.Roles.Count == 0)
                throw new AbpAuthorizationException("User does not have roles");
            if (courseRoleId != 0 && !UserHasRole(user, courseRoleId))
                throw new AbpAuthorizationException($"This logged user does not have access to add, update, delete or get this course with RoleId {courseRoleId}");
        }

        public bool UserHasRole(User user, int courseRoleId)
        {
            foreach (UserRole role in user.Roles)
                if (role.RoleId == courseRoleId)
                    return true;
            return false;
        }

        public User GetLoggedUserWithRoles()
        {
            var userId = _session.UserId;
            var user = _userManager.Users.Where(p => p.Id == userId).FirstOrDefault();
            user.Roles = GetUserRolesList(user);
            return user;
        }

        public ICollection<UserRole> GetUserRolesList(User user)
        {
            var roles = _userManager.GetRolesAsync(user).Result;
            List<UserRole> list = new List<UserRole>();
            foreach (var roleName in roles)
            {
                var role = _roleManager.GetRoleByName(roleName);
                list.Add(new UserRole() { RoleId = role.Id });
            }
            return list;
        }

        internal void ValidateOrder(List<CourseVideo> allCourseVideos, CourseVideo courseVideo)
        {
            foreach(var course in allCourseVideos)
                if(course.Order == courseVideo.Order && (course.Id != courseVideo.Id || courseVideo.Id == 0))
                    throw new AbpAuthorizationException("Video order cannot be repeated");
        }
    }
}
