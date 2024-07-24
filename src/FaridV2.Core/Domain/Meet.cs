using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farid.Domains.LMS
{
    public class MeetAttendee : Entity, IFullAudited
    {
        public int AttendeeId { get; set; }
        public string AttendeeName { get; set; }
        public string AttendeePassword { get; set; }
        public string ItemId { get; set; }
        public int MeetId { get; set; }
        public Meet Meet { get; set; }
        public DateTime CreationDate { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime CreationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class Meet : Entity, IFullAudited
    {
        public string MeetTilte { get; set; }
        public string MeetDescribtion { get; set; }
        public string MeetingId { get; set; }
        public string AppointmentId { get; set; }
        public DateTime CreationDate { get; set; }
        public string InternalMeetingId { get; set; }
        public DateTime MeetStartingTime { get; set; }
        public DateTime MeetEndingTime { get; set; }
        public int MeetingDuration { get; set; }
        public int MeetModratorId { get; set; }
        public string MeetModratorName { get; set; }
        public string MeetModratorPassword { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime CreationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
