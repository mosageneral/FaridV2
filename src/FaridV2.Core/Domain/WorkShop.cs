using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaridV2.Domain
{
    public class WorkShop : Entity, IFullAudited
    {
        public string Name { get; set; }
        public string ShortDecribtion { get; set; }
        public int Number { get; set; }
        public string Decribtion { get; set; }
        public string Image { get; set; }
        public string Covor { get; set; }
        public string Video { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime CreationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
