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

using System.Data.SqlClient;
using Bps.BpsBase.Entities.Models.ST.Api;
using System.Collections.Generic;
using System.Linq;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.ST
{
    public class StkartManager : IStkartService
    {
        private IStkartDal _stkartDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public StkartManager(IStkartDal stkartDal,IGnService gnservice,ILockedService lockedservice)
        {
            _stkartDal = stkartDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<STKART> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STKART>();
            sonuc.Items = global.SirketId != null ? _stkartDal.GetList(x => x.SIRKID == global.SirketId) : _stkartDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STKART> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STKART>();
            sonuc.Items = global.SirketId != null ? _stkartDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _stkartDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STKART> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STKART>();
            sonuc.Items = global.SirketId != null ? _stkartDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _stkartDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STKART> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STKART>();
            sonuc.Items = global.SirketId != null ? _stkartDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _stkartDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STKART> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STKART>();
            sonuc.Items = global.SirketId != null ? _stkartDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _stkartDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<STKART> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<STKART>();
            sonuc.Nesne = _stkartDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<STKART> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("STKART", id, global);
            var sonuc = new StandardResponse<STKART>();
            sonuc.Nesne = _stkartDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StkartValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STKART> Ncch_Add_NLog(STKART stkart, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<STKART>();
            stkart.SIRKID = global.SirketId.Value; 
            stkart.EKKULL = global.UserKod;
            stkart.ETARIH = DateTime.Now;
            stkart.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stkartDal.Add(stkart);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StkartValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STKART> Ncch_Update_Log(STKART stkart,STKART oldStkart, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("STKART", stkart.Id, global);
            var sonuc = new StandardResponse<STKART>();
            stkart.SIRKID = global.SirketId.Value; 
            stkart.DEKULL = global.UserKod;
            stkart.DTARIH = DateTime.Now;
            stkart.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stkartDal.Update(stkart);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StkartValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STKART> Ncch_UpdateAktifPasif_Log(STKART stkart, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<STKART>();
            stkart.SIRKID = global.SirketId.Value; 
            stkart.ACTIVE = !stkart.ACTIVE;
            stkart.DEKULL = global.UserKod;
            stkart.DTARIH = DateTime.Now;
            stkart.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stkartDal.Update(stkart);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StkartValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STKART> Ncch_Delete_Log(STKART stkart, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("STKART", stkart.Id, global);
            var sonuc = new StandardResponse<STKART>();
            stkart.SIRKID = global.SirketId.Value; 
            stkart.ACTIVE = false;
            stkart.SLINDI = true;
            stkart.DEKULL = global.UserKod;
            stkart.DTARIH = DateTime.Now;
            stkart.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stkartDal.Update(stkart);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        public StandardResponse<STKART> Ncch_GetByStKod_NLog(string stokKodu, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<STKART>();
            sonuc.Nesne = _stkartDal.Get(x => x.STKODU == stokKodu);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<STKART> Ncch_GetByStKodLike_NLog(string stokKodu, string malzemeTuru, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<STKART>();
            var sql = @"SELECT TOP(1) * FROM STKART WHERE SIRKID = @SirketId AND ACTIVE = 1 AND SLINDI = 0 AND STMLTR = @MalzemeTuru AND STKODU LIKE '" + stokKodu + "%' ORDER BY STKODU DESC";

            sonuc.Nesne = _stkartDal.GetSqlQuery<STKART>(sql, new SqlParameter("SirketId", global.SirketId), new SqlParameter("MalzemeTuru", malzemeTuru));
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STKART> Ncch_GetListByStKodLike_NLog(string stokKodu, string malzemeTuru, Global global,
            bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STKART>();
            var sql = @"SELECT * FROM STKART WHERE SIRKID = @SirketId AND ACTIVE = 1 AND SLINDI = 0 AND STMLTR = @MalzemeTuru AND STKODU LIKE '" + stokKodu + "%' ORDER BY STKODU";

            sonuc.Items = _stkartDal.GetListSqlQuery<STKART>(sql, new SqlParameter("SirketId", global.SirketId), new SqlParameter("MalzemeTuru", malzemeTuru));
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STKART> Cch_GetListByMalTur_NLog(Global global, string malTur, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STKART>();
            sonuc.Items = global.SirketId != null ? _stkartDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE && x.SLINDI == false && x.STMLTR == malTur) : _stkartDal.GetList(x => x.SLINDI == false && x.STMLTR == malTur);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<STKART> Ncch_GetRecentByMalTur_NLog(Global global, string malTur, bool yetkiKontrol = true)
        {
	        if (yetkiKontrol)
	        {
		        var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
		        if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
	        }

            var sonuc = new StandardResponse<STKART>();
	        sonuc.Nesne = global.SirketId != null ? _stkartDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE && x.SLINDI == false && x.STMLTR == malTur).OrderByDescending(s => s.STKODU).FirstOrDefault()
		        : _stkartDal.GetList(x => x.SLINDI == false && x.STMLTR == malTur).OrderByDescending(s => s.STKODU).FirstOrDefault();
            sonuc.Status = ResponseStatusEnum.OK;
	        return sonuc;
        }

        public ListResponse<StokKodAdModel> GetStokKodAd(Global global, List<string> filterList = null, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }

            string whereStr = "";
            foreach (string word in filterList) whereStr += " AND STKNAM LIKE '%" + word + "%'";

            var sonuc = new ListResponse<StokKodAdModel> { Items = new List<StokKodAdModel>() };
            var sql = @"SELECT TOP(20) * FROM STKART AS SK INNER JOIN STDEPO AS SD 
                ON SK.STKODU = SD.STKODU AND SK.SIRKID = SD.SIRKID AND SK.ACTIVE = SD.ACTIVE AND SK.SLINDI = SD.SLINDI 
                WHERE SK.SIRKID = @SirketId AND SK.ACTIVE = 1 AND SK.SLINDI = 0" + whereStr + " ORDER BY STKNAM";
            sonuc.Items = _stkartDal.GetListSqlQuery<StokKodAdModel>(sql, new SqlParameter("SirketId", global.SirketId));
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STKART> Ncch_GetListWithParti_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STKART>();
            sonuc.Items = global.SirketId != null ? _stkartDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false && x.PARTIT == true) : _stkartDal.GetList(x => x.SLINDI == false && x.PARTIT == true);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STKART> Ncch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STKART>();
            sonuc.Items = global.SirketId != null ? _stkartDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE && x.SLINDI == false) : _stkartDal.GetList(x => x.ACTIVE && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }
        #endregion ClientFunc
    }
}
