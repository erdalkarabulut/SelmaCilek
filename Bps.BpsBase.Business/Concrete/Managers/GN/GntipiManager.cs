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

using System.Data.SqlClient;
using Bps.BpsBase.Entities.Models.GN.Listed;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.GN
{
    public class GntipiManager : IGntipiService
    {
        private IGntipiDal _gntipiDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public GntipiManager(IGntipiDal gntipiDal,IGnService gnservice,ILockedService lockedservice)
        {
            _gntipiDal = gntipiDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<GNTIPI> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNTIPI>();
            sonuc.Items = global.SirketId != null ? _gntipiDal.GetList(x => x.SIRKID == global.SirketId) : _gntipiDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNTIPI> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNTIPI>();
            sonuc.Items = global.SirketId != null ? _gntipiDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _gntipiDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNTIPI> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNTIPI>();
            sonuc.Items = global.SirketId != null ? _gntipiDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _gntipiDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNTIPI> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNTIPI>();
            sonuc.Items = global.SirketId != null ? _gntipiDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _gntipiDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNTIPI> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNTIPI>();
            sonuc.Items = global.SirketId != null ? _gntipiDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _gntipiDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNTIPI> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<GNTIPI>();
            sonuc.Nesne = _gntipiDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNTIPI> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("GNTIPI", id, global);
            var sonuc = new StandardResponse<GNTIPI>();
            sonuc.Nesne = _gntipiDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GntipiValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNTIPI> Ncch_Add_NLog(GNTIPI gntipi, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<GNTIPI>();
            gntipi.SIRKID = global.SirketId.Value; 
            gntipi.EKKULL = global.UserKod;
            gntipi.ETARIH = DateTime.Now;
            gntipi.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gntipiDal.Add(gntipi);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GntipiValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNTIPI> Ncch_Update_Log(GNTIPI gntipi,GNTIPI oldGntipi, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("GNTIPI", gntipi.Id, global);
            var sonuc = new StandardResponse<GNTIPI>();
            gntipi.SIRKID = global.SirketId.Value; 
            gntipi.DEKULL = global.UserKod;
            gntipi.DTARIH = DateTime.Now;
            gntipi.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gntipiDal.Update(gntipi);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GntipiValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNTIPI> Ncch_UpdateAktifPasif_Log(GNTIPI gntipi, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<GNTIPI>();
            gntipi.SIRKID = global.SirketId.Value; 
            gntipi.ACTIVE = !gntipi.ACTIVE;
            gntipi.DEKULL = global.UserKod;
            gntipi.DTARIH = DateTime.Now;
            gntipi.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gntipiDal.Update(gntipi);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GntipiValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNTIPI> Ncch_Delete_Log(GNTIPI gntipi, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("GNTIPI", gntipi.Id, global);
            var sonuc = new StandardResponse<GNTIPI>();
            gntipi.SIRKID = global.SirketId.Value; 
            gntipi.ACTIVE = false;
            gntipi.SLINDI = true;
            gntipi.DEKULL = global.UserKod;
            gntipi.DTARIH = DateTime.Now;
            gntipi.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gntipiDal.Update(gntipi);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        public ListResponse<TipListModel> TipListGetir(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<TipListModel>();
            var sql = @"select *,
		        (select t2.TIPADI from GNTIPI t2 where t2.TIPKOD=t.UTPKOD) as UTPADI
		        from GNTIPI as t
		        order by t.TIPKOD,t.TIPADI";

            sonuc.Items = _gntipiDal.GetListSqlQuery<TipListModel>(sql, new SqlParameter("sirketId", global.SirketId));
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNTIPI> Ncch_GetByHareketTable_NLog(Global global, string hrktbl, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }

            var sonuc = new ListResponse<GNTIPI>();
            sonuc.Items = _gntipiDal.GetList(x => x.HRKTBL == hrktbl);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNTIPI> Ncch_GetListByUstTipKod_NLog(Global global, string utpkod, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }

            var sonuc = new ListResponse<GNTIPI>();
            sonuc.Items = _gntipiDal.GetList(x => x.UTPKOD == utpkod && x.ACTIVE && !x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNTIPI> Ncch_GetByTeknikAd_NLog(Global global, string teknad, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }

            var sonuc = new StandardResponse<GNTIPI>();
            sonuc.Nesne = _gntipiDal.Get(x => x.TEKNAD == teknad && x.ACTIVE && !x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }
        #endregion ClientFunc
    }
}
