namespace Netways.NetPays.UI.Models
{
    public class SaddBillRequest
    {
        public float Amount { get; set; }
        public string BillNumber { get; set; }
        public string BillCycle { get; set; }
        public string AccountNumber { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public Customer Customer { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public string Notes { get; set; }
        public int BillCategory { get; set; }
        public int BillSubCategory { get; set; }
    }
    public class Customer
    {
        public string OfficialId { get; set; }
        public int OfficialIdType { get; set; }
    }
}
