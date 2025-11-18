using System;
using Bps.Core.Response;
using Bps.Core.Aspects.Postsharp.CacheAspects;
using Bps.Core.CrossCuttingConcerns.Caching.Microsoft;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Exception;
using Bps.Core.Aspects.Postsharp.ValidationAspects;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.ValidationRules.FluentValidation.ST;
using Bps.BpsBase.Business.Abstract.ST;
using Bps.BpsBase.DataAccess.Abstract.ST;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.ST
{
    public class SturyrManager : ISturyrService
    {
        private ISturyrDal _sturyrDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public SturyrManager(ISturyrDal sturyrDal,IGnService gnservice,ILockedService lockedservice)
        {
            _sturyrDal = sturyrDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<STURYR> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STURYR>();
            sonuc.Items = global.SirketId != null ? _sturyrDal.GetList(x => x.SIRKID == global.SirketId) : _sturyrDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STURYR> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STURYR>();
            sonuc.Items = global.SirketId != null ? _sturyrDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _sturyrDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STURYR> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STURYR>();
            sonuc.Items = global.SirketId != null ? _sturyrDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _sturyrDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STURYR> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STURYR>();
            sonuc.Items = global.SirketId != null ? _sturyrDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _sturyrDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STURYR> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STURYR>();
            sonuc.Items = global.SirketId != null ? _sturyrDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _sturyrDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<STURYR> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<STURYR>();
            sonuc.Nesne = _sturyrDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<STURYR> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("STURYR", id, global);
            var sonuc = new StandardResponse<STURYR>();
            sonuc.Nesne = _sturyrDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SturyrValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STURYR> Ncch_Add_NLog(STURYR sturyr, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<STURYR>();
            sturyr.SIRKID = global.SirketId.Value; 
            sturyr.EKKULL = global.UserKod;
            sturyr.ETARIH = DateTime.Now;
            sturyr.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _sturyrDal.Add(sturyr);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SturyrValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STURYR> Ncch_Update_Log(STURYR sturyr,STURYR oldSturyr, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("STURYR", sturyr.Id, global);
            var sonuc = new StandardResponse<STURYR>();
            sturyr.SIRKID = global.SirketId.Value; 
            sturyr.DEKULL = global.UserKod;
            sturyr.DTARIH = DateTime.Now;
            sturyr.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _sturyrDal.Update(sturyr);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SturyrValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STURYR> Ncch_UpdateAktifPasif_Log(STURYR sturyr, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<STURYR>();
            sturyr.SIRKID = global.SirketId.Value; 
            sturyr.ACTIVE = !sturyr.ACTIVE;
            sturyr.DEKULL = global.UserKod;
            sturyr.DTARIH = DateTime.Now;
            sturyr.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _sturyrDal.Update(sturyr);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SturyrValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STURYR> Ncch_Delete_Log(STURYR sturyr, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("STURYR", sturyr.Id, global);
            var sonuc = new StandardResponse<STURYR>();
            sturyr.SIRKID = global.SirketId.Value; 
            sturyr.ACTIVE = false;
            sturyr.SLINDI = true;
            sturyr.DEKULL = global.UserKod;
            sturyr.DTARIH = DateTime.Now;
            sturyr.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _sturyrDal.Update(sturyr);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        public ListResponse<STURYR> Cch_GetListByStokKodu_NLog(string stokKodu, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STURYR>();
            sonuc.Items = global.SirketId != null ? _sturyrDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false && x.ACTIVE && x.STKODU == stokKodu) : _sturyrDal.GetList(x => x.SLINDI == false && x.ACTIVE && x.STKODU == stokKodu);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #endregion ClientFunc
    }
}
