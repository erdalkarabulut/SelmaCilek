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

using System.Collections.Generic;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.ST
{
    public class StkfiyManager : IStkfiyService
    {
        private IStkfiyDal _stkfiyDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public StkfiyManager(IStkfiyDal stkfiyDal,IGnService gnservice,ILockedService lockedservice)
        {
            _stkfiyDal = stkfiyDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<STKFIY> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STKFIY>();
            sonuc.Items = global.SirketId != null ? _stkfiyDal.GetList(x => x.SIRKID == global.SirketId) : _stkfiyDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STKFIY> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STKFIY>();
            sonuc.Items = global.SirketId != null ? _stkfiyDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _stkfiyDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STKFIY> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STKFIY>();
            sonuc.Items = global.SirketId != null ? _stkfiyDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _stkfiyDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STKFIY> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STKFIY>();
            sonuc.Items = global.SirketId != null ? _stkfiyDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _stkfiyDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STKFIY> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STKFIY>();
            sonuc.Items = global.SirketId != null ? _stkfiyDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _stkfiyDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<STKFIY> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<STKFIY>();
            sonuc.Nesne = _stkfiyDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<STKFIY> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("STKFIY", id, global);
            var sonuc = new StandardResponse<STKFIY>();
            sonuc.Nesne = _stkfiyDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StkfiyValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STKFIY> Ncch_Add_NLog(STKFIY stkfiy, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<STKFIY>();
            stkfiy.SIRKID = global.SirketId.Value; 
            stkfiy.EKKULL = global.UserKod;
            stkfiy.ETARIH = DateTime.Now;
            stkfiy.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stkfiyDal.Add(stkfiy);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StkfiyValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STKFIY> Ncch_Update_Log(STKFIY stkfiy,STKFIY oldStkfiy, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("STKFIY", stkfiy.Id, global);
            var sonuc = new StandardResponse<STKFIY>();
            stkfiy.SIRKID = global.SirketId.Value; 
            stkfiy.DEKULL = global.UserKod;
            stkfiy.DTARIH = DateTime.Now;
            stkfiy.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stkfiyDal.Update(stkfiy);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StkfiyValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STKFIY> Ncch_UpdateAktifPasif_Log(STKFIY stkfiy, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<STKFIY>();
            stkfiy.SIRKID = global.SirketId.Value; 
            stkfiy.ACTIVE = !stkfiy.ACTIVE;
            stkfiy.DEKULL = global.UserKod;
            stkfiy.DTARIH = DateTime.Now;
            stkfiy.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stkfiyDal.Update(stkfiy);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StkfiyValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STKFIY> Ncch_Delete_Log(STKFIY stkfiy, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("STKFIY", stkfiy.Id, global);
            var sonuc = new StandardResponse<STKFIY>();
            stkfiy.SIRKID = global.SirketId.Value; 
            stkfiy.ACTIVE = false;
            stkfiy.SLINDI = true;
            stkfiy.DEKULL = global.UserKod;
            stkfiy.DTARIH = DateTime.Now;
            stkfiy.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stkfiyDal.Update(stkfiy);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        public ListResponse<STKFIY> Cch_GetListByStfyno_NLog(Global global, int stfyno, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STKFIY>();
            sonuc.Items = _stkfiyDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false && x.STFYNO == stfyno);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StkfiyValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STKFIY> Ncch_Save_NLog(List<STKFIY> stkfisList, STKFYT stkfyt, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<STKFIY>();

            if (stkfisList.Count < 1)
            {
                sonuc.Status = ResponseStatusEnum.ERROR;
                sonuc.Message = "Fiyat listeside KAYIT YOK!";
                return sonuc;
            }

            int stfyno = Convert.ToInt32(stkfyt.STFYNO);

            var oldDatas = _stkfiyDal.GetList(g => g.STFYNO == stfyno);
            foreach (var stkfiy in oldDatas)
            {
                _stkfiyDal.Delete(stkfiy);
            }

            foreach (var stkfiy in stkfisList)
            {
                stkfiy.SIRKID = global.SirketId.Value;
                stkfiy.EKKULL = global.UserKod;
                stkfiy.ETARIH = DateTime.Now;
                stkfiy.KYNKKD = global.KaynakKod;
                sonuc.Nesne = _stkfiyDal.Add(stkfiy);
            }

            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<STKFIY> Ncch_GetFiyatByFytNoStokKod_NLog(int? fytNo, string stokKod, Global global)
        {
            var sonuc = new StandardResponse<STKFIY>();

            if (fytNo == null || string.IsNullOrEmpty(stokKod))
            {
                sonuc.Status = ResponseStatusEnum.ERROR;
                return sonuc;
            }

            sonuc.Nesne = _stkfiyDal.Get(g =>
                g.SIRKID == global.SirketId.Value && g.ACTIVE && g.STFYNO == fytNo && g.STKODU == stokKod && g.BASTAR.Value <= DateTime.Today && g.BITTAR.Value >= DateTime.Today);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #endregion ClientFunc
    }
}
