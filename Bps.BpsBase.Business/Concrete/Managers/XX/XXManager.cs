using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.Abstract.ST;
using Bps.BpsBase.Business.Abstract.UA;
using Bps.BpsBase.Business.Abstract.UR;
using Bps.BpsBase.Business.Abstract.WM;
using Bps.BpsBase.Business.Abstract.XX;
using Bps.BpsBase.Business.DependencyResolvers.Exception;
using Bps.BpsBase.Business.ValidationRules.FluentValidation.SP;
using Bps.BpsBase.Business.ValidationRules.FluentValidation.ST;
using Bps.BpsBase.DataAccess.Abstract.SA;
using Bps.BpsBase.DataAccess.Abstract.SP;
using Bps.BpsBase.DataAccess.Abstract.ST;
using Bps.BpsBase.DataAccess.Abstract.TS;
using Bps.BpsBase.DataAccess.Abstract.WM;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.BpsBase.Entities.Concrete.SP;
using Bps.BpsBase.Entities.Concrete.ST;
using Bps.BpsBase.Entities.Concrete.WM;
using Bps.BpsBase.Entities.Models.GN.Single;
using Bps.BpsBase.Entities.Models.SP.Single;
using Bps.BpsBase.Entities.Models.ST.Single;
using Bps.BpsBase.Entities.Models.TS;
using Bps.BpsBase.Entities.Models.WM.Api;
using Bps.Core.Aspects.Postsharp.CacheAspects;
using Bps.Core.Aspects.Postsharp.ValidationAspects;
using Bps.Core.CrossCuttingConcerns.Caching.Microsoft;
using Bps.Core.GlobalStaticsVariables;
using Bps.Core.Response;
using Bps.Core.Utilities.WinForm;
using Bps.BpsBase.Business.ValidationRules.FluentValidation.TS;
using Bps.BpsBase.DataAccess.Abstract;
using Bps.BpsBase.DataAccess.Abstract.GN;
using Bps.BpsBase.DataAccess.Abstract.IS;
using Bps.BpsBase.DataAccess.Abstract.UA;
using Bps.BpsBase.Entities.Concrete.IS;
using Bps.BpsBase.Entities.Concrete.UA;
using Bps.BpsBase.Entities.Concrete.UR;
using Bps.BpsBase.Entities.Models.ST.Listed;
using Bps.BpsBase.Entities.Models.UA;
using System.Reflection;
using Bps.BpsBase.Entities.Concrete.CM;
using Bps.Core.AttributeHelpers;

namespace Bps.BpsBase.Business.Concrete.Managers.XX
{
    public class XXManager : IXXService
    {
        private IStkartDal _stkartDal;
        private IStnameDal _stname;
        private IStdepoDal _stdepoDal;
        private IStdepvDal _stdepvDal;
        private IStmhsbDal _stmhsbDal;
        private IStsaleDal _stsaleDal;
        private IStolcuDal _stolcuDal;
        private IStkmizDal _stkmizDal;
        private IStvmizDal _stvmizDal;
        private IStkmihDal _stkmihDal;
        private ISturyrDal _sturyrDal;
        private ISthrktDal _sthrktDal;
        private ISthbasDal _sthbasDal;
        private IStdpynDal _stdpynDal;
        private IStoptmDal _stoptmDal;
        private ISpuropDal _spuropDal;
        private ISturopDal _sturopDal;
        private IUastrtDal _uastrtDal;
        private IGnevrkService _gnevrkService;
        private IGndpnoService _gndpnoService;
        private IWmhratService _wmhratService;
        private IWmadrtService _wmadrtService;
        private IStftipService _stftipService;
        private ISthrktService _sthrktService;
        private IUragacService _uragacService;
        private IUastbgService _uastbgService;
        private IIsplanDal _isplanDal;
        private IWmadrsDal _wmadrsDal;
        private IWmadrtDal _wmadrtDal;
        private ISpfbasDal _spfbasDal;
        private ISpfharDal _spfharDal;
        private IGnService _gnService;
        private IStolcuService _stolcuService;
        private ISadegaDal _sadegaDal;
        private ISpkoslDal _spkoslDal;
        private IGnkoslService _gnkoslService;
        private ITsfbasDal _tsfbasDal;
        private ITsfharDal _tsfharDal;
        private ISprezvDal _sprezvDal;
        private IGnorgaService _gnorgaService;
        private IGnorhrDal _gnorhrDal;
        private IGnorhrService _gnorhrService;
        private IIsyrtnDal _isyrtnDal;
        private IIsyropDal _isyropDal;
        private ILockedService _lockedService;
        private IStmaltService _stmaltService;
        private IStkartService _stokKartService;
        private IStbdrnDal _stbdrnDal;

        public XXManager(IStkartDal stkartDal, IStnameDal stname, IStdepoDal stdepoDal, IStdepvDal stdepvDal, IStmhsbDal stmhsbDal, IGnService gnService, IGnevrkService gnevrkService, IUastbgService uastbgService,
            IStsaleDal stsaleDal, IStolcuDal stolcuDal, IStkmizDal stkmizDal, IStvmizDal stvmizDal, IStkmihDal stkmihDal, ISturyrDal sturyrDal, IStolcuService stolcuService, ILockedService lockedService,
            ISthrktDal sthrktDal, ISthbasDal sthbasDal, IStdpynDal stdpynDal, IStoptmDal stoptmDal, IGndpnoService gndpnoService, ISpkoslDal spkoslDal, IGnkoslService gnkoslService,
            IWmhratService wmhratService, IWmadrtService wmadrtService, IWmadrsDal wmadrsDal, IWmadrtDal wmadrtDal, IStftipService stftipService, ISpfbasDal spfbasDal, IIsplanDal isplanDal,
            ISpfharDal spfharDal, ISadegaDal sadegaDal, ISpuropDal spuropDal, ISturopDal sturopDal, ITsfbasDal tsfbasDal, ITsfharDal tsfharDal, ISprezvDal sprezvDal, IUastrtDal uastrtDal,
            IGnorgaService gnorgaService, IGnorhrDal gnorhrDal, IGnorhrService gnorhrService, ISthrktService sthrktService, IIsyrtnDal isyrtnDal, IIsyropDal isyropDal, IUragacService uragacService
            , IStmaltService stmaltService, IStkartService stokKartService, IStbdrnDal stbdrnDal)
        {
            _gnevrkService = gnevrkService;
            _stolcuService = stolcuService;
            _stkartDal = stkartDal;
            _stname = stname;
            _stdepoDal = stdepoDal;
            _stmhsbDal = stmhsbDal;
            _stsaleDal = stsaleDal;
            _stolcuDal = stolcuDal;
            _stkmizDal = stkmizDal;
            _stkmihDal = stkmihDal;
            _sturyrDal = sturyrDal;
            _sthrktDal = sthrktDal;
            _sthbasDal = sthbasDal;
            _stdpynDal = stdpynDal;
            _stoptmDal = stoptmDal;
            _wmadrsDal = wmadrsDal;
            _wmadrtDal = wmadrtDal;
            _uastrtDal = uastrtDal;
            _isplanDal = isplanDal;
            _stftipService = stftipService;
            _spfbasDal = spfbasDal;
            _spfharDal = spfharDal;
            _sadegaDal = sadegaDal;
            _spuropDal = spuropDal;
            _sturopDal = sturopDal;
            _gndpnoService = gndpnoService;
            _wmhratService = wmhratService;
            _wmadrtService = wmadrtService;
            _gnService = gnService;
            _spkoslDal = spkoslDal;
            _gnkoslService = gnkoslService;
            _uragacService = uragacService;
            _uastbgService = uastbgService;
            _tsfbasDal = tsfbasDal;
            _tsfharDal = tsfharDal;
            _sprezvDal = sprezvDal;
            _gnorgaService = gnorgaService;
            _gnorhrDal = gnorhrDal;
            _gnorhrService = gnorhrService;
            _sthrktService = sthrktService;
            _isyrtnDal = isyrtnDal;
            _isyropDal = isyropDal;
            _lockedService = lockedService;
            _stmaltService = stmaltService;
            _stokKartService = stokKartService;
            _stbdrnDal = stbdrnDal;
            _stdepvDal = stdepvDal;
            _stvmizDal = stvmizDal;
        }

