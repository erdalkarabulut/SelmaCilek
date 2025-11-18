using System;
using Bps.Core.Response;
using Bps.Core.Aspects.Postsharp.CacheAspects;
using Bps.Core.CrossCuttingConcerns.Caching.Microsoft;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Exception;
using Bps.Core.Aspects.Postsharp.ValidationAspects;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.ValidationRules.FluentValidation.IS;
using Bps.BpsBase.Business.Abstract.IS;
using Bps.BpsBase.DataAccess.Abstract.IS;
using Bps.BpsBase.Entities.Concrete.IS;

#region ClientUsing

using Bps.BpsBase.Entities.Models.UA;
using System.Data.SqlClient;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.IS
{
    public class IsrevzManager : IIsrevzService
    {
        private IIsrevzDal _isrevzDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public IsrevzManager(IIsrevzDal isrevzDal,IGnService gnservice,ILockedService lockedservice)
        {
            _isrevzDal = isrevzDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<ISREVZ> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<ISREVZ>();
            sonuc.Items = global.SirketId != null ? _isrevzDal.GetList(x => x.SIRKID == global.SirketId) : _isrevzDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<ISREVZ> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<ISREVZ>();
            sonuc.Items = global.SirketId != null ? _isrevzDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _isrevzDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<ISREVZ> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<ISREVZ>();
            sonuc.Items = global.SirketId != null ? _isrevzDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _isrevzDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<ISREVZ> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<ISREVZ>();
            sonuc.Items = global.SirketId != null ? _isrevzDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _isrevzDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<ISREVZ> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<ISREVZ>();
            sonuc.Items = global.SirketId != null ? _isrevzDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _isrevzDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<ISREVZ> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<ISREVZ>();
            sonuc.Nesne = _isrevzDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<ISREVZ> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("ISREVZ", id, global);
            var sonuc = new StandardResponse<ISREVZ>();
            sonuc.Nesne = _isrevzDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(IsrevzValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<ISREVZ> Ncch_Add_NLog(ISREVZ isrevz, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<ISREVZ>();
            isrevz.SIRKID = global.SirketId.Value; 
            isrevz.EKKULL = global.UserKod;
            isrevz.ETARIH = DateTime.Now;
            isrevz.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _isrevzDal.Add(isrevz);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(IsrevzValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<ISREVZ> Ncch_Update_Log(ISREVZ isrevz,ISREVZ oldIsrevz, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("ISREVZ", isrevz.Id, global);
            var sonuc = new StandardResponse<ISREVZ>();
            isrevz.SIRKID = global.SirketId.Value; 
            isrevz.DEKULL = global.UserKod;
            isrevz.DTARIH = DateTime.Now;
            isrevz.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _isrevzDal.Update(isrevz);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(IsrevzValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<ISREVZ> Ncch_UpdateAktifPasif_Log(ISREVZ isrevz, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<ISREVZ>();
            isrevz.SIRKID = global.SirketId.Value; 
            isrevz.ACTIVE = !isrevz.ACTIVE;
            isrevz.DEKULL = global.UserKod;
            isrevz.DTARIH = DateTime.Now;
            isrevz.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _isrevzDal.Update(isrevz);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(IsrevzValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<ISREVZ> Ncch_Delete_Log(ISREVZ isrevz, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("ISREVZ", isrevz.Id, global);
            var sonuc = new StandardResponse<ISREVZ>();
            isrevz.SIRKID = global.SirketId.Value; 
            isrevz.ACTIVE = false;
            isrevz.SLINDI = true;
            isrevz.DEKULL = global.UserKod;
            isrevz.DTARIH = DateTime.Now;
            isrevz.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _isrevzDal.Update(isrevz);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        public ListResponse<UrunAgaciRevizyonList> Cch_GetListByUAModel_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<UrunAgaciRevizyonList>();
            var sql = @"Select 
                a.GNREZV  as RevizyonNo, a.TANIMI as RevizyonText
                from dbo.ISREVZ as a
                Where a.SIRKID=@sirketId and a.ACTIVE=1 and a.SLINDI=0";

            //Thread.Sleep(3000);
            sonuc.Items = _isrevzDal.GetListSqlQuery<UrunAgaciRevizyonList>(sql,
                new SqlParameter("@sirketId", global.SirketId));
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #endregion ClientFunc
    }
}
