using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using FaridV2.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farid.Domains.WalletEntities
{
    public class Transaction : Entity<int>, IFullAudited
    {
        public int WalletToId { get; set; }
        public Wallet WalletTo { get; set; }
        public WalletPaymentType PaymentType { get; set; }
        public WalletTransactionType TransactionType { get; set; }
        public decimal Amount { get; set; }
        public string TransactionId { get; set; }
        public double CurrentBalance { get; set; }
        public string TransactionNote { get; set; }
        public DateTime Date { get; set; }
        public int WalletFromId { get; set; }
        public Wallet WalletFrom { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime CreationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
