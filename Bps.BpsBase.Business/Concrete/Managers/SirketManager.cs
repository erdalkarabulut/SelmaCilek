using System;
using Bps.Core.Response;
using Bps.Core.Aspects.Postsharp.CacheAspects;
using Bps.Core.CrossCuttingConcerns.Caching.Microsoft;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Exception;
using Bps.Core.Aspects.Postsharp.ValidationAspects;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.ValidationRules.FluentValidation;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.DataAccess.Abstract;
using Bps.BpsBase.Entities.Concrete;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers
{
    public class SirketManager : ISirketService
    {
        private ISirketDal _sirketDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public SirketManager(ISirketDal sirketDal,IGnService gnservice,ILockedService lockedservice)
        {
            _sirketDal = sirketDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<SIRKET> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SIRKET>();
            sonuc.Items = _sirketDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SIRKET> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SIRKET>();
            sonuc.Items = _sirketDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SIRKET> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SIRKET>();
            sonuc.Items = _sirketDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SIRKET> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SIRKET>();
            sonuc.Items = _sirketDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SIRKET> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SIRKET>();
            sonuc.Items = _sirketDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<SIRKET> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<SIRKET>();
            sonuc.Nesne = _sirketDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<SIRKET> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("SIRKET", id, global);
            var sonuc = new StandardResponse<SIRKET>();
            sonuc.Nesne = _sirketDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SirketValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SIRKET> Ncch_Add_NLog(SIRKET sirket, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<SIRKET>();
            sirket.EKKULL = global.UserKod;
            sirket.ETARIH = DateTime.Now;
            sirket.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _sirketDal.Add(sirket);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SirketValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SIRKET> Ncch_Update_Log(SIRKET sirket,SIRKET oldSirket, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("SIRKET", sirket.Id, global);
            var sonuc = new StandardResponse<SIRKET>();
            sirket.DEKULL = global.UserKod;
            sirket.DTARIH = DateTime.Now;
            sirket.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _sirketDal.Update(sirket);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SirketValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SIRKET> Ncch_UpdateAktifPasif_Log(SIRKET sirket, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<SIRKET>();
            sirket.ACTIVE = !sirket.ACTIVE;
            sirket.DEKULL = global.UserKod;
            sirket.DTARIH = DateTime.Now;
            sirket.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _sirketDal.Update(sirket);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SirketValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SIRKET> Ncch_Delete_Log(SIRKET sirket, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("SIRKET", sirket.Id, global);
            var sonuc = new StandardResponse<SIRKET>();
            sirket.ACTIVE = false;
            sirket.SLINDI = true;
            sirket.DEKULL = global.UserKod;
            sirket.DTARIH = DateTime.Now;
            sirket.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _sirketDal.Update(sirket);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc
        
        public ListResponse<SIRKET> GetResmiSirketList()
        {
            var sonuc = new ListResponse<SIRKET>();
            sonuc.Items = _sirketDal.GetList(x => x.ACTIVE && x.SLINDI == false && x.SRKTYP == true);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<SIRKET> Ncch_GetKarsiSirket_Log(Global global)
        {
            var sonuc = new StandardResponse<SIRKET>();

            var sirket = _sirketDal.Get(w=>w.Id == global.SirketId);
            var sirketType = sirket.SRKTYP;
            sonuc.Nesne = sirketType.Value ? _sirketDal.Get(w => w.KARSIS == sirket.Id && w.SRKTYP == false) : _sirketDal.Get(w => w.KARSIS == sirket.Id && w.SRKTYP == true);

            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #endregion ClientFunc
    }
}
