using System;
using System.Collections.Generic;
using System.Linq;
using Bps.Core.Entities;

namespace Bps.BpsBase.Entities.Models.SH.Firestore
{
    [Serializable]
    public class WorkOrder : IFirestoreEntity
    {
        public string DocumentId { get; set; }
        public int SIRKID { get; set; }
        public string BELGEN { get; set; }
        public DateTime BELTRH { get; set; }
        public DateTime? SRTLTR { get; set; }
        public string CRKODU { get; set; }
        public string CRUNVN { get; set; }
        public string CRADRS { get; set; }
        public string CRTLFN { get; set; }
        public string CRYTKL { get; set; }
        public string TLPACN { get; set; }
        public string SRVTUR { get; set; }
        public string SRVDRM { get; set; }
        public string GRNDRM { get; set; }
        public string MKNDRM { get; set; }
        public DateTime? MKKRTR { get; set; }
        public int SRPRID { get; set; }
        public string SRVPRS { get; set; }
        public string URKTGR { get; set; }
        public string URMODL { get; set; }
        public string URSERI { get; set; }
        public string URSASI { get; set; }
        public string PRBTNM { get; set; }
        public string PRBTSP { get; set; }
        public string AKSYON { get; set; }
        public string ONYLYN { get; set; }
        public DateTime? SRBSTR { get; set; }
        public DateTime? SRBTTR { get; set; }

        public Dictionary<string, object> Serialize()
        {
            return this.GetType().GetProperties().ToDictionary(property => property.Name, property => property.GetValue(this));
        }

        public IFirestoreEntity Deserialize(Dictionary<string, object> map)
        {
            WorkOrder workOrder = new WorkOrder
            {
                SIRKID = Convert.ToInt32(map["SIRKID"]),
                BELGEN = map["BELGEN"].ToString(),
                //BELTRH = null,
                //SRTLTR = null,
                CRKODU = map["CRKODU"].ToString(),
                CRUNVN = map["CRUNVN"].ToString(),
                CRADRS = map["CRADRS"].ToString(),
                CRTLFN = map["CRTLFN"].ToString(),
                CRYTKL = map["CRYTKL"].ToString(),
                TLPACN = map["TLPACN"].ToString(),
                SRVTUR = map["SRVTUR"].ToString(),
                SRVDRM = map["SRVDRM"].ToString(),
                GRNDRM = map["GRNDRM"].ToString(),
                MKNDRM = map["MKNDRM"].ToString(),
                //MKKRTR = null,
                SRPRID = Convert.ToInt32(map["SRPRID"]),
                SRVPRS = map["SRVPRS"].ToString(),
                URKTGR = map["URKTGR"].ToString(),
                URMODL = map["URMODL"].ToString(),
                URSERI = map["URSERI"].ToString(),
                URSASI = map["URSASI"].ToString(),
                PRBTNM = map["PRBTNM"].ToString(),
                PRBTSP = map["PRBTSP"].ToString(),
                AKSYON = map["AKSYON"].ToString(),
                ONYLYN = map["ONYLYN"].ToString(),
                //SRBSTR = null,
                //SRBTTR = null,
            };

            return workOrder;
        }
    }
}