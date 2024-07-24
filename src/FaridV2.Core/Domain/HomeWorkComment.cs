using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using FaridV2.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farid.Domains.LMS
{
    public class HomeWorkComment : Entity, IFullAudited
    {
        public int HomeWorkId { get; set; }
        public HomeWork HomeWork { get; set; }
        public string Comment { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }

        public long? CreatorUserId { get; set; }
        public DateTime CreationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
