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
    public class StnameManager : IStnameService
    {
        private IStnameDal _stnameDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public StnameManager(IStnameDal stnameDal,IGnService gnservice,ILockedService lockedservice)
        {
            _stnameDal = stnameDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<STNAME> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STNAME>();
            sonuc.Items = global.SirketId != null ? _stnameDal.GetList(x => x.SIRKID == global.SirketId) : _stnameDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STNAME> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STNAME>();
            sonuc.Items = global.SirketId != null ? _stnameDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _stnameDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STNAME> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STNAME>();
            sonuc.Items = global.SirketId != null ? _stnameDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _stnameDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STNAME> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STNAME>();
            sonuc.Items = global.SirketId != null ? _stnameDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _stnameDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STNAME> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STNAME>();
            sonuc.Items = global.SirketId != null ? _stnameDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _stnameDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<STNAME> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<STNAME>();
            sonuc.Nesne = _stnameDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<STNAME> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("STNAME", id, global);
            var sonuc = new StandardResponse<STNAME>();
            sonuc.Nesne = _stnameDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StnameValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STNAME> Ncch_Add_NLog(STNAME stname, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<STNAME>();
            stname.SIRKID = global.SirketId.Value; 
            stname.EKKULL = global.UserKod;
            stname.ETARIH = DateTime.Now;
            stname.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stnameDal.Add(stname);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StnameValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STNAME> Ncch_Update_Log(STNAME stname,STNAME oldStname, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("STNAME", stname.Id, global);
            var sonuc = new StandardResponse<STNAME>();
            stname.SIRKID = global.SirketId.Value; 
            stname.DEKULL = global.UserKod;
            stname.DTARIH = DateTime.Now;
            stname.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stnameDal.Update(stname);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StnameValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STNAME> Ncch_UpdateAktifPasif_Log(STNAME stname, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<STNAME>();
            stname.SIRKID = global.SirketId.Value; 
            stname.ACTIVE = !stname.ACTIVE;
            stname.DEKULL = global.UserKod;
            stname.DTARIH = DateTime.Now;
            stname.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stnameDal.Update(stname);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StnameValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STNAME> Ncch_Delete_Log(STNAME stname, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("STNAME", stname.Id, global);
            var sonuc = new StandardResponse<STNAME>();
            stname.SIRKID = global.SirketId.Value; 
            stname.ACTIVE = false;
            stname.SLINDI = true;
            stname.DEKULL = global.UserKod;
            stname.DTARIH = DateTime.Now;
            stname.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stnameDal.Update(stname);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        public ListResponse<STNAME> Cch_GetListByStokKodu_NLog(Global global, string stokKodu, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STNAME>();
            sonuc.Items = global.SirketId != null ? _stnameDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false && x.ACTIVE && x.STKODU == stokKodu) : _stnameDal.GetList(x => x.SLINDI == false && x.ACTIVE && x.STKODU == stokKodu);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<STNAME> Cch_GetByStokKoduLangkd_NLog(Global global, string stokKodu, string langKd = "", bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<STNAME>();
            sonuc.Nesne = _stnameDal.Get(x => x.SLINDI == false && x.ACTIVE && x.STKODU == stokKodu && x.LANGKD == (langKd != "" ? langKd : global.DilKod));
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #endregion ClientFunc
    }
}