        [FluentValidationAspect(typeof(SiparisKayitValidator))]
        [CacheRemoveAspect("Bps.BpsBase.Business.Concrete.Managers.SP.", typeof(MemoryCacheManager))]
        public StandardResponse Ncch_SiparisKaydet_Log(SiparisKayitModel model, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse();


            var baslik = model.Baslik;
            var kalems = model.Kalems;
            var talepBaslik = model.TalepBaslik;
            bool insert = false;

            if (baslik == null)
            {
                return sonuc;
            }

            // SAS ile ilgili mal hareketi olduysa kontrolleri yapılmalı?????

            #region Başlık

            baslik.SIRKID = global.SirketId.Value;
            baslik.KYNKKD = global.KaynakKod;
            baslik.ACTIVE = true;
            baslik.SLINDI = false;

            if (baslik.Id > 0)
            {
                baslik.DEKULL = global.UserKod;
                baslik.DTARIH = DateTime.Now;
                _spfbasDal.Update(baslik);
            }
            else
            {


                var evrakmodel = new EvrakNoUretParamModel();
                evrakmodel.TabloAdi = "SPFBAS";
                evrakmodel.TeknikAd = "BELGEN";
                evrakmodel.IslemTur = baslik.SPHRTP;
                var evrakResponse = _gnevrkService.Ncch_EvrakNoUret_NLog(global, evrakmodel);

                if (evrakResponse.Status != ResponseStatusEnum.OK)
                {
                    throw new BusinessException(evrakResponse.Message);
                }

                baslik.BELGEN = evrakResponse.Nesne;
                baslik.EKKULL = global.UserKod;
                baslik.ETARIH = DateTime.Now;
                baslik.FLGKPN = false;

                _spfbasDal.Add(baslik);
                insert = true;

                if (talepBaslik != null)
                {
                    talepBaslik.SIPVER = true;
                    _spfbasDal.Update(talepBaslik);
                }
            }

            #endregion

            #region Kalemler

            if (baslik.Id > 0)
            {
                var eskiKalems = _spfharDal.GetList(g => g.SIRKID == global.SirketId.Value && g.BELGEN == baslik.BELGEN)
                    .ToList();

                foreach (var eskiKalem in eskiKalems)
                {
                    _spfharDal.Delete(eskiKalem);
                }
            }

            if (kalems != null)
            {
                foreach (var data in kalems)
                {
                    data.BELGEN = baslik.BELGEN;
                    data.BELTRH = baslik.BELTRH;
                    data.CRKODU = baslik.CRKODU;
                    if (data.Id == 0) data.KLNMKTR = data.GRMKTR;
                    data.GNMKTR = data.GRMKTR;

                    data.SIRKID = global.SirketId.Value;
                    data.KYNKKD = global.KaynakKod;
                    data.ACTIVE = true;
                    data.SLINDI = false;
                    data.EKKULL = global.UserKod;
                    data.ETARIH = DateTime.Now;
                    _spfharDal.Add(data);
                }
            }

            var sql = @"DELETE FROM SPUROP WHERE SIRKID = " + global.SirketId + " AND ACTIVE = 1 AND SLINDI = 0 AND BELGEN = '" + baslik.BELGEN + "'";
            _spuropDal.ExecuteSqlQuery(sql);

            if (model.UrunOpsiyons != null)
            {
                List<SPUROP> spuropList = new List<SPUROP>();

                foreach (var data in model.UrunOpsiyons)
                {
                    SPUROP spurop = new SPUROP();
                    spurop.BELGEN = baslik.BELGEN;
                    spurop.TIPKOD = data.TIPKOD;
                    spurop.HARKOD = data.HARKOD;
                    spurop.SATIRN = data.SATIRN;
                    spurop.STKODU = data.STKODU;
                    spurop.STKNAM = data.STKNAM;
                    spurop.GFIYAT = data.GFIYAT;
                    spurop.DVCNKD = data.DVCNKD;
                    spurop.GNACIK = data.GNACIK;

                    spurop.SIRKID = global.SirketId.Value;
                    spurop.KYNKKD = global.KaynakKod;
                    spurop.ACTIVE = true;
                    spurop.SLINDI = false;
                    spurop.EKKULL = global.UserKod;
                    spurop.ETARIH = DateTime.Now;
                    spuropList.Add(spurop);
                }

                if (spuropList.Count > 0) _spuropDal.MultiAdd(spuropList);
            }

            #endregion

            #region Varsayılan Anlaşma Koşulları

            if (insert && (baslik.SPHRTP == 1 || baslik.SPHRTP == 4)) //Satış veya Teklif
            {
                List<GNKOSL> kosulList = _gnkoslService.Ncch_GetListByProjeKodAndLanguage_NLog(global, global.ProjeKod, "tr-TR", true).Items;

                if (kosulList != null)
                {
                    foreach (GNKOSL gnkosl in kosulList)
                    {
                        SPKOSL spkosl = new SPKOSL
                        {
                            BELGEN = baslik.BELGEN,
                            KOSLID = gnkosl.Id,
                            SIRKID = global.SirketId.Value,
                            ACTIVE = true,
                            SLINDI = false,
                            CHKCTR = false,
                            KYNKKD = "3",
                            EKKULL = global.UserKod,
                            ETARIH = DateTime.Now,
                        };
                        _spkoslDal.Add(spkosl);
                    }
                }
            }

            #endregion

            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [CacheRemoveAspect("Bps.BpsBase.Business.Concrete.Managers.CM.", typeof(MemoryCacheManager))]
        public StandardResponse Ncch_CrmKartKaydet_Log(CMKART cmkart, List<CMAKSN> aksiyonList, Global global, bool yetkiKontrol = true)
        {
            return null;
        }

        [CacheRemoveAspect("Bps.BpsBase.Business.Concrete.Managers.SP.", typeof(MemoryCacheManager))]
        public StandardResponse<SiparisKayitModel> Ncch_OnlineProformaKaydet_Log(SiparisKayitModel model, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }

            var sonuc = new StandardResponse<SiparisKayitModel>();
            sonuc.Status = ResponseStatusEnum.ERROR;
            sonuc.Message = "ERROR";

            var baslik = model.Baslik;
            var kalems = model.Kalems;
            var talepBaslik = model.TalepBaslik;

            if (baslik == null)
            {
                sonuc.Nesne = null;
                return sonuc;
            }

            #region Başlık

            baslik.SIRKID = global.SirketId.Value;
            baslik.KYNKKD = global.KaynakKod;
            baslik.ACTIVE = true;
            baslik.SLINDI = false;

            if (baslik.Id > 0)
            {
                baslik.DEKULL = global.UserKod;
                baslik.DTARIH = DateTime.Now;
                baslik = _spfbasDal.Update(baslik);
            }
            else
            {
                var evrakmodel = new EvrakNoUretParamModel();
                evrakmodel.TabloAdi = "SPFBAS";
                evrakmodel.TeknikAd = "BELGEN";
                evrakmodel.IslemTur = 5;
                var evrakResponse = _gnevrkService.Ncch_EvrakNoUret_NLog(global, evrakmodel);

                if (evrakResponse.Status != ResponseStatusEnum.OK)
                {
                    sonuc.Error = evrakResponse.Error;
                    return sonuc;
                }

                sonuc.Message = evrakResponse.Nesne;

                baslik.BELGEN = evrakResponse.Nesne;
                baslik.EKKULL = global.UserKod;
                baslik.ETARIH = DateTime.Now;
                baslik = _spfbasDal.Add(baslik);

                if (talepBaslik != null)
                {
                    talepBaslik.SIPVER = true;
                    baslik = _spfbasDal.Update(talepBaslik);
                }
            }

            model.Baslik = baslik;

            #endregion

            #region Kalemler

            if (baslik.Id > 0)
            {
                var eskiKalems = _spfharDal.GetList(g => g.SIRKID == global.SirketId.Value && g.BELGEN == baslik.BELGEN)
                    .ToList();

                foreach (var eskiKalem in eskiKalems)
                {
                    _spfharDal.Delete(eskiKalem);
                }
            }

            if (kalems != null)
            {
                List<SPFHAR> newList = new List<SPFHAR>();

                foreach (var data in kalems)
                {
                    data.BELGEN = baslik.BELGEN;
                    data.BELTRH = baslik.BELTRH;
                    data.CRKODU = baslik.CRKODU;
                    data.KLNMKTR = data.GRMKTR;
                    data.GNMKTR = data.GRMKTR;

                    data.SIRKID = global.SirketId.Value;
                    data.KYNKKD = global.KaynakKod;
                    data.ACTIVE = true;
                    data.SLINDI = false;
                    data.EKKULL = global.UserKod;
                    data.ETARIH = DateTime.Now;
                    SPFHAR newSpfhar = _spfharDal.Add(data);
                    newList.Add(newSpfhar);
                }

                model.Kalems = newList;
            }

            //var sql = @"DELETE FROM SPUROP WHERE SIRKID = " + global.SirketId + " AND ACTIVE = 1 AND SLINDI = 0 AND BELGEN = '" + baslik.BELGEN + "'";
            //_spuropDal.ExecuteSqlQuery(sql);

            //if (model.UrunOpsiyons != null)
            //{
            //    List<SPUROP> spuropList = new List<SPUROP>();

            //    foreach (var data in model.UrunOpsiyons)
            //    {
            //        SPUROP spurop = new SPUROP();
            //        spurop.BELGEN = baslik.BELGEN;
            //        spurop.TIPKOD = data.TIPKOD;
            //        spurop.HARKOD = data.HARKOD;
            //        spurop.SATIRN = data.SATIRN;
            //        spurop.STKODU = data.STKODU;
            //        spurop.STKNAM = data.STKNAM;
            //        spurop.GFIYAT = data.GFIYAT;
            //        spurop.DVCNKD = data.DVCNKD;
            //        spurop.GNACIK = data.GNACIK;

            //        spurop.SIRKID = global.SirketId.Value;
            //        spurop.KYNKKD = global.KaynakKod;
            //        spurop.ACTIVE = true;
            //        spurop.SLINDI = false;
            //        spurop.EKKULL = global.UserKod;
            //        spurop.ETARIH = DateTime.Now;
            //        spuropList.Add(spurop);
            //    }

            //    if (spuropList.Count > 0) _spuropDal.MultiAdd(spuropList);
            //}

            #endregion

            sonuc.Nesne = model;
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GenelStokKartValidator))]
        [CacheRemoveAspect("Bps.BpsBase.Business.Concrete.Managers.ST.", typeof(MemoryCacheManager))]
        public StandardResponse Ncch_StokKartKaydet_Log(Global global, GenelStokKartModel model, List<Grid> grids, string _action, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse();


            var stKart = model.Stkart;
            var stDepos = model.Stdepos;
            var stUryrs = model.Sturyrs;
            var stMhsbs = model.Stmhsbs;
            var stSales = model.Stsales;
            var stOlcus = model.Stolcus;
            var stNames = model.Stnames;
            var stDpyns = model.Stdpyns;
            var stBdrns = model.Stbdrns;

            //var fhStKart = grids.FirstOrDefault(f => f.View == "STKART");
            var fhStDepos = grids.Where(f => f.View == "STDEPO").ToList();
            var fhStMhsbs = grids.Where(f => f.View == "STMHSB").ToList();
            var fhStSales = grids.Where(f => f.View == "STSALE").ToList();
            var fhStOlcus = grids.Where(f => f.View == "STOLCU").ToList();
            var fhStNames = grids.Where(f => f.View == "STNAME").ToList();
            var fhStUryrs = grids.Where(f => f.View == "STURYR").ToList();
            var fhStDpyns = grids.Where(f => f.View == "STDPYN").ToList();
            var fhStBdrns = grids.Where(f => f.View == "STBDRN").ToList();

            #region Stok Kart

            stKart.SIRKID = global.SirketId.Value;
            stKart.KYNKKD = global.KaynakKod;
            stKart.ACTIVE = true;
            stKart.SLINDI = false;

            //if (fhStKart != null)
            //{

            //    if (stKart.Id > 0 && fhStKart.Tipi == "update")
            //    {
            //        stKart.DEKULL = global.UserKod;
            //        stKart.DTARIH = DateTime.Now;
            //        _stkartDal.Update(stKart);
            //    }
            //    else if (fhStKart.Tipi == "insert")
            //    {
            //        stKart.EKKULL = global.UserKod;
            //        stKart.ETARIH = DateTime.Now;
            //        _stkartDal.Add(stKart);
            //    }
            //    else if (fhStKart.Tipi == "delete")
            //    {
            //        stKart.EKKULL = global.UserKod;
            //        stKart.ETARIH = DateTime.Now;
            //        stKart.ACTIVE = false;
            //        stKart.SLINDI = true;
            //        _stkartDal.Add(stKart);
            //    }
            //}


            if (_action == "insert")
            {
                stKart.EKKULL = global.UserKod;
                stKart.ETARIH = DateTime.Now;
                _stkartDal.Add(stKart);
            }
            else if (stKart.Id > 0 && _action == "update")
            {
                stKart.DEKULL = global.UserKod;
                stKart.DTARIH = DateTime.Now;
                _stkartDal.Update(stKart);
            }
            else if (_action == "delete")
            {
                stKart.DEKULL = global.UserKod;
                stKart.DTARIH = DateTime.Now;
                stKart.ACTIVE = false;
                stKart.SLINDI = true;
                _stkartDal.Update(stKart);
            }

            #endregion

            #region Depo

            if (stDepos != null)
            {
                var inserted = stDepos.Where(w => w.Id == 0).ToList();
                foreach (var data in inserted)
                {
                    data.STKODU = stKart.STKODU;
                    data.SIRKID = global.SirketId.Value;
                    data.KYNKKD = global.KaynakKod;
                    data.ACTIVE = true;
                    data.SLINDI = false;
                    data.EKKULL = global.UserKod;
                    data.ETARIH = DateTime.Now;
                    _stdepoDal.Add(data);
                }

                foreach (var grid in fhStDepos)
                {
                    STDEPO data = null;
                    if (grid.Tipi == "delete")
                    {
                        data = _stdepoDal.Get(g => g.Id == grid.Id);
                    }
                    else if (grid.Tipi == "update")
                    {
                        data = stDepos.FirstOrDefault(f => f.Id == grid.Id);
                    }

                    data.STKODU = stKart.STKODU;
                    data.SIRKID = global.SirketId.Value;
                    data.KYNKKD = global.KaynakKod;
                    if (grid.Tipi == "update")
                    {
                        data.ACTIVE = true;
                        data.SLINDI = false;
                        data.DEKULL = global.UserKod;
                        data.DTARIH = DateTime.Now;
                        _stdepoDal.Update(data);
                    }
                    else if (grid.Tipi == "delete")
                    {
                        data.ACTIVE = false;
                        data.SLINDI = true;
                        data.DEKULL = global.UserKod;
                        data.DTARIH = DateTime.Now;
                        _stdepoDal.Update(data);
                    }
                }

                if (_action == "delete")
                {
                    foreach (var data in stDepos)
                    {
                        data.ACTIVE = false;
                        data.SLINDI = true;
                        data.DEKULL = global.UserKod;
                        data.DTARIH = DateTime.Now;
                        _stdepoDal.Update(data);
                    }
                }
            }

            #endregion Depo

            #region Muhasebe

            if (stMhsbs != null)
            {
                var inserted = stMhsbs.Where(w => w.Id == 0).ToList();
                foreach (var data in inserted)
                {
                    data.STKODU = stKart.STKODU;
                    data.SIRKID = global.SirketId.Value;
                    data.KYNKKD = global.KaynakKod;
                    data.ACTIVE = true;
                    data.SLINDI = false;
                    data.EKKULL = global.UserKod;
                    data.ETARIH = DateTime.Now;
                    _stmhsbDal.Add(data);
                }

                foreach (var grid in fhStMhsbs)
                {
                    var data = stMhsbs.FirstOrDefault(f => f.Id == grid.Id);
                    data.STKODU = stKart.STKODU;
                    data.SIRKID = global.SirketId.Value;
                    data.KYNKKD = global.KaynakKod;
                    if (grid.Tipi == "update")
                    {
                        data.ACTIVE = true;
                        data.SLINDI = false;
                        data.DEKULL = global.UserKod;
                        data.DTARIH = DateTime.Now;
                        _stmhsbDal.Update(data);
                    }
                    else if (grid.Tipi == "delete")
                    {
                        data.ACTIVE = false;
                        data.SLINDI = true;
                        data.DEKULL = global.UserKod;
                        data.DTARIH = DateTime.Now;
                        _stmhsbDal.Update(data);
                    }
                }

                if (_action == "delete")
                {
                    foreach (var data in stMhsbs)
                    {
                        data.ACTIVE = false;
                        data.SLINDI = true;
                        data.DEKULL = global.UserKod;
                        data.DTARIH = DateTime.Now;
                        _stmhsbDal.Update(data);
                    }
                }
            }

            #endregion

            #region Satış Verileri

            if (stSales != null)
            {
                var inserted = stSales.Where(w => w.Id == 0).ToList();
                foreach (var data in inserted)
                {
                    data.STKODU = stKart.STKODU;
                    data.SIRKID = global.SirketId.Value;
                    data.KYNKKD = global.KaynakKod;
                    data.ACTIVE = true;
                    data.SLINDI = false;
                    data.EKKULL = global.UserKod;
                    data.ETARIH = DateTime.Now;
                    _stsaleDal.Add(data);
                }

                foreach (var grid in fhStSales)
                {
                    var data = stSales.FirstOrDefault(f => f.Id == grid.Id);
                    data.STKODU = stKart.STKODU;
                    data.SIRKID = global.SirketId.Value;
                    data.KYNKKD = global.KaynakKod;

                    if (grid.Tipi == "update")
                    {
                        data.ACTIVE = true;
                        data.SLINDI = false;
                        data.DEKULL = global.UserKod;
                        data.DTARIH = DateTime.Now;
                        _stsaleDal.Update(data);
                    }
                    else if (grid.Tipi == "delete")
                    {
                        data.ACTIVE = false;
                        data.SLINDI = true;
                        data.DEKULL = global.UserKod;
                        data.DTARIH = DateTime.Now;
                        _stsaleDal.Update(data);
                    }
                }

                if (_action == "delete")
                {
                    foreach (var data in stSales)
                    {
                        data.ACTIVE = false;
                        data.SLINDI = true;
                        data.DEKULL = global.UserKod;
                        data.DTARIH = DateTime.Now;
                        _stsaleDal.Update(data);
                    }
                }
            }

            #endregion

            #region Ölçü 

            if (stOlcus != null && stOlcus.Count > 0)
            {
                var inserted = stOlcus.Where(w => w.Id == 0).ToList();
                foreach (var data in inserted)
                {
                    data.STKODU = stKart.STKODU;
                    data.SIRKID = global.SirketId.Value;
                    data.KYNKKD = global.KaynakKod;
                    data.ACTIVE = true;
                    data.SLINDI = false;
                    data.EKKULL = global.UserKod;
                    data.ETARIH = DateTime.Now;
                    _stolcuDal.Add(data);
                }

                foreach (var grid in fhStOlcus)
                {
                    if (grid.Tipi == "update")
                    {
                        var data = stOlcus.FirstOrDefault(f => f.Id == grid.Id);
                        data.STKODU = stKart.STKODU;
                        data.SIRKID = global.SirketId.Value;
                        data.KYNKKD = global.KaynakKod;

                        data.ACTIVE = true;
                        data.SLINDI = false;
                        data.DEKULL = global.UserKod;
                        data.DTARIH = DateTime.Now;
                        _stolcuDal.Update(data);
                    }
                    else if (grid.Tipi == "delete")
                    {
                        var data = _stolcuDal.Get(o => o.Id == grid.Id);

                        //var exist = _sthrktDal.Get(g => g.Id == data.Id);
                        //if (exist != null)
                        //{
                        //    throw new BusinessException(data.HCOLKD + " ölçü biriminde hareket olduğu için silinemez!");
                        //}

                        data.ACTIVE = false;
                        data.SLINDI = true;
                        data.DEKULL = global.UserKod;
                        data.DTARIH = DateTime.Now;
                        _stolcuDal.Update(data);
                    }
                }

                if (_action == "delete")
                {
                    foreach (var data in stOlcus)
                    {
                        data.ACTIVE = false;
                        data.SLINDI = true;
                        data.DEKULL = global.UserKod;
                        data.DTARIH = DateTime.Now;
                        _stolcuDal.Update(data);
                    }
                }
            }
            else
            {
                var added = new STOLCU
                {
                    SIRKID = stKart.SIRKID,
                    STKODU = stKart.STKODU,
                    OLCUKD = stKart.OLCUKD,
                    OLCHDF = stKart.OLCUKD,
                    BOLLEN = 1,
                    BOLNEN = 1,
                    KYNKKD = global.KaynakKod,
                    ACTIVE = true,
                    SLINDI = false,
                    EKKULL = global.UserKod,
                    ETARIH = DateTime.Now
                };


                _stolcuDal.Add(added);
            }

            #endregion

            #region Maliyet

            var stkmiz = model.Stkmiz;
            if (stkmiz != null)
            {
                stkmiz.STKODU = stKart.STKODU;
                stkmiz.SIRKID = global.SirketId.Value;
                stkmiz.KYNKKD = global.KaynakKod;
                stkmiz.ACTIVE = true;
                stkmiz.SLINDI = false;


                if (_action == "insert")
                {
                    stkmiz.EKKULL = global.UserKod;
                    stkmiz.ETARIH = DateTime.Now;
                    _stkmizDal.Add(stkmiz);
                }
                else if (_action == "update")
                {
                    var oldData = _stkmizDal.Get(g => g.Id == stkmiz.Id);
                    if (oldData == null)
                    {
                        stkmiz.EKKULL = global.UserKod;
                        stkmiz.ETARIH = DateTime.Now;
                        _stkmizDal.Add(stkmiz);
                    }
                    else
                    {
                        if (oldData.MALIYL != stkmiz.MALIYL || oldData.MALIAY != stkmiz.MALIAY)
                        {
                            stkmiz.DEKULL = global.UserKod;
                            stkmiz.DTARIH = DateTime.Now;
                            _stkmizDal.Update(stkmiz);

                            var stkmih = new STKMIH()
                            {
                                STKODU = oldData.STKODU,
                                MALHSP = oldData.MALHSP,
                                KAYORT = oldData.KAYORT,
                                STNFIY = oldData.STNFIY,
                                DGMKTR = oldData.DGMKTR,
                                DGSTDG = oldData.DGSTDG,
                                MALIYL = oldData.MALIYL,
                                MALIAY = oldData.MALIAY,
                                ACTIVE = true,
                                SLINDI = false,
                                SIRKID = global.SirketId.Value,
                                EKKULL = global.UserKod,
                                ETARIH = DateTime.Now,
                                KYNKKD = global.KaynakKod,
                                CHKCTR = false
                            };
                            _stkmihDal.Add(stkmih);
                        }
                    }
                }
                else
                {
                    stkmiz.ACTIVE = false;
                    stkmiz.SLINDI = true;
                    stkmiz.DEKULL = global.UserKod;
                    stkmiz.DTARIH = DateTime.Now;
                    _stkmizDal.Update(stkmiz);
                }
            }

            #endregion

            #region Satış

            if (stSales != null)
            {
                var inserted = stSales.Where(w => w.Id == 0).ToList();
                foreach (var data in inserted)
                {
                    data.STKODU = stKart.STKODU;
                    data.SIRKID = global.SirketId.Value;
                    data.KYNKKD = global.KaynakKod;
                    data.ACTIVE = true;
                    data.SLINDI = false;
                    data.EKKULL = global.UserKod;
                    data.ETARIH = DateTime.Now;
                    _stsaleDal.Add(data);
                }
                foreach (var grid in fhStSales)
                {
                    var data = stSales.FirstOrDefault(f => f.Id == grid.Id);
                    data.STKODU = stKart.STKODU;
                    data.SIRKID = global.SirketId.Value;
                    data.KYNKKD = global.KaynakKod;
                    if (grid.Tipi == "update")
                    {
                        data.ACTIVE = true;
                        data.SLINDI = false;
                        data.DEKULL = global.UserKod;
                        data.DTARIH = DateTime.Now;
                        _stsaleDal.Update(data);
                    }
                    else if (grid.Tipi == "delete")
                    {
                        data.ACTIVE = false;
                        data.SLINDI = true;
                        data.DEKULL = global.UserKod;
                        data.DTARIH = DateTime.Now;
                        _stsaleDal.Update(data);
                    }
                }

                if (_action == "delete")
                {
                    foreach (var data in stSales)
                    {
                        data.ACTIVE = false;
                        data.SLINDI = true;
                        data.DEKULL = global.UserKod;
                        data.DTARIH = DateTime.Now;
                        _stsaleDal.Update(data);
                    }
                }
            }

            #endregion

            #region Dil

            if (stNames != null)
            {
                foreach (var stname in stNames)
                {
                    if (stname.LANGKD == global.DilKod)
                    {
                        stname.STKNAM = stKart.STKNAM;
                    }
                }
                var inserted = stNames.Where(w => w.Id == 0).ToList();
                foreach (var data in inserted)
                {
                    data.STKODU = stKart.STKODU;
                    data.SIRKID = global.SirketId.Value;
                    data.KYNKKD = global.KaynakKod;
                    data.ACTIVE = true;
                    data.SLINDI = false;
                    data.EKKULL = global.UserKod;
                    data.ETARIH = DateTime.Now;
                    _stname.Add(data);
                }

                foreach (var grid in fhStNames)
                {
                    if (grid.Tipi == "update")
                    {
                        var data = stNames.FirstOrDefault(f => f.Id == grid.Id);
                        data.STKODU = stKart.STKODU;
                        data.SIRKID = global.SirketId.Value;
                        data.KYNKKD = global.KaynakKod;

                        data.ACTIVE = true;
                        data.SLINDI = false;
                        data.DEKULL = global.UserKod;
                        data.DTARIH = DateTime.Now;
                        _stname.Update(data);
                    }
                    else if (grid.Tipi == "delete")
                    {
                        var data = _stname.Get(o => o.Id == grid.Id);
                        data.ACTIVE = false;
                        data.SLINDI = true;
                        data.DEKULL = global.UserKod;
                        data.DTARIH = DateTime.Now;
                        _stname.Update(data);
                    }
                }

                if (_action == "delete")
                {
                    foreach (var data in stNames)
                    {
                        data.ACTIVE = false;
                        data.SLINDI = true;
                        data.DEKULL = global.UserKod;
                        data.DTARIH = DateTime.Now;
                        _stname.Update(data);
                    }
                }
            }
            else
            {
                var sistemDilTanim = new STNAME()
                {
                    SIRKID = global.SirketId.Value,
                    STKODU = stKart.STKODU,
                    STKNAM = stKart.STKNAM,
                    LANGKD = global.DilKod,
                    ACTIVE = true,
                    SLINDI = false,
                    EKKULL = global.UserKod,
                    ETARIH = DateTime.Now,
                    KYNKKD = global.KaynakKod
                };
                _stname.Add(sistemDilTanim);
            }

            #endregion

            #region Üretim Yeri

            if (stUryrs != null)
            {
                var inserted = stUryrs.Where(w => w.Id == 0).ToList();
                foreach (var data in inserted)
                {
                    data.STKODU = stKart.STKODU;
                    data.SIRKID = global.SirketId.Value;
                    data.KYNKKD = global.KaynakKod;
                    data.ACTIVE = true;
                    data.SLINDI = false;
                    data.EKKULL = global.UserKod;
                    data.ETARIH = DateTime.Now;
                    _sturyrDal.Add(data);
                }

                foreach (var grid in fhStUryrs)
                {
                    STURYR data = null;
                    if (grid.Tipi == "delete")
                    {
                        data = _sturyrDal.Get(g => g.Id == grid.Id);
                    }
                    else if (grid.Tipi == "update")
                    {
                        data = stUryrs.FirstOrDefault(f => f.Id == grid.Id);
                    }

                    data.STKODU = stKart.STKODU;
                    data.SIRKID = global.SirketId.Value;
                    data.KYNKKD = global.KaynakKod;
                    if (grid.Tipi == "update")
                    {
                        data.ACTIVE = true;
                        data.SLINDI = false;
                        data.DEKULL = global.UserKod;
                        data.DTARIH = DateTime.Now;
                        _sturyrDal.Update(data);
                    }
                    else if (grid.Tipi == "delete")
                    {
                        data.ACTIVE = false;
                        data.SLINDI = true;
                        data.DEKULL = global.UserKod;
                        data.DTARIH = DateTime.Now;
                        _sturyrDal.Update(data);
                    }
                }

                if (_action == "delete")
                {
                    foreach (var data in stUryrs)
                    {
                        data.ACTIVE = false;
                        data.SLINDI = true;
                        data.DEKULL = global.UserKod;
                        data.DTARIH = DateTime.Now;
                        _sturyrDal.Update(data);
                    }
                }
            }

            #endregion Üretim Yeri


            #region BedenRenk

            if (stBdrns != null)
            {
                var inserted = stBdrns.Where(w => w.Id == 0).ToList();
                foreach (var data in inserted)
                {
                    data.STKODU = stKart.STKODU;
                    data.VRKODU = data.STKODU + data.RENKKD + data.BEDNKD + data.DROPKD;

                    if (data.VRYTNM == null) data.VRYTNM = data.STKODU + data.RENKKD + data.BEDNKD + data.DROPKD;
                    //data.VRYTNM = stKart.STKNAM + " " + data.RENKKD + " " + data.BEDNKD + " " + data.DROPKD;
                    data.SIRKID = global.SirketId.Value;
                    data.KYNKKD = global.KaynakKod;
                    data.ACTIVE = true;
                    data.SLINDI = false;
                    data.EKKULL = global.UserKod;
                    data.ETARIH = DateTime.Now;
                    _stbdrnDal.Add(data);
                }

                foreach (var grid in fhStBdrns)
                {
                    STBDRN data = null;
                    if (grid.Tipi == "delete")
                    {
                        data = _stbdrnDal.Get(g => g.Id == grid.Id);
                    }
                    else if (grid.Tipi == "update")
                    {
                        data = stBdrns.FirstOrDefault(f => f.Id == grid.Id);
                    }


                    if (grid.Tipi == "update")
                    {
                        data.STKODU = stKart.STKODU;
                        data.VRKODU = data.STKODU + data.RENKKD + data.BEDNKD + data.DROPKD;
                        if (data.VRYTNM == null) data.VRYTNM = data.STKODU + data.RENKKD + data.BEDNKD + data.DROPKD;
                        //data.VRYTNM = stKart.STKNAM + " " + data.RENKKD + " " + data.BEDNKD + " " + data.DROPKD;
                        data.SIRKID = global.SirketId.Value;
                        data.KYNKKD = global.KaynakKod;
                        data.ACTIVE = true;
                        data.SLINDI = false;
                        data.DEKULL = global.UserKod;
                        data.DTARIH = DateTime.Now;
                        _stbdrnDal.Update(data);
                    }
                    else if (grid.Tipi == "delete")
                    {
                        data.ACTIVE = false;
                        data.SLINDI = true;
                        data.DEKULL = global.UserKod;
                        data.DTARIH = DateTime.Now;
                        _stbdrnDal.Update(data);
                    }
                }

                if (_action == "delete")
                {
                    foreach (var data in stBdrns)
                    {
                        data.ACTIVE = false;
                        data.SLINDI = true;
                        data.DEKULL = global.UserKod;
                        data.DTARIH = DateTime.Now;
                        _stbdrnDal.Update(data);
                    }
                }
            }

            #endregion BedenRenk

            #region Depo Yönetimi WM

            if (stDpyns != null)
            {
                var inserted = stDpyns.Where(w => w.Id == 0).ToList();
                foreach (var data in inserted)
                {
                    data.STKODU = stKart.STKODU;
                    data.SIRKID = global.SirketId.Value;
                    data.KYNKKD = global.KaynakKod;
                    data.ACTIVE = true;
                    data.SLINDI = false;
                    data.EKKULL = global.UserKod;
                    data.ETARIH = DateTime.Now;
                    _stdpynDal.Add(data);
                }

                foreach (var grid in fhStDpyns)
                {
                    STDPYN data = null;
                    if (grid.Tipi == "delete")
                    {
                        data = _stdpynDal.Get(g => g.Id == grid.Id);
                    }
                    else if (grid.Tipi == "update")
                    {
                        data = stDpyns.FirstOrDefault(f => f.Id == grid.Id);
                    }

                    data.STKODU = stKart.STKODU;
                    data.SIRKID = global.SirketId.Value;
                    data.KYNKKD = global.KaynakKod;
                    if (grid.Tipi == "update")
                    {
                        data.ACTIVE = true;
                        data.SLINDI = false;
                        data.DEKULL = global.UserKod;
                        data.DTARIH = DateTime.Now;
                        _stdpynDal.Update(data);
                    }
                    else if (grid.Tipi == "delete")
                    {
                        data.ACTIVE = false;
                        data.SLINDI = true;
                        data.DEKULL = global.UserKod;
                        data.DTARIH = DateTime.Now;
                        _stdpynDal.Update(data);
                    }
                }

                if (_action == "delete")
                {
                    foreach (var data in stDpyns)
                    {
                        data.ACTIVE = false;
                        data.SLINDI = true;
                        data.DEKULL = global.UserKod;
                        data.DTARIH = DateTime.Now;
                        _stdpynDal.Update(data);
                    }
                }
            }

            #endregion Depo Yönetimi WM

            #region Ürün Opsiyon

            var sql = @"DELETE FROM STUROP WHERE SIRKID = " + global.SirketId + " AND ACTIVE = 1 AND SLINDI = 0 AND STKODU = '" + model.Stkart.STKODU + "'";
            _sturopDal.ExecuteSqlQuery(sql);

            if (model.UrunOpsiyons != null)
            {
                List<STUROP> sturopList = new List<STUROP>();

                foreach (var data in model.UrunOpsiyons)
                {
                    STUROP sturop = new STUROP();
                    sturop.TIPKOD = data.TIPKOD;
                    sturop.HARKOD = data.HARKOD;
                    sturop.STKODU = data.STKODU;
                    sturop.STKNAM = data.STKNAM;
                    sturop.SIRKID = global.SirketId.Value;
                    sturop.KYNKKD = global.KaynakKod;
                    sturop.ACTIVE = true;
                    sturop.SLINDI = false;
                    sturop.EKKULL = global.UserKod;
                    sturop.ETARIH = DateTime.Now;
                    sturopList.Add(sturop);
                }

                if (sturopList.Count > 0) _sturopDal.MultiAdd(sturopList);
            }

            #endregion

            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        //[FluentValidationAspect(typeof(GenelStokKartValidator))]
        [CacheRemoveAspect("Bps.BpsBase.Business.Concrete.Managers.ST.", typeof(MemoryCacheManager))]
        public StandardResponse Ncch_StokSayim_Log(StokHareketModel model, Global global, bool yetkiKontrol = true)
        {
            var sonuc = new StandardResponse();
            var baslik = model.Baslik;
            var kalemler = model.Kalemler;

            var evrakmodel = new EvrakNoUretParamModel();
            evrakmodel.TabloAdi = "STHBAS";
            evrakmodel.TeknikAd = "BELGEN";
            evrakmodel.IslemTur = baslik.STFTNO;
            var evrakResponse = _gnevrkService.Ncch_EvrakNoUret_NLog(global, evrakmodel);

            if (evrakResponse.Status != ResponseStatusEnum.OK)
            {
                throw new BusinessException(evrakResponse.Message);
            }

            var saveDate = DateTime.Now;
            baslik.EKKULL = global.UserKod;
            baslik.ETARIH = saveDate;
            baslik.SIRKID = global.SirketId.Value;
            baslik.KYNKKD = global.KaynakKod;
            baslik.ACTIVE = true;
            baslik.SLINDI = false;
            baslik.CHKCTR = false;
            baslik.BELGEN = evrakResponse.Nesne;

            foreach (var data in kalemler)
            {
                data.EKKULL = global.UserKod;
                data.ETARIH = saveDate;
                data.SIRKID = global.SirketId.Value;
                data.KYNKKD = global.KaynakKod;
                data.ACTIVE = true;
                data.SLINDI = false;
                data.CHKCTR = false;
                data.BELGEN = evrakResponse.Nesne;
                data.BELTRH = baslik.BELTRH;
                data.GRDEPO = baslik.GRDEPO;
                data.STFTNO = baslik.STFTNO;

                var stDepo = _stdepoDal.Get(g =>
                    g.SIRKID == global.SirketId && g.STKODU == data.STKODU && g.DPKODU == baslik.GRDEPO && g.ACTIVE);

                if (stDepo == null)
                {
                    throw new BusinessException(data.STKODU + " depo tanımlaması yapılmamıştır, lütfen kontrol ediniz!");
                }

                var stkmiz = _stkmizDal.Get(g =>
                    g.SIRKID == global.SirketId && g.STKODU == data.STKODU && g.MALIYL == DateTime.Now.Year && g.MALIAY == DateTime.Now.Month && g.ACTIVE);

                if (stkmiz == null)
                {
                    stkmiz = _stkmizDal.Add(new STKMIZ
                    {
                        SIRKID = global.SirketId.Value,
                        STKODU = data.STKODU,
                        MALIYL = baslik.BELTRH.Year,
                        MALIAY = baslik.BELTRH.Month,
                        KAYORT = 0,
                        STNFIY = 0,
                        DGMKTR = 0,
                        DGSTDG = 0,
                        MALHSP = 0,
                        ACTIVE = true,
                        SLINDI = false,
                        KYNKKD = "3",
                        EKKULL = global.UserKod,
                        ETARIH = DateTime.Now,
                        CHKCTR = false,
                    });
                }

                var date = new DateTime(stkmiz.MALIYL, stkmiz.MALIAY, 1);
                var belgeTarihi = baslik.BELTRH;

                if (date < belgeTarihi && date.Month != belgeTarihi.Month)
                {
                    throw new BusinessException(data.STKODU + " malzemenin maliyet dönemi kapanmıştır, işlem yapamazsınız! ( " + baslik.BELTRH.Year + "-" +
                                                baslik.BELTRH.Month + " )");
                }

                if (date > belgeTarihi && date.Month != belgeTarihi.Month)
                {
                    throw new BusinessException(data.STKODU + " malzemenin maliyet dönemi açılmamıştır, işlem yapamazsınız! ( " + baslik.BELTRH.Year + "-" +
                                                baslik.BELTRH.Month + " )");
                }
            }

            _sthbasDal.Add(baslik);

            foreach (var data in kalemler)
            {
                var stkmiz = _stkmizDal.Get(g =>
                    g.SIRKID == global.SirketId && g.STKODU == data.STKODU && g.ACTIVE &&
                    g.MALIAY == baslik.BELTRH.Month && g.MALIYL == baslik.BELTRH.Year);

                var stDepo = _stdepoDal.Get(g =>
                    g.SIRKID == global.SirketId && g.STKODU == data.STKODU && g.DPKODU == baslik.GRDEPO && g.ACTIVE);
                STDEPV stDepv = _stdepvDal.Get(g =>
                        g.SIRKID == global.SirketId && g.STKODU == data.STKODU && g.VRKODU == data.VRKODU && g.DPKODU == baslik.GRDEPO && g.ACTIVE);
                var stvmiz = _stvmizDal.Get(g =>
                        g.SIRKID == global.SirketId && g.STKODU == data.STKODU && g.VRKODU == data.VRKODU && g.ACTIVE &&
                        g.MALIAY == baslik.BELTRH.Month && g.MALIYL == baslik.BELTRH.Year);


                decimal fark = 0;

                if (!string.IsNullOrEmpty(data.PARTIN))
                {
                    List<SthrktMiktarByPartiModel> partiMiktarList = _sthrktService
                        .GetStokMiktarFromHareketByParti(global, "STKODU = '" + data.STKODU + "' AND PARTIN = '" + data.PARTIN + "' AND DPKODU = '" + baslik.GRDEPO + "'").Items;

                    decimal mevcut = 0;
                    if (partiMiktarList != null && partiMiktarList.Count == 1) mevcut = partiMiktarList[0].GRMKTR;

                    fark = data.GNMKTR.Value - mevcut;
                }
                else
                {
                    fark = data.GNMKTR.Value - stDepo.USESTK;
                }

                var copy = data.ShallowCopy();
                if (stDepv == null)
                {
                    stDepv = _stdepvDal.Add(new STDEPV
                    {
                        SIRKID = global.SirketId.Value,
                        STKODU = copy.STKODU,
                        VRKODU = copy.VRKODU,
                        URYRKD = stDepo.URYRKD,
                        DPKODU = stDepo.DPKODU,
                        ENBLKJ = false,
                        USESTK = 0,
                        BLKSTK = 0,
                        MIPGOS = stDepo.MIPGOS,
                        TEDKOD = stDepo.TEDKOD,
                        DPADRS = stDepo.DPADRS,
                        ULKEKD = stDepo.ULKEKD,
                        ACTIVE = true,
                        SLINDI = false,
                        KYNKKD = "3",
                        EKKULL = global.UserKod,
                        ETARIH = DateTime.Now,
                        CHKCTR = false,

                    });
                }
                if (stvmiz == null)
                {
                    stvmiz = _stvmizDal.Add(new STVMIZ
                    {
                        SIRKID = global.SirketId.Value,
                        STKODU = copy.STKODU,
                        VRKODU = copy.VRKODU,
                        MALIYL = DateTime.Today.Year,
                        MALIAY = DateTime.Today.Month,
                        KAYORT = 0,
                        STNFIY = 0,
                        DGMKTR = 0,
                        DGSTDG = 0,
                        MALHSP = 0,
                        ACTIVE = true,
                        SLINDI = false,
                        KYNKKD = "3",
                        EKKULL = global.UserKod,
                        ETARIH = DateTime.Now,
                        CHKCTR = false,
                    });
                }

                if (fark < 0)
                {
                    copy.STHRTP = 1;
                    copy.CKDEPO = copy.GRDEPO;
                    copy.GRDEPO = null;
                }
                else if (fark >= 0)
                {
                    copy.STHRTP = 0;
                }

                copy.GRMKTR = Math.Abs(fark);
                copy.GROLBR = data.OLCUKD;

                stDepo.USESTK += fark;
                stDepo.DEKULL = global.UserKod;
                stDepo.DTARIH = saveDate;
                _stdepoDal.Update(stDepo);

                stkmiz.DGMKTR += fark;
                stkmiz.DEKULL = global.UserKod;
                stkmiz.DTARIH = saveDate;
                _stkmizDal.Update(stkmiz);

                stDepv.USESTK += fark;
                stDepv.DEKULL = global.UserKod;
                stDepv.DTARIH = saveDate;
                _stdepvDal.Update(stDepv);

                stvmiz.DGMKTR += fark;
                stvmiz.DEKULL = global.UserKod;
                stvmiz.DTARIH = saveDate;
                _stvmizDal.Update(stvmiz);

                _sthrktDal.Add(copy);
            }

            sonuc.Message = evrakResponse.Nesne;
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        //[FluentValidationAspect(typeof(GenelStokKartValidator))]
        [CacheRemoveAspect("Bps.BpsBase.Business.Concrete.Managers.ST.", typeof(MemoryCacheManager))]
        public StandardResponse Ncch_StokMalGirisCikisEski_Log(StokHareketModel model, Global global, bool yetkiKontrol = true)
        {
            var sonuc = new StandardResponse();
            var baslik = model.Baslik.ShallowCopy();
            var kalemler = model.Kalemler;
            var sthrtp = baslik.STHRTP;
            string dpkodu = sthrtp == 0 ? baslik.GRDEPO : baslik.CKDEPO;

            var evrakmodel = new EvrakNoUretParamModel();
            evrakmodel.TabloAdi = "STHBAS";
            evrakmodel.TeknikAd = "BELGEN";
            evrakmodel.IslemTur = baslik.STFTNO;
            var evrakResponse = _gnevrkService.Ncch_EvrakNoUret_NLog(global, evrakmodel);

            if (evrakResponse.Status != ResponseStatusEnum.OK)
            {
                throw new BusinessException(evrakResponse.Message);
            }

            var saveDate = DateTime.Now;
            baslik.EKKULL = global.UserKod;
            baslik.ETARIH = saveDate;
            baslik.SIRKID = global.SirketId.Value;
            baslik.KYNKKD = global.KaynakKod;
            baslik.ACTIVE = true;
            baslik.SLINDI = false;
            baslik.CHKCTR = false;
            baslik.BELGEN = evrakResponse.Nesne;

            foreach (var data in kalemler)
            {
                data.EKKULL = global.UserKod;
                data.ETARIH = saveDate;
                data.SIRKID = global.SirketId.Value;
                data.KYNKKD = global.KaynakKod;
                data.ACTIVE = true;
                data.SLINDI = false;
                data.CHKCTR = false;
                data.BELGEN = evrakResponse.Nesne;
                data.BELTRH = baslik.BELTRH;
                data.GRDEPO = baslik.GRDEPO;
                data.CKDEPO = baslik.CKDEPO;
                data.STFTNO = baslik.STFTNO;

                STDEPO stDepo = null;

                if (sthrtp == 0 || sthrtp == 1)
                {
                    stDepo = _stdepoDal.Get(g =>
                        g.SIRKID == global.SirketId && g.STKODU == data.STKODU && g.DPKODU == dpkodu && g.ACTIVE);
                }

                if (stDepo == null)
                {
                    throw new BusinessException(data.STKODU + " depo tanımlaması yapılmamıştır, lütfen kontrol ediniz!");
                }

                List<STOLCU> olcuList = _stolcuService.Ncch_GetByStKod_NLog(data.STKODU, global).Items;

                if (olcuList != null && olcuList.Count > 0)
                {
                    STOLCU olcu = olcuList.FirstOrDefault(o => o.OLCHDF == data.GROLBR);
                    if (olcu == null)
                    {
                        throw new BusinessException(data.STKODU + " - " + data.STKNAM + Environment.NewLine + data.GROLBR + " için ölçü çevrimi bulunamadı!");
                    }
                }

                var stkmiz = _stkmizDal.Get(g =>
                    g.SIRKID == global.SirketId && g.STKODU == data.STKODU && g.ACTIVE);

                if (stkmiz == null)
                {
                    throw new BusinessException(data.STKODU + " maliyet tanımlaması yapılmamıştır, lütfen kontrol ediniz!");
                }

                var date = new DateTime(stkmiz.MALIYL, stkmiz.MALIAY, 1);
                var belgeTarihi = baslik.BELTRH;

                if (date < belgeTarihi && date.Month != belgeTarihi.Month)
                {
                    throw new BusinessException(data.STKODU + " malzemenin maliyet dönemi kapanmıştır, işlem yapamazsınız! ( " + baslik.BELTRH.Year + "-" +
                                                baslik.BELTRH.Month + " )");
                }

                if (date > belgeTarihi && date.Month != belgeTarihi.Month)
                {
                    throw new BusinessException(data.STKODU + " malzemenin maliyet dönemi açılmamıştır, işlem yapamazsınız! ( " + baslik.BELTRH.Year + "-" +
                                                baslik.BELTRH.Month + " )");
                }
            }

            _sthbasDal.Add(baslik);

            foreach (var data in kalemler)
            {
                var stDepo = _stdepoDal.Get(g =>
                    g.SIRKID == global.SirketId && g.STKODU == data.STKODU && g.DPKODU == dpkodu && g.ACTIVE);

                var stkmiz = _stkmizDal.Get(g =>
                    g.SIRKID == global.SirketId && g.STKODU == data.STKODU && g.ACTIVE &&
                    g.MALIAY == baslik.BELTRH.Month && g.MALIYL == baslik.BELTRH.Year);

                var copy = data.ShallowCopy();
                copy.STHRTP = sthrtp;
                copy.GRMKTR = data.GRMKTR.Value;
                copy.GROLBR = data.GROLBR;

                decimal? gnMiktar = null;

                List<STOLCU> olcuList = _stolcuService.Ncch_GetByStKod_NLog(copy.STKODU, global).Items;

                if (olcuList != null && olcuList.Count > 0)
                {
                    STOLCU olcu = olcuList.FirstOrDefault(o => o.OLCHDF == copy.GROLBR);
                    if (olcu == null)
                    {
                        throw new BusinessException(data.STKODU + " - " + data.STKNAM + Environment.NewLine + data.GROLBR + " için ölçü çevrimi bulunamadı!");
                    }

                    gnMiktar = copy.GRMKTR.Value / Convert.ToDecimal(olcu.BOLNEN);

                    copy.OLCUKD = olcu.OLCUKD;
                    copy.GNMKTR = gnMiktar;

                    if (sthrtp == 1) gnMiktar *= -1;
                }

                if (gnMiktar == null)
                {
                    throw new BusinessException(data.STKODU + " - " + data.STKNAM + Environment.NewLine + (sthrtp == 0 ? "Giriş" : "Çıkış") + " miktarı hatalı!");
                }

                stDepo.USESTK += gnMiktar.Value;
                stDepo.DEKULL = global.UserKod;
                stDepo.DTARIH = saveDate;
                _stdepoDal.Update(stDepo);

                stkmiz.DGMKTR += gnMiktar.Value;
                stkmiz.DEKULL = global.UserKod;
                stkmiz.DTARIH = saveDate;
                _stkmizDal.Update(stkmiz);

                _sthrktDal.Add(copy);
            }

            sonuc.Message = evrakResponse.Nesne;
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        //[FluentValidationAspect(typeof(GenelStokKartValidator))]
        [CacheRemoveAspect("Bps.BpsBase.Business.Concrete.Managers.ST.", typeof(MemoryCacheManager))]
        public StandardResponse Ncch_StokMalGirisCikis_Log(StokHareketModel model, Global global, bool yetkiKontrol = true)
        {
            var sonuc = new StandardResponse();
            var baslik = model.Baslik.ShallowCopy();
            var kalemler = model.Kalemler;
            var sthrtp = baslik.STHRTP;
            //string dpkodu = sthrtp == 0 ? baslik.GRDEPO : baslik.CKDEPO;

            //kalemler = kalemler.Where(k => k.gr)

            var evrakmodel = new EvrakNoUretParamModel();
            evrakmodel.TabloAdi = "STHBAS";
            evrakmodel.TeknikAd = "BELGEN";
            evrakmodel.IslemTur = baslik.STFTNO;
            var evrakResponse = _gnevrkService.Ncch_EvrakNoUret_NLog(global, evrakmodel);

            if (evrakResponse.Status != ResponseStatusEnum.OK)
            {
                throw new BusinessException(evrakResponse.Message);
            }

            var saveDate = DateTime.Now;
            baslik.EKKULL = global.UserKod;
            baslik.ETARIH = saveDate;
            baslik.SIRKID = global.SirketId.Value;
            baslik.KYNKKD = global.KaynakKod;
            baslik.ACTIVE = true;
            baslik.SLINDI = false;
            baslik.CHKCTR = false;
            baslik.BELGEN = evrakResponse.Nesne;

            foreach (var data in kalemler)
            {
                data.EKKULL = global.UserKod;
                data.ETARIH = saveDate;
                data.SIRKID = global.SirketId.Value;
                data.KYNKKD = global.KaynakKod;
                data.ACTIVE = true;
                data.SLINDI = false;
                data.CHKCTR = false;
                data.BELGEN = evrakResponse.Nesne;
                data.BELTRH = baslik.BELTRH;
                data.GRDEPO = string.IsNullOrEmpty(data.GRDEPO) ? baslik.GRDEPO : data.GRDEPO;
                data.CKDEPO = string.IsNullOrEmpty(data.CKDEPO) ? baslik.CKDEPO : data.CKDEPO;
                data.STFTNO = baslik.STFTNO;
                data.PARTIT = data.PARTIT ?? false;

                STDEPO stDepo = null;

                string dpkodu = sthrtp == 0 ? data.GRDEPO : data.CKDEPO;

                if (sthrtp == 0 || sthrtp == 1)
                {
                    stDepo = _stdepoDal.Get(g =>
                        g.SIRKID == global.SirketId && g.STKODU == data.STKODU && g.DPKODU == dpkodu && g.ACTIVE);
                }

                if (stDepo == null)
                {
                    throw new BusinessException(data.STKODU + " depo tanımlaması yapılmamıştır, lütfen kontrol ediniz!");
                }

                //List<STOLCU> olcuList = _stolcuService.Ncch_GetByStKod_NLog(data.STKODU, global, false).Items;
                List<STOLCU> olcuList = _stolcuDal.GetList(g =>
                    g.SIRKID == global.SirketId && g.STKODU == data.STKODU && g.ACTIVE);

                if (olcuList != null && olcuList.Count > 0)
                {
                    STOLCU olcu = olcuList.FirstOrDefault(o => o.OLCHDF == data.GROLBR);
                    if (olcu == null)
                    {
                        throw new BusinessException(data.STKODU + " - " + data.STKNAM + Environment.NewLine + data.GROLBR + " için ölçü çevrimi bulunamadı!");
                    }
                }

                var stkmiz = _stkmizDal.Get(g =>
                    g.SIRKID == global.SirketId && g.STKODU == data.STKODU && g.MALIAY == DateTime.Now.Month && g.ACTIVE && g.MALIYL == DateTime.Now.Year);

                if (stkmiz == null)
                {
                    stkmiz = _stkmizDal.Add(new STKMIZ
                    {
                        SIRKID = global.SirketId.Value,
                        STKODU = data.STKODU,
                        MALIYL = baslik.BELTRH.Year,
                        MALIAY = baslik.BELTRH.Month,
                        KAYORT = 0,
                        STNFIY = 0,
                        DGMKTR = 0,
                        DGSTDG = 0,
                        MALHSP = 0,
                        ACTIVE = true,
                        SLINDI = false,
                        KYNKKD = "3",
                        EKKULL = global.UserKod,
                        ETARIH = DateTime.Now,
                        CHKCTR = false,
                    });
                }

                var date = new DateTime(stkmiz.MALIYL, stkmiz.MALIAY, 1);
                var belgeTarihi = baslik.BELTRH;

                if (date < belgeTarihi && date.Month != belgeTarihi.Month)
                {
                    throw new BusinessException(data.STKODU + " malzemenin maliyet dönemi kapanmıştır, işlem yapamazsınız! ( " + baslik.BELTRH.Year + "-" +
                                                baslik.BELTRH.Month + " )");
                }

                if (date > belgeTarihi && date.Month != belgeTarihi.Month)
                {
                    throw new BusinessException(data.STKODU + " malzemenin maliyet dönemi açılmamıştır, işlem yapamazsınız! ( " + baslik.BELTRH.Year + "-" +
                                                baslik.BELTRH.Month + " )");
                }
            }

            _sthbasDal.Add(baslik);

            for (int i = 0; i < kalemler.Count; i++)
            {
                STHRKT data = kalemler[i];

                string dpkodu = sthrtp == 0 ? data.GRDEPO : data.CKDEPO;

                STDEPO stDepo = _stdepoDal.Get(g =>
                    g.SIRKID == global.SirketId && g.STKODU == data.STKODU && g.DPKODU == dpkodu && g.ACTIVE);

                STDEPV stDepv = _stdepvDal.Get(g =>
                        g.SIRKID == global.SirketId && g.STKODU == data.STKODU && g.VRKODU == data.VRKODU && g.DPKODU == dpkodu && g.ACTIVE);

                var stvmiz = _stvmizDal.Get(g =>
                        g.SIRKID == global.SirketId && g.STKODU == data.STKODU && g.VRKODU == data.VRKODU && g.ACTIVE &&
                        g.MALIAY == baslik.BELTRH.Month && g.MALIYL == baslik.BELTRH.Year);

                var stkmiz = _stkmizDal.Get(g =>
                    g.SIRKID == global.SirketId && g.STKODU == data.STKODU && g.ACTIVE &&
                    g.MALIAY == baslik.BELTRH.Month && g.MALIYL == baslik.BELTRH.Year);

                var copy = data.ShallowCopy();
                copy.STHRTP = sthrtp;
                copy.GRMKTR = data.GRMKTR.Value;
                copy.GROLBR = data.GROLBR;
                if (stDepv == null)
                {
                    stDepv = _stdepvDal.Add(new STDEPV
                    {
                        SIRKID = global.SirketId.Value,
                        STKODU = copy.STKODU,
                        VRKODU = copy.VRKODU,
                        URYRKD = stDepo.URYRKD,
                        DPKODU = stDepo.DPKODU,
                        ENBLKJ = false,
                        USESTK = 0,
                        BLKSTK = 0,
                        MIPGOS = stDepo.MIPGOS,
                        TEDKOD = stDepo.TEDKOD,
                        DPADRS = stDepo.DPADRS,
                        ULKEKD = stDepo.ULKEKD,
                        ACTIVE = true,
                        SLINDI = false,
                        KYNKKD = "3",
                        EKKULL = global.UserKod,
                        ETARIH = DateTime.Now,
                        CHKCTR = false,

                    });
                }
                if (stvmiz == null)
                {
                    stvmiz = _stvmizDal.Add(new STVMIZ
                    {
                        SIRKID = global.SirketId.Value,
                        STKODU = copy.STKODU,
                        VRKODU = copy.VRKODU,
                        MALIYL = DateTime.Today.Year,
                        MALIAY = DateTime.Today.Month,
                        KAYORT = 0,
                        STNFIY = 0,
                        DGMKTR = 0,
                        DGSTDG = 0,
                        MALHSP = 0,
                        ACTIVE = true,
                        SLINDI = false,
                        KYNKKD = "3",
                        EKKULL = global.UserKod,
                        ETARIH = DateTime.Now,
                        CHKCTR = false,
                    });
                }
                decimal? gnMiktar = null;

                //List<STOLCU> olcuList = _stolcuService.Ncch_GetByStKod_NLog(copy.STKODU, global).Items;
                List<STOLCU> olcuList = _stolcuDal.GetList(g =>
                    g.SIRKID == global.SirketId && g.STKODU == data.STKODU && g.ACTIVE);

                if (olcuList != null && olcuList.Count > 0)
                {
                    STOLCU olcu = olcuList.FirstOrDefault(o => o.OLCHDF == copy.GROLBR);
                    if (olcu == null)
                    {
                        throw new BusinessException(data.STKODU + " - " + data.STKNAM + Environment.NewLine + data.GROLBR + " için ölçü çevrimi bulunamadı!");
                    }

                    if (olcu.BOLLEN > 1) gnMiktar = copy.GRMKTR.Value * Convert.ToDecimal(olcu.BOLLEN);
                    else if (olcu.BOLNEN > 1) gnMiktar = copy.GRMKTR.Value / Convert.ToDecimal(olcu.BOLNEN);
                    else gnMiktar = copy.GRMKTR.Value;

                    //gnMiktar = copy.GRMKTR.Value / Convert.ToDecimal(olcu.BOLNEN);

                    copy.OLCUKD = olcu.OLCUKD;
                    copy.GNMKTR = gnMiktar;

                    if (sthrtp == 1) gnMiktar *= -1;
                }

                if (gnMiktar == null)
                {
                    throw new BusinessException(data.STKODU + " - " + data.STKNAM + Environment.NewLine + (sthrtp == 0 ? "Giriş" : "Çıkış") + " miktarı hatalı!");
                }

                stDepo.USESTK += gnMiktar.Value;
                stDepo.DEKULL = global.UserKod;
                stDepo.DTARIH = saveDate;
                _stdepoDal.Update(stDepo);

                stDepv.USESTK += gnMiktar.Value;
                stDepv.DEKULL = global.UserKod;
                stDepv.DTARIH = saveDate;
                _stdepvDal.Update(stDepv);

                stkmiz.DGMKTR += gnMiktar.Value;
                stkmiz.DEKULL = global.UserKod;
                stkmiz.DTARIH = saveDate;
                _stkmizDal.Update(stkmiz);

                stvmiz.DGMKTR += gnMiktar.Value;
                stvmiz.DEKULL = global.UserKod;
                stvmiz.DTARIH = saveDate;
                _stvmizDal.Update(stvmiz);

                #region WM

                if (model.KaynakWmAdresList.Count > 0 || model.HedefWmAdresList.Count > 0)
                {
                    var depoNo = _gndpnoService.Ncch_GetByDepoKodUretimYeri_NLog(stDepo.URYRKD, dpkodu, global, false).Nesne;
                    if (depoNo != null)
                    {
                        var hareketAtama = _wmhratService.Cch_GetByFisTip_NLog(baslik.STFTNO, global, false);

                        if (hareketAtama.Nesne == null)
                        {
                            throw new BusinessException("Wm Hareket ataması yapılmamıştır!");
                        }

                        var adres = "";
                        if (sthrtp == 0)
                        {
                            adres = model.HedefWmAdresList[i];
                            copy.GRADRS = adres;
                        }
                        else if (sthrtp == 1)
                        {
                            adres = model.KaynakWmAdresList[i];
                            copy.CKADRS = adres;
                        }

                        var adresTanim = _wmadrtService
                            .Cch_GetListByDepoKdDpAdrs_NLog(depoNo.DEPOKD, adres, global, false).Nesne;

                        if (adresTanim == null)
                        {
                            throw new BusinessException("Wm adres bulunamadı!");
                        }

                        if (sthrtp == 0)
                        {
                            if (adresTanim.DGSTBL == true)
                            {
                                throw new BusinessException("Wm Adres depolama için blokelidir!");
                            }

                            var evrModel = new EvrakNoUretParamModel();
                            evrModel.TabloAdi = "WMADRS";
                            evrModel.TeknikAd = "WMASNO";
                            evrModel.IslemTur = 0;
                            var evrkResponse = _gnevrkService.Ncch_EvrakNoUret_NLog(global, evrModel);

                            if (evrkResponse.Status != ResponseStatusEnum.OK)
                            {
                                throw new BusinessException(evrakResponse.Message);
                            }

                            var wmAdrs = new WMADRS()
                            {
                                SIRKID = global.SirketId.Value,
                                STKODU = copy.STKODU,
                                WMASNO = evrkResponse.Nesne,
                                URYRKD = stDepo.URYRKD,
                                DEPOKD = depoNo.DEPOKD,
                                DPTIPI = adresTanim.DPTIPI,
                                DPADRS = adres,
                                DGSTBL = adresTanim.DGSTBL,
                                DCSTBL = adresTanim.DCSTBL,
                                STARIH = DateTime.Now,
                                SDPTAR = DateTime.Now,
                                SDETAR = DateTime.Now,
                                STHRTP = copy.STHRTP,
                                STFTNO = copy.STFTNO,
                                BELGEN = copy.BELGEN,
                                BELTRH = copy.BELTRH,
                                SATIRN = copy.SATIRN,
                                TPLSTK = 0,
                                USESTK = copy.GNMKTR,
                                DPLSTK = 0,
                                DPCSTK = 0,
                                PARTIT = copy.PARTIT ?? false,
                                PARTIN = copy.PARTIN,
                                ACTIVE = true,
                                SLINDI = false,
                                EKKULL = global.UserKod,
                                ETARIH = DateTime.Now,
                                KYNKKD = global.KaynakKod,
                                CHKCTR = false,
                            };
                            _wmadrsDal.Add(wmAdrs);
                        }

                        if (sthrtp == 1)
                        {
                            if (adresTanim.DCSTBL == true)
                            {
                                throw new BusinessException("Wm Adres depo çıkış için blokelidir!");
                            }

                            var adrsList = _wmadrsDal.GetList(g =>
                                g.SIRKID == global.SirketId && g.STKODU == copy.STKODU && g.DPADRS == adres &&
                                g.ACTIVE && g.URYRKD == stDepo.URYRKD && g.DEPOKD == depoNo.DEPOKD &&
                                g.PARTIT.Value == copy.PARTIT.Value && g.PARTIN == copy.PARTIN).OrderBy(o => o.SDPTAR).ToList();

                            if (adrsList.Count < 1)
                            {
                                throw new BusinessException("Wm Adreste stok bulunamadı! (" + copy.STKODU + ")");
                            }

                            var toplamStok = adrsList.Sum(s => s.USESTK);

                            if (copy.GNMKTR > toplamStok)
                            {
                                throw new BusinessException("Depodaki '" + adres + "' adresinde " + copy.GNMKTR + " adet malzeme bulunmamaktadır!");
                            }

                            decimal tempMiktar = copy.GNMKTR.Value;
                            foreach (var wmadres in adrsList)
                            {
                                if (wmadres.USESTK >= tempMiktar)
                                {
                                    wmadres.USESTK = wmadres.USESTK - tempMiktar;
                                    _wmadrsDal.Update(wmadres);
                                    break;
                                }

                                tempMiktar = tempMiktar - wmadres.USESTK.Value;
                                wmadres.USESTK = 0;

                                _wmadrsDal.Update(wmadres);
                            }
                        }
                    }
                }

                #endregion

                _sthrktDal.Add(copy);
            }

            if (model.SiparisList != null && model.SiparisList.Count > 0)
            {//sipariş miktarı düzenlenip öyle kaydedilecek
                foreach (SPFHAR spfhar in model.SiparisList)
                {
                    spfhar.DEKULL = global.UserKod;
                    spfhar.DTARIH = saveDate;
                    _spfharDal.Update(spfhar);
                }

                if (model.RezervasyonList != null)
                {
                    foreach (SPREZV sprezv in model.RezervasyonList)
                    {
                        sprezv.DEKULL = global.UserKod;
                        sprezv.DTARIH = saveDate;
                        _sprezvDal.Update(sprezv);
                    }
                }
            }

            sonuc.Message = evrakResponse.Nesne;
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        //[FluentValidationAspect(typeof(GenelStokKartValidator))]
        [CacheRemoveAspect("Bps.BpsBase.Business.Concrete.Managers.ST.", typeof(MemoryCacheManager))]
        public StandardResponse Ncch_StokGirisCikisByOptimizasyon_Log(StokHareketModel cikisModel, StokHareketModel girisModel, Global global, bool yetkiKontrol = true)
        {
            var sonuc = new StandardResponse();
            var saveDate = DateTime.Now;

            //Stok çıkış kaydı
            string cikisEvrakNo = "";
            var cikisBaslik = cikisModel.Baslik.ShallowCopy();
            var cikisKalemler = cikisModel.Kalemler;

            var cikisEvrak = new EvrakNoUretParamModel();
            cikisEvrak.TabloAdi = "STHBAS";
            cikisEvrak.TeknikAd = "BELGEN";
            cikisEvrak.IslemTur = cikisBaslik.STFTNO;
            var cikisEvrakResponse = _gnevrkService.Ncch_EvrakNoUret_NLog(global, cikisEvrak);

            if (cikisEvrakResponse.Status != ResponseStatusEnum.OK)
            {
                throw new BusinessException(cikisEvrakResponse.Message);
            }

            cikisEvrakNo = cikisEvrakResponse.Nesne;

            cikisBaslik.EKKULL = global.UserKod;
            cikisBaslik.ETARIH = saveDate;
            cikisBaslik.SIRKID = global.SirketId.Value;
            cikisBaslik.KYNKKD = global.KaynakKod;
            cikisBaslik.ACTIVE = true;
            cikisBaslik.SLINDI = false;
            cikisBaslik.CHKCTR = false;
            cikisBaslik.BELGEN = cikisEvrakResponse.Nesne;
            cikisBaslik.OPTMZS = true;

            foreach (var data in cikisKalemler)
            {
                data.EKKULL = global.UserKod;
                data.ETARIH = saveDate;
                data.SIRKID = global.SirketId.Value;
                data.KYNKKD = global.KaynakKod;
                data.ACTIVE = true;
                data.SLINDI = false;
                data.CHKCTR = false;
                data.BELGEN = cikisEvrakResponse.Nesne;
                data.BELTRH = cikisBaslik.BELTRH;
                data.GRDEPO = cikisBaslik.GRDEPO;
                data.CKDEPO = cikisBaslik.CKDEPO;
                data.STFTNO = cikisBaslik.STFTNO;

                List<STOLCU> olcuList = _stolcuService.Ncch_GetByStKod_NLog(data.STKODU, global).Items;

                if (olcuList != null && olcuList.Count > 0)
                {
                    STOLCU olcu = olcuList.FirstOrDefault(o => o.OLCHDF == data.GROLBR);
                    if (olcu == null)
                    {
                        throw new BusinessException(data.STKODU + " - " + data.STKNAM + Environment.NewLine + data.GROLBR + " için ölçü çevrimi bulunamadı!");
                    }
                }

                STDEPO stDepo = _stdepoDal.Get(g =>
                    g.SIRKID == global.SirketId && g.STKODU == data.STKODU && g.DPKODU == cikisBaslik.CKDEPO && g.ACTIVE);

                if (stDepo == null)
                {
                    throw new BusinessException(data.STKODU + " depo tanımlaması yapılmamıştır, lütfen kontrol ediniz!");
                }

                var stkmiz = _stkmizDal.Get(g =>
                    g.SIRKID == global.SirketId && g.STKODU == data.STKODU && g.ACTIVE);

                if (stkmiz == null)
                {
                    throw new BusinessException(data.STKODU + " maliyet tanımlaması yapılmamıştır, lütfen kontrol ediniz!");
                }

                var date = new DateTime(stkmiz.MALIYL, stkmiz.MALIAY, 1);
                var belgeTarihi = cikisBaslik.BELTRH;

                if (date < belgeTarihi && date.Month != belgeTarihi.Month)
                {
                    throw new BusinessException(data.STKODU + " malzemenin maliyet dönemi kapanmıştır, işlem yapamazsınız! ( " + cikisBaslik.BELTRH.Year + "-" +
                                                cikisBaslik.BELTRH.Month + " )");
                }

                if (date > belgeTarihi && date.Month != belgeTarihi.Month)
                {
                    throw new BusinessException(data.STKODU + " malzemenin maliyet dönemi açılmamıştır, işlem yapamazsınız! ( " + cikisBaslik.BELTRH.Year + "-" +
                                                cikisBaslik.BELTRH.Month + " )");
                }
            }

            _sthbasDal.Add(cikisBaslik);

            foreach (var data in cikisKalemler)
            {
                var stDepo = _stdepoDal.Get(g =>
                    g.SIRKID == global.SirketId && g.STKODU == data.STKODU && g.DPKODU == cikisBaslik.CKDEPO && g.ACTIVE);

                var stkmiz = _stkmizDal.Get(g =>
                    g.SIRKID == global.SirketId && g.STKODU == data.STKODU && g.ACTIVE &&
                    g.MALIAY == cikisBaslik.BELTRH.Month && g.MALIYL == cikisBaslik.BELTRH.Year);

                var copy = data.ShallowCopy();
                copy.STHRTP = 1;
                copy.GRMKTR = data.GRMKTR.Value;
                copy.GROLBR = data.GROLBR;

                decimal? gnMiktar = null;

                List<STOLCU> olcuList = _stolcuService.Ncch_GetByStKod_NLog(copy.STKODU, global).Items;

                if (olcuList != null && olcuList.Count > 0)
                {
                    STOLCU olcu = olcuList.FirstOrDefault(o => o.OLCHDF == copy.GROLBR);
                    if (olcu == null)
                    {
                        throw new BusinessException(data.STKODU + " - " + data.STKNAM + Environment.NewLine + data.GROLBR + " için ölçü çevrimi bulunamadı!");
                    }

                    gnMiktar = copy.GRMKTR.Value / Convert.ToDecimal(olcu.BOLNEN);

                    copy.OLCUKD = olcu.OLCUKD;
                    copy.GNMKTR = gnMiktar;

                    gnMiktar *= -1;
                }

                if (gnMiktar == null)
                {
                    throw new BusinessException(data.STKODU + " - " + data.STKNAM + Environment.NewLine + "Çıkış miktarı hatalı!");
                }

                stDepo.USESTK += gnMiktar.Value;
                stDepo.DEKULL = global.UserKod;
                stDepo.DTARIH = saveDate;
                _stdepoDal.Update(stDepo);

                stkmiz.DGMKTR += gnMiktar.Value;
                stkmiz.DEKULL = global.UserKod;
                stkmiz.DTARIH = saveDate;
                _stkmizDal.Update(stkmiz);

                _sthrktDal.Add(copy);
            }

            //Stok giriş kaydı
            string girisEvrakNo = "";
            if (girisModel.Kalemler.Count > 0)
            {
                var girisBaslik = girisModel.Baslik.ShallowCopy();
                var girisKalemler = girisModel.Kalemler;

                var girisEvrak = new EvrakNoUretParamModel();
                girisEvrak.TabloAdi = "STHBAS";
                girisEvrak.TeknikAd = "BELGEN";
                girisEvrak.IslemTur = girisBaslik.STFTNO;
                var girisEvrakResponse = _gnevrkService.Ncch_EvrakNoUret_NLog(global, girisEvrak);

                if (girisEvrakResponse.Status != ResponseStatusEnum.OK)
                {
                    throw new BusinessException(girisEvrakResponse.Message);
                }

                girisEvrakNo = girisEvrakResponse.Nesne;

                girisBaslik.EKKULL = global.UserKod;
                girisBaslik.ETARIH = saveDate;
                girisBaslik.SIRKID = global.SirketId.Value;
                girisBaslik.KYNKKD = global.KaynakKod;
                girisBaslik.ACTIVE = true;
                girisBaslik.SLINDI = false;
                girisBaslik.CHKCTR = false;
                girisBaslik.BELGEN = girisEvrakResponse.Nesne;
                girisBaslik.OPTMZS = true;

                foreach (var data in girisKalemler)
                {
                    data.EKKULL = global.UserKod;
                    data.ETARIH = saveDate;
                    data.SIRKID = global.SirketId.Value;
                    data.KYNKKD = global.KaynakKod;
                    data.ACTIVE = true;
                    data.SLINDI = false;
                    data.CHKCTR = false;
                    data.BELGEN = girisEvrakResponse.Nesne;
                    data.BELTRH = girisBaslik.BELTRH;
                    data.GRDEPO = girisBaslik.GRDEPO;
                    data.CKDEPO = girisBaslik.CKDEPO;
                    data.STFTNO = girisBaslik.STFTNO;

                    STDEPO stDepo = _stdepoDal.Get(g =>
                            g.SIRKID == global.SirketId && g.STKODU == data.STKODU && g.DPKODU == girisBaslik.GRDEPO && g.ACTIVE);

                    if (stDepo == null)
                    {
                        throw new BusinessException(data.STKODU + " depo tanımlaması yapılmamıştır, lütfen kontrol ediniz!");
                    }
                }

                _sthbasDal.Add(girisBaslik);

                foreach (var data in girisKalemler)
                {
                    var stDepo = _stdepoDal.Get(g =>
                        g.SIRKID == global.SirketId && g.STKODU == data.STKODU && g.DPKODU == girisBaslik.GRDEPO && g.ACTIVE);

                    var stkmiz = _stkmizDal.Get(g =>
                        g.SIRKID == global.SirketId && g.STKODU == data.STKODU && g.ACTIVE &&
                        g.MALIAY == girisBaslik.BELTRH.Month && g.MALIYL == girisBaslik.BELTRH.Year);

                    var copy = data.ShallowCopy();
                    copy.STHRTP = 0;
                    copy.GRMKTR = data.GRMKTR.Value;
                    copy.GROLBR = data.GROLBR;

                    decimal? gnMiktar = null;

                    List<STOLCU> olcuList = _stolcuService.Ncch_GetByStKod_NLog(copy.STKODU, global).Items;

                    if (olcuList != null && olcuList.Count > 0)
                    {
                        STOLCU olcu = olcuList.FirstOrDefault(o => o.OLCHDF == copy.GROLBR);
                        if (olcu == null)
                        {
                            throw new BusinessException(data.STKODU + " - " + data.STKNAM + Environment.NewLine + data.GROLBR + " için ölçü çevrimi bulunamadı!");
                        }

                        gnMiktar = copy.GRMKTR.Value / Convert.ToDecimal(olcu.BOLNEN);

                        copy.OLCUKD = olcu.OLCUKD;
                        copy.GNMKTR = gnMiktar;
                    }

                    if (gnMiktar == null)
                    {
                        throw new BusinessException(data.STKODU + " - " + data.STKNAM + Environment.NewLine + "Giriş miktarı hatalı!");
                    }

                    stDepo.USESTK += gnMiktar.Value;
                    stDepo.DEKULL = global.UserKod;
                    stDepo.DTARIH = saveDate;
                    _stdepoDal.Update(stDepo);

                    stkmiz.DGMKTR += gnMiktar.Value;
                    stkmiz.DEKULL = global.UserKod;
                    stkmiz.DTARIH = saveDate;
                    _stkmizDal.Update(stkmiz);

                    _sthrktDal.Add(copy);
                }
            }

            //Optimizasyon kaydı

            var optEvrak = new EvrakNoUretParamModel();
            optEvrak.TabloAdi = "STOPTM";
            optEvrak.TeknikAd = "BELGEN";
            optEvrak.IslemTur = 0;
            var optEvrakResponse = _gnevrkService.Ncch_EvrakNoUret_NLog(global, optEvrak);

            if (optEvrakResponse.Status != ResponseStatusEnum.OK)
            {
                throw new BusinessException(optEvrakResponse.Message);
            }

            var optimizasyon = cikisModel.Optimizasyon.ShallowCopy();
            optimizasyon.BELGEN = optEvrakResponse.Nesne;
            optimizasyon.STKODU = cikisKalemler[0].STKODU;
            optimizasyon.STKNAM = cikisKalemler[0].STKNAM;
            optimizasyon.MCBELG = cikisEvrakNo;
            optimizasyon.MGBELG = girisEvrakNo;
            optimizasyon.EKKULL = global.UserKod;
            optimizasyon.ETARIH = saveDate;
            optimizasyon.KYNKKD = global.KaynakKod;
            optimizasyon.SIRKID = global.SirketId.Value;
            _stoptmDal.Add(optimizasyon);

            sonuc.Message = optEvrakResponse.Nesne + Environment.NewLine + cikisEvrakNo + Environment.NewLine + girisEvrakNo;
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        //[FluentValidationAspect(typeof(GenelStokKartValidator))]
        [CacheRemoveAspect("Bps.BpsBase.Business.Concrete.Managers.ST.", typeof(MemoryCacheManager))]
        public StandardResponse Ncch_StokDepoTransfer_Log(StokHareketModel model, Global global, bool yetkiKontrol = true)
        {
            var sonuc = new StandardResponse();
            var baslik = model.Baslik;
            var kalemler = model.Kalemler;

            if (baslik.GRDEPO == baslik.CKDEPO)
            {
                throw new BusinessException("Giriş-Çıkış depoları aynı olamaz!");
            }

            var evrakmodel = new EvrakNoUretParamModel();
            evrakmodel.TabloAdi = "STHBAS";
            evrakmodel.TeknikAd = "BELGEN";
            evrakmodel.IslemTur = baslik.STFTNO;
            var evrakResponse = _gnevrkService.Ncch_EvrakNoUret_NLog(global, evrakmodel);

            if (evrakResponse.Status != ResponseStatusEnum.OK)
            {
                throw new BusinessException(evrakResponse.Message);
            }

            var saveDate = DateTime.Now;
            baslik.EKKULL = global.UserKod;
            baslik.ETARIH = saveDate;
            baslik.SIRKID = global.SirketId.Value;
            baslik.KYNKKD = global.KaynakKod;
            baslik.ACTIVE = true;
            baslik.SLINDI = false;
            baslik.CHKCTR = false;
            baslik.BELGEN = evrakResponse.Nesne;

            foreach (var data in kalemler)
            {
                data.EKKULL = global.UserKod;
                data.ETARIH = saveDate;
                data.SIRKID = global.SirketId.Value;
                data.KYNKKD = global.KaynakKod;
                data.ACTIVE = true;
                data.SLINDI = false;
                data.CHKCTR = false;
                data.BELGEN = evrakResponse.Nesne;
                data.GRDEPO = baslik.GRDEPO;
                data.STFTNO = baslik.STFTNO;

                var cstDepo = _stdepoDal.Get(g =>
                    g.SIRKID == global.SirketId && g.STKODU == data.STKODU && g.DPKODU == baslik.CKDEPO && g.ACTIVE);

                if (cstDepo == null)
                {
                    throw new BusinessException(data.STKODU + " depo tanımlaması yapılmamıştır, lütfen kontrol ediniz!");
                }

                var stDepo = _stdepoDal.Get(g =>
                    g.SIRKID == global.SirketId && g.STKODU == data.STKODU && g.DPKODU == baslik.GRDEPO && g.ACTIVE);

                if (stDepo == null)
                {
                    var newGirisDepo = new STDEPO()
                    {
                        STKODU = data.STKODU,
                        URYRKD = cstDepo.URYRKD,
                        DPKODU = baslik.GRDEPO,
                        ENBLKJ = false,
                        USESTK = data.GNMKTR.Value,
                        BLKSTK = 0,
                        MIPGOS = false,
                        TEDKOD = "",
                        DPADRS = "",
                        SIRKID = global.SirketId.Value,
                        EKKULL = global.UserKod,
                        ETARIH = DateTime.Now,
                        ACTIVE = true,
                        KYNKKD = global.KaynakKod,
                        SLINDI = false,
                        CHKCTR = false,
                        ULKEKD = ""
                    };
                    _stdepoDal.Add(newGirisDepo);

                    var copyGiris = data.ShallowCopy();
                    var copyCikis = data.ShallowCopy();

                    copyGiris.GRMKTR = data.GNMKTR.Value;
                    copyGiris.GROLBR = data.OLCUKD;
                    copyGiris.STHRTP = 0;

                    copyCikis.GRMKTR = data.GNMKTR.Value;
                    copyCikis.GROLBR = data.OLCUKD;
                    copyCikis.STHRTP = 1;

                    cstDepo.USESTK = cstDepo.USESTK - data.GNMKTR.Value;
                    cstDepo.DEKULL = global.UserKod;
                    cstDepo.DTARIH = saveDate;
                    _stdepoDal.Update(cstDepo);

                    _sthrktDal.Add(copyGiris);
                    _sthrktDal.Add(copyCikis);
                }

                var stkmiz = _stkmizDal.Get(g =>
                    g.SIRKID == global.SirketId && g.STKODU == data.STKODU && g.MALIYL == DateTime.Now.Year && g.MALIAY == DateTime.Now.Month && g.ACTIVE);

                if (stkmiz == null)
                {
                    stkmiz = _stkmizDal.Add(new STKMIZ
                    {
                        SIRKID = global.SirketId.Value,
                        STKODU = data.STKODU,
                        MALIYL = baslik.BELTRH.Year,
                        MALIAY = baslik.BELTRH.Month,
                        KAYORT = 0,
                        STNFIY = 0,
                        DGMKTR = 0,
                        DGSTDG = 0,
                        MALHSP = 0,
                        ACTIVE = true,
                        SLINDI = false,
                        KYNKKD = "3",
                        EKKULL = global.UserKod,
                        ETARIH = DateTime.Now,
                        CHKCTR = false,
                    });
                }

                var date = new DateTime(stkmiz.MALIYL, stkmiz.MALIAY, 1);
                var belgeTarihi = baslik.BELTRH;

                if (date < belgeTarihi && date.Month != belgeTarihi.Month)
                {
                    throw new BusinessException(data.STKODU + " malzemenin maliyet dönemi kapanmıştır, işlem yapamazsınız! ( " + baslik.BELTRH.Year + "-" +
                                                baslik.BELTRH.Month + " )");
                }

                if (date > belgeTarihi && date.Month != belgeTarihi.Month)
                {
                    throw new BusinessException(data.STKODU + " malzemenin maliyet dönemi açılmamıştır, işlem yapamazsınız! ( " + baslik.BELTRH.Year + "-" +
                                                baslik.BELTRH.Month + " )");
                }
            }

            _sthbasDal.Add(baslik);

            foreach (var data in kalemler)
            {
                var gstDepo = _stdepoDal.Get(g =>
                    g.SIRKID == global.SirketId && g.STKODU == data.STKODU && g.DPKODU == baslik.GRDEPO && g.ACTIVE);
                STDEPV gstDepv = _stdepvDal.Get(g =>
                        g.SIRKID == global.SirketId && g.STKODU == data.STKODU && g.VRKODU == data.VRKODU && g.DPKODU == baslik.GRDEPO && g.ACTIVE);

                if (gstDepv == null)
                {
                    gstDepv = _stdepvDal.Add(new STDEPV
                    {
                        SIRKID = global.SirketId.Value,
                        STKODU = data.STKODU,
                        VRKODU = data.VRKODU,
                        URYRKD = gstDepo.URYRKD,
                        DPKODU = gstDepo.DPKODU,
                        ENBLKJ = false,
                        USESTK = 0,
                        BLKSTK = 0,
                        MIPGOS = gstDepo.MIPGOS,
                        TEDKOD = gstDepo.TEDKOD,
                        DPADRS = gstDepo.DPADRS,
                        ULKEKD = gstDepo.ULKEKD,
                        ACTIVE = true,
                        SLINDI = false,
                        KYNKKD = "3",
                        EKKULL = global.UserKod,
                        ETARIH = DateTime.Now,
                        CHKCTR = false,

                    });
                }

                if (gstDepo != null)
                {
                    var cstDepo = _stdepoDal.Get(g =>
                        g.SIRKID == global.SirketId && g.STKODU == data.STKODU && g.DPKODU == baslik.CKDEPO && g.ACTIVE);
                    STDEPV cstDepv = _stdepvDal.Get(g =>
                        g.SIRKID == global.SirketId && g.STKODU == data.STKODU && g.VRKODU == data.VRKODU && g.DPKODU == baslik.CKDEPO && g.ACTIVE);
                    
                    var copyGiris = data.ShallowCopy();
                    var copyCikis = data.ShallowCopy();


                    copyGiris.GRMKTR = data.GNMKTR.Value;
                    copyGiris.GROLBR = data.OLCUKD;
                    copyGiris.STHRTP = 0;

                    copyCikis.GRMKTR = data.GNMKTR.Value;
                    copyCikis.GROLBR = data.OLCUKD;
                    copyCikis.STHRTP = 1;


                    gstDepo.USESTK = gstDepo.USESTK + data.GNMKTR.Value;
                    gstDepo.DEKULL = global.UserKod;
                    gstDepo.DTARIH = saveDate;
                    _stdepoDal.Update(gstDepo);

                    gstDepv.USESTK = gstDepv.USESTK + data.GNMKTR.Value;
                    gstDepv.DEKULL = global.UserKod;
                    gstDepv.DTARIH = saveDate;
                    _stdepvDal.Update(gstDepv);

                    cstDepo.USESTK = gstDepo.USESTK - data.GNMKTR.Value;
                    cstDepo.DEKULL = global.UserKod;
                    cstDepo.DTARIH = saveDate;
                    _stdepoDal.Update(gstDepo);

                    cstDepv.USESTK = gstDepv.USESTK - data.GNMKTR.Value;
                    cstDepv.DEKULL = global.UserKod;
                    cstDepv.DTARIH = saveDate;
                    _stdepvDal.Update(gstDepv);

                    _sthrktDal.Add(copyGiris);
                    _sthrktDal.Add(copyCikis);
                }
            }

            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        //[FluentValidationAspect(typeof(GenelStokKartValidator))]
        [CacheRemoveAspect("Bps.BpsBase.Business.Concrete.Managers.ST.", typeof(MemoryCacheManager))]
        public StandardResponse Ncch_StokAdresTransferWm_Log(List<StokAdresTransferModel> modelList, Global global, bool yetkiKontrol = true)
        {
            STFTIP fisTip;
            if (modelList != null && modelList.Count > 0)
            {
                fisTip = _stftipService.Cch_GetByFisTipNo_NLog(modelList[0].Stftno, global, false).Nesne;
                if (fisTip == null) throw new BusinessException("Stok Fiş Tipi bulunamadı!");

            }
            else throw new BusinessException("Adres transfer modeli bulunamadı!");

            var sonuc = new StandardResponse();
            var evrModel = new EvrakNoUretParamModel();
            var evrkResponse = new StandardResponse<string>();

            for (int i = 0; i < modelList.Count; i++)
            {
                var kaynakAdres = modelList[i].KaynakStokAdresModel;
                var miktar = Convert.ToDecimal(modelList[i].Miktar);
                var stokKodu = kaynakAdres.STKODU;

                var depoNo = _gndpnoService.Ncch_GetByDepoKodUretimYeri_NLog(kaynakAdres.URYRKD, kaynakAdres.DPKODU, global, false).Nesne;
                if (depoNo != null)
                {
                    var hareketAtama = _wmhratService.Cch_GetByFisTip_NLog(fisTip.STFTNO, global, false);
                    if (hareketAtama.Nesne == null) throw new BusinessException("Wm Hareket ataması yapılmamıştır!");

                    var kaynakAdresTanim = _wmadrtService
                        .Cch_GetListByDepoKdDpAdrs_NLog(depoNo.DEPOKD, kaynakAdres.DPADRS, global, false).Nesne;
                    if (kaynakAdresTanim == null) throw new BusinessException(kaynakAdres.DPTANM + "'da " + kaynakAdres.DPADRS + " adresi bulunamadı!");
                    if (kaynakAdresTanim.DCSTBL == true) throw new BusinessException(kaynakAdres.DPADRS + " adresi depo çıkış için blokelidir!");

                    var hedefAdresTanim = _wmadrtService
                        .Cch_GetListByDepoKdDpAdrs_NLog(depoNo.DEPOKD, modelList[i].HedefAdres, global, false).Nesne;
                    if (hedefAdresTanim == null) throw new BusinessException(kaynakAdres.DPTANM + "'da " + modelList[i].HedefAdres + " adresi bulunamadı!");
                    if (hedefAdresTanim.DGSTBL == true) throw new BusinessException(modelList[i].HedefAdres + " adresi depolama için blokelidir!");

                    // Kaynak adresten çıkış

                    if (kaynakAdres.PARTIN == "") kaynakAdres.PARTIN = null;
                    var adrsList = _wmadrsDal.GetList(g =>
                        g.SIRKID == global.SirketId && g.STKODU == stokKodu && g.DPADRS == kaynakAdres.DPADRS &&
                        g.ACTIVE && g.URYRKD == kaynakAdres.URYRKD && g.DEPOKD == depoNo.DEPOKD &&
                        g.PARTIT.Value == kaynakAdres.PARTIT.Value && g.PARTIN == kaynakAdres.PARTIN).OrderBy(o => o.SDPTAR).ToList();

                    if (adrsList != null && adrsList.Count == 0) throw new BusinessException(kaynakAdres.DPADRS + " adresinde stok bulunamadı!");

                    var toplamStok = adrsList.Sum(s => s.USESTK);

                    if (miktar > toplamStok)
                    {
                        throw new BusinessException(kaynakAdres.DPADRS + "' adresinde " + miktar + " yeterli stok bulunmamaktadır!");
                    }

                    decimal tempMiktar = miktar;
                    foreach (var wmAdres in adrsList)
                    {
                        wmAdres.DTARIH = DateTime.Now;
                        wmAdres.DEKULL = global.UserKod;

                        if (wmAdres.USESTK >= tempMiktar)
                        {
                            wmAdres.USESTK = wmAdres.USESTK - tempMiktar;
                            _wmadrsDal.Update(wmAdres);
                            break;
                        }

                        tempMiktar = tempMiktar - wmAdres.USESTK.Value;
                        wmAdres.USESTK = 0;

                        _wmadrsDal.Update(wmAdres);
                    }

                    // Hedef adrese giriş

                    evrModel = new EvrakNoUretParamModel();
                    evrModel.TabloAdi = "WMADRS";
                    evrModel.TeknikAd = "WMASNO";
                    evrModel.IslemTur = 0;
                    evrkResponse = _gnevrkService.Ncch_EvrakNoUret_NLog(global, evrModel);
                    if (evrkResponse.Status != ResponseStatusEnum.OK) throw new BusinessException(evrkResponse.Message);

                    var wmadrs = new WMADRS
                    {
                        WMASNO = evrkResponse.Nesne,
                        URYRKD = kaynakAdres.URYRKD,
                        DEPOKD = depoNo.DEPOKD,
                        DPTIPI = hedefAdresTanim.DPTIPI,
                        DPADRS = hedefAdresTanim.DPADRS,
                        DGSTBL = hedefAdresTanim.DGSTBL,
                        DCSTBL = hedefAdresTanim.DCSTBL,
                        STKODU = stokKodu,
                        USESTK = miktar,
                        STARIH = DateTime.Now,
                        SDPTAR = DateTime.Now,
                        SDETAR = DateTime.Now,
                        STFTNO = fisTip.STFTNO,
                        SATIRN = i + 1,
                        TPLSTK = 0,
                        DPLSTK = 0,
                        DPCSTK = 0,
                        PARTIT = kaynakAdres.PARTIT ?? false,
                        PARTIN = kaynakAdres.PARTIN == "" ? null : kaynakAdres.PARTIN,
                        SIRKID = global.SirketId.Value,
                        ACTIVE = true,
                        SLINDI = false,
                        EKKULL = global.UserKod,
                        ETARIH = DateTime.Now,
                        KYNKKD = global.KaynakKod,
                        CHKCTR = false,
                    };
                    _wmadrsDal.Add(wmadrs);

                    //Stok hareket kaydı

                    var transferSthbas = new STHBAS
                    {
                        ACTIVE = true,
                        SIRKID = global.SirketId.Value,
                        SLINDI = false,
                        STHRTP = 2,
                        STFTNO = 9, //Adres transferi
                        BELTRH = DateTime.Now,
                        GNACIK = "Stok Adres Transferi",
                        GRDEPO = modelList[i].KaynakStokAdresModel.DPKODU,
                        CKDEPO = modelList[i].KaynakStokAdresModel.DPKODU,
                        EKKULL = global.UserKod,
                        ETARIH = DateTime.Now,
                        KYNKKD = global.KaynakKod,
                    };

                    var cikisEvrak = new EvrakNoUretParamModel();
                    cikisEvrak.TabloAdi = "STHBAS";
                    cikisEvrak.TeknikAd = "BELGEN";
                    cikisEvrak.IslemTur = transferSthbas.STFTNO;
                    var cikisEvrakResponse = _gnevrkService.Ncch_EvrakNoUret_NLog(global, cikisEvrak);

                    if (cikisEvrakResponse.Status != ResponseStatusEnum.OK)
                    {
                        throw new BusinessException(cikisEvrakResponse.Message);
                    }

                    transferSthbas.BELGEN = cikisEvrakResponse.Nesne;
                    _sthbasDal.Add(transferSthbas);

                    var transferSthrkt = new STHRKT
                    {
                        SIRKID = global.SirketId.Value,
                        BELGEN = transferSthbas.BELGEN,
                        BELTRH = transferSthbas.BELTRH,
                        CKDEPO = transferSthbas.CKDEPO,
                        GRDEPO = transferSthbas.GRDEPO,
                        GRADRS = modelList[i].HedefAdres,
                        CKADRS = kaynakAdres.DPADRS,
                        STHRTP = transferSthbas.STHRTP,
                        STFTNO = transferSthbas.STFTNO,
                        SATIRN = (i + 1) * 100,
                        STKNAM = modelList[i].KaynakStokAdresModel.STKNAM,
                        STKODU = modelList[i].KaynakStokAdresModel.STKODU,
                        GNMKTR = miktar,
                        GRMKTR = miktar,
                        OLCUKD = modelList[i].KaynakStokAdresModel.OLCUKD,
                        GROLBR = modelList[i].KaynakStokAdresModel.OLCUKD,
                        PARTIT = modelList[i].KaynakStokAdresModel.PARTIT,
                        PARTIN = modelList[i].KaynakStokAdresModel.PARTIN,
                        GNACIK = transferSthbas.GNACIK,
                        ACTIVE = true,
                        SLINDI = false,
                        EKKULL = transferSthbas.EKKULL,
                        ETARIH = transferSthbas.ETARIH,
                        KYNKKD = global.KaynakKod,
                    };

                    _sthrktDal.Add(transferSthrkt);
                }
            }

            sonuc.Message = evrkResponse.Nesne;
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        //[FluentValidationAspect(typeof(GenelStokKartValidator))]
        [CacheRemoveAspect("Bps.BpsBase.Business.Concrete.Managers.ST.", typeof(MemoryCacheManager))]
        public StandardResponse Ncch_SasGiris_Log(StokHareketModel model, Global global, bool yetkiKontrol = true)
        {
            var sonuc = new StandardResponse();
            var baslik = model.Baslik.ShallowCopy();
            var kalemler = model.Kalemler;
            var sthrtp = baslik.STHRTP;
            string dpkodu = sthrtp == 0 ? baslik.GRDEPO : baslik.CKDEPO;

            var evrakmodel = new EvrakNoUretParamModel();
            evrakmodel.TabloAdi = "STHBAS";
            evrakmodel.TeknikAd = "BELGEN";
            evrakmodel.IslemTur = baslik.STFTNO;
            var evrakResponse = _gnevrkService.Ncch_EvrakNoUret_NLog(global, evrakmodel);

            if (evrakResponse.Status != ResponseStatusEnum.OK)
            {
                throw new BusinessException(evrakResponse.Message);
            }

            var saveDate = DateTime.Now;
            baslik.EKKULL = global.UserKod;
            baslik.ETARIH = saveDate;
            baslik.SIRKID = global.SirketId.Value;
            baslik.KYNKKD = global.KaynakKod;
            baslik.ACTIVE = true;
            baslik.SLINDI = false;
            baslik.CHKCTR = false;
            baslik.BELGEN = evrakResponse.Nesne;

            SPFHAR sas = new SPFHAR();
            decimal? oncekiGiren = 0;
            decimal? toplamGiren = 0;
            decimal yuzde = 0;

            foreach (var data in kalemler)
            {
                oncekiGiren = 0;
                toplamGiren = 0;
                yuzde = 0;

                sas = _spfharDal.Get(g =>
                    g.SIRKID == global.SirketId && g.BELGEN == data.USTBLG && g.SATIRN == data.USTKLM);
                oncekiGiren = data.GNMKTR - sas.KLNMKTR;
                toplamGiren = oncekiGiren + data.GRMKTR;

                yuzde = Math.Round(((toplamGiren - data.GNMKTR) / data.GNMKTR ?? 1) * 100);

                if (data.SLINDI || data.GRMKTR == 0) continue;

                data.EKKULL = global.UserKod;
                data.ETARIH = saveDate;
                data.SIRKID = global.SirketId.Value;
                data.KYNKKD = global.KaynakKod;
                data.ACTIVE = true;
                data.SLINDI = false;
                data.CHKCTR = false;
                data.BELGEN = evrakResponse.Nesne;
                data.BELTRH = baslik.BELTRH;
                data.GRDEPO = string.IsNullOrEmpty(data.GRDEPO) ? baslik.GRDEPO : data.GRDEPO;
                data.CKDEPO = string.IsNullOrEmpty(data.CKDEPO) ? baslik.CKDEPO : data.CKDEPO;
                data.STFTNO = baslik.STFTNO;

                STDEPO stDepo = null;

                dpkodu = sthrtp == 0 ? data.GRDEPO : data.CKDEPO;

                if (sthrtp == 0 || sthrtp == 1)
                {
                    stDepo = _stdepoDal.Get(g =>
                        g.SIRKID == global.SirketId && g.STKODU == data.STKODU && g.DPKODU == dpkodu && g.ACTIVE);
                }

                if (stDepo == null)
                {
                    throw new BusinessException(data.STKODU + " depo tanımlaması yapılmamıştır, lütfen kontrol ediniz!");
                }

                //List<STOLCU> olcuList = _stolcuService.Ncch_GetByStKod_NLog(data.STKODU, global, false).Items;
                List<STOLCU> olcuList = _stolcuDal.GetList(g =>
                    g.SIRKID == global.SirketId && g.STKODU == data.STKODU && g.ACTIVE);

                if (olcuList != null && olcuList.Count > 0)
                {
                    STOLCU olcu = olcuList.FirstOrDefault(o => o.OLCHDF == data.GROLBR);
                    if (olcu == null)
                    {
                        throw new BusinessException(data.STKODU + " - " + data.STKNAM + Environment.NewLine + data.GROLBR + " için ölçü çevrimi bulunamadı!");
                    }
                }

                var stkmiz = _stkmizDal.Get(g =>
                    g.SIRKID == global.SirketId && g.STKODU == data.STKODU && g.ACTIVE && g.MALIAY == baslik.BELTRH.Month && g.MALIYL == baslik.BELTRH.Year);

                if (stkmiz == null)
                {
                    stkmiz = _stkmizDal.Add(new STKMIZ
                    {
                        SIRKID = global.SirketId.Value,
                        STKODU = data.STKODU,
                        MALIYL = baslik.BELTRH.Year,
                        MALIAY = baslik.BELTRH.Month,
                        KAYORT = 0,
                        STNFIY = 0,
                        DGMKTR = 0,
                        DGSTDG = 0,
                        MALHSP = 0,
                        ACTIVE = true,
                        SLINDI = false,
                        KYNKKD = "3",
                        EKKULL = global.UserKod,
                        ETARIH = DateTime.Now,
                        CHKCTR = false,
                    });
                }

                var date = new DateTime(stkmiz.MALIYL, stkmiz.MALIAY, 1);
                var belgeTarihi = baslik.BELTRH;

                //if (date < belgeTarihi && date.Month != belgeTarihi.Month)
                //{
                //    throw new BusinessException(data.STKODU + " malzemenin maliyet dönemi kapanmıştır, işlem yapamazsınız! ( " + baslik.BELTRH.Year + "-" +
                //                                baslik.BELTRH.Month + " )");
                //}

                //if (date > belgeTarihi && date.Month != belgeTarihi.Month)
                //{
                //    throw new BusinessException(data.STKODU + " malzemenin maliyet dönemi açılmamıştır, işlem yapamazsınız! ( " + baslik.BELTRH.Year + "-" +
                //                                baslik.BELTRH.Month + " )");
                //}


                // Tolerans kontrolleri

                var degerAnahtar = _sadegaDal.Get(g => g.SIRKID == global.SirketId && g.ACTIVE && g.SADEGK == data.SADEGK);
                if (degerAnahtar != null)
                {
                    if (yuzde > 0 && yuzde > degerAnahtar.TESFZT)
                    {
                        throw new BusinessException(data.STKODU + " malzemesi için max toleranstan fazla giriş yapıldı, işlem yapamazsınız! ( " + baslik.BELTRH.Year + "-" +
                                                    baslik.BELTRH.Month + " )");
                    }
                }
                else
                {
                    throw new BusinessException(data.STKODU + " malzemesi için satın alma değer anahtar bakımı yapılmadı, lütfen kontrol ediniz!( " + baslik.BELTRH.Year + "-" +
                                                baslik.BELTRH.Month + " )");
                }
            }

            _sthbasDal.Add(baslik);

            var kalanVarmi = false;
            var sasBelgeNo = "";
            var syc = 1;

            for (int i = 0; i < kalemler.Count; i++)
            {
                STHRKT data = kalemler[i];
                if (data.SLINDI) continue;
                oncekiGiren = 0;
                toplamGiren = 0;
                yuzde = 0;

                sas = _spfharDal.Get(g =>
                    g.SIRKID == global.SirketId && g.BELGEN == data.USTBLG && g.SATIRN == data.USTKLM);
                oncekiGiren = data.GNMKTR - sas.KLNMKTR;
                toplamGiren = oncekiGiren + data.GRMKTR;

                yuzde = Math.Round(((toplamGiren - data.GNMKTR) / data.GNMKTR ?? 1) * 100);

                #region SAS update

                if (syc == 1)
                {
                    sasBelgeNo = data.USTBLG;
                    syc++;
                }

                var degerAnahtar = _sadegaDal.Get(g => g.SIRKID == global.SirketId && g.ACTIVE && g.SADEGK == data.SADEGK);
                if (degerAnahtar != null)
                {
                    //var sas = _spfharDal.Get(g =>
                    //    g.SIRKID == global.SirketId && g.BELGEN == data.USTBLG && g.SATIRN == data.USTKLM);

                    //var toplamGiren = data.GNMKTR - sas.KLNMKTR;

                    //var yuzde = Math.Round((((data.GRMKTR + toplamGiren) - data.GNMKTR) / data.GNMKTR ?? 1) * 100);

                    if (yuzde >= 0)
                    {
                        sas.KLNMKTR = 0;
                        sas.FLGKPN = true;
                    }
                    else
                    {
                        if (yuzde < degerAnahtar.TESACT)
                        {
                            var kalan = sas.KLNMKTR - data.GRMKTR;
                            if (kalan < 0) kalan = 0;

                            sas.KLNMKTR = kalan.Value;
                            sas.FLGKPN = false;
                            kalanVarmi = true;
                        }
                        else
                        {
                            sas.KLNMKTR = 0;
                            sas.FLGKPN = true;
                        }
                    }

                    sas.DEKULL = global.UserKod;
                    sas.DTARIH = DateTime.Now;

                    _spfharDal.Update(sas);
                }

                #endregion


                var copy = data.ShallowCopy();
                copy.EKKULL = global.UserKod;
                copy.ETARIH = DateTime.Now;
                copy.KYNKKD = global.KaynakKod;

                if (copy.GRMKTR > 0)
                {
                    STDEPO stDepo = _stdepoDal.Get(g =>
                        g.SIRKID == global.SirketId && g.STKODU == data.STKODU && g.DPKODU == dpkodu && g.ACTIVE);
                    STDEPV stDepv = _stdepvDal.Get(g =>
                        g.SIRKID == global.SirketId && g.STKODU == data.STKODU && g.VRKODU == data.VRKODU && g.DPKODU == dpkodu && g.ACTIVE);

                    var stkmiz = _stkmizDal.Get(g =>
                        g.SIRKID == global.SirketId && g.STKODU == data.STKODU && g.ACTIVE &&
                        g.MALIAY == baslik.BELTRH.Month && g.MALIYL == baslik.BELTRH.Year);
                    var stvmiz = _stvmizDal.Get(g =>
                        g.SIRKID == global.SirketId && g.STKODU == data.STKODU && g.VRKODU == data.VRKODU && g.ACTIVE &&
                        g.MALIAY == baslik.BELTRH.Month && g.MALIYL == baslik.BELTRH.Year);
                    if (stDepv == null)
                    {
                        stDepv = _stdepvDal.Add(new STDEPV
                        {
                            SIRKID = global.SirketId.Value,
                            STKODU = copy.STKODU,
                            VRKODU = copy.VRKODU,
                            URYRKD = stDepo.URYRKD,
                            DPKODU = stDepo.DPKODU,
                            ENBLKJ = false,
                            USESTK = 0,
                            BLKSTK = 0,
                            MIPGOS = stDepo.MIPGOS,
                            TEDKOD = stDepo.TEDKOD,
                            DPADRS = stDepo.DPADRS,
                            ULKEKD = stDepo.ULKEKD,
                            ACTIVE = true,
                            SLINDI = false,
                            KYNKKD = "3",
                            EKKULL = global.UserKod,
                            ETARIH = DateTime.Now,
                            CHKCTR = false,

                        });
                    }
                    if (stkmiz == null)
                    {
                        stkmiz = _stkmizDal.Add(new STKMIZ
                        {
                            SIRKID = global.SirketId.Value,
                            STKODU = copy.STKODU,
                            MALIYL = DateTime.Today.Year,
                            MALIAY = DateTime.Today.Month,
                            KAYORT = 0,
                            STNFIY = 0,
                            DGMKTR = 0,
                            DGSTDG = 0,
                            MALHSP = 0,
                            ACTIVE = true,
                            SLINDI = false,
                            KYNKKD = "3",
                            EKKULL = global.UserKod,
                            ETARIH = DateTime.Now,
                            CHKCTR = false,
                        });
                    }
                    if (stvmiz == null)
                    {
                        stvmiz = _stvmizDal.Add(new STVMIZ
                        {
                            SIRKID = global.SirketId.Value,
                            STKODU = copy.STKODU,
                            VRKODU = copy.VRKODU,
                            MALIYL = DateTime.Today.Year,
                            MALIAY = DateTime.Today.Month,
                            KAYORT = 0,
                            STNFIY = 0,
                            DGMKTR = 0,
                            DGSTDG = 0,
                            MALHSP = 0,
                            ACTIVE = true,
                            SLINDI = false,
                            KYNKKD = "3",
                            EKKULL = global.UserKod,
                            ETARIH = DateTime.Now,
                            CHKCTR = false,
                        });
                    }

                    copy.STHRTP = sthrtp;
                    copy.GRMKTR = data.GRMKTR.Value;
                    copy.GROLBR = data.GROLBR;

                    decimal? gnMiktar = null;

                    //List<STOLCU> olcuList = _stolcuService.Ncch_GetByStKod_NLog(copy.STKODU, global).Items;
                    List<STOLCU> olcuList = _stolcuDal.GetList(g =>
                        g.SIRKID == global.SirketId && g.STKODU == data.STKODU && g.ACTIVE);

                    if (olcuList != null && olcuList.Count > 0)
                    {
                        STOLCU olcu = olcuList.FirstOrDefault(o => o.OLCHDF == copy.GROLBR);
                        if (olcu == null)
                        {
                            throw new BusinessException(data.STKODU + " - " + data.STKNAM + Environment.NewLine + data.GROLBR + " için ölçü çevrimi bulunamadı!");
                        }

                        gnMiktar = copy.GRMKTR.Value / Convert.ToDecimal(olcu.BOLNEN);

                        copy.OLCUKD = olcu.OLCUKD;
                        copy.GNMKTR = gnMiktar;

                        if (sthrtp == 1) gnMiktar *= -1;
                    }

                    if (gnMiktar == null)
                    {
                        throw new BusinessException(data.STKODU + " - " + data.STKNAM + Environment.NewLine + (sthrtp == 0 ? "Giriş" : "Çıkış") + " miktarı hatalı!");
                    }

                    stDepo.USESTK += gnMiktar.Value;
                    stDepo.DEKULL = global.UserKod;
                    stDepo.DTARIH = saveDate;
                    _stdepoDal.Update(stDepo);

                    stDepv.USESTK += gnMiktar.Value;
                    stDepv.DEKULL = global.UserKod;
                    stDepv.DTARIH = saveDate;
                    _stdepvDal.Update(stDepv);

                    stkmiz.DGMKTR += gnMiktar.Value;
                    stkmiz.DEKULL = global.UserKod;
                    stkmiz.DTARIH = saveDate;
                    _stkmizDal.Update(stkmiz);
                    stvmiz.DGMKTR += gnMiktar.Value;
                    stvmiz.DEKULL = global.UserKod;
                    stvmiz.DTARIH = saveDate;
                    _stvmizDal.Update(stvmiz);

                    #region WM

                    if (model.KaynakWmAdresList.Count > 0 || model.HedefWmAdresList.Count > 0)
                    {
                        var depoNo = _gndpnoService.Ncch_GetByDepoKodUretimYeri_NLog(stDepo.URYRKD, dpkodu, global, false).Nesne;
                        if (depoNo != null)
                        {
                            var hareketAtama = _wmhratService.Cch_GetByFisTip_NLog(baslik.STFTNO, global, false);

                            if (hareketAtama.Nesne == null)
                            {
                                throw new BusinessException("Wm Hareket ataması yapılmamıştır!");
                            }

                            var adres = "";
                            if (sthrtp == 0)
                            {
                                adres = model.HedefWmAdresList[i];
                                copy.GRADRS = adres;
                            }
                            else if (sthrtp == 1)
                            {
                                adres = model.KaynakWmAdresList[i];
                                copy.CKADRS = adres;
                            }

                            var adresTanim = _wmadrtService
                                .Cch_GetListByDepoKdDpAdrs_NLog(depoNo.DEPOKD, adres, global, false).Nesne;

                            if (adresTanim == null)
                            {
                                throw new BusinessException(adres + " - Wm adres bulunamadı!");
                            }

                            if (sthrtp == 0)
                            {
                                if (adresTanim.DGSTBL == true)
                                {
                                    throw new BusinessException(adres + " - Wm Adres depolama için blokelidir!");
                                }

                                var evrModel = new EvrakNoUretParamModel();
                                evrModel.TabloAdi = "WMADRS";
                                evrModel.TeknikAd = "WMASNO";
                                evrModel.IslemTur = 0;
                                var evrkResponse = _gnevrkService.Ncch_EvrakNoUret_NLog(global, evrModel);

                                if (evrkResponse.Status != ResponseStatusEnum.OK)
                                {
                                    throw new BusinessException(evrakResponse.Message);
                                }

                                var wmAdrs = new WMADRS()
                                {
                                    SIRKID = global.SirketId.Value,
                                    STKODU = copy.STKODU,
                                    WMASNO = evrkResponse.Nesne,
                                    URYRKD = stDepo.URYRKD,
                                    DEPOKD = depoNo.DEPOKD,
                                    DPTIPI = adresTanim.DPTIPI,
                                    DPADRS = adres,
                                    DGSTBL = adresTanim.DGSTBL,
                                    DCSTBL = adresTanim.DCSTBL,
                                    STARIH = DateTime.Now,
                                    SDPTAR = DateTime.Now,
                                    SDETAR = DateTime.Now,
                                    STHRTP = copy.STHRTP,
                                    STFTNO = copy.STFTNO,
                                    BELGEN = copy.BELGEN,
                                    BELTRH = copy.BELTRH,
                                    SATIRN = copy.SATIRN,
                                    TPLSTK = 0,
                                    USESTK = copy.GNMKTR,
                                    DPLSTK = 0,
                                    DPCSTK = 0,
                                    PARTIT = copy.PARTIT ?? false,
                                    PARTIN = copy.PARTIN,
                                    ACTIVE = true,
                                    SLINDI = false,
                                    EKKULL = global.UserKod,
                                    ETARIH = DateTime.Now,
                                    KYNKKD = global.KaynakKod,
                                    CHKCTR = false,
                                };
                                _wmadrsDal.Add(wmAdrs);
                            }

                            if (sthrtp == 1)
                            {
                                if (adresTanim.DCSTBL == true)
                                {
                                    throw new BusinessException("Wm Adres depo çıkış için blokelidir!");
                                }

                                var adrsList = _wmadrsDal.GetList(g =>
                                    g.SIRKID == global.SirketId && g.STKODU == copy.STKODU && g.DPADRS == adres &&
                                    g.ACTIVE && g.URYRKD == stDepo.URYRKD && g.DEPOKD == depoNo.DEPOKD &&
                                    g.PARTIT.Value == copy.PARTIT.Value && g.PARTIN == copy.PARTIN).OrderBy(o => o.SDPTAR).ToList();

                                if (adrsList.Count < 1)
                                {
                                    throw new BusinessException("Wm Adreste stok bulunamadı! (" + copy.STKODU + ")");
                                }

                                var toplamStok = adrsList.Sum(s => s.USESTK);

                                if (copy.GNMKTR > toplamStok)
                                {
                                    throw new BusinessException("Depodaki '" + adres + "' adresinde " + copy.GNMKTR + " adet malzeme bulunmamaktadır!");
                                }

                                decimal tempMiktar = copy.GNMKTR.Value;
                                foreach (var wmadres in adrsList)
                                {
                                    if (wmadres.USESTK >= tempMiktar)
                                    {
                                        wmadres.USESTK = wmadres.USESTK - tempMiktar;
                                        _wmadrsDal.Update(wmadres);
                                        break;
                                    }

                                    tempMiktar = tempMiktar - wmadres.USESTK.Value;
                                    wmadres.USESTK = 0;

                                    _wmadrsDal.Update(wmadres);
                                }
                            }
                        }
                    }
                }

                #endregion

                _sthrktDal.Add(copy);
            }

            if (kalanVarmi == false)
            {
                var sasBaslik = _spfbasDal.Get(g =>
                    g.SIRKID == global.SirketId && g.BELGEN == sasBelgeNo);
                sasBaslik.FLGKPN = true;
                _spfbasDal.Update(sasBaslik);
            }

            sonuc.Message = evrakResponse.Nesne;
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(TeslimatKayitValidator))]
        [CacheRemoveAspect("Bps.BpsBase.Business.Concrete.Managers.TS.", typeof(MemoryCacheManager))]
        public StandardResponse Ncch_TeslimatKaydet_Log(TeslimatKayitModel model, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse();

            var baslik = model.Baslik;
            var kalems = model.Kalems;

            if (baslik == null)
            {
                sonuc.Status = ResponseStatusEnum.ERROR;
                sonuc.Message = "Başlık bilgisi okunamadı!";
                return sonuc;
            }

            if (kalems == null || kalems.Count < 1)
            {
                sonuc.Status = ResponseStatusEnum.ERROR;
                sonuc.Message = "Teslimat kalem listesi boş geçilemez!";
                return sonuc;
            }

            #region Başlık

            baslik.SIRKID = global.SirketId.Value;
            baslik.KYNKKD = global.KaynakKod;
            baslik.ACTIVE = true;
            baslik.SLINDI = false;

            if (baslik.Id > 0)
            {
                baslik.DEKULL = global.UserKod;
                baslik.DTARIH = DateTime.Now;
                _tsfbasDal.Update(baslik);
            }
            else
            {
                var evrakmodel = new EvrakNoUretParamModel();
                evrakmodel.TabloAdi = "TSFBAS";
                evrakmodel.TeknikAd = "BELGEN";
                evrakmodel.IslemTur = baslik.TSHRTP;
                var evrakResponse = _gnevrkService.Ncch_EvrakNoUret_NLog(global, evrakmodel);

                if (evrakResponse.Status != ResponseStatusEnum.OK)
                {
                    throw new BusinessException(evrakResponse.Message);
                }

                baslik.BELGEN = evrakResponse.Nesne;
                baslik.EKKULL = global.UserKod;
                baslik.ETARIH = DateTime.Now;
                _tsfbasDal.Add(baslik);
            }

            #endregion

            #region Kalemler

            if (baslik.Id > 0)
            {
                var eskiKalems = _spfharDal.GetList(g => g.SIRKID == global.SirketId.Value && g.BELGEN == baslik.BELGEN)
                    .ToList();

                foreach (var eskiKalem in eskiKalems)
                {
                    _spfharDal.Delete(eskiKalem);
                }
            }

            if (kalems != null)
            {
                foreach (var data in kalems)
                {
                    data.BELGEN = baslik.BELGEN;
                    data.BELTRH = baslik.BELTRH;
                    data.CRKODU = baslik.CRKODU;
                    data.SPORKD = baslik.SPORKD;
                    data.SPDGKD = baslik.SPDGKD;
                    data.TSHRTP = baslik.TSHRTP;
                    data.TSFTNO = baslik.TSFTNO;

                    data.GNMKTR = data.GRMKTR;

                    data.SIRKID = global.SirketId.Value;
                    data.KYNKKD = global.KaynakKod;
                    data.ACTIVE = true;
                    data.SLINDI = false;
                    data.EKKULL = global.UserKod;
                    data.ETARIH = DateTime.Now;
                    _tsfharDal.Add(data);
                }
            }

            #endregion

            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [CacheRemoveAspect("Bps.BpsBase.Business.Concrete.Managers.SP.", typeof(MemoryCacheManager))]
        public StandardResponse Ncch_SiparisRezervasyonKaydet_Log(List<SPREZV> sprezvList, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse();

            if (sprezvList == null || sprezvList.Count < 1)
            {
                sonuc.Status = ResponseStatusEnum.ERROR;
                sonuc.Message = "Rezervasyon listesi boş geçilemez!";
                return sonuc;
            }

            var evrakmodel = new EvrakNoUretParamModel();
            evrakmodel.TabloAdi = "SPREZV";
            evrakmodel.TeknikAd = "BELGEN";
            evrakmodel.IslemTur = 0;
            var evrakResponse = _gnevrkService.Ncch_EvrakNoUret_NLog(global, evrakmodel);

            if (evrakResponse.Status != ResponseStatusEnum.OK)
            {
                throw new BusinessException(evrakResponse.Message);
            }

            #region Kalemler

            foreach (var data in sprezvList)
            {
                data.BELGEN = evrakResponse.Nesne;
                _sprezvDal.Add(data);
            }

            #endregion

            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [CacheRemoveAspect("Bps.BpsBase.Business.Concrete.Managers.GN.", typeof(MemoryCacheManager))]
        public StandardResponse Ncch_OrganizasyonHareketKaydet_Log(string orgKod, string tablnm, int tablid, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse();
            var kayitvarmi = new ListResponse<GNORHR>();
            kayitvarmi.Items = _gnorhrDal.GetList(x => x.SIRKID == global.SirketId && x.ORGKOD == orgKod && x.TABLNM == tablnm
              && x.TABLID == tablid && x.SLINDI == false && x.ACTIVE == true);
            if (kayitvarmi.Items.Count == 0)
            {
                var onaylist = _gnorgaService.Ncch_KullaniciOnayList_NLog(orgKod, global);


                foreach (var item in onaylist.Items)
                {
                    var Orghrkt = new GNORHR
                    {
                        ORGKOD = orgKod,
                        KULKOD = item.KULKOD,
                        TABLNM = tablnm,
                        TABLID = tablid,
                        SIRASI = (int)item.SIRASI,
                        SIRKID = global.SirketId.Value,
                        GNONAY = false,
                        ACTIVE = true,
                        SLINDI = false,
                        EKKULL = global.UserKod,
                        ETARIH = DateTime.Now,
                        KYNKKD = global.KaynakKod,
                        CHKCTR = false,
                    };
                    _gnorhrDal.Add(Orghrkt);
                }
                sonuc.Status = ResponseStatusEnum.OK;
            }
            else
            {
                sonuc.Status = ResponseStatusEnum.ERROR;
            }


            return sonuc;
        }

        [CacheRemoveAspect("Bps.BpsBase.Business.Concrete.Managers.GN.", typeof(MemoryCacheManager))]
        public StandardResponse Ncch_OrganizasyonHareketOnay_Log(string orgKod, string tablnm, int tablid, Global global, bool yetkiKontrol = true, bool onay = true)
        {

            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse();
            var kayitvarmi = new ListResponse<GNORHR>();
            kayitvarmi.Items = _gnorhrDal.GetList(x => x.SIRKID == global.SirketId && x.ORGKOD == orgKod && x.TABLNM == tablnm
              && x.TABLID == tablid && x.SLINDI == false && x.ACTIVE == true);
            var UserVarmi = kayitvarmi.Items.Where(o => o.KULKOD == global.UserKod).FirstOrDefault();
            if (UserVarmi == null) throw new BusinessException().FromMessageNo("0000", global, global.UserKod, null, null, null, "ON");

            else if (UserVarmi.GNONAY == onay)
            {
                if (onay)
                {
                    throw new BusinessException().FromMessageNo("0001", global, UserVarmi.KULKOD, null, null, null, "ON");
                }
                else
                {
                    throw new BusinessException().FromMessageNo("0002", global, UserVarmi.KULKOD, null, null, null, "ON");
                }
            }


            var firstUser = kayitvarmi.Items.Where(o => o.GNONAY != onay).OrderByDescending(o => o.SIRASI).FirstOrDefault();


            if (firstUser.KULKOD != global.UserKod) throw new BusinessException().FromMessageNo("0003", global, UserVarmi.KULKOD, null, null, null, "ON");

            if (firstUser.KULKOD == global.UserKod)
            {
                var lastUser = kayitvarmi.Items.Where(o => o.GNONAY != onay && o.SIRASI < firstUser.SIRASI).OrderByDescending(o => o.SIRASI).FirstOrDefault();

                if (lastUser != null && onay == false) throw new BusinessException().FromMessageNo("0004", global, lastUser.KULKOD, null, null, null, "ON");

                string _ara = " ";
                var kayit = _gnorhrService.Ncch_UpdateOnay_Log(firstUser, firstUser, global, onay);
                if (!onay) _ara = " Kaldırma ";

                if (kayit.Status == ResponseStatusEnum.OK)
                {
                    string _mesaj = "Onay" + _ara + "işlemi başarılı ";
                    sonuc.Message = _mesaj;
                    sonuc.Status = ResponseStatusEnum.OK;
                }
                else
                {
                    string _mesaj = "Onay" + _ara + "işlemi başarısız  ";
                    sonuc.Message = _mesaj;
                    sonuc.Status = ResponseStatusEnum.ERROR;

                }
            }
            return sonuc;
        }

        [CacheRemoveAspect("Bps.BpsBase.Business.Concrete.Managers.IS.", typeof(MemoryCacheManager))]
        public StandardResponse<ISYRTN> Ncch_IsyeriOperasyonKaydet_Log(ISYRTN isyrtn, List<string> operasyonList, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }

            var sonuc = new StandardResponse<ISYRTN>();

            _lockedService.LockControlWrite("ISYRTN", isyrtn.Id, global);
            isyrtn.SIRKID = global.SirketId.Value;
            isyrtn.DEKULL = global.UserKod;
            isyrtn.DTARIH = DateTime.Now;
            isyrtn.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _isyrtnDal.Update(isyrtn);

            var sql = @"DELETE FROM ISYROP WHERE ISYRID = @Isyrid AND SIRKID = @SirketId";
            _isyropDal.ExecuteSqlQuery(sql, new SqlParameter("@SirketId", global.SirketId), new SqlParameter("@Isyrid", isyrtn.Id));

            foreach (string operasyon in operasyonList)
            {
                ISYROP isyrop = new ISYROP();
                isyrop.SIRKID = global.SirketId.Value;
                isyrop.ACTIVE = true;
                isyrop.SLINDI = false;
                isyrop.EKKULL = global.UserKod;
                isyrop.ETARIH = DateTime.Now;
                isyrop.KYNKKD = global.KaynakKod;
                isyrop.ISYRID = isyrtn.Id;
                isyrop.ISOPKD = operasyon;
                _isyropDal.Add(isyrop);
            }

            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }



        [CacheRemoveAspect("Bps.BpsBase.Business.Concrete.Managers.SP.", typeof(MemoryCacheManager))]
        public StandardResponse<string> Ncch_SiparisIsemriOlustur_Log(string sipBelgeNo, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<string>();

            SPFBAS spfbas = _spfbasDal.Get(s =>
                s.BELGEN == sipBelgeNo && s.SIRKID == global.SirketId && s.ACTIVE && !s.SLINDI);
            List<SPFHAR> spfharList = _spfharDal.GetList(s => s.BELGEN == sipBelgeNo && s.SIRKID == global.SirketId && s.ACTIVE && !s.SLINDI).ToList();

            if (spfharList.Count == 0)
            {
                sonuc.Status = ResponseStatusEnum.ERROR;
                sonuc.Message = "Sipariş listesi boş geçilemez!";
                return sonuc;
            }

            List<ISPLAN> isplanList = _isplanDal.GetList(i => i.ISMETN == spfbas.BELGEN && i.SIRKID == global.SirketId && i.ACTIVE && !i.SLINDI);
            if (isplanList.Count > 0)
            {
                sonuc.Status = ResponseStatusEnum.INFO;
                sonuc.Message = "Bu sipariş için daha önce " + isplanList[0].ISPKOD + " no'lu plan ile işemri açılmış!";
                sonuc.Nesne = "";
                return sonuc;
            }

            #region Kalemler

            int rotaCount = 0;

            for (int i = 0; i < spfharList.Count; i++)
            {
                var spfhar = spfharList[i];
                string maxUaKodu = _uragacService.GetMaxUrunAgaciKodu(spfhar.STKODU, "1", global).Nesne;

                if (!string.IsNullOrEmpty(maxUaKodu))
                {
                    List<UrunAgaciTreeList> uaListModified = new List<UrunAgaciTreeList>();
                    List<UrunAgaciTreeList> uaList = _uragacService.Ncch_GetUrunAgaci_NLog(maxUaKodu, global).Items;
                    maxAltId = uaList.Max(u => u.AltId);

                    foreach (var row in uaList)
                    {
                        uaListModified.Add(row.ShallowCopy());

                        string stokKodu = row.StokKodu;
                        string revizyonNo = row.RevizyonNo;
                        int parentId = row.Id;
                        int seviye = row.Seviye;
                        bool fantom = row.FantomKalemi;

                        if (!fantom)
                        {
                            GetUrunAgaciSubLevel(uaListModified, stokKodu, maxUaKodu, revizyonNo, parentId, seviye + 1, global);
                        }
                        if (uaListModified.Count > 0) maxAltId = uaListModified.Max(u => u.AltId);
                    }

                    foreach (UrunAgaciTreeList ua in uaListModified)
                    {
                        URAGAC uragac = _uragacService.Ncch_GetById_NLog(ua.Id, global, false).Nesne;
                        List<UASTRT> uastrtList = _uastrtDal.GetList(x => x.URYRKD == uragac.URYRKD && x.GNREZV == uragac.GNREZV &&
                                               x.URAKOD == uragac.URAKOD && x.STKODU == uragac.STKODU &&
                                               x.PARENT == uragac.PARENT &&
                                               x.CHILDD == uragac.CHILDD.Value && x.SEVIYE == uragac.SEVIYE &&
                                               x.SIRKID == global.SirketId && x.ACTIVE && !x.SLINDI);
                        if (uastrtList != null && uastrtList.Count > 0)
                        {
                            foreach (UASTRT uastrt in uastrtList)
                            {
                                rotaCount++;
                                ISPLAN isplan = new ISPLAN
                                {
                                    SIRASI = i + 1,
                                    GNTARH = spfbas.TERTAR ?? spfbas.BELTRH,
                                    URYRKD = ua.UretimYeriKodu,
                                    //ISYKOD = "", //URSURE'den gelecek
                                    ISOPKD = uastrt.ISOPKD,
                                    ISMETN = spfbas.BELGEN,
                                    SPSRNO = spfhar.SATIRN,
                                    SPSTKD = spfhar.STKODU,
                                    MXPRKD = string.IsNullOrEmpty(ua.ParentStokKodu) ? spfhar.STKODU : ua.ParentStokKodu,
                                    STKODU = ua.StokKodu,
                                    GNREZV = ua.RevizyonNo,
                                    URAKOD = ua.UrunAgaciKodu,
                                    PURKOD = ua.ParentUrunAgaciKodu,
                                    ISLMNO = uastrt.SIRANO,
                                    PLMKTR = ua.Miktar * spfhar.GNMKTR ?? 0,
                                    GRMKTR = 0,
                                    GROLBR = ua.OlcuBirimiKodu,
                                    FLGKPN = false,
                                    SIRKID = global.SirketId.Value,
                                    EKKULL = global.UserKod,
                                    ETARIH = DateTime.Now,
                                    ACTIVE = true,
                                    KYNKKD = global.KaynakKod,
                                    SLINDI = false,
                                    CHKCTR = false,
                                };

                                isplanList.Add(isplan);
                            }
                        }
                    }
                }
            }

            if (rotaCount == 0)
            {
                sonuc.Status = ResponseStatusEnum.ERROR;
                sonuc.Nesne = "Rota bulunamadı!";
                sonuc.Message = "Rota bulunamadı!";
            }
            else
            {
                var evrakmodel = new EvrakNoUretParamModel();
                evrakmodel.TabloAdi = "ISPLAN";
                evrakmodel.TeknikAd = "ISPKOD";
                evrakmodel.IslemTur = 0;
                var evrakResponse = _gnevrkService.Ncch_EvrakNoUret_NLog(global, evrakmodel);

                if (evrakResponse.Status != ResponseStatusEnum.OK)
                {
                    throw new BusinessException(evrakResponse.Message);
                }

                foreach (SPFHAR spfhar in spfharList)
                {
                    spfhar.ISPKOD = evrakResponse.Nesne;
                    _spfharDal.Update(spfhar);
                }

                foreach (ISPLAN isplan in isplanList)
                {
                    isplan.ISPKOD = evrakResponse.Nesne;
                    _isplanDal.Add(isplan);
                }

                sonuc.Status = ResponseStatusEnum.OK;
                sonuc.Nesne = evrakResponse.Nesne;
            }

            #endregion

            return sonuc;
        }

        private int maxAltId = 0;

        private void GetUrunAgaciSubLevel(List<UrunAgaciTreeList> uaList, string stokKodu, string parentUaKodu, string revizyonNo, int parentId, int seviye, Global global)
        {
            string uaKodu = _uastbgService.Ncch_GetUrunAgaciKodu_NLog(stokKodu, revizyonNo, "1", global).Nesne;
            if (uaKodu == null) return;

            var dt = _uragacService.Ncch_GetUrunAgaci_NLog(uaKodu, global).Items;

            foreach (UrunAgaciTreeList uaTree in dt)
            {
                maxAltId++;
                uaTree.ParentId = parentId;
                uaTree.ParentStokKodu = stokKodu;
                uaTree.ParentUrunAgaciKodu = parentUaKodu;
                uaTree.AltId = maxAltId;
                uaTree.Seviye = seviye;
                uaTree.MalzemeTuru = "";
                uaList.Add(uaTree.ShallowCopy());
                GetUrunAgaciSubLevel(uaList, uaTree.StokKodu, uaKodu, uaTree.RevizyonNo, uaTree.Id, seviye + 1, global);
            }
        }
        [CacheRemoveAspect("Bps.BpsBase.Business.Concrete.Managers.ST.", typeof(MemoryCacheManager))]
        public StandardResponse<string> Ncch_StokKodOlustur_NLog(Global global, STMALT _stmalt, STKART _stkart, string krtsay = "D4", bool yetkiKontrol = true, bool kaydet = true)
        {
            //krtsay karakter sayısı demektir örnek değer D ile başlamalı D4 gibi

            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<string>();
            if (kaydet)
            {

                if (_stkart.STKODU != null)
                {
                    sonuc.Nesne = _stkart.STKODU;
                    sonuc.Status = ResponseStatusEnum.OK;
                    return sonuc;
                }

                if (((bool)_stmalt.OTMTIK) && (_stmalt.FORMUL == null) || (_stmalt.FORMUL == ""))
                {
                    throw new BusinessException().FromMessageNo("0007", global, _stmalt.STMLNM, null, null, null, "ON");
                }

            }

            if ((bool)!_stmalt.OTMTIK)
            {
                throw new BusinessException().FromMessageNo("0005", global, _stmalt.STMLNM, null, null, null, "ON");
            }

            string kodum = _stmalt.FORMUL;

            string[] kodlar = kodum.Split(';');
            string value = "";
            string _value = null;
            foreach (var kod in kodlar)
            {
                PropertyInfo propertyInfo = _stkart.GetType().GetProperty(kod);
                if (propertyInfo != null)
                {

                    _value = propertyInfo.GetValue(_stkart) == null ? null : propertyInfo.GetValue(_stkart).ToString();


                    if (_value == null)
                    {
                        throw new BusinessException().FromMessageNo("0006", global, kod, null, null, null, "ON");
                    }
                    value += _value;

                }
                else
                {
                    if (kod == "DINAMIK")
                    {
                        var evrakmodel = new EvrakNoUretParamModel();
                        evrakmodel.TabloAdi = "STKART";
                        evrakmodel.TeknikAd = "STKODU";
                        evrakmodel.IslemTur = _stmalt.Id;
                        var evrakResponse = _gnevrkService.Ncch_EvrakNoUret_NLog(global, evrakmodel);

                        if (evrakResponse.Status != ResponseStatusEnum.OK)
                        {
                            throw new BusinessException(evrakResponse.Message);
                        }
                        value += evrakResponse.Nesne;
                    }
                    else if (kod == "SONKYT")
                    {
                        var stokKart = _stokKartService.Ncch_GetByStKodLike_NLog(value, _stmalt.STMLTR, global).Nesne;

                        int siraNo = stokKart == null ? 1 : Convert.ToInt32(stokKart.STKODU.Substring(value.Length)) + 1;


                        value += siraNo.ToString(krtsay);

                    }
                    else
                    {
                        value += kod;
                    }

                }


            }




            sonuc.Nesne = value;
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }
    }
}