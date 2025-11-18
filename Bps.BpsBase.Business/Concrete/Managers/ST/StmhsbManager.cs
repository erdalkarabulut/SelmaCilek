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
    public class StmhsbManager : IStmhsbService
    {
        private IStmhsbDal _stmhsbDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public StmhsbManager(IStmhsbDal stmhsbDal,IGnService gnservice,ILockedService lockedservice)
        {
            _stmhsbDal = stmhsbDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<STMHSB> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STMHSB>();
            sonuc.Items = global.SirketId != null ? _stmhsbDal.GetList(x => x.SIRKID == global.SirketId) : _stmhsbDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STMHSB> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STMHSB>();
            sonuc.Items = global.SirketId != null ? _stmhsbDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _stmhsbDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STMHSB> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STMHSB>();
            sonuc.Items = global.SirketId != null ? _stmhsbDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _stmhsbDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STMHSB> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STMHSB>();
            sonuc.Items = global.SirketId != null ? _stmhsbDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _stmhsbDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STMHSB> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STMHSB>();
            sonuc.Items = global.SirketId != null ? _stmhsbDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _stmhsbDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<STMHSB> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<STMHSB>();
            sonuc.Nesne = _stmhsbDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<STMHSB> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("STMHSB", id, global);
            var sonuc = new StandardResponse<STMHSB>();
            sonuc.Nesne = _stmhsbDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StmhsbValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STMHSB> Ncch_Add_NLog(STMHSB stmhsb, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<STMHSB>();
            stmhsb.SIRKID = global.SirketId.Value; 
            stmhsb.EKKULL = global.UserKod;
            stmhsb.ETARIH = DateTime.Now;
            stmhsb.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stmhsbDal.Add(stmhsb);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StmhsbValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STMHSB> Ncch_Update_Log(STMHSB stmhsb,STMHSB oldStmhsb, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("STMHSB", stmhsb.Id, global);
            var sonuc = new StandardResponse<STMHSB>();
            stmhsb.SIRKID = global.SirketId.Value; 
            stmhsb.DEKULL = global.UserKod;
            stmhsb.DTARIH = DateTime.Now;
            stmhsb.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stmhsbDal.Update(stmhsb);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StmhsbValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STMHSB> Ncch_UpdateAktifPasif_Log(STMHSB stmhsb, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<STMHSB>();
            stmhsb.SIRKID = global.SirketId.Value; 
            stmhsb.ACTIVE = !stmhsb.ACTIVE;
            stmhsb.DEKULL = global.UserKod;
            stmhsb.DTARIH = DateTime.Now;
            stmhsb.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stmhsbDal.Update(stmhsb);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StmhsbValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STMHSB> Ncch_Delete_Log(STMHSB stmhsb, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("STMHSB", stmhsb.Id, global);
            var sonuc = new StandardResponse<STMHSB>();
            stmhsb.SIRKID = global.SirketId.Value; 
            stmhsb.ACTIVE = false;
            stmhsb.SLINDI = true;
            stmhsb.DEKULL = global.UserKod;
            stmhsb.DTARIH = DateTime.Now;
            stmhsb.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stmhsbDal.Update(stmhsb);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        public ListResponse<STMHSB> Cch_GetByStokKodu_NLog(Global global, string stokKodu, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STMHSB>();
            sonuc.Items = _stmhsbDal.GetList(x =>
                x.STKODU == stokKodu && x.SIRKID == global.SirketId && x.ACTIVE && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #endregion ClientFunc
    }
}
