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

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.WM
{
    public class WmhratManager : IWmhratService
    {
        private IWmhratDal _wmhratDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public WmhratManager(IWmhratDal wmhratDal,IGnService gnservice,ILockedService lockedservice)
        {
            _wmhratDal = wmhratDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<WMHRAT> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<WMHRAT>();
            sonuc.Items = global.SirketId != null ? _wmhratDal.GetList(x => x.SIRKID == global.SirketId) : _wmhratDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<WMHRAT> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<WMHRAT>();
            sonuc.Items = global.SirketId != null ? _wmhratDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _wmhratDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<WMHRAT> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<WMHRAT>();
            sonuc.Items = global.SirketId != null ? _wmhratDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _wmhratDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<WMHRAT> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<WMHRAT>();
            sonuc.Items = global.SirketId != null ? _wmhratDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _wmhratDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<WMHRAT> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<WMHRAT>();
            sonuc.Items = global.SirketId != null ? _wmhratDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _wmhratDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<WMHRAT> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<WMHRAT>();
            sonuc.Nesne = _wmhratDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<WMHRAT> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("WMHRAT", id, global);
            var sonuc = new StandardResponse<WMHRAT>();
            sonuc.Nesne = _wmhratDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(WmhratValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<WMHRAT> Ncch_Add_NLog(WMHRAT wmhrat, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<WMHRAT>();
            wmhrat.SIRKID = global.SirketId.Value; 
            wmhrat.EKKULL = global.UserKod;
            wmhrat.ETARIH = DateTime.Now;
            wmhrat.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _wmhratDal.Add(wmhrat);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(WmhratValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<WMHRAT> Ncch_Update_Log(WMHRAT wmhrat,WMHRAT oldWmhrat, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("WMHRAT", wmhrat.Id, global);
            var sonuc = new StandardResponse<WMHRAT>();
            wmhrat.SIRKID = global.SirketId.Value; 
            wmhrat.DEKULL = global.UserKod;
            wmhrat.DTARIH = DateTime.Now;
            wmhrat.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _wmhratDal.Update(wmhrat);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(WmhratValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<WMHRAT> Ncch_UpdateAktifPasif_Log(WMHRAT wmhrat, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<WMHRAT>();
            wmhrat.SIRKID = global.SirketId.Value; 
            wmhrat.ACTIVE = !wmhrat.ACTIVE;
            wmhrat.DEKULL = global.UserKod;
            wmhrat.DTARIH = DateTime.Now;
            wmhrat.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _wmhratDal.Update(wmhrat);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(WmhratValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<WMHRAT> Ncch_Delete_Log(WMHRAT wmhrat, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("WMHRAT", wmhrat.Id, global);
            var sonuc = new StandardResponse<WMHRAT>();
            wmhrat.SIRKID = global.SirketId.Value; 
            wmhrat.ACTIVE = false;
            wmhrat.SLINDI = true;
            wmhrat.DEKULL = global.UserKod;
            wmhrat.DTARIH = DateTime.Now;
            wmhrat.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _wmhratDal.Update(wmhrat);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc


        public StandardResponse<WMHRAT> Cch_GetByFisTip_NLog(int fisTip, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<WMHRAT>();
            sonuc.Nesne = _wmhratDal.Get(x => x.SIRKID == global.SirketId && x.STFTNO == fisTip && x.ACTIVE);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #endregion ClientFunc
    }
}
