using System;
using Bps.Core.Response;
using Bps.Core.Aspects.Postsharp.CacheAspects;
using Bps.Core.CrossCuttingConcerns.Caching.Microsoft;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Exception;
using Bps.Core.Aspects.Postsharp.ValidationAspects;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.ValidationRules.FluentValidation.CR;
using Bps.BpsBase.Business.Abstract.CR;
using Bps.BpsBase.DataAccess.Abstract.CR;
using Bps.BpsBase.Entities.Concrete.CR;

#region ClientUsing

using System.Linq;
using System.Data.SqlClient;
using Bps.BpsBase.Entities.Models.CR.Single;
using Bps.BpsBase.Entities.Models.CR.Listed;
using Bps.Core.Utilities.WinForm;
using System.Collections.Generic;
using Bps.BpsBase.Entities.Models.GN.Single;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.CR
{
    public class CrcariManager : ICrcariService
    {
        private ICrcariDal _crcariDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        private ICrytklDal _crytklDal;
        private ICrbankDal _crbankDal;

        #endregion ClientDals
        #region ClientServices
        private IGnevrkService _gnevrkService;
        #endregion ClientServices

        public CrcariManager(ICrcariDal crcariDal, IGnService gnservice, ILockedService lockedservice, ICrytklDal crytklDal, ICrbankDal crbankDal, IGnevrkService gnevrkService)
        {
            _crcariDal = crcariDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
            _crytklDal = crytklDal;
            _crbankDal = crbankDal;
            _gnevrkService = gnevrkService;

        }

        public ListResponse<CRCARI> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<CRCARI>();
            sonuc.Items = global.SirketId != null ? _crcariDal.GetList(x => x.SIRKID == global.SirketId) : _crcariDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<CRCARI> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<CRCARI>();
            sonuc.Items = global.SirketId != null ? _crcariDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _crcariDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<CRCARI> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<CRCARI>();
            sonuc.Items = global.SirketId != null ? _crcariDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _crcariDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<CRCARI> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<CRCARI>();
            sonuc.Items = global.SirketId != null ? _crcariDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _crcariDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<CRCARI> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<CRCARI>();
            sonuc.Items = global.SirketId != null ? _crcariDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _crcariDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<CRCARI> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<CRCARI>();
            sonuc.Nesne = _crcariDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<CRCARI> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("CRCARI", id, global);
            var sonuc = new StandardResponse<CRCARI>();
            sonuc.Nesne = _crcariDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(CrcariValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<CRCARI> Ncch_Add_NLog(CRCARI crcari, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<CRCARI>();
            crcari.SIRKID = global.SirketId.Value;
            crcari.EKKULL = global.UserKod;
            crcari.ETARIH = DateTime.Now;
            crcari.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _crcariDal.Add(crcari);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(CrcariValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<CRCARI> Ncch_Update_Log(CRCARI crcari, CRCARI oldCrcari, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            _lockedService.LockControlWrite("CRCARI", crcari.Id, global);
            var sonuc = new StandardResponse<CRCARI>();
            crcari.SIRKID = global.SirketId.Value;
            crcari.DEKULL = global.UserKod;
            crcari.DTARIH = DateTime.Now;
            crcari.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _crcariDal.Update(crcari);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(CrcariValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<CRCARI> Ncch_UpdateAktifPasif_Log(CRCARI crcari, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<CRCARI>();
            crcari.SIRKID = global.SirketId.Value;
            crcari.ACTIVE = !crcari.ACTIVE;
            crcari.DEKULL = global.UserKod;
            crcari.DTARIH = DateTime.Now;
            crcari.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _crcariDal.Update(crcari);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(CrcariValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<CRCARI> Ncch_Delete_Log(CRCARI crcari, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            _lockedService.LockControlWrite("CRCARI", crcari.Id, global);
            var sonuc = new StandardResponse<CRCARI>();
            crcari.SIRKID = global.SirketId.Value;
            crcari.ACTIVE = false;
            crcari.SLINDI = true;
            crcari.DEKULL = global.UserKod;
            crcari.DTARIH = DateTime.Now;
            crcari.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _crcariDal.Update(crcari);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        public ListResponse<CRCARI> Cch_GetListByTip_NLog(Global global, string tipKod, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<CRCARI>();
            sonuc.Items = global.SirketId != null
                ? _crcariDal.GetList(x =>
                    x.SIRKID == global.SirketId && x.CRHRKD == tipKod && x.ACTIVE && !x.SLINDI)
                : _crcariDal.GetList(x => x.CRHRKD == tipKod && x.ACTIVE && !x.SLINDI);
            sonuc.Items.RemoveAll(c => c.CRHRKD == "9" && !string.IsNullOrEmpty(c.ASCRKD)); //Adaydan asýla aktarýlan carileri getirme
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<CRCARI> Cch_GetAllListByTip_NLog(Global global, string tipKod, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<CRCARI>();
            sonuc.Items = global.SirketId != null
                ? _crcariDal.GetList(x =>
                    x.SIRKID == global.SirketId && x.CRHRKD == tipKod)
                : _crcariDal.GetList(x => x.CRHRKD == tipKod);

            sonuc.Items.RemoveAll(c => c.CRHRKD == "9" && !string.IsNullOrEmpty(c.ASCRKD)); //Adaydan asýla aktarýlan carileri getirme
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }


        public StandardResponse<CRCARI> Ncch_GetByCariKod_NLog(string cariKod, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<CRCARI>();
            sonuc.Nesne = _crcariDal.Get(x => x.CRKODU == cariKod);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(CariKartValidator))]
        [CacheRemoveAspect("Bps.BpsBase.Business.Concrete.Managers.CR.", typeof(MemoryCacheManager))]
        public StandardResponse Ncch_CariSaving_Log(Global global, GenelCariKartModel model, List<Grid> grids, bool yetkiKontrol = true)
        {

            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse();

            var cariKart = model.CariKart;
            var crytkls = model.Crytkls;
            var crbanks = model.Crbanks;

            var fhCrYtkls = grids.Where(f => f.View == "CRYTKL").ToList();
            var fhCrBanks = grids.Where(f => f.View == "CRBANK").ToList();

            
            #region CariKart

            cariKart.SIRKID = global.SirketId.Value;
            cariKart.KYNKKD = global.KaynakKod;
            cariKart.ACTIVE = true;
            cariKart.SLINDI = false;


            if (cariKart.Id > 0)
            {
                cariKart.DEKULL = global.UserKod;
                cariKart.DTARIH = DateTime.Now;
                _crcariDal.Update(cariKart);
            }
            else
            {
                cariKart.EKKULL = global.UserKod;
                cariKart.ETARIH = DateTime.Now;
                _crcariDal.Add(cariKart);
            }

            #endregion

            #region Yetkili

            if (crytkls != null)
            {
                var inserted = crytkls.Where(w => w.Id == 0).ToList();
                foreach (var data in inserted)
                {

                    data.CRKODU = cariKart.CRKODU;
                    data.SIRKID = global.SirketId.Value;
                    data.KYNKKD = global.KaynakKod;
                    data.ACTIVE = true;
                    data.SLINDI = false;
                    data.EKKULL = global.UserKod;
                    data.ETARIH = DateTime.Now;
                    _crytklDal.Add(data);
                }

                foreach (var grid in fhCrYtkls)
                {
                    var data = crytkls.FirstOrDefault(f => f.Id == grid.Id);
                    if (data != null)
                    {
                        data.CRKODU = cariKart.CRKODU;
                        data.SIRKID = global.SirketId.Value;
                        data.KYNKKD = global.KaynakKod;
                        if (grid.Tipi == "update")
                        {
                            data.ACTIVE = true;
                            data.SLINDI = false;
                            data.DEKULL = global.UserKod;
                            data.DTARIH = DateTime.Now;
                            _crytklDal.Update(data);
                        }
                        else if (grid.Tipi == "delete")
                        {
                            data.ACTIVE = false;
                            data.SLINDI = true;
                            data.EKKULL = global.UserKod;
                            data.ETARIH = DateTime.Now;
                            _crytklDal.Update(data);
                        }
                    }
                }
            }

            #endregion

            #region Banka

            if (crbanks != null)
            {
                var inserted = crbanks.Where(w => w.Id == 0).ToList();
                foreach (var data in inserted)
                {
                    data.CRKODU = cariKart.CRKODU;
                    data.SIRKID = global.SirketId.Value;
                    data.KYNKKD = global.KaynakKod;
                    data.ACTIVE = true;
                    data.SLINDI = false;
                    data.EKKULL = global.UserKod;
                    data.ETARIH = DateTime.Now;
                    _crbankDal.Add(data);
                }

                foreach (var grid in fhCrBanks)
                {
                    var data = crbanks.FirstOrDefault(f => f.Id == grid.Id);
                    if (data != null)
                    {
                        data.CRKODU = cariKart.CRKODU;
                        data.SIRKID = global.SirketId.Value;
                        data.KYNKKD = global.KaynakKod;
                        if (grid.Tipi == "update")
                        {
                            data.ACTIVE = true;
                            data.SLINDI = false;
                            data.DEKULL = global.UserKod;
                            data.DTARIH = DateTime.Now;
                            _crbankDal.Update(data);
                        }
                        else if (grid.Tipi == "delete")
                        {
                            data.ACTIVE = false;
                            data.SLINDI = true;
                            data.EKKULL = global.UserKod;
                            data.ETARIH = DateTime.Now;
                            _crbankDal.Update(data);
                        }
                    }
                }
            }

            #endregion

            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(CariKartValidator))]
        [CacheRemoveAspect("Bps.BpsBase.Business.Concrete.Managers.CR.", typeof(MemoryCacheManager))]
        public StandardResponse<CRCARI> Ncch_SaveSingleCari_Log(Global global, GenelCariKartModel model, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<CRCARI>();

            var cariKart = model.CariKart;
            var crytkls = model.Crytkls;
            var crbanks = model.Crbanks;

            #region CariKart
            
              
            
            cariKart.SIRKID = global.SirketId.Value;
            cariKart.KYNKKD = global.KaynakKod;
            cariKart.ACTIVE = true;
            cariKart.SLINDI = false;

            if (cariKart.Id > 0)
            {
                cariKart.DEKULL = global.UserKod;
                cariKart.DTARIH = DateTime.Now;
                sonuc.Nesne = _crcariDal.Update(cariKart);
            }
            else
            {
                cariKart.EKKULL = global.UserKod;
                cariKart.ETARIH = DateTime.Now;
                sonuc.Nesne = _crcariDal.Add(cariKart);
            }

            #endregion

            #region Yetkili

            if (crytkls != null)
            {
                var inserted = crytkls.Where(w => w.Id == 0).ToList();
                foreach (var data in inserted)
                {

                    data.CRKODU = cariKart.CRKODU;
                    data.SIRKID = global.SirketId.Value;
                    data.KYNKKD = global.KaynakKod;
                    data.ACTIVE = true;
                    data.SLINDI = false;
                    data.EKKULL = global.UserKod;
                    data.ETARIH = DateTime.Now;
                    _crytklDal.Add(data);
                }
            }

            #endregion

            #region Banka

            if (crbanks != null)
            {
                var inserted = crbanks.Where(w => w.Id == 0).ToList();
                foreach (var data in inserted)
                {
                    data.CRKODU = cariKart.CRKODU;
                    data.SIRKID = global.SirketId.Value;
                    data.KYNKKD = global.KaynakKod;
                    data.ACTIVE = true;
                    data.SLINDI = false;
                    data.EKKULL = global.UserKod;
                    data.ETARIH = DateTime.Now;
                    _crbankDal.Add(data);
                }
            }

            #endregion

            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<CRCARI> Ncch_GetAllActive_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<CRCARI>();
            sonuc.Items = global.SirketId != null ? _crcariDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE && !x.SLINDI) : _crcariDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<CariEmailModel> Ncch_GetCariEmails_NLog(string cariKodu, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<CariEmailModel>();
            var sql = @"SELECT * FROM (
	                        SELECT SIRKID, CRKODU, CRUNV1 AS ADSYAD, GNMAIL FROM CRCARI
	                        UNION ALL
	                        SELECT dbo.CRCARI.SIRKID, dbo.CRCARI.CRKODU, dbo.CRYTKL.YETADI + ' ' + dbo.CRYTKL.YETSOY AS ADSYAD, dbo.CRYTKL.GNMAIL
	                        FROM dbo.CRCARI INNER JOIN dbo.CRYTKL ON dbo.CRCARI.CRKODU = dbo.CRYTKL.CRKODU
                        ) AS T WHERE T.SIRKID = @sirketId AND T.CRKODU = @cariKodu";
            sonuc.Items = _crcariDal.GetListSqlQuery<CariEmailModel>(sql,
                new SqlParameter("sirketId", global.SirketId), new SqlParameter("cariKodu", cariKodu));
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<CariKodAdModel> Ncch_GetCariKodAdList_NLog(Global global, string crhrkd = "", bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }

            string crhrkdFilter = "";
            if (crhrkd != "") crhrkdFilter = "AND CRHRKD = @crhrkd";

            var sonuc = new ListResponse<CariKodAdModel>();
            var sql = @"SELECT CRCARI.CRKODU, CRUNV1, T.ULKEKD, T.ADRESS FROM CRCARI 
							LEFT OUTER JOIN (SELECT TOP(1) * FROM CRADRS) AS T
							ON CRCARI.CRKODU = T.CRKODU AND CRCARI.SIRKID = T.SIRKID AND T.ACTIVE = 1
							WHERE CRCARI.SIRKID = @SirketId AND CRCARI.ACTIVE = 1 " + crhrkdFilter;

            sonuc.Items = _crcariDal.GetListSqlQuery<CariKodAdModel>(sql, new SqlParameter("SirketId", global.SirketId), new SqlParameter("crhrkd", crhrkd));
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<CRCARI> Ncch_GetByCariKodLike_NLog(string cariKodu, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<CRCARI>();
            var sql = @"SELECT TOP(1) * FROM CRCARI WHERE SIRKID = @SirketId AND ACTIVE = 1 AND SLINDI = 0 AND CRKODU LIKE '" + cariKodu + "%' ORDER BY CRKODU DESC";

            sonuc.Nesne = _crcariDal.GetSqlQuery<CRCARI>(sql, new SqlParameter("SirketId", global.SirketId));
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<CariExternalSourceModel> GetCariListFromExternalSource(string sqlQuery, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<CariExternalSourceModel>();

            sonuc.Items = _crcariDal.GetListSqlQuery<CariExternalSourceModel>(sqlQuery);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #endregion ClientFunc
    }
}
