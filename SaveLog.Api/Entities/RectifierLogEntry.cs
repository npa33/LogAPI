using Amazon.Runtime.Documents;
using Contracts.Domains;
using Infrastructure.Extensions.MogoDb;
using MongoDB.Bson.Serialization.Attributes;
using System.Xml.Linq;

namespace SaveLog.Api.Entities
{
    [BsonCollection("RectifierLog")]
    public class RectifierLogEntry : MongoEntity
    {
        public RectifierLogEntry(string id)
        {
            Id = id;
        }
        [BsonElement("work_order")] public string WorkOrder { get; set; }
        [BsonElement("process")] public string Process { get; set; }
        //Mã lần đo
        [BsonElement("timesId")] public string TimesId { get; set; }
        [BsonElement("serial")] public string Serial { get; set; }
        [BsonElement("ac_volt")] public string AcVolt { get; set; }
        [BsonElement("dc_volt")] public int DcVolt { get; set; }
        [BsonElement("dc_curr")] public string DcCurr { get; set; }
        [BsonElement("curr_limit")] public string CurrLimit { get; set; }
        [BsonElement("temp")] public string Temp { get; set; }
        [BsonElement("pfc_ver")] public string PfcVer { get; set; }
        [BsonElement("llc_ver")] public string LlcVer { get; set; }
        [BsonElement("status_code")] public string StatusCode { get; set; }
    }
}
