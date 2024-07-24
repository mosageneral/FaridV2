using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using FaridV2.Authorization.Users;
using FaridV2.Domain;
using FaridV2.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Farid.Domains.WalletEntities
{
    public class Order : Entity, IFullAudited
    {
        public long? StudentId { get; set; }
        public User Student { get; set; }
        public long TeacherId { get; set; }
        public User Teacher { get; set; }
        public long? ParentId { get; set; }
        public User Parent { get; set; }
        public List<int> Timeslots { get; set; }
        public List<int> DaySlots { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime CreationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
