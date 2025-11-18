using System;
using Bps.Core.Response;
using Bps.Core.Aspects.Postsharp.CacheAspects;
using Bps.Core.CrossCuttingConcerns.Caching.Microsoft;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Exception;
using Bps.Core.Aspects.Postsharp.ValidationAspects;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.ValidationRules.FluentValidation.WM;
using Bps.BpsBase.Business.Abstract.WM;
using Bps.BpsBase.DataAccess.Abstract.WM;
using Bps.BpsBase.Entities.Concrete.WM;


#region ClientUsing
using Bps.BpsBase.Entities.Models.SP.Listed;
using System.Data.SqlClient;
using System.Collections.Generic;
#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.WM
{
    public class WmadrsManager : IWmadrsService
    {
        private IWmadrsDal _wmadrsDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public WmadrsManager(IWmadrsDal wmadrsDal,IGnService gnservice,ILockedService lockedservice)
        {
            _wmadrsDal = wmadrsDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<WMADRS> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<WMADRS>();
            sonuc.Items = global.SirketId != null ? _wmadrsDal.GetList(x => x.SIRKID == global.SirketId) : _wmadrsDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<WMADRS> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<WMADRS>();
            sonuc.Items = global.SirketId != null ? _wmadrsDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _wmadrsDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<WMADRS> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<WMADRS>();
            sonuc.Items = global.SirketId != null ? _wmadrsDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _wmadrsDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<WMADRS> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<WMADRS>();
            sonuc.Items = global.SirketId != null ? _wmadrsDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _wmadrsDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<WMADRS> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<WMADRS>();
            sonuc.Items = global.SirketId != null ? _wmadrsDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _wmadrsDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<WMADRS> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<WMADRS>();
            sonuc.Nesne = _wmadrsDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<WMADRS> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("WMADRS", id, global);
            var sonuc = new StandardResponse<WMADRS>();
            sonuc.Nesne = _wmadrsDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(WmadrsValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<WMADRS> Ncch_Add_NLog(WMADRS wmadrs, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<WMADRS>();
            wmadrs.SIRKID = global.SirketId.Value; 
            wmadrs.EKKULL = global.UserKod;
            wmadrs.ETARIH = DateTime.Now;
            wmadrs.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _wmadrsDal.Add(wmadrs);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(WmadrsValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<WMADRS> Ncch_Update_Log(WMADRS wmadrs,WMADRS oldWmadrs, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("WMADRS", wmadrs.Id, global);
            var sonuc = new StandardResponse<WMADRS>();
            wmadrs.SIRKID = global.SirketId.Value; 
            wmadrs.DEKULL = global.UserKod;
            wmadrs.DTARIH = DateTime.Now;
            wmadrs.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _wmadrsDal.Update(wmadrs);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(WmadrsValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<WMADRS> Ncch_UpdateAktifPasif_Log(WMADRS wmadrs, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<WMADRS>();
            wmadrs.SIRKID = global.SirketId.Value; 
            wmadrs.ACTIVE = !wmadrs.ACTIVE;
            wmadrs.DEKULL = global.UserKod;
            wmadrs.DTARIH = DateTime.Now;
            wmadrs.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _wmadrsDal.Update(wmadrs);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(WmadrsValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<WMADRS> Ncch_Delete_Log(WMADRS wmadrs, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("WMADRS", wmadrs.Id, global);
            var sonuc = new StandardResponse<WMADRS>();
            wmadrs.SIRKID = global.SirketId.Value; 
            wmadrs.ACTIVE = false;
            wmadrs.SLINDI = true;
            wmadrs.DEKULL = global.UserKod;
            wmadrs.DTARIH = DateTime.Now;
            wmadrs.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _wmadrsDal.Update(wmadrs);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        public ListResponse<WMADRS> Ncch_GetByBelgeNo_NLog(Global global, string belgeNo, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<WMADRS>();
            sonuc.Items = global.SirketId != null ? _wmadrsDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE && !x.SLINDI && x.BELGEN == belgeNo) : _wmadrsDal.GetList(x => x.ACTIVE && !x.SLINDI && x.BELGEN == belgeNo);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }


        public ListResponse<SpStokAdresMiktar> GetSiparisStokAdresMiktar(Global global, string sipBelgeNo, bool rezervasyon, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }

            var sonuc = new ListResponse<SpStokAdresMiktar> { Items = new List<SpStokAdresMiktar>() };
            string sql;

            if (rezervasyon)
            {
                sql = @"SELECT rez.STKODU, rez.STKNAM, DPADRS, SUM(USESTK) AS USESTK FROM 
                        (SELECT DISTINCT SIRKID, STKODU, STKNAM FROM SPREZV WHERE SIRKID = @SirketId AND ACTIVE = 1 AND SPBLNO = @SipBelgeNo) AS rez 
                        INNER JOIN WMADRS ON rez.SIRKID = WMADRS.SIRKID AND rez.STKODU = WMADRS.STKODU COLLATE SQL_Latin1_General_CP1_CI_AS
                        WHERE WMADRS.USESTK > 0 AND WMADRS.ACTIVE = 1
                        GROUP BY rez.STKODU, rez.STKNAM, DPADRS
                        ORDER BY rez.STKODU";
            }
            else
            {
                sql = @"SELECT dbo.SPFHAR.STKODU, dbo.SPFHAR.STKNAM, dbo.WMADRS.DPADRS, 
                        SUM(dbo.WMADRS.USESTK) AS USESTK, dbo.SPFHAR.PARTIN, dbo.SPFHAR.PARTIT FROM dbo.SPFHAR 
                        INNER JOIN dbo.WMADRS ON dbo.SPFHAR.SIRKID = dbo.WMADRS.SIRKID AND dbo.SPFHAR.STKODU = dbo.WMADRS.STKODU
                        WHERE SPFHAR.SIRKID = @SirketId AND SPFHAR.BELGEN = @SipBelgeNo AND SPFHAR.ACTIVE = 1 AND dbo.WMADRS.USESTK > 0 AND WMADRS.ACTIVE = 1
                        GROUP BY dbo.SPFHAR.BELGEN, dbo.SPFHAR.STKODU, dbo.SPFHAR.STKNAM, dbo.WMADRS.DPADRS, dbo.SPFHAR.PARTIN, dbo.SPFHAR.PARTIT";
            }


            sonuc.Items = _wmadrsDal.GetListSqlQuery<SpStokAdresMiktar>(sql, new SqlParameter("SirketId", global.SirketId), new SqlParameter("SipBelgeNo", sipBelgeNo));
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #endregion ClientFunc
    }
}
