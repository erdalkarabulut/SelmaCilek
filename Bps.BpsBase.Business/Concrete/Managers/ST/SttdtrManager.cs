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

using System.Linq;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.ST
{
    public class SttdtrManager : ISttdtrService
    {
        private ISttdtrDal _sttdtrDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public SttdtrManager(ISttdtrDal sttdtrDal,IGnService gnservice,ILockedService lockedservice)
        {
            _sttdtrDal = sttdtrDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<STTDTR> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STTDTR>();
            sonuc.Items = global.SirketId != null ? _sttdtrDal.GetList(x => x.SIRKID == global.SirketId) : _sttdtrDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STTDTR> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STTDTR>();
            sonuc.Items = global.SirketId != null ? _sttdtrDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _sttdtrDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STTDTR> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STTDTR>();
            sonuc.Items = global.SirketId != null ? _sttdtrDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _sttdtrDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STTDTR> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STTDTR>();
            sonuc.Items = global.SirketId != null ? _sttdtrDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _sttdtrDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STTDTR> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STTDTR>();
            sonuc.Items = global.SirketId != null ? _sttdtrDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _sttdtrDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<STTDTR> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<STTDTR>();
            sonuc.Nesne = _sttdtrDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<STTDTR> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("STTDTR", id, global);
            var sonuc = new StandardResponse<STTDTR>();
            sonuc.Nesne = _sttdtrDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SttdtrValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STTDTR> Ncch_Add_NLog(STTDTR sttdtr, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<STTDTR>();
            sttdtr.SIRKID = global.SirketId.Value; 
            sttdtr.EKKULL = global.UserKod;
            sttdtr.ETARIH = DateTime.Now;
            sttdtr.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _sttdtrDal.Add(sttdtr);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SttdtrValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STTDTR> Ncch_Update_Log(STTDTR sttdtr,STTDTR oldSttdtr, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("STTDTR", sttdtr.Id, global);
            var sonuc = new StandardResponse<STTDTR>();
            sttdtr.SIRKID = global.SirketId.Value; 
            sttdtr.DEKULL = global.UserKod;
            sttdtr.DTARIH = DateTime.Now;
            sttdtr.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _sttdtrDal.Update(sttdtr);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SttdtrValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STTDTR> Ncch_UpdateAktifPasif_Log(STTDTR sttdtr, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<STTDTR>();
            sttdtr.SIRKID = global.SirketId.Value; 
            sttdtr.ACTIVE = !sttdtr.ACTIVE;
            sttdtr.DEKULL = global.UserKod;
            sttdtr.DTARIH = DateTime.Now;
            sttdtr.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _sttdtrDal.Update(sttdtr);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SttdtrValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STTDTR> Ncch_Delete_Log(STTDTR sttdtr, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("STTDTR", sttdtr.Id, global);
            var sonuc = new StandardResponse<STTDTR>();
            sttdtr.SIRKID = global.SirketId.Value; 
            sttdtr.ACTIVE = false;
            sttdtr.SLINDI = true;
            sttdtr.DEKULL = global.UserKod;
            sttdtr.DTARIH = DateTime.Now;
            sttdtr.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _sttdtrDal.Update(sttdtr);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc


        public ListResponse<STTDTR> Cch_GetListByUretimYeri_NLog(string uretimYeri, Global global)
        {
            var sonuc = new ListResponse<STTDTR>();
            sonuc.Items = _sttdtrDal
                .GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false && x.URYRKD == uretimYeri).ToList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #endregion ClientFunc
    }
}
