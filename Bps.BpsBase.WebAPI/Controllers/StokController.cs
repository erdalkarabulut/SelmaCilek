using System;
using Bps.BpsBase.Business.Abstract.ST;
using Bps.BpsBase.Entities.Concrete.ST;
using Bps.Core.Web.Session;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Bps.BpsBase.Business.Abstract.WM;
using Bps.BpsBase.Business.Abstract.XX;
using Bps.BpsBase.Entities.Concrete.WM;
using Bps.BpsBase.Entities.Models.ST.Single;
using Bps.BpsBase.Entities.Models.ST.Api;
using Bps.BpsBase.Entities.Models.ST.Listed;
using Bps.BpsBase.Entities.Models.WM.Api;
using Bps.Core.GlobalStaticsVariables;
using Bps.Core.Response;
using BPS.Windows.Forms;
using DevExpress.XtraReports.UI;
using DevExtreme.AspNet.Mvc;
using Newtonsoft.Json;
using System.Management;
using System.Runtime.Remoting.Messaging;
using Bps.BpsBase.Business.Abstract.SP;
using Bps.BpsBase.Entities.Concrete.SP;
using Bps.BpsBase.Entities.Models.SP.Listed;
using DevExpress.XtraPrinting;

namespace Bps.BpsBase.WebAPI.Controllers
{
    [Route("api/StokKart/{action}", Name = "StokKartApi")]
    public class StokController : ApiController
    {
        protected ISthrktService _sthrktService;
        protected ISpfharService _spfharService;
        protected IStkartService _stkartService;
        protected IStftipService _stftipService;
        protected IStdepoService _stdepoService;
        protected ISprezvService _sprezvService;
        protected IWmhratService _wmhratService;
        protected IXXService _xxService;

        private short _etiketAdedi;

        public StokController(ISthrktService sthrktService, ISpfharService spfharService, IStkartService stkartService, IStftipService stftipService, ISprezvService sprezvService, IXXService xxService, IStdepoService stdepoService, IWmhratService wmhratService)
        {
            _sthrktService = sthrktService;
            _spfharService = spfharService;
            _stkartService = stkartService;
            _stftipService = stftipService;
            _sprezvService = sprezvService;
            _xxService = xxService;
            _stdepoService = stdepoService;
            _wmhratService = wmhratService;
        }

