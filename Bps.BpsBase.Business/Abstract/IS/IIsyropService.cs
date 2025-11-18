using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.IS;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.IS
{
    public interface IIsyropService
    {
        ListResponse<ISYROP> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<ISYROP> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<ISYROP> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<ISYROP> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<ISYROP> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<ISYROP> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<ISYROP> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<ISYROP> Ncch_Add_NLog(ISYROP isyrop, Global global);
        StandardResponse<ISYROP> Ncch_Update_Log(ISYROP isyrop,ISYROP oldIsyrop, Global global);
        StandardResponse<ISYROP> Ncch_UpdateAktifPasif_Log(ISYROP isyrop, Global global);
        StandardResponse<ISYROP> Ncch_Delete_Log(ISYROP isyrop, Global global);

        #region ClientFunc

        ListResponse<ISYROP> Ncch_GetListByIsyeriId_NLog(int isyeriId, Global global, bool yetkiKontrol = true);

        #endregion ClientFunc
    }
}
