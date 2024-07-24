using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using FaridV2.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farid.Domains
{
    public class UserSkills : Entity, IFullAudited
    {
        public long UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual User User { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime CreationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
