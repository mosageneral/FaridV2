using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaridV2.Domain
{
    public class Package : Entity, IFullAudited
    {
        public string Name { get; set; }
        public string Describtion { get; set; }
        public string ShortDescribtion { get; set; }
        public int Price { get; set; }
        public string Color { get; set; }
        public string Age { get; set; }
        public string CourseTime { get; set; }
        public decimal discountPrice { get; set; }
        public string ImageURL { get; set; }
        public string VideoURL { get; set; }
        public string PDFURL { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime CreationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public bool IsDeleted { get; set; }

    }
}
