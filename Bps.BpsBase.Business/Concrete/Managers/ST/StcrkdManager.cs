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
using System.Collections.Generic;
using System.Data.SqlClient;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.ST
{
    public class StcrkdManager : IStcrkdService
    {
        private IStcrkdDal _stcrkdDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public StcrkdManager(IStcrkdDal stcrkdDal,IGnService gnservice,ILockedService lockedservice)
        {
            _stcrkdDal = stcrkdDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<STCRKD> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STCRKD>();
            sonuc.Items = global.SirketId != null ? _stcrkdDal.GetList(x => x.SIRKID == global.SirketId) : _stcrkdDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STCRKD> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STCRKD>();
            sonuc.Items = global.SirketId != null ? _stcrkdDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _stcrkdDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STCRKD> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STCRKD>();
            sonuc.Items = global.SirketId != null ? _stcrkdDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _stcrkdDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STCRKD> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STCRKD>();
            sonuc.Items = global.SirketId != null ? _stcrkdDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _stcrkdDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STCRKD> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STCRKD>();
            sonuc.Items = global.SirketId != null ? _stcrkdDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _stcrkdDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<STCRKD> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<STCRKD>();
            sonuc.Nesne = _stcrkdDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<STCRKD> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("STCRKD", id, global);
            var sonuc = new StandardResponse<STCRKD>();
            sonuc.Nesne = _stcrkdDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StcrkdValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STCRKD> Ncch_Add_NLog(STCRKD stcrkd, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<STCRKD>();
            stcrkd.SIRKID = global.SirketId.Value; 
            stcrkd.EKKULL = global.UserKod;
            stcrkd.ETARIH = DateTime.Now;
            stcrkd.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stcrkdDal.Add(stcrkd);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StcrkdValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STCRKD> Ncch_Update_Log(STCRKD stcrkd,STCRKD oldStcrkd, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("STCRKD", stcrkd.Id, global);
            var sonuc = new StandardResponse<STCRKD>();
            stcrkd.SIRKID = global.SirketId.Value; 
            stcrkd.DEKULL = global.UserKod;
            stcrkd.DTARIH = DateTime.Now;
            stcrkd.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stcrkdDal.Update(stcrkd);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StcrkdValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STCRKD> Ncch_UpdateAktifPasif_Log(STCRKD stcrkd, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<STCRKD>();
            stcrkd.SIRKID = global.SirketId.Value; 
            stcrkd.ACTIVE = !stcrkd.ACTIVE;
            stcrkd.DEKULL = global.UserKod;
            stcrkd.DTARIH = DateTime.Now;
            stcrkd.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stcrkdDal.Update(stcrkd);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StcrkdValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STCRKD> Ncch_Delete_Log(STCRKD stcrkd, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("STCRKD", stcrkd.Id, global);
            var sonuc = new StandardResponse<STCRKD>();
            stcrkd.SIRKID = global.SirketId.Value; 
            stcrkd.ACTIVE = false;
            stcrkd.SLINDI = true;
            stcrkd.DEKULL = global.UserKod;
            stcrkd.DTARIH = DateTime.Now;
            stcrkd.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stcrkdDal.Update(stcrkd);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc
        public ListResponse<STCRKD> Cch_GetListByStokKodu_NLog(string stokKodu,string vrykod, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STCRKD>();
            sonuc.Items = global.SirketId != null ? _stcrkdDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false && x.ACTIVE && x.STKODU == stokKodu && x.VRKODU == vrykod) : _stcrkdDal.GetList(x => x.SLINDI == false && x.ACTIVE && x.STKODU == stokKodu && x.VRKODU == vrykod);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StcrkdValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse Ncch_MultiAdd_Log(List<STCRKD> stcrkd, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
                //_lockedService.LockControlWrite("GNYETB", gnyetb.Id, global);
            }
            var sonuc = new StandardResponse();
            foreach (var item in stcrkd)
            {
                item.SIRKID = (int)global.SirketId;
                item.EKKULL = global.UserKod;
                item.ETARIH = DateTime.Now;
                item.KYNKKD = global.KaynakKod;
                item.ACTIVE = true;
            }

            bool _ok = _stcrkdDal.MultiAdd(stcrkd);
            if (_ok)
            {
                sonuc.Status = ResponseStatusEnum.OK;
            }
            else
            {
                sonuc.Status = ResponseStatusEnum.ERROR;
            }

            return sonuc;
        }
        public StandardResponse<STCRKD> Ncch_GetByCRVRKO_NLog(string _crvrko,string _crkodu, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            
            var sonuc = new StandardResponse<STCRKD>();
            sonuc.Nesne = _stcrkdDal.Get(x => x.CRVRKO == _crvrko && x.CRKODU == _crkodu);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public string Ncch_HardDelete_Log(string stkodu, Global global)
        {
            try
            {
                var sql = @"DELETE FROM STCRKD WHERE STKODU = @Stkodu AND SIRKID = @SirketId";
                _stcrkdDal.ExecuteSqlQuery(sql, new SqlParameter("@SirketId", global.SirketId), new SqlParameter("@Stkodu", stkodu));
                return "Stokla ilgili tüm entegrasyonlar silindi";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        #endregion ClientFunc
    }
}
