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

using Bps.BpsBase.Entities.Models.GN.Single;

using System.Linq;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.GN
{
    public class GndptnManager : IGndptnService
    {
        private IGndptnDal _gndptnDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public GndptnManager(IGndptnDal gndptnDal,IGnService gnservice,ILockedService lockedservice)
        {
            _gndptnDal = gndptnDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<GNDPTN> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNDPTN>();
            sonuc.Items = global.SirketId != null ? _gndptnDal.GetList(x => x.SIRKID == global.SirketId) : _gndptnDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNDPTN> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNDPTN>();
            sonuc.Items = global.SirketId != null ? _gndptnDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _gndptnDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNDPTN> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNDPTN>();
            sonuc.Items = global.SirketId != null ? _gndptnDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _gndptnDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNDPTN> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNDPTN>();
            sonuc.Items = global.SirketId != null ? _gndptnDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _gndptnDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNDPTN> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNDPTN>();
            sonuc.Items = global.SirketId != null ? _gndptnDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _gndptnDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNDPTN> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<GNDPTN>();
            sonuc.Nesne = _gndptnDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNDPTN> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("GNDPTN", id, global);
            var sonuc = new StandardResponse<GNDPTN>();
            sonuc.Nesne = _gndptnDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GndptnValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNDPTN> Ncch_Add_NLog(GNDPTN gndptn, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<GNDPTN>();
            gndptn.SIRKID = global.SirketId.Value; 
            gndptn.EKKULL = global.UserKod;
            gndptn.ETARIH = DateTime.Now;
            gndptn.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gndptnDal.Add(gndptn);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GndptnValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNDPTN> Ncch_Update_Log(GNDPTN gndptn,GNDPTN oldGndptn, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("GNDPTN", gndptn.Id, global);
            var sonuc = new StandardResponse<GNDPTN>();
            gndptn.SIRKID = global.SirketId.Value; 
            gndptn.DEKULL = global.UserKod;
            gndptn.DTARIH = DateTime.Now;
            gndptn.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gndptnDal.Update(gndptn);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GndptnValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNDPTN> Ncch_UpdateAktifPasif_Log(GNDPTN gndptn, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<GNDPTN>();
            gndptn.SIRKID = global.SirketId.Value; 
            gndptn.ACTIVE = !gndptn.ACTIVE;
            gndptn.DEKULL = global.UserKod;
            gndptn.DTARIH = DateTime.Now;
            gndptn.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gndptnDal.Update(gndptn);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GndptnValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNDPTN> Ncch_Delete_Log(GNDPTN gndptn, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("GNDPTN", gndptn.Id, global);
            var sonuc = new StandardResponse<GNDPTN>();
            gndptn.SIRKID = global.SirketId.Value; 
            gndptn.ACTIVE = false;
            gndptn.SLINDI = true;
            gndptn.DEKULL = global.UserKod;
            gndptn.DTARIH = DateTime.Now;
            gndptn.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gndptnDal.Update(gndptn);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        public ListResponse<GNDPTN> Cch_GetListByUretimYeri_NLog(string uretimYeri, Global global)
        {
            var sonuc = new ListResponse<GNDPTN>();
            sonuc.Items = _gndptnDal
                .GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false && x.URYRKD == uretimYeri).ToList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse Ncch_Kaydet_Log(GenelKayitModel model, Global global, bool yetkiKontrol = true)
        {
            var sonuc = new StandardResponse();

            if (model == null || model.Gndptns.Count < 1 || model.Grids.Count < 1)
            {
                sonuc.Status = ResponseStatusEnum.ERROR;
                sonuc.Message = "Veri okunamadi!";
                return sonuc;
            }

            var inserted = model.Gndptns.Where(w => w.Id == 0).ToList();
            foreach (var data in inserted)
            {
                data.SIRKID = global.SirketId.Value;
                data.KYNKKD = global.KaynakKod;
                data.ACTIVE = true;
                data.SLINDI = false;
                data.EKKULL = global.UserKod;
                data.ETARIH = DateTime.Now;
                _gndptnDal.Add(data);
            }

            model.Grids = model.Grids.Where(w => w.Tipi != "Insert").ToList();
            foreach (var grid in model.Grids)
            {
                var data = model.Gndptns.FirstOrDefault(f => f.Id == grid.Id);
                if (data == null) continue;
                data.SIRKID = global.SirketId.Value;
                data.KYNKKD = global.KaynakKod;
                if (grid.Tipi == "update")
                {
                    data.ACTIVE = true;
                    data.SLINDI = false;
                    data.DEKULL = global.UserKod;
                    data.DTARIH = DateTime.Now;
                    _gndptnDal.Update(data);
                }
                else if (grid.Tipi == "delete")
                {
                    data.ACTIVE = false;
                    data.SLINDI = true;
                    data.EKKULL = global.UserKod;
                    data.ETARIH = DateTime.Now;
                    _gndptnDal.Update(data);
                }
            }

            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #endregion ClientFunc
    }
}
