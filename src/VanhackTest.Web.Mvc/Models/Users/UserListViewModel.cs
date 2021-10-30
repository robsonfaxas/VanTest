using System.Collections.Generic;
using VanhackTest.Roles.Dto;

namespace VanhackTest.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