        public StokController()
        {

        }

        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<STHRKT> GetStokHarekets(DataSourceLoadOptions loadOptions)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            return _sthrktService.Cch_GetList_NLog(global, false).Items;
        }

        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<STKART> GetStoks(DataSourceLoadOptions loadOptions)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            return _stkartService.Cch_GetList_NLog(global, false).Items;
        }

        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public StandardResponse<STKART> GetStokByKod(List<dynamic> data)
        {
            Global global = JsonConvert.DeserializeObject<Global>(data[0].ToString());
            string stokKodu = data[1].ToString();

            var response = _stkartService.Ncch_GetByStKod_NLog(stokKodu, global, false);

            if (response.Status == ResponseStatusEnum.OK)
            {
                response.Message = "";
                response.ErrorCode = "";
                response.ErrorMessage = "";
                response.RequestMessage = "";
            }

            return response;
        }

        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public StandardResponse SaveStokHareket(List<dynamic> data)
        {
            Global global = JsonConvert.DeserializeObject<Global>(data[0].ToString());
            int stftno = Convert.ToInt32(data[1]);
            string girisDepoKodu = data[2].ToString();
            string cikisDepoKodu = data[3].ToString();
            string kaynakWmAdres = data[4].ToString();
            string hedefWmAdres = data[5].ToString();
            List<StokMiktarModel> stokList = JsonConvert.DeserializeObject<List<StokMiktarModel>>(data[6].ToString());
            string evrakNo = data[7].ToString();
            string teslimAlan = data[8].ToString();

            var response = new StandardResponse();
            var model = new StokHareketModel();

            STFTIP fisTip = _stftipService.Cch_GetByFisTipNo_NLog(stftno, global, false).Nesne;
            if (fisTip != null)
            {
                model.Baslik = new STHBAS
                {
                    ACTIVE = true,
                    SIRKID = global.SirketId.Value,
                    SLINDI = false,
                    STHRTP = fisTip.STHRTP,
                    STFTNO = stftno,
                    BELTRH = DateTime.Now,
                    CHKCTR = false,
                    GRDEPO = girisDepoKodu == "" ? null : girisDepoKodu,
                    CKDEPO = cikisDepoKodu == "" ? null : cikisDepoKodu,
                    EVRAKN = evrakNo == "" ? null : evrakNo,
                    EKKULL = global.UserKod,
                    ETARIH = DateTime.Now,
                    KYNKKD = "5"
                };

                model.KaynakWmAdresList = new List<string>();
                model.HedefWmAdresList = new List<string>();

                WMHRAT wmhrat = _wmhratService.Cch_GetByFisTip_NLog(stftno, global, false).Nesne;

                model.Kalemler = new List<STHRKT>();

                for (int i = 0; i < stokList.Count; i++)
                {
                    if (wmhrat != null && kaynakWmAdres != null && kaynakWmAdres != "")
                    {
                        model.KaynakWmAdresList.Add(kaynakWmAdres);
                    }
                    if (wmhrat != null && hedefWmAdres != null && hedefWmAdres != "")
                    {
                        model.HedefWmAdresList.Add(hedefWmAdres);
                    }

                    var stk = stokList[i];

                    //if (string.IsNullOrEmpty(stk.Parti))
                    //{
	                   // response.Status = ResponseStatusEnum.ERROR;
	                   // response.Message = stk.Stkart.STKODU + " - " + stk.Stkart.STKNAM + Environment.NewLine + "için parti girmediniz!";
	                   // return response;
                    //}

                    model.Kalemler.Add(new STHRKT
                    {
                        GRMKTR = Convert.ToDecimal(stk.Miktar),
                        GROLBR = stk.Stkart.OLCUKD,
                        SATIRN = i + 1,
                        STKNAM = stk.Stkart.STKNAM,
                        STKODU = stk.Stkart.STKODU,
                        PARTIT = stk.Stkart.PARTIT,
                        PARTIN = stk.Parti != "" ? stk.Parti : null,
                        TSALAN = teslimAlan == "" ? null : teslimAlan
                    });
                }

                switch (fisTip.FUNCNM)
                {
                    case "Ncch_StokSayim_Log":
                        response = _xxService.Ncch_StokSayim_Log(model, global, false);
                        break;
                    case "Ncch_StokMalGirisCikis_Log":
                        response = _xxService.Ncch_StokMalGirisCikis_Log(model, global, false);
                        break;
                    case "Ncch_StokDepoTransfer_Log":
                        response = _xxService.Ncch_StokDepoTransfer_Log(model, global, false);
                        break;
                }
            }
            else
            {
                response.Status = ResponseStatusEnum.ERROR;
                response.Message = "Stok Fiş Tipi bulunamadı!";
            }

            if (response.Status == ResponseStatusEnum.OK)
            {
                response.Message = "";
                response.ErrorCode = "";
                response.ErrorMessage = "";
                response.RequestMessage = "";
            }

            return response;
        }

        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public StandardResponse SaveSatisStokCikis(List<dynamic> data)
        {
            Global global = JsonConvert.DeserializeObject<Global>(data[0].ToString());
            SPFBAS spfbas = JsonConvert.DeserializeObject<SPFBAS>(data[1].ToString());
            List<SiparisStokModel> stokList = JsonConvert.DeserializeObject<List<SiparisStokModel>>(data[2].ToString());

            var response = new StandardResponse();
            var model = new StokHareketModel();

            if (stokList.Count == 0)
            {
                response.Status = ResponseStatusEnum.ERROR;
                response.Message = "Stok seçilmedi!";
                return response;
            }

            stokList = stokList
                .GroupBy(s => new { s.STKODU, s.CKDEPO, s.DPADRS, s.GRDEPO, s.OLCUKD, s.PARTIN, s.SATIRN, s.SRBLNO })
                .Select(group => new SiparisStokModel
                {
                    STKODU = group.Key.STKODU,
                    CKDEPO = group.Key.CKDEPO,
                    DPADRS = group.Key.DPADRS,
                    GRDEPO = group.Key.GRDEPO,
                    OLCUKD = group.Key.OLCUKD,
                    PARTIN = group.Key.PARTIN,
                    SATIRN = group.Key.SATIRN,
                    SRBLNO = group.Key.SRBLNO,
                    GRMKTR = group.Sum(item => item.GRMKTR)
                }).ToList();

            int stftno = 12;

            STFTIP fisTip = _stftipService.Cch_GetByFisTipNo_NLog(stftno, global, false).Nesne;
            if (fisTip != null)
            {
                model.Baslik = new STHBAS
                {
                    ACTIVE = true,
                    SIRKID = global.SirketId.Value,
                    SLINDI = false,
                    STHRTP = fisTip.STHRTP,
                    STFTNO = stftno,
                    BELTRH = DateTime.Now,
                    CHKCTR = false,
                    GRDEPO = null,
                    CKDEPO = stokList[0].CKDEPO, //Farklı depolardan çıkış olursa kaldırılacak
                    EKKULL = global.UserKod,
                    ETARIH = DateTime.Now,
                    KYNKKD = "5"
                };

                model.KaynakWmAdresList = new List<string>();
                model.HedefWmAdresList = new List<string>();

                List<SPFHAR> siparisKalems = _spfharService.Cch_GetListByBelge_NLog(spfbas.BELGEN, global).Items;
                List<SPREZV> rezervasyonKalems =
                    _sprezvService.Ncch_GetListBySiparisBelgeNo_NLog(global, spfbas.BELGEN, false).Items;

                List<SPFHAR> islemGorenSiparisList = new List<SPFHAR>();
                List<SPREZV> islemGorenRezervasyonList = new List<SPREZV>();

                model.Kalemler = new List<STHRKT>();

                int satirNo = 0;
                foreach (SiparisStokModel sipStok in stokList)
                {
                    string modulKodu = sipStok.STKODU.Substring(0, 10);
                    SPFHAR spfhar = siparisKalems.Find(s => s.SATIRN == sipStok.SATIRN && s.STKODU == modulKodu);
                    STKART stkart = _stkartService.Ncch_GetByStKod_NLog(sipStok.STKODU, global, false).Nesne;

                    if (islemGorenSiparisList.FirstOrDefault(s => s.STKODU == modulKodu) == null)
                    {
                        islemGorenSiparisList.Add(spfhar.ShallowCopy());
                    }

                    if (sipStok.STKODU.Last() == '1') //Miktarı ilk paketten al
                    {
                        islemGorenSiparisList[islemGorenSiparisList.Count - 1].KLNMKTR -= sipStok.GRMKTR;
                        if (islemGorenSiparisList[islemGorenSiparisList.Count - 1].KLNMKTR < 1)
                        {
                            islemGorenSiparisList[islemGorenSiparisList.Count - 1].KLNMKTR = 0;
                            islemGorenSiparisList[islemGorenSiparisList.Count - 1].FLGKPN = true;
                        }
                    }

                    SPREZV sprezv = islemGorenRezervasyonList.FirstOrDefault(s =>
                        s.BELGEN == sipStok.SRBLNO && s.STKODU == sipStok.STKODU && s.SATIRN == sipStok.SATIRN);

                    if (sprezv == null)
                    {
                        sprezv = rezervasyonKalems.FirstOrDefault(s =>
                            s.BELGEN == sipStok.SRBLNO && s.STKODU == sipStok.STKODU && s.SATIRN == sipStok.SATIRN).ShallowCopy();
                        islemGorenRezervasyonList.Add(sprezv);
                    }

                    sprezv.KLMKTR -= sipStok.GRMKTR;

                    satirNo++;
                    var sthrkt = new STHRKT();
                    sthrkt.SATIRN = satirNo;
                    sthrkt.STKODU = stkart.STKODU;
                    sthrkt.STKNAM = stkart.STKNAM;
                    sthrkt.STFTNO = fisTip.STFTNO;
                    sthrkt.STHRTP = fisTip.STHRTP;
                    sthrkt.GNMKTR = sipStok.GRMKTR;
                    sthrkt.GRMKTR = sipStok.GRMKTR;
                    sthrkt.OLCUKD = stkart.OLCUKD;
                    sthrkt.GROLBR = stkart.OLCUKD;
                    sthrkt.CKDEPO = sipStok.CKDEPO;
                    sthrkt.USTBLG = spfhar.BELGEN;
                    sthrkt.USTKLM = spfhar.SATIRN;
                    sthrkt.PARTIT = stkart.PARTIT;
                    sthrkt.SADEGK = spfhar.SADEGK = stkart.SADEGK;

                    if (spfhar.FLGKPN != null && spfhar.FLGKPN.Value) sthrkt.SLINDI = true;

                    if (sthrkt.SLINDI || sipStok.GRMKTR == 0)
                    {
                        model.KaynakWmAdresList.Add("");
                        model.Kalemler.Add(sthrkt);
                        continue;
                    }

                    //if (kalem.GRMKTR == null)
                    //{
                    //    MessageBox.Show(kalem.STKODU + " - " + kalem.STKNAM + Environment.NewLine + "için miktar girmediniz!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    return;
                    //}

                    //Terminale parti ekleyince açılacak
                    //if (kalem.PARTIT.HasValue && kalem.PARTIT.Value && string.IsNullOrEmpty(kalem.PARTIN))
                    //{
                    //    MessageBox.Show(kalem.STKODU + " - " + kalem.STKNAM + Environment.NewLine + "için parti girmediniz!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    return;
                    //}

                    WMHRAT wmhrat = _wmhratService.Cch_GetByFisTip_NLog(stftno, global, false).Nesne;
                    if (wmhrat != null)
                    {
                        if (sipStok.DPADRS != null) model.KaynakWmAdresList.Add(sipStok.DPADRS);
                        else
                        {
                            response.Status = ResponseStatusEnum.ERROR;
                            response.Message = sthrkt.STKODU + " - " + sthrkt.STKNAM + Environment.NewLine + "giriş depo adresi seçilmedi!";
                            return response;
                        }
                    }
                    else
                    {
                        response.Status = ResponseStatusEnum.ERROR;
                        response.Message = "Satış siparişi stok çıkışı için WM hareket ataması bulunamadı!";
                        return response;
                    }

                    model.Kalemler.Add(sthrkt);
                }

                if (model.Kalemler.Count == 0)
                {
                    response.Status = ResponseStatusEnum.ERROR;
                    response.Message = "Stok seçmediniz!";
                    return response;
                }

                model.SiparisList = islemGorenSiparisList;
                model.RezervasyonList = islemGorenRezervasyonList;

                response = _xxService.Ncch_StokMalGirisCikis_Log(model, global, false);
            }
            else
            {
                response.Status = ResponseStatusEnum.ERROR;
                response.Message = "Stok Fiş Tipi bulunamadı!";
            }

            if (response.Status == ResponseStatusEnum.OK)
            {
                response.Message = "";
                response.ErrorCode = "";
                response.ErrorMessage = "";
                response.RequestMessage = "";
            }

            return response;
        }

        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public StandardResponse SaveSatinalmaStokGiris(List<dynamic> data)
        {
            Global global = JsonConvert.DeserializeObject<Global>(data[0].ToString());
            SPFBAS spfbas = JsonConvert.DeserializeObject<SPFBAS>(data[1].ToString());
            SpBaslikAcikModel sipAcikModel = JsonConvert.DeserializeObject<SpBaslikAcikModel>(data[1].ToString());
            List<SiparisStokModel> saSiparisStokList = JsonConvert.DeserializeObject<List<SiparisStokModel>>(data[2].ToString());

            var response = new StandardResponse();
            var model = new StokHareketModel();

            int stftno = 4;
            if (sipAcikModel.GRDPWM == "WM") stftno = 10;

            STFTIP fisTip = _stftipService.Cch_GetByFisTipNo_NLog(stftno, global, false).Nesne;
            if (fisTip != null)
            {
                model.Baslik = new STHBAS
                {
                    ACTIVE = true,
                    SIRKID = global.SirketId.Value,
                    SLINDI = false,
                    STHRTP = fisTip.STHRTP,
                    STFTNO = stftno,
                    BELTRH = DateTime.Now,
                    CHKCTR = false,
                    GRDEPO = "", //girisDepoKodu == "" ? null : girisDepoKodu,
                    CKDEPO = null,
                    EVRAKN = spfbas.EVRAKN == "" ? null : spfbas.EVRAKN,
                    EKKULL = global.UserKod,
                    ETARIH = DateTime.Now,
                    KYNKKD = "5"
                };

                model.KaynakWmAdresList = new List<string>();
                model.HedefWmAdresList = new List<string>();

                WMHRAT wmhrat = _wmhratService.Cch_GetByFisTip_NLog(stftno, global, false).Nesne;
                var siparisKalems = _spfharService.Cch_GetListByBelge_NLog(spfbas.BELGEN, global).Items;

                model.Kalemler = new List<STHRKT>();

                int satirNo = 0;
                foreach (SiparisStokModel sipStok in saSiparisStokList)
                {
                    SPFHAR spfhar = siparisKalems.Find(s => s.SATIRN == sipStok.SATIRN && s.STKODU == sipStok.STKODU);
                    STKART stkart = _stkartService.Ncch_GetByStKod_NLog(sipStok.STKODU, global, false).Nesne;

                    if (sipStok.PARTIT && string.IsNullOrEmpty(sipStok.PARTIN))
                    {
	                    response.Status = ResponseStatusEnum.ERROR;
	                    response.Message = spfhar.STKODU + " - " + spfhar.STKNAM + Environment.NewLine + "için parti girmediniz!";
	                    return response;
                    }

                    satirNo++;
                    var sthrkt = new STHRKT();
                    sthrkt.SATIRN = satirNo;
                    sthrkt.STKODU = spfhar.STKODU;
                    sthrkt.STKNAM = spfhar.STKNAM;
                    sthrkt.STFTNO = fisTip.STFTNO;
                    sthrkt.STHRTP = fisTip.STHRTP;
                    sthrkt.GNMKTR = spfhar.GNMKTR;
                    sthrkt.GRMKTR = sipStok.GRMKTR;
                    sthrkt.OLCUKD = spfhar.OLCUKD;
                    sthrkt.GROLBR = spfhar.GROLBR;
                    sthrkt.GRDEPO = spfhar.GRDEPO;
                    sthrkt.GNTUTR = spfhar.GNTUTR;
                    sthrkt.VRGORN = spfhar.VRGORN;
                    sthrkt.VRGTUT = spfhar.VRGTUT;
                    sthrkt.VRGSIZ = spfhar.VRGSIZ;
                    sthrkt.OTVORN = spfhar.OTVORN;
                    sthrkt.OTVTUT = spfhar.OTVTUT;
                    sthrkt.MLKBTR = spfhar.MLKBTR;
                    sthrkt.USTBLG = spfhar.BELGEN;
                    sthrkt.USTKLM = spfhar.SATIRN;
                    sthrkt.PARTIT = stkart.PARTIT;
                    sthrkt.PARTIN = sipStok.PARTIT ? sipStok.PARTIN : null;
                    sthrkt.SADEGK = spfhar.SADEGK = stkart.SADEGK;

                    if (spfhar.FLGKPN != null && spfhar.FLGKPN.Value) sthrkt.SLINDI = true;

                    if (sthrkt.SLINDI || sipStok.GRMKTR == 0)
                    {
                        model.HedefWmAdresList.Add("");
                        model.Kalemler.Add(sthrkt);
                        continue;
                    }

                    //if (kalem.GRMKTR == null)
                    //{
                    //    MessageBox.Show(kalem.STKODU + " - " + kalem.STKNAM + Environment.NewLine + "için miktar girmediniz!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    return;
                    //}

                    //Terminale parti ekleyince açılacak
                    if (sthrkt.PARTIT.HasValue && sthrkt.PARTIT.Value && string.IsNullOrEmpty(sthrkt.PARTIN))
                    {
	                    response.Status = ResponseStatusEnum.ERROR;
	                    response.Message = sthrkt.STKODU + " - " + sthrkt.STKNAM + Environment.NewLine + "için parti girmediniz!";
	                    return response;
                    }

                    if (wmhrat != null)
                    {
                        if (sipStok.DPADRS != null) model.HedefWmAdresList.Add(sipStok.DPADRS);
                        else
                        {
                            response.Status = ResponseStatusEnum.ERROR;
                            response.Message = sthrkt.STKODU + " - " + sthrkt.STKNAM + Environment.NewLine + "giriş depo adresi seçilmedi!";
                            return response;
                        }
                    }

                    model.Kalemler.Add(sthrkt);
                }

                if (model.Kalemler.Count == 0)
                {
                    response.Status = ResponseStatusEnum.ERROR;
                    response.Message = "Stok seçmediniz!";
                    return response;
                }

                decimal? toplamGiren = model.Kalemler.Sum(k => k.GRMKTR);
                if (toplamGiren == null || toplamGiren == 0)
                {
                    response.Status = ResponseStatusEnum.WARNING;
                    response.Message = "Geçerli miktar ve adres girişi yapılmadı!";
                    return response;
                }

                response = _xxService.Ncch_SasGiris_Log(model, global, false);

                if (response.Status != ResponseStatusEnum.OK)
                {
                    return response;
                }
            }

            return response;
        }

        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public StandardResponse SaveStokAdresTransfer(List<dynamic> data)
        {
            Global global = JsonConvert.DeserializeObject<Global>(data[0].ToString());
            List<StokAdresTransferModel> satmList = JsonConvert.DeserializeObject<List<StokAdresTransferModel>>(data[1].ToString());

            var response = _xxService.Ncch_StokAdresTransferWm_Log(satmList, global, false);

            if (response.Status == ResponseStatusEnum.OK)
            {
                response.Message = "";
                response.ErrorCode = "";
                response.ErrorMessage = "";
                response.RequestMessage = "";
            }

            return response;
        }

        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public ListResponse<StokKodAdModel> GetStokListByStokAdi(List<dynamic> data)
        {
            Global global = JsonConvert.DeserializeObject<Global>(data[0].ToString());
            List<string> filterList = JsonConvert.DeserializeObject<List<string>>(data[1].ToString());

            var response = new ListResponse<StokKodAdModel> { Items = new List<StokKodAdModel>() };
            response.Status = ResponseStatusEnum.OK;

            if (filterList != null && filterList.Count > 0) response = _stkartService.GetStokKodAd(global, filterList, false);
            if (response.Status == ResponseStatusEnum.OK)
            {
                response.Message = "";
                response.ErrorCode = "";
                response.ErrorMessage = "";
                response.RequestMessage = "";
            }

            return response;
        }

        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public ListResponse<StdepoStokAdresModel> GetStokAdresList(List<dynamic> data)
        {
            Global global = JsonConvert.DeserializeObject<Global>(data[0].ToString());
            List<string> filterList = JsonConvert.DeserializeObject<List<string>>(data[1].ToString());
            string adres = filterList[0];
            string stokKodu = filterList[1];

            var response = new ListResponse<StdepoStokAdresModel> { Items = new List<StdepoStokAdresModel>() };
            if (string.IsNullOrEmpty(adres) && string.IsNullOrEmpty(stokKodu))
            {
                response.Status = ResponseStatusEnum.ERROR;
                response.Message = "Adres bilgisi boş olamaz!";
                return response;
            }

            response = _stdepoService.GetStokAdresRapor(global, adres, stokKodu, false);

            if (response.Status == ResponseStatusEnum.OK)
            {
                response.Message = "";
                response.ErrorCode = "";
                response.ErrorMessage = "";
                response.RequestMessage = "";
            }

            return response;
        }

        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public ListResponse<StdepoStokMiktarModel> GetStokMiktarList(List<dynamic> data)
        {
            //Global global = JsonConvert.DeserializeObject<Global>(data[0].ToString());
            //string stokKodu = data[1].ToString();

            Global global = JsonConvert.DeserializeObject<Global>(data[0].ToString());
            List<string> filterList = JsonConvert.DeserializeObject<List<string>>(data[1].ToString());
            string stokKodu = filterList[1];

            var response = new ListResponse<StdepoStokMiktarModel> { Items = new List<StdepoStokMiktarModel>() };
            if (string.IsNullOrEmpty(stokKodu))
            {
                response.Status = ResponseStatusEnum.ERROR;
                response.Message = "Stok Kodu boş olamaz!";
                return response;
            }

            response = _stdepoService.GetStokMiktarRapor(global, stokKodu, yetkiKontrol: false);

            if (response.Status == ResponseStatusEnum.OK)
            {
                response.Message = "";
                response.ErrorCode = "";
                response.ErrorMessage = "";
                response.RequestMessage = "";
            }

            return response;
        }


        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public ListResponse<SthrktStokHareketModel> GetStokHareketRapor(List<dynamic> data)
        {
            Global global = JsonConvert.DeserializeObject<Global>(data[0].ToString());
            int itemCount = JsonConvert.DeserializeObject<int>(data[1].ToString());

            var response = new ListResponse<SthrktStokHareketModel> { Items = new List<SthrktStokHareketModel>() };

            var date1 = DateTime.Now.AddDays(-30);
            var date2 = DateTime.Now;

            response = _sthrktService.GetStokHareketRapor(date1, date2, global, false);

            if (response.Status == ResponseStatusEnum.OK)
            {
                response.Message = "";
                response.ErrorCode = "";
                response.ErrorMessage = "";
                response.RequestMessage = "";
            }

            return response;
        }

        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public ListResponse<SthrktStokHareketModel> GetModulPaketUrunAgaci()
        {
            List<string> data = new List<string>();
            Global global = JsonConvert.DeserializeObject<Global>(data[0].ToString());
            int itemCount = JsonConvert.DeserializeObject<int>(data[1].ToString());

            var response = new ListResponse<SthrktStokHareketModel> { Items = new List<SthrktStokHareketModel>() };

            var date1 = DateTime.Now.AddYears(-5);
            var date2 = DateTime.Now;

            response = _sthrktService.GetStokHareketRapor(date1, date2, global, false);

            if (response.Status == ResponseStatusEnum.OK)
            {
                response.Message = "";
                response.ErrorCode = "";
                response.ErrorMessage = "";
                response.RequestMessage = "";
            }

            return response;
        }

        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<string> GetEtiketSablonPaths(DataSourceLoadOptions loadOptions)
        {
            //string path = @"C:\EFIBALA\";
            //string path = @"D:\GDrive\Projects\_BitBucket\BPS\Bps.BpsBase.WinForm\bin\Debug\";
            string path = AppDomain.CurrentDomain.BaseDirectory;
            var list = Directory.GetFiles(path, "*.repx", SearchOption.TopDirectoryOnly).ToList();
            return list;
        }

        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<string> GetPrinters(DataSourceLoadOptions loadOptions)
        {
            List<string> printers = new List<string>();
            ManagementScope objScope = new ManagementScope(ManagementPath.DefaultPath); //For the local Access
            objScope.Connect();

            SelectQuery selectQuery = new SelectQuery();
            selectQuery.QueryString = "Select * from win32_Printer";
            ManagementObjectSearcher MOS = new ManagementObjectSearcher(objScope, selectQuery);
            ManagementObjectCollection MOC = MOS.Get();
            foreach (ManagementObject mo in MOC) printers.Add(mo["Name"].ToString());

            return printers;
        }

        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public StandardResponse<bool> PrintStokEtiket(List<dynamic> data)
        {
            List<object> printData = JsonConvert.DeserializeObject<List<object>>(data[0].ToString());

            List<string> etiketData = JsonConvert.DeserializeObject<List<string>>(printData[0].ToString());
            string printerName = printData[1].ToString();
            string etiketSablonPath = printData[2].ToString();
            _etiketAdedi = 1;
            short.TryParse(printData[3].ToString(), out _etiketAdedi);

            var response = new StandardResponse<bool>();
            if (string.IsNullOrEmpty(etiketSablonPath) || string.IsNullOrEmpty(etiketData[0]) || string.IsNullOrEmpty(etiketData[1]))
            {
                response.Status = ResponseStatusEnum.ERROR;
                response.Message = "Etiket Şablonu, Stok Kodu ve Stok Adı boş olamaz.";
                response.Nesne = false;
                return response;
            }

            try
            {
                var rEtiket = XtraReport.FromFile(etiketSablonPath) as repBarkodEtiket;
                rEtiket.lblStokAdi.Text = etiketData[1];
                rEtiket.xrBarcode.Text = etiketData[0];

                rEtiket.PrintingSystem.StartPrint += new PrintDocumentEventHandler(PrintingSystem_StartPrint);
                rEtiket.Print(printerName);

                response.Message = "";
                response.ErrorMessage = "";
                response.Nesne = true;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.ErrorMessage = e.Message;
                response.Nesne = false;
            }

            return response;
        }

        private void PrintingSystem_StartPrint(object sender, PrintDocumentEventArgs e)
        {
            e.PrintDocument.PrinterSettings.Copies = _etiketAdedi;
            _etiketAdedi = 1;
        }
    }
}
