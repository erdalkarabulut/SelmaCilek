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
using System.Collections.Generic;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.GN
{
    public class GnophrManager : IGnophrService
    {
        private IGnophrDal _gnophrDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public GnophrManager(IGnophrDal gnophrDal,IGnService gnservice,ILockedService lockedservice)
        {
            _gnophrDal = gnophrDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<GNOPHR> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNOPHR>();
            sonuc.Items = global.SirketId != null ? _gnophrDal.GetList(x => x.SIRKID == global.SirketId) : _gnophrDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNOPHR> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNOPHR>();
            sonuc.Items = global.SirketId != null ? _gnophrDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _gnophrDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNOPHR> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNOPHR>();
            sonuc.Items = global.SirketId != null ? _gnophrDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _gnophrDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNOPHR> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNOPHR>();
            sonuc.Items = global.SirketId != null ? _gnophrDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _gnophrDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNOPHR> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNOPHR>();
            sonuc.Items = global.SirketId != null ? _gnophrDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _gnophrDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNOPHR> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<GNOPHR>();
            sonuc.Nesne = _gnophrDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNOPHR> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("GNOPHR", id, global);
            var sonuc = new StandardResponse<GNOPHR>();
            sonuc.Nesne = _gnophrDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnophrValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNOPHR> Ncch_Add_NLog(GNOPHR gnophr, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<GNOPHR>();
            gnophr.SIRKID = global.SirketId.Value; 
            gnophr.EKKULL = global.UserKod;
            gnophr.ETARIH = DateTime.Now;
            gnophr.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnophrDal.Add(gnophr);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnophrValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNOPHR> Ncch_Update_Log(GNOPHR gnophr,GNOPHR oldGnophr, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("GNOPHR", gnophr.Id, global);
            var sonuc = new StandardResponse<GNOPHR>();
            gnophr.SIRKID = global.SirketId.Value; 
            gnophr.DEKULL = global.UserKod;
            gnophr.DTARIH = DateTime.Now;
            gnophr.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnophrDal.Update(gnophr);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnophrValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNOPHR> Ncch_UpdateAktifPasif_Log(GNOPHR gnophr, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<GNOPHR>();
            gnophr.SIRKID = global.SirketId.Value; 
            gnophr.ACTIVE = !gnophr.ACTIVE;
            gnophr.DEKULL = global.UserKod;
            gnophr.DTARIH = DateTime.Now;
            gnophr.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnophrDal.Update(gnophr);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnophrValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNOPHR> Ncch_Delete_Log(GNOPHR gnophr, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("GNOPHR", gnophr.Id, global);
            var sonuc = new StandardResponse<GNOPHR>();
            gnophr.SIRKID = global.SirketId.Value; 
            gnophr.ACTIVE = false;
            gnophr.SLINDI = true;
            gnophr.DEKULL = global.UserKod;
            gnophr.DTARIH = DateTime.Now;
            gnophr.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnophrDal.Update(gnophr);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc
        public ListResponse<GNOPHR> Ncch_GetListByTipKod(Global global, string tipKod, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNOPHR>();
            sonuc.Items = global.SirketId != null ? _gnophrDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE && x.TIPKOD == tipKod) : _gnophrDal.GetList(x => x.ACTIVE && x.TIPKOD == tipKod);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNOPHR> Ncch_GetListByTeknad(Global global, string teknad, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNOPHR>();
            var sql = @"select 
	                     th.*, t.TIPADI, t.TEKNAD
		                 from GNOPHR as th
		                 left join GNOPTP as t on t.TIPKOD=th.TIPKOD
		                 where th.SIRKID=@sirketId and t.SIRKID=@sirketId 
                         and th.ACTIVE=1 and th.SLINDI=0 
                         and t.ACTIVE=1 and t.SLINDI=0
		                 and t.TEKNAD=@teknad";

            sonuc.Items = _gnophrDal.GetListSqlQuery<GNOPHR>(sql,
                new SqlParameter("sirketId", global.SirketId),
                new SqlParameter("teknad", teknad));
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<TipHareketListModel> TipHareketListGetir(Global global, string tipKod, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<TipHareketListModel> { Items = new List<TipHareketListModel>() };
            var whereStr = "and th.TIPKOD=''";
            if (!string.IsNullOrEmpty(tipKod))
            {
                whereStr = " and th.TIPKOD='" + tipKod + "'";
            }
            var sql = @"select 
	                        th.Id,th.SIRKID,th.TIPKOD,t.TIPADI, th.HARKOD,th.SIRASI,th.TANIMI, th.GFIYAT, th.DVCNKD, th.ACTIVE,th.EKKULL,th.ETARIH,th.DEKULL,th.DTARIH,t.UTPKOD,th.EXTRA1,
	                        (select TANIMI from GNOPHR as th2 where th2.Id=th.PARENT) as ParentName,th.PARENT,t.TEKNAD
	                        from GNOPHR as th
	                        left join GNOPTP as t on t.TIPKOD=th.TIPKOD
                            where th.SIRKID=@sirketId and th.SLINDI=0 " + whereStr + " order by th.TIPKOD, th.SIRASI";

            sonuc.Items = _gnophrDal.GetListSqlQuery<TipHareketListModel>(sql, new SqlParameter("sirketId", global.SirketId));
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNOPHR> Ncch_GetByTipAndHarKod(Global global, string tipKod, string harkod, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<GNOPHR>();
            sonuc.Nesne = global.SirketId != null ? _gnophrDal.Get(x => x.SIRKID == global.SirketId && x.ACTIVE && x.TIPKOD == tipKod && x.HARKOD == harkod) : _gnophrDal.Get(x => x.ACTIVE && x.TIPKOD == tipKod && x.HARKOD == harkod);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }
        #endregion ClientFunc
    }
}
