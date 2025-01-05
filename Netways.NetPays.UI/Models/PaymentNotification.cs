namespace Netways.NetPays.UI.Models
{
    public class PaymentNotification
    {
        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }

        public string BillNumber { get; set; }

        public string BillCycle { get; set; }

        public string PaymentMethod { get; set; }

        public string AccountNumber { get; set; }

        public string AccessChannel { get; set; }

        public string BankId { get; set; }

        public string DistrictCode { get; set; }

        public string BranchCode { get; set; }

        public string SPTN { get; set; }

        public string BNKPTN { get; set; }
    }
}
