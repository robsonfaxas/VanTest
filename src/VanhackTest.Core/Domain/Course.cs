using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanhackTest.Authorization.Roles;

namespace VanhackTest.Domain
{
 
    public class Course : AuditedEntity<int>
    {
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual int RoleId { get; set; }
        public virtual List<CourseVideo> Videos { get; set; }
    }
}
