using Bps.BpsBase.Entities.Concrete.ST;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bps.BpsBase.WebAPI.Controllers
{
    [Route("api/Stok/{action}", Name = "DataGridCustomEditors")]
    public class DataGridCustomEditorsController : ApiController
    {

        [HttpGet]
        public HttpResponseMessage Tasks(DataSourceLoadOptions loadOptions)
        {
            var sonuc = new List<STHRKT>();
            sonuc.Add(new STHRKT()
            {
                Id = 1,
                STKODU = "150.01.01",
                GNMKTR = 2
            });

            sonuc.Add(new STHRKT()
            {
                Id = 2,
                STKODU = "150.01.02",
                GNMKTR = 2
            });
            return Request.CreateResponse(DataSourceLoader.Load(sonuc, loadOptions));
        }



    }
}
