namespace Netways.NetPays.UI.Models
{
    public class SaddBillResponse
    {
        public bool SuccessOperation { get; set; }
        public int ResponseCode { get; set; }
        public Result Result { get; set; }
    }
    public class Result
    {
        public int TransactionID { get; set; }
        public string RequestID { get; set; }
        public object billUploadResponse { get; set; }
        public float Amount { get; set; }
        public string BillNumber { get; set; }
        public string BillCycle { get; set; }
        public string AccountNumber { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public RCustomer Customer { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public string Notes { get; set; }
        public int BillCategory { get; set; }
        public int BillSubCategory { get; set; }
    }
    public class RCustomer
    {
        public string OfficialId { get; set; }
        public int OfficialIdType { get; set; }
    }
}
