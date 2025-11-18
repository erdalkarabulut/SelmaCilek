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
using Bps.BpsBase.Entities.Models.ST.Listed;
using Ninject.Infrastructure.Language;
using System.Collections.Generic;
using System.Linq;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.ST
{
    public class StbdrnManager : IStbdrnService
    {
        private IStbdrnDal _stbdrnDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices
        private IGnthrkService _gnthrkService;
        #endregion ClientServices

        public StbdrnManager(IStbdrnDal stbdrnDal,IGnService gnservice,ILockedService lockedservice
        #region ClientConts
        , IGnthrkService gnthrkService
        #endregion ClientConts
            )
        {
            _stbdrnDal = stbdrnDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
            #region ClientContsitems
            _gnthrkService = gnthrkService;
            #endregion ClientContsitems

        }

        public ListResponse<STBDRN> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STBDRN>();
            sonuc.Items = global.SirketId != null ? _stbdrnDal.GetList(x => x.SIRKID == global.SirketId) : _stbdrnDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STBDRN> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STBDRN>();
            sonuc.Items = global.SirketId != null ? _stbdrnDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _stbdrnDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STBDRN> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STBDRN>();
            sonuc.Items = global.SirketId != null ? _stbdrnDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _stbdrnDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STBDRN> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STBDRN>();
            sonuc.Items = global.SirketId != null ? _stbdrnDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _stbdrnDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STBDRN> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STBDRN>();
            sonuc.Items = global.SirketId != null ? _stbdrnDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _stbdrnDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<STBDRN> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<STBDRN>();
            sonuc.Nesne = _stbdrnDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<STBDRN> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("STBDRN", id, global);
            var sonuc = new StandardResponse<STBDRN>();
            sonuc.Nesne = _stbdrnDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StbdrnValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STBDRN> Ncch_Add_NLog(STBDRN stbdrn, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<STBDRN>();
            stbdrn.SIRKID = global.SirketId.Value; 
            stbdrn.EKKULL = global.UserKod;
            stbdrn.ETARIH = DateTime.Now;
            stbdrn.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stbdrnDal.Add(stbdrn);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StbdrnValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STBDRN> Ncch_Update_Log(STBDRN stbdrn,STBDRN oldStbdrn, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("STBDRN", stbdrn.Id, global);
            var sonuc = new StandardResponse<STBDRN>();
            stbdrn.SIRKID = global.SirketId.Value; 
            stbdrn.DEKULL = global.UserKod;
            stbdrn.DTARIH = DateTime.Now;
            stbdrn.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stbdrnDal.Update(stbdrn);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StbdrnValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STBDRN> Ncch_UpdateAktifPasif_Log(STBDRN stbdrn, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<STBDRN>();
            stbdrn.SIRKID = global.SirketId.Value; 
            stbdrn.ACTIVE = !stbdrn.ACTIVE;
            stbdrn.DEKULL = global.UserKod;
            stbdrn.DTARIH = DateTime.Now;
            stbdrn.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stbdrnDal.Update(stbdrn);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StbdrnValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STBDRN> Ncch_Delete_Log(STBDRN stbdrn, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("STBDRN", stbdrn.Id, global);
            var sonuc = new StandardResponse<STBDRN>();
            stbdrn.SIRKID = global.SirketId.Value; 
            stbdrn.ACTIVE = false;
            stbdrn.SLINDI = true;
            stbdrn.DEKULL = global.UserKod;
            stbdrn.DTARIH = DateTime.Now;
            stbdrn.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stbdrnDal.Update(stbdrn);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        public ListResponse<STBDRN> Cch_GetListByStokKodu_NLog(string stokKodu, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STBDRN>();
            sonuc.Items = global.SirketId != null ? _stbdrnDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false && x.ACTIVE && x.STKODU == stokKodu) : _stbdrnDal.GetList(x => x.SLINDI == false && x.ACTIVE && x.STKODU == stokKodu);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }
        public ListResponse<StbdrnListModel> Cch_GetListModelByStok_NLog(string stokKodu, Global global, bool yetkiKontrol = true , string vrykodu = null)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<StbdrnListModel>();
            var copylist = new List<StbdrnListModel>();
            var teknads = new List<string>() { "RENKKD", "BEDNKD", "DROPKD" };
            var teknadsResponse = _gnthrkService.Ncch_GetThrkByMultiTeknad_NLog(global, teknads, false);
            var renkKdlist = teknadsResponse.Items.Where(w => w.TEKNAD == "RENKKD").ToList();
            var bedenKdlist = teknadsResponse.Items.Where(w => w.TEKNAD == "BEDNKD").ToList();
            var dropKdlist = teknadsResponse.Items.Where(w => w.TEKNAD == "DROPKD").ToList();
            if (vrykodu == null)
            {
                copylist = global.SirketId != null ? _stbdrnDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false && x.ACTIVE && x.STKODU
           == stokKodu ).MapTo<STBDRN, StbdrnListModel>()
               : _stbdrnDal.GetList(x => x.SLINDI == false && x.ACTIVE && x.STKODU == stokKodu ).MapTo<STBDRN, StbdrnListModel>();
            }
            else
            {
                copylist = global.SirketId != null ? _stbdrnDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false && x.ACTIVE && x.STKODU
                           == stokKodu && x.VRKODU == vrykodu).MapTo<STBDRN, StbdrnListModel>()
                               : _stbdrnDal.GetList(x => x.SLINDI == false && x.ACTIVE && x.STKODU == stokKodu && x.VRKODU == vrykodu).MapTo<STBDRN, StbdrnListModel>();
            }
            

            foreach (var item in copylist)
            {
                item.RENKTN = renkKdlist.Where(x => x.HARKOD == item.RENKKD).Select(x => x.TANIMI).FirstOrDefault();
                item.BEDNTN = bedenKdlist.Where(x => x.HARKOD == item.BEDNKD).Select(x => x.TANIMI).FirstOrDefault();
                item.DROPTN = dropKdlist.Where(x => x.HARKOD == item.DROPKD).Select(x => x.TANIMI).FirstOrDefault();
            }

            sonuc.Items = copylist;
            
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<STBDRN> Ncch_GetByStkoduByVaryant_NLog(string stokKodu, string vrykodu, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            //_lockedService.LockControlRead("STBDRN", id, global);
            var sonuc = new StandardResponse<STBDRN>();
            sonuc.Nesne = _stbdrnDal.Get(x => x.STKODU == stokKodu && x.VRKODU == vrykodu);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }
        #endregion ClientFunc
    }
}
