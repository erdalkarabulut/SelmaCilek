using System;
using Bps.Core.Response;
using Bps.Core.Aspects.Postsharp.CacheAspects;
using Bps.Core.CrossCuttingConcerns.Caching.Microsoft;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Exception;
using Bps.Core.Aspects.Postsharp.ValidationAspects;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.ValidationRules.FluentValidation.GN;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.DataAccess.Abstract.GN;
using Bps.BpsBase.Entities.Concrete.GN;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.GN
{
    public class GnmesjManager : IGnmesjService
    {
        private IGnmesjDal _gnmesjDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public GnmesjManager(IGnmesjDal gnmesjDal,IGnService gnservice,ILockedService lockedservice)
        {
            _gnmesjDal = gnmesjDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<GNMESJ> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNMESJ>();
            sonuc.Items = global.SirketId != null ? _gnmesjDal.GetList(x => x.SIRKID == global.SirketId) : _gnmesjDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNMESJ> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNMESJ>();
            sonuc.Items = global.SirketId != null ? _gnmesjDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _gnmesjDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNMESJ> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNMESJ>();
            sonuc.Items = global.SirketId != null ? _gnmesjDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _gnmesjDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNMESJ> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNMESJ>();
            sonuc.Items = global.SirketId != null ? _gnmesjDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _gnmesjDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNMESJ> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNMESJ>();
            sonuc.Items = global.SirketId != null ? _gnmesjDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _gnmesjDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNMESJ> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<GNMESJ>();
            sonuc.Nesne = _gnmesjDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNMESJ> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("GNMESJ", id, global);
            var sonuc = new StandardResponse<GNMESJ>();
            sonuc.Nesne = _gnmesjDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnmesjValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNMESJ> Ncch_Add_NLog(GNMESJ gnmesj, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<GNMESJ>();
            gnmesj.SIRKID = global.SirketId.Value; 
            gnmesj.EKKULL = global.UserKod;
            gnmesj.ETARIH = DateTime.Now;
            gnmesj.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnmesjDal.Add(gnmesj);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnmesjValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNMESJ> Ncch_Update_Log(GNMESJ gnmesj,GNMESJ oldGnmesj, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("GNMESJ", gnmesj.Id, global);
            var sonuc = new StandardResponse<GNMESJ>();
            gnmesj.SIRKID = global.SirketId.Value; 
            gnmesj.DEKULL = global.UserKod;
            gnmesj.DTARIH = DateTime.Now;
            gnmesj.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnmesjDal.Update(gnmesj);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnmesjValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNMESJ> Ncch_UpdateAktifPasif_Log(GNMESJ gnmesj, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<GNMESJ>();
            gnmesj.SIRKID = global.SirketId.Value; 
            gnmesj.ACTIVE = !gnmesj.ACTIVE;
            gnmesj.DEKULL = global.UserKod;
            gnmesj.DTARIH = DateTime.Now;
            gnmesj.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnmesjDal.Update(gnmesj);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnmesjValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNMESJ> Ncch_Delete_Log(GNMESJ gnmesj, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("GNMESJ", gnmesj.Id, global);
            var sonuc = new StandardResponse<GNMESJ>();
            gnmesj.SIRKID = global.SirketId.Value; 
            gnmesj.ACTIVE = false;
            gnmesj.SLINDI = true;
            gnmesj.DEKULL = global.UserKod;
            gnmesj.DTARIH = DateTime.Now;
            gnmesj.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnmesjDal.Update(gnmesj);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        public ListResponse<GNMESJ> GetListByLangkd(Global global, string langkd, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNMESJ>();
            sonuc.Items = global.SirketId != null ? _gnmesjDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false && x.LANGKD == langkd) : _gnmesjDal.GetList(x => x.SLINDI == false && x.LANGKD == langkd);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNMESJ> GetMesajDirect(Global global, string msjNo, string m1 = null, string m2 = null, string m3 = null, string m4 = null, string mesajKod = null)
        {
            var sonuc = new StandardResponse<GNMESJ>();
            sonuc.Nesne = _gnmesjDal.Get(f =>
                f.MESJKD == (mesajKod ?? global.ProjeKod) &&
                f.LANGKD == global.DilKod && f.MESJNO == msjNo);
            if (sonuc.Nesne == null || string.IsNullOrEmpty(sonuc.Nesne.MSTEXT))
            {
                sonuc.Nesne= new GNMESJ()
                {
                    LANGKD = "tr",
                    MSTEXT = "Mesaj bilgisi yok!"
                };
                sonuc.Status = ResponseStatusEnum.ERROR;
                return sonuc;
            }
            var message = sonuc.Nesne.MSTEXT;
            if (!string.IsNullOrEmpty(message))
            {
                if (!string.IsNullOrEmpty(m1)) message = message.Replace("{0}", m1);
                if (!string.IsNullOrEmpty(m2)) message = message.Replace("{1}", m2);
                if (!string.IsNullOrEmpty(m3)) message = message.Replace("{2}", m3);
                if (!string.IsNullOrEmpty(m4)) message = message.Replace("{3}", m4);
                sonuc.Nesne.MSTEXT = message;
            }
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #endregion ClientFunc
    }
}
