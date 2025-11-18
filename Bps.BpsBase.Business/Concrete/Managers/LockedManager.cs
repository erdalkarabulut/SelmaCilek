using System;
using Bps.Core.Response;
using Bps.Core.Aspects.Postsharp.CacheAspects;
using Bps.Core.CrossCuttingConcerns.Caching.Microsoft;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Exception;
using Bps.Core.Aspects.Postsharp.ValidationAspects;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.ValidationRules.FluentValidation;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.DataAccess.Abstract;
using Bps.BpsBase.Entities.Concrete;

#region ClientUsing

using System.Threading;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers
{
    public class LockedManager : ILockedService
    {
        private ILockedDal _lockedDal;
        private IGnService _gnService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public LockedManager(ILockedDal lockedDal,IGnService gnservice)
        {
            _lockedDal = lockedDal;
            _gnService = gnservice;
        }

        public ListResponse<LOCKED> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<LOCKED>();
            sonuc.Items = global.SirketId != null ? _lockedDal.GetList(x => x.SIRKID == global.SirketId) : _lockedDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<LOCKED> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<LOCKED>();
            sonuc.Nesne = _lockedDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<LOCKED> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<LOCKED>();
            sonuc.Nesne = _lockedDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(LockedValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<LOCKED> Ncch_Add_NLog(LOCKED locked, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<LOCKED>();
            locked.SIRKID = global.SirketId.Value; 
            sonuc.Nesne = _lockedDal.Add(locked);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(LockedValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<LOCKED> Ncch_Update_Log(LOCKED locked,LOCKED oldLocked, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<LOCKED>();
            locked.SIRKID = global.SirketId.Value; 
            sonuc.Nesne = _lockedDal.Update(locked);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(LockedValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<LOCKED> Ncch_Delete_Log(LOCKED locked, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<LOCKED>();
            sonuc.Nesne = _lockedDal.Delete(locked);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        public StandardResponse LockControlRead(string tableName, int? id, Global global, int lockTime = 10) // lockTime saniye cinsinden
        {
            var sonuc = new StandardResponse();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;

            LOCKED locked = null;
            LOCKED lockedOwner = null;
            LOCKED lockedOther = null;

            for (var i = 0; i < 3; i++)
            {
                if (id == null)
                {
                    locked = _lockedDal.Get(x => x.TABLNM == tableName && x.KULKOD != global.UserKod);
                    if (locked != null)
                    {
                        var dif = (DateTime.Now - locked.LCKDAT)?.TotalSeconds < locked.LCTIME;
                        if (!dif)
                        {
                            locked = null;
                        }
                    }
                    lockedOther = _lockedDal.Get(x => x.TABLNM == tableName && x.KULKOD != global.UserKod);
                    if (lockedOther != null)
                    {
                        var dif = (DateTime.Now - lockedOther.LCKDAT)?.TotalSeconds > lockedOther.LCTIME;
                        if (!dif)
                        {
                            lockedOther = null;
                        }
                    }
                    lockedOwner = _lockedDal.Get(x => x.TABLNM == tableName && x.KULKOD == global.UserKod);
                }
                else
                {
                    locked = _lockedDal.Get(x => x.TABLNM == tableName && x.LOCKID == id && x.KULKOD != global.UserKod);
                    if (locked != null)
                    {
                        var dif = (DateTime.Now - locked.LCKDAT)?.TotalSeconds < locked.LCTIME;
                        if (!dif)
                        {
                            locked = null;
                        }
                    }
                    lockedOther = _lockedDal.Get(x => x.TABLNM == tableName && x.LOCKID == id && x.KULKOD != global.UserKod);
                    if (lockedOther != null)
                    {
                        var dif = (DateTime.Now - lockedOther.LCKDAT)?.TotalSeconds > lockedOther.LCTIME;
                        if (!dif)
                        {
                            lockedOther = null;
                        }
                    }
                    lockedOwner = _lockedDal.Get(x => x.TABLNM == tableName && x.LOCKID == id && x.KULKOD == global.UserKod);
                }

                if (locked == null)
                {
                    break;
                }
                Thread.Sleep(1000);
            }

            if (locked != null)
            {
                throw new BusinessException().FromMessageNo("0003", global, m1: locked.KULKOD, mesajKod: "GN");
            }

            if (lockedOwner == null)
            {
                var model = new LOCKED()
                {
                    SIRKID = global.SirketId.Value,
                    TABLNM = tableName,
                    KULKOD = global.UserKod,
                    LOCKID = id,
                    LCKDAT = DateTime.Now,
                    LCTIME = lockTime
                };
                _lockedDal.Add(model);
            }
            else
            {
                lockedOwner.LCKDAT = DateTime.Now;
                lockedOwner.LCTIME = lockTime;
                _lockedDal.Update(lockedOwner);
            }

            if (lockedOther != null)
            {
                _lockedDal.Delete(lockedOther);
            }

            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse LockControlWrite(string tableName, int? id, Global global)
        {
            var sonuc = new StandardResponse();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;

            LOCKED locked;
            LOCKED lockedOwner;
            LOCKED lockedOther;
            if (id == null)
            {
                locked = _lockedDal.Get(x => x.TABLNM == tableName && x.KULKOD != global.UserKod);
                if (locked != null)
                {
                    var dif = (DateTime.Now - locked.LCKDAT)?.TotalSeconds < locked.LCTIME;
                    if (!dif)
                    {
                        locked = null;
                    }
                }
                lockedOther = _lockedDal.Get(x => x.TABLNM == tableName && x.KULKOD != global.UserKod);
                if (lockedOther != null)
                {
                    var dif = (DateTime.Now - lockedOther.LCKDAT)?.TotalSeconds > lockedOther.LCTIME;
                    if (!dif)
                    {
                        lockedOther = null;
                    }
                }
                lockedOwner = _lockedDal.Get(x => x.TABLNM == tableName && x.KULKOD == global.UserKod);
            }
            else
            {
                locked = _lockedDal.Get(x => x.TABLNM == tableName && x.LOCKID == id && x.KULKOD != global.UserKod);
                if (locked != null)
                {
                    var dif = (DateTime.Now - locked.LCKDAT)?.TotalSeconds < locked.LCTIME;
                    if (!dif)
                    {
                        locked = null;
                    }
                }
                lockedOther = _lockedDal.Get(x => x.TABLNM == tableName && x.LOCKID == id && x.KULKOD != global.UserKod);
                if (lockedOther != null)
                {
                    var dif = (DateTime.Now - lockedOther.LCKDAT)?.TotalSeconds > lockedOther.LCTIME;
                    if (!dif)
                    {
                        lockedOther = null;
                    }
                }
                lockedOwner = _lockedDal.Get(x => x.TABLNM == tableName && x.LOCKID == id && x.KULKOD == global.UserKod);
            }

            if (locked != null)
            {
                throw new BusinessException().FromMessageNo("0003", global, m1: locked.KULKOD, mesajKod: "GN");
            }

            if (lockedOwner != null)
            {
                _lockedDal.Delete(lockedOwner);
            }
            if (lockedOther != null)
            {
                _lockedDal.Delete(lockedOther);
            }

            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #endregion ClientFunc
    }
}
