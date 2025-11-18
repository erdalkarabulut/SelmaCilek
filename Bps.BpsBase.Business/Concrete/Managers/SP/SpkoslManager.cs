using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Bps.Core.Response;
using Bps.Core.Aspects.Postsharp.CacheAspects;
using Bps.Core.CrossCuttingConcerns.Caching.Microsoft;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Exception;
using Bps.Core.Aspects.Postsharp.ValidationAspects;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.ValidationRules.FluentValidation.SP;
using Bps.BpsBase.Business.Abstract.SP;
using Bps.BpsBase.DataAccess.Abstract.SP;
using Bps.BpsBase.Entities.Concrete.SP;
using Bps.BpsBase.Entities.Models.SP.Listed;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.SP
{
    public class SpkoslManager : ISpkoslService
    {
        private ISpkoslDal _spkoslDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public SpkoslManager(ISpkoslDal spkoslDal,IGnService gnservice,ILockedService lockedservice)
        {
            _spkoslDal = spkoslDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<SPKOSL> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SPKOSL>();
            sonuc.Items = global.SirketId != null ? _spkoslDal.GetList(x => x.SIRKID == global.SirketId) : _spkoslDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SPKOSL> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SPKOSL>();
            sonuc.Items = global.SirketId != null ? _spkoslDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _spkoslDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SPKOSL> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SPKOSL>();
            sonuc.Items = global.SirketId != null ? _spkoslDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _spkoslDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SPKOSL> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SPKOSL>();
            sonuc.Items = global.SirketId != null ? _spkoslDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _spkoslDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SPKOSL> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SPKOSL>();
            sonuc.Items = global.SirketId != null ? _spkoslDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _spkoslDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<SPKOSL> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<SPKOSL>();
            sonuc.Nesne = _spkoslDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<SPKOSL> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("SPKOSL", id, global);
            var sonuc = new StandardResponse<SPKOSL>();
            sonuc.Nesne = _spkoslDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SpkoslValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SPKOSL> Ncch_Add_NLog(SPKOSL spkosl, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<SPKOSL>();
            spkosl.SIRKID = global.SirketId.Value; 
            spkosl.EKKULL = global.UserKod;
            spkosl.ETARIH = DateTime.Now;
            spkosl.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _spkoslDal.Add(spkosl);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SpkoslValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SPKOSL> Ncch_Update_Log(SPKOSL spkosl,SPKOSL oldSpkosl, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("SPKOSL", spkosl.Id, global);
            var sonuc = new StandardResponse<SPKOSL>();
            spkosl.SIRKID = global.SirketId.Value; 
            spkosl.DEKULL = global.UserKod;
            spkosl.DTARIH = DateTime.Now;
            spkosl.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _spkoslDal.Update(spkosl);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SpkoslValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SPKOSL> Ncch_UpdateAktifPasif_Log(SPKOSL spkosl, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<SPKOSL>();
            spkosl.SIRKID = global.SirketId.Value; 
            spkosl.ACTIVE = !spkosl.ACTIVE;
            spkosl.DEKULL = global.UserKod;
            spkosl.DTARIH = DateTime.Now;
            spkosl.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _spkoslDal.Update(spkosl);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SpkoslValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SPKOSL> Ncch_Delete_Log(SPKOSL spkosl, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("SPKOSL", spkosl.Id, global);
            var sonuc = new StandardResponse<SPKOSL>();
            spkosl.SIRKID = global.SirketId.Value; 
            spkosl.ACTIVE = false;
            spkosl.SLINDI = true;
            spkosl.DEKULL = global.UserKod;
            spkosl.DTARIH = DateTime.Now;
            spkosl.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _spkoslDal.Update(spkosl);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        public ListResponse<SPKOSL> Ncch_GetListByBelgeNo_NLog(Global global, string belgeNo)
        {
            var sonuc = new ListResponse<SPKOSL>();
            sonuc.Items = _spkoslDal.GetList(x => x.SIRKID == global.SirketId && x.BELGEN == belgeNo && x.ACTIVE && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SiparisKosulModel> Ncch_GetListByBelgeNoJoinGnkosul_NLog(Global global, string belgeNo, string langkd)
        {
            var sonuc = new ListResponse<SiparisKosulModel> { Items = new List<SiparisKosulModel>() };
            var sql = @"SELECT DISTINCT dbo.SPKOSL.SIRKID, dbo.SPKOSL.BELGEN, dbo.GNKOSL.Id, dbo.GNKOSL.KOSULL, dbo.GNKOSL.LANGKD FROM dbo.GNKOSL
                        RIGHT OUTER JOIN dbo.SPKOSL ON dbo.GNKOSL.SIRKID = dbo.SPKOSL.SIRKID AND dbo.GNKOSL.Id = dbo.SPKOSL.KOSLID
                        WHERE (dbo.SPKOSL.BELGEN = @BelgeNo) AND (dbo.GNKOSL.SIRKID = @SirketId) AND (dbo.GNKOSL.LANGKD = @Langkd) AND (dbo.GNKOSL.ACTIVE = 1) AND (dbo.GNKOSL.SLINDI = 0)";

            sonuc.Items = _spkoslDal.GetListSqlQuery<SiparisKosulModel>(sql, new SqlParameter("SirketId", global.SirketId), new SqlParameter("BelgeNo", belgeNo), new SqlParameter("Langkd", langkd));
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<SPKOSL> Ncch_DeleteKosul_Log(SPKOSL spkosl, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<SPKOSL>();
            sonuc.Nesne = _spkoslDal.Delete(spkosl);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #endregion ClientFunc
    }
}
