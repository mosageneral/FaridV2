using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Castle.Windsor.Configuration.Interpreters.XmlProcessor.ElementProcessors;
using Farid.Domains.WalletEntities;
using FaridV2.Authorization.Users;
using FaridV2.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaridV2.Domains
{




    public class TeacherDaySlot : Entity, IFullAudited
    {

        public DayOfWeek DayOfWeek { get; set; }

        public long TeacherId { get; set; }

        public User Teacher { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime CreationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class TeacherTimeSlot : Entity, IFullAudited
    {
        public int TeacherDaySlotId { get; set; }
        public TeacherDaySlot TeacherDaySlot { get; set; }
        public TimeSpan FromTime { get; set; }
        public TimeSpan ToTime { get; set; }

        public long TeacherId { get; set; }

        public User Teacher { get; set; }
        public TimeSlotStatus TimeSlotStatus { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime CreationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public bool IsDeleted { get; set; }

    }

    public class Appointment : Entity, IFullAudited
    {

        public long? StudentId { get; set; }
        public User Student { get; set; }
        public long TeacherId { get; set; }
        public User Teacher { get; set; }
        public string AppointmentTitle { get; set; }
        public DateTime ScheduledTime { get; set; }
        public bool? IsManual { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime CreationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public bool IsDeleted { get; set; }

    }
}
