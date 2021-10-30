using System.Collections.Generic;
using VanhackTest.Roles.Dto;

namespace VanhackTest.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}