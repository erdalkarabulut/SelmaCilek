using System;
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

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.SP
{
    public class SpftipManager : ISpftipService
    {
        private ISpftipDal _spftipDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public SpftipManager(ISpftipDal spftipDal,IGnService gnservice,ILockedService lockedservice)
        {
            _spftipDal = spftipDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<SPFTIP> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SPFTIP>();
            sonuc.Items = global.SirketId != null ? _spftipDal.GetList(x => x.SIRKID == global.SirketId) : _spftipDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SPFTIP> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SPFTIP>();
            sonuc.Items = global.SirketId != null ? _spftipDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _spftipDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SPFTIP> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SPFTIP>();
            sonuc.Items = global.SirketId != null ? _spftipDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _spftipDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SPFTIP> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SPFTIP>();
            sonuc.Items = global.SirketId != null ? _spftipDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _spftipDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SPFTIP> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SPFTIP>();
            sonuc.Items = global.SirketId != null ? _spftipDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _spftipDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<SPFTIP> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<SPFTIP>();
            sonuc.Nesne = _spftipDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<SPFTIP> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("SPFTIP", id, global);
            var sonuc = new StandardResponse<SPFTIP>();
            sonuc.Nesne = _spftipDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SpftipValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SPFTIP> Ncch_Add_NLog(SPFTIP spftip, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<SPFTIP>();
            spftip.SIRKID = global.SirketId.Value; 
            spftip.EKKULL = global.UserKod;
            spftip.ETARIH = DateTime.Now;
            spftip.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _spftipDal.Add(spftip);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SpftipValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SPFTIP> Ncch_Update_Log(SPFTIP spftip,SPFTIP oldSpftip, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("SPFTIP", spftip.Id, global);
            var sonuc = new StandardResponse<SPFTIP>();
            spftip.SIRKID = global.SirketId.Value; 
            spftip.DEKULL = global.UserKod;
            spftip.DTARIH = DateTime.Now;
            spftip.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _spftipDal.Update(spftip);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SpftipValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SPFTIP> Ncch_UpdateAktifPasif_Log(SPFTIP spftip, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<SPFTIP>();
            spftip.SIRKID = global.SirketId.Value; 
            spftip.ACTIVE = !spftip.ACTIVE;
            spftip.DEKULL = global.UserKod;
            spftip.DTARIH = DateTime.Now;
            spftip.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _spftipDal.Update(spftip);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SpftipValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SPFTIP> Ncch_Delete_Log(SPFTIP spftip, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("SPFTIP", spftip.Id, global);
            var sonuc = new StandardResponse<SPFTIP>();
            spftip.SIRKID = global.SirketId.Value; 
            spftip.ACTIVE = false;
            spftip.SLINDI = true;
            spftip.DEKULL = global.UserKod;
            spftip.DTARIH = DateTime.Now;
            spftip.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _spftipDal.Update(spftip);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc
        
        public ListResponse<SPFTIP> Ncch_GetListBySphrtp_NLog(Global global, int? sphrtp = null, bool yetkiKontrol = true)
        {
	        if (sphrtp == null) sphrtp = global.Sira;

            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SPFTIP>();
            sonuc.Items = global.SirketId != null ? _spftipDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE && x.SPHRTP == sphrtp) : _spftipDal.GetList(x => x.ACTIVE && x.SPHRTP == sphrtp);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<SPFTIP> Cch_GetBySPFTNO_NLog(int ftno, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<SPFTIP>();
            sonuc.Nesne = _spftipDal.Get(x => x.SPFTNO == ftno && x.SIRKID == global.SirketId);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        

        #endregion ClientFunc
    }
}
