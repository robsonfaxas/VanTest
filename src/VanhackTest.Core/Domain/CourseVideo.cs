using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanhackTest.Domain
{
    public class CourseVideo : AuditedEntity<int>
    {
        public virtual int IdCourse { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual short Order { get; set; }
        public virtual string Link { get; set; }
    }
}
