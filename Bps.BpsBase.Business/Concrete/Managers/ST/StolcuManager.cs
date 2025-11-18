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
    public class StolcuManager : IStolcuService
    {
        private IStolcuDal _stolcuDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public StolcuManager(IStolcuDal stolcuDal,IGnService gnservice,ILockedService lockedservice)
        {
            _stolcuDal = stolcuDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<STOLCU> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STOLCU>();
            sonuc.Items = global.SirketId != null ? _stolcuDal.GetList(x => x.SIRKID == global.SirketId) : _stolcuDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STOLCU> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STOLCU>();
            sonuc.Items = global.SirketId != null ? _stolcuDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _stolcuDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STOLCU> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STOLCU>();
            sonuc.Items = global.SirketId != null ? _stolcuDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _stolcuDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STOLCU> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STOLCU>();
            sonuc.Items = global.SirketId != null ? _stolcuDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _stolcuDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STOLCU> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STOLCU>();
            sonuc.Items = global.SirketId != null ? _stolcuDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _stolcuDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<STOLCU> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<STOLCU>();
            sonuc.Nesne = _stolcuDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<STOLCU> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("STOLCU", id, global);
            var sonuc = new StandardResponse<STOLCU>();
            sonuc.Nesne = _stolcuDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StolcuValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STOLCU> Ncch_Add_NLog(STOLCU stolcu, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<STOLCU>();
            stolcu.SIRKID = global.SirketId.Value; 
            stolcu.EKKULL = global.UserKod;
            stolcu.ETARIH = DateTime.Now;
            stolcu.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stolcuDal.Add(stolcu);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StolcuValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STOLCU> Ncch_Update_Log(STOLCU stolcu,STOLCU oldStolcu, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("STOLCU", stolcu.Id, global);
            var sonuc = new StandardResponse<STOLCU>();
            stolcu.SIRKID = global.SirketId.Value; 
            stolcu.DEKULL = global.UserKod;
            stolcu.DTARIH = DateTime.Now;
            stolcu.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stolcuDal.Update(stolcu);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StolcuValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STOLCU> Ncch_UpdateAktifPasif_Log(STOLCU stolcu, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<STOLCU>();
            stolcu.SIRKID = global.SirketId.Value; 
            stolcu.ACTIVE = !stolcu.ACTIVE;
            stolcu.DEKULL = global.UserKod;
            stolcu.DTARIH = DateTime.Now;
            stolcu.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stolcuDal.Update(stolcu);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StolcuValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STOLCU> Ncch_Delete_Log(STOLCU stolcu, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("STOLCU", stolcu.Id, global);
            var sonuc = new StandardResponse<STOLCU>();
            stolcu.SIRKID = global.SirketId.Value; 
            stolcu.ACTIVE = false;
            stolcu.SLINDI = true;
            stolcu.DEKULL = global.UserKod;
            stolcu.DTARIH = DateTime.Now;
            stolcu.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stolcuDal.Update(stolcu);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        public ListResponse<STOLCU> Ncch_GetByStKod_NLog(string stokKodu, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STOLCU>();
            sonuc.Items = _stolcuDal.GetList(x => x.STKODU == stokKodu && x.ACTIVE && !x.SLINDI).ToList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }
        public StandardResponse Ncch_DeleteByStKod_NLog(string stokKodu, Global global)
        {
            var sonuc = new StandardResponse();
            var items = _stolcuDal.GetList(x => x.STKODU == stokKodu).ToList();

            foreach (var item in items)
            {
                item.SLINDI = true;
                item.ACTIVE = false;
                item.DEKULL = global.UserKod;
                item.DTARIH=DateTime.Now;
                _stolcuDal.Update(item);
            }
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #endregion ClientFunc
    }
}
