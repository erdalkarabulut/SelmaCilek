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

using System.Linq;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.GN
{
    public class GnkxmlManager : IGnkxmlService
    {
        private IGnkxmlDal _gnkxmlDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public GnkxmlManager(IGnkxmlDal gnkxmlDal,IGnService gnservice,ILockedService lockedservice)
        {
            _gnkxmlDal = gnkxmlDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<GNKXML> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNKXML>();
            sonuc.Items = global.SirketId != null ? _gnkxmlDal.GetList(x => x.SIRKID == global.SirketId) : _gnkxmlDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNKXML> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNKXML>();
            sonuc.Items = global.SirketId != null ? _gnkxmlDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _gnkxmlDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNKXML> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNKXML>();
            sonuc.Items = global.SirketId != null ? _gnkxmlDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _gnkxmlDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNKXML> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNKXML>();
            sonuc.Items = global.SirketId != null ? _gnkxmlDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _gnkxmlDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNKXML> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNKXML>();
            sonuc.Items = global.SirketId != null ? _gnkxmlDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _gnkxmlDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNKXML> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<GNKXML>();
            sonuc.Nesne = _gnkxmlDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNKXML> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("GNKXML", id, global);
            var sonuc = new StandardResponse<GNKXML>();
            sonuc.Nesne = _gnkxmlDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnkxmlValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNKXML> Ncch_Add_NLog(GNKXML gnkxml, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<GNKXML>();
            gnkxml.SIRKID = global.SirketId.Value; 
            gnkxml.EKKULL = global.UserKod;
            gnkxml.ETARIH = DateTime.Now;
            gnkxml.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnkxmlDal.Add(gnkxml);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnkxmlValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNKXML> Ncch_Update_Log(GNKXML gnkxml,GNKXML oldGnkxml, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("GNKXML", gnkxml.Id, global);
            var sonuc = new StandardResponse<GNKXML>();
            gnkxml.SIRKID = global.SirketId.Value; 
            gnkxml.DEKULL = global.UserKod;
            gnkxml.DTARIH = DateTime.Now;
            gnkxml.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnkxmlDal.Update(gnkxml);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnkxmlValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNKXML> Ncch_UpdateAktifPasif_Log(GNKXML gnkxml, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<GNKXML>();
            gnkxml.SIRKID = global.SirketId.Value; 
            gnkxml.ACTIVE = !gnkxml.ACTIVE;
            gnkxml.DEKULL = global.UserKod;
            gnkxml.DTARIH = DateTime.Now;
            gnkxml.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnkxmlDal.Update(gnkxml);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnkxmlValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNKXML> Ncch_Delete_Log(GNKXML gnkxml, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("GNKXML", gnkxml.Id, global);
            var sonuc = new StandardResponse<GNKXML>();
            gnkxml.SIRKID = global.SirketId.Value; 
            gnkxml.ACTIVE = false;
            gnkxml.SLINDI = true;
            gnkxml.DEKULL = global.UserKod;
            gnkxml.DTARIH = DateTime.Now;
            gnkxml.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnkxmlDal.Update(gnkxml);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        public ListResponse<dynamic> Ncch_GetSpecificColumnsWhere_NLog(string kulKod, string menuName, int menutag, int gridtag, Global global)
        {
            var sonuc = new ListResponse<dynamic>();
            sonuc.Items = _gnkxmlDal.GetSpecColumnsList(p => new {Tanim = p.GRDTXT, Aktif = p.VARSAY}, x =>
                x.KULKOD == kulKod
                && x.MNUNAM == menuName && x.MNUTAG == menutag && x.GRDTAG == gridtag && x.SIRKID == global.SirketId &&
                x.ACTIVE).ToList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNKXML> Ncch_GetBy_NLog(string kulKod, string menuName, int menutag, int gridtag, string gridText, Global global)
        {
            var sonuc = new StandardResponse<GNKXML>();
            sonuc.Nesne = _gnkxmlDal.Get(x => x.KULKOD == kulKod
                                              && x.MNUNAM == menuName && x.MNUTAG == menutag && x.GRDTAG == gridtag &&
                                              x.GRDTXT == gridText && x.SIRKID == global.SirketId && x.ACTIVE);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNKXML> Ncch_GetByVarsayilan_NLog(string kulKod, string menuName, int menuTag, int gridTag)
        {
            var sonuc = new StandardResponse<GNKXML>();
            sonuc.Nesne = _gnkxmlDal.Get(x => x.KULKOD == kulKod
                                              && x.MNUNAM == menuName && x.MNUTAG == menuTag && x.GRDTAG == gridTag && x.VARSAY);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #endregion ClientFunc
    }
}
