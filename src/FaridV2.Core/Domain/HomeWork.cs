using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using FaridV2.Authorization.Users;
using FaridV2.Domains;
using FaridV2.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farid.Domains.LMS
{
    public class HomeWork : Entity, IFullAudited
    {
        public string Title { get; set; }
        public string Describtion { get; set; }
        public long TeacherId { get; set; }
        public User Teacher { get; set; }
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
        public long StudentId { get; set; }
        public User Student { get; set; }
        public DateTime CreatationDate { get; set; }
        public HomeWorkStatus Status { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime CreationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
