using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Netways.NetPays.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BillsController : ControllerBase
    {
        private readonly ILogger<BillsController> _logger;

        public BillsController(ILogger<BillsController> logger)
        {
            _logger = logger;
        }

        [HttpPost("UploadBill")]
        public IResult UploadBill([FromBody] SaddBillRequest saddBillRequest)
        {
            Log.Information("API Log.,{payload}", JsonConvert.SerializeObject(saddBillRequest));
            return Results.Ok(JsonConvert.DeserializeObject<SaddBillResponse>(@"{
    ""SuccessOperation"": true,
    ""ResponseCode"": 200,
    ""Result"": {
        ""TransactionID"": 36929,
        ""RequestID"": ""9d210309-37e4-43a4-9dfa-199b1e9564ed"",
        ""billUploadResponse"": null,
        ""Amount"": 100.0,
        ""BillNumber"": ""19042023"",
        ""BillCycle"": """",
        ""AccountNumber"": ""11223344"",
        ""DueDate"": ""2025-05-16T13:45:27.1743994+03:00"",
        ""ExpiryDate"": ""2025-07-20T13:45:27.1743994+03:00"",
        ""Customer"": {
            ""OfficialId"": ""2044907456"",
            ""OfficialIdType"": 1
        },
        ""CustomerName"": ""Abdaullah Khalid"",
        ""CustomerPhone"": ""0566666666"",
        ""CustomerEmail"": ""ahasan@test.com"",
        ""Notes"": """",
        ""BillCategory"": 1,
        ""BillSubCategory"": 2
    }
}"));

        }
    }
}
