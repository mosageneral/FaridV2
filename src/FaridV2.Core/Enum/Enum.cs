using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaridV2.Enums
{
    public enum Gender
    {
        Male = 0,
        Female
    }
    public enum WalletPaymentType
    {
        Payment = 0,
        AddedFund,
        OfflineRecharge,
        Transfare,
        noType
    }
    public enum WalletTransactionType
    {
        Debit,
        Credit
    }
    public enum OrderStatus
    {
        UnPaid,
        Pending,
        Approved,
        Rejected
    }
    public enum HomeWorkStatus
    {
        Pending,
        Done
    }
    public enum TimeSlotStatus
    {
        Available = 1, Unavailable = 2
    }
    public enum AppointmentStatus
    {
        UnDone = 1, Done = 2, Inprogress = 3
    }
}
